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
using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Google.Api.Generator.ProtoUtils
{
    internal static class ProtoExtensions
    {
        private static T ReadOption<T>(IDescriptor desc, string optionName)
        {
            // There is no support for reading various standard options; so use reflection.
            object descProto = desc.GetType().GetProperty("Proto", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(desc);
            object options = descProto.GetType().GetProperty("Options").GetValue(descProto);
            object result = options?.GetType().GetProperty(optionName).GetValue(options);
            return result != null ? (T)result : default;
        }

        public static string CSharpNamespace(this FileDescriptor desc)
        {
            // Order of looking for C# namespace: "csharp_namespace" option, proto package.
            // TODO: Also look for the "metadata" proto annotation: Metadata.PackageName
            string ns = ReadOption<string>(desc, "CsharpNamespace");
            if (!string.IsNullOrEmpty(ns))
            {
                return ns;
            }
            // As a fallback, capitalize the first character of each part of the proto package.
            return string.Join(".", desc.Package.Split('.').Select(x => x.ToUpperCamelCase()));
        }

        public static bool IsDeprecated(this FieldDescriptor desc) => ReadOption<bool>(desc, "Deprecated");

        public static IEnumerable<string> DocLines(this DescriptorDeclaration decl) =>
            decl?.LeadingComments.Split('\n').Select(x => x.Trim())
                .SkipWhile(string.IsNullOrWhiteSpace).Reverse().SkipWhile(string.IsNullOrWhiteSpace).Reverse() ??
                    Enumerable.Empty<string>();

        public static string CSharpPropertyName(this FieldDescriptor field) => field.Name.ToUpperCamelCase();

        public static string CSharpFieldName(this FieldDescriptor field) => field.Name.ToLowerCamelCase();

        internal static string RemoveEnumPrefix(string enumName, string valueName)
        {
            // Duplicate of code in:
            // https://github.com/protocolbuffers/protobuf/blob/3bf05b88eaf938526f7daee85ab6fb1efb0e809c/src/google/protobuf/compiler/csharp/csharp_helpers.cc#L270
            enumName = enumName.ToUpperCamelCase(forceAllChars: true);
            valueName = valueName.ToUpperCamelCase(forceAllChars: true);
            if (valueName.Length > enumName.Length && valueName.ToLowerInvariant().StartsWith(enumName.ToLowerInvariant()))
            {
                // Final .ToUpperCamelCase() required as the first char may otherwise be lower.
                // This call will only affect the first character.
                valueName = valueName.Substring(enumName.Length).ToUpperCamelCase();
            }
            if (char.IsDigit(valueName[0]))
            {
                valueName = "_" + valueName;
            }
            return valueName;
        }

        public static string CSharpName(this EnumValueDescriptor desc) => RemoveEnumPrefix(desc.EnumDescriptor.Name, desc.Name);

        private static IEnumerable<(ulong number, ByteString byteString)> GetRepeated(CustomOptions opts, int field)
        {
            // There is no way of reading a repeated custom option.
            // The normal `TryGetMessage<T>()` method returns the single merged value of all repeated options.
            // See proto code for details for the members reflected over:
            // https://github.com/protocolbuffers/protobuf/blob/3.8.x/csharp/src/Google.Protobuf/Reflection/CustomOptions.cs
            var valuesByField = typeof(CustomOptions).GetField("valuesByField", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(opts);
            // valuesByField is a Dictionary<int, List<CustomOptions.FieldValue>> - FieldValue is a private nested struct.
            var parameters = new object[] { field, null };
            var containsField = (bool)valuesByField.GetType().GetMethod("TryGetValue").Invoke(valuesByField, parameters);
            return containsField ? ((IEnumerable)parameters[1]).Cast<object>().Select(fieldValue =>
            {
                var number = (ulong)fieldValue.GetType().GetProperty("Number", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fieldValue);
                var byteString = (ByteString)fieldValue.GetType().GetProperty("ByteString", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(fieldValue);
                return (number, byteString);
            }) : null;
        }

        public static bool TryGetRepeatedMessage<T>(this CustomOptions opts, int field, out IEnumerable<T> value) where T : class, IMessage<T>, new()
        {
            var result = GetRepeated(opts, field)?.Select(fieldValue =>
            {
                if (fieldValue.byteString == null)
                {
                    return null;
                }
                T v = new T();
                v.MergeFrom(fieldValue.byteString);
                return v;
            }).Where(x => x != null).ToList();
            value = result == null || result.Count == 0 ? null : result;
            return value != null;
        }

        public static bool TryGetRepeatedInt32(this CustomOptions opts, int field, out IEnumerable<int> value)
        {
            var result = GetRepeated(opts, field)?.Select(fieldValue => (int)fieldValue.number).ToList();
            value = result == null || result.Count == 0 ? null : result;
            return value != null;
        }

        public static bool TryGetRepeatedString(this CustomOptions opts, int field, out IEnumerable<string> value)
        {
            var result = GetRepeated(opts, field)?.Select(fieldValue => fieldValue.byteString.ToStringUtf8()).ToList();
            value = result == null || result.Count == 0 ? null : result;
            return value != null;
        }

        public static bool TryGetRepeatedEnum<T>(this CustomOptions opts, int field, out IEnumerable<T> value) where T : Enum
        {
            value = TryGetRepeatedInt32(opts, field, out var ints) ? ints.Select(x => (T)(object)x) : null;
            return value != null;
        }
    }
}
