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
using Google.Api.Gax;
using Google.Protobuf;
using Google.Protobuf.Compiler;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Api.Generator
{
    public static class Program
    {
        private const string nameGrpcServiceConfig = "grpc-service-config";
        private const string nameCommonResourcesConfig = "common-resources-config";

        private static IImmutableSet<string> s_validParameters = ImmutableHashSet.Create(
            nameGrpcServiceConfig,
            nameCommonResourcesConfig);

        public class Options
        {
            [Option("descriptor", Required = true, HelpText = "The path on disk to a file containing a serialized `FileDescriptorSet`.")]
            public string Descriptor { get; private set; }

            [Option("package", Required = true, HelpText = "The proto package designated the files actually intended for output.")]
            public string Package { get; private set; }

            [Option("output", Required = true, HelpText = " The output directory.")]
            public string Output { get; private set; }

            [Option(nameGrpcServiceConfig, Required = false, HelpText = "Client-side gRPC service config path. JSON proto of type ServiceConfig.")]
            public string GrpcServiceConfig { get; private set; }

            [Option(nameCommonResourcesConfig, Required = false, HelpText = "Common resources config path. JSON proto of type CommonResources.")]
            public IEnumerable<string> CommonResourcesConfigs { get; private set; }

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
                    return GenerateFromProtoc(stdin, stdout);
                }
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

        private class TimeoutStream : Stream
        {
            public TimeoutStream(Stream underlying) => _underlying = underlying;

            private readonly Stream _underlying;

            public override bool CanRead => _underlying.CanRead;
            public override bool CanSeek => _underlying.CanSeek;
            public override bool CanWrite => _underlying.CanWrite;
            public override long Length => _underlying.Length;
            public override long Position { get => _underlying.Position; set => _underlying.Position = value; }
            public override void Flush() => _underlying.Flush();
            public override long Seek(long offset, SeekOrigin origin) => _underlying.Seek(offset, origin);
            public override void SetLength(long value) => _underlying.SetLength(value);

            public override bool CanTimeout => true;
            public override int ReadTimeout { get; set; }

            public override int Read(byte[] buffer, int offset, int count)
            {
                var readTask = _underlying.ReadAsync(buffer, offset, count); // CancellationToken passed here is ignored.
                var index = Task.WaitAny(new[] { readTask }, millisecondsTimeout: ReadTimeout);
                if (index == 0)
                {
                    return readTask.Result;
                }
                throw new TimeoutException("Read timed-out.");
            }

            public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
        }

        private static int GenerateFromProtoc(Stream stdin, Stream stdout)
        {
            var stdinTimeout = new TimeoutStream(stdin) { ReadTimeout = 2_000 };
            CodeGeneratorRequest codeGenRequest;
            try
            {
                codeGenRequest = CodeGeneratorRequest.Parser.ParseFrom(stdinTimeout);
            }
            catch (TimeoutException)
            {
                // This has probably been called from the cmd-line, not from protoc,
                // so output an error message to the console.
                Parser.Default.ParseArguments<Options>(Enumerable.Empty<string>());
                return 1;
            }
            CodeGeneratorResponse codeGenResponse;
            try
            {
                // Parse additional parameters.
                var extraParams = ParseExtraParameters(codeGenRequest.Parameter);
                // Generate code.
                // On success, send all generated files back to protoc.
                var descriptors = FileDescriptor.BuildFromByteStrings(codeGenRequest.ProtoFile);
                var results = CodeGenerator.Generate(descriptors, codeGenRequest.FileToGenerate, SystemClock.Instance,
                    extraParams.GetValueOrDefault(nameGrpcServiceConfig)?.SingleOrDefault(), extraParams.GetValueOrDefault(nameCommonResourcesConfig));
                codeGenResponse = new CodeGeneratorResponse
                {
                    SupportedFeatures = (int)CodeGeneratorResponse.Types.Feature.Proto3Optional,
                    File =
                    {
                        results.Select(x => new CodeGeneratorResponse.Types.File
                        {
                            Name = x.RelativePath.Replace('\\', '/'),
                            Content = x.Content,
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
            return 0;

            IReadOnlyDictionary<string, IReadOnlyList<string>> ParseExtraParameters(string paramsString)
            {
                // Multiple parameters to protoc use a comma separater.
                var ps = paramsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                return ps
                    .Select(param =>
                    {
                        var parts = param.Split('=').Select(x => x.Trim()).ToArray();
                        if (parts.Length != 2)
                        {
                            throw new InvalidOperationException($"Invalid parameter: '{param}'");
                        }
                        if (!s_validParameters.Contains(parts[0]))
                        {
                            throw new InvalidOperationException($"Invalid parameter name: '{param}'");
                        }
                        return parts;
                    })
                    .GroupBy(x => x[0])
                    .ToDictionary(x => x.Key, x => (IReadOnlyList<string>)x.Select(y => y[1]).ToList());
            }
        }

        private static void GenerateFromArgs(Options options)
        {
            var descriptorBytes = File.ReadAllBytes(options.Descriptor);
            var files = CodeGenerator.Generate(descriptorBytes, options.Package, SystemClock.Instance, options.GrpcServiceConfig, options.CommonResourcesConfigs);
            foreach (var file in files)
            {
                var path = Path.Combine(options.Output, file.RelativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, file.Content);
            }
        }
    }
}
