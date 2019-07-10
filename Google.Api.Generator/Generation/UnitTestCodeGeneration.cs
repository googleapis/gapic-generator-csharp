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
using Google.Api.Gax.Grpc;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Google.LongRunning;
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
using System.Threading;
using System.Threading.Tasks;
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
                        yield return methodDef.AsyncRequestMethod;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.SyncMethod;
                            yield return signature.AsyncMethod;
                            if (signature.HasResourceNames)
                            {
                                yield return signature.SyncMethodResourceNames;
                                yield return signature.AsyncMethodResourceNames;
                            }
                        }
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
            private LocalDeclarationStatementSyntax ResponseCallSettings => Local(Ctx.Type(Method.ResponseTyp), "responseCallSettings");
            private LocalDeclarationStatementSyntax ResponseCancellationToken => Local(Ctx.Type(Method.ResponseTyp), "responseCancellationToken");

            private ParameterSyntax X => Parameter(null, "x");

            private object TestValue(FieldDescriptor fieldDesc, bool resourceNameAsString = false)
            {
                var md5 = MD5.Create();
                var resource = Svc.Catalog.GetResourceDetailsByField(fieldDesc);
                if (resource != null)
                {
                    // TODO: Resource-sets
                    var one = resource.ResourceDefinition.Single;
                    var multi = resource.ResourceDefinition.Multi;
                    object value;
                    if (resourceNameAsString)
                    {
                        if (multi != null)
                        {
                            // TODO
                            value = "TODO!!!";
                        }
                        else
                        {
                            value = one.IsWildcard ?
                                "a/wildcard/resource" :
                                one.Template.Expand(one.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]").ToArray());
                        }
                    }
                    else
                    {
                        if (multi != null)
                        {
                            // TODO
                            value = "TODO!!!";
                        }
                        else
                        {
                            value = one.IsWildcard ?
                            New(Ctx.Type<UnknownResourceName>())("a/wildcard/resource") :
                            New(Ctx.Type(one.ResourceNameTyp))(one.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]"));
                        }
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

            private IEnumerable<ObjectInitExpr> InitMessage(MessageDescriptor msgDesc, IEnumerable<MethodDetails.Signature.Field> onlyFields)
            {
                var onlyFieldsSet = onlyFields?.Select(x => x.Descs.Last().FieldNumber).ToHashSet();
                foreach (var fieldDesc in msgDesc.Fields.InFieldNumberOrder())
                {
                    if (!IsPaginationField() && (onlyFieldsSet == null || onlyFieldsSet.Contains(fieldDesc.FieldNumber)))
                    {
                        // TODO: Support one-ofs properly; i.e. only set one of the fields.
                        yield return new ObjectInitExpr(
                            Svc.Catalog.GetResourceDetailsByField(fieldDesc)?.SingleResourcePropertyName ?? fieldDesc.CSharpPropertyName(),
                            TestValue(fieldDesc));
                    }

                    bool IsPaginationField() => Method is MethodDetails.Paginated paged &&
                        (fieldDesc.FieldNumber == paged.PageSizeFieldNumber || fieldDesc.FieldNumber == paged.PageTokenFieldNumber);
                }
            }

            private IEnumerable<object> LroSetup()
            {
                if (Svc.Methods.Any(x => x is MethodDetails.Lro))
                {
                    yield return MockGrpcClient.Call(nameof(Mock<string>.Setup))(Lambda(X)(X.Call("CreateOperationsClient")()))
                        .Call(nameof(IReturns<string, int>.Returns))(New(Ctx.Type<Mock<Operations.OperationsClient>>())().Access(nameof(Mock.Object)));
                }
            }

            private MethodDeclarationSyntax Sync(string methodName, IEnumerable<MethodDetails.Signature.Field> requestFields, object requestMethodArgs) =>
                Method(Public, VoidType, methodName)()
                    .WithAttribute(Ctx.Type<FactAttribute>())
                    .WithBody(
                        MockGrpcClient.WithInitializer(New(Ctx.Type(Typ.Generic(typeof(Mock<>), Svc.GrpcClientTyp)))(Ctx.Type<MockBehavior>().Access(MockBehavior.Strict))),
                        LroSetup(),
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitMessage(Method.RequestMessageDesc, requestFields).ToArray())),
                        ExpectedResponse.WithInitializer(New(Ctx.Type(Method.ResponseTyp))().WithInitializer(InitMessage(Method.ResponseMessageDesc, null).ToArray())),
                        MockGrpcClient.Call(nameof(Mock<string>.Setup))(
                            Lambda(X)(X.Call(Method.SyncMethodName)(Request, Ctx.Type(typeof(It)).Call(nameof(It.IsAny), Ctx.Type<CallOptions>())())))
                            .Call(nameof(IReturns<string, int>.Returns))(ExpectedResponse),
                        Client.WithInitializer(New(Ctx.Type(Svc.ClientImplTyp))(MockGrpcClient.Access(nameof(Mock.Object)), Null)),
                        Response.WithInitializer(Client.Call(Method.SyncMethodName)(requestMethodArgs)),
                        Ctx.Type<Assert>().Call(nameof(Assert.Same))(ExpectedResponse, Response),
                        MockGrpcClient.Call(nameof(Mock.VerifyAll))());

            private MethodDeclarationSyntax Async(string methodName, IEnumerable<MethodDetails.Signature.Field> requestFields, object requestMethodArgs) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithAttribute(Ctx.Type<FactAttribute>())
                    .WithBody(
                        MockGrpcClient.WithInitializer(New(Ctx.Type(Typ.Generic(typeof(Mock<>), Svc.GrpcClientTyp)))(Ctx.Type<MockBehavior>().Access(MockBehavior.Strict))),
                        LroSetup(),
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitMessage(Method.RequestMessageDesc, requestFields).ToArray())),
                        ExpectedResponse.WithInitializer(New(Ctx.Type(Method.ResponseTyp))().WithInitializer(InitMessage(Method.ResponseMessageDesc, null).ToArray())),
                        MockGrpcClient.Call(nameof(Mock<string>.Setup))(
                            Lambda(X)(X.Call(Method.AsyncMethodName)(Request, Ctx.Type(typeof(It)).Call(nameof(It.IsAny), Ctx.Type<CallOptions>())())))
                            .Call(nameof(IReturns<string, int>.Returns))(New(Ctx.Type(Typ.Generic(typeof(AsyncUnaryCall<>), Method.ResponseTyp)))(
                                Ctx.Type<Task>().Call(nameof(Task.FromResult))(ExpectedResponse), Null, Null, Null, Null)),
                        Client.WithInitializer(New(Ctx.Type(Svc.ClientImplTyp))(MockGrpcClient.Access(nameof(Mock.Object)), Null)),
                        ResponseCallSettings.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(requestMethodArgs,
                            Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(Ctx.Type<CancellationToken>().Access(nameof(CancellationToken.None)))))),
                        Ctx.Type<Assert>().Call(nameof(Assert.Same))(ExpectedResponse, ResponseCallSettings),
                        ResponseCancellationToken.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(requestMethodArgs,
                            Ctx.Type<CancellationToken>().Access(nameof(CancellationToken.None))))),
                        Ctx.Type<Assert>().Call(nameof(Assert.Same))(ExpectedResponse, ResponseCancellationToken),
                        MockGrpcClient.Call(nameof(Mock.VerifyAll))());

            public MethodDeclarationSyntax SyncRequestMethod => Sync(Method.SyncTestMethodName, null, Request);

            public MethodDeclarationSyntax AsyncRequestMethod => Async(Method.AsyncTestMethodName, null, Request);

            public class Signature
            {
                // TODO: Support resource-sets.

                public Signature(MethodDef def, MethodDetails.Signature sig, int? index) => (_def, _sig, _index) = (def, sig, index);

                private MethodDef _def;
                private MethodDetails.Signature _sig;
                private int? _index;

                private ServiceDetails Svc => _def.Svc;
                private SourceFileContext Ctx => _def.Ctx;
                private MethodDetails Method => _def.Method;

                private string SyncMethodName => Method.SyncMethodName + (_index is int index ? (index + 1).ToString() : "");
                private string AsyncMethodName => $"{Method.AsyncMethodName.Substring(0, Method.AsyncMethodName.Length - 5)}{(_index is int index ? (index + 1).ToString() : "")}Async";
                private string SyncResourceNameMethodName => $"{SyncMethodName}_ResourceNames";
                private string AsyncResourceNameMethodName => $"{AsyncMethodName}_ResourceNames";

                private IEnumerable<object> SigArgs => _sig.Fields.Select(field => _def.Request.Access(field.PropertyName));

                // TODO: Multi-resource-names.
                private IEnumerable<object> SigResourceNameArgs =>
                    _sig.Fields.Select(field => _def.Request.Access(field.FieldResource?.SingleResourcePropertyName ?? field.PropertyName));

                public bool HasResourceNames => _sig.Fields.Any(x => x.FieldResource != null);

                public MethodDeclarationSyntax SyncMethod => _def.Sync(SyncMethodName, _sig.Fields, SigArgs);

                public MethodDeclarationSyntax AsyncMethod => _def.Async(AsyncMethodName, _sig.Fields, SigArgs);

                public MethodDeclarationSyntax SyncMethodResourceNames => _def.Sync(SyncResourceNameMethodName, _sig.Fields, SigResourceNameArgs);

                public MethodDeclarationSyntax AsyncMethodResourceNames => _def.Async(AsyncResourceNameMethodName, _sig.Fields, SigResourceNameArgs);
            }

            public IEnumerable<Signature> Signatures => Method.Signatures.Select((sig, i) => new Signature(this, sig, Method.Signatures.Count > 1 ? i : (int?)null));
        }
    }
}
