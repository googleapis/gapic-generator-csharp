// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Gax;
using Google.Api.Generator.Generation;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Cloud;
using Google.Cloud.Tools.SnippetGen.SnippetIndex.V1;
using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.ServiceConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Google.Api.Generator
{
    internal static class CodeGenerator
    {
        /// <summary>
        /// Extension registry with everything we need in.
        /// </summary>
        private static readonly ExtensionRegistry s_registry = new ExtensionRegistry
        {
            ClientExtensions.DefaultHost,
            ClientExtensions.MethodSignature,
            ClientExtensions.OauthScopes,
            OperationsExtensions.OperationInfo,
            FieldBehaviorExtensions.FieldBehavior,
            AnnotationsExtensions.Http,
            ResourceExtensions.Resource,
            ResourceExtensions.ResourceDefinition,
            ResourceExtensions.ResourceReference,
            ExtendedOperationsExtensions.OperationField,
            ExtendedOperationsExtensions.OperationPollingMethod,
            ExtendedOperationsExtensions.OperationRequestField,
            ExtendedOperationsExtensions.OperationResponseField,
            ExtendedOperationsExtensions.OperationService,
        };

        private static readonly IReadOnlyDictionary<string, string> s_wellknownNamespaceAliases = new Dictionary<string, string>
            {
                { typeof(System.Int32).Namespace, "sys" }, // Don't use "s"; one-letter aliases cause a compilation error!
                { typeof(System.Net.WebUtility).Namespace, "sysnet" },
                { typeof(System.Collections.Generic.IEnumerable<>).Namespace, "scg" },
                { typeof(System.Collections.ObjectModel.Collection<>).Namespace, "sco" },
                { typeof(System.Linq.Enumerable).Namespace, "linq" },
                { typeof(Google.Api.Gax.Expiration).Namespace, "gax" },
                { typeof(Google.Api.Gax.Grpc.CallSettings).Namespace, "gaxgrpc" },
                { typeof(Google.Api.Gax.Grpc.GrpcCore.GrpcCoreAdapter).Namespace, "gaxgrpccore" },
                { typeof(Grpc.Core.CallCredentials).Namespace, "grpccore" },
                { typeof(Grpc.Core.Interceptors.Interceptor).Namespace, "grpcinter" },
                { typeof(Google.Protobuf.WellKnownTypes.Any).Namespace, "wkt" },
                { typeof(Google.LongRunning.Operation).Namespace, "lro" },
                { typeof(Google.Protobuf.ByteString).Namespace, "proto" },
                { typeof(Moq.Mock).Namespace, "moq" },
                { typeof(Xunit.Assert).Namespace, "xunit" },
            };

        /// <summary>
        /// For unaliased source file context, we still have to sometimes aliase some namespaces to avoid
        /// name collisions.
        /// This collection is used to influence the order in which colliding namespaces are picked for
        /// aliasing.
        /// </summary>
        private static readonly IReadOnlyCollection<Regex> s_avoidAliasingNamespaceRegex = new HashSet<Regex>
        {
            new Regex(@"^System\.?.*", RegexOptions.Compiled | RegexOptions.CultureInvariant),
        };

        public static IEnumerable<ResultFile> Generate(FileDescriptorSet descriptorSet, string package, IClock clock,
            string grpcServiceConfigPath, IEnumerable<string> commonResourcesConfigPaths)
        {
            var descriptors = descriptorSet.File;
            var filesToGenerate = descriptors.Where(x => x.Package == package).Select(x => x.Name).ToList();
            return Generate(descriptors, filesToGenerate, clock, grpcServiceConfigPath, commonResourcesConfigPaths);
        }

        public static IEnumerable<ResultFile> Generate(IReadOnlyList<FileDescriptorProto> descriptorProtos, IEnumerable<string> filesToGenerate, IClock clock,
            string grpcServiceConfigPath, IEnumerable<string> commonResourcesConfigPaths)
        {
            var descriptors = FileDescriptor.BuildFromByteStrings(descriptorProtos.Select(proto => proto.ToByteString()), s_registry);
            // Load side-loaded configurations; both optional.
            var grpcServiceConfig = grpcServiceConfigPath != null ? ServiceConfig.Parser.ParseJson(File.ReadAllText(grpcServiceConfigPath)) : null;
            var commonResourcesConfigs = commonResourcesConfigPaths != null ?
                commonResourcesConfigPaths.Select(path => CommonResources.Parser.ParseJson(File.ReadAllText(path))) : null;
            // TODO: Multi-package support not tested.
            var filesToGenerateSet = filesToGenerate.ToHashSet();
            var byPackage = descriptors.Where(x => filesToGenerateSet.Contains(x.Name)).GroupBy(x => x.Package).ToList();
            if (byPackage.Count == 0)
            {
                throw new InvalidOperationException("No packages specified to build.");
            }

            // Collect all service details here to emit one `gapic_metadata.json` file for multi-package situations (e.g. Kms with Iam)
            var allServiceDetails = new List<ServiceDetails>();
            foreach (var singlePackageFileDescs in byPackage)
            {
                var namespaces = singlePackageFileDescs.Select(x => x.CSharpNamespace()).Distinct().ToList();
                if (namespaces.Count > 1)
                {
                    throw new InvalidOperationException(
                        "All files in the same package must have the same C# namespace. " +
                        $"Found namespaces '{string.Join(", ", namespaces)}' in package '{singlePackageFileDescs.Key}'.");
                }
                var catalog = new ProtoCatalog(singlePackageFileDescs.Key, descriptors, singlePackageFileDescs, commonResourcesConfigs);
                foreach (var resultFile in GeneratePackage(namespaces[0], singlePackageFileDescs, catalog, clock, grpcServiceConfig, allServiceDetails))
                {
                    yield return resultFile;
                }
            }

            if (allServiceDetails.Any())
            {
                // Generate gapic_metadata.json, if there are any services.
                var gapicMetadataJsonContent = MetadataGenerator.GenerateGapicMetadataJson(allServiceDetails);
                yield return new ResultFile("gapic_metadata.json", gapicMetadataJsonContent);
            }
        }

        private static IEnumerable<ResultFile> GeneratePackage(string ns,
            IEnumerable<FileDescriptor> packageFileDescriptors, ProtoCatalog catalog, IClock clock,
            ServiceConfig grpcServiceConfig, List<ServiceDetails> allServiceDetails)
        {
            var clientPathPrefix = $"{ns}{Path.DirectorySeparatorChar}";
            var serviceSnippetsPathPrefix = $"{ns}.Snippets{Path.DirectorySeparatorChar}";
            var snippetsPathPrefix = $"{ns}.GeneratedSnippets{Path.DirectorySeparatorChar}";
            var unitTestsPathPrefix = $"{ns}.Tests{Path.DirectorySeparatorChar}";
            bool hasLro = false;
            bool hasContent = false;
            var packageServiceDetails = new List<ServiceDetails>();
            HashSet<string> allResourceNameClasses = new HashSet<string>();
            HashSet<string> duplicateResourceNameClasses = new HashSet<string>();
            IList<Snippet> snippets = new List<Snippet>();

            IEnumerable<Typ> packageTyps = packageFileDescriptors.SelectMany(
                fileDescriptor => fileDescriptor.Services.Select(serv => Typ.Manual(ns, serv.Name))
                    .Union(fileDescriptor.MessageTypes.Select(msg => Typ.Manual(ns, msg.Name)))
                    .Union(fileDescriptor.EnumTypes.Select(e => Typ.Manual(ns, e.Name, isEnum: true))));

            var seenPaginatedResponseTyps = new HashSet<Typ>();
            foreach (var fileDesc in packageFileDescriptors)
            {
                foreach (var service in fileDesc.Services)
                {
                    // Generate settings and client code for requested package.
                    var serviceDetails = new ServiceDetails(catalog, ns, service, grpcServiceConfig);
                    packageServiceDetails.Add(serviceDetails);

                    var ctx = SourceFileContext.CreateFullyAliased(clock, s_wellknownNamespaceAliases);
                    var code = ServiceCodeGenerator.Generate(ctx, serviceDetails, seenPaginatedResponseTyps);
                    var filename = $"{clientPathPrefix}{serviceDetails.ClientAbstractTyp.Name}.g.cs";
                    yield return new ResultFile(filename, code);
                    // Generate service-per-file snippets for the service
                    // TODO: Consider removing this once we have integrated the snippet-per-file snippets
                    // with docs generation.
                    var serviceSnippetsCtx = SourceFileContext.CreateUnaliased(
                        clock, s_wellknownNamespaceAliases, s_avoidAliasingNamespaceRegex, packageTyps, maySkipOwnNamespaceImport: true);
                    var serviceSnippetsCode = SnippetCodeGenerator.Generate(serviceSnippetsCtx, serviceDetails);
                    var serviceSnippetsFilename = $"{serviceSnippetsPathPrefix}{serviceDetails.ClientAbstractTyp.Name}Snippets.g.cs";
                    yield return new ResultFile(serviceSnippetsFilename, serviceSnippetsCode);
                    // Generate snippet-per-file snippets for the service
                    // TODO: Integrate snippet-per-file snippets with docs generation.
                    foreach (var snippetGenerator in SnippetCodeGenerator.SnippetsGenerators(serviceDetails))
                    {
                        var snippetCtx = SourceFileContext.CreateUnaliased(
                            clock, s_wellknownNamespaceAliases, s_avoidAliasingNamespaceRegex, packageTyps, maySkipOwnNamespaceImport: false);
                        var (snippetCode, snippetMetadata) = snippetGenerator.Generate(snippetCtx);
                        snippetMetadata.File = $"{serviceDetails.ClientAbstractTyp.Name}.{snippetGenerator.SnippetMethodName}Snippet.g.cs";
                        var snippetFile = $"{snippetsPathPrefix}{snippetMetadata.File}";
                        snippets.Add(snippetMetadata);
                        yield return new ResultFile(snippetFile, snippetCode);
                    }
                    // Generate unit tests for the the service.
                    var unitTestCtx = SourceFileContext.CreateFullyAliased(clock, s_wellknownNamespaceAliases);
                    var unitTestCode = UnitTestCodeGeneration.Generate(unitTestCtx, serviceDetails);
                    var unitTestFilename = $"{unitTestsPathPrefix}{serviceDetails.ClientAbstractTyp.Name}Test.g.cs";
                    yield return new ResultFile(unitTestFilename, unitTestCode);
                    // Record whether LRO is used.
                    hasLro |= serviceDetails.Methods.Any(x => x is MethodDetails.Lro);
                    hasContent = true;
                }
                var resCtx = SourceFileContext.CreateFullyAliased(clock, s_wellknownNamespaceAliases);
                var (resCode, resCodeClassCount) = ResourceNamesGenerator.Generate(catalog, resCtx, fileDesc);
                // Only produce an output file if it contains >0 [partial] classes.
                if (resCodeClassCount > 0)
                {
                    // Keep track of the resource names, to spot duplicates
                    var resourceNameClasses = catalog.GetResourceDefsByFile(fileDesc)
                        .Where(def => def.HasNotWildcard && !def.IsCommon)
                        .Select(def => def.ResourceNameTyp.Name);
                    foreach (var resourceNameClass in resourceNameClasses)
                    {
                        if (!allResourceNameClasses.Add(resourceNameClass))
                        {
                            duplicateResourceNameClasses.Add(resourceNameClass);
                        }
                    }

                    // Yield the file to be generated.
                    var filenamePrefix = Path.GetFileNameWithoutExtension(fileDesc.Name).ToUpperCamelCase();
                    var resFilename = $"{clientPathPrefix}{filenamePrefix}ResourceNames.g.cs";
                    yield return new ResultFile(resFilename, resCode);
                    hasContent = true;
                }

                var lroAdaptationCtx = SourceFileContext.CreateFullyAliased(clock, s_wellknownNamespaceAliases);
                var (lroCode, lroClassCount) = LroAdaptationGenerator.Generate(catalog, lroAdaptationCtx, fileDesc);
                if (lroClassCount > 0)
                {
                    var filenamePrefix = Path.GetFileNameWithoutExtension(fileDesc.Name).ToUpperCamelCase();
                    var lroAdaptationFilename = $"{clientPathPrefix}{filenamePrefix}LroAdaptation.g.cs";
                    yield return new ResultFile(lroAdaptationFilename, lroCode);
                    hasContent = true;
                }
            }
            // Now we've processed all the files, check for duplicate resource names.
            if (duplicateResourceNameClasses.Count > 0)
            {
                throw new InvalidOperationException($"The following resource name classes were created multiple times: {string.Join(", ", duplicateResourceNameClasses)}");
            }
            // Only output csproj's and snippet metadata if there is any other generated content.
            // When processing a (proto) package without any services there will be no generated content.
            if (hasContent)
            {
                // Generate client csproj.
                var csprojContent = CsProjGenerator.GenerateClient(hasLro);
                var csprojFilename = $"{clientPathPrefix}{ns}.csproj";
                yield return new ResultFile(csprojFilename, csprojContent);
                // If we only generated resources, we don't need to generate all of these.
                if (packageServiceDetails.Count > 0)
                {
                    allServiceDetails.AddRange(packageServiceDetails);

                    // Generate snippets csproj.
                    var serviceSnippetsCsprojContent = CsProjGenerator.GenerateSnippets(ns);
                    var serviceSnippetsCsProjFilename = $"{serviceSnippetsPathPrefix}{ns}.Snippets.csproj";
                    yield return new ResultFile(serviceSnippetsCsProjFilename, serviceSnippetsCsprojContent);
                    // Generate snippet metadata (only for snippet-per-file snippets).
                    // All services in this package have the same package information, namespace etc. so, we
                    // just pick the first one
                    var serviceDetails = packageServiceDetails.First();
                    var snippetIndexJsonContent = SnippetCodeGenerator.GenerateSnippetIndexJson(snippets, serviceDetails);
                    yield return new ResultFile($"{snippetsPathPrefix}snippet_metadata_{serviceDetails.ProtoPackage}.json", snippetIndexJsonContent);
                    // Generate snippet-per-file snippets csproj.
                    var snippetsCsprojContent = CsProjGenerator.GenerateSnippets(ns);
                    var snippetsCsProjFilename = $"{snippetsPathPrefix}{ns}.GeneratedSnippets.csproj";
                    yield return new ResultFile(snippetsCsProjFilename, snippetsCsprojContent);
                    // Generate unit-tests csproj.
                    var unitTestsCsprojContent = CsProjGenerator.GenerateUnitTests(ns);
                    var unitTestsCsprojFilename = $"{unitTestsPathPrefix}{ns}.Tests.csproj";
                    yield return new ResultFile(unitTestsCsprojFilename, unitTestsCsprojContent);
                }
            }
        }
    }
}
