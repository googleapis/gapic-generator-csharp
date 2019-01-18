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

using Google.Api.Generator.RoslynUtils;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                var ctor = CtorGrpcClient();
                // TODO: Implementation members.
                cls = cls.AddMembers(ctor);
            }
            return cls;
        }

        private MemberDeclarationSyntax CtorGrpcClient()
        {
            var grpcClient = Parameter(_ctx.Type(_svc.GrpcClientTyp), "grpcClient");
            var settings = Parameter(_ctx.Type(_svc.SettingsTyp), "settings");
            return Ctor(Public, _ctx.CurrentTyp)(grpcClient, settings)
                .WithBody(
                    // TODO: Constructor body
                )
                .WithXmlDoc(
                    XmlDoc.Summary($"Constructs a client wrapper for the {_svc.DocumentationName} service, with the specified gRPC client and settings."),
                    XmlDoc.Param(grpcClient, "The underlying gRPC client."),
                    XmlDoc.Param(settings, "The base ", _ctx.Type(_svc.SettingsTyp), " used within this client.")
                );
        }
    }
}
