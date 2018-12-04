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

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Api.Generator.RoslynUtils
{
    [Flags]
    internal enum Modifier
    {
        DontCare = 0,
        NoModifiers = 0,

        Public = 0x1,
        Static = 0x2,
        Private = 0x4,
        Readonly = 0x8,
        Async = 0x10,
        Sealed = 0x20,
        Partial = 0x40,
        Abstract = 0x80,
        Virtual = 0x100,
        Override = 0x200,
        Internal = 0x400,
    }

    internal static class ModifierExtensions
    {
        private static readonly SyntaxToken PUBLIC_TOKEN = SyntaxFactory.Token(SyntaxKind.PublicKeyword);
        private static readonly SyntaxToken ABSTRACT_TOKEN = SyntaxFactory.Token(SyntaxKind.AbstractKeyword);
        private static readonly SyntaxToken PARTIAL_TOKEN = SyntaxFactory.Token(SyntaxKind.PartialKeyword);
        private static readonly SyntaxToken STATIC_TOKEN = SyntaxFactory.Token(SyntaxKind.StaticKeyword);
        private static readonly SyntaxToken READONLY_TOKEN = SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword);
        private static readonly SyntaxToken PRIVATE_TOKEN = SyntaxFactory.Token(SyntaxKind.PrivateKeyword);
        private static readonly SyntaxToken ASYNC_TOKEN = SyntaxFactory.Token(SyntaxKind.AsyncKeyword);
        private static readonly SyntaxToken SEALED_TOKEN = SyntaxFactory.Token(SyntaxKind.SealedKeyword);
        private static readonly SyntaxToken VIRTUAL_TOKEN = SyntaxFactory.Token(SyntaxKind.VirtualKeyword);
        private static readonly SyntaxToken OVERRIDE_TOKEN = SyntaxFactory.Token(SyntaxKind.OverrideKeyword);
        private static readonly SyntaxToken INTERNAL_TOKEN = SyntaxFactory.Token(SyntaxKind.InternalKeyword);

        public static SyntaxToken[] ToSyntaxTokens(this Modifier m)
        {
            var result = new List<SyntaxToken>();
            // Order here matters; it's the order in which the modifiers will be placed in the generated source.
            if ((m & Modifier.Public) != 0) result.Add(PUBLIC_TOKEN);
            if ((m & Modifier.Private) != 0) result.Add(PRIVATE_TOKEN);
            if ((m & Modifier.Internal) != 0) result.Add(INTERNAL_TOKEN);
            if ((m & Modifier.Abstract) != 0) result.Add(ABSTRACT_TOKEN);
            if ((m & Modifier.Virtual) != 0) result.Add(VIRTUAL_TOKEN);
            if ((m & Modifier.Override) != 0) result.Add(OVERRIDE_TOKEN);
            if ((m & Modifier.Readonly) != 0) result.Add(READONLY_TOKEN);
            if ((m & Modifier.Static) != 0) result.Add(STATIC_TOKEN);
            if ((m & Modifier.Sealed) != 0) result.Add(SEALED_TOKEN);
            if ((m & Modifier.Async) != 0) result.Add(ASYNC_TOKEN);
            if ((m & Modifier.Partial) != 0) result.Add(PARTIAL_TOKEN);
            return result.ToArray();
        }
    }
}
