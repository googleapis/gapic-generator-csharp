// Copyright 2019 Google Inc. All Rights Reserved.
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

// This is not a general-purpose C# code formatter.
// It makes various assumptions about the Roslyn input.

using Google.Api.Generator.RoslynUtils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Formatting
{
    internal class XmlDocSplitter
    {
        private static readonly XmlElementStartTagSyntax s_missingStartTag = XmlElementStartTag(
            MissingToken(SyntaxKind.LessThanToken), XmlName(MissingToken(SyntaxKind.IdentifierToken)), List<XmlAttributeSyntax>(), MissingToken(SyntaxKind.GreaterThanToken));
        private static readonly XmlElementEndTagSyntax s_missingEndTag = XmlElementEndTag(
            MissingToken(SyntaxKind.LessThanSlashToken), XmlName(MissingToken(SyntaxKind.IdentifierToken)), MissingToken(SyntaxKind.GreaterThanToken));

        private static XmlElementSyntax StartTag(XmlNameSyntax name, SyntaxList<XmlAttributeSyntax> attrs = default) => XmlElement(XmlElementStartTag(name, attrs), s_missingEndTag);
        private static XmlElementSyntax EndTag(XmlNameSyntax name) => XmlElement(s_missingStartTag, XmlElementEndTag(name));

        public static SyntaxTriviaList Split(SyntaxTrivia indent, int maxLineLength, SyntaxTriviaList xmlDocTrivia) =>
            new XmlDocSplitter(indent, maxLineLength).Split(xmlDocTrivia);

        private XmlDocSplitter(SyntaxTrivia indent, int maxLineLength)
        {
            _maxLineLength = maxLineLength;
            _preTrivia = TriviaList(
                indent,
                DocumentationCommentExterior("///"),
                Whitespace(" "));
            _maxXmlLength = _maxLineLength - _preTrivia.Span.Length;
        }

        private readonly int _maxLineLength;
        private readonly SyntaxTriviaList _preTrivia;
        private readonly int _maxXmlLength;

        private SyntaxTriviaList Split(SyntaxTriviaList xmlDocTrivia)
        {
            var trivia = xmlDocTrivia.Where(x => !x.Span.IsEmpty).SelectMany(item =>
            {
                var docComment = (DocumentationCommentTriviaSyntax)item.GetStructure();
                return docComment.HasAnnotation(XmlDoc.Annotations.Preformatted) ? SplitPreformatted(docComment) : SplitUnformatted(docComment);
            });
            return TriviaList(trivia.Select(Trivia));
        }

        private DocumentationCommentTriviaSyntax OneLine(XmlNodeSyntax xmlNode) => xmlNode == null ? null : OneLine(SingletonList(xmlNode));
        private DocumentationCommentTriviaSyntax OneLine(IEnumerable<XmlNodeSyntax> xmlNodes) => OneLine(List(xmlNodes.Where(x => x != null)));
        private DocumentationCommentTriviaSyntax OneLine(SyntaxList<XmlNodeSyntax> xmlNodes) =>
            DocumentationCommentTrivia(SyntaxKind.SingleLineDocumentationCommentTrivia, xmlNodes)
                .WithLeadingTrivia(_preTrivia).WithTrailingTrivia(CarriageReturnLineFeed);

        private IEnumerable<DocumentationCommentTriviaSyntax> SplitPreformatted(DocumentationCommentTriviaSyntax docComment)
        {
            // TODO: This assumes it's for a summary element, which may not always be true in the future.
            // Already correct pre-formatted into lines; need to indent and add `/// `.
            foreach (var element in docComment.Content.OfType<XmlElementSyntax>())
            {
                yield return OneLine(StartTag(element.StartTag.Name, element.StartTag.Attributes));
                foreach (var node in element.Content)
                {
                    yield return OneLine(node);
                }
                yield return OneLine(EndTag(element.EndTag.Name));
            }
        }

        private IEnumerable<DocumentationCommentTriviaSyntax> SplitUnformatted(DocumentationCommentTriviaSyntax docComment)
        {
            // Types of nested XML, with examples:
            // * <c> inline, but first and last XML tags must be on same line as adjacant word.
            // * <code> Always on new line; contains pre-formatted lines of text.
            // * <list> Must always start on a new line. OK all on one line, or must be by itself.
            // * <item> OK within <list> if all on one line; otherwise must start on its own line. Content may be all on one line, or nested <description> can be with in.
            return docComment.Content.SelectMany(node =>
            {
                if (node.Span.Length <= _maxXmlLength)
                {
                    return new[] { OneLine(node) };
                }
                else
                {
                    var multi = Fit(node, Enumerable.Empty<XmlNodeSyntax>()).ToList();
                    // Returun all none-empty lines.
                    // TODO: This will probably remove pre-formatted empty lines (e.g. in a `code` element).
                    return multi
                        .Where(x => x != null && x.Any())
                        .Select(line =>
                        {
                            // remove any lone leading ` ` characters.
                            line = line
                                .SkipWhile(x => x is XmlTextSyntax t && t.TextTokens.Count == 1 && t.TextTokens[0].Text == " ")
                                .ToList();
                            // Remove any trailing ` ` characters. Complexity due to the nested xml-node structure.
                            if (line.LastOrDefault() is XmlTextSyntax t2 && t2.TextTokens.Any() && t2.TextTokens.Last().Text.EndsWith(' '))
                            {
                                var lastText = t2.TextTokens.Last().Text.TrimEnd(' ');
                                var lastTextToken = Token(TriviaList(), SyntaxKind.XmlTextLiteralToken, lastText, lastText, TriviaList());
                                t2 = XmlText(TokenList(t2.TextTokens.SkipLast(1).Append(lastTextToken)));
                                line = line.SkipLast(1).Append(t2);
                            }
                            return OneLine(line);
                        });
                }
            });

            IEnumerable<IEnumerable<XmlNodeSyntax>> Fit(XmlNodeSyntax node, IEnumerable<XmlNodeSyntax> continuation)
            {
                switch (node)
                {
                    case XmlElementSyntax element:
                        var name = element.StartTag.Name.LocalName.Text.ToLowerInvariant();
                        var startTag = StartTag(element.StartTag.Name, element.StartTag.Attributes);
                        var endTag = EndTag(element.EndTag.Name);
                        switch (name)
                        {
                            case "c":
                                // Completely inline; first/last words must be on the same line as the respective tag.
                                var word1 = (element.Content.FirstOrDefault() as XmlTextSyntax)?.TextTokens.FirstOrDefault().Text.Split(' ').FirstOrDefault();
                                if (List(continuation.Append(startTag).Append(XmlText(word1))).Span.Length > _maxXmlLength)
                                {
                                    // start-tag and first word won't fit on end of continuation.
                                    yield return continuation;
                                    continuation = Enumerable.Empty<XmlNodeSyntax>();
                                }
                                continuation = continuation.Append(startTag);
                                foreach (var childNode in element.Content)
                                {
                                    var childLines = Fit(childNode, continuation).ToList();
                                    foreach (var childLine in childLines.SkipLast(1))
                                    {
                                        yield return childLine;
                                    }
                                    continuation = childLines.LastOrDefault() ?? Enumerable.Empty<XmlNodeSyntax>();
                                }
                                yield return continuation.Append(endTag); // TODO: This can overrun line-length.
                                yield break;
                            case "code":
                                // Start on new line; lines are pre-formatted.
                                yield return continuation;
                                continuation = Enumerable.Empty<XmlNodeSyntax>();
                                yield return new[] { startTag };
                                foreach (var childNode in element.Content)
                                {
                                    yield return new[] { childNode };
                                }
                                yield return new[] { endTag };
                                yield return Enumerable.Empty<XmlNodeSyntax>(); // To ensure the close tag is on its own line.
                                yield break;
                            default:
                                // Start on new line; all in one line, or start/end tags on their own lines.
                                yield return continuation;
                                continuation = Enumerable.Empty<XmlNodeSyntax>();
                                if (element.Span.Length < _maxXmlLength)
                                {
                                    yield return new[] { element };
                                }
                                else
                                {
                                    yield return new[] { startTag };
                                    foreach (var childNode in element.Content)
                                    {
                                        var childLines = Fit(childNode, continuation).ToList();
                                        foreach (var childLine in childLines.SkipLast(1))
                                        {
                                            yield return childLine;
                                        }
                                        continuation = childLines.LastOrDefault() ?? Enumerable.Empty<XmlNodeSyntax>();
                                    }
                                    yield return continuation;
                                    yield return new[] { endTag };
                                }
                                yield return Enumerable.Empty<XmlNodeSyntax>(); // To ensure the close tag is on its own line.
                                yield break;
                        }
                    case XmlEmptyElementSyntax emptyElement:
                        // Attempt to add to continuation if it fits.
                        if (continuation.Append(emptyElement).Sum(x => x.Span.Length) <= _maxXmlLength)
                        {
                            yield return continuation.Append(emptyElement);
                        }
                        else
                        {
                            yield return continuation;
                            yield return new[] { emptyElement };
                        }
                        yield break;
                    case XmlTextSyntax text:
                        // Add words up until they exceed line length limit (unless it's a single word).
                        string textLine = null;
                        foreach (var word in text.TextTokens.SelectMany(x => x.Text.Split(' ')))
                        {
                            string prevTextLine = textLine;
                            textLine = textLine == null ? word : $"{textLine} {word}";
                            if (continuation.Append(XmlText(textLine)).Sum(x => x.Span.Length) > _maxXmlLength && (continuation.Any() || prevTextLine != null))
                            {
                                yield return continuation.Append(prevTextLine == null ? null : XmlText(prevTextLine));
                                continuation = Enumerable.Empty<XmlNodeSyntax>();
                                textLine = string.IsNullOrWhiteSpace(word) ? "" : word;
                            }
                        }
                        yield return continuation.Append(XmlText(textLine));
                        yield break;
                    default:
                        throw new InvalidOperationException($"Cannot fit xmldoc of type: {node.Kind()}");
                }
            }
        }
    }

}
