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

using Google.Api.Gax.Testing;
using Google.Api.Generator.Testing;
using Google.Api.Generator.Utils;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class ProtoTest
    {
        private IEnumerable<ResultFile> Run(IEnumerable<string> protoFilenames, string package,
            string grpcServiceConfigPath, string serviceConfigPath, IEnumerable<string> commonResourcesConfigPaths)
        {
            var clock = new FakeClock(new DateTime(2019, 1, 1));
            var protoPaths = protoFilenames.Select(x => Path.Combine(Invoker.GeneratorTestsDir, x));
            using (var desc = Invoker.TempFile())
            {
                Invoker.Protoc($"-o {desc} --experimental_allow_proto3_optional --include_imports --include_source_info " +
                    $"-I{Invoker.CommonProtosDir} -I{Invoker.ProtobufDir} -I{Invoker.GeneratorTestsDir} {string.Join(" ", protoPaths)}");
                var descriptorBytes = File.ReadAllBytes(desc.Path);
                FileDescriptorSet descriptorSet = FileDescriptorSet.Parser.ParseFrom(descriptorBytes);
                return CodeGenerator.Generate(descriptorSet, package, clock, grpcServiceConfigPath, serviceConfigPath, commonResourcesConfigPaths);
            }
        }

        [Fact]
        public void ProtocExecution()
        {
            // Test that protoc executes successfully,
            // and the generator processes the descriptors without crashing!
            Run(new[] { "ProtoTest.proto" }, "testing", null, null, null);
        }

        private void ProtoTestSingle(string testProtoName,
            bool ignoreCsProj = false, bool ignoreSnippets = false, bool ignoreUnitTests = false,
            string grpcServiceConfigPath = null, string serviceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null, bool ignoreMetadataFile = true) =>
            ProtoTestSingle(
                new[] { testProtoName },
                ignoreCsProj,
                ignoreSnippets,
                ignoreUnitTests,
                grpcServiceConfigPath,
                serviceConfigPath,
                commonResourcesConfigPaths,
                ignoreMetadataFile
            );

        private void ProtoTestSingle(IEnumerable<string> testProtoNames,
            bool ignoreCsProj = false, bool ignoreSnippets = false, bool ignoreUnitTests = false,
            string grpcServiceConfigPath = null, string serviceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null, bool ignoreMetadataFile = true)
        {
            // Confirm each generated file is identical to the expected output.
            // Use `// TEST_START` and `// TEST_END` lines in the expected file to test subsets of output files.
            // Or include `// TEST_DISABLE` to disable testing of the entire file.
            var dirName = testProtoNames.First();
            var protoPaths = testProtoNames.Select(x => Path.Combine("ProtoTests", dirName, $"{x}.proto"));
            var package = $"testing.{dirName.ToLowerInvariant()}";

            if (testProtoNames.SingleOrDefault() == "Showcase")
            {
                protoPaths = new[] {"compliance.proto", "echo.proto", "identity.proto", "messaging.proto", "sequence.proto", "testing.proto"}
                    .Select(f => Path.Combine("ProtoTests", "Showcase", "google", "showcase", "v1beta1", $"{f}"));
                package = "google.showcase.v1beta1";
            }

            var files = Run(protoPaths, package,
                grpcServiceConfigPath, serviceConfigPath, commonResourcesConfigPaths);
            // Check output is present.
            Assert.NotEmpty(files);
   	    // Write all output files to the temporary directory before validating any.
            // This makes it easier to see the complete set of outputs.
            foreach (var file in files)
            {
                var pathToWriteTo = Path.Combine(Invoker.ActualGeneratedFilesDir, dirName, file.RelativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(pathToWriteTo));
                File.WriteAllText(pathToWriteTo, file.Content);
            }
            // Verify each output file.
            foreach (var file in files)
            {
                if ((ignoreCsProj && file.RelativePath.EndsWith(".csproj")) ||
                    (ignoreSnippets && file.RelativePath.Contains($".Snippets{Path.DirectorySeparatorChar}")) ||
                    (ignoreSnippets && file.RelativePath.Contains($".GeneratedSnippets{Path.DirectorySeparatorChar}")) ||
                    (ignoreUnitTests && file.RelativePath.Contains($".Tests{Path.DirectorySeparatorChar}")) ||
                    (ignoreMetadataFile && file.RelativePath.EndsWith("gapic_metadata.json")))
                {
                    continue;
                }
                var expectedFilePath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", dirName, file.RelativePath);
                if (expectedFilePath.Contains("BasicClientStreamingClient.g.cs", StringComparison.InvariantCultureIgnoreCase))
                    File.WriteAllText(@"C:\temp\BasicClientStreamingClient.g.cs", file.Content);

                TextComparer.CompareText(expectedFilePath, file);
            }
        }

        private void BuildTest(string serviceName, string protoPackageVersion = null, bool ignoreUnitTests = false)
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
            if (!ignoreUnitTests)
            {
                // Test build unit-tests.
                Build(Path.Combine(baseTestPath, $"Testing.{effectiveTestName}.Tests"));
            }

            void Build(string path)
            {
                Assert.True(Directory.Exists(path), $"Test directory doesn't exist: '{path}'");
                // TODO: Use Roslyn directly, rather than invoking `dotnet`.
                var errors = new List<string>();
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
        public void Basic0() => ProtoTestSingle("Basic.v1", ignoreMetadataFile: false);

        [Fact]
        public void BasicLro() => ProtoTestSingle("BasicLro", ignoreCsProj: true, ignoreUnitTests: true);

        [Fact]
        public void BasicBidiStreaming() => ProtoTestSingle("BasicBidiStreaming", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void BasicServerStreaming() => ProtoTestSingle("BasicServerStreaming", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void BasicClientStreaming() => ProtoTestSingle("BasicClientStreaming", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);
        
        [Fact]
        public void BasicPaginated() => ProtoTestSingle("BasicPaginated", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void MethodSignatures() => ProtoTestSingle("MethodSignatures", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void ResourceNames() => ProtoTestSingle("ResourceNames", ignoreCsProj: true);

        [Fact]
        public void Paginated0() => ProtoTestSingle("Paginated", ignoreCsProj: true, ignoreUnitTests: true);

        [Fact]
        public void Lro0() => ProtoTestSingle("Lro", ignoreUnitTests: true);

        [Fact]
        public void ServerStreaming0() => ProtoTestSingle("ServerStreaming", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void Snippets() => ProtoTestSingle("Snippets", ignoreCsProj: true, ignoreUnitTests: true);

        [Fact]
        public void RoutingHeaders() => ProtoTestSingle("RoutingHeaders", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void UnitTests() => ProtoTestSingle("UnitTests", ignoreCsProj: true, ignoreSnippets: true);

        [Fact]
        public void GrpcServiceConfig() => ProtoTestSingle("GrpcServiceConfig", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true,
                grpcServiceConfigPath: Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "GrpcServiceConfig", "GrpcServiceConfig.json"));

        [Fact]
        public void CommonResource() => ProtoTestSingle(new[] { "CommonResource", "CommonResourceDef" },
            ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true,
            commonResourcesConfigPaths: new[]
            {
                Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "CommonResource", "CommonResourceConfig1.json"),
                Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "CommonResource", "CommonResourceConfig2.json")
            });

        [Fact]
        public void ChildResource() => ProtoTestSingle("ChildResource", ignoreCsProj: true, ignoreUnitTests: true, ignoreSnippets: true);

        [Fact]
        public void UnknownResource() => ProtoTestSingle("UnknownResource", ignoreCsProj: true, ignoreUnitTests: true, ignoreSnippets: true);

        [Fact]
        public void ResourceNameSeparator() => ProtoTestSingle("ResourceNameSeparator", ignoreCsProj: true);

        [Fact]
        public void VoidReturn() => ProtoTestSingle("VoidReturn", ignoreCsProj: true);

        [Fact]
        public void Keywords() => ProtoTestSingle("Keywords", ignoreCsProj: true);

        [Fact]
        public void Deprecated() => ProtoTestSingle("Deprecated", ignoreCsProj: true);

        [Fact]
        public void OptionalFields() => ProtoTestSingle("OptionalFields", ignoreCsProj: true, ignoreUnitTests: true, ignoreSnippets: true);
        
        [Fact]
        public void Showcase() => ProtoTestSingle("Showcase", ignoreCsProj: true, ignoreUnitTests: true, ignoreSnippets: true);
        [Fact]
        public void Mixins() => ProtoTestSingle("Mixins", ignoreMetadataFile: false, ignoreSnippets: true,
            serviceConfigPath: Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", "Mixins", "Mixins.yaml"));

        // Build tests are testing `csproj` file generation only.
        // All other generated code is effectively "build tested" when this test project is built.

        [Fact]
        public void BuildBasic() => BuildTest("Basic", protoPackageVersion: "v1");

        [Fact]
        public void BuildLro() => BuildTest("Lro", ignoreUnitTests: true);
    }
}
