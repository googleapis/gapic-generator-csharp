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
using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Google.LongRunning;
using Google.Protobuf;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

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

        private ServiceImplClientClassGenerator(SourceFileContext ctx, ServiceDetails svc) =>
            (_ctx, _svc) = (ctx, svc);

        private readonly ServiceDetails _svc;
        private readonly SourceFileContext _ctx;

        private ClassDeclarationSyntax Generate()
        {
            var cls = Class(Public | Sealed | Partial, _svc.ClientImplTyp, baseTypes: _ctx.Type(_svc.ClientAbstractTyp))
                .WithXmlDoc(XmlDoc.Summary($"{_svc.DocumentationName} client wrapper implementation, for convenient use."));
            using (_ctx.InClass(cls))
            {
                var apiCallFields = ApiCallFields().ToArray();
                var grpcClient = GrpcClient();
                var modifyApiCallGeneric = ModifyApiCallGenericPartialMethods().ToArray();
                var modifyApiCallPerMethod = ModifyPerMethodApiCallPartialMethods().ToArray();
                var onCtor = OnConstruction();
                var ctor = CtorGrpcClient(grpcClient, onCtor, modifyApiCallGeneric.First());
                var modifyRequestMethods = ModifyRequestMethods().ToArray();
                cls = cls.AddMembers(apiCallFields);
                cls = cls.AddMembers(ctor);
                cls = cls.AddMembers(modifyApiCallGeneric);
                cls = cls.AddMembers(modifyApiCallPerMethod);
                cls = cls.AddMembers(onCtor, grpcClient);
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
                    _svc.Methods.OfType<MethodDetails.Lro>().Select(LroClient),
                    _svc.Methods.SelectMany(PerMethod),
                    This.Call(onCtor)(grpcClient, effectiveSettings, clientHelper)
                )
                .WithXmlDoc(
                    XmlDoc.Summary($"Constructs a client wrapper for the {_svc.DocumentationName} service, with the specified gRPC client and settings."),
                    XmlDoc.Param(grpcClient, "The underlying gRPC client."),
                    XmlDoc.Param(settings, "The base ", _ctx.Type(_svc.SettingsTyp), " used within this client.")
                );

            SyntaxNode LroClient(MethodDetails.Lro lro)
            {
                var lroOperationsClientProperty = Property(Public, _ctx.Type<OperationsClient>(), lro.LroClientName);
                return lroOperationsClientProperty.Assign(New(_ctx.Type<OperationsClientImpl>())(
                    grpcClient.Call("CreateOperationsClient")(), effectiveSettings.Access(lro.LroSettingsName)));
            }

            IEnumerable<SyntaxNode> PerMethod(MethodDetails method)
            {
                var field = ApiCallField(_ctx, method);
                // Initialize ApiCall field.
                switch (method)
                {
                    case MethodDetails.BidiStreaming methodBidi:
                        var fieldInitBidi = clientHelper.Call(nameof(ClientHelper.BuildApiCall), _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName), effectiveSettings.Access(methodBidi.StreamingSettingsName));
                        yield return field.Assign(fieldInitBidi);
                        break;
                    case MethodDetails.ServerStreaming _:
                        var fieldInitServer = clientHelper.Call(nameof(ClientHelper.BuildApiCall), _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName));
                        yield return field.Assign(fieldInitServer);
                        break;
                    default:
                        var fieldInit = clientHelper.Call(nameof(ClientHelper.BuildApiCall), _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                            grpcClient.Access(method.AsyncMethodName), grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName));
                        yield return field.Assign(fieldInit);
                        break;
                }
                // Call modify partial methods.
                yield return This.Call(modifyApiCall)(Ref(field));
                yield return This.Call(method.ModifyApiCallMethodName)(Ref(field));
            }
        }

        private PropertyDeclarationSyntax GrpcClient() =>
            AutoProperty(Public | Override, _ctx.Type(_svc.GrpcClientTyp), "GrpcClient")
                .WithXmlDoc(XmlDoc.Summary("The underlying gRPC ", _svc.DocumentationName, " client"));

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
