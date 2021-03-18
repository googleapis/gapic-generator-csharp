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
using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.ServiceConfig;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            ResourceExtensions.ResourceReference
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
            foreach (var singlePackageFileDescs in byPackage)
            {
                var namespaces = singlePackageFileDescs.Select(x => x.CSharpNamespace()).Distinct().ToList();
                if (namespaces.Count > 1)
                {
                    throw new InvalidOperationException(
                        "All files in the same package must have the same C# namespace. " +
                        $"Found namespaces '{string.Join(", ", namespaces)}' in package '{singlePackageFileDescs.Key}'.");
                }
                var catalog = new ProtoCatalog(singlePackageFileDescs.Key, descriptors, commonResourcesConfigs);
                foreach (var resultFile in GeneratePackage(namespaces[0], singlePackageFileDescs, catalog, clock, grpcServiceConfig))
                {
                    yield return resultFile;
                }
            }
        }

        private static IEnumerable<ResultFile> GeneratePackage(string ns, IEnumerable<FileDescriptor> packageFileDescriptors, ProtoCatalog catalog, IClock clock,
            ServiceConfig grpcServiceConfig)
        {
            var clientPathPrefix = $"{ns}{Path.DirectorySeparatorChar}";
            var snippetsPathPrefix = $"{ns}.Snippets{Path.DirectorySeparatorChar}";
            var standaloneSnippetsPathPrefix = $"{ns}.StandaloneSnippets{Path.DirectorySeparatorChar}";
            var unitTestsPathPrefix = $"{ns}.Tests{Path.DirectorySeparatorChar}";
            bool hasLro = false;
            bool hasContent = false;
            HashSet<string> allResourceNameClasses = new HashSet<string>();
            HashSet<string> duplicateResourceNameClasses = new HashSet<string>();

            var allServiceDetails = new List<ServiceDetails>();
            foreach (var fileDesc in packageFileDescriptors)
            {
                foreach (var service in fileDesc.Services)
                {
                    // Generate settings and client code for requested package.
                    var serviceDetails = new ServiceDetails(catalog, ns, service, grpcServiceConfig);
                    allServiceDetails.Add(serviceDetails);

                    var ctx = SourceFileContext.CreateFullyAliased(clock, s_wellknownNamespaceAliases);
                    var code = ServiceCodeGenerator.Generate(ctx, serviceDetails);
                    var filename = $"{clientPathPrefix}{serviceDetails.ClientAbstractTyp.Name}.g.cs";
                    yield return new ResultFile(filename, code);
                    // Generate snippets for the service
                    // TODO: Consider removing this once we have integrated the standalone snippets
                    // with docs generation.
                    var snippetCtx = SourceFileContext.CreateUnaliased(
                        clock, s_wellknownNamespaceAliases, s_avoidAliasingNamespaceRegex, maySkipOwnNamespaceImport: true);
                    var snippetCode = SnippetCodeGenerator.Generate(snippetCtx, serviceDetails);
                    var snippetFilename = $"{snippetsPathPrefix}{serviceDetails.ClientAbstractTyp.Name}Snippets.g.cs";
                    yield return new ResultFile(snippetFilename, snippetCode);
                    // Generate standalone snippets for the service
                    // TODO: Integrate standalone snippets with docs generation.
                    // TODO: Once (and if we) generate just one set of snippets, stop using "standalone" as a differentiatior.
                    foreach (var snippetGenerator in SnippetCodeGenerator.StandaloneGenerators(serviceDetails))
                    {
                        var standaloneSnippetCtx = SourceFileContext.CreateUnaliased(
                            clock, s_wellknownNamespaceAliases, s_avoidAliasingNamespaceRegex, maySkipOwnNamespaceImport: false);
                        var standaloneSnippetCode = snippetGenerator.Generate(standaloneSnippetCtx);
                        var standaloneSnippetFilename = $"{standaloneSnippetsPathPrefix}{serviceDetails.ClientAbstractTyp.Name}.{snippetGenerator.SnippetMethodName}Snippet.g.cs";
                        yield return new ResultFile(standaloneSnippetFilename, standaloneSnippetCode);
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
            }
            // Now we've processed all the files, check for duplicate resource names.
            if (duplicateResourceNameClasses.Count > 0)
            {
                throw new InvalidOperationException($"The following resource name classes were created multiple times: {string.Join(", ", duplicateResourceNameClasses)}");
            }
            // Only output csproj's if there is any other generated content.
            // When processing a (proto) package without any services there will be no generated content.
            if (hasContent)
            {
                // Generate client csproj.
                var csprojContent = CsProjGenerator.GenerateClient(hasLro);
                var csprojFilename = $"{clientPathPrefix}{ns}.csproj";
                yield return new ResultFile(csprojFilename, csprojContent);
                // Generate snippets csproj.
                var snippetsCsprojContent = CsProjGenerator.GenerateSnippets(ns);
                var snippetsCsProjFilename = $"{snippetsPathPrefix}{ns}.Snippets.csproj";
                yield return new ResultFile(snippetsCsProjFilename, snippetsCsprojContent);
                // Generate standalone snippets csproj.
                var standaloneSnippetsCsprojContent = CsProjGenerator.GenerateSnippets(ns);
                var standaloneSnippetsCsProjFilename = $"{standaloneSnippetsPathPrefix}{ns}.StandaloneSnippets.csproj";
                yield return new ResultFile(standaloneSnippetsCsProjFilename, standaloneSnippetsCsprojContent);
                // Generate unit-tests csproj.
                var unitTestsCsprojContent = CsProjGenerator.GenerateUnitTests(ns);
                var unitTestsCsprojFilename = $"{unitTestsPathPrefix}{ns}.Tests.csproj";
                yield return new ResultFile(unitTestsCsprojFilename, unitTestsCsprojContent);
                // Generate gapic_metadata.json
                var gapicMetadataJsonContent = MetadataGenerator.GenerateGapicMetadataJson(allServiceDetails);
                var gapicMetadataJsonFilename = $"{clientPathPrefix}gapic_metadata.json";
                yield return new ResultFile(gapicMetadataJsonFilename, gapicMetadataJsonContent);
            }
        }
    }
}
