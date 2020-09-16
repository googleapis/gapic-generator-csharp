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
using Google.Apis.Util;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    /// <summary>
    /// Model for a property within a <see cref="DataModel"/>.
    /// </summary>
    public class DataPropertyModel
    {
        private readonly JsonSchema _schema;

        /// <summary>
        /// The data model containing this property.
        /// </summary>
        public DataModel Parent { get; }

        /// <summary>
        /// The name in the discovery doc
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// The name in the C# code.
        /// </summary>
        public string PropertyName { get; }

        public DataPropertyModel(DataModel parent, string name, JsonSchema schema)
        {
            Parent = parent;
            Name = name;
            // Not sure why this special-casing exists in the template, but it does...
            PropertyName = name == "etag" && parent.Parent is null ? "ETag" : name.ToUpperCamelCase();
            _schema = schema;
        }

        public IEnumerable<PropertyDeclarationSyntax> GeneratePropertyDeclarations(SourceFileContext ctx)
        {
            var propertyTyp = SchemaTypes.GetTypFromSchema(Parent.Package, _schema, Name, ctx.CurrentTyp);
            if (propertyTyp.FullName == "System.Nullable<System.DateTime>")
            {
                // DateTime values generate two properties: one raw as a string, and one DateTime version.
                var rawProperty = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), PropertyName + "Raw", hasSetter: true)
                    .WithAttribute(ctx.Type<JsonPropertyAttribute>())(Name);
                if (_schema.Description is object)
                {
                    rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary(_schema.Description));
                }
                yield return rawProperty;

                var valueParameter = Parameter(ctx.Type(propertyTyp), "value");
                yield return Property(Modifier.Public | Modifier.Virtual, ctx.Type(propertyTyp), PropertyName)
                    .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
                    .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTime>()), " representation of ", rawProperty, "."))
                    .WithGetBody(Return(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.GetDateTimeFromString))(rawProperty)))
                    .WithSetBody(rawProperty.Assign(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.GetStringFromDateTime))(valueParameter)));
            }
            else
            {
                var property = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type(propertyTyp), PropertyName, hasSetter: true)
                    .WithAttribute(ctx.Type<JsonPropertyAttribute>())(Name);
                if (_schema.Description is object)
                {
                    property = property.WithXmlDoc(XmlDoc.Summary(_schema.Description));
                }
                yield return property;
            }
        }

        public IEnumerable<ClassDeclarationSyntax> GenerateAnonymousModels(SourceFileContext ctx)
        {
            if ((_schema.Properties ?? _schema.Items?.Properties) is null)
            {
                yield break;
            }
            var dataModel = new DataModel(Parent.Package, Parent, PropertyName + "Data", _schema);
            yield return dataModel.GenerateClass(ctx);
        }
    }
}
