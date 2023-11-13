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
                "date-time" => GenerateDateTimeProperties(ctx),
                "google-datetime" => GenerateGoogleDateTimeProperties(ctx),
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

        private IEnumerable<MemberDeclarationSyntax> GenerateDateTimeProperties(SourceFileContext ctx)
        {
            if (_schema.Type != "string" || _schema.Required == true || _schema.Properties is object ||
                _schema.AdditionalProperties is object || _schema.Repeated == true ||
                _schema.Enum__ is object || _schema.Ref__ is object)
            {
                throw new ArgumentException("Unable to handle complex date-time properties");
            }
            // DateTime values generate two properties: one raw as a string, and one DateTime version.
            var rawProperty = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), PropertyName + "Raw", hasSetter: true)
                .WithAttribute(ctx.Type<JsonPropertyAttribute>())(Name);
            if (_schema.Description is object)
            {
                rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary(_schema.Description));
            }
            yield return rawProperty;

            var valueParameter = Parameter(ctx.Type<DateTimeOffset?>(), "value");

            var dtoProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type(typeof(DateTimeOffset?)), PropertyName + "DateTimeOffset")
                .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
                .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTimeOffset>()), " representation of ", rawProperty, "."))
                .WithGetBody(Return(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.ParseDateTimeToDateTimeOffset))(rawProperty)))
                .WithSetBody(rawProperty.Assign(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.FormatDateTimeOffsetToDateTime))(valueParameter)));
            yield return dtoProperty;

            yield return Property(Modifier.Public | Modifier.Virtual, ctx.Type<DateTime?>(), PropertyName)
                .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
                .WithAttribute(ctx.Type<ObsoleteAttribute>())($"This property is obsolete and may behave unexpectedly; please use {PropertyName}DateTimeOffset instead.")
                .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTime>()), " representation of ", rawProperty, "."))
                .WithGetBody(Return(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.GetDateTimeFromString))(rawProperty)))
                .WithSetBody(rawProperty.Assign(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.GetStringFromDateTime))(valueParameter)));
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateGoogleDateTimeProperties(SourceFileContext ctx)
        {
            if (_schema.Type != "string" || _schema.Required == true || _schema.Properties is object ||
                _schema.AdditionalProperties is object || _schema.Repeated == true ||
                _schema.Enum__ is object || _schema.Ref__ is object)
            {
                throw new ArgumentException("Unable to handle complex google-datetime properties");
            }

            // For google-datetime properties, we generate:
            // - Three properties: Xyz (object), XyzRaw (string), XyzDateTimeOffset (DateTimeOffset?)
            // - Two fields, to back Xyz and XyzRaw
            //
            // Each property setter will set both fields.

            // The type of "value" is irrelevant to our uses of this, so it's okay that in the raw property it should be a string.
            var valueParameter = Parameter(ctx.Type<object>(), "value");
            var rawField = Field(Modifier.Private, ctx.Type<string>(), $"_{Name}Raw");
            var objectField = Field(Modifier.Private, ctx.Type<object>(), $"_{Name}");

            var rawProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), PropertyName + "Raw")
                .WithAttribute(ctx.Type<JsonPropertyAttribute>())(Name)
                .WithGetBody(Return(rawField))
                .WithSetBody(
                    objectField.Assign(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.DeserializeForGoogleFormat))(valueParameter)),
                    rawField.Assign(valueParameter)
                );
            if (_schema.Description is object)
            {
                rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary(_schema.Description));
            }

            var dtoProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<DateTimeOffset?>(), PropertyName + "DateTimeOffset")
                .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
                .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTimeOffset>()), " representation of ", rawProperty, "."))
                .WithGetBody(Return(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.ParseGoogleDateTimeToDateTimeOffset))(rawProperty)))
                .WithSetBody(rawProperty.Assign(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.FormatDateTimeOffsetToGoogleDateTime))(valueParameter)));

            var objectProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<object>(), PropertyName)
                .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
                .WithAttribute(ctx.Type<ObsoleteAttribute>())($"This property is obsolete and may behave unexpectedly; please use {PropertyName}DateTimeOffset instead.")
                .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<object>()), " representation of ", rawProperty, "."))
                .WithGetBody(Return(objectField))
                .WithSetBody(
                    rawField.Assign(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.SerializeForGoogleFormat))(valueParameter)),
                    objectField.Assign(valueParameter)
                );

            yield return rawField;
            yield return objectField;

            yield return rawProperty;
            yield return objectProperty;
            yield return dtoProperty;
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
