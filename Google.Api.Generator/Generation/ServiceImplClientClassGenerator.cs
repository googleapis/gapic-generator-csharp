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

using Google.Api.Gax.Grpc;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Api.Generator.Utils;
using Google.LongRunning;
using Google.Protobuf;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using Microsoft.CodeAnalysis.CSharp;
using Google.Protobuf.Reflection;

namespace Google.Api.Generator.Generation
{
    internal class ServiceImplClientClassGenerator
    {
        public static ClassDeclarationSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new ServiceImplClientClassGenerator(ctx, svc).Generate();

        public static FieldDeclarationSyntax ApiCallField(SourceFileContext ctx, MethodDetails method) =>
            Field(Private | Readonly, ctx.Type(method.ApiCallTyp), method.ApiCallFieldName);

        public static MethodDeclarationSyntax ModifyRequestPartialMethod(SourceFileContext ctx, MethodDetails method)
        {
            var requestParam = Parameter(ctx.Type(method.RequestTyp), "request").Ref();
            var settingsParam = Parameter(ctx.Type<CallSettings>(), "settings").Ref();
            return PartialMethod(method.ModifyRequestMethodName)(requestParam, settingsParam);
        }

        public static MethodDeclarationSyntax ModifyBidiRequestCallSettingsPartialMethod(SourceFileContext ctx, MethodDetails.BidiStreaming method)
        {
            var settingsParam = Parameter(ctx.Type<CallSettings>(), "settings").Ref();
            return PartialMethod(method.ModifyStreamingCallSettingsMethodName)(settingsParam);
        }

        public static MethodDeclarationSyntax ModifyClientRequestCallSettingsPartialMethod(SourceFileContext ctx, MethodDetails.ClientStreaming method)
        {
            var settingsParam = Parameter(ctx.Type<CallSettings>(), "settings").Ref();
            return PartialMethod(method.ModifyStreamingCallSettingsMethodName)(settingsParam);
        }

        private ServiceImplClientClassGenerator(SourceFileContext ctx, ServiceDetails svc) =>
            (_ctx, _svc) = (ctx, svc);

        private readonly ServiceDetails _svc;
        private readonly SourceFileContext _ctx;

        private ClassDeclarationSyntax Generate()
        {
            var cls = Class(Public | Sealed | Partial, _svc.ClientImplTyp, baseTypes: _ctx.Type(_svc.ClientAbstractTyp))
                .WithXmlDoc(
                    XmlDoc.Summary($"{_svc.DocumentationName} client wrapper implementation, for convenient use."),
                    XmlDoc.RemarksPreFormatted(_svc.DocLines));
            using (_ctx.InClass(cls))
            {
                var apiCallFields = ApiCallFields().ToArray();
                var grpcClient = GrpcClient();
                var modifyApiCallGeneric = ModifyApiCallGenericPartialMethods().ToArray();
                var modifyApiCallPerMethod = ModifyPerMethodApiCallPartialMethods().ToArray();
                var onCtor = OnConstruction();
                var ctor = CtorGrpcClient(grpcClient, onCtor, modifyApiCallGeneric.First());
                var mixIns = Mixins().ToArray();
                var modifyRequestMethods = ModifyRequestMethods().ToArray();
                cls = cls.AddMembers(apiCallFields);
                cls = cls.AddMembers(ctor);
                cls = cls.AddMembers(modifyApiCallGeneric);
                cls = cls.AddMembers(modifyApiCallPerMethod);
                cls = cls.AddMembers(onCtor, grpcClient);
                cls = cls.AddMembers(mixIns);
                cls = cls.AddMembers(modifyRequestMethods);
                var methods = ServiceMethodGenerator.Generate(_ctx, _svc, inAbstract: false);
                cls = cls.AddMembers(methods.ToArray());
            }
            return cls;
        }

        private IEnumerable<FieldDeclarationSyntax> ApiCallFields() => _svc.Methods.Select(m => ApiCallField(_ctx, m));

