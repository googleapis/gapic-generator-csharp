﻿// Copyright 2020 Google LLC
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
using Google.Api.Generator.Utils.Roslyn;

namespace Google.Api.Generator.Rest.Models
{
    /// <summary>
    /// Centralized place for naming rules within the REST generator.
    /// </summary>
    internal static class Naming
    {
        /// <summary>
        /// Creates a member name from the given name in the discovery doc.
        /// This is generally just the upper-camel-case version of the name,
        /// but with some tweaks.
        /// </summary>
        internal static string ToMemberName(this string name, bool addUnderscoresToEscape = true)
        {
            if (char.IsDigit(name[0]))
            {
                name = "Value" + name;
            }
            var upper = name.ToUpperCamelCase(upperAfterDigit: null);

            // We don't really need to escape keywords given that we've upper-cased it,
            // but this is what the Python code does.
            if (addUnderscoresToEscape && Keywords.IsKeyword(upper.ToLowerInvariant()))
            {
                upper += "__";
            }
            return upper;
        }

        /// <summary>
        /// Equivalent to ToClassName in csharp_generator.py
        /// </summary>
        internal static string ToClassName(this string name, PackageModel package, string containingClass)
        {
            if (Keywords.IsKeyword(name.ToLowerInvariant()))
            {
                return package.ClassName.ToUpperCamelCase() + name.ToUpperCamelCase();
            }
            // csharp_generator.py splits by dots and then joins the bits together with dots,
            // but we never need that (and it causes issues with names like "$.xgafv").
            var candidate = ToMemberName(name);
            var suffix = candidate == containingClass ? "Schema" : "";
            return candidate + suffix;
        }

        /// <summary>
        /// Creates a name suitable for a local variable or parameter, using the package name
        /// as a prefix if necessary.
        /// </summary>
        internal static string ToLocalVariableName(this string name, PackageModel package)
        {
            string lowerCamel = name.ToLowerCamelCase();
            return Keywords.IsKeyword(lowerCamel) ? package.ApiName + name.ToUpperCamelCase() : lowerCamel;
        }
    }
}
