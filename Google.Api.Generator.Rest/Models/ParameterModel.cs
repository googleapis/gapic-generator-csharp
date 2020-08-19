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
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Google.Api.Generator.Utils.Roslyn.RoslynExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Rest.Models
{
    public class ParameterModel
    {
        private readonly JsonSchema _schema;

        public string Name { get; }
        public string PropertyName { get; }

        public ParameterModel(string name, JsonSchema schema)
        {
            Name = name;
            PropertyName = name.ToUpperCamelCase();
            _schema = schema;
        }

        public PropertyDeclarationSyntax GenerateProperty(SourceFileContext ctx)
        {
            var property = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), PropertyName)
                // TODO: Attribute arguments
                // TODO: Default, Minimum, Maximum? Commented out...
                .WithAttribute(ctx.Type<RequestParameterAttribute>());
            if (_schema.Description is string description)
            {
                property = property.WithXmlDoc(XmlDoc.Summary(description));
            }
            return property;
        }

        // TODO: Arguments
        internal object GenerateInitializer(SourceFileContext ctx) =>
            IdentifierName("RequestParameters").Call("Add")(Name);
    }
}
