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
            var descOutputPath = Path.GetTempFileName();
            try
            {
                var protocArgs = $"-o {descOutputPath} --include_imports --include_source_info -I. -I{commonProtosPath} {protoFilename}";
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
        public void TestProtocExecution()
        {
            // Test that protoc executes successfully,
            // and the generator processes the descriptors without crashing!
            // TODO: Remove this test.
            Run("ProtoTest.proto", "testing");
        }

        [Fact]
        public void TestThatSomeCodeIsGenerated()
        {
            // Test that the code generator executes, and produces the expected code.
            // TODO: Improve this testing infrastructure.
            var files = Run("ProtoTest.proto", "testing");
            var clientCs = files.FirstOrDefault(x => x.RelativePath == "TestClient.cs");
            Assert.NotNull(clientCs);
            var clientCsContent = Encoding.UTF8.GetString(clientCs.Content);
            // TODO: Create helper methods for much of this Roslyn testing.
            // Parse the C# source.
            var root = CSharpSyntaxTree.ParseText(clientCsContent).GetCompilationUnitRoot();
            Assert.NotNull(root);
            // Check there is at least one `using` directive.
            Assert.NotEmpty(root.Usings);
            // Check there is only one `namespace` statement.
            Assert.Single(root.Members);
            var ns = root.Members[0] as NamespaceDeclarationSyntax;
            Assert.NotNull(ns);
            // Check there is one settings class.
            Assert.NotEmpty(ns.Members);
            var settingsClasses = ns.Members.OfType<ClassDeclarationSyntax>().Where(x => x.Identifier.Text == "TestSettings").ToList();
            Assert.Single(settingsClasses);
            var settingsClass = settingsClasses[0];
            // Check the static method `GetDefault()` exists.
            var getDefaultMethods = settingsClass.Members.OfType<MethodDeclarationSyntax>()
                .Where(x => x.Identifier.Text == "GetDefault" && !x.ParameterList.Parameters.Any()).ToList();
            Assert.Single(getDefaultMethods);
            var getDefaultMethod = getDefaultMethods[0];
            // Check that the GetDefault() method body is as expected.
            Assert.Equal("=> new TestSettings()", getDefaultMethod.ExpressionBody.ToFullString());
            // Check that the parameterless ctor has an empty body.
            var defaultCtor = settingsClass.Members.OfType<ConstructorDeclarationSyntax>().Single(x => !x.ParameterList.Parameters.Any());
            Assert.Empty(defaultCtor.Body.Statements);
            // check that the copy ctor is as it should be.
            var copyCtor = settingsClass.Members.OfType<ConstructorDeclarationSyntax>().Single(x => x.ParameterList.Parameters.Count == 1);
            Assert.Equal(3, copyCtor.Body.Statements.Count);
            Assert.Equal("gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));",
                copyCtor.Body.Statements[0].WithoutTrivia().ToFullString());
            Assert.Equal("Method1Settings = existing.Method1Settings;",
                copyCtor.Body.Statements[1].WithoutTrivia().ToFullString());
            Assert.Equal("OnCopy(existing);",
                copyCtor.Body.Statements[2].WithoutTrivia().ToFullString());
        }
    }
}
