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
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    public class ResourceModel
    {
        public PackageModel Package { get; }

        /// <summary>
        /// The name as it appears as the key within the JSON dictionary.
        /// </summary>
        public string Name { get; }

        public string ClassName { get; }

        public string PropertyName { get; }

        public IReadOnlyList<MethodModel> Methods { get; }
        public IReadOnlyList<ResourceModel> Subresources { get; }
        public ResourceModel Parent { get; }

        public Typ Typ { get; }

        public ResourceModel(PackageModel package, ResourceModel parent, string name, RestResource discoveryResource)
        {
            Package = package;
            Name = name;
            PropertyName = package.ToClassName(name);
            ClassName = $"{PropertyName}Resource";
            Typ = parent is null ? Typ.Manual(package.PackageName, ClassName) : Typ.Nested(parent.Typ, ClassName);
            Subresources = discoveryResource.Resources.ToReadOnlyList(pair => new ResourceModel(package, this, pair.Key, pair.Value));
            Methods = discoveryResource.Methods.ToReadOnlyList(pair => new MethodModel(package, pair.Key, pair.Value));
        }

        public PropertyDeclarationSyntax GenerateProperty(SourceFileContext ctx) => 
            AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type(Typ), PropertyName)
                .WithXmlDoc(XmlDoc.Summary($"Gets the {PropertyName} resource."));

        public ClassDeclarationSyntax GenerateClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, Typ)
                .WithXmlDoc(XmlDoc.Summary($"The {Name} collection of methods."));
            using (ctx.InClass(cls))
            {
                var resourceString = Field(Modifier.Private | Modifier.Const, ctx.Type<string>(), "Resource")
                    // TODO: Validate this does the right thing. It's "codeName" in the Python generator.
                    .WithInitializer(Name);

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
                    cls = cls.AddMembers(method.GenerateMethodDeclaration(ctx));
                }
            }
            return cls;
        }
    }
}
