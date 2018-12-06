﻿// Copyright 2018 Google Inc. All Rights Reserved.
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
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.RoslynUtils
{
    /// <summary>
    /// Converters between .NET objects and Roslyn types.
    /// </summary>
    internal static class RoslynConverters
    {
        public static IEnumerable<ExpressionSyntax> ToExpressions(object o)
        {
            switch (o)
            {
                // Order matters.
                case string value:
                    return new[] { LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(value)) };
                case IEnumerable v:
                    return v.Cast<object>().SelectMany(ToExpressions);
                case ExpressionSyntax expression:
                    return new[] { expression };
                case FieldDeclarationSyntax field:
                    return new[] { IdentifierName(field.Declaration.Variables.Single().Identifier) };
                case PropertyDeclarationSyntax prop:
                    return new[] { IdentifierName(prop.Identifier) };
                case ParameterSyntax param:
                    return new[] { IdentifierName(param.Identifier) };
                case LocalDeclarationStatementSyntax var:
                    return new[] { IdentifierName(var.Declaration.Variables.Single().Identifier) };
                case int value:
                    return new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) };
                case bool value:
                    return new[] { LiteralExpression(value ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression) };
                case double value:
                    return new[] { LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(value)) };
                default:
                    throw new NotSupportedException($"Cannot handle ToExpressions({o.GetType()})");
            }
        }

        private static IEnumerable<ArgumentSyntax> ToArgs(object o)
        {
            // TODO: Named arguments.
            // TODO: ref arguments.
            return ToExpressions(o).Select(Argument);
        }

        public static IEnumerable<StatementSyntax> ToStatements(object o)
        {
            switch (o)
            {
                // Order matters.
                case null:
                    return Enumerable.Empty<StatementSyntax>();
                case IEnumerable v:
                    return v.Cast<object>().SelectMany(ToStatements);
                case StatementSyntax v:
                    return new[] { v };
                case ExpressionSyntax v:
                    return new[] { v.ToStatement() };
                case FieldDeclarationSyntax field:
                    return new[] { IdentifierName(field.Declaration.Variables[0].Identifier).ToStatement() };
                default:
                    throw new NotSupportedException($"Cannot handle ToStatement({o.GetType()})");
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
            SyntaxToken name;
            switch (o)
            {
                case string v:
                    name = Identifier(v);
                    break;
                case PropertyDeclarationSyntax v:
                    name = v.Identifier;
                    break;
                case MethodDeclarationSyntax v:
                    name = v.Identifier;
                    break;
                default:
                    throw new NotSupportedException($"Cannot handle ToSimpleName({o.GetType()})");
            }
            return genericArgs.Any() ?
                GenericName(name, TypeArgumentList(SeparatedList(genericArgs))) :
                (SimpleNameSyntax)IdentifierName(name);
        }

    }
}
