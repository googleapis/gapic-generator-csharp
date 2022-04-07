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
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    internal class ServiceAbstractClientClassCodeGenerator
    {
        public static ClassDeclarationSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new ServiceAbstractClientClassCodeGenerator(ctx, svc).Generate();

        private ServiceAbstractClientClassCodeGenerator(SourceFileContext ctx, ServiceDetails svc) =>
            (_ctx, _svc) = (ctx, svc);

        private readonly ServiceDetails _svc;
        private readonly SourceFileContext _ctx;

        private ClassDeclarationSyntax Generate()
        {
            var cls = Class(Public | Abstract | Partial, _svc.ClientAbstractTyp)
                .WithXmlDoc(
                    XmlDoc.Summary($"{_svc.DocumentationName} client wrapper, for convenient use."),
                    XmlDoc.RemarksPreFormatted(_svc.DocLines));
            using (_ctx.InClass(cls))
            {
                var defaultEndpoint = DefaultEndpoint();
                var defaultScopes = DefaultScopes();
                var serviceMetadata = ServiceMetadata(defaultEndpoint, defaultScopes);
                var channelPool = ChannelPool(serviceMetadata);
                var createAsync = CreateAsync();
                var create = Create();
                var createFromCallInvoker = CreateFromCallInvoker();
                var shutdown = ShutdownDefaultChannelsAsync(channelPool, create, createAsync);
                var grpcClient = GrpcClient();
                cls = cls.AddMembers(
                    defaultEndpoint, defaultScopes, serviceMetadata, channelPool, 
                    createAsync, create, createFromCallInvoker, shutdown, grpcClient);
                cls = cls.AddMembers(Mixins().ToArray());
                var methods = ServiceMethodGenerator.Generate(_ctx, _svc, inAbstract: true);
                cls = cls.AddMembers(methods.ToArray());
            }
            return cls;
        }

        private PropertyDeclarationSyntax DefaultEndpoint() =>
            AutoProperty(Public | Static, _ctx.Type<string>(), "DefaultEndpoint")
                .WithInitializer($"{_svc.DefaultHost}:{_svc.DefaultPort}")
                .WithXmlDoc(XmlDoc.Summary(
                    $"The default endpoint for the {_svc.DocumentationName} service, " + 
                    $"which is a host of \"{_svc.DefaultHost}\" and a port of {_svc.DefaultPort}."));

        private PropertyDeclarationSyntax DefaultScopes() =>
            AutoProperty(Public | Static, _ctx.Type<IReadOnlyList<string>>(), "DefaultScopes")
                .WithInitializer(New(_ctx.Type<ReadOnlyCollection<string>>())(NewArray(_ctx.ArrayType<string[]>())(_svc.DefaultScopes)))
                .WithXmlDoc(
                    XmlDoc.Summary($"The default {_svc.DocumentationName} scopes."),
                    XmlDoc.Remarks($"The default {_svc.DocumentationName} scopes are:", XmlDoc.UL(_svc.DefaultScopes)));

        private PropertyDeclarationSyntax ServiceMetadata(PropertyDeclarationSyntax defaultEndpoint, PropertyDeclarationSyntax defaultScopes)
        {
            var serviceDescriptor = _ctx.Type(_svc.ProtoTyp).Access("Descriptor");
            var supportsScopedJwts = true;
            // TODO: make this observe the transports we've been asked for.
            var apiTransports = _ctx.Type<ApiTransports>().Access(nameof(ApiTransports.Grpc));
            var apiMetadata = _ctx.Type(Typ.Manual(_svc.Namespace, PackageApiMetadataGenerator.ClassName)).Access(PackageApiMetadataGenerator.PropertyName);
            return AutoProperty(Internal | Static, _ctx.Type<ServiceMetadata>(), "ServiceMetadata")
                .WithInitializer(New(_ctx.Type<ServiceMetadata>())(serviceDescriptor, defaultEndpoint, defaultScopes, supportsScopedJwts, apiTransports, apiMetadata))
                .WithXmlDoc(XmlDoc.Summary($"The service metadata associated with this client type."));
        }

        private PropertyDeclarationSyntax ChannelPool(PropertyDeclarationSyntax serviceMetadata) =>
            AutoProperty(Internal | Static, _ctx.Type<ChannelPool>(), "ChannelPool")
                .WithInitializer(New(_ctx.Type<ChannelPool>())(serviceMetadata));

        // This isn't strictly required; it could be moved into the builder type if we wanted.
        // That can be done later if we want, as this is an internal method.
        private MethodDeclarationSyntax CreateFromCallInvoker()
        {
            var callInvoker = Parameter(_ctx.Type<CallInvoker>(), "callInvoker");
            var settings = Parameter(_ctx.Type(_svc.SettingsTyp), "settings", @default: Null);
            var interceptor = Local(_ctx.Type<Interceptor>(), "interceptor");
            var grpcClient = Local(_ctx.Type(_svc.GrpcClientTyp), "grpcClient");
            return Method(Internal | Static, _ctx.CurrentType, "Create")(callInvoker, settings)
                .WithBody(
                    _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(callInvoker, Nameof(callInvoker)),
                    interceptor.WithInitializer(settings.Access("Interceptor", conditional: true)),
                    If(interceptor.NotEqualTo(Null)).Then(
                        callInvoker.Assign(_ctx.Type(typeof(CallInvokerExtensions)).Call(nameof(CallInvokerExtensions.Intercept))(callInvoker, interceptor))),
                    grpcClient.WithInitializer(New(_ctx.Type(_svc.GrpcClientTyp))(callInvoker)),
                    Return(New(_ctx.Type(_svc.ClientImplTyp))(grpcClient, settings))
                )
                .WithXmlDoc(
                    XmlDoc.Summary("Creates a ", _ctx.CurrentType, " which uses the specified call invoker for remote operations."),
                    XmlDoc.Param(callInvoker, "The ", callInvoker.Type, " for remote operations. Must not be null."),
                    XmlDoc.Param(settings, "Optional ", settings.Type, "."),
                    XmlDoc.Returns("The created ", _ctx.CurrentType, "."));
        }

        private MethodDeclarationSyntax CreateAsync()
        {
            var returnType = Typ.Generic(typeof(Task<>), _ctx.CurrentTyp);
            var cancellationToken = Parameter(_ctx.Type<CancellationToken>(), "cancellationToken", @default: Default);
            return Method(Public | Static, _ctx.Type(returnType), "CreateAsync")(cancellationToken)
                .WithBody(New(_ctx.Type(_svc.BuilderTyp))().Call("BuildAsync")(cancellationToken))
                .WithXmlDoc(
                    XmlDoc.Summary("Asynchronously creates a ", _ctx.CurrentType,
                    " using the default credentials, endpoint and settings. ",
                    "To specify custom credentials or other settings, use ", _ctx.Type(_svc.BuilderTyp), "."),
                    XmlDoc.Param(cancellationToken, "The ", cancellationToken.Type, " to use while creating the client."),
                    XmlDoc.Returns("The task representing the created ", _ctx.CurrentType, "."));
        }

        private MethodDeclarationSyntax Create()
        {
            var returnType = _ctx.CurrentTyp;
            return Method(Public | Static, _ctx.Type(returnType), "Create")()
                .WithBody(New(_ctx.Type(_svc.BuilderTyp))().Call("Build")())
                .WithXmlDoc(
                    XmlDoc.Summary("Synchronously creates a ", _ctx.CurrentType,
                    " using the default credentials, endpoint and settings. ",
                    "To specify custom credentials or other settings, use ", _ctx.Type(_svc.BuilderTyp), "."),
                    XmlDoc.Returns("The created ", _ctx.CurrentType, "."));
        }

        private MemberDeclarationSyntax ShutdownDefaultChannelsAsync(PropertyDeclarationSyntax channelPool, MethodDeclarationSyntax create, MethodDeclarationSyntax createAsync) =>
            Method(Public | Static, _ctx.Type<Task>(), "ShutdownDefaultChannelsAsync")()
                .WithBody(
                    channelPool.Call(nameof(Google.Api.Gax.Grpc.ChannelPool.ShutdownChannelsAsync))())
                .WithXmlDoc(
                    XmlDoc.Summary("Shuts down any channels automatically created by ", create, " and ", createAsync, ".",
                        " Channels which weren't automatically created are not affected."),
                    XmlDoc.Remarks("After calling this method, further calls to ", create, " and ", createAsync,
                        " will create new channels, which could in turn be shut down by another call to this method."),
                    XmlDoc.Returns("A task representing the asynchronous shutdown operation.")
                );

        private PropertyDeclarationSyntax GrpcClient() =>
            Property(Public | Virtual, _ctx.Type(_svc.GrpcClientTyp), "GrpcClient")
                .WithGetBody(Throw(New(_ctx.Type<NotImplementedException>())()))
                .WithXmlDoc(XmlDoc.Summary("The underlying gRPC ", _svc.DocumentationName, " client"));

        private IEnumerable<PropertyDeclarationSyntax> Mixins() =>
            _svc.Mixins.Select(mixin =>
                Property(Public | Virtual, _ctx.Type(mixin.GapicClientType), mixin.GapicClientType.Name)
                    .WithGetBody(Throw(New(_ctx.Type<NotImplementedException>())()))
                    .WithXmlDoc(XmlDoc.Summary("The ", _ctx.Type(mixin.GapicClientType), " associated with this client.")));
    }
}
