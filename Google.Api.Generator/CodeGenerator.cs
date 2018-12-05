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
using System.Linq;
using System.Text;

namespace Google.Api.Generator
{
    internal static class CodeGenerator
    {
        public class ResultFile
        {
            public ResultFile(string relativePath, byte[] content) =>
                (RelativePath, Content) = (relativePath, content);
            public string RelativePath { get; }
            public byte[] Content { get; }
        }

        public static IEnumerable<ResultFile> Generate(byte[] descriptorBytes, string package)
        {
            var descriptors = GetFileDescriptors(descriptorBytes);
            var catalog = new ProtoCatalog(package, descriptors);
            // Generate settings and client code for requested package
            foreach (var desc in descriptors.Where(x => x.Package == package))
            {
                var ns = desc.CSharpNamespace();
                foreach (var service in desc.Services)
                {
                    var serviceDetails = new ServiceDetails(catalog, ns, service);
                    var ctx = new SourceFileContext(SourceFileContext.ImportStyle.FullyAliased);
                    var code = ServiceCodeGenerator.Generate(ctx, serviceDetails);
                    var formattedCode = CodeFormatter.Format(code);
                    // TODO: Place the generated code in the correct directory.
                    var filename = $"{serviceDetails.ClientAbstractTyp.Name}.cs";
                    var content = Encoding.UTF8.GetBytes(formattedCode.ToFullString());
                    // May not use `yield return` later, but it's fine for now.
                    yield return new ResultFile(filename, content);
                }
            }
            // TODO: Generate resource names, csproj, tests, smoketests, integration tests, snippets, etc...
        }

        private static IReadOnlyList<FileDescriptor> GetFileDescriptors(byte[] bytes)
        {
            // TODO: Remove this when equivalent is in Protobuf.
            // Manually read repeated field of FileDescriptors.
            int i = 0;
            var bss = new List<ByteString>();
            while (i < bytes.Length)
            {
                if (bytes[i] != 0xa)
                {
                    throw new InvalidOperationException("Expected 0xa");
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
                i += (int)len;
            }
            return FileDescriptor.BuildFromByteStrings(bss);
        }
    }
}
