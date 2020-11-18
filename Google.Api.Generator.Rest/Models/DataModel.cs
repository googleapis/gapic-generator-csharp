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
using Google.Apis.Requests;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    public class DataModel
    {
        private readonly JsonSchema _schema;

        /// <summary>
        /// The package this model is part of.
        /// </summary>
        public PackageModel Package { get; }

        private string Name { get; }

        /// <summary>
        /// The ID for the model, used in "$ref" properties.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The parent of this data model, if any. (This is non-null if and only
        /// if this data model is nested within another.)
        /// </summary>
        public DataModel Parent { get; }

        /// <summary>
        /// The type that will be generated for this data model.
        /// </summary>
        public Typ Typ { get; }

        private bool IsArray => _schema.Type == "array";

        /// <summary>
        /// The properties within this data model.
        /// </summary>
        private IReadOnlyList<DataPropertyModel> Properties { get; }

        /// <summary>
        /// Placeholder models aren't generated, and are represented as just "object" when referenced.
        /// </summary>
        public bool IsPlaceholder => _schema.Properties is null && _schema.Items is null;

        public DataModel(PackageModel package, DataModel parent, string name, JsonSchema schema)
        {
            _schema = schema;
            Name = name;
            Id = schema.Id;
            Package = package;
            Parent = parent;
            // TODO: Move this logic into Naming somehow, but noting that we *don't* escape keywords here. <sigh>
            string className = schema.Id is object && IsArray ? name + "Items" : name;
            className = className.ToUpperCamelCase(upperAfterDigit: null);
            if (className == parent?.Typ.Name)
            {
                className += "Schema";
            }
            Typ = parent is null ? Typ.Manual(Package.PackageName + ".Data", className) : Typ.Nested(parent.Typ, className);

            // We may get a JsonSchema for an array as a nested model. Just use the properties from schema.Items for simplicity.
            Properties = GetProperties(schema).ToReadOnlyList(pair => new DataPropertyModel(this, pair.Key, pair.Value));
        }

        /// <summary>
        /// Determines how code referring to this data model should be refer to it; this takes
        /// into account whether it's a placeholder, an array etc.
        /// </summary>
        internal Typ GetTypForReference()
        {
            var ret = IsPlaceholder ? Typ.Of<object>() : Typ;
            if (IsArray)
            {
                ret = Typ.Generic(typeof(IList<>), ret);
            }
            if (_schema.AdditionalProperties is object)
            {
                ret = SchemaTypes.GetTypFromAdditionalProperties(Package, _schema.AdditionalProperties, Name, ret, inParameter: false);                
            }
            return ret;
        }

        internal static IDictionary<string, JsonSchema> GetProperties(JsonSchema schema) =>
            schema.Properties ?? (schema.Items is object ? GetProperties(schema.Items) : null);

        public ClassDeclarationSyntax GenerateClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, Typ, Parent is null ? new[] { ctx.Type<IDirectResponseSchema>() } : Array.Empty<TypeSyntax>());
            using (ctx.InClass(Typ))
            {
                if (_schema.Description is string description)
                {
                    cls = cls.WithXmlDoc(XmlDoc.Summary(description));
                }
                cls = cls.AddMembers(Properties.SelectMany(p => p.GeneratePropertyDeclarations(ctx)).ToArray());

                // Top-level data models automatically have an etag property if one isn't otherwise generated.
                if (Parent is null && !Properties.Any(p => p.Name == "etag"))
                {
                    var etag = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), "ETag", hasSetter: true)
                        .WithXmlDoc(XmlDoc.Summary("The ETag of the item."));
                    cls = cls.AddMembers(etag);
                }

                cls = cls.AddMembers(Properties.SelectMany(p => p.GenerateAnonymousModels(ctx)).ToArray());
            }
            return cls;
        }

    }
}

