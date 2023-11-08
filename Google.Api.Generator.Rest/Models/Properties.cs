// Copyright 2023 Google LLC
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
using static Google.Api.Generator.Utils.Roslyn.RoslynExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Rest.Models;

internal static class Properties
{
    internal static IEnumerable<MemberDeclarationSyntax> GenerateDateTimeProperties(SourceFileContext ctx, JsonSchema schema, string name, string propertyName, params AttributeSyntax[] rawPropertyAttributes)
    {
        CheckNotComplexSchema(schema);

        // DateTime values generate three properties: one raw as a string, one DateTime version, and one DateTimeOffset version.
        var rawProperty = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), propertyName + "Raw", hasSetter: true);

        foreach (var attr in rawPropertyAttributes)
        {
            rawProperty = rawProperty.WithAttribute(attr);
        }
            
        if (schema.Description is object)
        {
            rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary(schema.Description));
        }
        yield return rawProperty;

        var valueParameter = Parameter(ctx.Type<DateTimeOffset?>(), "value");

        var dtoProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type(typeof(DateTimeOffset?)), propertyName + "DateTimeOffset")
            .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
            .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTimeOffset>()), " representation of ", rawProperty, "."))
            .WithGetBody(Return(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.ParseDateTimeToDateTimeOffset))(rawProperty)))
            .WithSetBody(rawProperty.Assign(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.FormatDateTimeOffsetToDateTime))(valueParameter)));
        yield return dtoProperty;

        yield return Property(Modifier.Public | Modifier.Virtual, ctx.Type<DateTime?>(), propertyName)
            .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
            .WithAttribute(ctx.Type<ObsoleteAttribute>())($"This property is obsolete and may behave unexpectedly; please use {propertyName}DateTimeOffset instead.")
            .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTime>()), " representation of ", rawProperty, "."))
            .WithGetBody(Return(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.GetDateTimeFromString))(rawProperty)))
            .WithSetBody(rawProperty.Assign(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.GetStringFromDateTime))(valueParameter)));
    }

    internal static IEnumerable<MemberDeclarationSyntax> GenerateGoogleDateTimeProperties(SourceFileContext ctx, JsonSchema schema, string name, string propertyName, params AttributeSyntax[] rawPropertyAttributes)
    {
        CheckNotComplexSchema(schema);

        // For google-datetime properties, we generate:
        // - Three properties: Xyz (object), XyzRaw (string), XyzDateTimeOffset (DateTimeOffset?)
        // - Two fields, to back Xyz and XyzRaw
        //
        // Each property setter will set both fields.

        // The type of "value" is irrelevant to our uses of this, so it's okay that in the raw property it should be a string.
        var valueParameter = Parameter(ctx.Type<object>(), "value");
        var rawField = Field(Modifier.Private, ctx.Type<string>(), $"_{name}Raw");
        var objectField = Field(Modifier.Private, ctx.Type<object>(), $"_{name}");

        var rawProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), propertyName + "Raw")
            .WithGetBody(Return(rawField))
            .WithSetBody(
                objectField.Assign(ctx.Type(typeof(Utilities)).Call(nameof(Utilities.DeserializeForGoogleFormat))(valueParameter)),
                rawField.Assign(valueParameter)
            );

        foreach (var attr in rawPropertyAttributes)
        {
            rawProperty = rawProperty.WithAttribute(attr);
        }

        if (schema.Description is object)
        {
            rawProperty = rawProperty.WithXmlDoc(XmlDoc.Summary(schema.Description));
        }

        var dtoProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<DateTimeOffset?>(), propertyName + "DateTimeOffset")
            .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
            .WithXmlDoc(XmlDoc.Summary(XmlDoc.SeeAlso(ctx.Type<DateTimeOffset>()), " representation of ", rawProperty, "."))
            .WithGetBody(Return(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.ParseGoogleDateTimeToDateTimeOffset))(rawProperty)))
            .WithSetBody(rawProperty.Assign(ctx.Type(typeof(DiscoveryFormat)).Call(nameof(DiscoveryFormat.FormatDateTimeOffsetToGoogleDateTime))(valueParameter)));

        var objectProperty = Property(Modifier.Public | Modifier.Virtual, ctx.Type<object>(), propertyName)
            .WithAttribute(ctx.Type<JsonIgnoreAttribute>())()
            .WithAttribute(ctx.Type<ObsoleteAttribute>())($"This property is obsolete and may behave unexpectedly; please use {propertyName}DateTimeOffset instead.")
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

    private static void CheckNotComplexSchema(JsonSchema schema)
    {
        if (schema.Type != "string" || schema.Required == true || schema.Properties is object ||
            schema.AdditionalProperties is object || schema.Repeated == true ||
            schema.Enum__ is object || schema.Ref__ is object)
        {
            throw new ArgumentException($"Unable to handle complex {schema.Format} properties");
        }
    }
}
