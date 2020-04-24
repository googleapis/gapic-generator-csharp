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
using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Google.Api.Generator.ProtoUtils
{
    internal static class ProtoExtensions
    {
        /// <summary>
        /// Extension registry with everything we need in. See <see cref="ReparseWithExtensions{T}(T)"/> for usage.
        /// </summary>
        private static readonly ExtensionRegistry s_registry = new ExtensionRegistry
        {
            ClientExtensions.DefaultHost,
            ClientExtensions.MethodSignature,
            ClientExtensions.OauthScopes,
            OperationsExtensions.OperationInfo,
            FieldBehaviorExtensions.FieldBehavior,
            AnnotationsExtensions.Http,
            ResourceExtensions.Resource,
            ResourceExtensions.ResourceDefinition,
            ResourceExtensions.ResourceReference
        };

        private static object GetRawOptions(IDescriptor desc)
        {
            object descProto = desc.GetType().GetProperty("Proto", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(desc);
            object options = descProto.GetType().GetProperty("Options").GetValue(descProto);
            return options;
        }

        public static string CSharpNamespace(this FileDescriptor desc)
        {
            // Order of looking for C# namespace: "csharp_namespace" option, proto package.
            // TODO: Also look for the "metadata" proto annotation: Metadata.PackageName
            string ns = GetOptions(desc)?.CsharpNamespace;
            if (!string.IsNullOrEmpty(ns))
            {
                return ns;
            }
            // As a fallback, capitalize the first character of each part of the proto package.
            return string.Join(".", desc.Package.Split('.').Select(x => x.ToUpperCamelCase()));
        }

        public static bool IsDeprecated(this MessageDescriptor desc) => GetOptions(desc)?.Deprecated ?? false;

        public static bool IsDeprecated(this MethodDescriptor desc) => GetOptions(desc)?.Deprecated ?? false;

        public static bool IsDeprecated(this FieldDescriptor desc) => GetOptions(desc)?.Deprecated ?? false;

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

        // *Descriptor.GetOption equivalents, with three differences:
        // - Google.Protobuf code throws an NRE if you try to fetch an option and there are no options in the descriptor.
        // - Google.Protobuf code throws an NRE if you try to fetch a repeated option and it doesn't exist in the descriptor.
        // - After obtaining options, we reparse the options with our extension registry - because we can't that when we create the
        //   original FileDescriptors. (FileDescriptor.BuildFromByteStrings doesn't accept an extension registry.)
        //
        // Hopefully this could all go away if Google.Protobuf is fixed.
        internal static T SafeGetOption<T>(this FileDescriptor descriptor, Extension<FileOptions, T> extension)
        {
            var options = GetOptions(descriptor);
            return options is object ? options.GetExtension(extension) : default;
        }

        internal static RepeatedField<T> SafeGetOption<T>(this FileDescriptor descriptor, RepeatedExtension<FileOptions, T> extension) =>
            GetOptions(descriptor)?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T SafeGetOption<T>(this MessageDescriptor descriptor, Extension<MessageOptions, T> extension)
        {
            var options = GetOptions(descriptor);
            return options is object ? options.GetExtension(extension) : default;
        }

        internal static RepeatedField<T> SafeGetOption<T>(this MessageDescriptor descriptor, RepeatedExtension<MessageOptions, T> extension) =>
            GetOptions(descriptor)?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T SafeGetOption<T>(this FieldDescriptor descriptor, Extension<FieldOptions, T> extension)
        {
            var options = GetOptions(descriptor);
            return options is object ? options.GetExtension(extension) : default;
        }

        internal static RepeatedField<T> SafeGetOption<T>(this FieldDescriptor descriptor, RepeatedExtension<FieldOptions, T> extension) =>
            GetOptions(descriptor)?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T SafeGetOption<T>(this ServiceDescriptor descriptor, Extension<ServiceOptions, T> extension)
        {
            var options = GetOptions(descriptor);
            return options is object ? options.GetExtension(extension) : default;
        }

        internal static RepeatedField<T> SafeGetOption<T>(this ServiceDescriptor descriptor, RepeatedExtension<ServiceOptions, T> extension) =>
            GetOptions(descriptor)?.GetExtension(extension) ?? new RepeatedField<T>();

        internal static T SafeGetOption<T>(this MethodDescriptor descriptor, Extension<MethodOptions, T> extension)
        {
            var options = GetOptions(descriptor);
            return options is object ? options.GetExtension(extension) : default;
        }

        internal static RepeatedField<T> SafeGetOption<T>(this MethodDescriptor descriptor, RepeatedExtension<MethodOptions, T> extension) =>
            GetOptions(descriptor)?.GetExtension(extension) ?? new RepeatedField<T>();

        private static FileOptions GetOptions(FileDescriptor descriptor) => ((FileOptions) GetRawOptions(descriptor)).ReparseWithExtensions();
        private static MessageOptions GetOptions(MessageDescriptor descriptor) => ((MessageOptions) GetRawOptions(descriptor)).ReparseWithExtensions();
        private static ServiceOptions GetOptions(ServiceDescriptor descriptor) => ((ServiceOptions) GetRawOptions(descriptor)).ReparseWithExtensions();
        private static MethodOptions GetOptions(MethodDescriptor descriptor) => ((MethodOptions) GetRawOptions(descriptor)).ReparseWithExtensions();
        private static FieldOptions GetOptions(FieldDescriptor descriptor) => ((FieldOptions) GetRawOptions(descriptor)).ReparseWithExtensions();

        private static T ReparseWithExtensions<T>(this T input) where T : class, IMessage<T> =>
            (T) input?.Descriptor.Parser.WithExtensionRegistry(s_registry).ParseFrom(input.ToByteArray());
    }
}
