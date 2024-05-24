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
using Google.Apis.Discovery.v1.Data;
using Google.Apis.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    public class ResourceModel
    {
        /// <summary>
        /// The name as it appears as the key within the JSON dictionary.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The name to use when referring to this resource within another resource.
        /// </summary>
        private string PropertyName { get; }

        /// <summary>
        /// The methods declared in this resource.
        /// </summary>
        private IReadOnlyList<MethodModel> Methods { get; }

        /// <summary>
        /// The resources nested within this resource.
        /// </summary>
        private IReadOnlyList<ResourceModel> Subresources { get; }

        /// <summary>
        /// The type generated to represent this resource.
        /// </summary>
        public Typ Typ { get; }

        public ResourceModel(PackageModel package, ResourceModel parent, string name, RestResource discoveryResource)
        {
            Name = name;
            PropertyName = name.ToMemberName();
            string className = name.ToClassName(package, parent?.Typ.Name) + "Resource";
            Typ = parent is null ? Typ.Manual(package.PackageName, className) : Typ.Nested(parent.Typ, className);
            Subresources = discoveryResource.Resources.ToReadOnlyList(pair => new ResourceModel(package, this, pair.Key, pair.Value));
            Methods = discoveryResource.Methods.ToReadOnlyList(pair => new MethodModel(package, this, pair.Key, pair.Value));
        }

        internal IEnumerable<MethodModel> GetAllMethodsRecursively() =>
            Methods.Concat(Subresources.SelectMany(sr => sr.GetAllMethodsRecursively()));

        public PropertyDeclarationSyntax GenerateProperty(SourceFileContext ctx) =>
            AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type(Typ), PropertyName)
                .WithXmlDoc(XmlDoc.Summary($"Gets the {PropertyName} resource."));

        public ClassDeclarationSyntax GenerateClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, Typ)
                .WithXmlDoc(XmlDoc.Summary($"The \"{Name}\" collection of methods."));
            using (ctx.InClass(Typ))
            {
                // TODO: validate that lower camel case is the right option here.
                var resourceString = Field(Modifier.Private | Modifier.Const, ctx.Type<string>(), "Resource")
                    .WithInitializer(Name.ToLowerCamelCase(upperAfterDigit: null));

                var service = Field(Modifier.Private | Modifier.Readonly, ctx.Type<IClientService>(), "service")
                    .WithXmlDoc(XmlDoc.Summary("The service which this resource belongs to."));

                var subresources = Subresources.Select(subresource => (property: subresource.GenerateProperty(ctx), resource: subresource));

                var ctorParameter = Parameter(ctx.Type<IClientService>(), "service");
                var ctor = Ctor(Modifier.Public, cls)(ctorParameter)
                    .WithBlockBody(
                        new[] { service.AssignThisQualified(ctorParameter) }
                            .Concat(subresources.Select(pair => pair.property.Assign(New(ctx.Type(pair.resource.Typ))(ctorParameter))))
                            .ToArray()
                    )
                    .WithXmlDoc(XmlDoc.Summary("Constructs a new resource."));

                cls = cls.AddMembers(resourceString, service, ctor);

                foreach (var subresourceProperty in subresources)
                {
                    cls = cls.AddMembers(subresourceProperty.property, subresourceProperty.resource.GenerateClass(ctx));
                }

                foreach (var method in Methods)
                {
                    cls = cls.AddMembers(method.GenerateDeclarations(ctx).ToArray());
                }
            }
            return cls;
        }
    }
}
