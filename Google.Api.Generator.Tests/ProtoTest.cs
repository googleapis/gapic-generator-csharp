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

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Google.Api.Generator.Tests
{
    public class ProtoTest
    {
        private IEnumerable<CodeGenerator.ResultFile> Run(string protoFilename, string package)
        {
            var protoPath = Path.Combine(Invoker.GeneratorTestsDir, protoFilename);
            using (var desc = Invoker.TempFile())
            {
                Invoker.Protoc($"-o {desc} --include_imports --include_source_info " +
                    $"-I{Invoker.CommonProtosDir} -I{Invoker.ProtobufDir} -I{Invoker.GeneratorTestsDir} {protoPath}");
                var descriptorBytes = File.ReadAllBytes(desc.Path);
                return CodeGenerator.Generate(descriptorBytes, package);
            }
        }

        [Fact]
        public void ProtocExecution()
        {
            // Test that protoc executes successfully,
            // and the generator processes the descriptors without crashing!
            Run("ProtoTest.proto", "testing");
        }

        private void ProtoTestSingle(string testProtoName, bool ignoreCsProj = false, bool ignoreSnippets = false, bool ignoreUnitTests = false)
        {
            // Confirm each generated file is idential to the expected output.
            // Use `// TEST_START` and `// TEST_END` lines in the expected file to test subsets of output files.
            // Or include `// TEST_DISABLE` to disable testing of the entire file.
            var files = Run(Path.Combine("ProtoTests", testProtoName, $"{testProtoName}.proto"), $"testing.{testProtoName.ToLowerInvariant()}");
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
                var expectedFilePath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTests", testProtoName, file.RelativePath);
                Assert.True(File.Exists(expectedFilePath), $"Expected file does not exist: '{expectedFilePath}'");
                var expectedLines = File.ReadAllLines(expectedFilePath).Select(x => x.Trim('\r')).ToList();
                if (expectedLines.Any(line => line.Trim() == "// TEST_DISABLE"))
                {
                    continue;
                }
                var actualLines = Encoding.UTF8.GetString(file.Content).Split('\n').Select(x => x.Trim('\r')).ToList();
                var fullFile = !expectedLines.Any(x => x.Trim() == "// TEST_START");
                var expectedBlocks = fullFile ? new[] { expectedLines.Select((s, i) => (i, s)).ToList() } : TestBlocks();
                // Check that all expected code blocks in the expected code exist in the generated (actual) code.
                // The order of the test blocks is not enforced, only the content.
                foreach (var block in expectedBlocks)
                {
                    int blockIndex = 0;
                    (int lineNumber, string line) missing = default;
                    string missingActualLine = null;
                    int missingBestLength = -1;
                    foreach (var (actualLine, actualLineNumber) in actualLines.Select((line, i) => (line, i)))
                    {
                        if (block[blockIndex].line == actualLine && (!fullFile || block[blockIndex].lineNumber == actualLineNumber))
                        {
                            blockIndex += 1;
                            if (blockIndex == block.Count)
                            {
                                missing = default;
                                break;
                            }
                        }
                        else
                        {
                            if (blockIndex > missingBestLength)
                            {
                                missing = block[blockIndex];
                                missingActualLine = actualLine;
                                missingBestLength = blockIndex;
                            }
                            blockIndex = 0;
                        }
                    }
                    if (missing.line != null)
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, actualLines));
                        throw new XunitException($"Failed to find expected line {missing.lineNumber + 1} in '{Path.GetFileName(file.RelativePath)}'\n" +
                            $"  Expected line:  '{missing.line}'\n" +
                            $"  Generated line: '{missingActualLine}'");
                    }
                }

                IEnumerable<IList<(int lineNumber, string line)>> TestBlocks()
                {
                    bool active = false;
                    var block = new List<(int, string)>();
                    foreach (var (line, lineNumber) in expectedLines.Select((s, i) => (s, i)))
                    {
                        if (active)
                        {
                            if (line.Trim() == "// TEST_END")
                            {
                                active = false;
                                yield return block.ToArray();
                                block.Clear();
                            }
                            else
                            {
                                block.Add((lineNumber, line));
                            }
                        }
                        else if (line.Trim() == "// TEST_START")
                        {
                            active = true;
                        }
                    }
                }
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
                    Directory.Delete(Path.Combine(path, "bin"), recursive: true);
                }
                catch
                {
                }
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

        // Build tests are testing `csproj` file generation only.
        // All other generated code is effectively "build tested" when this test project is built.

        [Fact]
        public void BuildBasic() => BuildTest("Basic");

        [Fact]
        public void BuildLro() => BuildTest("Lro", ignoreUnitTests: true);
    }
}
