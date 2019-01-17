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
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            // TODO: Allow subsets of files to be verified, this will allow tests for specific generator features
            // without requiring a (possibly large) expected output file to be entirely written.
            var files = Run(Path.Combine("ProtoTests", $"{testProtoName}.proto"), "testing");
            foreach (var file in files)
            {
                var expectedFilePath = Path.Combine("ProtoTests", file.RelativePath);
                Assert.True(File.Exists(expectedFilePath), $"Expected file does not exist: '{expectedFilePath}'");
                var expectedLines = File.ReadAllLines(expectedFilePath).Select(x => x.Trim('\r')).ToList();
                var actualLines = Encoding.UTF8.GetString(file.Content).Split('\n').Select(x => x.Trim('\r')).ToList();
                // Check that all the testable lines with in the expected file match.
                int expectedIndex = 0;
                int actualIndex = 0;
                bool active = !expectedLines.Any(x => x.Trim() == "// TEST_START");
                while (expectedIndex < expectedLines.Count && actualIndex < actualLines.Count)
                {
                    active &= expectedLines[expectedIndex].Trim() != "// TEST_END";
                    if (active)
                    {
                        expectedIndex += actualLines[actualIndex] == expectedLines[expectedIndex] ? 1 : 0;
                        actualIndex += 1;
                    }
                    else
                    {
                        active |= expectedLines[expectedIndex].Trim() == "// TEST_START";
                        expectedIndex += 1;
                    }
                }
                if (expectedIndex != expectedLines.Count)
                {
                    foreach (var actualLine in actualLines)
                    {
                        Console.WriteLine(actualLine);
                    }
                    Assert.True(false, $"Failed to find expected line {expectedIndex + 1}: '{expectedLines[expectedIndex]}'");
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
    }
}
