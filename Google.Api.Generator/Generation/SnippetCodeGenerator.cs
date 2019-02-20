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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    internal class SnippetCodeGenerator
    {
        public static CompilationUnitSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new SnippetCodeGenerator(ctx, svc).Generate();

        private SnippetCodeGenerator(SourceFileContext ctx, ServiceDetails svc) => (_ctx, _svc) = (ctx, svc);

        private readonly SourceFileContext _ctx;
        private readonly ServiceDetails _svc;

        private CompilationUnitSyntax Generate()
        {
            var ns = Namespace(_svc.Namespace);
            using (_ctx.InNamespace(ns))
            {
                var cls = Class(Public | Sealed, _svc.SnippetsTyp)
                    .WithXmlDoc(XmlDoc.Summary("Generated snippets."));
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
                switch (method)
                {
                    case MethodDetails.Normal _:
                        yield return methodDef.SyncRequestMethod;
                        yield return methodDef.AsyncRequestMethod;
                        break;
                    case MethodDetails.Lro _:
                        yield return methodDef.SyncLroRequestMethod;
                        yield return methodDef.AsyncLroRequestMethod;
                        break;
                }
            }
        }

        private class MethodDef
        {
            public MethodDef(SourceFileContext ctx, ServiceDetails svc, MethodDetails method) =>
                (Ctx, Svc, Method) = (ctx, svc, method);

            private SourceFileContext Ctx { get; }
            private ServiceDetails Svc { get; }
            private MethodDetails Method { get; }
            private MethodDetails.Lro MethodLro => (MethodDetails.Lro)Method;

            private LocalDeclarationStatementSyntax Client => Local(Ctx.Type(Svc.ClientAbstractTyp), Svc.SnippetsClientName);
            private LocalDeclarationStatementSyntax Request => Local(Ctx.Type(Method.RequestTyp), "request");
            private LocalDeclarationStatementSyntax Response => Local(Ctx.Type(Method.ResponseTyp), "response");
            private LocalDeclarationStatementSyntax LroResponse => Local(Ctx.Type(MethodLro.OperationTyp), "response");
            private LocalDeclarationStatementSyntax LroCompletedResponse => Local(Ctx.Type(MethodLro.OperationTyp), "completedResponse");
            private LocalDeclarationStatementSyntax LroResult => Local(Ctx.Type(MethodLro.OperationResponseTyp), "result");
            private LocalDeclarationStatementSyntax LroOperationName => Local(Ctx.Type<string>(), "operationName");
            private LocalDeclarationStatementSyntax LroRetrievedResponse => Local(Ctx.Type(MethodLro.OperationTyp), "retrievedResponse");
            private LocalDeclarationStatementSyntax LroRetrievedResult => Local(Ctx.Type(MethodLro.OperationResponseTyp), "retrievedResult");


            private IEnumerable<ObjectInitExpr> InitRequest()
            {
                foreach (var fieldDesc in Method.RequestMessageDesc.Fields.InFieldNumberOrder())
                {
                    var resource = Svc.Catalog.GetResourceDetailsByField(fieldDesc);
                    if (resource != null)
                    {
                        // TODO: Resource-sets
                        var one = resource.ResourceDefinition.One;
                        object @default = one.IsWildcard ?
                            New(Ctx.Type<UnknownResourceName>())("a/wildcard/resource") :
                            New(Ctx.Type(one.ResourceNameTyp))(one.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]"));
                        yield return new ObjectInitExpr(resource.ResourcePropertyName, fieldDesc.IsRepeated ? CollectionInitializer(@default) : @default);
                    }
                    else
                    {
                        object @default;
                        if (fieldDesc.IsMap)
                        {
                            throw new NotImplementedException("Map types not yet implemented.");
                        }
                        // See https://developers.google.com/protocol-buffers/docs/proto3#scalar
                        // Switch cases are ordered as in this doc. Please do not re-order.
                        switch (fieldDesc.FieldType)
                        {
                            case FieldType.Double: @default = default(double); break;
                            case FieldType.Float: @default = default(float); break;
                            case FieldType.Int32: @default = default(int); break;
                            case FieldType.Int64: @default = default(long); break;
                            case FieldType.UInt32: @default = default(uint); break;
                            case FieldType.UInt64: @default = default(ulong); break;
                            case FieldType.SInt32: @default = default(int); break;
                            case FieldType.SInt64: @default = default(long); break;
                            case FieldType.Fixed32: @default = default(uint); break;
                            case FieldType.Fixed64: @default = default(ulong); break;
                            case FieldType.SFixed32: @default = default(int); break;
                            case FieldType.SFixed64: @default = default(long); break;
                            case FieldType.Bool: @default = default(bool); break;
                            case FieldType.String: @default = ""; break;
                            case FieldType.Bytes: @default = Ctx.Type<ByteString>().Access(nameof(ByteString.Empty)); break;
                            case FieldType.Message: @default = New(Ctx.Type(Typ.Of(fieldDesc.MessageType)))(); break;
                            case FieldType.Enum: @default = Ctx.Type(Typ.Of(fieldDesc.EnumType)).Access(fieldDesc.EnumType.Values.First().CSharpName()); break;
                            default: throw new InvalidOperationException($"Cannot generate default for proto type: {fieldDesc.FieldType}");

                        }
                        yield return new ObjectInitExpr(fieldDesc.CSharpPropertyName(), fieldDesc.IsRepeated ? CollectionInitializer(@default) : @default);
                    }
                }
            }

            public MethodDeclarationSyntax SyncRequestMethod =>
                Method(Public, VoidType, Method.SyncSnippetMethodName)()
                    .WithBody(
                        $"// Snippet: {Method.SyncMethodName}({Method.RequestTyp.Name}, {nameof(CallSettings)})",
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        "// Initialize request argument(s)",
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitRequest().ToArray())),
                        "// Make the request",
                        Response.WithInitializer(Client.Call(Method.SyncMethodName)(Request)),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            public MethodDeclarationSyntax AsyncRequestMethod =>
                Method(Public | Async, Ctx.Type<Task>(), Method.AsyncSnippetMethodName)()
                    .WithBody(
                        $"// Snippet: {Method.AsyncMethodName}({Method.RequestTyp.Name}, {nameof(CallSettings)})",
                        $"// Additional: {Method.AsyncMethodName}({Method.RequestTyp.Name}, {nameof(CancellationToken)})",
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        "// Initialize request argument(s)",
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitRequest().ToArray())),
                        "// Make the request",
                        Response.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(Request))),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.AsyncMethodName}"));

            public MethodDeclarationSyntax SyncLroRequestMethod =>
                Method(Public, VoidType, Method.SyncSnippetMethodName)()
                    .WithBody(
                        $"// Snippet: {Method.SyncMethodName}({Method.RequestTyp.Name}, {nameof(CallSettings)})",
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        "// Initialize request argument(s)",
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitRequest().ToArray())),
                        "// Make the request",
                        LroResponse.WithInitializer(Client.Call(Method.SyncMethodName)(Request)),
                        BlankLine,
                        "// Poll until the returned long-running operation is complete",
                        LroCompletedResponse.WithInitializer(LroResponse.Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollUntilCompleted))()),
                        "// Retrieve the operation result",
                        LroResult.WithInitializer(LroCompletedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result))),
                        BlankLine,
                        "// Or get the name of the operation",
                        LroOperationName.WithInitializer(LroResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Name))),
                        "// This name can be stored, then the long-running operation retrieved later by name",
                        LroRetrievedResponse.WithInitializer(Client.Call(MethodLro.SyncPollMethodName)(LroOperationName)),
                        "// Check if the retrieved long-running operation has completed",
                        If(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.IsCompleted)))
                            .Then(
                                "// If it has completed, then access the result",
                                LroRetrievedResult.WithInitializer(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result)))),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            public MethodDeclarationSyntax AsyncLroRequestMethod =>
                Method(Public | Async, Ctx.Type<Task>(), Method.AsyncSnippetMethodName)()
                    .WithBody(
                        $"// Snippet: {Method.AsyncMethodName}({Method.RequestTyp.Name}, {nameof(CallSettings)})",
                        $"// Additional: {Method.AsyncMethodName}({Method.RequestTyp.Name}, {nameof(CancellationToken)})",
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        "// Initialize request argument(s)",
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitRequest().ToArray())),
                        "// Make the request",
                        LroResponse.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(Request))),
                        BlankLine,
                        "// Poll until the returned long-running operation is complete",
                        LroCompletedResponse.WithInitializer(Await(LroResponse.Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollUntilCompletedAsync))())),
                        "// Retrieve the operation result",
                        LroResult.WithInitializer(LroCompletedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result))),
                        BlankLine,
                        "// Or get the name of the operation",
                        LroOperationName.WithInitializer(LroResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Name))),
                        "// This name can be stored, then the long-running operation retrieved later by name",
                        LroRetrievedResponse.WithInitializer(Await(Client.Call(MethodLro.AsyncPollMethodName)(LroOperationName))),
                        "// Check if the retrieved long-running operation has completed",
                        If(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.IsCompleted)))
                            .Then(
                                "// If it has completed, then access the result",
                                LroRetrievedResult.WithInitializer(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result)))),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.AsyncMethodName}"));
        }
    }
}
