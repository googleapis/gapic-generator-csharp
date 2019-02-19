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
using static Google.Api.Generator.RoslynUtils.RoslynConverters;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.RoslynUtils
{
    /// <summary>
    /// Helper methods to simplify constructing Roslyn syntax.
    /// </summary>
    internal static class RoslynBuilder
    {
        private static readonly SyntaxToken s_semicolonToken = Token(SyntaxKind.SemicolonToken);

        public delegate T ParametersFunc<T>(params ParameterSyntax[] parameters);
        public delegate T ArgumentsFunc<T>(params object[] args);
        public delegate T CodeFunc<T>(params object[] code);

        public static TypeSyntax VoidType { get; } = PredefinedType(Token(SyntaxKind.VoidKeyword));
        public static ExpressionSyntax Null { get; } = LiteralExpression(SyntaxKind.NullLiteralExpression);
        public static ExpressionSyntax This { get; } = ThisExpression();
        public static ExpressionSyntax Value { get; } = IdentifierName("value");

        public static NamespaceDeclarationSyntax Namespace(string ns) => NamespaceDeclaration(IdentifierName(ns));

        public static ClassDeclarationSyntax Class(Modifier modifier, Typ typ, params TypeSyntax[] baseTypes)
        {
            var cls = ClassDeclaration(typ.Name).AddModifiers(modifier.ToSyntaxTokens());
            if (baseTypes.Any())
            {
                cls = cls.WithBaseList(BaseList(SeparatedList<BaseTypeSyntax>(baseTypes.Select(SimpleBaseType))));
            }
            return cls;
        }

        public static ParametersFunc<ConstructorDeclarationSyntax> Ctor(Modifier modifiers, Typ type, ConstructorInitializerSyntax initializer = null) => parameters =>
        {
            var ctor = ConstructorDeclaration(Identifier(type.Name))
                .AddModifiers(modifiers.ToSyntaxTokens())
                .WithParameterList(ParameterList(SeparatedList(parameters)));
            if (initializer != null)
            {
                ctor = ctor.WithInitializer(initializer);
            }
            return ctor;
        };

        public static ParametersFunc<ConstructorDeclarationSyntax> Ctor(Modifier modifiers, ClassDeclarationSyntax cls) => parameters =>
            ConstructorDeclaration(cls.Identifier).AddModifiers(modifiers.ToSyntaxTokens()).WithParameterList(ParameterList(SeparatedList(parameters)));


        public static ConstructorInitializerSyntax BaseInitializer(params object[] args) =>
            ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, CreateArgList(args));

        public static ParametersFunc<MethodDeclarationSyntax> Method(
            Modifier modifiers, TypeSyntax returnType, string name, params Typ.GenericParameter[] genericParams) => parameters =>
        {
            var method = MethodDeclaration(returnType, name).AddModifiers(modifiers.ToSyntaxTokens())
                .WithParameterList(ParameterList(SeparatedList(parameters)));
            if (genericParams.Any())
            {
                method = method.WithTypeParameterList(
                    TypeParameterList(SeparatedList(genericParams.Select(p => TypeParameter(Identifier(p.Name))))));
            }
            return method;
        };

        public static ParametersFunc<MethodDeclarationSyntax> PartialMethod(
            string name, params Typ.GenericParameter[] genericParams) => parameters =>
                Method(Modifier.Partial, VoidType, name, genericParams)(parameters).WithSemicolonToken(s_semicolonToken);

        private static readonly IReadOnlyDictionary<string, SyntaxKind> operatorNameTokens = new Dictionary<string, SyntaxKind>
        {
            { "==", SyntaxKind.EqualsEqualsToken },
            { "!=", SyntaxKind.ExclamationEqualsToken },
        };
        public static ParametersFunc<OperatorDeclarationSyntax> OperatorMethod(TypeSyntax returnType, string name) => parameters =>
            OperatorDeclaration(returnType, Token(operatorNameTokens[name]))
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword)))
                .WithParameterList(ParameterList(SeparatedList(parameters)));

        public static ParameterSyntax Parameter(TypeSyntax type, string name, ExpressionSyntax @default = null)
        {
            var param = SyntaxFactory.Parameter(Identifier(name));
            if (type != null)
            {
                param = param.WithType(type);
            }
            if (@default != null)
            {
                param = param.WithDefault(EqualsValueClause(@default));
            }
            return param;
        }

        public static DeclarationExpressionSyntax ParameterOutVar(TypeSyntax type, string name) => DeclarationExpression(type, SingleVariableDesignation(Identifier(name)));

        public static LocalDeclarationStatementSyntax Local(TypeSyntax type, string name)
        {
            var varDecl = VariableDeclarator(name);
            var variable = VariableDeclaration(type, SingletonSeparatedList(varDecl));
            return LocalDeclarationStatement(variable);
        }

        public static PropertyDeclarationSyntax Property(Modifier modifiers, TypeSyntax type, string name) =>
            PropertyDeclaration(type, name).AddModifiers(modifiers.ToSyntaxTokens());

        public static PropertyDeclarationSyntax AutoProperty(Modifier modifiers, TypeSyntax type, string name, bool hasSetter = false)
        {
            var accessors = new List<AccessorDeclarationSyntax>
            {
                AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(s_semicolonToken)
            };
            if (hasSetter)
            {
                accessors.Add(AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(s_semicolonToken));
            }
            return PropertyDeclaration(type, name)
                .AddModifiers(modifiers.ToSyntaxTokens())
                .AddAccessorListAccessors(accessors.ToArray());
        }

        public static LambdaExpressionSyntax Lambda(ParameterSyntax parameter, object code) =>
            SimpleLambdaExpression(parameter, ToExpression(code));

        public static FieldDeclarationSyntax Field(Modifier modifiers, TypeSyntax type, string name) =>
            FieldDeclaration(VariableDeclaration(type, SingletonSeparatedList(VariableDeclarator(name)))).AddModifiers(modifiers.ToSyntaxTokens());

        public static ExpressionSyntax Nameof(ParameterSyntax nameof) =>
            InvocationExpression(IdentifierName("nameof"))
                .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(IdentifierName(nameof.Identifier)))));

        public static InitializerExpressionSyntax CollectionInitializer(params object[] exprs) =>
            InitializerExpression(SyntaxKind.CollectionInitializerExpression, SeparatedList(ToExpressions(exprs)));

        public static ArgumentsFunc<ObjectCreationExpressionSyntax> New(TypeSyntax type) => args =>
            ObjectCreationExpression(type).WithArgumentList(RoslynConverters.CreateArgList(args));

        public static ArgumentsFunc<ArrayCreationExpressionSyntax> NewArray(ArrayTypeSyntax arrayType) => args =>
            ArrayCreationExpression(arrayType)
                .WithInitializer(InitializerExpression(SyntaxKind.ArrayInitializerExpression, SeparatedList(args.SelectMany(ToExpressions))));

        public static AwaitExpressionSyntax Await(ExpressionSyntax expr) => AwaitExpression(expr);

        public static ReturnStatementSyntax Return(object expr) => ReturnStatement(ToExpression(expr));

        public static IfStatementSyntax If(ExpressionSyntax condition) => IfStatement(condition, Block());

        public static ThrowExpressionSyntax Throw(ExpressionSyntax obj) => ThrowExpression(obj);

        public static PrefixUnaryExpressionSyntax Not(object expr) => PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, ToExpression(expr));

        public static ParenthesizedExpressionSyntax Parens(object expr) => ParenthesizedExpression(ToExpression(expr));

        public static ArgModifier Ref(object arg) => new ArgModifier(ArgModifier.Type.Ref, arg);

        public static SyntaxTrivia BlankLine => CarriageReturnLineFeed;
    }
}
