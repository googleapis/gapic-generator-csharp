// Copyright 2022 Google LLC
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

using Google.Api.Gax.Grpc;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Generation
{
    internal class ApiDescriptorGenerator
    {
        internal const string ClassName = "GaxApiDescriptor";
        internal const string FileName = ClassName + ".g.cs";
        internal const string PropertyName = "ApiDescriptor";

        public static CompilationUnitSyntax GenerateApiDescriptor(string ns, SourceFileContext ctx, IEnumerable<FileDescriptor> packageFileDescriptors)
        {
            var namespaceDeclaration = Namespace(ns);
            using (ctx.InNamespace(namespaceDeclaration))
            {
                var descriptorClass = GenerateClass(ns, ctx, packageFileDescriptors);
                namespaceDeclaration = namespaceDeclaration.AddMembers(descriptorClass);
            }
            return ctx.CreateCompilationUnit(namespaceDeclaration);
        }

        private static ClassDeclarationSyntax GenerateClass(string ns, SourceFileContext ctx, IEnumerable<FileDescriptor> packageFileDescriptors)
        {
            var typ = Typ.Manual(ns, $"GaxApiDescriptor");
            var cls = Class(Internal | Static, typ)
                .WithXmlDoc(XmlDoc.Summary("Static class to provide common access to an API descriptor."));

            var transportsEnum = ctx.Type<GrpcTransports>();
            // FIXME: Use Rest/Grpc as appropriate
            var transports = transportsEnum.Access("Grpc");

            var yieldStatements = packageFileDescriptors.Select(GenerateYieldStatement).ToArray();
            var fileDescriptorMethod = Method(Private | Static, ctx.Type(Typ.Of<IEnumerable<FileDescriptor>>()), "GetFileDescriptors")()
                .WithBlockBody(yieldStatements);

            // TODO: Use ctx.Type<ApiDescriptorType> when GAX is published.
            var apiDescriptorType = ctx.Type<ApiDescriptor>();
            var property = AutoProperty(Internal | Static, apiDescriptorType, PropertyName)
                .WithInitializer(New(apiDescriptorType)(ns, transports, IdentifierName(fileDescriptorMethod.Identifier)))
                .WithXmlDoc(XmlDoc.Summary("The ", apiDescriptorType, " for services in this package."));
            return cls.AddMembers(property, fileDescriptorMethod);

            YieldStatementSyntax GenerateYieldStatement(FileDescriptor descriptor)
            {
                var type = ctx.Type(ProtoTyp.OfReflectionClass(descriptor));
                return YieldStatement(SyntaxKind.YieldReturnStatement, type.Access("Descriptor"));
            }
        }
    }
}
