// Copyright 2018 Google Inc. All Rights Reserved.
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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.RoslynUtils
{
    internal static class RoslynBuilder
    {
        public static NamespaceDeclarationSyntax Namespace(string ns) => NamespaceDeclaration(IdentifierName(ns));

        public static ClassDeclarationSyntax Class(Modifier modifier, Typ typ, TypeSyntax baseType = null)
        {
            var cls = ClassDeclaration(typ.Name).AddModifiers(modifier.ToSyntaxTokens());
            if (baseType != null)
            {
                cls = cls.WithBaseList(BaseList(SingletonSeparatedList<BaseTypeSyntax>(SimpleBaseType(baseType))));
            }
            return cls;
        }
    }
}
