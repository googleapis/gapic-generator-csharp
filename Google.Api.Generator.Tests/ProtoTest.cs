using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;
using Xunit.Sdk;

namespace Google.Api.Generator.Tests
{
    // This is an initial proto-based test to ensure this works locally and on CI.
    // TODO: Move this proto-base functionality into a helper method/class, and probably remove this test.
    public class ProtoTest
    {
        [Fact]
        public void TestProtocExecution()
        {
            // Test that protoc executes successfully, and the generator works correctly on the resulting proto descriptor
            var rootPath = Environment.CurrentDirectory;
            while (!rootPath.EndsWith("Google.Api.Generator.Tests"))
            {
                rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            }
            rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var protocPath = Path.GetFullPath(Path.Combine(rootPath, "tools", isWindows ? "protoc.exe" : "protoc"));
            var commonProtosPath = Path.GetFullPath(Path.Combine(rootPath, "api-common-protos"));
            var descOutputPath = Path.GetTempFileName();
            try
            {
                var protocArgs = $"-o {descOutputPath} --include_imports --include_source_info -I. -I{commonProtosPath} ProtoTest.proto";
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
                var descBytes = File.ReadAllBytes(descOutputPath);
                var files = Generator.Generate(descBytes, "testing");
                Assert.Empty(files);
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
    }
}
