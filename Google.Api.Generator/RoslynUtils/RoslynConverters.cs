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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.RoslynUtils
{
    /// <summary>
    /// Converters between .NET objects and Roslyn types.
    /// </summary>
    internal static class RoslynConverters
    {
        public static IEnumerable<ExpressionSyntax> ToExpressions(object o) => o switch
        {
            // Order matters.
            string value => new[] { LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(value)) },
            IEnumerable v => v.Cast<object>().SelectMany(ToExpressions),
            ExpressionSyntax expression => new[] { expression },
            FieldDeclarationSyntax field => new[] { IdentifierName(field.Declaration.Variables.Single().Identifier) },
            PropertyDeclarationSyntax prop => new[] { IdentifierName(prop.Identifier) },
            ParameterSyntax param => new[] { IdentifierName(param.Identifier) },
            LocalDeclarationStatementSyntax var => new[] { IdentifierName(var.Declaration.Variables.Single().Identifier) },
            SyntaxToken identifier => new[] { IdentifierName(identifier) },
            int value => new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) },
            bool value => new[] { LiteralExpression(value ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression) },
            double value => new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) },
            float value => new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) },
            long value => new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) },
            uint value => new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) },
            ulong value => new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) },
            _ => throw new NotSupportedException($"Cannot handle ToExpressions({o.GetType()})"),
        };

        public static ExpressionSyntax ToExpression(object o) => ToExpressions(o).Single();

        private static IEnumerable<ArgumentSyntax> ToArgs(object o)
        {
            if (o is null)
            {
                return Enumerable.Empty<ArgumentSyntax>();
            }
            if (o is ITuple tuple && tuple.Length == 2 && tuple[0] is string argName)
            {
                // Named argument
                return new[] { ToArgs(tuple[1]).Single().WithNameColon(NameColon(argName)) };
            }
            if (o is ArgModifier argMod)
            {
                var kind = argMod.ModType switch
                {
                    ArgModifier.Type.Ref => SyntaxKind.RefKeyword,
                    ArgModifier.Type.Out => SyntaxKind.OutKeyword,
                    _ => throw new InvalidOperationException($"Cannot convert modtype: {argMod.ModType}"),
                };
                return new[] { Argument(ToExpressions(argMod.Arg).Single()).WithRefKindKeyword(Token(kind)) };
            }
            if (o is DeclarationExpressionSyntax decl)
            {
                // Handle `out var` parameters. This may need to be generalized later.
                return new[] { Argument(decl).WithRefKindKeyword(Token(SyntaxKind.OutKeyword)) };
            }
            // TODO: ref arguments.
            return ToExpressions(o).Select(Argument);
        }

        public static IEnumerable<StatementSyntax> ToStatements(object o)
        {
            return o switch
            {
                // Order matters.
                null => Enumerable.Empty<StatementSyntax>(),
                string v => new[] { ExpressionStatement(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(v))) },
                IEnumerable en => HandleEnumerable(en),
                StatementSyntax v => new[] { v },
                ExpressionSyntax v => new[] { v.ToStatement() },
                FieldDeclarationSyntax field => new[] { IdentifierName(field.Declaration.Variables[0].Identifier).ToStatement() },
                _ => throw new NotSupportedException($"Cannot handle ToStatement({o.GetType()})"),
            };

            IEnumerable<StatementSyntax> HandleEnumerable(IEnumerable items)
            {
                var result = new List<StatementSyntax>();
                var preTrivia = new SyntaxTriviaList();
                foreach (object item in items)
                {
                    var item1 = item is string s && s.StartsWith("// ") ? Comment(s) : item;
                    if (item1 is SyntaxTrivia triv)
                    {
                        preTrivia = preTrivia.Add(triv);
                    }
                    else
                    {
                        var statements = ToStatements(item1).ToList();
                        result.AddRange(statements.Take(1).Select(x => preTrivia.Any() ? x.WithLeadingTrivia(preTrivia) : x).Concat(statements.Skip(1)));
                        preTrivia = new SyntaxTriviaList();
                    }
                }
                if (preTrivia.Any())
                {
                    result[result.Count - 1] = result.Last().WithTrailingTrivia(preTrivia);
                }
                return result;
            }
        }

        public static ArgumentListSyntax CreateArgList(params object[] args) =>
            ArgumentList(SeparatedList(args.SelectMany(ToArgs)));

        public static SimpleNameSyntax ToSimpleName(object o, params TypeSyntax[] genericArgs)
        {
            if (o.GetType().IsEnum)
            {
                if (genericArgs.Any())
                {
                    throw new ArgumentException("Generic args must not be present for an enum");
                }
                return IdentifierName(o.ToString());
            }
            var name = o switch
            {
                string v => Identifier(v),
                PropertyDeclarationSyntax v => v.Identifier,
                MethodDeclarationSyntax v => v.Identifier,
                EnumMemberDeclarationSyntax v => v.Identifier,
                _ => throw new NotSupportedException($"Cannot handle ToSimpleName({o.GetType()})"),
            };
            name = name.WithoutTrivia();
            return genericArgs.Any() ?
                GenericName(name, TypeArgumentList(SeparatedList(genericArgs))) :
                (SimpleNameSyntax)IdentifierName(name);
        }

    }
}
