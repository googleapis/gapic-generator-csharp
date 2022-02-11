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
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.ProtoUtils
{
    internal static class ProtoExtensions
    {
        public static string CSharpNamespace(this FileDescriptor desc)
        {
            // Order of looking for C# namespace: "csharp_namespace" option, proto package.
            // TODO: Also look for the "metadata" proto annotation: Metadata.PackageName
            string ns = desc?.GetOptions()?.CsharpNamespace;
            if (!string.IsNullOrEmpty(ns))
            {
                return ns;
            }
            // As a fallback, capitalize the first character of each part of the proto package.
            return string.Join(".", desc.Package.Split('.').Select(x => x.ToUpperCamelCase()));
        }

        public static bool IsDeprecated(this MessageDescriptor desc) => desc?.GetOptions()?.Deprecated ?? false;

        public static bool IsDeprecated(this MethodDescriptor desc) => desc?.GetOptions()?.Deprecated ?? false;

        public static bool IsDeprecated(this FieldDescriptor desc) =>
            (desc?.GetOptions()?.Deprecated ?? false) || IsDeprecated(desc?.ContainingType);

        public static IEnumerable<string> DocLines(this DescriptorDeclaration decl) =>
            decl?.LeadingComments.Split('\n').Select(x => x.Trim())
                .SkipWhile(string.IsNullOrWhiteSpace).Reverse().SkipWhile(string.IsNullOrWhiteSpace).Reverse() ??
                    Enumerable.Empty<string>();

        public static string CSharpPropertyName(this FieldDescriptor field)
        {
            var result = field.Name.ToUpperCamelCase();
            // Note: Types is reserved in C# because any nested types are nested within an already-nested Types class.
            return field.ContainingType.Name == result || result == "Types" ? $"{result}_"
                : result; // Matches protoc naming
        }

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

        // Convenience methods for accessing extensions, where repeated extensions
        // return an empty repeated field instead of null if they're absent.
        internal static T GetExtension<T>(this FileDescriptor descriptor, Extension<FileOptions, T> extension) =>
            descriptor.GetOptions() is FileOptions options ? options.GetExtension(extension) : default;

        internal static RepeatedField<T> GetExtension<T>(this FileDescriptor descriptor, RepeatedExtension<FileOptions, T> extension) =>
            descriptor.GetOptions()?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T GetExtension<T>(this MessageDescriptor descriptor, Extension<MessageOptions, T> extension) =>
            descriptor.GetOptions() is MessageOptions options ? options.GetExtension(extension) : default;

        internal static RepeatedField<T> GetExtension<T>(this MessageDescriptor descriptor, RepeatedExtension<MessageOptions, T> extension) =>
            descriptor.GetOptions()?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T GetExtension<T>(this FieldDescriptor descriptor, Extension<FieldOptions, T> extension) =>
            descriptor.GetOptions() is FieldOptions options ? options.GetExtension(extension) : default;

        internal static RepeatedField<T> GetExtension<T>(this FieldDescriptor descriptor, RepeatedExtension<FieldOptions, T> extension) =>
            descriptor.GetOptions()?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T GetExtension<T>(this ServiceDescriptor descriptor, Extension<ServiceOptions, T> extension) =>
            descriptor.GetOptions() is ServiceOptions options ? options.GetExtension(extension) : default;

        internal static RepeatedField<T> GetExtension<T>(this ServiceDescriptor descriptor, RepeatedExtension<ServiceOptions, T> extension) =>
            descriptor.GetOptions()?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T GetExtension<T>(this MethodDescriptor descriptor, Extension<MethodOptions, T> extension) =>
            descriptor.GetOptions() is MethodOptions options ? options.GetExtension(extension) : default;

        internal static RepeatedField<T> GetExtension<T>(this MethodDescriptor descriptor, RepeatedExtension<MethodOptions, T> extension) =>
            descriptor.GetOptions()?.GetExtension(extension) ?? new RepeatedField<T>();
    }
}
