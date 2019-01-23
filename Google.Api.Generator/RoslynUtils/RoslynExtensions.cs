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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public static T WithXmlDoc<T>(this T node, params DocumentationCommentTriviaSyntax[] xmlDoc) where T : SyntaxNode =>
            node.WithLeadingTrivia(xmlDoc.Select(Trivia));

        public static StatementSyntax ToStatement(this ExpressionSyntax expr) => ExpressionStatement(expr);

        private static T WithBody<T>(IEnumerable<object> code, Func<ArrowExpressionClauseSyntax, T> fnExpr, Func<BlockSyntax, T> fnBlock)
        {
            var statements = ToStatements(code).ToList();
            // Use an expression-body if the body contains exactly one expression.
            return fnExpr != null && statements.Count == 1 && statements[0] is ExpressionStatementSyntax expr ?
                fnExpr(ArrowExpressionClause(expr.Expression)) : fnBlock(Block(statements));
        }

        public static ConstructorDeclarationSyntax WithBody(this ConstructorDeclarationSyntax ctor, params object[] code) =>
            WithBody(code, x => ctor.WithExpressionBody(x).WithSemicolonToken(s_semicolonToken), ctor.WithBody);

        public static MethodDeclarationSyntax WithBody(this MethodDeclarationSyntax method, params object[] code) =>
            WithBody(code, x => method.WithExpressionBody(x).WithSemicolonToken(s_semicolonToken), method.WithBody);

        public static PropertyDeclarationSyntax WithGetBody(this PropertyDeclarationSyntax prop, params object[] code)
        {
            var statements = ToStatements(code).ToList();
            if (!(prop.AccessorList?.Accessors.Any() ?? false) && statements.Count == 1 && statements[0] is ExpressionStatementSyntax expr)
            {
                // If this is a getter with no setter, containing a single expression, then use an expression-bodied property.
                return prop.WithExpressionBody(ArrowExpressionClause(expr.Expression)).WithSemicolonToken(s_semicolonToken);
            }
            return WithBody(code,
                x => prop.AddAccessorListAccessors(AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(x).WithSemicolonToken(s_semicolonToken)),
                x => prop.AddAccessorListAccessors(AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, x)));
        }

        public static ObjectCreationExpressionSyntax WithInitializer(
            this ObjectCreationExpressionSyntax obj, params (string propertyName, object code)[] inits)
        {
            if (!obj.ArgumentList.Arguments.Any())
            {
                // If calling the parameterless ctor, recreate the `new` expression without an argument list.
                obj = ObjectCreationExpression(obj.Type);
            }
            return obj.WithInitializer(InitializerExpression(SyntaxKind.ObjectInitializerExpression,
                SeparatedList<ExpressionSyntax>(inits.Select(init =>
                    AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, ToSimpleName(init.propertyName), ToExpressions(init.code).Single())))));
        }

        public static PropertyDeclarationSyntax WithInitializer(this PropertyDeclarationSyntax prop, object code) =>
            prop.WithInitializer(EqualsValueClause(((ExpressionStatementSyntax)ToStatements(code).Single()).Expression)).WithSemicolonToken(s_semicolonToken);

        public static FieldDeclarationSyntax WithInitializer(this FieldDeclarationSyntax field, object code) =>
            field.WithDeclaration(field.Declaration.WithVariables(
                SingletonSeparatedList(field.Declaration.Variables.Single().WithInitializer(
                    EqualsValueClause(((ExpressionStatementSyntax)ToStatements(code).Single()).Expression)))));

        public static LocalDeclarationStatementSyntax WithInitializer(this LocalDeclarationStatementSyntax var, object code) =>
            var.WithDeclaration(var.Declaration.WithVariables(
                SingletonSeparatedList(var.Declaration.Variables.Single().WithInitializer(
                    EqualsValueClause(((ExpressionStatementSyntax)ToStatements(code).Single()).Expression)))));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this TypeSyntax type, object method, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression, type, ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this FieldDeclarationSyntax field, object method, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName(field.Declaration.Variables.Single().Identifier), ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this ExpressionSyntax expr, object method, params TypeSyntax[] genericArgs) => args =>
                expr is ThisExpressionSyntax ?
                    InvocationExpression(ToSimpleName(method, genericArgs), CreateArgList(args)) :
                    InvocationExpression(MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression, expr, ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this LocalDeclarationStatementSyntax var, object method, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName(var.Declaration.Variables.Single().Identifier), ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static InvocationExpressionSyntax ConfigureAwait(this ExpressionSyntax expr) =>
            expr.Call(nameof(Task.ConfigureAwait))(false);

        public static AssignmentExpressionSyntax Assign(this PropertyDeclarationSyntax assignTo, object assignFrom) =>
            AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression, IdentifierName(assignTo.Identifier), ToExpressions(assignFrom).Single());

        public static AssignmentExpressionSyntax Assign(this ParameterSyntax assignTo, object assignFrom) =>
            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(assignTo.Identifier), ToExpressions(assignFrom).Single());

        public static AssignmentExpressionSyntax Assign(this FieldDeclarationSyntax assignTo, object assignFrom) =>
            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                IdentifierName(assignTo.Declaration.Variables.Single().Identifier), ToExpressions(assignFrom).Single());

        public static ExpressionSyntax Access(this TypeSyntax type, object member) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, type, ToSimpleName(member));

        public static ExpressionSyntax Access(this ParameterSyntax obj, object member, bool conditional = false) => conditional ?
            (ExpressionSyntax)ConditionalAccessExpression(IdentifierName(obj.Identifier), MemberBindingExpression(ToSimpleName(member))) :
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(obj.Identifier), ToSimpleName(member));

        public static ExpressionSyntax Access(this LocalDeclarationStatementSyntax var, object member) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(var.Declaration.Variables.Single().Identifier), ToSimpleName(member));

        public static ExpressionSyntax NullCoalesce(this ParameterSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.CoalesceExpression, ToExpressions(lhs).Single(), ToExpressions(rhs).Single());

        public static ExpressionSyntax NotEqualTo(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.NotEqualsExpression, ToExpressions(lhs).Single(), ToExpressions(rhs).Single());

        public static IfStatementSyntax Then(this IfStatementSyntax @if, params object[] code) =>
            WithBody(code, fnExpr: null, fnBlock: @if.WithStatement);

        public static ParameterSyntax Ref(this ParameterSyntax parameter) => parameter.WithModifiers(TokenList(Token(SyntaxKind.RefKeyword)));

        public static MethodDeclarationSyntax AddGenericConstraint(this MethodDeclarationSyntax method, Typ.GenericParameter genericParam, params TypeSyntax[] constraints)
        {
            var constraint = TypeParameterConstraintClause(IdentifierName(genericParam.Name), SeparatedList(constraints.Select(MakeConstraint)));
            return method.WithConstraintClauses(List(method.ConstraintClauses.Append(constraint)));

            TypeParameterConstraintSyntax MakeConstraint(TypeSyntax type)
            {
                if (type is SimpleNameSyntax simple && simple.Identifier.Text.StartsWith(Typ.Special.NamePrefix))
                {
                    var special = Enum.Parse<Typ.Special.Type>(simple.Identifier.Text.Substring(Typ.Special.NamePrefix.Length));
                    switch (special)
                    {
                        case Typ.Special.Type.ClassConstraint:
                            return ClassOrStructConstraint(SyntaxKind.ClassConstraint);
                        default:
                            throw new ArgumentException($"Cannot handle special constraint: '{special}'");
                    }
                }
                return TypeConstraint(type);
            }
        }
    }
}
