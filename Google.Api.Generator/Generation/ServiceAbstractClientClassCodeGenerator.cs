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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                cls = cls.AddMembers(defaultEndpoint, defaultScopes);
                // TODO: Further abstract client content...
            }
            return cls;
        }

        private MemberDeclarationSyntax DefaultEndpoint() =>
            AutoProperty(Public | Static, _ctx.Type<ServiceEndpoint>(), "DefaultEndpoint")
                .WithInitializer(New(_ctx.Type<ServiceEndpoint>())(_svc.DefaultHost, _svc.DefaultPort))
                .WithXmlDoc(XmlDoc.Summary(
                    $"The default endpoint for the {_svc.DocumentationName} service, " + 
                    $"which is a host of \"{_svc.DefaultHost}\" and a port of {_svc.DefaultPort}."));

        private MemberDeclarationSyntax DefaultScopes() =>
            AutoProperty(Public | Static, _ctx.Type<IReadOnlyList<string>>(), "DefaultScopes")
                .WithInitializer(New(_ctx.Type<ReadOnlyCollection<string>>())(NewArray(_ctx.ArrayType<string[]>())(_svc.DefaultScopes)))
                .WithXmlDoc(
                    XmlDoc.Summary($"The default {_svc.DocumentationName} scopes."),
                    XmlDoc.Remarks($"The default {_svc.DocumentationName} scopes are:", XmlDoc.UL(_svc.DefaultScopes)));
    }
}
