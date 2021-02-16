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
using System.Text.RegularExpressions;
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

            public Unaliased(
                IClock clock, IReadOnlyDictionary<string, string> wellKnownNamespaceAliases, IReadOnlyCollection<Regex> avoidAliasingNamespaceRegex) : base(clock) =>
                (_wellKnownNamespaceAliases, _avoidAliasingNamespaceRegex) = (wellKnownNamespaceAliases, avoidAliasingNamespaceRegex);

            private readonly IReadOnlyDictionary<string, string> _wellKnownNamespaceAliases;
            private readonly IReadOnlyCollection<Regex> _avoidAliasingNamespaceRegex;
            // Seen namespaces. The associated bool value indicates whether we may skip import or not.
            private readonly Dictionary<string, bool> _seenNamespaces = new Dictionary<string, bool>();
            // Seen types. This will be used to avoid name collisions.
            private readonly HashSet<Typ> _seenTypes = new HashSet<Typ>();

            public override TypeSyntax Type(Typ typ) => base.Type(typ) ?? Type0(typ);

            private const string FromNamespace = "from-namespace";
            private const string ContextNamespace = "context-namespace";

            public TypeSyntax Type0(Typ typ)
            {
                TrackAsSeen(typ);

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
                // Always annotate with the namespace information.
                result = result.WithAdditionalAnnotations(
                    new SyntaxAnnotation(FromNamespace, typ.Namespace),
                    new SyntaxAnnotation(ContextNamespace, Namespace));
                return result;
            }

            private void TrackAsSeen(Typ typ)
            {
                // Track the namespace as seen and whether import may be skipped or not.
                // Let's not override any explicit import.
                // Current Namespace may change, so once we must include an import, let's not override
                // that either.
                if (!_seenNamespaces.TryGetValue(typ.Namespace, out bool maySkipImport) || maySkipImport)
                {
                    _seenNamespaces[typ.Namespace] = IsParentOrSameNamespace(typ.Namespace, Namespace);
                }
                // Track the type as seen.
                _seenTypes.Add(typ);
            }

            public override T Import<T>(System.Type t, T o)
            {
                // An explicit import can never be skipped.
                _seenNamespaces[t.Namespace] = false;
                return o;
            }

            private static bool IsParentOrSameNamespace(string supposedParent, string supposedChild) =>
                $"{supposedChild}.".StartsWith($"{supposedParent}.");

            private class TypeAliaser : CSharpSyntaxRewriter
            {
                // Collection of aliased namespaces as generated by this class. Namespace -> alias.
                private readonly Dictionary<string, string> _aliasedNamespaces = new Dictionary<string, string>();
                // Collection of unaliased namespaces as generated by this class.
                private readonly HashSet<string> _unaliasedNamespaces = new HashSet<string>();
                // Collection of types that need to be aliased as generated by this class.
                // These were colliding types whose namespaces were aliased to avoid the collision. Type -> namespaces.
                private readonly Dictionary<string, HashSet<string>> _collidingAliasedTypes = new Dictionary<string, HashSet<string>>();
                // Collection of types that may need to be aliased because their namespaces were aliased to avoid collisions
                // from other types. These types may not be aliased if used in the context of their own namespace. Type -> namespaces.
                private readonly Dictionary<string, HashSet<string>> _nonCollidingAliasedTypes = new Dictionary<string, HashSet<string>>();

                public IReadOnlyDictionary<string, string> AliasedNamespaces => _aliasedNamespaces;
                public IReadOnlyCollection<string> UnaliasedNamespaces => _unaliasedNamespaces;

                public static TypeAliaser Create(
                    IReadOnlyDictionary<string, bool> seenNamespaces,
                    IReadOnlyCollection<Typ> seenTypes,
                    IReadOnlyDictionary<string, string> wellKnownNamespaceAliases,
                    IReadOnlyCollection<Regex> avoidAliasingNamespaceRegex)
                {
                    // Let's copy some of these collections over so we can make changes.
                    // Also, copy them to more usable collections.
                    var mustImportNs = seenNamespaces.Where(nsInfo => !nsInfo.Value).Select(nsInfo => nsInfo.Key).ToHashSet();
                    // Get type names and the namespeces through which they would be imported if those namespaces were to be
                    // imported unaliased. We don't look at skippable namespaces because those are only imported aliased, if imported.
                    // We can safely exclude generic types because we don't generate any generic types and we know there
                    // are no clashes between generic types in the non generated dependencies.
                    // This mechanism isn't fool-proof, but will work fine in most cases because this generator
                    // depends on all assemblies that a generated library will depend on.
                    // Type name -> namespaces through which it could be imported.
                    var couldBeImportedTypes = AppDomain.CurrentDomain.GetAssemblies()
                        .Where(a => !a.IsDynamic)
                        .SelectMany(a => a.GetExportedTypes())
                        .Where(t => !t.IsGenericTypeDefinition && mustImportNs.Contains(t.Namespace))
                        .GroupBy(t => t.Name, t => t.Namespace);
                    // Colliding types are either seen types that collide between them or seen types that collide with a type
                    // that would be imported (even if unused) when importing an unaliased namespace, or both.
                    // We also skip generic types here.
                    // Notice that in collidingTypes we always have at least one seen type of each name (because of the join);
                    // we don't care about collisions from unseen imported types between them.
                    var collidingTypes = seenTypes
                        .Where(t => t.GenericArgTyps?.Any() != true)
                        .GroupBy(t => t.Name, t => t.Namespace)
                        .Join(
                            couldBeImportedTypes,
                            seen => seen.Key,
                            imported => imported.Key,
                            (seen, imported) => (type: seen.Key, namespaces: new HashSet<string>(seen.Concat(imported))))
                        .Where(tNs => tNs.namespaces.Count > 1)
                        .ToDictionary(tNs => tNs.type, tNs => tNs.namespaces);

                    // We now have all the information we need to know which types and namespaces need aliasing.
                    // This is what we'll generate:
                    // Collection of aliased namespaces. Namespace -> alias.
                    Dictionary<string, string> aliasedNamespaces = new Dictionary<string, string>();
                    // Collection of unaliased namespaces.
                    HashSet<string> unaliasedNamespaces = new HashSet<string>();
                    // Collection of types that need to be aliased. Type -> namespaces.
                    Dictionary<string, HashSet<string>> collidingAliasedTypes = new Dictionary<string, HashSet<string>>();
                    // Collection of types that may need to be aliased because their namespaces were aliased to avoid collisions
                    // from other types. These types may not be aliased if used in the context of their own namespace. Type -> namespaces.
                    Dictionary<string, HashSet<string>> nonCollidingAliasedTypes = new Dictionary<string, HashSet<string>>();

                    // Let's alias namespaces until we have no collisions.
                    while (GetTopCollidingNamespace() is string topCollidingNamespace)
                    {
                        // First alias the namespace.
                        var alias = ImportAliased(topCollidingNamespace);
                        // Now alias all seen types from that namespace, colliding or not.
                        foreach (var t in seenTypes.Where(t => t.Namespace == topCollidingNamespace))
                        {
                            AliasType(t.Name, topCollidingNamespace);
                        }
                        // If there are still colliding types from this namespace, we can safely remove them.
                        // They are not seen types that we need to alias, they are types that would have
                        // been imported if the namespace were to be imported unaliased, but we just aliased
                        // the namespace.
                        RemoveNamespaceFromColliding(topCollidingNamespace);
                    }

                    // We have no collisions now. We can safely import remaining namespaces.
                    unaliasedNamespaces.UnionWith(mustImportNs);

                    return new TypeAliaser(aliasedNamespaces, unaliasedNamespaces, collidingAliasedTypes, nonCollidingAliasedTypes);

                    // Find the next namespace to be aliased.
                    string GetTopCollidingNamespace() =>
                        collidingTypes
                            // This just flips the collection from type => namespace to namespace => type.
                            .SelectMany(tNs => tNs.Value.Select(ns => (ns, t: tNs.Key)))
                            // Now we group by namespace.
                            .GroupBy(nsT => nsT.ns, nsT => nsT.t)
                            // Prioritize the ones that we are free to alias.
                            .OrderBy(nsG => avoidAliasingNamespaceRegex.Any(regex => regex.IsMatch(nsG.Key)))
                            // Then the ones that introduce the most collisions for seen types.
                            // Think about Google.Cloud.Spanner.V1.Type, System.Type and Google.Protobuf.WellKnownTypes.Type:
                            // the only one actually used in snippets is the one from Spanner, but the other two are imported because
                            // the namespaces are imported. If we alias the Spanner namespace then we don't need to alias the other two
                            // but if we alias Protobuf, then we still need to alias one of the two remaining.
                            .ThenByDescending(nsg => nsg.Where(tn => seenTypes.Any(t => t.Name == tn && t.Namespace == nsg.Key)).Count())
                            // Then the ones that introduce the most collisions overall.
                            .ThenByDescending(nsg => nsg.Count())
                            // Then the ones that that have well known aliases, it's preferably to alias those.
                            .ThenByDescending(nsg => wellKnownNamespaceAliases.ContainsKey(nsg.Key))
                            // Then lastly avoid introducing unnecessary imports.
                            .ThenByDescending(nsg => mustImportNs.Contains(nsg.Key))
                            .FirstOrDefault()?.Key;

                    // Creates an alias for the given namespace and imports it as such.
                    string ImportAliased(string ns)
                    {
                        if (!wellKnownNamespaceAliases.TryGetValue(ns, out var alias))
                        {
                            // Create alias using the first character of each namespace part.
                            // TODO: Ensure single-character aliased are not generated; they cause a compilation error.
                            alias = ns
                                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => char.ToLowerInvariant(x[0]))
                                .Aggregate("", (a, c) => a + c);
                        }
                        // Add this namespace and it's alias to the aliased collection.
                        aliasedNamespaces.Add(ns, alias);
                        // We have now imported this namespace as aliased so remove it from pending namespaces.
                        // Note that this may have been a skippable namespace, in which case it wasn't in the
                        // mustImportNs collection to start with.
                        mustImportNs.Remove(ns);
                        return alias;
                    }

                    void AliasType(string t, string ns)
                    {
                        // Remove the pair from colliding types if this was a colliding type.
                        // Add the pair to the corresponding aliased types collection.
                        if (RemoveTypeFromColliding(t, ns))
                        {
                            Add(collidingAliasedTypes, t, ns);
                        }
                        else
                        {
                            Add(nonCollidingAliasedTypes, t, ns);
                        }
                    }

                    void Add(IDictionary<string, HashSet<string>> tNamespaces, string t, string ns)
                    {
                        if (!tNamespaces.TryGetValue(t, out HashSet<string> namespaces))
                        {
                            namespaces = tNamespaces[t] = new HashSet<string>();
                        }
                        namespaces.Add(ns);
                    }

                    void RemoveNamespaceFromColliding(string ns)
                    {
                        foreach(var tNs in collidingTypes.Where(ctNs => ctNs.Value.Contains(ns)).ToList())
                        {
                            RemoveTypeFromColliding(tNs.Key, ns);
                        }
                    }

                    bool RemoveTypeFromColliding(string t, string ns)
                    {
                        if (collidingTypes.TryGetValue(t, out var collidingTypeNamespaces) && collidingTypeNamespaces.Contains(ns))
                        {
                            if (collidingTypeNamespaces.Count == 2 || // If we remove one of the remaining two collisions...
                                // or if after removal the remaining collisions are between unseen imported types...
                                !collidingTypeNamespaces.Any(ctNs => ctNs != ns && seenTypes.Any(typ => typ.Name == t && typ.Namespace == ctNs)))
                            {
                                // ... then this type is not colliding anymore
                                collidingTypes.Remove(t);
                            }
                            else
                            {
                                // Even after removal of this collision, there are remaining collisions from seen types
                                // with this name, so we just remove this particular collision.
                                collidingTypeNamespaces.Remove(ns);
                            }
                            return true;
                        }
                        return false;
                    }
                }

                private TypeAliaser(
                    Dictionary<string, string> aliasedNamespaces,
                    HashSet<string> unaliasedNamespaces,
                    Dictionary<string, HashSet<string>> collidingAliasedTypes,
                    Dictionary<string, HashSet<string>> nonCollidingAliasedTypes) =>
                    (_aliasedNamespaces, _unaliasedNamespaces, _collidingAliasedTypes, _nonCollidingAliasedTypes) = 
                    (aliasedNamespaces, unaliasedNamespaces, collidingAliasedTypes, nonCollidingAliasedTypes);

                public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node) =>
                    VisitSimpleNameSyntax(node) ?? base.VisitIdentifierName(node);

                public override SyntaxNode VisitGenericName(GenericNameSyntax node) =>
                    VisitSimpleNameSyntax(node) ?? base.VisitGenericName(node);

                private SyntaxNode VisitSimpleNameSyntax(SimpleNameSyntax node)
                {
                    if (GetAlias(node) is string alias)
                    {
                        // Move any comments to the new node, and return it.
                        var aliasedName = AliasQualifiedName(alias, node.WithoutTrivia());
                        return aliasedName.WithTriviaFrom(node);
                    }

                    return null;
                }

                private string GetAlias(SimpleNameSyntax node)
                {
                    if (node.GetAnnotations(FromNamespace).FirstOrDefault()?.Data is string typNs)
                    {
                        var typName = node.Identifier.ValueText;

                        // We alias if this was an aliased colliding type, or if it was an aliased not colliding type that's beeing used
                        // outside of it's own namespace.
                        if (ContainsType(_collidingAliasedTypes, typName, typNs) ||
                            (ContainsType(_nonCollidingAliasedTypes, typName, typNs) && !IsParentOrSameNamespace(typNs, node.GetAnnotations(ContextNamespace).Single().Data)))
                        {
                            // Type name needs fully aliasing; there is a name collision with another type.
                            return _aliasedNamespaces[typNs];
                        }
                    }
                    return null;

                    static bool ContainsType(IDictionary<string, HashSet<string>> types, string typ, string ns) =>
                       types.TryGetValue(typ, out HashSet<string> namespaces) && namespaces.Contains(ns);
                }
            }

            public override CompilationUnitSyntax CreateCompilationUnit(NamespaceDeclarationSyntax ns)
            {
                // Rewrite as fully-aliased any types for which there are name collisions.
                // This has to be done post-generation, as we don't know the complete set of types & imports until generation is complete.
                var typeAliaser = TypeAliaser.Create(_seenNamespaces, _seenTypes, _wellKnownNamespaceAliases, _avoidAliasingNamespaceRegex);
                ns = (NamespaceDeclarationSyntax) typeAliaser.Visit(ns);
                // Add using statements for standard imports, and for fully-qualifying name collisions.
                var usings = typeAliaser.UnaliasedNamespaces.OrderBy(x => x).Select(x => UsingDirective(IdentifierName(x)))
                    .Concat(typeAliaser.AliasedNamespaces.OrderBy(x => x.Key).Select(x => UsingDirective(NameEquals(x.Value), IdentifierName(x.Key))));
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

        public static SourceFileContext CreateUnaliased(
            IClock clock, IReadOnlyDictionary<string, string> wellKnownNamespaceAliases, IReadOnlyCollection<Regex> avoidAliasingNamespaceRegex) =>
            new Unaliased(clock, wellKnownNamespaceAliases, avoidAliasingNamespaceRegex);

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

        // TODO: make InClass(ClassDeclarationSyntax) work for nested classes.

        /// <summary>
        /// Move the current context into a class.
        /// This is relevant for type references to nested classes.
        /// Disposing of the return value moves the context back out of the class.
        /// Note: this method currently fails when called within a nested class.
        /// </summary>
        /// <param name="cls">The class into which to move.</param>
        /// <returns>An <c>IDisposable</c> value that must be disposed of to move out of this class.</returns>
        public IDisposable InClass(ClassDeclarationSyntax cls) => InClass(Typ.Manual(Namespace, cls));

        /// <summary>
        /// Move the current context into a class.
        /// This is relevant for type references to nested classes.
        /// Disposing of the return value moves the context back out of the class.
        /// </summary>
        /// <param name="cls">The class into which to move.</param>
        /// <returns>An <c>IDisposable</c> value that must be disposed of to move out of this class.</returns>
        public IDisposable InClass(Typ typ)
        {
            var restoreTypes = Typs;
            var restoreMemberNames = RegisteredMemberNames;
            Typs = Typs.Append(typ).ToList();
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
            if (typ is Typ.VarTyp)
            {
                return IdentifierName("var");
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
