﻿// Copyright 2019 Google Inc. All Rights Reserved.
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

using Google.Api.Generator.Testing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;

namespace Google.Api.Generator.Tests
{
    internal static class Invoker
    {
        public class WithPath : IDisposable
        {
            public WithPath(Action action, string path) => (_action, Path) = (action, path);
            private readonly Action _action;
            public string Path { get; }
            void IDisposable.Dispose() => _action();
            public override string ToString() => Path;
        }

        static Invoker()
        {
            RootDir = PathUtils.GetRepoRoot();
            GeneratorDir = Path.Combine(RootDir, "Google.Api.Generator");
            GeneratorTestsDir = Path.Combine(RootDir, "Google.Api.Generator.Tests");

            // Fetch OS dependent executable paths and other configs
            (string protocFileName, Runtime, string pluginFileName) = GetOSSpecificConfigs(RootDir);
            ProtocFile = Path.Combine(RootDir, "tools", protocFileName);
            PluginFile = Path.Combine(GeneratorDir, "bin", "Debug", "net8.0", Runtime, "publish", pluginFileName);

            CommonProtosDir = Path.Combine(RootDir, "googleapis");
            ProtobufDir = Path.Combine(RootDir, "tools", "protos");
            var now = DateTime.UtcNow;
            ActualGeneratedFilesDir = Path.Combine(Path.GetTempPath(), $"GeneratorTests-{now:yyyyMMddHHmmssZ}");
        }

        /// <summary>Root path; where the .sln file is.</summary>
        public static string RootDir { get; }

        /// <summary>Generator path; where the generator .csproj file is.</summary>
        public static string GeneratorDir { get; }

        /// <summary>Generator tests path; where the generator tests .csproj file is.</summary>
        public static string GeneratorTestsDir { get; }

        /// <summary>The directory in which to write actual generated files. (This is in a temporary directory.)</summary>
        public static string ActualGeneratedFilesDir { get; }

        /// <summary>Path to protoc executable.</summary>
        public static string ProtocFile { get; }

        /// <summary>The correct dotnet runtime for this platform.</summary>
        public static string Runtime { get; }

        /// <summary>Path of the native executable to be used as the protoc plugin.</summary>
        public static string PluginFile { get; }

        /// <summary>Path of directory containing common protos.</summary>
        public static string CommonProtosDir { get; }

        /// <summary>Path of directory containing protobuf protos.</summary>
        public static string ProtobufDir { get; }

        private static void Execute(string executable, string args, string workingDirectory, TimeSpan timeout, int exitCode)
        {
            var start = new ProcessStartInfo(executable, args)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = workingDirectory,
            };
            var output = new List<string>();
            using (var process = Process.Start(start))
            {
                DataReceivedEventHandler handler = (_, e) => output.Add(e.Data);
                process.ErrorDataReceived += handler;
                process.OutputDataReceived += handler;
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                var exited = process.WaitForExit((int)timeout.TotalMilliseconds);

                // Avoid any extra data being added to our output while we're processing assertions.
                process.ErrorDataReceived -= handler;
                process.OutputDataReceived -= handler;
                if (!exited)
                {
                    process.Kill();
                    Assert.True(exited,
                        $"'{Path.GetFileName(executable)}' did not complete:{Environment.NewLine}{string.Join(Environment.NewLine, output)}");
                }
                Assert.True(process.ExitCode == exitCode,
                    $"'{Path.GetFileName(executable)}' failed:{Environment.NewLine}{string.Join(Environment.NewLine, output)}{Environment.NewLine}" +
                    $"Expected exit code: {exitCode}; was {process.ExitCode}");
            }
        }

        // Generous timeouts, as travis can be slow sometimes, and many invocations may be executing concurrently.

        public static void Protoc(string args) => Execute(ProtocFile, args, null, TimeSpan.FromSeconds(30), 0);

        public static void Dotnet(string args, string workingDirectory = null, int exitCode = 0) =>
            Execute("dotnet", args, workingDirectory ?? GeneratorDir, TimeSpan.FromSeconds(120), exitCode);

        public static WithPath TempFile()
        {
            var filePath = Path.GetTempFileName();
            return new WithPath(() => File.Delete(filePath), filePath);
        }

        public static WithPath TempDir()
        {
            var dirPath = Path.Combine(Path.GetTempPath(), $"GeneratorTest-{Guid.NewGuid()}");
            Directory.CreateDirectory(dirPath);
            return new WithPath(() => Directory.Delete(dirPath, recursive: true), dirPath);
        }

        private static (string protocFile, string runtime, string pluginFileName) GetOSSpecificConfigs(string rootDir) =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? ("protoc", "linux-x64", "Google.Api.Generator")
            : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? ("protoc_macosx_x64", "osx-x64", "Google.Api.Generator")
            : ("protoc.exe", "win-x64", "Google.Api.Generator.exe");
    }
}
