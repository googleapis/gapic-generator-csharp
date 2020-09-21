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
using Google.Apis.Util;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    /// <summary>
    /// Model for a member of <see cref="EnumModel"/>.
    /// </summary>
    public class EnumMemberModel
    {
        public string MemberName { get; }
        public string OriginalValue { get; }
        public string Description { get; }

        public EnumMemberModel(string value, string description)
        {
            OriginalValue = value;
            MemberName = value.ToMemberName();
            Description = description;
        }

        public EnumMemberDeclarationSyntax GenerateDeclaration(SourceFileContext ctx)
        {
            var declaration =
            EnumMember(MemberName)
                .WithAttribute(ctx.Type<StringValueAttribute>())(OriginalValue);
            if (Description is object)
            {
                declaration = declaration.WithXmlDoc(XmlDoc.Summary(Description));
            }
            return declaration;
        }
    }
}
