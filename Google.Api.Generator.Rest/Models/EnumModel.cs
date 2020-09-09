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
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    /// <summary>
    /// Models an enum created for a parameter (and maybe other ways later...)
    /// </summary>
    public class EnumModel
    {
        public string Description { get; }
        public IReadOnlyList<EnumMemberModel> Members { get; }
        public string TypeName { get; }

        public EnumModel(string name, JsonSchema schema)
        {
            IList<string> values = schema.Enum__;
            IList<string> description = schema.EnumDescriptions;
            Description = schema.Description;
            TypeName = name.ToUpperCamelCase() + "Enum";
            Members = schema.Enum__
                .Zip(schema.EnumDescriptions)
                .ToReadOnlyList(pair => new EnumMemberModel(pair.First, pair.Second));
        }


        public EnumDeclarationSyntax GenerateDeclaration(SourceFileContext ctx)
        {
            var declaration = Enum(Modifier.Public, Typ.Nested(ctx.CurrentTyp, TypeName, isEnum: true))
                (Members.Select(m => m.GenerateDeclaration(ctx)).ToArray());

            if (Description is string description)
            {
                declaration = declaration.WithXmlDoc(XmlDoc.Summary(description));
            }
            return declaration;
        }
    }
}
