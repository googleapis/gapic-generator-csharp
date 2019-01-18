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

using Google.Api.Generator.ProtoUtils;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.Utils
{
    // TODO: If this name causes too much confusion change it to something
    // more descriptive, possibly "ClrType".
    /// <summary>
    /// Abstraction of a .NET type.
    /// The name "Typ" is delibrately concise as this type is used extensively
    /// throughout the rest of the code.
    /// </summary>
    internal abstract class Typ
    {
        private sealed class FromType : Typ
        {
            public FromType(System.Type type) => _type = type;
            private System.Type _type;
            public override string Namespace => _type.Namespace;
            public override string Name => _type.Name.Split('`')[0];
            public override bool IsPrimitive => _type.IsPrimitive;
            public override Typ ElementTyp => _type.IsArray ? Of(_type.GetElementType()) : null;
            public override Typ DeclaringTyp => _type.IsNested ? Of(_type.DeclaringType) : null;
            public override IEnumerable<Typ> GenericArgTyps => _type.IsGenericType ? _type.GetGenericArguments().Select(Of) : null;
        }

        private sealed class FromManual : Typ
        {
            public FromManual(string ns, string name) => (Namespace, Name) = (ns, name);
            public override string Namespace { get; }
            public override string Name { get; }
        }

        private sealed class FromNested : Typ
        {
            public FromNested(Typ declaringTyp, string name) => (DeclaringTyp, Name) = (declaringTyp, name);
            public override string Namespace => DeclaringTyp.Namespace;
            public override string Name { get; }
            public override Typ DeclaringTyp { get; }
            public override string FullName => $"{DeclaringTyp.FullName}+{Name}";
        }

        private sealed class FromGeneric : Typ
        {
            /// <summary>
            /// Construct a closed generic typ, from an open typ def and the generic args.
            /// </summary>
            /// <param name="def">Open generic typ definition.</param>
            /// <param name="typeArgs">The typ arguments; must be the same quantity as in the typ definition.</param>
            public FromGeneric(Typ def, IEnumerable<Typ> typeArgs) => (_def, GenericArgTyps) = (def, typeArgs);
            private Typ _def;
            public override string Namespace => _def.Namespace;
            public override string Name => _def.Name;
            public override Typ DeclaringTyp => _def.DeclaringTyp;
            public override IEnumerable<Typ> GenericArgTyps { get; }
            public override string FullName => $"{base.FullName}<{string.Join(", ", GenericArgTyps.Select(x => x.FullName))}>";
        }

        public sealed class GenericParameter : Typ
        {
            public GenericParameter(string name) => Name = name;
            public override string Namespace => throw new InvalidOperationException();
            public override string Name { get; }
            public override string FullName => $"<{Name}>";
        }

        public sealed class Special : Typ
        {
            public const string NamePrefix = "::special::";
            public enum Type { ClassConstraint }
            public Special(Type type) => SpecialType = type;
            public Type SpecialType { get; }
            public override string Namespace => throw new InvalidOperationException();
            public override string Name => throw new InvalidOperationException();
        }

        public static Typ Of<T>() => Of(typeof(T));
        public static Typ Of(System.Type type) => new FromType(type);
        public static Typ Of(MessageDescriptor desc) => Manual(desc.File.CSharpNamespace(), desc.Name);
        public static Typ Manual(string ns, string name) => new FromManual(ns, name);
        public static Typ Manual(string ns, ClassDeclarationSyntax cls) => new FromManual(ns, cls.Identifier.Text);
        public static Typ Nested(Typ declaringTyp, string name) => new FromNested(declaringTyp, name);
        public static Typ Generic(System.Type genericDef, params Typ[] typeArgs) => new FromGeneric(Of(genericDef), typeArgs);
        public static Typ.GenericParameter GenericParam(string name) => new Typ.GenericParameter(name);
        public static Typ.Special ClassConstraint { get; } = new Special(Special.Type.ClassConstraint);

        /// <summary> the namespace of this typ. </summary>
        public abstract string Namespace { get; }

        /// <summary> The name of this typ. </summary>
        public abstract string Name { get; }

        /// <summary> Whether this typ is a primitive. </summary>
        public virtual bool IsPrimitive => false;

        /// <summary> The array element typ; or <c>null</c> if not an array. </summary>
        public virtual Typ ElementTyp => null;

        /// <summary> The declaring typ; or <c>null</c> if not nested. </summary>
        public virtual Typ DeclaringTyp => null;

        /// <summary> The generic arguments of this typ; or <c>null</c> if not a generic typ.  </summary>
        public virtual IEnumerable<Typ> GenericArgTyps => null;

        public virtual string FullName => $"{Namespace}.{Name}";

        public override string ToString() => FullName;
        public override int GetHashCode() => FullName.GetHashCode();
        public override bool Equals(object obj) => obj is Typ other && FullName == other.FullName;

        public static bool operator ==(Typ a, Typ b) => a?.FullName == b?.FullName;
        public static bool operator !=(Typ a, Typ b) => !(a == b);
    }
}
