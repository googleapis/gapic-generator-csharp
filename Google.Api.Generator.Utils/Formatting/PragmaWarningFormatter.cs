// Copyright 2020 Google Inc. All Rights Reserved.
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

using Google.Api.Generator.Utils.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Utils.Formatting
{
    public static class PragmaWarningFormatter
    {
        private class PragmaVisitor : CSharpSyntaxRewriter
        {
            public PragmaVisitor() : base(visitIntoStructuredTrivia: true) { }

            public override SyntaxNode VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node)
            {
                node = (PragmaWarningDirectiveTriviaSyntax) base.VisitPragmaWarningDirectiveTrivia(node);
                node = node.WithPragmaKeyword(node.PragmaKeyword.WithTrailingTrivia(Space));
                node = node.WithWarningKeyword(node.WarningKeyword.WithTrailingTrivia(Space));
                node = node.WithDisableOrRestoreKeyword(node.DisableOrRestoreKeyword.WithTrailingTrivia(Space));
                return node;
            }
        }

        private static SyntaxTrivia PragmaWarningDisable(params string[] toDisable) =>
            Trivia(PragmaWarningDirectiveTrivia(Token(SyntaxKind.DisableKeyword), SeparatedList<ExpressionSyntax>(toDisable.Select(IdentifierName)), true));

        private static SyntaxTrivia PragmaWarningRestore(params string[] toRestore) =>
            Trivia(PragmaWarningDirectiveTrivia(Token(SyntaxKind.RestoreKeyword), SeparatedList<ExpressionSyntax>(toRestore.Select(IdentifierName)), true));

        public static CompilationUnitSyntax Visit(CompilationUnitSyntax code)
        {
            var modifications = new Dictionary<SyntaxToken, SyntaxToken>();
            var token = code.GetFirstToken();
            Action modifyPrevEol = () => { };
            var addAtPrevEol = new List<(string errorCode, bool isRestore)>();
            var addAtNextEol = new List<(string errorCode, bool isRestore)>();
            while (!token.IsKind(SyntaxKind.None))
            {
                token = token.GetNextToken();
                var localToken = token;
                var leadingTrivia = token.GetAllTrivia().TakeWhile(x => x.SpanStart < token.SpanStart).ToList();
                HandleEol(leadingTrivia, t => t.WithLeadingTrivia);
                var warnings = token.GetAnnotations(PragmaWarnings.AnnotationKind);
                if (warnings.Any())
                {
                    var errorCodes = warnings.Select(x => x.Data).ToList();
                    addAtPrevEol.AddRange(errorCodes.Select(x => (x, false)));
                    addAtNextEol.AddRange(errorCodes.Select(x => (x, true)));
                }
                var trailingTrivia = token.GetAllTrivia().SkipWhile(x => x.SpanStart < token.SpanStart).ToList();
                HandleEol(trailingTrivia, t => t.WithTrailingTrivia);

                void HandleEol(IReadOnlyList<SyntaxTrivia> trivia, Func<SyntaxToken, Func<IEnumerable<SyntaxTrivia>, SyntaxToken>> mod)
                {
                    if (trivia.Any(ContainsEol))
                    {
                        modifyPrevEol();
                        addAtPrevEol = addAtNextEol;
                        addAtNextEol = new List<(string errorCode, bool isRestore)>();
                        modifyPrevEol = () =>
                        {
                            if (!addAtPrevEol.Any())
                            {
                                return;
                            }
                            var disables0 = addAtPrevEol.Where(x => !x.isRestore).Select(x => x.errorCode).Distinct().ToList();
                            var restores0 = addAtPrevEol.Where(x => x.isRestore).Select(x => x.errorCode).Distinct().ToList();
                            var disables = disables0.Except(restores0).ToList();
                            var restores = restores0.Except(disables0).ToList();
                            if (!disables.Any() && !restores.Any())
                            {
                                return;
                            }
                            var preEol = trivia.TakeWhile(x => !ContainsEol(x)).ToList();
                            var postEol = Enumerable.Reverse(trivia).TakeWhile(x => !ContainsEol(x)).Reverse().ToList();
                            var midEol = trivia.Skip(preEol.Count).Take(trivia.Count - preEol.Count - postEol.Count);
                            var modifiedTrivia = preEol
                                .Concat(restores.Any() ?
                                    new[] { WhitespaceFormatterNewLine.NewLine, PragmaWarningRestore(restores.ToArray()) } :
                                    Enumerable.Empty<SyntaxTrivia>())
                                .Concat(midEol)
                                .Concat(disables.Any() ?
                                    new[] { PragmaWarningDisable(disables.ToArray()), WhitespaceFormatterNewLine.NewLine } :
                                    Enumerable.Empty<SyntaxTrivia>())
                                .Concat(postEol);
                            var existingToken = modifications.TryGetValue(localToken, out var modifiedToken) ? modifiedToken : localToken;
                            modifications[localToken] = mod(existingToken)(modifiedTrivia);
                        };
                    }

                    bool ContainsEol(SyntaxTrivia st)
                    {
                        if (st.IsKind(SyntaxKind.EndOfLineTrivia))
                        {
                            return true;
                        }
                        var structure = st.GetStructure();
                        if (structure is object)
                        {
                            if (structure.DescendantNodesAndTokensAndSelf().Any(nt => nt.GetLeadingTrivia().Concat(nt.GetTrailingTrivia()).Any(ContainsEol)))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            modifyPrevEol();
            code = code.ReplaceTokens(modifications.Keys, (orgtoken, _) => modifications[orgtoken]);
            code = (CompilationUnitSyntax) new PragmaVisitor().Visit(code);
            return code;
        }
    }
}
