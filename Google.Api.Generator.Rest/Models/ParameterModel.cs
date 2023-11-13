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
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Google.Api.Generator.Utils.Roslyn.RoslynExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Rest.Models
{
    public class ParameterModel
    {
        private readonly JsonSchema _schema;

        private RequestParameterType Location { get; }

        /// <summary>
        /// The name of the parameter as it appears in the Discovery doc.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The name to use when declaring a parameter in a method that
        /// corresponds with this parameter model. This is also used
        /// for underlying fields in non-auto properties.
        /// </summary>
        public string MethodParameterName { get; }

        /// <summary>
        /// The name to use when declaring a parameter in a constructor that
        /// corresponds with this parameter model.
        /// </summary>
        public string CtorParameterName { get; }

        /// <summary>
        /// The name to use in a request for a property representing the value of
        /// this parameter model.
        /// </summary>
        public string PropertyName { get; }
        private EnumModel EnumModel { get; }

        /// <summary>
        /// Indicates whether this parameter is required for the containing method or not.
        /// </summary>
        public bool IsRequired => _schema.Required ?? false;

        /// <summary>
        /// The description of the parameter, if any.
        /// </summary>
        public string Description => _schema.Description;

        /// <summary>
        /// The type of the parameter, which may be generated or a built-in type such as string.
        /// </summary>
        public Typ Typ { get; }

        /// <summary>
        /// Repeated optional enum parameters have always been incorrectly generated. We now add an extra property
        /// to make up for that.
        /// </summary>
        private bool IsRepeatedOptionalEnum => _schema.Repeated == true && EnumModel is object && _schema.Required != true;

        public ParameterModel(PackageModel package, string name, JsonSchema schema, Typ parentTyp)
        {
            Name = name;
            MethodParameterName = name.ToLocalVariableName(package);
            CtorParameterName = MethodParameterName;

            // It's unclear why these properties don't get the "__" treatment, but apparently they don't.
            PropertyName = name.ToMemberName(addUnderscoresToEscape: false);

            // Service is a property in our resources, and we use service as a constructor parameter
            // for that, so we need to add underscores in just a couple of places.
            if (name == "service")
            {
                PropertyName = "Service_";
                CtorParameterName = "service_";
            }

            Location = schema.Location switch
            {
                "query" => RequestParameterType.Query,
                "path" => RequestParameterType.Path,
                _ => throw new InvalidOperationException($"Unhandled parameter location: '{_schema.Location}'")
            };
            EnumModel = schema.Enum__ is object ? new EnumModel(package, parentTyp, name, schema) : null;
            _schema = schema;
            Typ = SchemaTypes.GetTypFromSchema(package, schema, name, currentTyp: parentTyp, inParameter: true);

            // Some validation for things that are theoretically feasible, but not currently supported.
            if (IsRequired)                
            {
                if (schema.Format is string format && (format.StartsWith("google-", StringComparison.Ordinal) || format == "date-time"))
                {
                    throw new InvalidOperationException($"Generation of required parameters for schema format '{format}' is currently not supported. Parameter '{name}' in '{parentTyp.FullName}'");
                }
            }

            if (schema.Repeated == true && Location == RequestParameterType.Path)
            {
                throw new InvalidOperationException($"Path parameters cannot be repeated. Parameter '{name}' in '{parentTyp.FullName}'");
            }
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateRegularProperties(SourceFileContext ctx)
        {
            var propertyType = ctx.Type(Typ);
            var locationExpression = ctx.Type<RequestParameterType>().Access(Location.ToString());
            var property = AutoProperty(Modifier.Public | Modifier.Virtual, propertyType, PropertyName, hasSetter: true, setterIsPrivate: IsRequired)
                .WithAttribute(ctx.Type<RequestParameterAttribute>())(Name, locationExpression);
            if (_schema.Description is string description)
            {
                var summary = XmlDoc.Summary(description);
                var docs = IsRepeatedOptionalEnum
                    ? new[] { summary, XmlDoc.Remarks($"Use this property to set a single value for the parameter, or ", IdentifierName(PropertyName + "List"), " to set multiple values. Do not set both properties.") }
                    : new[] { summary };
                property = property.WithXmlDoc(docs);
            }
            yield return property;

            if (IsRepeatedOptionalEnum)
            {
                var repeatedPropertyType = ctx.Type(Typ.Generic(Typ.Of(typeof(Repeatable<>)), Typ.GenericArgTyps.Single()));
                var repeatedProperty = AutoProperty(Modifier.Public | Modifier.Virtual, repeatedPropertyType, PropertyName + "List", hasSetter: true)
                    .WithAttribute(ctx.Type<RequestParameterAttribute>())(Name, locationExpression);
                if (_schema.Description is string description2)
                {
                    repeatedProperty = repeatedProperty.WithXmlDoc(
                        XmlDoc.Summary(description2),
                        XmlDoc.Remarks($"Use this property to set one or more values for the parameter. Do not set both this property and ", IdentifierName(PropertyName), "."));
                }
                yield return repeatedProperty;
            }
            if (EnumModel is object)
            {
                yield return EnumModel.GenerateDeclaration(ctx);
            }
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateDateTimeProperties(SourceFileContext ctx)
        {
            if (_schema.Type != "string" || _schema.Required == true || _schema.Properties is object ||
                _schema.AdditionalProperties is object || _schema.Repeated == true ||
                _schema.Enum__ is object || _schema.Ref__ is object)
            {
                throw new ArgumentException("Unable to handle complex date-time properties");
            }

            var propertyType = ctx.Type(Typ);
            var locationExpression = ctx.Type<RequestParameterType>().Access(Location.ToString());
            var valueParameter = Parameter(ctx.Type<DateTimeOffset?>(), "value");

            // DateTime values generate two properties: one raw as a string, one DateTimeOffset version, and one (obsolete) DateTime version.
            // The DateTimeOffset and string properties are slightly awkward, as we need to reference the raw property from the getters and setters of the DTO,
            // but we refer to the DTO property from the raw property's XML doc.
            var rawProperty = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), PropertyName + "Raw", hasSetter: true, setterIsPrivate: true)
                .WithAttribute(ctx.Type<RequestParameterAttribute>())(Name, locationExpression);
            if (_schema.Description is object)
            {
                rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary(_schema.Description));
            }

            var dtoProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type(typeof(DateTimeOffset?)), PropertyName + "DateTimeOffset")
                .WithGetBody(Return(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.ParseDateTimeToDateTimeOffset))(rawProperty)))
                .WithSetBody(rawProperty.Assign(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.FormatDateTimeOffsetToDateTime))(valueParameter)));
            if (_schema.Description is object)
            {
                dtoProperty = dtoProperty.WithXmlDoc(XmlDoc.Summary(_schema.Description));
            }
            rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary("String representation of ", dtoProperty, ", formatted for inclusion in the HTTP request."));

            yield return dtoProperty;
            yield return rawProperty;

            yield return Property(Modifier.Public | Modifier.Virtual, ctx.Type<DateTime?>(), PropertyName)
                .WithAttribute(ctx.Type<ObsoleteAttribute>())($"This property is obsolete and may behave unexpectedly; please use {PropertyName}DateTimeOffset instead.")
                .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTime>()), " representation of ", dtoProperty, "."))
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

            var propertyType = ctx.Type(Typ);
            var locationExpression = ctx.Type<RequestParameterType>().Access(Location.ToString());
            // The type of "value" is irrelevant to our uses of this, so it's okay that in the raw property it should be a string.
            var valueParameter = Parameter(ctx.Type<object>(), "value");

            // For google-datetime properties, we generate:
            // - Three properties: Xyz (object), XyzRaw (string, auto-property), XyzDateTimeOffset (DateTimeOffset?)
            // - A field to back Xyz.
            //
            // Each property setter will set the field for Xyz and XyzRaw.
            var objectField = Field(Modifier.Private, ctx.Type<object>(), $"_{MethodParameterName}");

            var rawProperty = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), PropertyName + "Raw", hasSetter: true, setterIsPrivate: true)
                .WithAttribute(ctx.Type<RequestParameterAttribute>())(Name, locationExpression);

            var dtoProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<DateTimeOffset?>(), PropertyName + "DateTimeOffset")
                // Note: we could just cast objectField and return the result, but:
                // - This is consistent with data model properties
                // - Our we end up with a stray semi-colon at the end of the overall property declaration for non-obvious reasons
                .WithGetBody(Return(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.ParseGoogleDateTimeToDateTimeOffset))(rawProperty)))
                .WithSetBody(
                    rawProperty.Assign(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.FormatDateTimeOffsetToGoogleDateTime))(valueParameter)),
                    objectField.Assign(valueParameter)
                );
            if (_schema.Description is object)
            {
                //dtoProperty = dtoProperty.WithXmlDoc(XmlDoc.Summary(_schema.Description));
            }
            rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary("String representation of ", dtoProperty, ", formatted for inclusion in the HTTP request."));

            var objectProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<object>(), PropertyName)
                .WithAttribute(ctx.Type<ObsoleteAttribute>())($"This property is obsolete and may behave unexpectedly; please use {PropertyName}DateTimeOffset instead.")
                .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<object>()), " representation of ", rawProperty, "."))
                .WithGetBody(Return(objectField))
                .WithSetBody(
                    rawProperty.Assign(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.ConvertToString))(valueParameter)),
                    objectField.Assign(valueParameter)
                );

            yield return objectField;

            yield return rawProperty;
            yield return objectProperty;
            yield return dtoProperty;
        }

        public IEnumerable<MemberDeclarationSyntax> GenerateDeclarations(SourceFileContext ctx) =>
            _schema.Format switch
            {
                "date-time" => GenerateDateTimeProperties(ctx),
                "google-datetime" => GenerateGoogleDateTimeProperties(ctx),
                _ => GenerateRegularProperties(ctx)
            };

        internal object GenerateInitializer(SourceFileContext ctx)
        {
            var parameterCtor = New(ctx.Type<Google.Apis.Discovery.Parameter>())()
                .WithInitializer(
                    new ObjectInitExpr("Name", Name),
                    new ObjectInitExpr("IsRequired", IsRequired),
                    new ObjectInitExpr("ParameterType", _schema.Location),
                    new ObjectInitExpr("DefaultValue", string.IsNullOrEmpty(_schema.Default__) ? (object) Null : _schema.Default__),
                    new ObjectInitExpr("Pattern", PatternCode(_schema.Pattern)));
            return IdentifierName("RequestParameters").Call("Add")(Name, parameterCtor);

            object PatternCode(string pattern)
            {
                if (pattern is null)
                {
                    return Null;
                }
                // Escape double-quotes to "double double-quotes".
                var escaped = pattern.Replace("\"", "\"\"");
                return LiteralExpression(SyntaxKind.StringLiteralExpression, Literal($"@\"{escaped}\"", pattern));
            }
        }
    }
}
