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
using Google.Cloud.Iam.V1;
using Google.Cloud.Location;
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
using YamlDotNet.Serialization;

namespace Google.Api.Generator
{
    internal static class CodeGenerator
    {
        /// <summary>
        /// Extension registry with everything we need in.
        /// </summary>
        private static readonly ExtensionRegistry Registry = new ExtensionRegistry
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
            RoutingExtensions.Routing,
            ExtendedOperationsExtensions.OperationField,
            ExtendedOperationsExtensions.OperationPollingMethod,
            ExtendedOperationsExtensions.OperationRequestField,
            ExtendedOperationsExtensions.OperationResponseField,
            ExtendedOperationsExtensions.OperationService,
        };

        private static readonly IReadOnlyDictionary<string, string> WellknownNamespaceAliases = new Dictionary<string, string>
        {
            { typeof(System.Int32).Namespace, "sys" }, // Don't use "s"; one-letter aliases cause a compilation error!
            { typeof(System.Net.WebUtility).Namespace, "sysnet" },
            { typeof(System.Collections.Generic.IEnumerable<>).Namespace, "scg" },
            { typeof(System.Collections.ObjectModel.Collection<>).Namespace, "sco" },
            { typeof(System.Linq.Enumerable).Namespace, "linq" },
            { typeof(Google.Api.Gax.Expiration).Namespace, "gax" },
            { typeof(Google.Api.Gax.Grpc.CallSettings).Namespace, "gaxgrpc" },
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
        private static readonly IReadOnlyCollection<Regex> AvoidAliasingNamespaceRegex = new HashSet<Regex>
        {
            new Regex(@"^System\.?.*", RegexOptions.Compiled | RegexOptions.CultureInvariant),
        };

        private static readonly IReadOnlyList<ServiceDescriptor> AllowedAdditionalServices = new List<ServiceDescriptor>
        {
            IAMPolicy.Descriptor,
            Locations.Descriptor,
            Operations.Descriptor,
        }.AsReadOnly();

        public static IEnumerable<ResultFile> Generate(FileDescriptorSet descriptorSet, string package, IClock clock,
            string grpcServiceConfigPath, string serviceConfigPath, IEnumerable<string> commonResourcesConfigPaths, ApiTransports transports, bool requestNumericEnumJsonEncoding)
        {
            var descriptors = descriptorSet.File;
            var filesToGenerate = descriptors.Where(x => x.Package == package).Select(x => x.Name).ToList();
            return Generate(descriptors, filesToGenerate, clock, grpcServiceConfigPath, serviceConfigPath, commonResourcesConfigPaths, transports, requestNumericEnumJsonEncoding);
        }

        public static IEnumerable<ResultFile> Generate(IReadOnlyList<FileDescriptorProto> descriptorProtos, IEnumerable<string> filesToGenerate, IClock clock,
            string grpcServiceConfigPath, string serviceConfigPath, IEnumerable<string> commonResourcesConfigPaths, ApiTransports transports, bool requestNumericEnumJsonEncoding)
        {
            var descriptors = FileDescriptor.BuildFromByteStrings(descriptorProtos.Select(proto => proto.ToByteString()), Registry);
            // Load side-loaded configurations; both optional.
            var grpcServiceConfig = grpcServiceConfigPath is object ? ServiceConfig.Parser.ParseJson(File.ReadAllText(grpcServiceConfigPath)) : null;
            var serviceConfig = ParseServiceConfigYaml(serviceConfigPath);

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
            var resultFilesByProtoPackage = new Dictionary<string, List<ResultFile>>();
            foreach (var singlePackageFileDescs in byPackage)
            {
                // Find the right library settings by matching the proto package we're publishing.
                var librarySettings = serviceConfig?.Publishing?.LibrarySettings?.FirstOrDefault(ls => ls.Version == singlePackageFileDescs.Key);

                var namespaces = singlePackageFileDescs.Select(x => x.CSharpNamespace()).Distinct().ToList();
                if (namespaces.Count > 1)
                {
                    throw new InvalidOperationException(
                        "All files in the same package must have the same C# namespace. " +
                        $"Found namespaces '{string.Join(", ", namespaces)}' in package '{singlePackageFileDescs.Key}'.");
                }
                var catalog = new ProtoCatalog(singlePackageFileDescs.Key, descriptors, singlePackageFileDescs, commonResourcesConfigs, librarySettings);
                var files = new List<ResultFile>();
                foreach (var resultFile in GeneratePackage(
                    namespaces[0], singlePackageFileDescs, catalog, clock,
                    grpcServiceConfig, serviceConfig, allServiceDetails,
                    transports, requestNumericEnumJsonEncoding, librarySettings))
                {
                    files.Add(resultFile);
                }
                if (files.Count > 0)
                {
                    resultFilesByProtoPackage[singlePackageFileDescs.Key] = files;
                }
            }

            var resultFiles = GetResultFilesToCreate(resultFilesByProtoPackage);

            // We assume that the first service we've generated corresponds to the service config (if we have one),
            // and is a service from the primary library we're generating. This is used for API validation and
            // gapic_metadata.json generation. This means it doesn't matter (for gapic_metadata.json)
            // if we're actually asked to generate more services than we really want. This currently
            // happens for services with IAM/location mix-ins, for example.
            var primaryLibraryProtoPackage = allServiceDetails.FirstOrDefault()?.ProtoPackage;
            var primaryLibraryServices = allServiceDetails.Where(s => s.ProtoPackage == primaryLibraryProtoPackage).ToList();

            if (primaryLibraryServices.Any())
            {
                // Generate gapic_metadata.json, if there are any services.
                var gapicMetadataJsonContent = MetadataGenerator.GenerateGapicMetadataJson(primaryLibraryServices);
                resultFiles.Add(new ResultFile("gapic_metadata.json", gapicMetadataJsonContent));
            }

            var unhandledApis = (serviceConfig?.Apis.Select(api => api.Name) ?? Enumerable.Empty<string>())
                .Except(primaryLibraryServices.Select(s => s.ServiceFullName))
                .Except(AllowedAdditionalServices.Select(s => s.FullName))
                .ToList();

            if (unhandledApis.Any())
            {
                throw new InvalidOperationException($"Unhandled APIs in service config: {string.Join(", ", unhandledApis)}");
            }

            ValidateTransports(transports, allServiceDetails);
            return resultFiles;

            // Returns the result files we should actually create, ignoring mix-ins unless we're actually
            // generating the mix-in API.
            // This is necessary because Bazel passes more files to generate than we really want.
            // Note that this method may modify filesByProtoPackage - we're not using it after calling this method though.
            static List<ResultFile> GetResultFilesToCreate(Dictionary<string, List<ResultFile>> filesByProtoPackage)
            {
                var mixinPackages = AllowedAdditionalServices.Select(svc => svc.File.Package).ToHashSet();

                // Unless we're *only* generating mixins, remove all mixins.
                if (!filesByProtoPackage.Keys.All(mixinPackages.Contains))
                {
                    foreach (var pkg in mixinPackages)
                    {
                        filesByProtoPackage.Remove(pkg);
                    }
                }

                // We may still have multiple packages here, and that's probably not
                // ideal, but it's not too bad - and it deals with the common situation.
                return filesByProtoPackage.Values.SelectMany(list => list).ToList();
            }
        }

        private static void ValidateTransports(ApiTransports transports, List<ServiceDetails> services)
        {
            // Note: we only look at the HttpRule options in the proto. While others can be provided
            // in the service config, those should only be for mixins, which aren't included in the list
            // of services. If we discover a need to use service config overrides for the "main" services,
            // we can accept the service config here and find the overrides.
            // It's just possible that a user could create a client with the REST adapter solely for the purpose
            // of accessing mixins to call via REST, and we're effectively prohibiting that - but it's much more
            // likely that this is an accidental configuration failure that's worth fixing, so it's fine to be
            // conservative.
            if ((transports & ApiTransports.Rest) != 0)
            {
                var methodDescriptors = services.SelectMany(svc => svc.Methods).Select(method => method.Descriptor);
                if (methodDescriptors.All(method => method.GetOptions()?.GetExtension(AnnotationsExtensions.Http) is null))
                {
                    throw new InvalidOperationException("REST transport was requested, but no method in any service has an HTTP annotation");
                }
            }
        }

        private static Service ParseServiceConfigYaml(string path)
        {
            if (path is null)
            {
                return null;
            }
            
            // Parsing straight from YAML to the proto representation of a service config is
            // difficult. Instead, we convert the YAML to JSON, and parse that.
            var deserializer = new Deserializer();
            using var reader = File.OpenText(path);
            var yamlObject = deserializer.Deserialize(reader);
            var serializer = new SerializerBuilder().JsonCompatible().Build();
            var writer = new StringWriter();
            serializer.Serialize(writer, yamlObject);
            string json = writer.ToString();

            // Unfortunately the YAML to JSON conversion isn't aware of types, so Boolean values
            // are represented as strings, and need to be converted to JSON Boolean values.
            // In theory this could create problems if there are *genuine* string values of "true"
            // or "false", but those will show up at generation time, and we can address them then.
            // Using a leading space prevents accidentally replacing part of a string value with
            // an escaped double-quote. (The YAML/JSON conversion always generates spaces before values.)
            // This is undoubtedly hacky, but should be sufficient for now.
            json = json.Replace(" \"true\"", " true").Replace(" \"false\"", " false");
            
            var parser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));
            return parser.Parse<Service>(json);
        }

        private static IEnumerable<ResultFile> GeneratePackage(string ns,
            IEnumerable<FileDescriptor> packageFileDescriptors, ProtoCatalog catalog, IClock clock,
            ServiceConfig grpcServiceConfig, Service serviceConfig, List<ServiceDetails> allServiceDetails,
            ApiTransports transports, bool requestNumericEnumJsonEncoding, ClientLibrarySettings librarySettings)
        {
            var clientPathPrefix = $"{ns}{Path.DirectorySeparatorChar}";
            var serviceSnippetsPathPrefix = $"{ns}.Snippets{Path.DirectorySeparatorChar}";
            var snippetsPathPrefix = $"{ns}.GeneratedSnippets{Path.DirectorySeparatorChar}";
            var unitTestsPathPrefix = $"{ns}.Tests{Path.DirectorySeparatorChar}";
            bool hasLro = false;
            HashSet<string> mixins = new HashSet<string>();
            bool hasContent = false;
            var packageServiceDetails = new List<ServiceDetails>();
            HashSet<string> allResourceNameClasses = new HashSet<string>();
            HashSet<string> duplicateResourceNameClasses = new HashSet<string>();
            IList<Snippet> snippets = new List<Snippet>();

            var dependencyProtoPackages = packageFileDescriptors
                .SelectMany(descriptor => descriptor.Dependencies.Concat(descriptor.PublicDependencies))
                .Select(dependency => dependency.Package)
                .ToHashSet();

            IReadOnlyCollection<string> forcedAliases = librarySettings?.DotnetSettings?.ForcedNamespaceAliases?.ToList() ?? new List<string>();

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
                    var serviceDetails = new ServiceDetails(catalog, ns, service, grpcServiceConfig, serviceConfig, transports, librarySettings);
                    packageServiceDetails.Add(serviceDetails);

                    var ctx = SourceFileContext.CreateFullyAliased(clock, WellknownNamespaceAliases);
                    var code = ServiceCodeGenerator.Generate(ctx, serviceDetails, seenPaginatedResponseTyps);
                    var filename = $"{clientPathPrefix}{serviceDetails.ClientAbstractTyp.Name}.g.cs";
                    yield return new ResultFile(filename, code);
                    // Generate service-per-file snippets for the service
                    // TODO: Consider removing this once we have integrated the snippet-per-file snippets
                    // with docs generation.
                    var serviceSnippetsCtx = SourceFileContext.CreateUnaliased(
                        clock, WellknownNamespaceAliases, AvoidAliasingNamespaceRegex, forcedAliases, packageTyps);
                    var serviceSnippetsCode = SnippetCodeGenerator.Generate(serviceSnippetsCtx, serviceDetails);
                    var serviceSnippetsFilename = $"{serviceSnippetsPathPrefix}{serviceDetails.ClientAbstractTyp.Name}Snippets.g.cs";
                    yield return new ResultFile(serviceSnippetsFilename, serviceSnippetsCode);
                    // Generate snippet-per-file snippets for the service
                    // TODO: Integrate snippet-per-file snippets with docs generation.
                    foreach (var snippetGenerator in SnippetCodeGenerator.SnippetsGenerators(serviceDetails))
                    {
                        var snippetCtx = SourceFileContext.CreateUnaliased(
                            clock, WellknownNamespaceAliases, AvoidAliasingNamespaceRegex, forcedAliases, packageTyps);
                        var (snippetCode, snippetMetadata) = snippetGenerator.Generate(snippetCtx);
                        snippetMetadata.File = $"{serviceDetails.ClientAbstractTyp.Name}.{snippetGenerator.SnippetMethodName}Snippet.g.cs";
                        var snippetFile = $"{snippetsPathPrefix}{snippetMetadata.File}";
                        snippets.Add(snippetMetadata);
                        yield return new ResultFile(snippetFile, snippetCode);
                    }
                    // Record whether LRO/mixins are used.
                    hasLro |= serviceDetails.Methods.Any(x => x is MethodDetails.Lro);
                    foreach (var mixin in serviceDetails.Mixins)
                    {
                        mixins.Add(mixin.ProtobufServiceDescriptor.FullName);
                        dependencyProtoPackages.Add(mixin.ProtobufServiceDescriptor.File.Package);
                    }
                    hasContent = true;
                }
                var resCtx = SourceFileContext.CreateFullyAliased(clock, WellknownNamespaceAliases);
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

                var lroAdaptationCtx = SourceFileContext.CreateFullyAliased(clock, WellknownNamespaceAliases);
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
                var csprojContent = CsProjGenerator.GenerateClient(dependencyProtoPackages);
                var csprojFilename = $"{clientPathPrefix}{ns}.csproj";
                yield return new ResultFile(csprojFilename, csprojContent);
                // If we only generated resources, we don't need to generate all of these.
                if (packageServiceDetails.Count > 0)
                {
                    allServiceDetails.AddRange(packageServiceDetails);

                    // Generate the package-wide API metadata
                    var ctx = SourceFileContext.CreateFullyAliased(clock, WellknownNamespaceAliases);
                    var packageApiMetadataContent = PackageApiMetadataGenerator.GeneratePackageApiMetadata(ns, ctx, packageFileDescriptors, hasLro, mixins, serviceConfig, requestNumericEnumJsonEncoding);
                    var packageApiMetadataFilename = $"{clientPathPrefix}{PackageApiMetadataGenerator.FileName}";
                    yield return new ResultFile(packageApiMetadataFilename, packageApiMetadataContent);

                    // Generate snippets csproj.
                    var serviceSnippetsCsprojContent = CsProjGenerator.GenerateSnippets(ns);
                    var serviceSnippetsCsProjFilename = $"{serviceSnippetsPathPrefix}{ns}.Snippets.csproj";
                    yield return new ResultFile(serviceSnippetsCsProjFilename, serviceSnippetsCsprojContent);

                    // Generate dependency injection extension methods
                    var dependencyInjectionExtensionsContent = ServiceCollectionExtensionsGenerator.GenerateExtensions(ctx, packageServiceDetails);
                    var dependencyInjectionExtensionsFilename = $"{clientPathPrefix}{ServiceCollectionExtensionsGenerator.FileName}";
                    yield return new ResultFile(dependencyInjectionExtensionsFilename, dependencyInjectionExtensionsContent);

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
                }
            }
        }
    }
}
