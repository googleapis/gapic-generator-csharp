// Copyright 2020 Google LLC
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
using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using static Google.Api.Generator.Utils.Typ;

namespace Google.Api.Generator.ProtoUtils
{
    /// <summary>
    /// Factory methods for <see cref="Typ"/> based on protobuf elements.
    /// </summary>
    internal static class ProtoTyp
    {
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

        public static Typ OfReflectionClass(FileDescriptor desc)
        {
            string protoFile = desc.Name;
            string name = Path.GetFileNameWithoutExtension(protoFile);
            return Manual(desc.CSharpNamespace(), name.ToUpperCamelCase() + "Reflection");
        }

        public static Typ Of(MessageDescriptor desc)
        {
            if (s_wrapperTypes.TryGetValue(desc.FullName, out var wkt))
            {
                return wkt;
            }
            var ns = desc.File.CSharpNamespace();
            var isDeprecated = desc.IsDeprecated();
            var decls = new List<MessageDescriptor>();
            do
            {
                decls.Add(desc);
                desc = desc.ContainingType;
            } while (desc != null);
            decls.Reverse();
            var typ = Manual(ns, decls[0].Name, isDeprecated: isDeprecated);
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
                var kv = desc.MessageType.Fields.InFieldNumberOrder();
                if (forceRepeated != null)
                {
                    // It turns out that you can force repeated on a map field.
                    // This is needed when the paginated results field is a map
                    // as does happen e.g. in the Compute DiREGapic.
                    return Generic(typeof(KeyValuePair<,>), Of(kv[0]), Of(kv[1]));
                }

                // A map is a repeated message with key and value fields.
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
    }
}
