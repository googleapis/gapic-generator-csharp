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
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.Utils
{
    /// <summary>
    /// Abstraction of a .NET type.
    /// The name "Typ" is delibrately concise as this type is used extensively
    /// throughout the rest of the code.
    /// </summary>
    internal abstract class Typ : IEquatable<Typ>
    {
        public sealed class VoidTyp : Typ
        {
            public override string Namespace => null;
            public override string Name => "void";
        }

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

        private sealed class Array : Typ
        {
            public Array(Typ elementTyp) => ElementTyp = elementTyp;
            public override string Namespace => ElementTyp.Namespace;
            public override string Name => ElementTyp.Name;
            public override Typ ElementTyp { get; }
        }

        private sealed class FromManual : Typ
        {
            public FromManual(string ns, string name, bool isEnum = false) => (Namespace, Name, IsEnum) = (ns, name, isEnum);
            public override string Namespace { get; }
            public override string Name { get; }
            public override bool IsEnum { get; }
        }

        private sealed class FromNested : Typ
        {
            public FromNested(Typ declaringTyp, string name, bool isEnum = false) => (DeclaringTyp, Name, IsEnum) = (declaringTyp, name, isEnum);
            public override string Namespace => DeclaringTyp.Namespace;
            public override string Name { get; }
            public override Typ DeclaringTyp { get; }
            public override string FullName => $"{DeclaringTyp.FullName}+{Name}";
            public override bool IsEnum { get; }
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
            public override string Name => null;
        }

        private static readonly IReadOnlyDictionary<string, Typ> s_wrapperTypes = new Dictionary<string, Typ>
        {
            { "google.protobuf.BoolValue", Of<bool?>() },
            { "google.protobuf.Int32Value", Of<int?>() },
            { "google.protobuf.UInt32Value", Of<uint?>() },
            { "google.protobuf.Int64Value", Of<long?>() },
            { "google.protobuf.UInt64Value", Of<ulong?>() },
            { "google.protobuf.FloatValue", Of<float?>() },
            { "google.protobuf.DoubleValue", Of<double?>() },
            { "google.protobuf.StringValue", Of<string>() },
            { "google.protobuf.BytesValue", Of<ByteString>() },
        };

        public static bool IsWrapperType(FieldDescriptor field)
        {
            switch (field.FieldType)
            {
                case FieldType.Message:
                    return s_wrapperTypes.ContainsKey(field.MessageType.FullName);
                default:
                    return false;
            }
        }

        public static Typ Void { get; } = new VoidTyp();

        public static Typ Of<T>() => Of(typeof(T));
        public static Typ Of(System.Type type) => new FromType(type);
        public static Typ ArrayOf(Typ typ) => new Array(typ);
        public static Typ Manual(string ns, string name, bool isEnum = false) => new FromManual(ns, name, isEnum);
        public static Typ Manual(string ns, ClassDeclarationSyntax cls) => new FromManual(ns, cls.Identifier.Text);
        public static Typ Nested(Typ declaringTyp, string name, bool isEnum = false) => new FromNested(declaringTyp, name, isEnum);
        public static Typ Generic(System.Type genericDef, params Typ[] typeArgs) => new FromGeneric(Of(genericDef), typeArgs);
        public static Typ.GenericParameter GenericParam(string name) => new Typ.GenericParameter(name);
        public static Typ.Special ClassConstraint { get; } = new Special(Special.Type.ClassConstraint);

        public static Typ Of(MessageDescriptor desc)
        {
            if (s_wrapperTypes.TryGetValue(desc.FullName, out var wkt))
            {
                return wkt;
            }
            var ns = desc.File.CSharpNamespace();
            var decls = new List<MessageDescriptor>();
            do
            {
                decls.Add(desc);
                desc = desc.ContainingType;
            } while (desc != null);
            decls.Reverse();
            var typ = Manual(ns, decls[0].Name);
            foreach (var decl in decls.Skip(1))
            {
                typ = Nested(Nested(typ, "Types"), decl.Name);
            }
            return typ;
        }

        public static Typ Of(EnumDescriptor desc) => desc.ContainingType == null ?
            Manual(desc.File.CSharpNamespace(), desc.Name, isEnum: true) :
            Nested(Nested(Of(desc.ContainingType), "Types"), desc.Name, isEnum: true);

        public static Typ Of(FieldDescriptor desc, bool? forceRepeated = null)
        {
            if (desc.IsMap)
            {
                if (forceRepeated != null)
                {
                    throw new InvalidOperationException("Cannot force repeated on a map field.");
                }
                // A map is a repeated message with key and value fields.
                var kv = desc.MessageType.Fields.InFieldNumberOrder();
                return Generic(typeof(IDictionary<,>), Of(kv[0]), Of(kv[1]));
            }
            // See https://developers.google.com/protocol-buffers/docs/proto3#scalar
            // Switch cases are ordered as in this doc. Please do not re-order.
            if (forceRepeated ?? desc.IsRepeated)
            {
                switch (desc.FieldType)
                {
                    case FieldType.Double: return Of<IEnumerable<double>>();
                    case FieldType.Float: return Of<IEnumerable<float>>();
                    case FieldType.Int32: return Of<IEnumerable<int>>();
                    case FieldType.Int64: return Of<IEnumerable<long>>();
                    case FieldType.UInt32: return Of<IEnumerable<uint>>();
                    case FieldType.UInt64: return Of<IEnumerable<ulong>>();
                    case FieldType.SInt32: return Of<IEnumerable<int>>();
                    case FieldType.SInt64: return Of<IEnumerable<long>>();
                    case FieldType.Fixed32: return Of<IEnumerable<uint>>();
                    case FieldType.Fixed64: return Of<IEnumerable<ulong>>();
                    case FieldType.SFixed32: return Of<IEnumerable<int>>();
                    case FieldType.SFixed64: return Of<IEnumerable<long>>();
                    case FieldType.Bool: return Of<IEnumerable<bool>>();
                    case FieldType.String: return Of<IEnumerable<string>>();
                    case FieldType.Bytes: return Of<IEnumerable<ByteString>>();
                    case FieldType.Message: return Generic(typeof(IEnumerable<>), Of(desc.MessageType));
                    case FieldType.Enum: return Generic(typeof(IEnumerable<>), Of(desc.EnumType));
                    default: throw new NotSupportedException($"Cannot get repeated Typ of: {desc.FieldType}");
                }
            }
            switch (desc.FieldType)
            {
                case FieldType.Double: return Of<double>();
                case FieldType.Float: return Of<float>();
                case FieldType.Int32: return Of<int>();
                case FieldType.Int64: return Of<long>();
                case FieldType.UInt32: return Of<uint>();
                case FieldType.UInt64: return Of<ulong>();
                case FieldType.SInt32: return Of<int>();
                case FieldType.SInt64: return Of<long>();
                case FieldType.Fixed32: return Of<uint>();
                case FieldType.Fixed64: return Of<ulong>();
                case FieldType.SFixed32: return Of<int>();
                case FieldType.SFixed64: return Of<long>();
                case FieldType.Bool: return Of<bool>();
                case FieldType.String: return Of<string>();
                case FieldType.Bytes: return Of<ByteString>();
                case FieldType.Message: return Of(desc.MessageType);
                case FieldType.Enum: return Of(desc.EnumType);
                default: throw new NotSupportedException($"Cannot get Typ of: {desc.FieldType}");
            }
        }

        /// <summary>The namespace of this typ.</summary>
        public abstract string Namespace { get; }

        /// <summary>The name of this typ.</summary>
        public abstract string Name { get; }

        /// <summary>Whether this typ is a primitive.</summary>
        public virtual bool IsPrimitive => false;

        /// <summary>Whether this typ is an enum.</summary>
        public virtual bool IsEnum => false;

        /// <summary>The array element typ; or <c>null</c> if not an array.</summary>
        public virtual Typ ElementTyp => null;

        /// <summary>The declaring typ; or <c>null</c> if not nested.</summary>
        public virtual Typ DeclaringTyp => null;

        /// <summary>The generic arguments of this typ; or <c>null</c> if not a generic typ.</summary>
        public virtual IEnumerable<Typ> GenericArgTyps => null;

        public virtual string FullName => $"{Namespace}.{Name}";

        public override string ToString() => FullName;
        public override int GetHashCode() => FullName.GetHashCode();
        public override bool Equals(object obj) => Equals(obj as Typ);
        public bool Equals(Typ other) => ReferenceEquals(this, other) || FullName == other?.FullName;

        public static bool operator ==(Typ a, Typ b) => a?.FullName == b?.FullName;
        public static bool operator !=(Typ a, Typ b) => !(a == b);
    }
}
