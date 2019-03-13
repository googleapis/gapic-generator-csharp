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

using Google.Api.Generator.Formatting;
using Google.Api.Generator.RoslynUtils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Xunit;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Tests
{
    public class XmlDocSplitterTest
    {
        private static readonly SyntaxTrivia s_indent4 = Whitespace("    ");

        private SyntaxTriviaList TrivList(DocumentationCommentTriviaSyntax triv) => TriviaList(Trivia(triv));

        [Fact]
        public void SingleLine()
        {
            var s = XmlDocSplitter.Split(s_indent4, 40, TrivList(XmlDoc.Summary("Short line"))).ToFullString();
            Assert.Equal("    /// <summary>Short line</summary>\r\n", s);
        }

        [Fact]
        public void MultiLine()
        {
            var s = XmlDocSplitter.Split(s_indent4, 40, TrivList(XmlDoc.Summary("A slightly longer line to go over 40 chars"))).ToFullString();
            Assert.Equal("    /// <summary>\r\n    /// A slightly longer line to go\r\n    /// over 40 chars\r\n    /// </summary>\r\n", s);
        }

        [Fact]
        public void Preformatted()
        {
            // Whitespace around " Line 2 " is delibrate, to test extra whitespace removal at end of lines only.
            var s = XmlDocSplitter.Split(s_indent4, 40, TrivList(XmlDoc.SummaryPreFormatted(new[] { "Line 1", " Line 2 " }))).ToFullString();
            Assert.Equal("    /// <summary>\r\n    /// Line 1\r\n    ///  Line 2\r\n    /// </summary>\r\n", s);
        }
    }
}
