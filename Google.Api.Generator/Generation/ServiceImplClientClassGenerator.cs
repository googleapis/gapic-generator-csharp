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
using Google.Protobuf;
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

        private ServiceImplClientClassGenerator(SourceFileContext ctx, ServiceDetails svc) =>
            (_ctx, _svc) = (ctx, svc);

        private readonly ServiceDetails _svc;
        private readonly SourceFileContext _ctx;

        private ClassDeclarationSyntax Generate()
        {
            var cls = Class(Public | Sealed | Partial, _svc.ClientImplTyp, baseType: _ctx.Type(_svc.ClientAbstractTyp))
                .WithXmlDoc(XmlDoc.Summary($"{_svc.DocumentationName} client wrapper implementation, for convenient use."));
            using (_ctx.InClass(cls))
            {
                var apiCallFields = ApiCallFields().ToArray();
                var grpcClient = GrpcClient();
                var modifyApiCallGeneric = ModifyApiCallGenericPartialMethods().ToArray();
                var modifyApiCallPerMethod = ModifyPerMethodApiCallMethods().ToArray();
                var onCtor = OnConstruction();
                var ctor = CtorGrpcClient(grpcClient, onCtor, modifyApiCallGeneric.First());
                // TODO: Implementation members.
                cls = cls.AddMembers(apiCallFields);
                cls = cls.AddMembers(ctor);
                cls = cls.AddMembers(modifyApiCallGeneric);
                cls = cls.AddMembers(modifyApiCallPerMethod);
                cls = cls.AddMembers(onCtor, grpcClient);
            }
            return cls;
        }

        private FieldDeclarationSyntax ApiCallField(MethodDetails method) =>
            Field(Private | Readonly, _ctx.Type(method.ApiCallTyp), method.ApiCallFieldName);

        private IEnumerable<FieldDeclarationSyntax> ApiCallFields() => _svc.Methods.Select(ApiCallField);

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
                    _svc.Methods.SelectMany(PerMethod),
                    This.Call(onCtor)(grpcClient, effectiveSettings, clientHelper)
                )
                .WithXmlDoc(
                    XmlDoc.Summary($"Constructs a client wrapper for the {_svc.DocumentationName} service, with the specified gRPC client and settings."),
                    XmlDoc.Param(grpcClient, "The underlying gRPC client."),
                    XmlDoc.Param(settings, "The base ", _ctx.Type(_svc.SettingsTyp), " used within this client.")
                );

            IEnumerable<object> PerMethod(MethodDetails method)
            {
                var field = ApiCallField(method);
                var fieldInit = clientHelper.Call(nameof(ClientHelper.BuildApiCall), _ctx.Type(method.RequestTyp), _ctx.Type(method.ResponseTyp))(
                    grpcClient.Access(method.AsyncMethodName), grpcClient.Access(method.SyncMethodName), effectiveSettings.Access(method.SettingsName));
                // Initialize ApiCall field.
                yield return field.Assign(fieldInit);
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
        }

        private IEnumerable<MethodDeclarationSyntax> ModifyPerMethodApiCallMethods() =>
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
    }
}
