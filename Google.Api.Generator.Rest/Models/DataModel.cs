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

        public PackageModel Package { get; }

        /// <summary>
        /// The ID for the model, used in "$ref" properties.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The parent of this data model, if any. (This could be a method
        /// or another data model.)
        /// </summary>
        public object Parent { get; }
        public string Name { get; }
        public Typ Typ { get; }
        public IReadOnlyList<DataModel> Children { get; }
        public IReadOnlyList<DataPropertyModel> Properties { get; }

        public DataModel(PackageModel package, object parent, string name, JsonSchema schema)
        {
            // TODO: Not sure about this...
            Id = name;
            Package = package;
            Parent = parent;
            Name = name;
            // FIXME: Nested models
            Typ = Typ.Manual(Package.PackageName, Name);
            Properties = schema.Properties.ToReadOnlyList(pair => new DataPropertyModel(this, pair.Key, pair.Value));
            _schema = schema;
        }

        public ClassDeclarationSyntax GenerateClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, Typ, Parent is null ? Array.Empty<TypeSyntax>() : new[] { ctx.Type<IDirectResponseSchema>() });
            using (ctx.InClass(Typ))
            {
                if (_schema.Description is string description)
                {
                    cls = cls.WithXmlDoc(XmlDoc.Summary(description));
                    cls = cls.AddMembers(Properties.Select(p => p.GenerateDeclaration(ctx)).ToArray());
                }
            }

            // TODO: Add ETag if it doesn't otherwise exist. (Why?)
            return cls;
        }

    }
}

