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
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.RoslynUtils
{
    internal static class RoslynExtensions
    {
        public static T WithTrailingSpace<T>(this T node) where T : SyntaxNode => node.WithTrailingTrivia(Space);
        public static T WithLeadingCrLf<T>(this T node) where T : SyntaxNode => node.WithLeadingTrivia(CarriageReturnLineFeed);
        public static T WithTrailingCrLf<T>(this T node, int count = 1) where T : SyntaxNode => node.WithTrailingTrivia(Enumerable.Repeat(CarriageReturnLineFeed, count));

        public static SyntaxToken WithLeadingSpace(this SyntaxToken token) => token.WithLeadingTrivia(Space);
        public static SyntaxToken WithTrailingSpace(this SyntaxToken token) => token.WithTrailingTrivia(Space);
        public static SyntaxToken WithTrailingCrLf(this SyntaxToken token) => token.WithTrailingTrivia(CarriageReturnLineFeed);
    }
}
