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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Google.Api.Generator.Tests
{
    // This is an initial proto-based test to ensure this works locally and on CI.
    // TODO: Move this proto-base functionality into a helper method/class, and probably remove this test.
    public class ProtoTest
    {
        private IEnumerable<CodeGenerator.ResultFile> Run(string protoFilename, string package)
        {
            var rootPath = Environment.CurrentDirectory;
            while (!rootPath.EndsWith("Google.Api.Generator.Tests"))
            {
                rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            }
            rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var protocPath = Path.GetFullPath(Path.Combine(rootPath, "tools", isWindows ? "protoc.exe" : "protoc"));
            var commonProtosPath = Path.GetFullPath(Path.Combine(rootPath, "api-common-protos"));
            var protobufPath = Path.GetFullPath(Path.Combine(rootPath, "protobuf", "src"));
            var descOutputPath = Path.GetTempFileName();
            try
            {
                var protocArgs = $"-o {descOutputPath} --include_imports --include_source_info -I. -I{commonProtosPath} -I{protobufPath} {protoFilename}";
                var processStart = new ProcessStartInfo(protocPath, protocArgs)
                {
                    RedirectStandardError = true
                };
                var protocErrors = new List<string>();
                using (var protoProcess = Process.Start(processStart))
                {
                    protoProcess.ErrorDataReceived += (sender, e) => protocErrors.Add(e.Data);
                    protoProcess.BeginErrorReadLine();
                    protoProcess.WaitForExit(10_000);
                    if (protoProcess.ExitCode != 0)
                    {
                        throw new XunitException($"protoc failed:\n{string.Join('\n', protocErrors)}");
                    }
                }
                var descriptorBytes = File.ReadAllBytes(descOutputPath);
                return CodeGenerator.Generate(descriptorBytes, package);
            }
            catch (Exception e)
            {
                throw new XunitException($"Executing `protoc` failed: {e.Message}");
            }
            finally
            {
                File.Delete(descOutputPath);
            }
        }

        [Fact]
        public void ProtocExecution()
        {
            // Test that protoc executes successfully,
            // and the generator processes the descriptors without crashing!
            // TODO: Remove this test.
            Run("ProtoTest.proto", "testing");
        }

        private void ProtoTestSingle(string testProtoName)
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
                var expectedFilePath = Path.Combine("ProtoTests", testProtoName, file.RelativePath);
                Assert.True(File.Exists(expectedFilePath), $"Expected file does not exist: '{expectedFilePath}'");
                var expectedLines = File.ReadAllLines(expectedFilePath).Select(x => x.Trim('\r')).ToList();
                if (expectedLines.Any(line => line.Trim() == "// TEST_DISABLE"))
                {
                    continue;
                }
                var actualLines = Encoding.UTF8.GetString(file.Content).Split('\n').Select(x => x.Trim('\r')).ToList();
                var expectedBlocks = expectedLines.Any(x => x.Trim() == "// TEST_START") ? TestBlocks() : new[] { expectedLines.Select((s, i) => (i, s)).ToList() };
                // Check that all expected code blocks in the expected code exist in the generated (actual) code.
                // The order of the test blocks is not enforced, only the content.
                foreach (var block in expectedBlocks)
                {
                    int blockIndex = 0;
                    (int lineNumber, string line) missing = default;
                    string missingActualLine = null;
                    int missingBestLength = -1;
                    foreach (var actualLine in actualLines)
                    {
                        if (block[blockIndex].line == actualLine)
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
                            $"  Expected line: '{missing.line}'\n" +
                            $"  Actual line:   '{missingActualLine}'");
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

        // TODO: Consider using a single Theory for these.
        // It's currently convenient having them separate, so they can easily be run individually.

        // `0` suffix so it's easier to run this test by itself!
        [Fact]
        public void Basic0() => ProtoTestSingle("Basic");

        [Fact]
        public void BasicLro() => ProtoTestSingle("BasicLro");

        [Fact]
        public void BasicBidiStreaming() => ProtoTestSingle("BasicBidiStreaming");

        [Fact]
        public void BasicServerStreaming() => ProtoTestSingle("BasicServerStreaming");

        [Fact]
        public void BasicPaginated() => ProtoTestSingle("BasicPaginated");

        [Fact]
        public void MethodSignatures() => ProtoTestSingle("MethodSignatures");

        [Fact]
        public void ResourceNames() => ProtoTestSingle("ResourceNames");

        [Fact]
        public void Paginated0() => ProtoTestSingle("Paginated");
    }
}
