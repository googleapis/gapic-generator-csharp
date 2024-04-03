// Copyright 2022 Google LLC
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

using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Generation
{
    internal class ServiceCollectionExtensionsGenerator
    {
        internal const string ClassName = "ServiceCollectionExtensions";
        internal const string FileName = ClassName + ".g.cs";

        public static CompilationUnitSyntax GenerateExtensions(SourceFileContext ctx, List<ServiceDetails> packageServiceDetails)
        {
            var ns = typeof(IServiceCollection).Namespace;
            var namespaceDeclaration = Namespace(ns);
            using (ctx.InNamespace(namespaceDeclaration))
            {
                var cls = Class(Public | Static | Partial, Typ.Manual(ns, ClassName))
                    .WithXmlDoc(XmlDoc.Summary("Static class to provide extension methods to configure API clients."));

                var extensionMethods = packageServiceDetails
                    .OrderBy(p => p.ServiceFullName, StringComparer.Ordinal)
                    .SelectMany(m => GenerateMethods(ctx, m))
                    .ToArray();
                cls = cls.AddMembers(extensionMethods);
                namespaceDeclaration = namespaceDeclaration.AddMembers(cls);
            }
            return ctx.CreateCompilationUnit(namespaceDeclaration);
        }

        private static IEnumerable<MethodDeclarationSyntax> GenerateMethods(SourceFileContext ctx, ServiceDetails service)
        {
            yield return GenerateMethod(ctx, service);
            yield return GenerateMethodWithAdditionalDependencyInjection(ctx, service);
        }

        private static MethodDeclarationSyntax GenerateMethod(SourceFileContext ctx, ServiceDetails service)
        {
            var name = $"Add{service.ClientAbstractTyp.Name}";
            var serviceCollection = ctx.Type<IServiceCollection>();
            var services = Parameter(serviceCollection, "services")
                .WithModifiers(SyntaxTokenList.Create(Token(SyntaxKind.ThisKeyword).WithTrailingSpace()));
            var actionType = ctx.Type(Typ.Generic(typeof(Action<>), service.BuilderTyp));
            var action = Parameter(actionType, "action", @default: Null);

            var builderType = ctx.Type(service.BuilderTyp);
            var builder = Local(builderType, "builder");

            var provider = Parameter(ctx.Type<IServiceProvider>(), "provider");
            var lambda = Lambda(provider)(
                    builder.WithInitializer(New(builderType)()),
                    action.Call("Invoke", true)(builder),
                    Return(builder.Call("Build")(provider))
                );

            return Method(Public | Static, serviceCollection, name)(services, action)
                .MaybeWithAttribute(service.IsDeprecated, () => ctx.Type<ObsoleteAttribute>())()
                .WithBody(services.Call("AddSingleton")(lambda))
                .WithXmlDoc(
                    XmlDoc.Summary("Adds a singleton ", ctx.Type(service.ClientAbstractTyp), " to ", services, "."),
                    XmlDoc.Param(services, "The service collection to add the client to. The services are used to configure the client when requested."),
                    XmlDoc.Param(action, "An optional action to invoke on the client builder. This is invoked before services from ", services, " are used.")
                );
        }

        private static MethodDeclarationSyntax GenerateMethodWithAdditionalDependencyInjection(SourceFileContext ctx, ServiceDetails service)
        {
            var name = $"Add{service.ClientAbstractTyp.Name}";
            var serviceCollection = ctx.Type<IServiceCollection>();
            var services = Parameter(serviceCollection, "services")
                .WithModifiers(SyntaxTokenList.Create(Token(SyntaxKind.ThisKeyword).WithTrailingSpace()));
            var actionType = ctx.Type(Typ.Generic(typeof(Action<>), Typ.Of<IServiceProvider>(), service.BuilderTyp));
            var action = Parameter(actionType, "action", @default: Null);

            var builderType = ctx.Type(service.BuilderTyp);
            var builder = Local(builderType, "builder");

            var provider = Parameter(ctx.Type<IServiceProvider>(), "provider");
            var lambda = Lambda(provider)(
                builder.WithInitializer(New(builderType)()),
                action.Call("Invoke", true)(provider, builder),
                Return(builder.Call("Build")(provider))
            );

            return Method(Public | Static, serviceCollection, name)(services, action)
                .MaybeWithAttribute(service.IsDeprecated, () => ctx.Type<ObsoleteAttribute>())()
                .WithBody(services.Call("AddSingleton")(lambda))
                .WithXmlDoc(
                    XmlDoc.Summary("Adds a singleton ", ctx.Type(service.ClientAbstractTyp), " to ", services, "."),
                    XmlDoc.Param(services, "The service collection to add the client to. The services are used to configure the client when requested."),
                    XmlDoc.Param(action, "An optional action to invoke on the client builder. This is invoked before services from ", services, " are used.")
                );
        }
    }
}
