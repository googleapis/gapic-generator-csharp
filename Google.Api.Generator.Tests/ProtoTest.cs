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
using Google.Api.Gax.Testing;
using Google.Api.Generator.Generation;
using Google.Api.Generator.Testing;
using Google.Api.Generator.Utils;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class ProtoTest
    {
        private IEnumerable<ResultFile> Run(IEnumerable<string> protoFilenames, string package,
            string grpcServiceConfigPath, string serviceConfigPath, IEnumerable<string> commonResourcesConfigPaths, ApiTransports transports, bool requestNumericEnumJsonEncoding)
        {
            var clock = new FakeClock(new DateTime(2019, 1, 1));
            var protoPaths = protoFilenames.Select(x => Path.Combine(Invoker.GeneratorTestsDir, x));
            using (var desc = Invoker.TempFile())
            {
                var args = new[]
                {
                    "-o", desc.Path,
                    "--include_imports",
                    "--include_source_info",
                    $"-I{Invoker.CommonProtosDir}",
                    $"-I{Invoker.ProtobufDir}",
                    $"-I{Invoker.GeneratorTestsDir}",
                }.Concat(protoPaths);
                Invoker.Protoc(string.Join(" ", args));

                var descriptorBytes = File.ReadAllBytes(desc.Path);
                FileDescriptorSet descriptorSet = FileDescriptorSet.Parser.ParseFrom(descriptorBytes);
                return CodeGenerator.Generate(descriptorSet, package, clock, grpcServiceConfigPath, serviceConfigPath, commonResourcesConfigPaths, transports, requestNumericEnumJsonEncoding);
            }
        }

        [Fact]
        public void ProtocExecution()
        {
            // Test that protoc executes successfully,
            // and the generator processes the descriptors without crashing!
            Run(new[] { "ProtoTest.proto" }, "testing", null, null, null, ApiTransports.Grpc, requestNumericEnumJsonEncoding: false);
        }

        private void ProtoTestSingle(string testProtoName,
            bool ignoreCsProj = false, bool ignoreSnippets = false,
            string grpcServiceConfigPath = null, string serviceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null,
            ApiTransports transports = ApiTransports.Grpc, bool requestNumericEnumJsonEncoding = false,
            bool ignoreGapicMetadataFile = true, bool ignoreApiMetadataFile = true, bool ignoreServiceExtensionsFile = true) =>
            ProtoTestSingle(
                new[] { testProtoName },
                // The following three don't need to be customized for simple cases
                sourceDir: null,
                outputDir: null,
                package: null,
                ignoreCsProj,
                ignoreSnippets,
                grpcServiceConfigPath,
                serviceConfigPath,
                commonResourcesConfigPaths,
                transports,
                requestNumericEnumJsonEncoding,
                ignoreGapicMetadataFile,
                ignoreApiMetadataFile,
                ignoreServiceExtensionsFile
            );

        private void ProtoTestSingle(IEnumerable<string> testProtoNames, string sourceDir = null, string outputDir = null, string package = null,
            bool ignoreCsProj = false, bool ignoreSnippets = false,
            string grpcServiceConfigPath = null, string serviceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null,
            ApiTransports transports = ApiTransports.Grpc, bool requestNumericEnumJsonEncoding = false,
            bool ignoreGapicMetadataFile = true, bool ignoreApiMetadataFile = true, bool ignoreServiceExtensionsFile = true)
        {
            // Confirm each generated file is identical to the expected output.
            // Use `// TEST_START` and `// TEST_END` lines in the expected file to test subsets of output files.
            // Or include `// TEST_DISABLE` to disable testing of the entire file.
            sourceDir = sourceDir ?? testProtoNames.First();
            outputDir = outputDir ?? sourceDir;
            var protoPaths = testProtoNames.Select(x => Path.Combine("ProtoTests", sourceDir, $"{x}.proto"));
            package = package ?? $"testing.{sourceDir.ToLowerInvariant()}";

            if (serviceConfigPath is string)
            {
                serviceConfigPath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", sourceDir, serviceConfigPath);
            }

            var files = Run(protoPaths, package,
                grpcServiceConfigPath, serviceConfigPath, commonResourcesConfigPaths, transports, requestNumericEnumJsonEncoding);
            // Check output is present.
            Assert.NotEmpty(files);

            // Write all output files to the temporary directory before validating any.
            // This makes it easier to see the complete set of outputs.
            foreach (var file in files)
            {
                var pathToWriteTo = Path.Combine(Invoker.ActualGeneratedFilesDir, outputDir, file.RelativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(pathToWriteTo));
                File.WriteAllText(pathToWriteTo, file.Content);
            }

            // Verify each output file.
            foreach (var file in files)
            {
                if ((ignoreCsProj && file.RelativePath.EndsWith(".csproj")) ||
                    (ignoreSnippets && file.RelativePath.Contains($".Snippets{Path.DirectorySeparatorChar}")) ||
                    (ignoreSnippets && file.RelativePath.Contains($".GeneratedSnippets{Path.DirectorySeparatorChar}")) ||
                    (ignoreGapicMetadataFile && file.RelativePath.EndsWith("gapic_metadata.json")) ||
                    (ignoreApiMetadataFile && file.RelativePath.EndsWith(PackageApiMetadataGenerator.FileName)) ||
                    (ignoreServiceExtensionsFile && file.RelativePath.EndsWith(ServiceCollectionExtensionsGenerator.FileName)))
                {
                    continue;
                }
                var expectedFilePath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", outputDir, file.RelativePath);
                TextComparer.CompareText(expectedFilePath, file);
            }
        }

        private TException ProtoTestSingleFailure<TException>(string testProtoName,
            string grpcServiceConfigPath = null, string serviceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null,
            ApiTransports transports = ApiTransports.Grpc, bool requestNumericEnumJsonEncoding = false)
            where TException : Exception =>
            ProtoTestSingleFailure<TException>(
                new[] { testProtoName },
                grpcServiceConfigPath,
                serviceConfigPath,
                commonResourcesConfigPaths,
                transports,
                requestNumericEnumJsonEncoding
            );

        private TException ProtoTestSingleFailure<TException>(IEnumerable<string> testProtoNames,
            string grpcServiceConfigPath = null, string serviceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null,
            ApiTransports transports = ApiTransports.Grpc, bool requestNumericEnumJsonEncoding = false)
            where TException : Exception
        {
            string sourceDir = testProtoNames.First();
            var protoPaths = testProtoNames.Select(x => Path.Combine("ProtoTests", sourceDir, $"{x}.proto"));
            string package =  $"testing.{sourceDir.ToLowerInvariant()}";

            if (serviceConfigPath is string)
            {
                serviceConfigPath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", sourceDir, serviceConfigPath);
            }
            var exception = Assert.Throws<TException>(() => Run(protoPaths, package,
                grpcServiceConfigPath, serviceConfigPath, commonResourcesConfigPaths, transports, requestNumericEnumJsonEncoding));
            return exception;
        }

        private void BuildTest(string serviceName, string protoPackageVersion = null)
        {
            var (effectiveBasePathPart, effectiveTestName) = protoPackageVersion == null
                ? (serviceName, serviceName)
                : ($"{serviceName}.{protoPackageVersion}", $"{serviceName}.{protoPackageVersion.ToUpperCamelCase()}");

            var baseTestPath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", effectiveBasePathPart);
            var clientPath = Path.Combine(baseTestPath, $"Testing.{effectiveTestName}");
            // Test build client library.
            Build(clientPath);
            // Test build snippets.
            Build(Path.Combine(baseTestPath, $"Testing.{effectiveTestName}.Snippets"));
            Build(Path.Combine(baseTestPath, $"Testing.{effectiveTestName}.GeneratedSnippets"));

            void Build(string path)
            {
                Assert.True(Directory.Exists(path), $"Test directory doesn't exist: '{path}'");
                // TODO: Use Roslyn directly, rather than invoking `dotnet`.
                try
                {
                    Invoker.Dotnet("build", path);
                }
                finally
                {
                    CleanUp(path);
                    // Always clean up the client; this is built when any other project is built.
                    CleanUp(clientPath);
                }
            }

            void CleanUp(string path)
            {
                try
                {
                    Directory.Delete(Path.Combine(path, "obj"), recursive: true);
                }
                catch { }
                try
                {
                    Directory.Delete(Path.Combine(path, "bin"), recursive: true);
                }
                catch { }
            }
        }

        // `0` suffix so it's easier to run this test by itself!
        [Fact]
        public void Basic0() => ProtoTestSingle("Basic.v1", ignoreGapicMetadataFile: false, ignoreApiMetadataFile: false);

        [Fact]
        public void BasicLro() => ProtoTestSingle("BasicLro", ignoreCsProj: true);

        [Fact]
        public void BasicBidiStreaming() => ProtoTestSingle("BasicBidiStreaming", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void BasicClientStreaming() => ProtoTestSingle("BasicClientStreaming", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void BasicServerStreaming() => ProtoTestSingle("BasicServerStreaming", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void BasicPaginated() => ProtoTestSingle("BasicPaginated", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void MethodSignatures() => ProtoTestSingle("MethodSignatures", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void ResourceNames() => ProtoTestSingle("ResourceNames", ignoreCsProj: true);

        [Fact]
        public void Paginated0() => ProtoTestSingle("Paginated", ignoreCsProj: true);

        [Fact]
        public void Lro0() => ProtoTestSingle("Lro");

        [Fact]
        public void ServerStreaming0() => ProtoTestSingle("ServerStreaming", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void Snippets() => ProtoTestSingle("Snippets", ignoreCsProj: true);

        [Fact]
        public void RoutingHeaders() => ProtoTestSingle("RoutingHeaders", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void RoutingHeadersExplicit() => ProtoTestSingle("RoutingHeadersExplicit", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void GrpcServiceConfig() => ProtoTestSingle("GrpcServiceConfig", ignoreCsProj: true, ignoreSnippets: true,
                grpcServiceConfigPath: Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "GrpcServiceConfig", "GrpcServiceConfig.json"));

        [Fact]
        public void CommonResource() => ProtoTestSingle(new[] { "CommonResource", "CommonResourceDef" },
            ignoreCsProj: true, ignoreSnippets: true,
            commonResourcesConfigPaths: new[]
            {
                Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "CommonResource", "CommonResourceConfig1.json"),
                Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "CommonResource", "CommonResourceConfig2.json")
            });

        [Fact]
        public void ChildResource() => ProtoTestSingle("ChildResource", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void UnknownResource() => ProtoTestSingle("UnknownResource", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void ResourceNameSeparator() => ProtoTestSingle("ResourceNameSeparator", ignoreCsProj: true);

        [Fact]
        public void VoidReturn() => ProtoTestSingle("VoidReturn", ignoreCsProj: true);

        // Note: VoidReturn is just picked as a proto example which doesn't need or have any HTTP bindings.
        // It's simpler to reuse an existing one than to create a separate sample just for this.
        // If we want to add HTTP bindings to all test protos later, we can create a separate sample at that point.
        [Fact]
        public void VoidReturn_FailsWithRestTransport() =>
            Assert.Throws<InvalidOperationException>(() => ProtoTestSingle("VoidReturn", transports: ApiTransports.Rest | ApiTransports.Grpc));

        [Fact]
        public void Keywords() => ProtoTestSingle("Keywords", ignoreCsProj: true);

        [Fact]
        public void Deprecated() => ProtoTestSingle("Deprecated", ignoreCsProj: true, ignoreServiceExtensionsFile: false);

        [Fact]
        public void OptionalFields() => ProtoTestSingle("OptionalFields", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void Mixins() => ProtoTestSingle("Mixins", ignoreGapicMetadataFile: false, ignoreSnippets: true, serviceConfigPath: "Mixins.yaml");

        [Fact]
        public void Showcase() => ProtoTestSingle(testProtoNames: new[] { "compliance", "echo", "identity", "messaging", "sequence", "testing" },
            sourceDir: "Showcase/google/showcase/v1beta1",
            outputDir: "Showcase",
            package: "google.showcase.v1beta1",
            serviceConfigPath: "showcase_v1beta1.yaml",
            transports: ApiTransports.Grpc | ApiTransports.Rest,
            requestNumericEnumJsonEncoding: true,
            ignoreSnippets: true,
            ignoreApiMetadataFile: false);

        [Fact]
        public void ShowcaseInFrenchCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            var oldUiCulture = CultureInfo.CurrentUICulture;
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
            CultureInfo.CurrentUICulture = new CultureInfo("fr-FR");
            try
            {
                ProtoTestSingle(testProtoNames: new[] { "compliance", "echo", "identity", "messaging", "sequence", "testing" },
                    sourceDir: "Showcase/google/showcase/v1beta1",
                    outputDir: "Showcase",
                    package: "google.showcase.v1beta1",
                    serviceConfigPath: "showcase_v1beta1.yaml",
                    transports: ApiTransports.Grpc | ApiTransports.Rest,
                    requestNumericEnumJsonEncoding: true,
                    ignoreSnippets: true,
                    ignoreApiMetadataFile: false);
            }
            finally
            {
                CultureInfo.CurrentCulture = oldCulture;
                CultureInfo.CurrentUICulture = oldUiCulture;
            }
        }

        [Fact]
        public void PublishingSettings() => ProtoTestSingle(
            new[] { "PublishingSettings", "CommonResourceDef" },
            ignoreCsProj: true, serviceConfigPath: "ServiceConfig.yaml",
            commonResourcesConfigPaths: new[]
            {
                Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "PublishingSettings", "CommonResourceConfig.json")
            });

        // Build tests are testing `csproj` file generation only.
        // All other generated code is effectively "build tested" when this test project is built.

        [Fact]
        public void BuildBasic() => BuildTest("Basic", protoPackageVersion: "v1");

        [Fact]
        public void BuildLro() => BuildTest("Lro");

        [Fact]
        public void DuplicateResourceDefinitions()
        {
            var exception = ProtoTestSingleFailure<InvalidOperationException>("DuplicateResourceDefinitions");
            Assert.Contains("Multiple definitions", exception.Message);
            Assert.Contains("TestResource", exception.Message);
        }
    }
}
