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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.RoslynUtils
{
    /// <summary>
    /// Helper methods to assist with creating XmlDoc elements.
    /// </summary>
    internal static class XmlDoc
    {
        public static class Annotations
        {
            public readonly static SyntaxAnnotation Preformatted = new SyntaxAnnotation("preformatted");
        }

        private static XmlNodeSyntax ToNode(object o)
        {
            switch (o)
            {
                case null:
                    return C("null");
                case true:
                    return C("true");
                case false:
                    return C("false");
                case int v:
                    return C(v.ToString(CultureInfo.InvariantCulture));
                case string v:
                    return XmlText(v);
                case XmlNodeSyntax v:
                    return v;
                case ParameterSyntax v:
                    return XmlParamRefElement(v.Identifier.Text);
                case PropertyDeclarationSyntax v:
                    return XmlSeeElement(NameMemberCref(IdentifierName(v.Identifier)));
                case ClassDeclarationSyntax v:
                    return XmlSeeElement(NameMemberCref(IdentifierName(v.Identifier)));
                case MethodDeclarationSyntax v:
                    return XmlSeeElement(NameMemberCref(IdentifierName(v.Identifier))
                        .WithParameters(CrefParameterList(SeparatedList(v.ParameterList.Parameters.Select(p => CrefParameter(p.Type))))));
                case TypeSyntax v:
                    return XmlSeeElement(NameMemberCref(v));
                case MemberAccessExpressionSyntax v:
                    // Only for enum elements
                    return XmlSeeElement(QualifiedCref((TypeSyntax)v.Expression, NameMemberCref(v.Name)));
                default:
                    throw new NotSupportedException($"Cannot handle ToNode({o.GetType()})");
            }
        }

        private static DocumentationCommentTriviaSyntax XmlDocElement<T>(IEnumerable<object> parts, Func<XmlNodeSyntax[], T> fn) where T : XmlNodeSyntax =>
            DocumentationCommentTrivia(SyntaxKind.SingleLineDocumentationCommentTrivia, SingletonList<XmlNodeSyntax>(fn(parts.Select(ToNode).ToArray())));

        public static DocumentationCommentTriviaSyntax Summary(params object[] parts) => XmlDocElement(parts, XmlSummaryElement);
        public static DocumentationCommentTriviaSyntax SummaryPreFormatted(IEnumerable<string> lines) => Summary(lines.ToArray()).WithAdditionalAnnotations(Annotations.Preformatted);
        public static DocumentationCommentTriviaSyntax Remarks(params object[] parts) => XmlDocElement(parts, XmlRemarksElement);
        public static DocumentationCommentTriviaSyntax Example(params object[] parts) => XmlDocElement(parts, XmlExampleElement);
        public static DocumentationCommentTriviaSyntax Param(ParameterSyntax param, params object[] parts) => XmlDocElement(parts, x => XmlParamElement(param.Identifier.Text, x));
        public static DocumentationCommentTriviaSyntax ParamPreFormatted(ParameterSyntax param, IEnumerable<string> lines) => Param(param, lines.ToArray()).WithAdditionalAnnotations(Annotations.Preformatted);
        public static DocumentationCommentTriviaSyntax Returns(params object[] parts) => XmlDocElement(parts, XmlReturnsElement);

        public static DocumentationCommentTriviaSyntax InheritDoc =>
            DocumentationCommentTrivia(SyntaxKind.SingleLineDocumentationCommentTrivia, SingletonList<XmlNodeSyntax>(XmlEmptyElement("inheritdoc")));

        public static XmlNodeSyntax C(string c) => XmlElement("c", SingletonList<XmlNodeSyntax>(XmlText(c)));
        public static XmlNodeSyntax Code(params string[] lines) => XmlElement("code", List(lines.Select(ToNode)));

        public static XmlNodeSyntax UL(params object[] items) => UL((IEnumerable<object>)items);
        public static XmlNodeSyntax UL<T>(IEnumerable<T> items) => XmlElement(
            XmlElementStartTag(XmlName("list"), SingletonList<XmlAttributeSyntax>(XmlTextAttribute("type", "bullet"))),
                List<XmlNodeSyntax>(items.Select(item =>
                {
                    var desc = XmlElement("description", SingletonList(ToNode(item)));
                    return XmlElement("item", SingletonList<XmlNodeSyntax>(desc));
                })),
                XmlElementEndTag(XmlName("list")));
    }
}
