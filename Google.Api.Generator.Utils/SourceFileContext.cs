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

using Google.Api.Gax;
using Google.Api.Generator.Utils.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Utils
{
    /// <summary>
    /// The context tracking the state for a single C# source file.
    /// </summary>
    public abstract class SourceFileContext
    {
        private sealed class FullyAliased : SourceFileContext
        {
            private readonly IReadOnlyDictionary<string, string> _wellKnownNamespaceAliases;

            public FullyAliased(IClock clock, IReadOnlyDictionary<string, string> wellKnownNamespaceAliases)
                : base(clock) =>
                _wellKnownNamespaceAliases = wellKnownNamespaceAliases;

            // Namespace -> alias
            private readonly Dictionary<string, string> _namespaceAliases = new Dictionary<string, string>();
            private readonly HashSet<string> _namespaceAliasesOnly = new HashSet<string>();

            public override TypeSyntax Type(Typ typ) => base.Type(typ) ?? Type0(typ);

            private TypeSyntax Type0(Typ typ)
            {
                string namespaceAlias;
                if (!RequireFullyQualifiedTyp(typ) && $"{Namespace}.".StartsWith($"{typ.Namespace}."))
                {
                    // Within the current namespace and not required to force a fully-qualified name; no import required.
                    namespaceAlias = null;
                }
                else if (!_namespaceAliases.TryGetValue(typ.Namespace, out namespaceAlias))
                {
                    // A namespace that hasn't been seen before. Create an alias for it.
                    if (!_wellKnownNamespaceAliases.TryGetValue(typ.Namespace, out var rawAlias))
                    {
                        // If it's not a well-known namespace (e.g. "System"), then create an alias 
                        // using the first character of each namespace part.
                        // TODO: Ensure single-character aliased are not generated; they cause a compilation error.
                        rawAlias = typ.Namespace
                            .Split('.', StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => char.ToLowerInvariant(x[0]))
                            .Aggregate("", (a, c) => a + c);
                    }
                    // Make sure all aliases are unique by adding a numeric suffix if necessary.
                    int index = 0;
                    namespaceAlias = rawAlias;
                    while (_namespaceAliasesOnly.Contains(namespaceAlias))
                    {
                        namespaceAlias = $"{rawAlias}{++index}";
                    }
                    // Record the alias for later.
                    _namespaceAliases.Add(typ.Namespace, namespaceAlias);
                    _namespaceAliasesOnly.Add(namespaceAlias);
                }
                SimpleNameSyntax result = IdentifierName(typ.Name);
                if (typ.IsDeprecated)
                {
                    result = result.WithIdentifier(result.Identifier.WithPragmaWarning(PragmaWarnings.Obsolete));
                }
                if (typ.GenericArgTyps != null)
                {
                    // Generic typ, so return a generic name by recursively calling this method on all type args.
                    result = GenericName(result.Identifier, TypeArgumentList(SeparatedList(typ.GenericArgTyps.Select(Type))));
                }
                // Return the final TypeSyntax, aliased or not as required.
                return namespaceAlias == null ? (TypeSyntax) result : AliasQualifiedName(namespaceAlias, result);
            }

            public override CompilationUnitSyntax CreateCompilationUnit(NamespaceDeclarationSyntax ns)
            {
                var usings = _namespaceAliases
                    .OrderBy(x => x.Key)
                    .Select(x => UsingDirective(NameEquals(x.Value), IdentifierName(x.Key)));
                return AddLicense(CompilationUnit().AddUsings(usings.ToArray()).AddMembers(ns));
            }
        }

        private sealed class Unaliased : SourceFileContext
        {
            // TODO: Handle nested types.

            // Name collisions between types in imported namespaces and types from generated
            // code in the current & base namespaces are handled.
            // Name collisions between types imported from two different namespaces are not handled;
            // however, this isn't necessary as we completely control which namespaces are imported,
            // and we know that there are no collisions.

            public Unaliased(IClock clock) : base(clock) { }

            // Imported namespaces.
            private readonly HashSet<string> _imports = new HashSet<string>();
            // All type-names that have been imported through namespace imports. Used to detect name collisions.
            private readonly HashSet<string> _importedClassNames = new HashSet<string>();

            private void AddImport(string ns)
            {
                // Add import.
                if (_imports.Add(ns))
                {
                    // Track all available type names that can be used unalised.
                    // This mechanism isn't fool-proof, but will work fine in most cases because this generator
                    // depends on all assemblies that a generated library will depend on.
                    var typeNamesInNs = AppDomain.CurrentDomain.GetAssemblies()
                        .Where(a => !a.IsDynamic)
                        .SelectMany(a => a.GetExportedTypes())
                        .Where(t => t.Namespace == ns)
                        .Select(t => t.Name);
                    foreach (var typeNameInNs in typeNamesInNs)
                    {
                        _importedClassNames.Add(typeNameInNs);
                    }
                }
            }

            public override TypeSyntax Type(Typ typ) => base.Type(typ) ?? Type0(typ);

            private const string AliasableType = "rewriteable-type";

            public TypeSyntax Type0(Typ typ)
            {
                bool aliasable;
                if (!$"{Namespace}.".StartsWith($"{typ.Namespace}."))
                {
                    AddImport(typ.Namespace);
                    aliasable = false;
                }
                else
                {
                    aliasable = true;
                }
                SimpleNameSyntax result = IdentifierName(typ.Name);
                if (typ.IsDeprecated)
                {
                    result = result.WithIdentifier(result.Identifier.WithPragmaWarning(PragmaWarnings.Obsolete));
                }
                if (typ.GenericArgTyps != null)
                {
                    // Generic typ, so return a generic name by recursively calling this method on all type args.
                    result = GenericName(result.Identifier, TypeArgumentList(SeparatedList(typ.GenericArgTyps.Select(Type))));
                }
                if (aliasable)
                {
                    // Annotate this type to show it might need fully aliasing if there is a name collision.
                    result = result.WithAdditionalAnnotations(new SyntaxAnnotation(AliasableType, typ.Namespace));
                }
                return result;
            }

            public override T Import<T>(System.Type t, T o)
            {
                AddImport(t.Namespace);
                return o;
            }

            private class TypeAliaser : CSharpSyntaxRewriter
            {
                public TypeAliaser(HashSet<string> importedClassNames) => _importedClassNames = importedClassNames;

                private readonly HashSet<string> _importedClassNames;

                // Namespace -> alias
                private readonly Dictionary<string, string> _namespaceAliases = new Dictionary<string, string>();

                public IReadOnlyDictionary<string, string> NamespaceAliases => _namespaceAliases;

                public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
                {
                    var aliasable = node.GetAnnotations(AliasableType).FirstOrDefault();
                    if (aliasable != null && _importedClassNames.Contains(node.Identifier.ValueText))
                    {
                        // Type name needs fully aliasing; there is a name collision with another type.
                        var ns = aliasable.Data;
                        if (!_namespaceAliases.TryGetValue(ns, out var alias))
                        {
                            // Create alias using the first character of each namespace part.
                            // TODO: Ensure single-character aliased are not generated; they cause a compilation error.
                            alias = ns
                                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => char.ToLowerInvariant(x[0]))
                                .Aggregate("", (a, c) => a + c);
                            _namespaceAliases.Add(ns, alias);
                        }
                        // Move any comments to the new node, and return it.
                        var aliasedName = AliasQualifiedName(alias, node.WithoutTrivia());
                        return aliasedName.WithTriviaFrom(node);
                    }
                    return base.VisitIdentifierName(node);
                }
            }

            public override CompilationUnitSyntax CreateCompilationUnit(NamespaceDeclarationSyntax ns)
            {
                // Rewrite as fully-aliased any types for which there are name collisions.
                // This has to be done post-generation, as we don't know the complete set of types & imports until generation is complete.
                var typeAliaser = new TypeAliaser(_importedClassNames);
                ns = (NamespaceDeclarationSyntax) typeAliaser.Visit(ns);
                // Add using statements for standard imports, and for fully-qualifying name collisions.
                var usings = _imports.OrderBy(x => x).Select(x => UsingDirective(IdentifierName(x)))
                    .Concat(typeAliaser.NamespaceAliases.OrderBy(x => x.Key).Select(x => UsingDirective(NameEquals(x.Value), IdentifierName(x.Key))));
                ns = ns.AddUsings(usings.ToArray());
                // Return compilation-unit with license.
                var compilationUnit = CompilationUnit().AddMembers(ns);
                return AddLicense(compilationUnit);
            }
        }

        private sealed class FullyQualified : SourceFileContext
        {
            public FullyQualified(IClock clock) : base(clock) { }

            public override CompilationUnitSyntax CreateCompilationUnit(NamespaceDeclarationSyntax ns)
            {
                var compilationUnit = CompilationUnit().AddMembers(ns);
                return AddLicense(compilationUnit);
            }

            public override TypeSyntax Type(Typ typ) => base.Type(typ) ?? Type0(typ);

            public TypeSyntax Type0(Typ typ)
            {
                SimpleNameSyntax simpleName = IdentifierName(typ.Name);
                if (typ.GenericArgTyps != null)
                {
                    // Generic typ, so return a generic name by recursively calling this method on all type args.
                    simpleName = GenericName(simpleName.Identifier, TypeArgumentList(SeparatedList(typ.GenericArgTyps.Select(Type))));
                }
                NameSyntax result = simpleName;
                if (typ.Namespace != Namespace)
                {
                    // TODO: It feels like there must be a better way of doing this...
                    var segments = typ.Namespace.Split('.');
                    NameSyntax namespaceName = IdentifierName(segments[0]);
                    foreach (var segment in segments.Skip(1))
                    {
                        namespaceName = QualifiedName(namespaceName, IdentifierName(segment));
                    }
                    result = QualifiedName(namespaceName, simpleName);
                }

                return result;
            }
        }

        private static readonly IReadOnlyDictionary<string, TypeSyntax> s_predefinedTypes = new Dictionary<string, TypeSyntax>
        {
            { typeof(bool).FullName, PredefinedType(Token(SyntaxKind.BoolKeyword)) },
            { typeof(byte).FullName, PredefinedType(Token(SyntaxKind.ByteKeyword)) },
            { typeof(sbyte).FullName, PredefinedType(Token(SyntaxKind.SByteKeyword)) },
            { typeof(short).FullName, PredefinedType(Token(SyntaxKind.ShortKeyword)) },
            { typeof(ushort).FullName, PredefinedType(Token(SyntaxKind.UShortKeyword)) },
            { typeof(int).FullName, PredefinedType(Token(SyntaxKind.IntKeyword)) },
            { typeof(uint).FullName, PredefinedType(Token(SyntaxKind.UIntKeyword)) },
            { typeof(long).FullName, PredefinedType(Token(SyntaxKind.LongKeyword)) },
            { typeof(ulong).FullName, PredefinedType(Token(SyntaxKind.ULongKeyword)) },
            { typeof(char).FullName, PredefinedType(Token(SyntaxKind.CharKeyword)) },
            { typeof(decimal).FullName, PredefinedType(Token(SyntaxKind.DecimalKeyword)) },
            { typeof(double).FullName, PredefinedType(Token(SyntaxKind.DoubleKeyword)) },
            { typeof(float).FullName, PredefinedType(Token(SyntaxKind.FloatKeyword)) },
            { typeof(string).FullName, PredefinedType(Token(SyntaxKind.StringKeyword)) },
            { typeof(object).FullName, PredefinedType(Token(SyntaxKind.ObjectKeyword)) },
        };

        public static SourceFileContext CreateUnaliased(IClock clock) => new Unaliased(clock);

        public static SourceFileContext CreateFullyQualified(IClock clock) => new FullyQualified(clock);

        public static SourceFileContext CreateFullyAliased(IClock clock, IReadOnlyDictionary<string, string> wellKnownNamespaceAliases) =>
            new FullyAliased(clock, wellKnownNamespaceAliases);

        protected SourceFileContext(IClock clock) => _clock = clock;

        private readonly IClock _clock;

        /// <summary>
        /// The current namespace. This will change depending on code location.
        /// </summary>
        public string Namespace { get; private set; } = "";

        /// <summary>
        /// The stack of typ nesting. Element 0 is the outermost typ.
        /// </summary>
        public IReadOnlyList<Typ> Typs { get; private set; } = new Typ[0];

        /// <summary>
        /// The current typ. This will change depending on code location.
        /// </summary>
        public Typ CurrentTyp => Typs.Last();

        /// <summary>
        /// The current TypeSyntax. This will change depending on code location.
        /// </summary>
        public TypeSyntax CurrentType => Type(CurrentTyp);

        /// <summary>
        /// Member names known to exist in the current and outer class.
        /// Used to ensure types are fully-qualified if their name clashes with an existing member.
        /// </summary>
        public ImmutableHashSet<string> RegisteredMemberNames { get; set; } = ImmutableHashSet<string>.Empty;

        /// <summary>
        /// Move the current context into a namespace.
        /// This is relevant for namespacing of type references.
        /// Disposing of the return value moves the context back out of the namespace.
        /// </summary>
        /// <param name="ns">The namespace into which to move.</param>
        /// <returns>An <c>IDisposable</c> value that must be disposed of to move out of this namespace.</returns>
        public IDisposable InNamespace(NamespaceDeclarationSyntax ns)
        {
            var restoreNamespace = Namespace;
            Namespace = $"{Namespace}.{ns.Name}".Trim('.');
            return new Disposable(() => Namespace = restoreNamespace);
        }

        /// <summary>
        /// Move the current context into a class.
        /// This is relevant for type references to nested classes.
        /// Disposing of the return value moves the context back out of the class.
        /// </summary>
        /// <param name="cls">The class into which to move.</param>
        /// <returns>An <c>IDisposable</c> value that must be disposed of to move out of this class.</returns>
        public IDisposable InClass(ClassDeclarationSyntax cls)
        {
            var restoreTypes = Typs;
            var restoreMemberNames = RegisteredMemberNames;
            Typs = Typs.Append(Typ.Manual(Namespace, cls)).ToList();
            return new Disposable(() =>
            {
                Typs = restoreTypes;
                RegisteredMemberNames = restoreMemberNames;
            });
        }

        public void RegisterClassMemberNames(IEnumerable<string> names)
        {
            RegisteredMemberNames = RegisteredMemberNames.Union(names);
        }

        private bool RequireFullyQualifiedTyp(Typ typ) => RegisteredMemberNames.Contains(typ.Name);

        public TypeSyntax TypeDontCare => Type<int>();

        public TypeSyntax Type<T>() => Type(Typ.Of<T>());

        public TypeSyntax Type(System.Type type) => Type(Typ.Of(type));

        public virtual TypeSyntax Type(Typ typ)
        {
            if (typ is Typ.Special special)
            {
                // Handle special typ; e.g. `class` generic constraint.
                return IdentifierName($"{Typ.Special.NamePrefix}{special.SpecialType}");
            }
            if (typ is Typ.GenericParameter)
            {
                // Handle generic parameters.
                return IdentifierName(typ.Name);
            }
            if (typ is Typ.VoidTyp)
            {
                return PredefinedType(Token(SyntaxKind.VoidKeyword));
            }
            if (typ.ElementTyp != null)
            {
                // Handle array typs.
                return SyntaxFactory.ArrayType(Type(typ.ElementTyp));
            }
            if (typ.GenericArgTyps != null && $"{typ.FullName}`1" == typeof(Nullable<>).FullName)
            {
                // Handle nullable types
                return NullableType(Type(typ.GenericArgTyps.First()));
            }
            if (typ.DeclaringTyp != null)
            {
                // Handle nested typs.
                if (!RequireFullyQualifiedTyp(typ) && Typs.Count > 0 && typ.DeclaringTyp == CurrentTyp)
                {
                    // No need to fully qualify
                    return IdentifierName(typ.Name);
                }
                var outerType = Type(typ.DeclaringTyp);
                return QualifiedName((NameSyntax) outerType, IdentifierName(typ.Name));
            }
            if (s_predefinedTypes.TryGetValue(typ.FullName, out var predefinedType))
            {
                // Handle typs representing predefined C# types (e.g. `string`).
                return predefinedType;
            }
            return null;
        }

        public ArrayTypeSyntax ArrayType(Typ arrayTyp, int? size = null)
        {
            if (arrayTyp.ElementTyp is null)
            {
                throw new ArgumentException("Type argument must be an array.", nameof(arrayTyp));
            }
            if (size != null)
            {
                throw new ArgumentException("Array size specification not yet supported", nameof(size));
            }
            return ((ArrayTypeSyntax) Type(arrayTyp)).WithRankSpecifiers(SingletonList(ArrayRankSpecifier()));
        }

        public ArrayTypeSyntax ArrayType<T>(int? size = null) => ArrayType(Typ.Of<T>(), size);

        /// <summary>
        /// Force an import of referenced type.
        /// </summary>
        public virtual T Import<T>(System.Type t, T o) => o;

        public abstract CompilationUnitSyntax CreateCompilationUnit(NamespaceDeclarationSyntax ns);

        protected CompilationUnitSyntax AddLicense(CompilationUnitSyntax cu)
        {
            // TODO: Possibly allow customization of license? Is this required?
            string licenseText = $@"
// Copyright {_clock.GetCurrentDateTimeUtc().Year} Google LLC
//
// Licensed under the Apache License, Version 2.0 (the ""License"");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an ""AS IS"" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!
".TrimStart();
            var licenseTrivia = TriviaList(licenseText.Replace("\r\n", "\n").Replace('\r', '\n')
                .Split('\n')
                .Select(x => x.StartsWith("//") || x == "" ? Comment(x) : throw new InvalidOperationException("Invalid text in license.")));
            if (cu.Usings.Any())
            {
                // Using directives present, so attach license to the first using directive.
                var u0 = cu.Usings[0];
                var u0Licensed = u0.WithUsingKeyword(u0.UsingKeyword.WithLeadingTrivia(licenseTrivia));
                return cu.WithUsings(List(cu.Usings.Skip(1).Prepend(u0Licensed)));
            }
            else
            {
                // No using directives, attach license to first member (probably a namespace).
                switch (cu.Members[0])
                {
                    case NamespaceDeclarationSyntax ns0:
                        var ns0Licensed = ns0.WithNamespaceKeyword(ns0.NamespaceKeyword.WithLeadingTrivia(licenseTrivia));
                        return cu.WithMembers(List(cu.Members.Skip(1).Prepend(ns0Licensed)));
                    default:
                        throw new InvalidOperationException("Cannot find an item to attach license to.");
                }
            }
        }
    }
}
