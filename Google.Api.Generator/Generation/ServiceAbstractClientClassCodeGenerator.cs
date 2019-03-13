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
using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

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
                .WithXmlDoc(XmlDoc.Summary($"{_svc.DocumentationName} client wrapper, for convenient use."));
            using (_ctx.InClass(cls))
            {
                var defaultEndpoint = DefaultEndpoint();
                var defaultScopes = DefaultScopes();
                var sChannelPool = SChannelPool(defaultScopes);
                var createFromCallInvoker = CreateFromCallInvoker();
                var createFromChannel = CreateFromChannel(createFromCallInvoker);
                var createFromEndPoint = CreateFromEndpoint(sChannelPool, defaultEndpoint, createFromChannel);
                var createAsync = CreateAsync(sChannelPool, defaultEndpoint, createFromChannel);
                var shutdown = ShutdownDefaultChannelsAsync(sChannelPool, createFromCallInvoker, createAsync);
                var grpcClient = GrpcClient();
                cls = cls.AddMembers(
                    defaultEndpoint, defaultScopes, sChannelPool,
                    createAsync, createFromEndPoint, createFromChannel, createFromCallInvoker,
                    shutdown, grpcClient);
                var methods = ServiceMethodGenerator.Generate(_ctx, _svc, inAbstract: true);
                cls = cls.AddMembers(methods.ToArray());
            }
            return cls;
        }

        private PropertyDeclarationSyntax DefaultEndpoint() =>
            AutoProperty(Public | Static, _ctx.Type<ServiceEndpoint>(), "DefaultEndpoint")
                .WithInitializer(New(_ctx.Type<ServiceEndpoint>())(_svc.DefaultHost, _svc.DefaultPort))
                .WithXmlDoc(XmlDoc.Summary(
                    $"The default endpoint for the {_svc.DocumentationName} service, " + 
                    $"which is a host of \"{_svc.DefaultHost}\" and a port of {_svc.DefaultPort}."));

        private PropertyDeclarationSyntax DefaultScopes() =>
            AutoProperty(Public | Static, _ctx.Type<IReadOnlyList<string>>(), "DefaultScopes")
                .WithInitializer(New(_ctx.Type<ReadOnlyCollection<string>>())(NewArray(_ctx.ArrayType<string[]>())(_svc.DefaultScopes)))
                .WithXmlDoc(
                    XmlDoc.Summary($"The default {_svc.DocumentationName} scopes."),
                    XmlDoc.Remarks($"The default {_svc.DocumentationName} scopes are:", XmlDoc.UL(_svc.DefaultScopes)));

        private FieldDeclarationSyntax SChannelPool(PropertyDeclarationSyntax defaultScopes) =>
            Field(Private | Static | Readonly, _ctx.Type<ChannelPool>(), "s_channelPool")
                .WithInitializer(New(_ctx.Type<ChannelPool>())(defaultScopes));

        private MethodDeclarationSyntax CreateFromCallInvoker()
        {
            var callInvoker = Parameter(_ctx.Type<CallInvoker>(), "callInvoker");
            var settings = Parameter(_ctx.Type(_svc.SettingsTyp), "settings", @default: Null);
            var interceptor = Local(_ctx.Type<Interceptor>(), "interceptor");
            var grpcClient = Local(_ctx.Type(_svc.GrpcClientTyp), "grpcClient");
            return Method(Public | Static, _ctx.CurrentType, "Create")(callInvoker, settings)
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

        private MethodDeclarationSyntax CreateFromChannel(MethodDeclarationSyntax createFromCallInvoker)
        {
            var channel = Parameter(_ctx.Type<Channel>(), "channel");
            var settings = Parameter(_ctx.Type(_svc.SettingsTyp), "settings", @default: Null);
            return Method(Public | Static, _ctx.CurrentType, "Create")(channel, settings)
                .WithBody(
                    _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(channel, Nameof(channel)),
                    Return(This.Call(createFromCallInvoker)(New(_ctx.Type<DefaultCallInvoker>())(channel), settings)))
                .WithXmlDoc(
                    XmlDoc.Summary("Creates a ", _ctx.CurrentType, " which uses the specified channel for remote operations."),
                    XmlDoc.Param(channel, "The ", channel.Type, " for remote operations. Must not be null."),
                    XmlDoc.Param(settings, "Optional ", settings.Type, "."),
                    XmlDoc.Returns("The created ", _ctx.CurrentType, "."));
        }

        private MethodDeclarationSyntax CreateFromEndpoint(FieldDeclarationSyntax channelPool, MemberDeclarationSyntax defaultEndpoint, MethodDeclarationSyntax createFromChannel)
        {
            var endpoint = Parameter(_ctx.Type<ServiceEndpoint>(), "endpoint", @default: Null);
            var settings = Parameter(_ctx.Type(_svc.SettingsTyp), "settings", @default: Null);
            var channel = Local(_ctx.Type<Channel>(), "channel");
            return Method(Public | Static, _ctx.CurrentType, "Create")(endpoint, settings)
                .WithBody(
                    channel.WithInitializer(channelPool.Call(nameof(Google.Api.Gax.Grpc.ChannelPool.GetChannel))(endpoint.NullCoalesce(defaultEndpoint))),
                    Return(This.Call(createFromChannel)(channel, settings)))
                .WithXmlDoc(
                    XmlDoc.Summary("Synchronously creates a ", _ctx.CurrentType, ", applying defaults for all unspecified settings, ",
                        "and creating a channel connecting to the given endpoint with application default credentials where ",
                        "necessary. See the example for how to use custom credentials."),
                    XmlDoc.Example("This sample shows how to create a client using default credentials:",
                        XmlDoc.Code(
                            "using Google.Cloud.Vision.V1;",
                            "...",
                            "// When running on Google Cloud Platform this will use the project Compute Credential.",
                            "// Or set the GOOGLE_APPLICATION_CREDENTIALS environment variable to the path of a JSON",
                            "// credential file to use that credential.",
                            "ImageAnnotatorClient client = ImageAnnotatorClient.Create();"),
                        "This sample shows how to create a client using credentials loaded from a JSON file:",
                        XmlDoc.Code(
                            "using Google.Cloud.Vision.V1;",
                            "using Google.Apis.Auth.OAuth2;",
                            "using Grpc.Auth;",
                            "using Grpc.Core;",
                            "...",
                            "GoogleCredential cred = GoogleCredential.FromFile(\"/path/to/credentials.json\");",
                            "Channel channel = new Channel(",
                            "    ImageAnnotatorClient.DefaultEndpoint.Host, ImageAnnotatorClient.DefaultEndpoint.Port, cred.ToChannelCredentials());",
                            "ImageAnnotatorClient client = ImageAnnotatorClient.Create(channel);",
                            "...",
                            "// Shutdown the channel when it is no longer required.",
                            "channel.ShutdownAsync().Wait();")),
                    XmlDoc.Param(endpoint, "Optional ", endpoint.Type, "."),
                    XmlDoc.Param(settings, "Optional ", settings.Type, "."),
                    XmlDoc.Returns("The created ", _ctx.CurrentType, "."));
        }

        private MethodDeclarationSyntax CreateAsync(FieldDeclarationSyntax channelPool, PropertyDeclarationSyntax defaultEndpoint, MethodDeclarationSyntax createFromChannel)
        {
            var returnType = Typ.Generic(typeof(Task<>), _ctx.CurrentTyp);
            var endpoint = Parameter(_ctx.Type<ServiceEndpoint>(), "endpoint", @default: Null);
            var settings = Parameter(_ctx.Type(_svc.SettingsTyp), "settings", @default: Null);
            var channel = Local(_ctx.Type<Channel>(), "channel");
            return Method(Public | Static | Async, _ctx.Type(returnType), "CreateAsync")(endpoint, settings)
                .WithBody(
                    channel.WithInitializer(Await(channelPool.Call(nameof(ChannelPool.GetChannelAsync))(endpoint.NullCoalesce(defaultEndpoint)).ConfigureAwait())),
                    Return(This.Call(createFromChannel)(channel, settings)))
                .WithXmlDoc(
                    XmlDoc.Summary("Asynchronously creates a ", _ctx.CurrentType, ", applying defaults for all unspecified settings, ",
                        "and creating a channel connecting to the given endpoint with application default credentials where ",
                        "necessary. See the example for how to use custom credentials."),
                    XmlDoc.Example("This sample shows how to create a client using default credentials:",
                        XmlDoc.Code(
                            "using Google.Cloud.Vision.V1;",
                            "...",
                            "// When running on Google Cloud Platform this will use the project Compute Credential.",
                            "// Or set the GOOGLE_APPLICATION_CREDENTIALS environment variable to the path of a JSON",
                            "// credential file to use that credential.",
                            "ImageAnnotatorClient client = await ImageAnnotatorClient.CreateAsync();"),
                        "This sample shows how to create a client using credentials loaded from a JSON file:",
                        XmlDoc.Code(
                            "using Google.Cloud.Vision.V1;",
                            "using Google.Apis.Auth.OAuth2;",
                            "using Grpc.Auth;",
                            "using Grpc.Core;",
                            "...",
                            "GoogleCredential cred = GoogleCredential.FromFile(\"/path/to/credentials.json\");",
                            "Channel channel = new Channel(",
                            "    ImageAnnotatorClient.DefaultEndpoint.Host, ImageAnnotatorClient.DefaultEndpoint.Port, cred.ToChannelCredentials());",
                            "ImageAnnotatorClient client = ImageAnnotatorClient.Create(channel);",
                            "...",
                            "// Shutdown the channel when it is no longer required.",
                            "await channel.ShutdownAsync();")),
                    XmlDoc.Param(endpoint, "Optional ", endpoint.Type, "."),
                    XmlDoc.Param(settings, "Optional ", settings.Type, "."),
                    XmlDoc.Returns("The task representing the created ", _ctx.CurrentType, "."));
        }

        private MemberDeclarationSyntax ShutdownDefaultChannelsAsync(FieldDeclarationSyntax channelPool, MethodDeclarationSyntax create, MethodDeclarationSyntax createAsync) =>
            Method(Public | Static, _ctx.Type<Task>(), "ShutdownDefaultChannelsAsync")()
                .WithBody(
                    channelPool.Call(nameof(ChannelPool.ShutdownChannelsAsync))())
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
    }
}
