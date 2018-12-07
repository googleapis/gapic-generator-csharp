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
using System.Linq;
using static Google.Api.Generator.RoslynUtils.RoslynConverters;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.RoslynUtils
{
    internal static class RoslynExtensions
    {
        private static readonly SyntaxToken s_semicolonToken = Token(SyntaxKind.SemicolonToken);

        public static T WithTrailingSpace<T>(this T node) where T : SyntaxNode => node.WithTrailingTrivia(Space);
        public static T WithLeadingCrLf<T>(this T node) where T : SyntaxNode => node.WithLeadingTrivia(CarriageReturnLineFeed);
        public static T WithTrailingCrLf<T>(this T node, int count = 1) where T : SyntaxNode =>
            node.WithTrailingTrivia(Enumerable.Repeat(CarriageReturnLineFeed, count));

        public static SyntaxToken WithLeadingSpace(this SyntaxToken token) => token.WithLeadingTrivia(Space);
        public static SyntaxToken WithTrailingSpace(this SyntaxToken token) => token.WithTrailingTrivia(Space);
        public static SyntaxToken WithTrailingCrLf(this SyntaxToken token) => token.WithTrailingTrivia(CarriageReturnLineFeed);

        public static ClassDeclarationSyntax WithXmlDoc(this ClassDeclarationSyntax cls, params SyntaxTrivia[] xmlDoc) =>
            cls.WithLeadingTrivia(xmlDoc);

        public static ConstructorDeclarationSyntax WithXmlDoc(this ConstructorDeclarationSyntax ctor, params SyntaxTrivia[] xmlDoc) =>
            ctor.WithLeadingTrivia(xmlDoc);

        public static MethodDeclarationSyntax WithXmlDoc(this MethodDeclarationSyntax method, params SyntaxTrivia[] xmlDoc) =>
            method.WithLeadingTrivia(xmlDoc);

        public static StatementSyntax ToStatement(this ExpressionSyntax expr) => ExpressionStatement(expr);

        private static T WithBody<T>(IEnumerable<object> code, Func<ArrowExpressionClauseSyntax, T> fnExpr, Func<BlockSyntax, T> fnBlock)
        {
            var statements = RoslynConverters.ToStatements(code).ToList();
            // Use an expression-body if the body contains exactly one expression.
            return fnExpr != null && statements.Count == 1 && statements[0] is ExpressionStatementSyntax expr ?
                fnExpr(ArrowExpressionClause(expr.Expression)) : fnBlock(Block(statements));
        }

        public static ConstructorDeclarationSyntax WithBody(this ConstructorDeclarationSyntax ctor, params object[] code) =>
            WithBody(code, x => ctor.WithExpressionBody(x).WithSemicolonToken(s_semicolonToken), ctor.WithBody);

        public static MethodDeclarationSyntax WithBody(this MethodDeclarationSyntax method, params object[] code) =>
            WithBody(code, x => method.WithExpressionBody(x).WithSemicolonToken(s_semicolonToken), method.WithBody);

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this TypeSyntax type, object method, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression, type, ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this ExpressionSyntax expr, object method, params TypeSyntax[] genericArgs) => args =>
                expr is ThisExpressionSyntax ?
                    InvocationExpression(ToSimpleName(method, genericArgs), CreateArgList(args)) :
                    InvocationExpression(MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression, expr, ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static AssignmentExpressionSyntax Assign(this PropertyDeclarationSyntax assignTo, object assignFrom) =>
            AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression, IdentifierName(assignTo.Identifier), ToExpressions(assignFrom).Single());

        public static ExpressionSyntax Access(this ParameterSyntax obj, object member, bool conditional = false) => conditional ?
            (ExpressionSyntax)ConditionalAccessExpression(IdentifierName(obj.Identifier), MemberBindingExpression(ToSimpleName(member))) :
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(obj.Identifier), ToSimpleName(member));
    }
}
