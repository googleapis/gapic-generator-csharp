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
using System.Collections.Generic;
using System.Linq;
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

        public static TypeSyntax VoidType { get; } = PredefinedType(Token(SyntaxKind.VoidKeyword));
        public static ExpressionSyntax Null { get; } = LiteralExpression(SyntaxKind.NullLiteralExpression);

        public static ExpressionSyntax This { get; } = ThisExpression();

        public static NamespaceDeclarationSyntax Namespace(string ns) => NamespaceDeclaration(IdentifierName(ns));

        public static ClassDeclarationSyntax Class(Modifier modifier, Typ typ, TypeSyntax baseType = null)
        {
            var cls = ClassDeclaration(typ.Name).AddModifiers(modifier.ToSyntaxTokens());
            if (baseType != null)
            {
                cls = cls.WithBaseList(BaseList(SingletonSeparatedList<BaseTypeSyntax>(SimpleBaseType(baseType))));
            }
            return cls;
        }

        public static ParametersFunc<ConstructorDeclarationSyntax> Ctor(Modifier modifiers, Typ type) => parameters =>
            ConstructorDeclaration(Identifier(type.Name))
                .AddModifiers(modifiers.ToSyntaxTokens())
                .WithParameterList(ParameterList(SeparatedList(parameters)));

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

        public static ParameterSyntax Parameter(TypeSyntax type, string name, ExpressionSyntax @default = null)
        {
            var param = SyntaxFactory.Parameter(Identifier(name)).WithType(type);
            if (@default != null)
            {
                param = param.WithDefault(EqualsValueClause(@default));
            }
            return param;
        }

        public static LocalDeclarationStatementSyntax Local(TypeSyntax type, string name)
        {
            var varDecl = VariableDeclarator(name);
            var variable = VariableDeclaration(type, SingletonSeparatedList(varDecl));
            return LocalDeclarationStatement(variable);
        }

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

        public static FieldDeclarationSyntax Field(Modifier modifiers, TypeSyntax type, string name) =>
            FieldDeclaration(VariableDeclaration(type, SingletonSeparatedList(VariableDeclarator(name)))).AddModifiers(modifiers.ToSyntaxTokens());

        public static ExpressionSyntax Nameof(ParameterSyntax nameof) =>
            InvocationExpression(IdentifierName("nameof"))
                .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(IdentifierName(nameof.Identifier)))));

        public static ArgumentsFunc<ObjectCreationExpressionSyntax> New(TypeSyntax type) => args =>
            ObjectCreationExpression(type).WithArgumentList(RoslynConverters.CreateArgList(args));

        public static ArgumentsFunc<ArrayCreationExpressionSyntax> NewArray(ArrayTypeSyntax arrayType) => args =>
            ArrayCreationExpression(arrayType)
                .WithInitializer(InitializerExpression(SyntaxKind.ArrayInitializerExpression, SeparatedList(args.SelectMany(RoslynConverters.ToExpressions))));

        public static AwaitExpressionSyntax Await(ExpressionSyntax expr) => AwaitExpression(expr);

        public static ReturnStatementSyntax Return(ExpressionSyntax expr) => ReturnStatement(expr);

        public static IfStatementSyntax If(ExpressionSyntax condition) => IfStatement(condition, Block());
    }
}
