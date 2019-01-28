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

using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Formatting
{
    internal class WhitespaceFormatter : CSharpSyntaxRewriter
    {
        private static readonly SyntaxToken s_commaSpace = Token(SyntaxKind.CommaToken).WithTrailingSpace();
        private static IEnumerable<SyntaxToken> CommaSpaces(int count) => Enumerable.Repeat(s_commaSpace, Math.Max(0, count));
        private static readonly SyntaxTrivia s_singleIndentTrivia = SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "    ");

        public WhitespaceFormatter(int maxLineLength) : base(visitIntoStructuredTrivia: false) =>
            _maxLineLength = maxLineLength;

        private readonly int _maxLineLength;
        private SyntaxTrivia _indentTrivia = SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "");

        private IDisposable WithIndent(bool withIndent = true)
        {
            if (withIndent)
            {
                var orgIndentTrivia = _indentTrivia;
                _indentTrivia = SyntaxTrivia(SyntaxKind.WhitespaceTrivia, new string(' ', orgIndentTrivia.Span.Length + 4));
                return new Disposable(() => _indentTrivia = orgIndentTrivia);
            }
            else
            {
                return new Disposable(() => { });
            }
        }

        private SyntaxTriviaList FormatXmlDoc(SyntaxTriviaList trivList) =>
            XmlDocSplitter.Split(_indentTrivia, _maxLineLength, trivList);

        public override SyntaxNode VisitCompilationUnit(CompilationUnitSyntax node)
        {
            node = (CompilationUnitSyntax)base.VisitCompilationUnit(node);
            node = node.WithMembers(List(node.Members.Take(1).Select(m => m.WithLeadingCrLf())
                .Concat(node.Members.Skip(1))));
            return node;
        }

        public override SyntaxNode VisitUsingDirective(UsingDirectiveSyntax node)
        {
            node = (UsingDirectiveSyntax)base.VisitUsingDirective(node);
            node = node.WithLeadingTrivia(_indentTrivia);
            node = node.WithUsingKeyword(node.UsingKeyword.WithTrailingSpace());
            node = node.WithSemicolonToken(node.SemicolonToken.WithTrailingCrLf());
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
            }
            node = node.WithLeadingTrivia(_indentTrivia);
            node = node.WithNamespaceKeyword(node.NamespaceKeyword.WithTrailingSpace());
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(CarriageReturnLineFeed, _indentTrivia).WithTrailingCrLf());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingCrLf());
            node = node.WithMembers(List(
                node.Members.SkipLast(1).Select(m => m.WithTrailingCrLf(count: 2))
                    .Concat(node.Members.TakeLast(1).Select(m => m.WithTrailingCrLf(count: 1)))));
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
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(CarriageReturnLineFeed, _indentTrivia).WithTrailingCrLf());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingCrLf());
            node = node.WithMembers(List(
                node.Members.SkipLast(1).Select(m => m.WithTrailingCrLf(count: 2))
                    .Concat(node.Members.TakeLast(1).Select(m => m.WithTrailingCrLf(count: 1)))));
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

        public override SyntaxNode VisitArgumentList(ArgumentListSyntax node)
        {
            node = (ArgumentListSyntax)base.VisitArgumentList(node);
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
            node = node.WithType(node.Type.WithTrailingSpace());
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
            var postTrivia = lineSplit ? TriviaList(CarriageReturnLineFeed, _indentTrivia, s_singleIndentTrivia) : TriviaList(Space);
            using (WithIndent(lineSplit))
            {
                node = (ArrowExpressionClauseSyntax)base.VisitArrowExpressionClause(node);
            }
            node = node.WithArrowToken(node.ArrowToken.WithLeadingSpace().WithTrailingTrivia(postTrivia));
            return node;
        }

        public override SyntaxNode VisitBlock(BlockSyntax node)
        {
            using (WithIndent())
            {
                node = node.WithStatements(List(node.Statements.Select(s =>
                    Visit(s).WithLeadingTrivia(_indentTrivia).WithTrailingCrLf())));
            }
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(CarriageReturnLineFeed, _indentTrivia).WithTrailingCrLf());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia).WithTrailingCrLf());
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
                node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(CarriageReturnLineFeed, _indentTrivia).WithTrailingCrLf());
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
                // TODO: Implement this if/when required.
                throw new NotImplementedException();
            }
            else if (node.ExpressionBody != null)
            {
                node = node.WithKeyword(node.Keyword.WithLeadingTrivia(_indentTrivia));
                node = node.WithSemicolonToken(node.SemicolonToken.WithTrailingCrLf());
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
            using (WithIndent())
            {
                node = node.WithExpressions(SeparatedList(
                    node.Expressions.Select(e => Visit(e).WithLeadingTrivia(_indentTrivia)),
                    node.Expressions.Select(_ => Token(SyntaxKind.CommaToken).WithTrailingCrLf())));
            }
            node = node.WithOpenBraceToken(node.OpenBraceToken.WithLeadingTrivia(CarriageReturnLineFeed, _indentTrivia).WithTrailingCrLf());
            node = node.WithCloseBraceToken(node.CloseBraceToken.WithLeadingTrivia(_indentTrivia));
            return node;
        }

        public override SyntaxNode VisitReturnStatement(ReturnStatementSyntax node)
        {
            node = (ReturnStatementSyntax)base.VisitReturnStatement(node);
            node = node.WithReturnKeyword(node.ReturnKeyword.WithTrailingSpace());
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
    }
}
