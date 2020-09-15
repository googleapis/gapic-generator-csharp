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
    public static class WhitespaceFormatterNewLine
    {
        public static SyntaxTrivia NewLine { get; } = SyntaxTrivia(SyntaxKind.EndOfLineTrivia, Environment.NewLine);

        public static T WithTrailingNewLine<T>(this T node, int count = 1) where T : SyntaxNode =>
            node.WithTrailingTrivia(Enumerable.Repeat(NewLine, count));

        public static SyntaxToken WithTrailingNewLine(this SyntaxToken token, int count = 1) =>
            token.WithTrailingTrivia(Enumerable.Repeat(NewLine, count));
    }

    public class WhitespaceFormatter : CSharpSyntaxRewriter
    {
        private static readonly SyntaxToken s_commaSpace = Token(SyntaxKind.CommaToken).WithTrailingSpace();
        private static IEnumerable<SyntaxToken> CommaSpaces(int count) => Enumerable.Repeat(s_commaSpace, Math.Max(0, count));
        private static readonly SyntaxTrivia s_singleIndentTrivia = SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "    ");
        private static SyntaxTrivia NewLine => WhitespaceFormatterNewLine.NewLine;

        public WhitespaceFormatter(int maxLineLength) : base(visitIntoStructuredTrivia: false) =>
            _maxLineLength = maxLineLength;

        private readonly int _maxLineLength;
        private SyntaxTrivia _indentTrivia = SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "");
        private SyntaxTrivia _previousIndentTrivia = SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "");

        private IDisposable WithIndent(bool withIndent = true)
        {
            if (withIndent)
            {
                var orgPreviousIndentTrivia = _previousIndentTrivia;
                _previousIndentTrivia = _indentTrivia;
                _indentTrivia = SyntaxTrivia(SyntaxKind.WhitespaceTrivia, new string(' ', _indentTrivia.Span.Length + 4));
                return new Disposable(() =>
                {
                    _indentTrivia = _previousIndentTrivia;
                    _previousIndentTrivia = orgPreviousIndentTrivia;
                });
            }
            else
            {
                return new Disposable(() => { });
            }
        }

        private SyntaxTriviaList FormatXmlDoc(SyntaxTriviaList trivList) =>
            XmlDocSplitter.Split(_indentTrivia, _maxLineLength, trivList);

        private T HandleLeadingTrivia<T>(T node) where T : SyntaxNode
        {
            var trivia0 = node.GetLeadingTrivia();
            if (trivia0.Span.IsEmpty)
            {
                // For some reason there is an empty piece of trivia prepended to all `using` directives.
                // I don't understand why this is; but just get rid of it here for now.
                // TODO: Understand where this empty leading trivia is coming from.
                trivia0 = TriviaList();
            }
            var trivia1 = _indentTrivia.Span.IsEmpty ?
                trivia0.SelectMany(x => new[] { x, NewLine }) :
                trivia0.SelectMany(x => new[] { _indentTrivia, x, NewLine }).Append(_indentTrivia);
            return node.WithLeadingTrivia(trivia1);
        }

        public override SyntaxNode VisitCompilationUnit(CompilationUnitSyntax node)
        {
            node = (CompilationUnitSyntax)base.VisitCompilationUnit(node);
            node = node.WithMembers(List(node.Members.Take(1).Select(m =>
            {
                // If there's not already a blank line before the namespace, then add one.
                var last2 = m.GetLeadingTrivia()
                    .Where(x => !x.Span.IsEmpty)
                    .TakeLast(2).ToList();
                var hasBlankLine = last2.Count == 2 && last2.All(x => x.IsKind(SyntaxKind.EndOfLineTrivia));
                return hasBlankLine ?
                    m.WithLeadingTrivia(m.GetLeadingTrivia()) :
                    m.WithLeadingTrivia(m.GetLeadingTrivia().Append(NewLine));
            })
                .Concat(node.Members.Skip(1))));
            return node;
        }

        public override SyntaxNode VisitUsingDirective(UsingDirectiveSyntax node)
        {
            node = (UsingDirectiveSyntax)base.VisitUsingDirective(node);
            node = HandleLeadingTrivia(node);
            node = node.WithUsingKeyword(node.UsingKeyword.WithTrailingSpace());
            node = node.WithSemicolonToken(node.SemicolonToken.WithTrailingNewLine());
            return node;
        }

        public override SyntaxNode VisitNameEquals(NameEqualsSyntax node)
        {
            node = (NameEqualsSyntax)base.VisitNameEquals(node);
            node = node.WithEqualsToken(node.EqualsToken.WithLeadingSpace().WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            using (WithIndent())
            {
                node = (NamespaceDeclarationSyntax)base.VisitNamespaceDeclaration(node);
                if (node.Usings.Any())
                {
                    node = node.WithUsings(List(node.Usings.SkipLast(1).Append(node.Usings.Last().WithTrailingTrivia(NewLine, NewLine))));
                }
            }
            node = HandleLeadingTrivia(node);
            node = node.WithNamespaceKeyword(node.NamespaceKeyword.WithTrailingSpace());
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(NewLine, _indentTrivia).WithTrailingNewLine());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingNewLine());
            node = node.WithMembers(List(
                node.Members.SkipLast(1).Select(m => m.WithTrailingNewLine(count: 2))
                    .Concat(node.Members.TakeLast(1).Select(m => m.WithTrailingNewLine(count: 1)))));
            return node;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            using (WithIndent())
            {
                node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node);
            }
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            node = node.WithModifiers(TokenList(node.Modifiers.Select(m => m.WithTrailingSpace())));
            node = node.WithKeyword(node.Keyword.WithTrailingSpace());
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(NewLine, _indentTrivia).WithTrailingNewLine());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingNewLine());
            node = node.WithMembers(List(
                node.Members.SkipLast(1).Select(m => m.WithTrailingNewLine(count: 2))
                    .Concat(node.Members.TakeLast(1).Select(m => m.WithTrailingNewLine(count: 1)))));
            return node;
        }

        public override SyntaxNode VisitBaseList(BaseListSyntax node)
        {
            node = (BaseListSyntax)base.VisitBaseList(node);
            node = node.WithColonToken(node.ColonToken.WithLeadingSpace().WithTrailingSpace());
            node = node.WithTypes(SeparatedList(node.Types, CommaSpaces(node.Types.Count - 1)));
            return node;
        }

        public override SyntaxNode VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            node = (ConstructorDeclarationSyntax)base.VisitConstructorDeclaration(node);
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            node = node.WithModifiers(TokenList(node.Modifiers.Select(m => m.WithTrailingSpace())));
            return node;
        }

        public override SyntaxNode VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            node = (ConstructorInitializerSyntax)base.VisitConstructorInitializer(node);
            node = node.WithColonToken(node.ColonToken.WithLeadingSpace().WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            node = (MethodDeclarationSyntax)base.VisitMethodDeclaration(node);
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            node = node.WithModifiers(TokenList(node.Modifiers.Select(m => m.WithTrailingSpace())));
            node = node.WithReturnType(node.ReturnType.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitAttributeList(AttributeListSyntax node)
        {
            var lineBreak = node.Parent is MethodDeclarationSyntax ||
                node.Parent is ClassDeclarationSyntax ||
                node.Parent is PropertyDeclarationSyntax ||
                node.Parent is EnumMemberDeclarationSyntax ||
                node.Parent is EnumDeclarationSyntax;
            // For class and enum declarations, VisitAttributeList happens *within* the base declaration visit...
            // which means we've already called WithIndent by the time we get here. We need to indent by
            // the previous amount of whitespace instead.
            var indentTrivia = node.Parent is ClassDeclarationSyntax || node.Parent is EnumDeclarationSyntax
                ? _previousIndentTrivia
                : _indentTrivia;

            node = (AttributeListSyntax)base.VisitAttributeList(node);
            if (lineBreak)
            {
                node = node.WithCloseBracketToken(node.CloseBracketToken.WithTrailingTrivia(NewLine, indentTrivia));
            }
            return node;
        }

        public override SyntaxNode VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            node = (OperatorDeclarationSyntax)base.VisitOperatorDeclaration(node);
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            node = node.WithModifiers(TokenList(node.Modifiers.Select(m => m.WithTrailingSpace())));
            node = node.WithReturnType(node.ReturnType.WithTrailingSpace());
            node = node.WithOperatorKeyword(node.OperatorKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitArgumentList(ArgumentListSyntax node)
        {
            node = (ArgumentListSyntax)base.VisitArgumentList(node);
            node = node.WithArguments(SeparatedList(node.Arguments, CommaSpaces(node.Arguments.Count - 1)));
            return node;
        }

        public override SyntaxNode VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            node = (AttributeArgumentListSyntax) base.VisitAttributeArgumentList(node);
            node = node.WithArguments(SeparatedList(node.Arguments, CommaSpaces(node.Arguments.Count - 1)));
            return node;
        }

        public override SyntaxNode VisitArgument(ArgumentSyntax node)
        {
            node = (ArgumentSyntax)base.VisitArgument(node);
            if (node.RefKindKeyword != null)
            {
                node = node.WithRefKindKeyword(node.RefKindKeyword.WithTrailingSpace());
            }
            return node;
        }

        public override SyntaxNode VisitNameColon(NameColonSyntax node)
        {
            node = (NameColonSyntax)base.VisitNameColon(node);
            node = node.WithColonToken(node.ColonToken.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitParameter(ParameterSyntax node)
        {
            node = (ParameterSyntax)base.VisitParameter(node);
            if (node.Type != null)
            {
                node = node.WithType(node.Type.WithTrailingSpace());
            }
            node = node.WithModifiers(TokenList(node.Modifiers.Select(x => x.WithTrailingSpace())));
            return node;
        }

        public override SyntaxNode VisitParameterList(ParameterListSyntax node)
        {
            node = (ParameterListSyntax)base.VisitParameterList(node);
            node = node.WithParameters(SeparatedList(node.Parameters, CommaSpaces(node.Parameters.Count - 1)));
            return node;
        }

        public override SyntaxNode VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            var lineSplit = node.Parent is MethodDeclarationSyntax method && method.Span.Length + _indentTrivia.Span.Length > _maxLineLength;
            var postTrivia = lineSplit ? TriviaList(NewLine, _indentTrivia, s_singleIndentTrivia) : TriviaList(Space);
            using (WithIndent(lineSplit))
            {
                node = (ArrowExpressionClauseSyntax)base.VisitArrowExpressionClause(node);
            }
            node = node.WithArrowToken(node.ArrowToken.WithLeadingSpace().WithTrailingTrivia(postTrivia));
            return node;
        }

        public override SyntaxNode VisitBlock(BlockSyntax node)
        {
            bool parentIsLambda = node.Parent is SimpleLambdaExpressionSyntax || node.Parent is ParenthesizedLambdaExpressionSyntax;
            using (WithIndent())
            {
                node = node.WithStatements(List(node.Statements.Select(s =>
                {
                    IEnumerable<SyntaxTrivia> AdjustTrivia(SyntaxTrivia triv) => triv.ToString().Trim() == ""
                        ? new[] { NewLine } : new[] { _indentTrivia, triv, NewLine };
                    var preTrivia = s.GetLeadingTrivia().Where(x => !x.Span.IsEmpty).SelectMany(AdjustTrivia).Append(_indentTrivia);
                    var postTrivia = s.GetTrailingTrivia().Where(x => !x.Span.IsEmpty).SelectMany(AdjustTrivia).Prepend(NewLine);
                    return Visit(s).WithLeadingTrivia(preTrivia).WithTrailingTrivia(postTrivia);
                })));
            }
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(NewLine, _indentTrivia).WithTrailingNewLine());
            if (parentIsLambda)
            {
                node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia));
            }
            else
            {
                node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingNewLine());
            }
            return node;
        }

        public override SyntaxNode VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            node = (AssignmentExpressionSyntax)base.VisitAssignmentExpression(node);
            var noSpace = node.Right is InitializerExpressionSyntax initExpr && initExpr.Kind() == SyntaxKind.CollectionInitializerExpression;
            var operatorToken1 = noSpace ? node.OperatorToken.WithLeadingSpace() : node.OperatorToken.WithLeadingSpace().WithTrailingSpace();
            node = node.WithOperatorToken(operatorToken1);
            return node;
        }

        public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            node = (BinaryExpressionSyntax)base.VisitBinaryExpression(node);
            node = node.WithOperatorToken(node.OperatorToken.WithLeadingSpace().WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            node = (FieldDeclarationSyntax)base.VisitFieldDeclaration(node);
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            node = node.WithModifiers(TokenList(node.Modifiers.Select(m => m.WithTrailingSpace())));
            return node;
        }

        public override SyntaxNode VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            node = (VariableDeclarationSyntax)base.VisitVariableDeclaration(node);
            node = node.WithType(node.Type.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            node = (EqualsValueClauseSyntax)base.VisitEqualsValueClause(node);
            node = node.WithEqualsToken(node.EqualsToken.WithLeadingSpace().WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            node = (PropertyDeclarationSyntax)base.VisitPropertyDeclaration(node);
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            node = node.WithModifiers(TokenList(node.Modifiers.Select(m => m.WithTrailingSpace())));
            node = node.WithType(node.Type.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitAccessorList(AccessorListSyntax node)
        {
            var anyBodies = node.Accessors.Any(x => x.Body != null || x.ExpressionBody != null);
            if (anyBodies)
            {
                using (WithIndent())
                {
                    node = (AccessorListSyntax)base.VisitAccessorList(node);
                }
                node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(NewLine, _indentTrivia).WithTrailingNewLine());
                node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia));
            }
            else
            {
                node = (AccessorListSyntax)base.VisitAccessorList(node);
                node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingSpace().WithTrailingSpace());
            }
            return node;
        }

        public override SyntaxNode VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            node = (AccessorDeclarationSyntax)base.VisitAccessorDeclaration(node);
            if (node.Body != null)
            {
                node = node.WithKeyword(node.Keyword.WithLeadingTrivia(_indentTrivia));
            }
            else if (node.ExpressionBody != null)
            {
                node = node.WithKeyword(node.Keyword.WithLeadingTrivia(_indentTrivia));
                node = node.WithSemicolonToken(node.SemicolonToken.WithTrailingNewLine());
            }
            else
            {
                node = node.WithSemicolonToken(node.SemicolonToken.WithTrailingSpace());
            }
            return node;
        }

        public override SyntaxNode VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            node = (ObjectCreationExpressionSyntax)base.VisitObjectCreationExpression(node);
            node = node.WithNewKeyword(node.NewKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            node = (ArrayCreationExpressionSyntax)base.VisitArrayCreationExpression(node);
            node = node.WithNewKeyword(node.NewKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            // Do not call base; the contained expressions are visited in this method.
            var isComplex = node.Kind() == SyntaxKind.ComplexElementInitializerExpression;
            var nodeExprs = node.Expressions.Select(Visit);
            if (node.Span.Length < 20)
            {
                // Crude <20 to only make short initializer expressions stay on a single line.
                node = node.WithExpressions(SeparatedList<SyntaxNode>(nodeExprs
                    .SelectMany(x => new SyntaxNodeOrToken[] { x.WithLeadingSpace(), Token(SyntaxKind.CommaToken) }).SkipLast(isComplex ? 1 : 0)));
                node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingSpace());
                node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingSpace());
            }
            else
            {
                using (WithIndent())
                {
                    var items = nodeExprs.SelectMany(x => new SyntaxNodeOrToken[]
                    {
                        x.WithLeadingTrivia(_indentTrivia),
                        Token(SyntaxKind.CommaToken).WithTrailingNewLine()
                    }).ToList();
                    if (isComplex)
                    {
                        items = items.SkipLast(2).Concat(items
                            .TakeLast(2).Take(1).Select(x => x.WithTrailingTrivia(NewLine))).ToList();
                    }
                    node = node.WithExpressions(SeparatedList<SyntaxNode>(items));
                }
                node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(NewLine, _indentTrivia).WithTrailingNewLine());
                node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia));
            }
            return node;
        }

        public override SyntaxNode VisitReturnStatement(ReturnStatementSyntax node)
        {
            node = (ReturnStatementSyntax)base.VisitReturnStatement(node);
            if (node.Expression != null)
            {
                node = node.WithReturnKeyword(node.ReturnKeyword.WithTrailingSpace());
            }
            return node;
        }

        public override SyntaxNode VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            node = (AwaitExpressionSyntax)base.VisitAwaitExpression(node);
            node = node.WithAwaitKeyword(node.AwaitKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            node = (IfStatementSyntax)base.VisitIfStatement(node);
            node = node.WithIfKeyword(node.IfKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitElseClause(ElseClauseSyntax node)
        {
            node = (ElseClauseSyntax)base.VisitElseClause(node);
            node = node.WithElseKeyword(node.ElseKeyword.WithLeadingTrivia(_indentTrivia));
            return node;
        }

        public override SyntaxNode VisitThrowStatement(ThrowStatementSyntax node)
        {
            node = (ThrowStatementSyntax)base.VisitThrowStatement(node);
            node = node.WithThrowKeyword(node.ThrowKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitThrowExpression(ThrowExpressionSyntax node)
        {
            node = (ThrowExpressionSyntax)base.VisitThrowExpression(node);
            node = node.WithThrowKeyword(node.ThrowKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitTypeParameterList(TypeParameterListSyntax node)
        {
            node = (TypeParameterListSyntax)base.VisitTypeParameterList(node);
            node = node.WithParameters(SeparatedList(node.Parameters, CommaSpaces(node.Parameters.Count - 1)));
            return node;
        }

        public override SyntaxNode VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            node = (TypeParameterConstraintClauseSyntax)base.VisitTypeParameterConstraintClause(node);
            node = node.WithWhereKeyword(node.WhereKeyword.WithLeadingSpace().WithTrailingSpace());
            node = node.WithColonToken(node.ColonToken.WithLeadingSpace().WithTrailingSpace());
            node = node.WithConstraints(SeparatedList(node.Constraints, CommaSpaces(node.Constraints.Count - 1)));
            return node;
        }

        public override SyntaxNode VisitGenericName(GenericNameSyntax node)
        {
            node = (GenericNameSyntax)base.VisitGenericName(node);
            node = node.WithTypeArgumentList(TypeArgumentList(SeparatedList(node.TypeArgumentList.Arguments, CommaSpaces(node.TypeArgumentList.Arguments.Count - 1))));
            return node;
        }

        public override SyntaxNode VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            node = (ConditionalExpressionSyntax)base.VisitConditionalExpression(node);
            node = node.WithQuestionToken(node.QuestionToken.WithLeadingSpace().WithTrailingSpace());
            node = node.WithColonToken(node.ColonToken.WithLeadingSpace().WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitDeclarationExpression(DeclarationExpressionSyntax node)
        {
            node = (DeclarationExpressionSyntax)base.VisitDeclarationExpression(node);
            node = node.WithType(node.Type.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            node = (SimpleLambdaExpressionSyntax)base.VisitSimpleLambdaExpression(node);
            if (node.AsyncKeyword != null)
            {
                node = node.WithAsyncKeyword(node.AsyncKeyword.WithTrailingSpace());
            }
            if (node.Body is BlockSyntax)
            {
                node = node.WithArrowToken(node.ArrowToken.WithLeadingSpace());
            }
            else
            {
                node = node.WithArrowToken(node.ArrowToken.WithLeadingSpace().WithTrailingSpace());
            }
            return node;
        }

        public override SyntaxNode VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            node = (ParenthesizedLambdaExpressionSyntax)base.VisitParenthesizedLambdaExpression(node);
            if (node.AsyncKeyword != null)
            {
                node = node.WithAsyncKeyword(node.AsyncKeyword.WithTrailingSpace());
            }
            if (node.Body is BlockSyntax)
            {
                node = node.WithArrowToken(node.ArrowToken.WithLeadingSpace());
            }
            else
            {
                node = node.WithArrowToken(node.ArrowToken.WithLeadingSpace().WithTrailingSpace());
            }
            return node;
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            node = (ForEachStatementSyntax)base.VisitForEachStatement(node);
            node = node.WithForEachKeyword(node.ForEachKeyword.WithTrailingSpace());
            node = node.WithType(node.Type.WithTrailingSpace());
            node = node.WithInKeyword(node.InKeyword.WithLeadingSpace().WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitForStatement(ForStatementSyntax node)
        {
            node = (ForStatementSyntax)base.VisitForStatement(node);
            node = node.WithForKeyword(node.ForKeyword.WithTrailingSpace());
            node = node.WithFirstSemicolonToken(node.FirstSemicolonToken.WithTrailingSpace());
            node = node.WithSecondSemicolonToken(node.SecondSemicolonToken.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
        {
            node = (WhileStatementSyntax)base.VisitWhileStatement(node);
            node = node.WithWhileKeyword(node.WhileKeyword.WithTrailingSpace());
            return node;
        }

        public override SyntaxNode VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            using (WithIndent())
            {
                node = (EnumDeclarationSyntax)base.VisitEnumDeclaration(node);
            }
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            node = node.WithModifiers(TokenList(node.Modifiers.Select(m => m.WithTrailingSpace())));
            node = node.WithEnumKeyword(node.EnumKeyword.WithTrailingSpace());
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(NewLine, _indentTrivia).WithTrailingNewLine());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingNewLine());
            node = node.WithMembers(SeparatedList(
                node.Members,
                // Members before the final one have a comma and two new lines.
                // The final member only has a single new line, but does still have the comma.
                // The comma is optional, but means that there's no diff on that line when a new member is added.
                node.Members
                    .SkipLast(1).Select(_ => Token(SyntaxKind.CommaToken).WithTrailingNewLine(count: 2))
                    .Concat(new[] { Token(SyntaxKind.CommaToken).WithTrailingNewLine(count: 1) })));
            return node;
        }

        public override SyntaxNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            node = (EnumMemberDeclarationSyntax)base.VisitEnumMemberDeclaration(node);
            node = node.WithLeadingTrivia(FormatXmlDoc(node.GetLeadingTrivia()).Append(_indentTrivia));
            return node;
        }

        public override SyntaxNode VisitSwitchStatement(SwitchStatementSyntax node)
        {
            using (WithIndent())
            {
                node = (SwitchStatementSyntax)base.VisitSwitchStatement(node);
            }
            node = node.WithSwitchKeyword(node.SwitchKeyword.WithTrailingSpace());
            node = node.WithCloseParenToken(node.CloseParenToken.WithTrailingNewLine());
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingNewLine());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingNewLine());
            return node;
        }

        public override SyntaxNode VisitSwitchSection(SwitchSectionSyntax node)
        {
            node = (SwitchSectionSyntax)base.VisitSwitchSection(node);
            var label = node.Labels.Single();
            var keywordTrailingTriv = label is DefaultSwitchLabelSyntax ? new SyntaxTrivia[] { } : new[] { Space };
            if (node.Statements.Count == 1)
            {
                node = node.WithLabels(SingletonList(label
                    .WithKeyword(label.Keyword.WithLeadingTrivia(_indentTrivia).WithTrailingTrivia(keywordTrailingTriv))
                    .WithColonToken(label.ColonToken.WithTrailingSpace())));
                node = node.WithStatements(List(node.Statements.Select(x => x.WithTrailingNewLine())));
            }
            else
            {
                node = node.WithLabels(SingletonList(label
                    .WithKeyword(label.Keyword.WithLeadingTrivia(_indentTrivia).WithTrailingTrivia(keywordTrailingTriv))
                    .WithColonToken(label.ColonToken.WithTrailingNewLine())));
                using (WithIndent())
                {
                    node = node.WithStatements(List(node.Statements.Select(s =>
                    {
                        return s.WithLeadingTrivia(_indentTrivia).WithTrailingNewLine();
                    })));
                }
            }
            return node;
        }
    }
}
