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

using Google.Protobuf.Reflection;
using System.Linq;
using System.Reflection;

namespace Google.Api.Generator.ProtoUtils
{
    internal static class ProtoExtensions
    {
        public static string CSharpNamespace(this FileDescriptor desc)
        {
            // There is no way of reading the C# namespace without using reflection.
            // Once C# supports proto2 this will become easier.
            // Order of looking for C# namespace: "csharp_namespace" option, proto package.
            // TODO: Also look for the "metadata" proto annotation: Metadata.PackageName
            var protoProp = typeof(FileDescriptor).GetProperty("Proto", BindingFlags.Instance | BindingFlags.NonPublic);
            object fileDescriptorProto = protoProp.GetValue(desc);
            object options = fileDescriptorProto.GetType().GetProperty("Options").GetValue(fileDescriptorProto);
            string ns = options?.GetType().GetProperty("CsharpNamespace").GetValue(options) as string;
            if (!string.IsNullOrEmpty(ns))
            {
                return ns;
            }
            // As a fallback, capitalize the first character of each part of the proto package.
            return string.Join(".", desc.Package.Split('.').Select(x => char.ToUpperInvariant(x[0]) + x.Substring(1)));
        }
    }
}
