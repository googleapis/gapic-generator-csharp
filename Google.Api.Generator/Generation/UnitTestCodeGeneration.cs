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

using Google.Api.Gax;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;
using Moq.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    internal class UnitTestCodeGeneration
    {
        public static CompilationUnitSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new UnitTestCodeGeneration(ctx, svc).Generate();

        private UnitTestCodeGeneration(SourceFileContext ctx, ServiceDetails svc) => (_ctx, _svc) = (ctx, svc);

        private readonly SourceFileContext _ctx;
        private readonly ServiceDetails _svc;

        private CompilationUnitSyntax Generate()
        {
            var ns = Namespace(_svc.Namespace);
            using (_ctx.InNamespace(ns))
            {
                var cls = Class(Public | Sealed, _svc.UnitTestsTyp).WithXmlDoc(XmlDoc.Summary("Generated unit tests."));
                using (_ctx.InClass(cls))
                {
                    cls = cls.AddMembers(GenerateMethods().ToArray());
                }
                ns = ns.AddMembers(cls);
            }
            return _ctx.CreateCompilationUnit(ns);
        }

        private IEnumerable<MethodDeclarationSyntax> GenerateMethods()
        {
            foreach (var method in _svc.Methods)
            {
                var methodDef = new MethodDef(_ctx, _svc, method);
                // TODO: Test of non-"normal" methods. E.g. LRO.
                switch (method)
                {
                    case MethodDetails.Normal _:
                        yield return methodDef.SyncRequestMethod;
                        // TODO: Async test.
                        // TODO: Test method signatures.
                        break;
                }
            }
        }

        private class MethodDef
        {
            private static MD5 s_md5 = MD5.Create();

            public MethodDef(SourceFileContext ctx, ServiceDetails svc, MethodDetails method) =>
                (Ctx, Svc, Method) = (ctx, svc, method);

            private SourceFileContext Ctx { get; }
            private ServiceDetails Svc { get; }
            private MethodDetails Method { get; }

            private LocalDeclarationStatementSyntax MockGrpcClient => Local(Ctx.Type(Typ.Generic(typeof(Mock<>), Svc.GrpcClientTyp)), "mockGrpcClient");
            private LocalDeclarationStatementSyntax Client => Local(Ctx.Type(Svc.ClientAbstractTyp), "client");
            private LocalDeclarationStatementSyntax Request => Local(Ctx.Type(Method.RequestTyp), "request");
            private LocalDeclarationStatementSyntax ExpectedResponse => Local(Ctx.Type(Method.ResponseTyp), "expectedResponse");
            private LocalDeclarationStatementSyntax Response => Local(Ctx.Type(Method.ResponseTyp), "response");

            private ParameterSyntax X => Parameter(null, "x");

            private object TestValue(FieldDescriptor fieldDesc, bool resourceNameAsString = false)
            {
                var md5 = MD5.Create();
                var resource = Svc.Catalog.GetResourceDetailsByField(fieldDesc);
                if (resource != null)
                {
                    // TODO: Resource-sets
                    var one = resource.ResourceDefinition.One;
                    object value;
                    if (resourceNameAsString)
                    {
                        value = one.IsWildcard ?
                            "a/wildcard/resource" :
                            one.Template.Expand(one.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]").ToArray());
                    }
                    else
                    {
                        value = one.IsWildcard ?
                            New(Ctx.Type<UnknownResourceName>())("a/wildcard/resource") :
                            New(Ctx.Type(one.ResourceNameTyp))(one.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]"));
                    }
                    return fieldDesc.IsRepeated ? CollectionInitializer(value) : value;
                }
                else
                {
                    object value;
                    if (fieldDesc.IsMap)
                    {
                        throw new NotImplementedException("Map types not yet implemented.");
                    }
                    // See https://developers.google.com/protocol-buffers/docs/proto3#scalar
                    // Switch cases are ordered as in this doc. Please do not re-order.
                    switch (fieldDesc.FieldType)
                    {
                        case FieldType.Double: value = Double(); break;
                        case FieldType.Float: value = (float)Double(); break;
                        case FieldType.Int32: value = Int(); break;
                        case FieldType.Int64: value = Long(); break;
                        case FieldType.UInt32: value = (uint)Int(); break;
                        case FieldType.UInt64: value = (ulong)Long(); break;
                        case FieldType.SInt32: value = Int(); break;
                        case FieldType.SInt64: value = Long(); break;
                        case FieldType.Fixed32: value = (uint)Int(); break;
                        case FieldType.Fixed64: value = (ulong)Long(); break;
                        case FieldType.SFixed32: value = Int(); break;
                        case FieldType.SFixed64: value = Long(); break;
                        case FieldType.Bool: value = Int() >= 0; break;
                        case FieldType.String: value = String(); break;
                        case FieldType.Bytes: value = Ctx.Type<ByteString>().Call(nameof(ByteString.CopyFromUtf8))(String()); break;
                        case FieldType.Message: value = New(Ctx.Type(Typ.Of(fieldDesc.MessageType)))(); break;
                        case FieldType.Enum: value = Ctx.Type(Typ.Of(fieldDesc.EnumType)).Access(
                            fieldDesc.EnumType.Values[Math.Abs(Int()) % fieldDesc.EnumType.Values.Count].CSharpName()); break;
                        default: throw new InvalidOperationException($"Cannot generate test value for proto type: {fieldDesc.FieldType}");

                    }
                    return fieldDesc.IsRepeated ? CollectionInitializer(value) : value;
                }

                // Generate deterministic values, based on the field name.
                byte[] FieldHash() => s_md5.ComputeHash(Encoding.UTF8.GetBytes(fieldDesc.Name));
                int Int() => BitConverter.ToInt32(FieldHash());
                long Long() => BitConverter.ToInt64(FieldHash());
                double Double() => ((double)Long()) / 8;
                string String() => $"{fieldDesc.Name}{Int():x8}";
            }

            private IEnumerable<ObjectInitExpr> InitMessage(MessageDescriptor msgDesc)
            {
                foreach (var fieldDesc in msgDesc.Fields.InFieldNumberOrder())
                {
                    if (!IsPaginationField())
                    {
                        // TODO: Support one-ofs properly; i.e. only set one of the fields.
                        yield return new ObjectInitExpr(
                            Svc.Catalog.GetResourceDetailsByField(fieldDesc)?.ResourcePropertyName ?? fieldDesc.CSharpPropertyName(),
                            TestValue(fieldDesc));
                    }

                    bool IsPaginationField() => Method is MethodDetails.Paginated paged &&
                        (fieldDesc.FieldNumber == paged.PageSizeFieldNumber || fieldDesc.FieldNumber == paged.PageTokenFieldNumber);
                }
            }

            public MethodDeclarationSyntax SyncRequestMethod =>
                Method(Public, VoidType, Method.SyncTestMethodName)()
                    .WithAttribute(Ctx.Type<FactAttribute>())
                    .WithBody(
                        MockGrpcClient.WithInitializer(New(Ctx.Type(Typ.Generic(typeof(Mock<>), Svc.GrpcClientTyp)))(Ctx.Type<MockBehavior>().Access(MockBehavior.Strict))),
                        // TODO: Setup mock LRO clients.
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitMessage(Method.RequestMessageDesc).ToArray())),
                        ExpectedResponse.WithInitializer(New(Ctx.Type(Method.ResponseTyp))().WithInitializer(InitMessage(Method.ResponseMessageDesc).ToArray())),
                        MockGrpcClient.Call(nameof(Mock<string>.Setup))(
                            Lambda(X, X.Call(Method.SyncMethodName)(Request, Ctx.Type(typeof(It)).Call(nameof(It.IsAny), Ctx.Type<CallOptions>())())))
                            .Call(nameof(IReturns<string, int>.Returns))(ExpectedResponse),
                        Client.WithInitializer(New(Ctx.Type(Svc.ClientImplTyp))(MockGrpcClient.Access(nameof(Mock.Object)), Null)),
                        Response.WithInitializer(Client.Call(Method.SyncMethodName)(Request)),
                        Ctx.Type<Assert>().Call(nameof(Assert.Same))(ExpectedResponse, Response),
                        MockGrpcClient.Call(nameof(Mock.VerifyAll))()
                    );
        }
    }
}
