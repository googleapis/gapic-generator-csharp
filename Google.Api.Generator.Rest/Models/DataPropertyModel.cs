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
        private DataModel Parent { get; }

        /// <summary>
        /// The name in the discovery doc
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// The name in the C# code.
        /// </summary>
        private string PropertyName { get; }

        public DataPropertyModel(DataModel parent, string name, JsonSchema schema)
        {
            Parent = parent;
            Name = name;
            // Not sure why this special-casing exists in the template, but it does...
            PropertyName = name == "etag" && parent.Parent is null ? "ETag" : name.ToMemberName();

            // Avoid collisions between properties and their containing classes.
            if (PropertyName == parent.Typ.Name)
            {
                PropertyName += "Value";
            }
            // Avoid collisions with our own ETag property in data models.
            // Note that the standard etag field is named with all lowercase.
            // Other etag fields named with different casing do not represent the
            // resource version, instead they are properties of the resource itself,
            // for instance, if the resource represents a request or response.
            if (name != "etag" && name.Equals("etag", StringComparison.OrdinalIgnoreCase))
            {
                PropertyName = "ETag__";
            }
            _schema = schema;
        }

        public IEnumerable<MemberDeclarationSyntax> GeneratePropertyDeclarations(SourceFileContext ctx) =>
            _schema.Format switch
            {
                "date-time" => Properties.GenerateDateTimeProperties(ctx, _schema, Name, PropertyName, AttributeWithArgs(ctx.Type<JsonPropertyAttribute>(), Name)),
                "google-datetime" => Properties.GenerateGoogleDateTimeProperties(ctx, _schema, Name, PropertyName, AttributeWithArgs(ctx.Type<JsonPropertyAttribute>(), Name)),
                _ => GenerateRegularProperty(ctx)
            };

        private IEnumerable<MemberDeclarationSyntax> GenerateRegularProperty(SourceFileContext ctx)
        {
            var propertyTyp = SchemaTypes.GetTypFromSchema(Parent.Package, _schema, Name, ctx.CurrentTyp, inParameter: false);
            var property = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type(propertyTyp), PropertyName, hasSetter: true)
                .WithAttribute(ctx.Type<JsonPropertyAttribute>())(Name);
            if (_schema.Description is object)
            {
                property = property.WithXmlDoc(XmlDoc.Summary(_schema.Description));
            }
            return new[] { property };
        }

        public IEnumerable<ClassDeclarationSyntax> GenerateAnonymousModels(SourceFileContext ctx)
        {
            if (_schema.AdditionalProperties is object && DataModel.GetProperties(_schema.AdditionalProperties) is object)
            {
                var dataModel = new DataModel(Parent.Package, Parent, (Name + "Element").ToAnonymousModelClassName(Parent.Package, Parent.Typ.Name, true), _schema.AdditionalProperties);
                yield return dataModel.GenerateClass(ctx);
            }
            else if (DataModel.GetProperties(_schema) is object)
            {
                var dataModel = new DataModel(Parent.Package, Parent, Name.ToAnonymousModelClassName(Parent.Package, Parent.Typ.Name, false), _schema);
                yield return dataModel.GenerateClass(ctx);
            }
        }
    }
}