        private MemberDeclarationSyntax CtorGrpcClient(PropertyDeclarationSyntax grpcClientProperty, MethodDeclarationSyntax onCtor, MethodDeclarationSyntax modifyApiCall)
        {
            var grpcClient = Parameter(_ctx.Type(_svc.GrpcClientTyp), "grpcClient");
            var settings = Parameter(_ctx.Type(_svc.SettingsTyp), "settings");
            var effectiveSettings = Local(_ctx.Type(_svc.SettingsTyp), "effectiveSettings");
            var clientHelper = Local(_ctx.Type<ClientHelper>(), "clientHelper");
            return Ctor(Public, _ctx.CurrentTyp)(grpcClient, settings)
                .WithBody(
                    grpcClientProperty.Assign(grpcClient),
                    effectiveSettings.WithInitializer(settings.NullCoalesce(_ctx.Type(_svc.SettingsTyp).Call("GetDefault")())),
                    clientHelper.WithInitializer(New(_ctx.Type<ClientHelper>())(effectiveSettings)),
                    _svc.Methods.OfType<MethodDetails.StandardLro>().Select(StandardLroClient),
                    _svc.Methods.OfType<MethodDetails.NonStandardLro>().Select(NonStandardLroClient),
                    _svc.Mixins.Select(MixinClient),
                    _svc.Methods.SelectMany(PerMethod),
                    This.Call(onCtor)(grpcClient, effectiveSettings, clientHelper)
                )
                .WithXmlDoc(
                    XmlDoc.Summary($"Constructs a client wrapper for the {_svc.DocumentationName} service, with the specified gRPC client and settings."),
                    XmlDoc.Param(grpcClient, "The underlying gRPC client."),
                    XmlDoc.Param(settings, "The base ", _ctx.Type(_svc.SettingsTyp), " used within this client.")
                );

            SyntaxNode StandardLroClient(MethodDetails.StandardLro lro)
            {
                var lroOperationsClientProperty = Property(Public, _ctx.Type<OperationsClient>(), lro.LroClientName);
                return lroOperationsClientProperty.Assign(New(_ctx.Type<OperationsClientImpl>())(
                    grpcClient.Call("CreateOperationsClient")(), effectiveSettings.Access(lro.LroSettingsName)));
            }

            SyntaxNode NonStandardLroClient(MethodDetails.NonStandardLro lro)
            {
                var lroOperationsClientProperty = Property(Public, _ctx.Type<OperationsClient>(), lro.LroClientName);
                return lroOperationsClientProperty.Assign(New(_ctx.Type<OperationsClientImpl>())(
                    grpcClient.Call($"CreateOperationsClientFor{lro.OperationService}")(), effectiveSettings.Access(lro.LroSettingsName)));
            }

            SyntaxNode MixinClient(ServiceDetails.MixinDetails mixin)
            {
                var mixinClientProperty = Property(Public, _ctx.Type(mixin.GapicClientType), mixin.GapicClientType.Name);
                return mixinClientProperty.Assign(New(_ctx.Type(mixin.GapicClientImplType))(
                    grpcClient.Call("Create" + mixin.GrpcClientType.Name)(), effectiveSettings.Access(mixin.GapicSettingsType.Name)));
            }

            IEnumerable<SyntaxNode> PerMethod(MethodDetails method)
            {
                var apiCallField = ApiCallField(_ctx, method);
                // Initialize ApiCall field.
                switch (method)
                {
                    case MethodDetails.BidiStreaming methodBidi:
                        var fieldInitBidi = clientHelper.MaybeObsoleteCall(nameof(ClientHelper.BuildApiCall), method.IsDeprecated, _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName), effectiveSettings.Access(methodBidi.StreamingSettingsName));
                        yield return apiCallField.Assign(fieldInitBidi);
                        break;
                    case MethodDetails.ServerStreaming _:
                        var fieldInitServer = clientHelper.MaybeObsoleteCall(nameof(ClientHelper.BuildApiCall), method.IsDeprecated, _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName));
                        yield return apiCallField.Assign(WithGoogleRequestParams(fieldInitServer));
                        break;
                    case MethodDetails.ClientStreaming methodClient:
                        var fieldInitClient = clientHelper.MaybeObsoleteCall(nameof(ClientHelper.BuildApiCall), method.IsDeprecated, _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName), effectiveSettings.Access(methodClient.StreamingSettingsName));
                        yield return field.Assign(fieldInitClient);
                        break;
                    case MethodDetails.ServerStreaming _:
                        var fieldInitServer = clientHelper.MaybeObsoleteCall(nameof(ClientHelper.BuildApiCall), method.IsDeprecated, _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName));
                        yield return field.Assign(WithGoogleRequestParams(fieldInitServer));
                        break;
                    default:
                        var fieldInit = clientHelper.MaybeObsoleteCall(nameof(ClientHelper.BuildApiCall), method.IsDeprecated, _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.AsyncMethodName), grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName));
                        yield return apiCallField.Assign(WithGoogleRequestParams(fieldInit));
                        break;
                }
                // Call modify partial methods.
                yield return This.Call(modifyApiCall)(Ref(apiCallField));
                yield return This.Call(method.ModifyApiCallMethodName)(Ref(apiCallField));

                InvocationExpressionSyntax WithGoogleRequestParams(InvocationExpressionSyntax fieldInitializer)
                {
                    var request = Parameter(_ctx.Type(method.RequestTyp), "request");
                    if (method.RoutingHeaders.All(header => header.Type == MethodDetails.RoutingHeader.HeaderType.Implicit))
                    {
                        // This is backwards-compatible with how C# generated implicit headers --
                        // `WithGoogleRequestParam` call per parameter, ending up with several
                        // `x-goog-request-params` headers in the Metadata
                        // TODO [virost, 2022-01] figure out what GRPC does with multiple headers in the metadata. Does it `&`-merge them correctly?
                        foreach (var routingHeader in method.RoutingHeaders)
                        {
                            var extraction = routingHeader.Extractions.Single();
                            var access = FullFieldAccess(extraction.Fields);

                            // Note: the name "WithGoogleRequestParam" is the same across ApiCall and ApiServerStreamingCall,
                            // so we don't need to distinguish between them here.
                            fieldInitializer = fieldInitializer.Call(nameof(ApiCall<ProtoMsg, ProtoMsg>.WithGoogleRequestParam))(
                                routingHeader.EncodedName, Lambda(request)(access));
                        }
                    }
                    else if (method.RoutingHeaders.Count() == 1 && method.RoutingHeaders.Single() is MethodDetails.RoutingHeader { FullFieldNoRegex: true } singleHeader)
                    {
                        // This is to simplify for when there is just one explicit header without any regex specified
                        var access = FullFieldAccess(singleHeader.Extractions.Single().Fields);

                        // Note: the name "WithGoogleRequestParam" is the same across ApiCall and ApiServerStreamingCall,
                        // so we don't need to distinguish between them here.
                        fieldInitializer = fieldInitializer.Call(nameof(ApiCall<ProtoMsg, ProtoMsg>.WithGoogleRequestParam))(
                            singleHeader.EncodedName, Lambda(request)(access));
                    }
                    else if (method.RoutingHeaders.Any())
                    {
                        // This is the code path for generating the code for the explicit headers.

                        // A small safeguard in case the parsing code changes
                        if (method.RoutingHeaders.Any(rh => rh.Type == MethodDetails.RoutingHeader.HeaderType.Implicit))
                        {
                            throw new InvalidOperationException("Generating a mix of implicit and explicit headers is not supported");
                        }

                        var extractorType = _ctx.Type(Typ.Generic(typeof(RoutingHeaderExtractor<>), method.RequestTyp));
                        ExpressionSyntax extractorSyntax = New(extractorType)();

                        foreach (var header in method.RoutingHeaders.Where(rh => rh.Type == MethodDetails.RoutingHeader.HeaderType.Explicit))
                        {
                            foreach (var extraction in header.Extractions)
                            {
                                var access = FullFieldAccess(extraction.Fields);
                                extractorSyntax =
                                    extractorSyntax.Call(nameof(RoutingHeaderExtractor<ProtoMsg>
                                        .WithExtractedParameter))(header.EncodedName, extraction.RegexStr,
                                        Lambda(request)(access));
                            }
                        }

                        // Note: the name "WithExtractedGoogleRequestParam" is the same across ApiCall and ApiServerStreamingCall,
                        // so we don't need to distinguish between them here.
                        fieldInitializer = fieldInitializer.Call(nameof(ApiCall<ProtoMsg, ProtoMsg>.WithExtractedGoogleRequestParam))(extractorSyntax);
                    }
                    
                    return fieldInitializer;
                    
                    ExpressionSyntax FullFieldAccess(IEnumerable<FieldDescriptor> extractionFields)
                    {  
                        var access = request.Access(FieldAccess(extractionFields.First()));
                        foreach (var field in extractionFields.Skip(1))
                        {
                            access = access.Access(FieldAccess(field), conditional: true);
                        }

                        return access;
                    }

                    // Returns a simple name to access a field, adding an pragma to disable obsolete warnings if necessary.
                    SimpleNameSyntax FieldAccess(FieldDescriptor field) =>
                        SyntaxFactory.IdentifierName(field.CSharpPropertyName()).MaybeWithPragmaDisableObsoleteWarning(field.IsDeprecated());
                }
            }
        }

        private PropertyDeclarationSyntax GrpcClient() =>
            AutoProperty(Public | Override, _ctx.Type(_svc.GrpcClientTyp), "GrpcClient")
                .WithXmlDoc(XmlDoc.Summary("The underlying gRPC ", _svc.DocumentationName, " client"));
        private IEnumerable<PropertyDeclarationSyntax> Mixins() =>
            _svc.Mixins.Select(mixin =>
                AutoProperty(Public | Override, _ctx.Type(mixin.GapicClientType), mixin.GapicClientType.Name)
                    .WithXmlDoc(XmlDoc.Summary("The ", _ctx.Type(mixin.GapicClientType), " associated with this client.")));

        private IEnumerable<MethodDeclarationSyntax> ModifyApiCallGenericPartialMethods()
        {
            var tRequest = Typ.GenericParam("TRequest");
            var tResponse = Typ.GenericParam("TResponse");
            var call = Parameter(_ctx.Type(Typ.Generic(typeof(ApiCall<,>), tRequest, tResponse)), "call").Ref();
            yield return PartialMethod("Modify_ApiCall", tRequest, tResponse)(call)
                .AddGenericConstraint(tRequest, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tRequest)))
                .AddGenericConstraint(tResponse, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tResponse)));
            if (_svc.Methods.Any(m => m is MethodDetails.BidiStreaming))
            {
                var callBidiStreaming = Parameter(_ctx.Type(Typ.Generic(typeof(ApiBidirectionalStreamingCall<,>), tRequest, tResponse)), "call").Ref();
                yield return PartialMethod("Modify_ApiCall", tRequest, tResponse)(callBidiStreaming)
                    .AddGenericConstraint(tRequest, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tRequest)))
                    .AddGenericConstraint(tResponse, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tResponse)));
            }
            if (_svc.Methods.Any(m => m is MethodDetails.ServerStreaming))
            {
                var callServerStreaming = Parameter(_ctx.Type(Typ.Generic(typeof(ApiServerStreamingCall<,>), tRequest, tResponse)), "call").Ref();
                yield return PartialMethod("Modify_ApiCall", tRequest, tResponse)(callServerStreaming)
                    .AddGenericConstraint(tRequest, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tRequest)))
                    .AddGenericConstraint(tResponse, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tResponse)));
            }
            if (_svc.Methods.Any(m => m is MethodDetails.ClientStreaming))
            {
                var callClientStreaming = Parameter(_ctx.Type(Typ.Generic(typeof(ApiClientStreamingCall<,>), tRequest, tResponse)), "call").Ref();
                yield return PartialMethod("Modify_ApiCall", tRequest, tResponse)(callClientStreaming)
                    .AddGenericConstraint(tRequest, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tRequest)))
                    .AddGenericConstraint(tResponse, _ctx.Type(Typ.ClassConstraint), _ctx.Type(Typ.Generic(typeof(IMessage<>), tResponse)));
            }
        }

        private IEnumerable<MethodDeclarationSyntax> ModifyPerMethodApiCallPartialMethods() =>
            _svc.Methods.Select(method =>
            {
                var call = Parameter(_ctx.Type(method.ApiCallTyp), "call").Ref();
                return PartialMethod(method.ModifyApiCallMethodName)(call);
            });

        private MethodDeclarationSyntax OnConstruction()
        {
            var grpcClient = Parameter(_ctx.Type(_svc.GrpcClientTyp), "grpcClient");
            var effectiveSettings = Parameter(_ctx.Type(_svc.SettingsTyp), "effectiveSettings");
            var clientHelper = Parameter(_ctx.Type<ClientHelper>(), "clientHelper");
            return PartialMethod("OnConstruction")(grpcClient, effectiveSettings, clientHelper);
        }

        private IEnumerable<MethodDeclarationSyntax> ModifyRequestMethods()
        {
            var seenTypes = new HashSet<Typ>();
            var seenStreamingTypes = new HashSet<Typ>();
            foreach (var method in _svc.Methods)
            {
                switch (method)
                {
                    case MethodDetails.BidiStreaming methodBidi:
                        if (seenStreamingTypes.Add(method.RequestTyp))
                        {
                            yield return ModifyBidiRequestCallSettingsPartialMethod(_ctx, methodBidi);
                            yield return PartialMethod(methodBidi.ModifyStreamingRequestMethodName)(Parameter(_ctx.Type(method.RequestTyp), "request").Ref());
                        }
                        break;
                    case MethodDetails.ClientStreaming methodClient:
                        if (seenStreamingTypes.Add(method.RequestTyp))
                        {
                            yield return ModifyClientRequestCallSettingsPartialMethod(_ctx, methodClient);
                            yield return PartialMethod(methodClient.ModifyStreamingRequestMethodName)(Parameter(_ctx.Type(method.RequestTyp), "request").Ref());
                        }
                        break;
                    default:
                        if (seenTypes.Add(method.RequestTyp))
                        {
                            yield return ModifyRequestPartialMethod(_ctx, method);
                        }
                        break;
                }
            }
        }
    }
}
