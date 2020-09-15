// Copyright 2020 Google LLC
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
using Google.Apis.Discovery;
using Google.Apis.Discovery.v1.Data;
using Google.Apis.Requests;
using Google.Apis.Services;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Rest.Models
{
    public class PackageModel
    {
        private readonly RestDescription _discoveryDoc;

        /// <summary>
        /// The name of the package, suitable for both namespace declarations and the NuGet
        /// package itself.
        /// </summary>
        public string PackageName { get; }

        public string Title { get; }
        public string ApiName { get; }
        public string ClassName { get; } // e.g. Webfonts
        public string ServiceClassName { get; } // e.g. WebfontsService
        public string VersionNoDots { get; }
        public string ApiVersion { get; }
        public IReadOnlyList<ResourceModel> Resources { get; }
        public IReadOnlyList<string> Features { get; }
        public IReadOnlyList<AuthScope> AuthScopes { get; }
        public IReadOnlyList<MethodModel> Methods { get; }
        public IReadOnlyList<DataModel> DataModels { get; }
        public Typ BaseRequestTyp { get; }
        public Typ ServiceTyp { get; }
        public string BaseUri { get; }
        public string BasePath { get; }
        public string BatchUri { get; }
        public string BatchPath { get; }

        public PackageModel(RestDescription discoveryDoc)
        {
            _discoveryDoc = discoveryDoc;
            ApiName = discoveryDoc.Name;
            ClassName = ToClassName(discoveryDoc.CanonicalName ?? discoveryDoc.Name);
            ServiceClassName = $"{ClassName}Service";
            ApiVersion = discoveryDoc.Version;
            PackageName = $"Google.Apis.{ClassName}.{ApiVersion}";
            VersionNoDots = discoveryDoc.Version.Replace('.', '_');
            Resources = discoveryDoc.Resources.ToReadOnlyList(pair => new ResourceModel(this, parent: null, pair.Key, pair.Value));
            Features = discoveryDoc.Features.ToReadOnlyList();
            // TODO: Ordering?
            AuthScopes = (discoveryDoc.Auth?.Oauth2?.Scopes).ToReadOnlyList(pair => new AuthScope(pair.Key, pair.Value.Description));
            ServiceTyp = Typ.Manual(PackageName, ServiceClassName);
            BaseRequestTyp = Typ.Generic(Typ.Manual(PackageName, $"{ClassName}BaseServiceRequest"), Typ.GenericParam("TResponse")); 
            BaseUri = discoveryDoc.RootUrl + discoveryDoc.ServicePath;
            BasePath = discoveryDoc.ServicePath;
            BatchUri = discoveryDoc.RootUrl + discoveryDoc.BatchPath;
            BatchPath = discoveryDoc.BatchPath;
            Title = discoveryDoc.Title;
            // TODO: Add in the anonymous schemas from method definitions
            DataModels = discoveryDoc.Schemas.ToReadOnlyList(pair => new DataModel(this, parent: null, name: pair.Key, schema: pair.Value));
            Methods = discoveryDoc.Methods.ToReadOnlyList(pair => new MethodModel(this, null, pair.Key, pair.Value));
        }

        /// <summary>
        /// Equivalent to ToClassName in csharp_generator.py
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal string ToClassName(string text)
        {
            if (Keywords.IsKeyword(text))
            {
                return PackageName.ToUpperCamelCase() + text.ToUpperCamelCase();
            }
            string[] bits = text.Split('.');
            return string.Join('.', bits.Select(bit => bit.ToUpperCamelCase()));
        }

        public ClassDeclarationSyntax GenerateServiceClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, ServiceTyp, ctx.Type<BaseClientService>()).WithXmlDoc(XmlDoc.Summary($"The {ClassName} Service."));
            using (ctx.InClass(cls))
            {
                var discoveryVersionTyp = Typ.Manual("Google.Apis.Discovery", "DiscoveryVersion");
                var version = Field(Modifier.Public | Modifier.Const, ctx.Type<string>(), "Version")
                    .WithInitializer(ApiVersion)
                    .WithXmlDoc(XmlDoc.Summary("The API version."));
                var discoveryVersion = Field(Modifier.Public | Modifier.Static, ctx.Type(discoveryVersionTyp), "DiscoveryVersionUsed")
                    .WithInitializer(ctx.Type(discoveryVersionTyp).Access(nameof(DiscoveryVersion.Version_1_0)))
                    .WithXmlDoc(XmlDoc.Summary("The discovery version used to generate this service."));

                var parameterlessCtor = Ctor(Modifier.Public, cls, ThisInitializer(New(ctx.Type<BaseClientService.Initializer>())()))()
                    .WithBody()
                    .WithXmlDoc(XmlDoc.Summary("Constructs a new service."));

                var initializerParam = Parameter(ctx.Type<BaseClientService.Initializer>(), "initializer");

                var featuresArrayInitializer = Features.Any()
                    ? NewArray(ctx.ArrayType(Typ.Of<string[]>()))(Features.ToArray())
                    : NewArray(ctx.ArrayType(Typ.Of<string[]>()), LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0)));
                var features = Property(Modifier.Public | Modifier.Override, ctx.Type<IList<string>>(), "Features")
                    .WithGetBody(featuresArrayInitializer)
                    .WithXmlDoc(XmlDoc.Summary("Gets the service supported features."));

                var nameProperty = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "Name")
                    .WithGetBody(ApiName)
                    .WithXmlDoc(XmlDoc.Summary("Gets the service name."));

                // TODO: BaseURI without BaseUriOverride, via #if
                var baseUri = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BaseUri")
                    .WithGetBody(IdentifierName("BaseUriOverride").NullCoalesce(BaseUri))
                    .WithXmlDoc(XmlDoc.Summary("Gets the service base URI."));

                var basePath = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BasePath")
                    .WithGetBody(BasePath)
                    .WithXmlDoc(XmlDoc.Summary("Gets the service base path."));

                // TODO: #if !NET40 for both of these
                var batchUri = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BatchUri")
                    .WithGetBody(BatchUri)
                    .WithXmlDoc(XmlDoc.Summary("Gets the batch base URI; ", XmlDoc.C("null"), " if unspecified."));
                var batchPath = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BatchPath")
                    .WithGetBody(BatchPath)
                    .WithXmlDoc(XmlDoc.Summary("Gets the batch base path; ", XmlDoc.C("null"), " if unspecified."));

                var resourceProperties = Resources.Select(resource => resource.GenerateProperty(ctx)).ToArray();

                var parameterizedCtor = Ctor(Modifier.Public, cls, BaseInitializer(initializerParam))(initializerParam)
                    .WithBlockBody(resourceProperties.Zip(Resources).Select(pair => pair.First.Assign(New(ctx.Type(pair.Second.Typ))(This))).ToArray())
                    .WithXmlDoc(
                        XmlDoc.Summary("Constructs a new service."),
                        XmlDoc.Param(initializerParam, "The service initializer."));

                cls = cls.AddMembers(version, discoveryVersion, parameterlessCtor, parameterizedCtor, features, nameProperty, baseUri, basePath, batchUri, batchPath);

                if (AuthScopes.Any())
                {
                    var scopeClass = Class(Modifier.Public, Typ.Manual(PackageName, "Scope"))
                        .WithXmlDoc(XmlDoc.Summary($"Available OAuth 2.0 scopes for use with the {Title}."));
                    using (ctx.InClass(scopeClass))
                    {
                        foreach (var scope in AuthScopes)
                        {
                            var field = Field(Modifier.Public | Modifier.Static, ctx.Type<string>(), scope.Name)
                                .WithInitializer(scope.Value)
                                .WithXmlDoc(XmlDoc.Summary(scope.Description));
                            scopeClass = scopeClass.AddMembers(field);
                        }
                    }

                    var scopeConstantsClass = Class(Modifier.Public | Modifier.Static, Typ.Manual(PackageName, "ScopeConstants"))
                        .WithXmlDoc(XmlDoc.Summary($"Available OAuth 2.0 scope constants for use with the {Title}."));
                    using (ctx.InClass(scopeConstantsClass))
                    {
                        foreach (var scope in AuthScopes)
                        {
                            var field = Field(Modifier.Public | Modifier.Const, ctx.Type<string>(), scope.Name)
                                .WithInitializer(scope.Value)
                                .WithXmlDoc(XmlDoc.Summary(scope.Description));
                            scopeConstantsClass = scopeConstantsClass.AddMembers(field);
                        }
                    }

                    cls = cls.AddMembers(scopeClass, scopeConstantsClass);
                }

                // TODO: Find an example of this...
                foreach (var method in Methods)
                {
                    cls = cls.AddMembers(method.GenerateDeclarations(ctx).ToArray());
                }

                cls = cls.AddMembers(resourceProperties);
            }
            return cls;
        }

        public ClassDeclarationSyntax GenerateBaseRequestClass(SourceFileContext ctx)
        {
            var cls = Class(
                Modifier.Public | Modifier.Abstract,
                BaseRequestTyp,
                ctx.Type(Typ.Generic(typeof(ClientServiceRequest<>), Typ.GenericParam("TResponse"))))
                .WithXmlDoc(XmlDoc.Summary($"A base abstract class for {ClassName} requests."));

            using (ctx.InClass(cls))
            {
                var serviceParam = Parameter(ctx.Type<IClientService>(), "service");
                var ctor = Ctor(Modifier.Protected, cls, BaseInitializer(serviceParam))(serviceParam)
                    .WithBody()
                    .WithXmlDoc(XmlDoc.Summary($"Constructs a new {ClassName}BaseServiceRequest instance."));

                cls = cls.AddMembers(ctor);

                var parameters = _discoveryDoc.Parameters.Select(p => new ParameterModel(p.Key, p.Value))
                    .OrderBy(p => p.Name)
                    .ToList();

                cls = cls.AddMembers(parameters.SelectMany(p => p.GenerateDeclarations(ctx)).ToArray());

                var initParameters = Method(Modifier.Protected | Modifier.Override, VoidType, "InitParameters")()
                    .WithBlockBody(
                        BaseExpression().Call("InitParameters")(),
                        parameters.Select(p => p.GenerateInitializer(ctx)).ToArray())
                    .WithXmlDoc(XmlDoc.Summary($"Initializes {ClassName} parameter list."));

                cls = cls.AddMembers(initParameters);
            }
            return cls;
        }

        // TODO: The rest...
        public XDocument GenerateProjectFile() =>
            new XDocument(new XElement("Project", new XAttribute("Sdk", "Microsoft.NET.Sdk"), new XAttribute("ToolsVersion", "15.0")));
    }
}
