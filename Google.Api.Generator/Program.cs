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

using CommandLine;
using CommandLine.Text;
using Google.Protobuf;
using Google.Protobuf.Compiler;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Google.Api.Generator
{
    public static class Program
    {
        public class Options
        {
            [Option("descriptor", Required = true, HelpText = "The path on disk to a file containing a serialized `FileDescriptorSet`.")]
            public string Descriptor { get; private set; }

            [Option("package", Required = true, HelpText = "The proto package designated the files actually intended for output.")]
            public string Package { get; private set; }

            [Option("output", Required = true, HelpText = " The output directory.")]
            public string Output { get; private set; }

            [Usage]
            public static IEnumerable<Example> Examples => new[]
            {
                new Example("Generate to stdout from a serialized `CodeGeneratorRequest` on stdin",
                    new Options { }),
                new Example("Generate from a file containing a serialized `FileDescriptorSet`",
                    new Options
                    {
                        Descriptor = Path.Combine("path", "to", "serialized", "FileDescriptorSet"),
                        Package = "your.service.proto_package",
                        Output = Path.Combine("path", "to", "output", "directory"),
                    }),
            };
        }

        public static int Main(string[] args)
        {
            if (!args.Any())
            {
                // Invoked from protoc, process `CodeGeneratorRequest` from stdin.
                // Output `CodeGeneratorResponse` to stdout.
                using (Stream stdin = Console.OpenStandardInput(), stdout = Console.OpenStandardOutput())
                {
                    GenerateFromProtoc(stdin, stdout);
                }
                return 0;
            }
            // Invoked manually, use options.
            var parsed = Parser.Default.ParseArguments<Options>(args);
            switch (parsed)
            {
                case Parsed<Options> success:
                    // All options present, try to generate.
                    GenerateFromArgs(success.Value);
                    return 0;
                case NotParsed<Options> failure:
                    // Errors will have already been shown.
                    return 1;
                default:
                    Console.WriteLine("Error: Unexpected command-line parse result.");
                    return 2;
            }
        }

        private static void GenerateFromProtoc(Stream stdin, Stream stdout)
        {
            var codeGenRequest = CodeGeneratorRequest.Parser.ParseFrom(stdin);
            CodeGeneratorResponse codeGenResponse;
            try
            {
                // Generate code.
                // On success, send all generated files back to protoc.
                var descriptors = FileDescriptor.BuildFromByteStrings(codeGenRequest.ProtoFile);
                var results = CodeGenerator.Generate(descriptors, codeGenRequest.FileToGenerate);
                codeGenResponse = new CodeGeneratorResponse
                {
                    File =
                    {
                        results.Select(x => new CodeGeneratorResponse.Types.File
                        {
                            Name = x.RelativePath.Replace('\\', '/'),
                            Content = Encoding.UTF8.GetString(x.Content),
                        })
                    }
                };
            }
            catch (Exception e)
            {
                // On failure, send the error back to protoc.
                codeGenResponse = new CodeGeneratorResponse
                {
                    Error = e.ToString()
                };
            }
            // Write result back to protoc.
            using (var outputStream = new CodedOutputStream(stdout, leaveOpen: true))
            {
                codeGenResponse.WriteTo(outputStream);
            }
        }

        private static void GenerateFromArgs(Options options)
        {
            var descriptorBytes = File.ReadAllBytes(options.Descriptor);
            var files = CodeGenerator.Generate(descriptorBytes, options.Package);
            foreach (var file in files)
            {
                var path = Path.Combine(options.Output, file.RelativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllBytes(path, file.Content);
            }
        }
    }
}
