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
using Google.Api.Generator.Utils.Roslyn;
using Google.Api.Generator.Utils;
using Google.LongRunning;
using Grpc.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using System.Collections;
using Google.Protobuf.Reflection;

namespace Google.Api.Generator.Generation
{
    internal partial class ServiceMethodGenerator
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
                        foreach (var signature in method.SignaturesToGenerate)
                        {
                            yield return signature.AbstractSyncRequestMethod;
                            yield return signature.AbstractAsyncCallSettingsRequestMethod;
                            yield return signature.AbstractAsyncCancellationTokenRequestMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.AbstractSyncRequestMethod;
                                yield return resourceName.AbstractAsyncCallSettingsRequestMethod;
                                yield return resourceName.AbstractAsyncCancellationTokenRequestMethod;
                            }
                        }
                        break;
                    case MethodDetails.Paginated _:
                        yield return method.AbstractSyncRequestMethod;
                        yield return method.AbstractAsyncCallSettingsRequestMethod;
                        foreach (var signature in method.SignaturesToGenerate)
                        {
                            yield return signature.AbstractSyncPaginatedRequestMethod;
                            yield return signature.AbstractAsyncPaginatedCallSettingsRequestMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.AbstractSyncPaginatedRequestMethod;
                                yield return resourceName.AbstractAsyncPaginatedCallSettingsRequestMethod;
                            }
                        }
                        break;
                    case MethodDetails.Lro _:
                        yield return method.AbstractSyncRequestMethod;
                        yield return method.AbstractAsyncCallSettingsRequestMethod;
                        yield return method.AbstractAsyncCancellationTokenRequestMethod;
                        yield return method.AbstractLroOperationsClientProperty;
                        yield return method.AbstractLroSyncPollMethod;
                        yield return method.AbstractLroAsyncPollMethod;
                        foreach (var signature in method.SignaturesToGenerate)
                        {
                            yield return signature.AbstractSyncRequestMethod;
                            yield return signature.AbstractAsyncCallSettingsRequestMethod;
                            yield return signature.AbstractAsyncCancellationTokenRequestMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.AbstractSyncRequestMethod;
                                yield return resourceName.AbstractAsyncCallSettingsRequestMethod;
                                yield return resourceName.AbstractAsyncCancellationTokenRequestMethod;
                            }
                        }
                        break;
                    case MethodDetails.BidiStreaming _:
                        yield return method.AbstractBidiStreamClass;
                        yield return method.AbstractBidiStreamSyncRequestMethod;
                        break;
                    case MethodDetails.ClientStreaming _:
                        yield return method.AbstractClientStreamClass;
                        yield return method.AbstractClientStreamSyncRequestMethod;
                        break;
                    case MethodDetails.ServerStreaming _:
                        yield return method.AbstractServerStreamClass;
                        yield return method.AbstractServerStreamSyncRequestMethod;
                        foreach (var signature in method.SignaturesToGenerate)
                        {
                            yield return signature.AbstractServerStreamSyncRequestMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.AbstractServerStreamSyncRequestMethod;
                            }
                        }
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
                    case MethodDetails.Paginated _:
                        yield return method.ImplPaginatedSyncRequestMethod;
                        yield return method.ImplPaginatedAsyncCallSettingsRequestMethod;
                        break;
                    case MethodDetails.StandardLro _:
                        yield return method.ImplLroOperationsClientProperty;
                        yield return method.ImplStandardLroSyncRequestMethod;
                        yield return method.ImplStandardLroAsyncCallSettingsRequestMethod;
                        break;
                    case MethodDetails.NonStandardLro _:
                        yield return method.ImplLroOperationsClientProperty;
                        yield return method.ImplNonStandardLroSyncRequestMethod;
                        yield return method.ImplNonStandardLroAsyncCallSettingsRequestMethod;
                        break;
                    case MethodDetails.BidiStreaming _:
                        yield return method.ImplBidiStreamClass();
                        yield return method.ImplBidiStreamSyncRequestMethod();
                        break;
                    case MethodDetails.ClientStreaming _:
                        yield return method.ImplClientStreamClass();
                        yield return method.ImplClientStreamSyncRequestMethod();
                        break;
                    case MethodDetails.ServerStreaming _:
                        yield return method.ImplServerStreamClass();
                        yield return method.ImplServerStreamSyncRequestMethod;
                        break;
                }
            }
        }

        private partial class MethodDef
        {
            public MethodDef(SourceFileContext ctx, string ns, MethodDetails methodDetails) =>
                (Ctx, Namespace, MethodDetails) = (ctx, ns, methodDetails);

            public SourceFileContext Ctx { get; }
            public string Namespace { get; }

            public MethodDetails MethodDetails { get; }
            public MethodDetails.Paginated MethodDetailsPaginated => (MethodDetails.Paginated) MethodDetails;
            public MethodDetails.Lro MethodDetailsLro => (MethodDetails.Lro) MethodDetails;
            public MethodDetails.BidiStreaming MethodDetailsBidiStream => (MethodDetails.BidiStreaming) MethodDetails;
            public MethodDetails.ClientStreaming MethodDetailsClientStream => (MethodDetails.ClientStreaming) MethodDetails;
            public MethodDetails.ServerStreaming MethodDetailsServerStream => (MethodDetails.ServerStreaming) MethodDetails;

            private MethodDeclarationSyntax ModifyRequestMethod => ServiceImplClientClassGenerator.ModifyRequestPartialMethod(Ctx, MethodDetails);
            private FieldDeclarationSyntax ApiCallField => ServiceImplClientClassGenerator.ApiCallField(Ctx, MethodDetails);
            private MethodDeclarationSyntax ModifyBidiRequestCallSettingsPartialMethod => ServiceImplClientClassGenerator.ModifyBidiRequestCallSettingsPartialMethod(Ctx, MethodDetailsBidiStream);
            private MethodDeclarationSyntax ModifyClientRequestCallSettingsPartialMethod => ServiceImplClientClassGenerator.ModifyClientRequestCallSettingsPartialMethod(Ctx, MethodDetailsClientStream);

            private string ApiCallSyncName => nameof(ApiCall<ProtoMsg, ProtoMsg>.Sync);
            private string ApiCallAsyncName => nameof(ApiCall<ProtoMsg, ProtoMsg>.Async);

            private ParameterSyntax RequestParam => Parameter(Ctx.Type(MethodDetails.RequestTyp), "request");
            private ParameterSyntax CallSettingsParam => Parameter(Ctx.Type<CallSettings>(), "callSettings", @default: Null);
            private ParameterSyntax CancellationTokenParam => Parameter(Ctx.Type<CancellationToken>(), "cancellationToken");
            private ParameterSyntax OperationNameParam => Parameter(Ctx.Type<string>(), "operationName");
            private ParameterSyntax BidiStreamingSettingsParam => Parameter(Ctx.Type<BidirectionalStreamingSettings>(), "streamingSettings", @default: Null);
            private ParameterSyntax ClientStreamingSettingsParam => Parameter(Ctx.Type<ClientStreamingSettings>(), "streamingSettings", @default: Null);

            private DocumentationCommentTriviaSyntax SummaryXmlDoc => XmlDoc.SummaryPreFormatted(MethodDetails.DocLines);
            private DocumentationCommentTriviaSyntax RequestXmlDoc => XmlDoc.Param(RequestParam, "The request object containing all of the parameters for the API call.");
            private DocumentationCommentTriviaSyntax CallSettingsXmlDoc => XmlDoc.Param(CallSettingsParam, "If not null, applies overrides to this RPC call.");
            private DocumentationCommentTriviaSyntax CancellationTokenXmlDoc => XmlDoc.Param(CancellationTokenParam, "A ", Ctx.Type<CancellationToken>(), " to use for this RPC.");
            private DocumentationCommentTriviaSyntax ReturnsSyncXmlDoc => XmlDoc.Returns("The RPC response.");
            private DocumentationCommentTriviaSyntax ReturnsAsyncXmlDoc => XmlDoc.Returns("A Task containing the RPC response.");
            private DocumentationCommentTriviaSyntax ReturnsSyncPaginatedXmlDoc => XmlDoc.Returns("A pageable sequence of ", Ctx.Type(MethodDetailsPaginated.ResourceTypForCref), " resources.");
            private DocumentationCommentTriviaSyntax ReturnsAsyncPaginatedXmlDoc => XmlDoc.Returns("A pageable asynchronous sequence of ", Ctx.Type(MethodDetailsPaginated.ResourceTypForCref), " resources.");
            private DocumentationCommentTriviaSyntax OperationsSummaryXmlDoc => XmlDoc.Summary("The long-running operations client for ", XmlDoc.C(MethodDetails.SyncMethodName), ".");
            private DocumentationCommentTriviaSyntax OperationNameXmlDoc => XmlDoc.Param(OperationNameParam, "The name of a previously invoked operation. Must not be ", XmlDoc.C("null"), " or empty.");
            private DocumentationCommentTriviaSyntax BidiStreamingSettingsXmlDoc => XmlDoc.Param(BidiStreamingSettingsParam, "If not null, applies streaming overrides to this RPC call.");
            private DocumentationCommentTriviaSyntax ReturnsBidiStreamingXmlDoc => XmlDoc.Returns("The client-server stream.");
            private DocumentationCommentTriviaSyntax ReturnsServerStreamingXmlDoc => XmlDoc.Returns("The server stream.");
            private DocumentationCommentTriviaSyntax ClientStreamingSettingsXmlDoc => XmlDoc.Param(ClientStreamingSettingsParam, "If not null, applies streaming overrides to this RPC call.");
            private DocumentationCommentTriviaSyntax ReturnsClientStreamingXmlDoc => XmlDoc.Returns("The client stream.");

            // Base abstract members.

            public MethodDeclarationSyntax AbstractSyncRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, MethodDetails is MethodDetails.Paginated ? ReturnsSyncPaginatedXmlDoc : ReturnsSyncXmlDoc);

            public MethodDeclarationSyntax AbstractAsyncCallSettingsRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, MethodDetails is MethodDetails.Paginated ? ReturnsAsyncPaginatedXmlDoc : ReturnsAsyncXmlDoc);

            public MethodDeclarationSyntax AbstractAsyncCancellationTokenRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CancellationTokenParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(This.Call(AbstractAsyncCallSettingsRequestMethod)(RequestParam, Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(CancellationTokenParam)))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CancellationTokenXmlDoc, ReturnsAsyncXmlDoc);

            // Base impl members.

            public MethodDeclarationSyntax ImplSyncRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                        .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                        .WithBody(
                            AutoPopulateFields(RequestParam),
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            MethodDetails.SyncReturnTyp is Typ.VoidTyp ?
                                (object) ApiCallField.Call(ApiCallSyncName)(RequestParam, CallSettingsParam) :
                                Return(ApiCallField.Call(ApiCallSyncName)(RequestParam, CallSettingsParam)))
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsSyncXmlDoc);

            public MethodDeclarationSyntax ImplAsyncCallSettingsRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                        .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                        .WithBody(
                            AutoPopulateFields(RequestParam),
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            Return(ApiCallField.Call(ApiCallAsyncName)(RequestParam, CallSettingsParam)))
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsAsyncXmlDoc);

            // Paginated impl members.

            public MethodDeclarationSyntax ImplPaginatedSyncRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(
                        AutoPopulateFields(RequestParam),
                        This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                        Return(New(Ctx.Type(MethodDetailsPaginated.SyncGrpcType))(ApiCallField, RequestParam, CallSettingsParam)))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsSyncPaginatedXmlDoc);

            public MethodDeclarationSyntax ImplPaginatedAsyncCallSettingsRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(
                        AutoPopulateFields(RequestParam),
                        This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                        Return(New(Ctx.Type(MethodDetailsPaginated.AsyncGrpcType))(ApiCallField, RequestParam, CallSettingsParam)))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsAsyncPaginatedXmlDoc);

            // LRO abstract members.

            public PropertyDeclarationSyntax AbstractLroOperationsClientProperty =>
                Property(Public | Virtual, Ctx.Type<OperationsClient>(), MethodDetailsLro.LroClientName)
                    .WithGetBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(OperationsSummaryXmlDoc);

            public MethodDeclarationSyntax AbstractLroSyncPollMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetailsLro.SyncPollMethodName)(OperationNameParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(
                        Ctx.Type(MethodDetailsLro.OperationTyp).Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollOnceFromName))(
                            Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(OperationNameParam, Nameof(OperationNameParam)),
                            AbstractLroOperationsClientProperty, CallSettingsParam))
                    .WithXmlDoc(
                        XmlDoc.Summary("Poll an operation once, using an ", XmlDoc.C("operationName"), " from a previous invocation of ", XmlDoc.C(MethodDetails.SyncMethodName), "."),
                            OperationNameXmlDoc, CallSettingsXmlDoc, XmlDoc.Returns("The result of polling the operation."));

            public MethodDeclarationSyntax AbstractLroAsyncPollMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetailsLro.AsyncPollMethodName)(OperationNameParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(
                        Ctx.Type(MethodDetailsLro.OperationTyp).Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollOnceFromNameAsync))(
                            Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(OperationNameParam, Nameof(OperationNameParam)),
                            AbstractLroOperationsClientProperty, CallSettingsParam))
                    .WithXmlDoc(
                        XmlDoc.Summary("Asynchronously poll an operation once, using an ", XmlDoc.C("operationName"), " from a previous invocation of ", XmlDoc.C(MethodDetails.SyncMethodName), "."),
                            OperationNameXmlDoc, CallSettingsXmlDoc, XmlDoc.Returns("A task representing the result of polling the operation."));

            // LRO impl members.

            // Common LRO members
            public PropertyDeclarationSyntax ImplLroOperationsClientProperty =>
                AutoProperty(Public | Override, Ctx.Type<OperationsClient>(), MethodDetailsLro.LroClientName)
                    .WithXmlDoc(OperationsSummaryXmlDoc);

            // Standard LRO members
            public MethodDeclarationSyntax ImplStandardLroSyncRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                        .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                        .WithBody(
                            AutoPopulateFields(RequestParam),
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            Return(New(Ctx.Type(MethodDetailsLro.OperationTyp))(ApiCallField.Call(ApiCallSyncName)(RequestParam, CallSettingsParam), ImplLroOperationsClientProperty))
                        )
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsSyncXmlDoc);

            public MethodDeclarationSyntax ImplStandardLroAsyncCallSettingsRequestMethod =>
                Method(Public | Override | Async, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                        .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                        .WithBody(
                            AutoPopulateFields(RequestParam),
                            This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                            Return(New(Ctx.Type(MethodDetailsLro.OperationTyp))(Await(ApiCallField.Call(ApiCallAsyncName)(RequestParam, CallSettingsParam).ConfigureAwait()), ImplLroOperationsClientProperty))
                        )
                        .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsAsyncXmlDoc);

            // Non-standard LRO members
            public MethodDeclarationSyntax ImplNonStandardLroSyncRequestMethod
            {
                get
                {
                    var lro = (MethodDetails.NonStandardLro) MethodDetails;
                    var response = Local(Ctx.Type(lro.OperationServiceDetails.OperationTyp), "response");
                    var pollRequest = Local(Ctx.Type(lro.OperationServiceDetails.PollingRequestTyp), "pollRequest");
                    return Method(Public | Override, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                            .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                            .WithBody(
                                AutoPopulateFields(RequestParam),
                                This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                                response.WithInitializer(ApiCallField.Call(ApiCallSyncName)(RequestParam, CallSettingsParam)),
                                pollRequest.WithInitializer(Ctx.Type(lro.OperationServiceDetails.PollingRequestTyp).Call("FromInitialResponse")(response)),
                                RequestParam.Call("PopulatePollRequestFields")(pollRequest),
                                Return(New(Ctx.Type(MethodDetailsLro.OperationTyp))(response.Call("ToLroResponse")(pollRequest.Call("ToLroOperationName")()), ImplLroOperationsClientProperty))
                            )
                            .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsSyncXmlDoc);
                }
            }

            public MethodDeclarationSyntax ImplNonStandardLroAsyncCallSettingsRequestMethod
            {
                get
                {
                    var lro = (MethodDetails.NonStandardLro) MethodDetails;
                    var response = Local(Ctx.Type(lro.OperationServiceDetails.OperationTyp), "response");
                    var pollRequest = Local(Ctx.Type(lro.OperationServiceDetails.PollingRequestTyp), "pollRequest");
                    return Method(Public | Override | Async, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(RequestParam, CallSettingsParam)
                            .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                            .WithBody(
                                AutoPopulateFields(RequestParam),
                                This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                                response.WithInitializer(Await(ApiCallField.Call(ApiCallAsyncName)(RequestParam, CallSettingsParam).ConfigureAwait())),
                                pollRequest.WithInitializer(Ctx.Type(lro.OperationServiceDetails.PollingRequestTyp).Call("FromInitialResponse")(response)),
                                RequestParam.Call("PopulatePollRequestFields")(pollRequest),
                                Return(New(Ctx.Type(MethodDetailsLro.OperationTyp))(response.Call("ToLroResponse")(pollRequest.Call("ToLroOperationName")()), ImplLroOperationsClientProperty))
                            )
                            .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsAsyncXmlDoc);
                }
            }

            // Bidi streaming abstract members.

            public ClassDeclarationSyntax AbstractBidiStreamClass =>
                Class(Public | Abstract | Partial, MethodDetailsBidiStream.AbstractStreamTyp, baseTypes: Ctx.Type(Typ.Generic(typeof(BidirectionalStreamingBase<,>), MethodDetails.RequestTyp, MethodDetails.ResponseTyp)))
                    .WithXmlDoc(XmlDoc.Summary("Bidirectional streaming methods for ", AbstractBidiStreamSyncRequestMethod, "."));

            public MethodDeclarationSyntax AbstractBidiStreamSyncRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetailsBidiStream.AbstractStreamTyp), MethodDetails.SyncMethodName)(CallSettingsParam, BidiStreamingSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(SummaryXmlDoc, CallSettingsXmlDoc, BidiStreamingSettingsXmlDoc, ReturnsBidiStreamingXmlDoc);

            // Bidi streaming impl members.

            public ClassDeclarationSyntax ImplBidiStreamClass()
            {
                var cls = Class(Internal | Sealed | Partial, MethodDetailsBidiStream.ImplStreamTyp, baseTypes: Ctx.Type(Typ.Manual(Namespace, AbstractBidiStreamClass)));
                var serviceTyp = Ctx.CurrentTyp;
                var serviceField = Field(Private, Ctx.Type(serviceTyp), "_service");
                var writeBufferType = Typ.Generic(typeof(BufferedClientStreamWriter<>), MethodDetails.RequestTyp);
                var writeBufferField = Field(Private, Ctx.Type(writeBufferType), "_writeBuffer");
                var grpcCallType = Typ.Generic(typeof(AsyncDuplexStreamingCall<,>), MethodDetails.RequestTyp, MethodDetails.ResponseTyp);
                var grpcCallName = nameof(BidirectionalStreamingBase<ProtoMsg, ProtoMsg>.GrpcCall);
                var grpcCallProperty = AutoProperty(Public | Override, Ctx.Type(grpcCallType), grpcCallName);
                var modifyRequestMethod = ModifyRequest();
                var messageParam = Parameter(Ctx.Type(MethodDetails.RequestTyp), "message");
                var optionsParam = Parameter(Ctx.Type<WriteOptions>(), "options");
                using (Ctx.InClass(cls))
                {
                    cls = cls.AddMembers(
                        Constructor(),
                        serviceField, writeBufferField,
                        grpcCallProperty,
                        modifyRequestMethod,
                        TryWriteAsync1(), WriteAsync1(),
                        TryWriteAsync2(), WriteAsync2(),
                        TryWriteCompleteAsync(), WriteCompleteAsync());
                }
                return cls;

                ConstructorDeclarationSyntax Constructor()
                {
                    var serviceParam = Parameter(Ctx.Type(serviceTyp), "service");
                    var callParam = Parameter(Ctx.Type(grpcCallType), "call");
                    var writeBufferParam = Parameter(Ctx.Type(writeBufferType), "writeBuffer");
                    return Ctor(Public, cls)(serviceParam, callParam, writeBufferParam)
                        .WithBody(
                            serviceField.Assign(serviceParam),
                            grpcCallProperty.Assign(callParam),
                            writeBufferField.Assign(writeBufferParam))
                        .WithXmlDoc(
                            XmlDoc.Summary("Construct the bidirectional streaming method for ", XmlDoc.C(MethodDetails.SyncMethodName), "."),
                            XmlDoc.Param(serviceParam, "The service containing this streaming method."),
                            XmlDoc.Param(callParam, "The underlying gRPC duplex streaming call."),
                            XmlDoc.Param(writeBufferParam, "The ", Ctx.Type(writeBufferType), " instance associated with this streaming call.")
                        );
                }

                MethodDeclarationSyntax ModifyRequest()
                {
                    var requestParam = Parameter(Ctx.Type(MethodDetails.RequestTyp), "request");
                    return Method(Private, Ctx.Type(MethodDetails.RequestTyp), "ModifyRequest")(requestParam)
                        .WithBody(
                            AutoPopulateFields(requestParam),
                            serviceField.Call(MethodDetailsBidiStream.ModifyStreamingRequestMethodName)(Ref(requestParam)),
                            Return(requestParam)
                        );
                }

                MethodDeclarationSyntax TryWriteAsync1() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(BidirectionalStreamingBase<ProtoMsg, ProtoMsg>.TryWriteAsync))(messageParam)
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.TryWriteAsync))(This.Call(modifyRequestMethod)(messageParam)));

                MethodDeclarationSyntax WriteAsync1() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(BidirectionalStreamingBase<ProtoMsg, ProtoMsg>.WriteAsync))(messageParam)
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.WriteAsync))(This.Call(modifyRequestMethod)(messageParam)));

                MethodDeclarationSyntax TryWriteAsync2() =>
                    RoslynBuilder.Method(Public | Override, Ctx.Type<Task>(), nameof(BidirectionalStreamingBase<ProtoMsg, ProtoMsg>.TryWriteAsync))(messageParam, optionsParam)
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.TryWriteAsync))(This.Call(modifyRequestMethod)(messageParam), optionsParam));

                MethodDeclarationSyntax WriteAsync2() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(BidirectionalStreamingBase<ProtoMsg, ProtoMsg>.WriteAsync))(messageParam, optionsParam)
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.WriteAsync))(This.Call(modifyRequestMethod)(messageParam), optionsParam));

                MethodDeclarationSyntax TryWriteCompleteAsync() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(BidirectionalStreamingBase<ProtoMsg, ProtoMsg>.TryWriteCompleteAsync))()
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.TryWriteCompleteAsync))());

                MethodDeclarationSyntax WriteCompleteAsync() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(BidirectionalStreamingBase<ProtoMsg, ProtoMsg>.WriteCompleteAsync))()
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.WriteCompleteAsync))());
            }

            public MethodDeclarationSyntax ImplBidiStreamSyncRequestMethod()
            {
                var effectiveStreamingSettings = Local(Ctx.Type<BidirectionalStreamingSettings>(), "effectiveStreamingSettings");
                var streamingSettingsName = nameof(ApiBidirectionalStreamingCall<ProtoMsg, ProtoMsg>.StreamingSettings);
                var call = Local(Ctx.Type(Typ.Generic(typeof(AsyncDuplexStreamingCall<,>), MethodDetails.RequestTyp, MethodDetails.ResponseTyp)), "call");
                var writeBufferType = Typ.Generic(typeof(BufferedClientStreamWriter<>), MethodDetails.RequestTyp);
                var writeBuffer = Local(Ctx.Type(writeBufferType), "writeBuffer");
                var requestStreamName = nameof(AsyncDuplexStreamingCall<ProtoMsg, ProtoMsg>.RequestStream);
                var bufferedClientWriterCapacityName = nameof(BidirectionalStreamingSettings.BufferedClientWriterCapacity);
                return Method(Public | Override, Ctx.Type(MethodDetailsBidiStream.AbstractStreamTyp), MethodDetails.SyncMethodName)(CallSettingsParam, BidiStreamingSettingsParam)
                    .WithBody(
                        This.Call(ModifyBidiRequestCallSettingsPartialMethod)(Ref(CallSettingsParam)),
                        effectiveStreamingSettings.WithInitializer(BidiStreamingSettingsParam.NullCoalesce(ApiCallField.Access(streamingSettingsName))),
                        call.WithInitializer(ApiCallField.Call(nameof(ApiBidirectionalStreamingCall<ProtoMsg, ProtoMsg>.Call))(CallSettingsParam)),
                        writeBuffer.WithInitializer(New(Ctx.Type(writeBufferType))(call.Access(requestStreamName), effectiveStreamingSettings.Access(bufferedClientWriterCapacityName))),
                        Return(New(Ctx.Type(MethodDetailsBidiStream.ImplStreamTyp))(This, call, writeBuffer))
                    )
                    .WithXmlDoc(SummaryXmlDoc, CallSettingsXmlDoc, BidiStreamingSettingsXmlDoc, ReturnsBidiStreamingXmlDoc);
            }

            // Server streaming abstract members.

            public ClassDeclarationSyntax AbstractServerStreamClass =>
                Class(Public | Abstract | Partial, MethodDetailsServerStream.AbstractStreamTyp, baseTypes: Ctx.Type(Typ.Generic(typeof(ServerStreamingBase<>), MethodDetails.ResponseTyp)))
                    .WithXmlDoc(XmlDoc.Summary("Server streaming methods for ", AbstractServerStreamSyncRequestMethod, "."));

            public MethodDeclarationSyntax AbstractServerStreamSyncRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetailsServerStream.AbstractStreamTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsServerStreamingXmlDoc);

            // Server streaming impl members.

            public ClassDeclarationSyntax ImplServerStreamClass()
            {
                var cls = Class(Internal | Sealed | Partial, MethodDetailsServerStream.ImplStreamTyp, baseTypes: Ctx.Type(Typ.Manual(Namespace, AbstractServerStreamClass)));
                var grpcCallType = Typ.Generic(typeof(AsyncServerStreamingCall<>), MethodDetails.ResponseTyp);
                var grpcCallName = nameof(ServerStreamingBase<ProtoMsg>.GrpcCall);
                var grpcCallProperty = AutoProperty(Public | Override, Ctx.Type(grpcCallType), grpcCallName);
                using (Ctx.InClass(cls))
                {
                    cls = cls.AddMembers(
                        Constructor(),
                        grpcCallProperty);
                }
                return cls;

                ConstructorDeclarationSyntax Constructor()
                {
                    var callParam = Parameter(Ctx.Type(grpcCallType), "call");
                    return Ctor(Public, cls)(callParam)
                        .WithBody(grpcCallProperty.Assign(callParam))
                        .WithXmlDoc(
                            XmlDoc.Summary("Construct the server streaming method for ", XmlDoc.C(MethodDetails.SyncMethodName), "."),
                            XmlDoc.Param(callParam, "The underlying gRPC server streaming call."));
                }
            }

            public MethodDeclarationSyntax ImplServerStreamSyncRequestMethod =>
                Method(Public | Override, Ctx.Type(MethodDetailsServerStream.AbstractStreamTyp), MethodDetails.SyncMethodName)(RequestParam, CallSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(
                        AutoPopulateFields(RequestParam),
                        This.Call(ModifyRequestMethod)(Ref(RequestParam), Ref(CallSettingsParam)),
                        Return(New(Ctx.Type(MethodDetailsServerStream.ImplStreamTyp))(ApiCallField.Call(nameof(ApiServerStreamingCall<ProtoMsg, ProtoMsg>.Call))(RequestParam, CallSettingsParam))))
                    .WithXmlDoc(SummaryXmlDoc, RequestXmlDoc, CallSettingsXmlDoc, ReturnsServerStreamingXmlDoc);

            public ClassDeclarationSyntax AbstractClientStreamClass =>
                Class(Public | Abstract | Partial, MethodDetailsClientStream.AbstractStreamTyp, baseTypes: Ctx.Type(Typ.Generic(typeof(ClientStreamingBase<,>),MethodDetails.RequestTyp, MethodDetails.ResponseTyp)))
                    .WithXmlDoc(XmlDoc.Summary("Client streaming methods for ", AbstractClientStreamSyncRequestMethod, "."));
            public MethodDeclarationSyntax AbstractClientStreamSyncRequestMethod =>
                Method(Public | Virtual, Ctx.Type(MethodDetailsClientStream.AbstractStreamTyp), MethodDetails.SyncMethodName)(CallSettingsParam, ClientStreamingSettingsParam)
                    .MaybeWithAttribute(MethodDetails.IsDeprecated, () => Ctx.Type<ObsoleteAttribute>())()
                    .WithBody(Throw(New(Ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(SummaryXmlDoc, CallSettingsXmlDoc, ClientStreamingSettingsXmlDoc, ReturnsClientStreamingXmlDoc);

            // Common helper methods
            IEnumerable AutoPopulateFields(ParameterSyntax requestParameter)
            {
                var requestDescriptor = MethodDetails.RequestMessageDesc;
                foreach (var fieldName in MethodDetails.ServiceConfigMethodSettings.AutoPopulatedFields)
                {
                    var field = requestDescriptor.FindFieldByName(fieldName);
                    if (field is null)
                    {
                        throw new ArgumentException($"Invalid method settings: field '{fieldName}' not found in '{requestDescriptor.FullName}'");
                    }
                    if (field.FieldType != FieldType.String)
                    {
                        throw new ArgumentException($"Invalid method settings: field '{fieldName}' in '{requestDescriptor.FullName}' is not a string");
                    }
                    if (field.IsMap || field.IsRepeated)
                    {
                        throw new ArgumentException($"Invalid method settings: field '{fieldName}' in '{requestDescriptor.FullName}' is not singular");
                    }
                    if (field.GetExtension(FieldInfoExtensions.FieldInfo) is not FieldInfo fieldInfo)
                    {
                        throw new ArgumentException($"Invalid method settings: field '{fieldName}' in '{requestDescriptor.FullName}' has no FieldInfo annotation");
                    }
                    if (fieldInfo.Format != FieldInfo.Types.Format.Uuid4)
                    {
                        throw new ArgumentException($"Invalid method settings: field '{fieldName}' in '{requestDescriptor.FullName}' has unsupported format {fieldInfo.Format}");
                    }

                    yield return If(requestParameter.Access(field.CSharpPropertyName()).EqualTo(""))
                        .Then(
                            requestParameter.Assign(requestParameter.Call("Clone")()),
                            requestParameter.Access(field.CSharpPropertyName()).Assign(Ctx.Type(typeof(FieldFormats)).Call(nameof(FieldFormats.GenerateUuid4))()));                        
                }
            }

            public ClassDeclarationSyntax ImplClientStreamClass()
            {
                var cls = Class(Internal | Sealed | Partial, MethodDetailsClientStream.ImplStreamTyp,
                    Ctx.Type(Typ.Manual(Namespace, AbstractClientStreamClass)));

                var serviceType = Ctx.CurrentType;
                var serviceField = Field(Private, serviceType, "_service");
                var writeBufferType = Ctx.Type(Typ.Generic(typeof(BufferedClientStreamWriter<>), MethodDetails.RequestTyp));
                var writeBufferField = Field(Private, writeBufferType, "_writeBuffer");
                var grpcCallType = Ctx.Type(Typ.Generic(typeof(AsyncClientStreamingCall<,>), MethodDetails.RequestTyp,
                    MethodDetails.ResponseTyp));
                var grpcCallName = nameof(ClientStreamingBase<ProtoMsg, ProtoMsg>.GrpcCall);
                var grpcCallProperty = AutoProperty(Public | Override, grpcCallType, grpcCallName);
                var modifyRequestMethod = ModifyRequest();
                var messageParam = Parameter(Ctx.Type(MethodDetails.RequestTyp), "message");
                var optionsParam = Parameter(Ctx.Type<WriteOptions>(), "options");
                using (Ctx.InClass(cls))
                {
                    cls = cls.AddMembers(
                        Constructor(),
                        serviceField, writeBufferField,
                        grpcCallProperty,
                        modifyRequestMethod,
                        TryWriteAsync(), WriteAsync(),
                        TryWriteAsyncWithOptions(), WriteAsyncWithOptions(),
                        TryWriteCompleteAsync(), WriteCompleteAsync()
                    );
                }

                return cls;

                ConstructorDeclarationSyntax Constructor()
                {
                    var serviceParam = Parameter(serviceType, "service");
                    var callParam = Parameter(grpcCallType, "call");
                    var writeBufferParam = Parameter(writeBufferType, "writeBuffer");
                    return Ctor(Public, cls)(serviceParam, callParam, writeBufferParam)
                        .WithBody(
                            serviceField.Assign(serviceParam),
                            grpcCallProperty.Assign(callParam),
                            writeBufferField.Assign(writeBufferParam))
                        .WithXmlDoc(
                            XmlDoc.Summary("Construct the client streaming method for ", XmlDoc.C(MethodDetails.SyncMethodName), "."),
                            XmlDoc.Param(serviceParam, "The service containing this streaming method."),
                            XmlDoc.Param(callParam, "The underlying gRPC client streaming call."),
                            XmlDoc.Param(writeBufferParam, "The ", writeBufferType, " instance associated with this streaming call.")
                        );
                }
                
                MethodDeclarationSyntax ModifyRequest()
                {
                    var requestParam = Parameter(Ctx.Type(MethodDetails.RequestTyp), "request");
                    return Method(Private, Ctx.Type(MethodDetails.RequestTyp), "ModifyRequest")(requestParam)
                        .WithBody(
                            AutoPopulateFields(requestParam),
                            serviceField.Call(MethodDetailsClientStream.ModifyStreamingRequestMethodName)(Ref(requestParam)),
                            Return(requestParam)
                        );
                }

                MethodDeclarationSyntax TryWriteAsync() => 
                Method(Public | Override, Ctx.Type<Task>(), nameof (ClientStreamingBase<ProtoMsg, ProtoMsg>.TryWriteAsync))(messageParam)
                    .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.TryWriteAsync))(This.Call(modifyRequestMethod)(messageParam)));

                MethodDeclarationSyntax WriteAsync() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(ClientStreamingBase<ProtoMsg, ProtoMsg>.WriteAsync))(messageParam)
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.WriteAsync))(This.Call(modifyRequestMethod)(messageParam)));
                
                MethodDeclarationSyntax TryWriteAsyncWithOptions() => 
                    Method(Public | Override, Ctx.Type<Task>(), nameof (ClientStreamingBase<ProtoMsg, ProtoMsg>.TryWriteAsync))(messageParam, optionsParam)
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.TryWriteAsync))(This.Call(modifyRequestMethod)(messageParam), optionsParam));

                MethodDeclarationSyntax WriteAsyncWithOptions() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(ClientStreamingBase<ProtoMsg, ProtoMsg>.WriteAsync))(messageParam, optionsParam)
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.WriteAsync))(This.Call(modifyRequestMethod)(messageParam), optionsParam));

                MethodDeclarationSyntax TryWriteCompleteAsync() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(ClientStreamingBase<ProtoMsg, ProtoMsg>.TryWriteCompleteAsync))()
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.TryWriteCompleteAsync))());

                MethodDeclarationSyntax WriteCompleteAsync() =>
                    Method(Public | Override, Ctx.Type<Task>(), nameof(ClientStreamingBase<ProtoMsg, ProtoMsg>.WriteCompleteAsync))()
                        .WithBody(writeBufferField.Call(nameof(BufferedClientStreamWriter<ProtoMsg>.WriteCompleteAsync))());
            }

            public MethodDeclarationSyntax ImplClientStreamSyncRequestMethod()
            {
                var effectiveStreamingSettings = Local(Ctx.Type<ClientStreamingSettings>(), "effectiveStreamingSettings");
                var streamingSettingsName = nameof(ApiClientStreamingCall<ProtoMsg, ProtoMsg>.StreamingSettings);
                var call = Local(Ctx.Type(Typ.Generic(typeof(AsyncClientStreamingCall<,>), MethodDetails.RequestTyp, MethodDetails.ResponseTyp)), "call");
                var writeBufferType = Typ.Generic(typeof(BufferedClientStreamWriter<>), MethodDetails.RequestTyp);
                var writeBuffer = Local(Ctx.Type(writeBufferType), "writeBuffer");
                var requestStreamName = nameof(AsyncClientStreamingCall<ProtoMsg, ProtoMsg>.RequestStream);
                var bufferedClientWriterCapacityName = nameof(ClientStreamingSettings.BufferedClientWriterCapacity);
                return Method(Public | Override, Ctx.Type(MethodDetailsClientStream.AbstractStreamTyp), MethodDetails.SyncMethodName)(CallSettingsParam, ClientStreamingSettingsParam)
                    .WithBody(
                        This.Call(ModifyClientRequestCallSettingsPartialMethod)(Ref(CallSettingsParam)),
                        effectiveStreamingSettings.WithInitializer(ClientStreamingSettingsParam.NullCoalesce(ApiCallField.Access(streamingSettingsName))),
                        call.WithInitializer(ApiCallField.Call(nameof(ApiClientStreamingCall<ProtoMsg, ProtoMsg>.Call))(CallSettingsParam)),
                        writeBuffer.WithInitializer(New(Ctx.Type(writeBufferType))(call.Access(requestStreamName), effectiveStreamingSettings.Access(bufferedClientWriterCapacityName))),
                        Return(New(Ctx.Type(MethodDetailsClientStream.ImplStreamTyp))(This, call, writeBuffer))
                    )
                    .WithXmlDoc(SummaryXmlDoc, CallSettingsXmlDoc, ClientStreamingSettingsXmlDoc, ReturnsClientStreamingXmlDoc);
            }
        }
    }
}
