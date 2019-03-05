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

using Google.Api.Generator.Formatting;
using Google.Api.Generator.Generation;
using Google.Api.Generator.ProtoUtils;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Google.Api.Generator
{
    internal static class CodeGenerator
    {
        public class ResultFile
        {
            public ResultFile(string relativePath, byte[] content) => (RelativePath, Content) = (relativePath, content);
            public string RelativePath { get; }
            public byte[] Content { get; }
        }

        public static IEnumerable<ResultFile> Generate(byte[] descriptorBytes, string package)
        {
            var descriptors = GetFileDescriptors(descriptorBytes);
            var filesToGenerate = descriptors.Where(x => x.Package == package).Select(x => x.Name).ToList();
            return Generate(descriptors, filesToGenerate);
        }

        public static IEnumerable<ResultFile> Generate(IReadOnlyList<FileDescriptor> descriptors, IEnumerable<string> filesToGenerate)
        {
            // TODO: Support multiple packages.
            var packages = descriptors.Where(x => filesToGenerate.Contains(x.Name)).Select(x => x.Package).Distinct().ToList();
            if (packages.Count == 0)
            {
                throw new InvalidOperationException("No packages specified to build.");
            }
            if (packages.Count > 1)
            {
                throw new InvalidOperationException($"More than one package specified to build: {string.Join(", ", packages)}");
            }
            var package = packages[0];
            var catalog = new ProtoCatalog(package, descriptors);
            var packageFileDescs = descriptors.Where(x => x.Package == package).ToList();
            foreach (var fileDesc in packageFileDescs)
            {
                var ns = fileDesc.CSharpNamespace();
                var clientPathPrefix = $"{ns}{Path.DirectorySeparatorChar}";
                var snippetsPathPrefix = $"{ns}.Snippets{Path.DirectorySeparatorChar}";
                var unitTestsPathPrefix = $"{ns}.Tests{Path.DirectorySeparatorChar}";
                bool hasLro = false;
                foreach (var service in fileDesc.Services)
                {
                    // Generate settings and client code for requested package.
                    var serviceDetails = new ServiceDetails(catalog, ns, service);
                    var ctx = SourceFileContext.Create(SourceFileContext.ImportStyle.FullyAliased);
                    var code = ServiceCodeGenerator.Generate(ctx, serviceDetails);
                    var formattedCode = CodeFormatter.Format(code);
                    var filename = $"{clientPathPrefix}{serviceDetails.ClientAbstractTyp.Name}.cs";
                    var content = Encoding.UTF8.GetBytes(formattedCode.ToFullString());
                    yield return new ResultFile(filename, content);
                    // Generate snippets for the service
                    var snippetCtx = SourceFileContext.Create(SourceFileContext.ImportStyle.Unaliased);
                    var snippetCode = SnippetCodeGenerator.Generate(snippetCtx, serviceDetails);
                    var snippetFormattedCode = CodeFormatter.Format(snippetCode);
                    var snippetFilename = $"{snippetsPathPrefix}{serviceDetails.ClientAbstractTyp.Name}Snippets.g.cs";
                    var snippetContent = Encoding.UTF8.GetBytes(snippetFormattedCode.ToFullString());
                    yield return new ResultFile(snippetFilename, snippetContent);
                    // Generate unit tests for the the service.
                    var unitTestCtx = SourceFileContext.Create(SourceFileContext.ImportStyle.FullyAliased);
                    var unitTestCode = UnitTestCodeGeneration.Generate(unitTestCtx, serviceDetails);
                    var unitTestFormattedCode = CodeFormatter.Format(unitTestCode);
                    var unitTestFilename = $"{unitTestsPathPrefix}{serviceDetails.ClientAbstractTyp.Name}Test.g.cs";
                    var unitTestContent = Encoding.UTF8.GetBytes(unitTestFormattedCode.ToFullString());
                    yield return new ResultFile(unitTestFilename, unitTestContent);
                    // Record whether LRO is used.
                    hasLro |= serviceDetails.Methods.Any(x => x is MethodDetails.Lro);
                }
                // Generate resource-names for this proto file, if there are any.
                if (catalog.GetResourceDefsByFile(fileDesc).Any())
                {
                    var resCtx = SourceFileContext.Create(SourceFileContext.ImportStyle.FullyAliased);
                    var resCode = ResourceNamesGenerator.Generate(catalog, resCtx, fileDesc);
                    var formattedResCode = CodeFormatter.Format(resCode);
                    var resFilename = $"{clientPathPrefix}{Path.GetFileNameWithoutExtension(fileDesc.Name)}ResourceNames.cs";
                    var resContent = Encoding.UTF8.GetBytes(formattedResCode.ToFullString());
                    yield return new ResultFile(resFilename, resContent);
                }
                // Generate client csproj.
                var csprojContent = Encoding.UTF8.GetBytes(CsProjGenerator.GenerateClient(hasLro));
                var csprojFilename = $"{clientPathPrefix}{ns}.csproj";
                yield return new ResultFile(csprojFilename, csprojContent);
                // Generate snippets csproj.
                var snippetsCsprojContent = Encoding.UTF8.GetBytes(CsProjGenerator.GenerateSnippets(ns));
                var snippetsCsProjFilename = $"{snippetsPathPrefix}{ns}.Snippets.csproj";
                yield return new ResultFile(snippetsCsProjFilename, snippetsCsprojContent);
                // Generate unit-tests csproj.
                var unitTestsCsprojContent = Encoding.UTF8.GetBytes(CsProjGenerator.GenerateUnitTests(ns));
                var unitTestsCsprojFilename = $"{unitTestsPathPrefix}{ns}.Tests.csproj";
                yield return new ResultFile(unitTestsCsprojFilename, unitTestsCsprojContent);
            }
        }

        private static IReadOnlyList<FileDescriptor> GetFileDescriptors(byte[] bytes)
        {
            // TODO: Remove this when equivalent is in Protobuf.
            // Manually read repeated field of `FileDescriptorProto` messages.
            int i = 0;
            var bss = new List<ByteString>();
            while (i < bytes.Length)
            {
                if (bytes[i] != 0xa)
                {
                    throw new InvalidOperationException($"Expected 0xa at offset {i}");
                }
                i += 1;
                int len = 0;
                int shift = 0;
                while (true)
                {
                    var b = bytes[i];
                    i += 1;
                    len |= (b & 0x7f) << shift;
                    shift += 7;
                    if ((b & 0x80) == 0)
                    {
                        break;
                    }
                }
                bss.Add(ByteString.CopyFrom(bytes, i, len));
                i += len;
            }
            return FileDescriptor.BuildFromByteStrings(bss);
        }
    }
}
