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
using System.Text;
using static Google.Api.Generator.Utils.Roslyn.RoslynConverters;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Utils.Roslyn
{
    /// <summary>
    /// Helper methods to simplify constructing Roslyn syntax.
    /// </summary>
    public static class RoslynBuilder
    {
        private static readonly SyntaxToken s_semicolonToken = Token(SyntaxKind.SemicolonToken);

        public delegate T ParametersFunc<T>(params ParameterSyntax[] parameters);
        public delegate T ArgumentsFunc<T>(params object[] args);
        public delegate T CodeFunc<T>(params object[] code);
        public delegate EnumDeclarationSyntax EnumFunc(params EnumMemberDeclarationSyntax[] items);
        public delegate SwitchStatementSyntax SwitchFunc(params (object caseLiteral, object code)[] cases);

        public static TypeSyntax VoidType { get; } = PredefinedType(Token(SyntaxKind.VoidKeyword));
        public static ExpressionSyntax Null { get; } = LiteralExpression(SyntaxKind.NullLiteralExpression);
        public static ExpressionSyntax This { get; } = ThisExpression();
        public static ExpressionSyntax Value { get; } = IdentifierName("value");
        public static ExpressionSyntax Default { get; } = LiteralExpression(SyntaxKind.DefaultLiteralExpression);

        public static NamespaceDeclarationSyntax Namespace(string ns) => NamespaceDeclaration(IdentifierName(ns));

        public static EnumFunc Enum(Modifier modifier, Typ typ) => items =>
            EnumDeclaration(typ.Name).AddModifiers(modifier.ToSyntaxTokens()).WithMembers(SeparatedList(items));

        public static EnumMemberDeclarationSyntax EnumMember(string identifier, int? value = null)
        {
            var enumMember = EnumMemberDeclaration(identifier);
            if (value is int v)
            {
                enumMember = enumMember.WithEqualsValue(EqualsValueClause(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(v))));
            }
            return enumMember;
        }

        public static ClassDeclarationSyntax Class(Modifier modifier, Typ typ, params TypeSyntax[] baseTypes)
        {
            var cls = ClassDeclaration(typ.Name).AddModifiers(modifier.ToSyntaxTokens());
            if (baseTypes.Any())
            {
                cls = cls.WithBaseList(BaseList(SeparatedList<BaseTypeSyntax>(baseTypes.Select(SimpleBaseType))));
            }
            if (typ.GenericArgTyps is IEnumerable<Typ> typeParameters)
            {
                cls = cls.AddTypeParameterListParameters(typeParameters.Select(tp => TypeParameter(tp.Name)).ToArray());
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

        public static ParametersFunc<ConstructorDeclarationSyntax> Ctor(Modifier modifiers, ClassDeclarationSyntax cls, ConstructorInitializerSyntax initializer = null) => parameters =>
        {
            var ctor = ConstructorDeclaration(cls.Identifier)
                .AddModifiers(modifiers.ToSyntaxTokens())
                .WithParameterList(ParameterList(SeparatedList(parameters)));
            if (initializer != null)
            {
                ctor = ctor.WithInitializer(initializer);
            }
            return ctor;
        };

        public static ConstructorInitializerSyntax BaseInitializer(params object[] args) =>
            ConstructorInitializer(SyntaxKind.BaseConstructorInitializer, CreateArgList(args));

        public static ConstructorInitializerSyntax ThisInitializer(params object[] args) =>
            ConstructorInitializer(SyntaxKind.ThisConstructorInitializer, CreateArgList(args));

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
            var param = SyntaxFactory.Parameter(Identifier(Keywords.PrependAtIfKeyword(name)));
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

        public static LocalDeclarationStatementSyntax Local(TypeSyntax type, string name)
        {
            var varDecl = VariableDeclarator(Keywords.PrependAtIfKeyword(name));
            var variable = VariableDeclaration(type, SingletonSeparatedList(varDecl));
            return LocalDeclarationStatement(variable);
        }

        public static PropertyDeclarationSyntax Property(Modifier modifiers, TypeSyntax type, string name) =>
            PropertyDeclaration(type, name).AddModifiers(modifiers.ToSyntaxTokens());

        public static PropertyDeclarationSyntax AutoProperty(Modifier modifiers, TypeSyntax type, string name, bool hasSetter = false, bool setterIsPrivate = false)
        {
            var accessors = new List<AccessorDeclarationSyntax>
            {
                AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(s_semicolonToken)
            };
            if (hasSetter)
            {
                var setter = AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(s_semicolonToken);
                if (setterIsPrivate)
                {
                    setter = setter.WithModifiers(TokenList(Token(SyntaxKind.PrivateKeyword).WithTrailingSpace()));
                }
                accessors.Add(setter);
            }
            return PropertyDeclaration(type, name)
                .AddModifiers(modifiers.ToSyntaxTokens())
                .AddAccessorListAccessors(accessors.ToArray());
        }

        public static CodeFunc<LambdaExpressionSyntax> Lambda(ParameterSyntax parameter, bool async = false) => code =>
        {
            var statements = ToStatements(code).ToArray();
            var expr = SimpleLambdaExpression(parameter.WithType(null), statements.Length == 1 ? MakeExpr(statements[0]) : Block(statements));
            if (async)
            {
                expr = expr.WithAsyncKeyword(Token(SyntaxKind.AsyncKeyword));
            }
            return expr;

            static CSharpSyntaxNode MakeExpr(CSharpSyntaxNode c) =>
                c is ReturnStatementSyntax ret ? ret.Expression :
                c is ExpressionStatementSyntax exprState ? exprState.Expression :
                c;
        };

        public static CodeFunc<LambdaExpressionSyntax> LambdaTyped(ParameterSyntax parameter, bool async = false) => code =>
        {
            var expr = code.Length == 1 ?
                ParenthesizedLambdaExpression(Params(), ToExpression(code)) :
                ParenthesizedLambdaExpression(Params(), Block(ToStatements(code).ToArray()));
            if (async)
            {
                expr = expr.WithAsyncKeyword(Token(SyntaxKind.AsyncKeyword));
            }
            return expr;

            ParameterListSyntax Params() => ParameterList(SeparatedList(Enumerable.Repeat(parameter, parameter == null ? 0 : 1)));
        };

        public static FieldDeclarationSyntax Field(Modifier modifiers, TypeSyntax type, string name) =>
            FieldDeclaration(VariableDeclaration(type, SingletonSeparatedList(VariableDeclarator(name)))).AddModifiers(modifiers.ToSyntaxTokens());

        public static ExpressionSyntax Nameof(ParameterSyntax nameof) =>
            InvocationExpression(IdentifierName("nameof"))
                .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(IdentifierName(nameof.Identifier)))));

        public static InitializerExpressionSyntax CollectionInitializer(params object[] exprs) =>
            InitializerExpression(SyntaxKind.CollectionInitializerExpression, SeparatedList(ToExpressions(exprs)));

        public static InitializerExpressionSyntax ComplexElementInitializer(params object[] exprs) =>
            InitializerExpression(SyntaxKind.ComplexElementInitializerExpression, SeparatedList<ExpressionSyntax>(
                exprs.SelectMany(x => ToExpressions(x)).SelectMany(x => new SyntaxNodeOrToken[] { Token(SyntaxKind.CommaToken), x }).Skip(1)));

        public static ArgumentsFunc<ObjectCreationExpressionSyntax> New(TypeSyntax type) => args =>
            ObjectCreationExpression(type).WithArgumentList(CreateArgList(args));

        public static ArgumentsFunc<ArrayCreationExpressionSyntax> NewArray(ArrayTypeSyntax arrayType) => args =>
            ArrayCreationExpression(arrayType)
                .WithInitializer(InitializerExpression(SyntaxKind.ArrayInitializerExpression, SeparatedList(args.SelectMany(ToExpressions))));

        public static ArrayCreationExpressionSyntax NewArray(ArrayTypeSyntax arrayType, ExpressionSyntax rank) =>
            ArrayCreationExpression(arrayType.WithRankSpecifiers(SingletonList(ArrayRankSpecifier(SingletonSeparatedList(rank)))));

        public static CodeFunc<ForEachStatementSyntax> ForEach(TypeSyntax type, SyntaxToken varName, object expr) => code =>
            ForEachStatement(type, varName, ToExpression(expr), Block(ToStatements(code)));

        public static CodeFunc<ForStatementSyntax> For(LocalDeclarationStatementSyntax decl, ExpressionSyntax condition, ExpressionSyntax incr) => code =>
            ForStatement(decl.Declaration, SeparatedList<ExpressionSyntax>(), condition, SingletonSeparatedList(incr), Block(ToStatements(code)));

        public static CodeFunc<WhileStatementSyntax> While(object conditionExpr) => code =>
            WhileStatement(ToExpression(conditionExpr), Block(ToStatements(code)));

        public static AwaitExpressionSyntax Await(object expr) => AwaitExpression(ToExpression(expr));

        public static ReturnStatementSyntax Return(object expr) => ReturnStatement(ToExpression(expr));

        public static IfStatementSyntax If(ExpressionSyntax condition) => IfStatement(condition, Block());

        public static IfStatementSyntax If(ParameterSyntax condition) => IfStatement(IdentifierName(condition.Identifier), Block());

        public static ThrowExpressionSyntax Throw(ExpressionSyntax obj) => ThrowExpression(obj);

        public static PrefixUnaryExpressionSyntax Not(object expr) => PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, ToExpression(expr));

        public static ParenthesizedExpressionSyntax Parens(object expr) => ParenthesizedExpression(ToExpression(expr));

        public static ArgModifier Ref(object arg) => new ArgModifier(ArgModifier.Type.Ref, arg);

        public static ArgModifier Out(object arg) => new ArgModifier(ArgModifier.Type.Out, arg);

        public static DeclarationExpressionSyntax OutVar(LocalDeclarationStatementSyntax local) =>
            DeclarationExpression(local.Declaration.Type, SingleVariableDesignation(local.Declaration.Variables[0].Identifier));

        public static SyntaxTrivia BlankLine => CarriageReturnLineFeed;

        public static InterpolatedStringExpressionSyntax Dollar(params FormattableString[] fss)
        {
            var parts = fss.SelectMany(fs =>
                fs.Format.Aggregate((content: new StringBuilder(), inCode: false, result: new List<InterpolatedStringContentSyntax>()), (acc, c) =>
                {
                    if (acc.inCode)
                    {
                        if (c == '}')
                        {
                            var indexParts = acc.content.ToString().Split(':');
                            var arg = fs.GetArgument(int.Parse(indexParts[0]));
                            if (indexParts.Length > 1 && indexParts[1] == "raw")
                            {
                                AppendString(arg.ToString(), acc.result);
                            }
                            else
                            {
                                acc.result.Add(Interpolation(ToExpression(arg)));
                            }
                            return (acc.content.Clear(), false, acc.result);
                        }
                        return (acc.content.Append(c), true, acc.result);
                    }
                    else
                    {
                        if (c == '{')
                        {
                            AppendString(acc.content.ToString(), acc.result);
                            return (acc.content.Clear(), true, acc.result);
                        }
                        return (acc.content.Append(c), false, acc.result);
                    }
                }, acc =>
                {
                    AppendString(acc.content.ToString(), acc.result);
                    return acc.result;
                }));
            return InterpolatedStringExpression(Token(SyntaxKind.InterpolatedStringStartToken), List(parts));

            static void AppendString(string s, List<InterpolatedStringContentSyntax> list)
            {
                if (s.Length > 0)
                {
                    list.Add(InterpolatedStringText(Token(TriviaList(), SyntaxKind.InterpolatedStringTextToken, s, s, TriviaList())));
                }
            }
        }

        public static SwitchFunc Switch(ExpressionSyntax expr) => cases => SwitchStatement(expr, List(
            cases.Select(@case => SwitchSection(SingletonList<SwitchLabelSyntax>(CaseSwitchLabel(ToExpression(@case.caseLiteral))), List(ToStatements(@case.code))))));

        public static SwitchFunc Switch(ParameterSyntax expr) => Switch(IdentifierName(expr.Identifier));

        public static SwitchFunc Switch(PropertyDeclarationSyntax expr) => Switch(IdentifierName(expr.Identifier));

        public static CastExpressionSyntax Cast(TypeSyntax type, ExpressionSyntax expr) => CastExpression(type, expr);
        
        public static CastExpressionSyntax Cast(TypeSyntax type, PropertyDeclarationSyntax expr) => Cast(type, IdentifierName(expr.Identifier));

        public static CheckedExpressionSyntax CheckedCast(TypeSyntax type, ExpressionSyntax expr) => CheckedExpression(SyntaxKind.CheckedExpression, CastExpression(type, expr));

        public static ArgumentsFunc<ExpressionSyntax> ThisQualifiedCall(object method, params TypeSyntax[] genericArgs) => args =>
            InvocationExpression(MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression, This, ToSimpleName(method, genericArgs)), CreateArgList(args));
    }
}
