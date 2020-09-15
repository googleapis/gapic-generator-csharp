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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
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

        public PropertyDeclarationSyntax GenerateDeclaration(SourceFileContext ctx)
        {
            // FIXME: Type, and handle DateTime? differently.
            var property = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), PropertyName, hasSetter: true)
                .WithAttribute(ctx.Type<JsonPropertyAttribute>())(Name);
            if (_schema.Description is object)
            {
                property = property.WithXmlDoc(XmlDoc.Summary(_schema.Description));
            }
            return property;
        }
    }
}
