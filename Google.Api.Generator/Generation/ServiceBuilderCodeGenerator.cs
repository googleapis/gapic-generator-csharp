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
using Grpc.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

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
                cls = cls.AddMembers(Build());
                cls = cls.AddMembers(BuildAsync());
                cls = cls.AddMembers(GetDefaultEndpoint());
                cls = cls.AddMembers(GetDefaultScopes());
                cls = cls.AddMembers(GetChannelPool());
            }
            return cls;
        }

        private PropertyDeclarationSyntax Settings() =>
            AutoProperty(Public, _ctx.Type(_svc.SettingsTyp), "Settings", hasSetter: true)
                .WithXmlDoc(XmlDoc.Summary("The settings to use for RPCs, or ", null, " for the default settings."));

        private MethodDeclarationSyntax Build()
        {
            var callInvoker = Local(_ctx.Type<CallInvoker>(), "callInvoker");
            return Method(Public | Override, _ctx.Type(_svc.ClientAbstractTyp), "Build")()
                .WithBody(
                    This.Call("Validate")(),
                    callInvoker.WithInitializer(This.Call("CreateCallInvoker")()),
                    Return(_ctx.Type(_svc.ClientAbstractTyp).Call("Create")(callInvoker, Settings())))
                .WithXmlDoc(XmlDoc.InheritDoc);
        }

        private MethodDeclarationSyntax BuildAsync()
        {
            var cancellationToken = Parameter(_ctx.Type<CancellationToken>(), "cancellationToken", @default: Default);
            var callInvoker = Local(_ctx.Type<CallInvoker>(), "callInvoker");
            return Method(Public | Override | Async, _ctx.Type(Typ.Generic(typeof(Task<>), _svc.ClientAbstractTyp)), "BuildAsync")(cancellationToken)
                .WithBody(
                    This.Call("Validate")(),
                    callInvoker.WithInitializer(Await(This.Call("CreateCallInvokerAsync")(cancellationToken).ConfigureAwait())),
                    Return(_ctx.Type(_svc.ClientAbstractTyp).Call("Create")(callInvoker, Settings())))
                .WithXmlDoc(XmlDoc.InheritDoc);
        }

        private MethodDeclarationSyntax GetDefaultEndpoint() =>
            Method(Protected|Override, _ctx.Type<ServiceEndpoint>(), "GetDefaultEndpoint")()
                .WithBody(_ctx.Type(_svc.ClientAbstractTyp).Access("DefaultEndpoint"))
                .WithXmlDoc(XmlDoc.InheritDoc);

        private MethodDeclarationSyntax GetDefaultScopes() =>
            Method(Protected | Override, _ctx.Type<IReadOnlyList<string>>(), "GetDefaultScopes")()
                .WithBody(_ctx.Type(_svc.ClientAbstractTyp).Access("DefaultScopes"))
                .WithXmlDoc(XmlDoc.InheritDoc);

        private MethodDeclarationSyntax GetChannelPool() =>
            Method(Protected | Override, _ctx.Type<ChannelPool>(), "GetChannelPool")()
                .WithBody(_ctx.Type(_svc.ClientAbstractTyp).Access("ChannelPool"))
                .WithXmlDoc(XmlDoc.InheritDoc);
    }
}
