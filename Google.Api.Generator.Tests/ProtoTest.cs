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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class ProtoTest
    {
        private IEnumerable<ResultFile> Run(IEnumerable<string> protoFilenames, string package,
            string grpcServiceConfigPath, IEnumerable<string> commonResourcesConfigPaths)
        {
            var clock = new FakeClock(new DateTime(2019, 1, 1));
            var protoPaths = protoFilenames.Select(x => Path.Combine(Invoker.GeneratorTestsDir, x));
            using (var desc = Invoker.TempFile())
            {
                Invoker.Protoc($"-o {desc} --experimental_allow_proto3_optional --include_imports --include_source_info " +
                    $"-I{Invoker.CommonProtosDir} -I{Invoker.ProtobufDir} -I{Invoker.GeneratorTestsDir} {string.Join(" ", protoPaths)}");
                var descriptorBytes = File.ReadAllBytes(desc.Path);
                return CodeGenerator.Generate(descriptorBytes, package, clock, grpcServiceConfigPath, commonResourcesConfigPaths);
            }
        }

        [Fact]
        public void ProtocExecution()
        {
            // Test that protoc executes successfully,
            // and the generator processes the descriptors without crashing!
            Run(new[] { "ProtoTest.proto" }, "testing", null, null);
        }

        private void ProtoTestSingle(string testProtoName, bool ignoreCsProj = false, bool ignoreSnippets = false, bool ignoreUnitTests = false,
            string grpcServiceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null) =>
            ProtoTestSingle(new[] { testProtoName }, ignoreCsProj, ignoreSnippets, ignoreUnitTests, grpcServiceConfigPath, commonResourcesConfigPaths);

        private void ProtoTestSingle(IEnumerable<string> testProtoNames, bool ignoreCsProj = false, bool ignoreSnippets = false, bool ignoreUnitTests = false,
            string grpcServiceConfigPath = null, IEnumerable<string> commonResourcesConfigPaths = null)
        {
            // Confirm each generated file is idential to the expected output.
            // Use `// TEST_START` and `// TEST_END` lines in the expected file to test subsets of output files.
            // Or include `// TEST_DISABLE` to disable testing of the entire file.
            var dirName = testProtoNames.First();
            var protoPaths = testProtoNames.Select(x => Path.Combine("ProtoTests", dirName, $"{x}.proto"));
            var files = Run(protoPaths, $"testing.{dirName.ToLowerInvariant()}",
                grpcServiceConfigPath, commonResourcesConfigPaths);
            // Check output is present.
            Assert.NotEmpty(files);
            // Verify each output file.
            foreach (var file in files)
            {
                if ((ignoreCsProj && file.RelativePath.EndsWith(".csproj")) ||
                    (ignoreSnippets && file.RelativePath.Contains($".Snippets{Path.DirectorySeparatorChar}")) ||
                    (ignoreUnitTests && file.RelativePath.Contains($".Tests{Path.DirectorySeparatorChar}")))
                {
                    continue;
                }
                var expectedFilePath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", dirName, file.RelativePath);

                TextComparer.CompareText(expectedFilePath, file);
            }
        }

        private void BuildTest(string testName, bool ignoreUnitTests = false)
        {
            var baseTestPath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", testName);
            var clientPath = Path.Combine(baseTestPath, $"Testing.{testName}");
            // Test build client library.
            Build(clientPath);
            // Test build snippets.
            Build(Path.Combine(baseTestPath, $"Testing.{testName}.Snippets"));
            if (!ignoreUnitTests)
            {
                // Test build unit-tests.
                Build(Path.Combine(baseTestPath, $"Testing.{testName}.Tests"));
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
        public void Basic0() => ProtoTestSingle("Basic");

        [Fact]
        public void BasicLro() => ProtoTestSingle("BasicLro", ignoreCsProj: true, ignoreUnitTests: true);

        [Fact]
        public void BasicBidiStreaming() => ProtoTestSingle("BasicBidiStreaming", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void BasicServerStreaming() => ProtoTestSingle("BasicServerStreaming", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void BasicPaginated() => ProtoTestSingle("BasicPaginated", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void MethodSignatures() => ProtoTestSingle("MethodSignatures", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

        [Fact]
        public void ResourceNames() => ProtoTestSingle("ResourceNames", ignoreCsProj: true, ignoreSnippets: true, ignoreUnitTests: true);

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

        // Build tests are testing `csproj` file generation only.
        // All other generated code is effectively "build tested" when this test project is built.

        [Fact]
        public void BuildBasic() => BuildTest("Basic");

        [Fact]
        public void BuildLro() => BuildTest("Lro", ignoreUnitTests: true);
    }
}
