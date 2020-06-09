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

using System.IO;
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class InvocationTest
    {
        [Fact]
        public void BadCmdLineInvocation()
        {
            // Test that the generator doesn't just hang if executed manually with no cmd-line args.
            Invoker.Dotnet($"run", exitCode: 1);
        }

        [Fact]
        public void CmdLineInvocation()
        {
            var protoFilePath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTest.proto");
            using (Invoker.WithPath desc = Invoker.TempFile(), output = Invoker.TempDir())
            {
                Invoker.Protoc($"-o {desc} --experimental_allow_proto3_optional --include_imports --include_source_info -I{Invoker.GeneratorTestsDir} {protoFilePath}");
                Invoker.Dotnet($"run -- --descriptor={desc} --package=testing --output={output}");
                // Expect at least 6 generated files: Client, tests, and snippets - all with a .cs and a .csproj
                var files = Directory.GetFiles(output.Path, "*", SearchOption.AllDirectories);
                Assert.True(files.Length >= 6, $"{files.Length} generated files present in output directory; must be >= 6");
            }
        }

        [Fact]
        public void ProtocInvocation()
        {
            // Publish generator to the correct platform-dependent target.
            Invoker.Dotnet($"publish -c Debug --self-contained --runtime={Invoker.Runtime}");
            // Execute protoc using the above-published plugin.
            var protoFilePath = Path.Combine(Invoker.GeneratorTestsDir, "ProtoTest.proto");
            using (var output = Invoker.TempDir())
            {
                Invoker.Protoc($"--experimental_allow_proto3_optional --plugin=protoc-gen-test={Invoker.PluginFile} --test_out={output} -I{Invoker.GeneratorTestsDir} {protoFilePath}");
                // Expect at least 6 generated files: Client, tests, and snippets - all with a .cs and a .csproj
                var files = Directory.GetFiles(output.Path, "*", SearchOption.AllDirectories);
                Assert.True(files.Length >= 6, $"{files.Length} generated files present in output directory; must be >= 6");
            }
        }
    }
}
