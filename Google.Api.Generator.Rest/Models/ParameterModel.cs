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
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Google.Api.Generator.Utils.Roslyn.RoslynExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Rest.Models
{
    public class ParameterModel
    {
        private readonly JsonSchema _schema;
        private readonly PackageModel _package;

        public RequestParameterType Location { get; }
        public string Name { get; }
        public string CodeParameterName { get; }
        public string PropertyName { get; }
        public EnumModel EnumModel { get; }
        public bool IsRequired => _schema.Required ?? false;
        public bool IsRepeated => _schema.Repeated ?? false;
        public string Description => _schema.Description;
        public Typ Typ { get; }

        public ParameterModel(PackageModel package, string name, JsonSchema schema, Typ parentTyp)
        {
            _package = package;
            Name = name;
            CodeParameterName = name.ToLocalVariableName(package);

            // It's unclear why these properties don't get the "__" treatment, but apparently they don't.
            PropertyName = name.ToMemberName(addUnderscoresToEscape: false);
            Location = schema.Location switch
            {
                "query" => RequestParameterType.Query,
                "path" => RequestParameterType.Path,
                _ => throw new InvalidOperationException($"Unhandled parameter location: '{_schema.Location}'")
            };
            EnumModel = schema.Enum__ is object ? new EnumModel(name, schema) : null;
            _schema = schema;
            Typ = SchemaTypes.GetTypFromSchema(package, schema, name, currentTyp: parentTyp, inParameter: true);
        }

        private PropertyDeclarationSyntax GenerateProperty(SourceFileContext ctx)
        {
            var propertyType = ctx.Type(Typ);
            var locationExpression = ctx.Type<RequestParameterType>().Access(Location.ToString());
            var property = AutoProperty(Modifier.Public | Modifier.Virtual, propertyType, PropertyName, hasSetter: true, setterIsPrivate: IsRequired)
                .WithAttribute(ctx.Type<RequestParameterAttribute>())(Name, locationExpression);
            if (_schema.Description is string description)
            {
                property = property.WithXmlDoc(XmlDoc.Summary(description));
            }
            return property;
        }

        public IEnumerable<MemberDeclarationSyntax> GenerateDeclarations(SourceFileContext ctx)
        {
            yield return GenerateProperty(ctx);
            if (EnumModel is object)
            {
                yield return EnumModel.GenerateDeclaration(ctx);
            }
        }

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
