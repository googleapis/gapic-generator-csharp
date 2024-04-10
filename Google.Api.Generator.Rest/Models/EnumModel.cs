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
        /// <summary>
        /// Description of the enum within the Discovery doc, if any.
        /// </summary>
        private string Description { get; }

        /// <summary>
        /// The members of the enum.
        /// </summary>
        private IReadOnlyList<EnumMemberModel> Members { get; }

        /// <summary>
        /// The name of the generated enum type.
        /// </summary>
        private string TypeName { get; }

        public EnumModel(PackageModel package, Typ parentTyp, string name, JsonSchema schema)
        {
            IList<string> values = schema.Enum__;
            IList<string> description = schema.EnumDescriptions;
            Description = schema.Description;
            TypeName = name.ToMemberName(addUnderscoresToEscape: false) + "Enum";
            // The exact value of the key doesn't particularly matter, so long as it's unique.
            // This should be fine.
            string enumStorageKey = $"{parentTyp.FullName}.{TypeName}";
            Members = schema.Enum__
                .Zip(schema.EnumDescriptions ?? Enumerable.Repeat((string) null, schema.Enum__.Count), (text, description) => (text, description))
                .ToReadOnlyList(pair => new EnumMemberModel(pair.text, pair.description, package.PackageEnumStorage.GetOrAddEnumValue(enumStorageKey, pair.text)));
        }

        public EnumDeclarationSyntax GenerateDeclaration(SourceFileContext ctx) =>
            Enum(Modifier.Public, Typ.Nested(ctx.CurrentTyp, TypeName, isEnum: true))
                (Members.Select(m => m.GenerateDeclaration(ctx)).ToArray())
                .MaybeWithXmlDoc(XmlDoc.MaybeSummary(Description));
    }
}
