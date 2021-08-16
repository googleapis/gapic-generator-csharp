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
using Google.Api.Gax.Grpc.GrpcCore;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Grpc.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Generate all code for the `Builder` class of a proto-defined service.
    /// </summary>
    internal class ServiceBuilderCodeGenerator
    {
        public static ClassDeclarationSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new ServiceBuilderCodeGenerator(ctx, svc).Generate();

        private ServiceBuilderCodeGenerator(SourceFileContext ctx, ServiceDetails svc) =>
            (_ctx, _svc) = (ctx, svc);

        private readonly SourceFileContext _ctx;
        private readonly ServiceDetails _svc;

        private ClassDeclarationSyntax Generate()
        {
            var baseTyp = Typ.Generic(typeof(ClientBuilderBase<>), _svc.ClientAbstractTyp);
            var cls = Class(Public | Sealed | Partial, _svc.BuilderTyp, baseTypes: _ctx.Type(baseTyp))
                .WithXmlDoc(XmlDoc.Summary("Builder class for ", _ctx.Type(_svc.ClientAbstractTyp), " to provide simple configuration of credentials, endpoint etc."));
            using (_ctx.InClass(cls))
            {
                cls = cls.AddMembers(Settings());
                cls = cls.AddMembers(ParameterlessConstructor());
                cls = cls.AddMembers(InterceptBuild());
                cls = cls.AddMembers(InterceptBuildAsync());
                cls = cls.AddMembers(Build());
                cls = cls.AddMembers(BuildAsync());
                cls = cls.AddMembers(BuildImpl());
                cls = cls.AddMembers(BuildAsyncImpl());
                cls = cls.AddMembers(GetDefaultEndpoint());
                cls = cls.AddMembers(GetDefaultScopes());
                cls = cls.AddMembers(GetChannelPool());
                cls = cls.AddMembers(DefaultGrpcAdapter());
            }
            return cls;
        }

        private PropertyDeclarationSyntax Settings() =>
            AutoProperty(Public, _ctx.Type(_svc.SettingsTyp), "Settings", hasSetter: true)
                .WithXmlDoc(XmlDoc.Summary("The settings to use for RPCs, or ", null, " for the default settings."));

        private ConstructorDeclarationSyntax ParameterlessConstructor() =>
            Ctor(Public, _svc.BuilderTyp)()
                .WithXmlDoc(XmlDoc.Summary("Creates a new builder with default settings."))
                .WithBlockBody(new[]
                {
                    Property(Public, _ctx.Type(_svc.BuilderTyp), "UseJwtAccessWithScopes").Assign(_ctx.Type(_svc.ClientAbstractTyp).Access("UseJwtAccessWithScopes"))
                });

        private MethodDeclarationSyntax InterceptBuild() => PartialMethod("InterceptBuild")(Parameter(_ctx.Type(_svc.ClientAbstractTyp), "client").Ref());

        private MethodDeclarationSyntax InterceptBuildAsync() => PartialMethod("InterceptBuildAsync")(
            Parameter(_ctx.Type<CancellationToken>(), "cancellationToken"),
            Parameter(_ctx.Type(Typ.Generic(typeof(Task<>), _svc.ClientAbstractTyp)), "task").Ref());

        private MethodDeclarationSyntax Build()
        {
            var client = Local(_ctx.Type(_svc.ClientAbstractTyp), "client");
            return Method(Public | Override, _ctx.Type(_svc.ClientAbstractTyp), "Build")()
                .WithBody(
                    client.WithInitializer(Null),
                    This.Call("InterceptBuild")(Ref(client)),
                    Return(client.NullCoalesce(This.Call("BuildImpl")())))
                .WithXmlDoc(XmlDoc.Summary("Builds the resulting client."));
        }

        private MethodDeclarationSyntax BuildAsync()
        {
            var cancellationToken = Parameter(_ctx.Type<CancellationToken>(), "cancellationToken", @default: Default);
            var task = Local(_ctx.Type(Typ.Generic(typeof(Task<>), _svc.ClientAbstractTyp)), "task");
            return Method(Public | Override, _ctx.Type(Typ.Generic(typeof(Task<>), _svc.ClientAbstractTyp)), "BuildAsync")(cancellationToken)
                .WithBody(
                    task.WithInitializer(Null),
                    This.Call("InterceptBuildAsync")(cancellationToken, Ref(task)),
                    Return(task.NullCoalesce(This.Call("BuildAsyncImpl")(cancellationToken))))
                .WithXmlDoc(XmlDoc.Summary("Builds the resulting client asynchronously."));
        }

        private MethodDeclarationSyntax BuildImpl()
        {
            var callInvoker = Local(_ctx.Type<CallInvoker>(), "callInvoker");
            return Method(Private, _ctx.Type(_svc.ClientAbstractTyp), "BuildImpl")()
                .WithBody(
                    This.Call("Validate")(),
                    callInvoker.WithInitializer(This.Call("CreateCallInvoker")()),
                    Return(_ctx.Type(_svc.ClientAbstractTyp).Call("Create")(callInvoker, Settings())));
        }

        private MethodDeclarationSyntax BuildAsyncImpl()
        {
            var cancellationToken = Parameter(_ctx.Type<CancellationToken>(), "cancellationToken");
            var callInvoker = Local(_ctx.Type<CallInvoker>(), "callInvoker");
            return Method(Private | Async, _ctx.Type(Typ.Generic(typeof(Task<>), _svc.ClientAbstractTyp)), "BuildAsyncImpl")(cancellationToken)
                .WithBody(
                    This.Call("Validate")(),
                    callInvoker.WithInitializer(Await(This.Call("CreateCallInvokerAsync")(cancellationToken).ConfigureAwait())),
                    Return(_ctx.Type(_svc.ClientAbstractTyp).Call("Create")(callInvoker, Settings())));
        }

        private MethodDeclarationSyntax GetDefaultEndpoint() =>
            Method(Protected|Override, _ctx.Type<string>(), "GetDefaultEndpoint")()
                .WithBody(_ctx.Type(_svc.ClientAbstractTyp).Access("DefaultEndpoint"))
                .WithXmlDoc(XmlDoc.Summary("Returns the endpoint for this builder type, used if no endpoint is otherwise specified."));

        private MethodDeclarationSyntax GetDefaultScopes() =>
            Method(Protected | Override, _ctx.Type<IReadOnlyList<string>>(), "GetDefaultScopes")()
                .WithBody(_ctx.Type(_svc.ClientAbstractTyp).Access("DefaultScopes"))
                .WithXmlDoc(XmlDoc.Summary("Returns the default scopes for this builder type, used if no scopes are otherwise specified."));

        private MethodDeclarationSyntax GetChannelPool() =>
            Method(Protected | Override, _ctx.Type<ChannelPool>(), "GetChannelPool")()
                .WithBody(_ctx.Type(_svc.ClientAbstractTyp).Access("ChannelPool"))
                .WithXmlDoc(XmlDoc.Summary("Returns the channel pool to use when no other options are specified."));

        private PropertyDeclarationSyntax DefaultGrpcAdapter() =>
            Property(Protected | Override, _ctx.Type<GrpcAdapter>(), "DefaultGrpcAdapter")
                .WithGetBody(_ctx.Type<GrpcCoreAdapter>().Access(nameof(GrpcCoreAdapter.Instance)))
                .WithXmlDoc(XmlDoc.Summary("Returns the default ", _ctx.Type<GrpcAdapter>(), "to use if not otherwise specified."));
    }
}
