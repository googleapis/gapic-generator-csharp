// Copyright 2019 Google Inc. All Rights Reserved.
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class ProtocTest
    {
        [Fact]
        public void ProtocInvocation()
        {
            var rootPath = Environment.CurrentDirectory;
            while (!rootPath.EndsWith("Google.Api.Generator.Tests"))
            {
                rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            }
            rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            var generatorPath = Path.Combine(rootPath, "Google.Api.Generator");
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            // Publish generator to the correct platform-dependent target.
            var runtime = isWindows ? "win-x64" : "linux-x64";
            using (var publishProcess = Process.Start(new ProcessStartInfo("dotnet", $"publish -c Debug --self-contained --runtime={runtime}")
            {
                WorkingDirectory = generatorPath,
            }))
            {
                publishProcess.WaitForExit(120_000);
                Assert.True(publishProcess.ExitCode == 0, "dotnet publish failed.");
            }
            // Execute protoc using the above-published plugin.
            var outputPath = Path.Combine(Path.GetTempPath(), $"ProtocTest-{Guid.NewGuid()}");
            var protocPath = Path.Combine(rootPath, "tools", isWindows ? "protoc.exe" : "protoc");
            var pluginDir = Path.Combine(generatorPath, "bin", "Debug", "netcoreapp2.2", runtime, "publish");
            var pluginPath = Path.Combine(pluginDir, isWindows ? "Google.Api.Generator.exe" : "Google.Api.Generator");
            var protoFileDir = Path.Combine(rootPath, "Google.Api.Generator.Tests");
            var protoFilePath = Path.Combine(protoFileDir, "ProtoTest.proto");
            var protocArgs = $"--plugin=protoc-gen-test={pluginPath} --test_out={outputPath} -I{protoFileDir} {protoFilePath}";
            try
            {
                Directory.CreateDirectory(outputPath);
                var protocErrors = new List<string>();
                using (var protocProcess = Process.Start(new ProcessStartInfo(protocPath, protocArgs)
                {
                    RedirectStandardError = true
                }))
                {
                    protocProcess.ErrorDataReceived += (sender, e) => protocErrors.Add(e.Data);
                    protocProcess.BeginErrorReadLine();
                    protocProcess.WaitForExit(30_000);
                    Assert.True(protocProcess.ExitCode == 0, $"protoc failed:\n{string.Join("\n", protocErrors)}");
                }
                // Expect at least 6 generated files: Client, tests, and snippets - all with a .cs and a .csproj
                var files = Directory.GetFiles(outputPath, "*", SearchOption.AllDirectories);
                Assert.True(files.Length >= 6, $"{files.Length} generated files present in output directory; must be >= 6");
            }
            finally
            {
                try
                {
                    Directory.Delete(outputPath, recursive: true);
                }
                catch { }
            }
        }
    }
}
