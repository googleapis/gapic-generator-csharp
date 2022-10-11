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
using System.Threading.Tasks;
using static Google.Api.Generator.Utils.Roslyn.RoslynConverters;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Utils.Roslyn
{
    public static class RoslynExtensions
    {
        private static readonly SyntaxToken s_semicolonToken = Token(SyntaxKind.SemicolonToken);

        public static T WithLeadingSpace<T>(this T node) where T : SyntaxNode => node.WithLeadingTrivia(Space);
        public static T WithTrailingSpace<T>(this T node) where T : SyntaxNode => node.WithTrailingTrivia(Space);

        public static SyntaxToken WithLeadingSpace(this SyntaxToken token) => token.WithLeadingTrivia(Space);
        public static SyntaxToken WithTrailingSpace(this SyntaxToken token) => token.WithTrailingTrivia(Space);

        public static SyntaxToken WithPrependedLeadingTrivia(this SyntaxToken token, params SyntaxTrivia[] triv) =>
            token.HasLeadingTrivia
            ? token.WithLeadingTrivia(triv.Concat(token.LeadingTrivia))
            : token.WithLeadingTrivia(triv);

        public static SyntaxToken WithPrependedTrailingTrivia(this SyntaxToken token, params SyntaxTrivia[] triv) =>
            token.HasTrailingTrivia
            ? token.WithTrailingTrivia(triv.Concat(token.TrailingTrivia))
            : token.WithTrailingTrivia(triv);

        public static T WithXmlDoc<T>(this T node, params DocumentationCommentTriviaSyntax[] xmlDoc) where T : SyntaxNode =>
            node.WithLeadingTrivia(xmlDoc.Select(Trivia));

        public static StatementSyntax ToStatement(this ExpressionSyntax expr) => ExpressionStatement(expr);

        public static MethodDeclarationSyntax WithExplicitInterfaceSpecifier(this MethodDeclarationSyntax method, TypeSyntax interfaceType) =>
            method.WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier((NameSyntax)interfaceType));

        private static T WithBody<T>(IEnumerable<object> code, Func<ArrowExpressionClauseSyntax, T> fnExpr, Func<BlockSyntax, T> fnBlock)
        {
            var statements = ToStatements(code).ToList();
            // Use an expression-body if the body contains exactly one expression.
            if (fnExpr != null && statements.Count == 1)
            {
                if (statements[0] is ReturnStatementSyntax ret)
                {
                    return fnExpr(ArrowExpressionClause(ret.Expression));
                }
                if (statements[0] is ExpressionStatementSyntax expr)
                {
                    return fnExpr(ArrowExpressionClause(expr.Expression));
                }
            }
            return fnBlock(Block(statements));
        }

        public static ConstructorDeclarationSyntax WithBlockBody(this ConstructorDeclarationSyntax ctor, params object[] code) =>
            WithBody(code, null, ctor.WithBody);

        public static MethodDeclarationSyntax WithBlockBody(this MethodDeclarationSyntax method, params object[] code) =>
            WithBody(code, null, method.WithBody);

        public static OperatorDeclarationSyntax WithBlockBody(this OperatorDeclarationSyntax method, params object[] code) =>
            WithBody(code, null, method.WithBody);

        public static ConstructorDeclarationSyntax WithBody(this ConstructorDeclarationSyntax ctor, params object[] code) =>
            WithBody(code, x => ctor.WithExpressionBody(x).WithSemicolonToken(s_semicolonToken), ctor.WithBody);

        public static MethodDeclarationSyntax WithBody(this MethodDeclarationSyntax method, params object[] code) =>
            WithBody(code, x => method.WithExpressionBody(x).WithSemicolonToken(s_semicolonToken), method.WithBody);

        public static OperatorDeclarationSyntax WithBody(this OperatorDeclarationSyntax method, params object[] code) =>
            WithBody(code, x => method.WithExpressionBody(x).WithSemicolonToken(s_semicolonToken), method.WithBody);

        private static PropertyDeclarationSyntax PropertyBody(PropertyDeclarationSyntax prop, SyntaxKind accessorKind, object[] code)
        {
            var statements = ToStatements(code).ToList();
            if (accessorKind == SyntaxKind.GetAccessorDeclaration && !(prop.AccessorList?.Accessors.Any() ?? false) && statements.Count == 1 && statements[0] is ExpressionStatementSyntax expr)
            {
                // If this is a getter with no setter, containing a single expression, then use an expression-bodied property.
                return prop.WithExpressionBody(ArrowExpressionClause(expr.Expression)).WithSemicolonToken(s_semicolonToken);
            }
            if (accessorKind == SyntaxKind.SetAccessorDeclaration && prop.ExpressionBody != null)
            {
                prop = prop.AddAccessorListAccessors(AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithExpressionBody(prop.ExpressionBody).WithSemicolonToken(s_semicolonToken))
                    .WithExpressionBody(null);
            }
            return WithBody(code,
                x => prop.AddAccessorListAccessors(AccessorDeclaration(accessorKind).WithExpressionBody(x).WithSemicolonToken(s_semicolonToken)),
                x => prop.AddAccessorListAccessors(AccessorDeclaration(accessorKind, x)));
        }

        public static PropertyDeclarationSyntax WithGetBody(this PropertyDeclarationSyntax prop, params object[] code) => PropertyBody(prop, SyntaxKind.GetAccessorDeclaration, code);
        public static PropertyDeclarationSyntax WithSetBody(this PropertyDeclarationSyntax prop, params object[] code) => PropertyBody(prop, SyntaxKind.SetAccessorDeclaration, code);

        public static ObjectCreationExpressionSyntax WithInitializer(
            this ObjectCreationExpressionSyntax obj, params ObjectInitExpr[] inits)
        {
            if (!obj.ArgumentList.Arguments.Any())
            {
                // If calling the parameterless ctor, recreate the `new` expression without an argument list.
                obj = ObjectCreationExpression(obj.Type);
            }
            return obj.WithInitializer(InitializerExpression(SyntaxKind.ObjectInitializerExpression,
                SeparatedList<ExpressionSyntax>(inits.Select(init =>
                {
                    var property = ToSimpleName(init.PropertyName);
                    if (init.IsDeprecated)
                    {
                        property = property.WithIdentifier(property.Identifier.WithPragmaWarning(PragmaWarnings.Obsolete));
                    }
                    return AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, property, ToExpression(init.Code));
                }))));
        }

        public static ObjectCreationExpressionSyntax WithCollectionInitializer(
            this ObjectCreationExpressionSyntax obj, params object[] inits)
        {
            if (!obj.ArgumentList.Arguments.Any())
            {
                // If calling the parameterless ctor, recreate the `new` expression without an argument list.
                obj = ObjectCreationExpression(obj.Type);
            }
            return obj.WithInitializer(InitializerExpression(SyntaxKind.CollectionInitializerExpression,
                SeparatedList(inits.Select(init =>
                    init is object[] sublist
                    ? InitializerExpression(SyntaxKind.ComplexElementInitializerExpression, SeparatedList(sublist.Select(ToExpression)))
                    : ToExpression(init)))));
        }

        public static PropertyDeclarationSyntax WithInitializer(this PropertyDeclarationSyntax prop, object code) =>
            prop.WithInitializer(EqualsValueClause(ToExpression(code))).WithSemicolonToken(s_semicolonToken);

        public static FieldDeclarationSyntax WithInitializer(this FieldDeclarationSyntax field, object code) =>
            field.WithDeclaration(field.Declaration.WithVariables(
                SingletonSeparatedList(field.Declaration.Variables.Single().WithInitializer(EqualsValueClause(ToExpression(code))))));

        public static LocalDeclarationStatementSyntax WithInitializer(this LocalDeclarationStatementSyntax var, object code) =>
            var.WithDeclaration(var.Declaration.WithVariables(
                SingletonSeparatedList(var.Declaration.Variables.Single().WithInitializer(EqualsValueClause(ToExpression(code))))));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this TypeSyntax type, object method, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression, type, ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this FieldDeclarationSyntax field, object method, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName(field.Declaration.Variables.Single().Identifier), ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> MaybeObsoleteCall(
            this LocalDeclarationStatementSyntax var, string method, bool obsolete, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName(var.Declaration.Variables.Single().Identifier), ToSimpleName(method, genericArgs).MaybeWithPragmaDisableObsoleteWarning(obsolete)), CreateArgList(args));
        
        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this LocalDeclarationStatementSyntax var, object method, params TypeSyntax[] genericArgs) => args =>
                InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    IdentifierName(var.Declaration.Variables.Single().Identifier), ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<ExpressionSyntax> Call(
            this ExpressionSyntax expr, object method, bool conditional, params TypeSyntax[] genericArgs) => args =>
                expr is ThisExpressionSyntax ?
                    InvocationExpression(ToSimpleName(method, genericArgs), CreateArgList(args)) :
                    conditional ?
                        (ExpressionSyntax)ConditionalAccessExpression(expr,
                             InvocationExpression(MemberBindingExpression(ToSimpleName(method, genericArgs)), CreateArgList(args))) :
                        InvocationExpression(MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression, expr, ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this ExpressionSyntax expr, object method, params TypeSyntax[] genericArgs) => args => (InvocationExpressionSyntax)Call(expr, method, false, genericArgs)(args);

        public static RoslynBuilder.ArgumentsFunc<ExpressionSyntax> Call(
            this ParameterSyntax param, object method, bool conditional, params TypeSyntax[] genericArgs) => args =>
                conditional ?
                    (ExpressionSyntax)ConditionalAccessExpression(IdentifierName(param.Identifier),
                        InvocationExpression(MemberBindingExpression(ToSimpleName(method, genericArgs)), CreateArgList(args))) :
                    InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName(param.Identifier), ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(
            this ParameterSyntax param, object method, params TypeSyntax[] genericArgs) => args => (InvocationExpressionSyntax)Call(param, method, false, genericArgs)(args);

        public static RoslynBuilder.ArgumentsFunc<InvocationExpressionSyntax> Call(this PropertyDeclarationSyntax property, object method, params TypeSyntax[] genericArgs) => args =>
            InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName(property.Identifier), ToSimpleName(method, genericArgs)), CreateArgList(args));

        public static InvocationExpressionSyntax ConfigureAwait(this ExpressionSyntax expr) =>
            expr.Call(nameof(Task.ConfigureAwait))(false);

        public static AssignmentExpressionSyntax Assign(this PropertyDeclarationSyntax assignTo, object assignFrom) =>
            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(assignTo.Identifier), ToExpression(assignFrom));

        public static AssignmentExpressionSyntax Assign(this ParameterSyntax assignTo, object assignFrom) =>
            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(assignTo.Identifier), ToExpression(assignFrom));

        public static AssignmentExpressionSyntax Assign(this FieldDeclarationSyntax assignTo, object assignFrom) =>
            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(assignTo.Declaration.Variables.Single().Identifier), ToExpression(assignFrom));

        public static AssignmentExpressionSyntax AssignThisQualified(this FieldDeclarationSyntax assignTo, object assignFrom) =>
            AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression,
                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(assignTo.Declaration.Variables.Single().Identifier)),
                ToExpression(assignFrom));

        public static AssignmentExpressionSyntax Assign(this ExpressionSyntax assignTo, object assignFrom) =>
            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, assignTo, ToExpression(assignFrom));

        public static AssignmentExpressionSyntax Assign(this LocalDeclarationStatementSyntax assignTo, object assignFrom) =>
            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                IdentifierName(assignTo.Declaration.Variables.Single().Identifier), ToExpressions(assignFrom).Single());

        public static ExpressionSyntax Access(this TypeSyntax type, object member) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, type, ToSimpleName(member));

        public static ExpressionSyntax Access(this ParameterSyntax obj, object member, bool conditional = false) => conditional ?
            (ExpressionSyntax)ConditionalAccessExpression(IdentifierName(obj.Identifier), MemberBindingExpression(ToSimpleName(member))) :
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(obj.Identifier), ToSimpleName(member));

        public static MemberAccessExpressionSyntax Access(this LocalDeclarationStatementSyntax var, object member) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(var.Declaration.Variables.Single().Identifier), ToSimpleName(member));

        public static ExpressionSyntax Access(this PropertyDeclarationSyntax prop, object member) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(prop.Identifier), ToSimpleName(member));

        public static ExpressionSyntax Access(this FieldDeclarationSyntax field, object member) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(field.Declaration.Variables.Single().Identifier), ToSimpleName(member));

        public static ExpressionSyntax Access(this ExpressionSyntax expr, object member, bool conditional = false) => conditional ?
            (ExpressionSyntax) ConditionalAccessExpression(expr, MemberBindingExpression(ToSimpleName(member)))  :
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, expr, ToSimpleName(member));

        public static ExpressionSyntax ElementAccess(this LocalDeclarationStatementSyntax var, object element) =>
            ElementAccessExpression(IdentifierName(var.Declaration.Variables.Single().Identifier),
                BracketedArgumentList(SeparatedList(ToExpressions(element).Select(Argument))));

        public static ExpressionSyntax ElementAccess(this DeclarationExpressionSyntax decl, object element) =>
            ElementAccessExpression(IdentifierName(((SingleVariableDesignationSyntax)decl.Designation).Identifier),
                BracketedArgumentList(SeparatedList(ToExpressions(element).Select(Argument))));

        public static ExpressionSyntax ElementAccess(this ParameterSyntax var, object element) =>
            ElementAccessExpression(IdentifierName(var.Identifier),
                BracketedArgumentList(SeparatedList(ToExpressions(element).Select(Argument))));

        public static ExpressionSyntax NullCoalesce(this ExpressionSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.CoalesceExpression, ToExpression(lhs), ToExpression(rhs));

        public static ExpressionSyntax NullCoalesce(this ParameterSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.CoalesceExpression, ToExpression(lhs), ToExpression(rhs));

        public static ExpressionSyntax NullCoalesce(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.CoalesceExpression, ToExpression(lhs), ToExpression(rhs));

        public static ExpressionSyntax NotEqualTo(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.NotEqualsExpression, ToExpression(lhs), ToExpression(rhs));

        public static ExpressionSyntax NotEqualTo(this PropertyDeclarationSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.NotEqualsExpression, ToExpression(lhs), ToExpression(rhs));

        public static IfStatementSyntax Then(this IfStatementSyntax @if, params object[] code) =>
            WithBody(code, fnExpr: null, fnBlock: @if.WithStatement);

        public static IfStatementSyntax Else(this IfStatementSyntax @if, params object[] code) =>
            WithBody(code, fnExpr: null, fnBlock: x => @if.WithElse(ElseClause(x)));

        public static ConditionalExpressionSyntax ConditionalOperator(this ExpressionSyntax condition, object whenTrue, object whenFalse) =>
            ConditionalExpression(condition, ToExpression(whenTrue), ToExpression(whenFalse));

        public static BinaryExpressionSyntax As(this ParameterSyntax parameter, TypeSyntax type) =>
            BinaryExpression(SyntaxKind.AsExpression, IdentifierName(parameter.Identifier), type);

        public static BinaryExpressionSyntax Equality(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.EqualsExpression, ToExpression(lhs), ToExpression(rhs));

        public static BinaryExpressionSyntax Equality(this ExpressionSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.EqualsExpression, lhs, ToExpression(rhs));

        public static BinaryExpressionSyntax Equality(this ParameterSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.EqualsExpression, IdentifierName(lhs.Identifier), ToExpression(rhs));

        public static ExpressionSyntax Equality(this PropertyDeclarationSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.EqualsExpression, ToExpression(lhs), ToExpression(rhs));

        public static BinaryExpressionSyntax LessThan(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.LessThanExpression, ToExpression(lhs), ToExpression(rhs));

        public static BinaryExpressionSyntax LessThanOrEqual(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.LessThanOrEqualExpression, ToExpression(lhs), ToExpression(rhs));

        public static BinaryExpressionSyntax Minus(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.SubtractExpression, ToExpression(lhs), ToExpression(rhs));

        public static BinaryExpressionSyntax Plus(this ExpressionSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.AddExpression, lhs, ToExpression(rhs));

        public static BinaryExpressionSyntax Plus(this LocalDeclarationStatementSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.AddExpression, ToExpression(lhs), ToExpression(rhs));

        public static PostfixUnaryExpressionSyntax PlusPlus(this LocalDeclarationStatementSyntax var) =>
            PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, ToExpression(var));

        public static BinaryExpressionSyntax Or(this ExpressionSyntax lhs, object rhs) =>
            BinaryExpression(SyntaxKind.LogicalOrExpression, lhs, ToExpression(rhs));

        public static ParameterSyntax Ref(this ParameterSyntax parameter) => parameter.WithModifiers(TokenList(Token(SyntaxKind.RefKeyword)));
        public static ParameterSyntax Out(this ParameterSyntax parameter) => parameter.WithModifiers(TokenList(Token(SyntaxKind.OutKeyword)));

        public static MethodDeclarationSyntax AddGenericConstraint(this MethodDeclarationSyntax method, Typ.GenericParameter genericParam, params TypeSyntax[] constraints)
        {
            var constraint = TypeParameterConstraintClause(IdentifierName(genericParam.Name), SeparatedList(constraints.Select(MakeConstraint)));
            return method.WithConstraintClauses(List(method.ConstraintClauses.Append(constraint)));

            static TypeParameterConstraintSyntax MakeConstraint(TypeSyntax type)
            {
                if (type is SimpleNameSyntax simple && simple.Identifier.Text.StartsWith(Typ.Special.NamePrefix))
                {
                    var special = Enum.Parse<Typ.Special.Type>(simple.Identifier.Text.Substring(Typ.Special.NamePrefix.Length));
                    return special switch
                    {
                        Typ.Special.Type.ClassConstraint => ClassOrStructConstraint(SyntaxKind.ClassConstraint),
                        _ => throw new ArgumentException($"Cannot handle special constraint: '{special}'"),
                    };
                }
                return TypeConstraint(type);
            }
        }

        public static RoslynBuilder.ArgumentsFunc<MethodDeclarationSyntax> WithAttribute(this MethodDeclarationSyntax method, TypeSyntax attrType) =>
            args => method.WithAttributeLists(SingletonList(AttributeList(SingletonSeparatedList(Attribute((NameSyntax)attrType, CreateAttributeArgList(args))))));

        public static RoslynBuilder.ArgumentsFunc<PropertyDeclarationSyntax> WithAttribute(this PropertyDeclarationSyntax property, TypeSyntax attrType) =>
            args => property.WithAttributeLists(SingletonList(AttributeList(SingletonSeparatedList(Attribute((NameSyntax) attrType, CreateAttributeArgList(args))))));

        /// <summary>
        /// Returns the specified method declaration syntax, potentially (if <paramref name="condition"/> is true) adding an attribute specified
        /// by <paramref name="attrType"/>. This is a function so that if obtaining the attribute type has side-effects,
        /// those side effects will not have an impact unless the attribute is added.
        /// </summary>
        public static RoslynBuilder.ArgumentsFunc<MethodDeclarationSyntax> MaybeWithAttribute(this MethodDeclarationSyntax method, bool condition, Func<TypeSyntax> attrType) =>
            condition
            ? args => method.WithAttributeLists(SingletonList(AttributeList(SingletonSeparatedList(Attribute((NameSyntax)attrType(), CreateAttributeArgList(args))))))
            : (RoslynBuilder.ArgumentsFunc<MethodDeclarationSyntax>) (args => method);

        /// <summary>
        /// Returns the specified property declaration syntax, potentially (if <paramref name="condition"/> is true) adding an attribute specified
        /// by <paramref name="attrType"/>. This is a function so that if obtaining the attribute type has side-effects,
        /// those side effects will not have an impact unless the attribute is added.
        /// </summary>
        public static RoslynBuilder.ArgumentsFunc<PropertyDeclarationSyntax> MaybeWithAttribute(this PropertyDeclarationSyntax property, bool condition, Func<TypeSyntax> attrType) =>
            condition
            ? args => property.WithAttributeLists(SingletonList(AttributeList(SingletonSeparatedList(Attribute((NameSyntax)attrType(), CreateAttributeArgList(args))))))
            : (RoslynBuilder.ArgumentsFunc<PropertyDeclarationSyntax>) (arg => property);

        public static RoslynBuilder.ArgumentsFunc<EnumMemberDeclarationSyntax> WithAttribute(this EnumMemberDeclarationSyntax enumDeclaration, TypeSyntax attrType) =>
            args => enumDeclaration.WithAttributeLists(SingletonList(AttributeList(SingletonSeparatedList(Attribute((NameSyntax) attrType, CreateAttributeArgList(args))))));

        public static BinaryExpressionSyntax Is(this ExpressionSyntax expr, TypeSyntax type) => BinaryExpression(SyntaxKind.IsExpression, expr, type);

        public static BinaryExpressionSyntax Is(this ParameterSyntax expr, TypeSyntax type) => IdentifierName(expr.Identifier).Is(type);

        public static SwitchStatementSyntax WithDefault(this SwitchStatementSyntax @switch, object code) =>
            @switch.AddSections(SwitchSection(SingletonList<SwitchLabelSyntax>(DefaultSwitchLabel()), List(ToStatements(code))));

        public static SimpleNameSyntax MaybeWithPragmaDisableObsoleteWarning(this SimpleNameSyntax syntax, bool obsolete) =>
            obsolete ? syntax.WithPragmaWarning(PragmaWarnings.Obsolete) : syntax;

        public static SimpleNameSyntax WithPragmaWarning(this SimpleNameSyntax syntax, string errorCode) =>
            syntax.WithIdentifier(syntax.Identifier.WithPragmaWarning(errorCode));

        public static SyntaxToken WithPragmaWarning(this SyntaxToken token, string errorCode) =>
            token.WithAdditionalAnnotations(new SyntaxAnnotation(PragmaWarnings.AnnotationKind, errorCode));

        public static MethodDeclarationSyntax WithParameterLineBreaks(this MethodDeclarationSyntax method) =>
            method.WithParameterList(method.ParameterList.WithAdditionalAnnotations(Annotations.LineBreakAnnotation));
    }
}
