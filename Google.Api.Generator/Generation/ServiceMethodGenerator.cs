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

using Google.Api.Gax;
using Google.Api.Gax.Grpc;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Google.LongRunning;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    internal class ServiceMethodGenerator
    {
        public static IEnumerable<MemberDeclarationSyntax> Generate(SourceFileContext ctx, ServiceDetails svc, bool inAbstract) =>
            new ServiceMethodGenerator(ctx, svc, inAbstract).Generate();

        private ServiceMethodGenerator(SourceFileContext ctx, ServiceDetails svc, bool inAbstract) =>
            (_ctx, _svc, _inAbstract) = (ctx, svc, inAbstract);

        private readonly ServiceDetails _svc;
        private readonly SourceFileContext _ctx;
        private readonly bool _inAbstract;

        private IEnumerable<MemberDeclarationSyntax> Generate()
        {
            return _svc.Methods.SelectMany(methodDetails =>
            {
                var method = new MethodDef(_ctx, _svc.Namespace, methodDetails);
                return _inAbstract ? Abstract(method) : Impl(method);
            });

            IEnumerable<MemberDeclarationSyntax> Abstract(MethodDef method)
            {
                switch (method.MethodDetails)
                {
                    case MethodDetails.Normal _:
                        yield return method.AbstractSyncRequestMethod;
                        yield return method.AbstractAsyncCallSettingsRequestMethod;
                        yield return method.AbstractAsyncCancellationTokenRequestMethod;
                        break;
                    case MethodDetails.Lro _:
                        yield return method.AbstractSyncRequestMethod;
                        yield return method.AbstractAsyncCallSettingsRequestMethod;
                        yield return method.AbstractAsyncCancellationTokenRequestMethod;
                        yield return method.AbstractLroOperationsClientProperty;
                        yield return method.AbstractLroSyncPollMethod;
                        yield return method.AbstractLroAsyncPollMethod;
                        break;
                }
            }

            IEnumerable<MemberDeclarationSyntax> Impl(MethodDef method)
            {
                switch (method.MethodDetails)
                {
                    case MethodDetails.Normal _:
                        yield return method.ImplSyncRequestMethod;
                        yield return method.ImplAsyncCallSettingsRequestMethod;
                        break;
                    case MethodDetails.Lro _:
                        yield return method.ImplLroOperationsClientProperty;
                        yield return method.ImplLroSyncRequestMethod;
                        yield return method.ImplLroAsyncCallSettingsRequestMethod;
                        break;
                }
            }
        }

        private class MethodDef
        {
            public MethodDef(SourceFileContext ctx, string ns, MethodDetails methodDetails) =>
                (Ctx, Namespace, MethodDetails) = (ctx, ns, methodDetails);

            public SourceFileContext Ctx { get; }
            public string Namespace { get; }

            public MethodDetails MethodDetails { get; }
            public MethodDetails.Lro MethodDetailsLro => (MethodDetails.Lro)MethodDetails;

            private MethodDeclarationSyntax ModifyRequestMethod => ServiceImplClientClassGenerator.ModifyRequestMethod(Ctx, MethodDetails);
            private FieldDeclarationSyntax ApiCallField => ServiceImplClientClassGenerator.ApiCallField(Ctx, MethodDetails);

            private string ApiCallSyncName => nameof(ApiCall<ProtoMsg, ProtoMsg>.Sync);
            private string ApiCallAsyncName => nameof(ApiCall<ProtoMsg, ProtoMsg>.Async);

            private ParameterSyntax RequestParam => Parameter(Ctx.Type(MethodDetails.RequestTyp), "request");
            private ParameterSyntax CallSettingsParam => Parameter(Ctx.Type<CallSettings>(), "callSettings", @default: Null);
            private ParameterSyntax CancellationTokenParam => Parameter(Ctx.Type<CancellationToken>(), "cancellationToken");
            private ParameterSyntax OperationNameParam => Parameter(Ctx.Type<string>(), "operationName");

            private DocumentationCommentTriviaSyntax SummaryXmlDoc => XmlDoc.SummaryMultiline(MethodDetails.DocLines);
            private DocumentationCommentTriviaSyntax RequestXmlDoc => XmlDoc.Param(RequestParam, "The request object containing all of the parameters for the API call.");
            private DocumentationCommentTriviaSyntax CallSettingsXmlDoc => XmlDoc.Param(CallSettingsParam, "If not null, applies overrides to this RPC call.");
            private DocumentationCommentTriviaSyntax CancellationTokenXmlDoc => XmlDoc.Param(CancellationTokenParam, "A ", Ctx.Type<CancellationToken>(), " to use for this RPC.");
            private DocumentationCommentTriviaSyntax ReturnsSyncXmlDoc => XmlDoc.Returns("The RPC response.");
            private DocumentationCommentTriviaSyntax ReturnsAsyncXmlDoc => XmlDoc.Returns("A Task containing the RPC response.");
            private DocumentationCommentTriviaSyntax OperationsSummaryXmlDoc => XmlDoc.Summary("The long-running operations client for ", XmlDoc.C(MethodDetails.SyncMethodName), ".");
            private DocumentationCommentTriviaSyntax OperationNameXmlDoc => XmlDoc.Param(OperationNameParam, "The name of a previously invoked operation. Must not be ", XmlDoc.C("null"), " or empty.");

            // Base abstract members.

            public MethodDeclarationSyntax AbstractSyncRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                    .WithBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsSyncXmlDoc);

            public MethodDeclarationSyntax AbstractAsyncCallSettingsRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                    .WithBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsAsyncXmlDoc);

            public MethodDeclarationSyntax AbstractAsyncCancellationTokenRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CancellationTokenParam)
                    .WithBody(This.Call(AbstractAsyncCallSettingsRequestMethod)(RequestParam, Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(CancellationTokenParam)))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CancellationTokenXmlDoc, ReturnsAsyncXmlDoc);

            // Base impl members.

            public MethodDeclarationSyntax ImplSyncRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                        .WithBody(
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            Return(ApiCallField.Call(ApiCallSyncName)(RequestParam, CallSettingsParam)))
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsSyncXmlDoc);

            public MethodDeclarationSyntax ImplAsyncCallSettingsRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                        .WithBody(
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            Return(ApiCallField.Call(ApiCallAsyncName)(RequestParam, CallSettingsParam)))
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsAsyncXmlDoc);

            // LRO abstract members.

            public PropertyDeclarationSyntax AbstractLroOperationsClientProperty =>
                Property(Public | Virtual, Ctx.Type<OperationsClient>(), MethodDetailsLro.LroClientName)
                    .WithGetBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(OperationsSummaryXmlDoc);

            public MethodDeclarationSyntax AbstractLroSyncPollMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetailsLro.SyncPollMethodName)(OperationNameParam, CallSettingsParam)
                    .WithBody(
                        Ctx.Type(MethodDetailsLro.OperationTyp).Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollOnceFromName))(
                            Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(OperationNameParam, Nameof(OperationNameParam)),
                            AbstractLroOperationsClientProperty, CallSettingsParam))
                    .WithXmlDoc(
                        XmlDoc.Summary("Poll an operation once, using an ", XmlDoc.C("operationName"), " from a previous invocation of ", XmlDoc.C(MethodDetails.SyncMethodName), "."),
                            OperationNameXmlDoc, CallSettingsXmlDoc, XmlDoc.Returns("The result of polling the operation."));

            public MethodDeclarationSyntax AbstractLroAsyncPollMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetailsLro.AsyncPollMethodName)(OperationNameParam, CallSettingsParam)
                    .WithBody(
                        Ctx.Type(MethodDetailsLro.OperationTyp).Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollOnceFromNameAsync))(
                            Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(OperationNameParam, Nameof(OperationNameParam)),
                            AbstractLroOperationsClientProperty, CallSettingsParam))
                    .WithXmlDoc(
                        XmlDoc.Summary("Asynchronously poll an operation once, using an ", XmlDoc.C("operationName"), " from a previous invocation of ", XmlDoc.C(MethodDetails.SyncMethodName), "."),
                            OperationNameXmlDoc, CallSettingsXmlDoc, XmlDoc.Returns("A task representing the result of polling the operation."));

            // LRO impl members.

            public PropertyDeclarationSyntax ImplLroOperationsClientProperty =>
                AutoProperty(Public | Override, Ctx.Type<OperationsClient>(), MethodDetailsLro.LroClientName)
                    .WithXmlDoc(OperationsSummaryXmlDoc);

            public MethodDeclarationSyntax ImplLroSyncRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                        .WithBody(
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            Return(New(Ctx.Type(MethodDetailsLro.OperationTyp))(ApiCallField.Call(ApiCallSyncName)(RequestParam, CallSettingsParam), ImplLroOperationsClientProperty))
                        )
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsSyncXmlDoc);

            public MethodDeclarationSyntax ImplLroAsyncCallSettingsRequestMethod =>
                Method(Public | Override | Async, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                        .WithBody(
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            Return(New(Ctx.Type(MethodDetailsLro.OperationTyp))(Await(ApiCallField.Call(ApiCallAsyncName)(RequestParam, CallSettingsParam).ConfigureAwait()), ImplLroOperationsClientProperty))
                        )
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsAsyncXmlDoc);
        }
    }
}
