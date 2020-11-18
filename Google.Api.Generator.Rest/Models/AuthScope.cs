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

namespace Google.Api.Generator.Rest.Models
{
    public class AuthScope
    {
        private const string GooglePrefix = "https://www.googleapis.com/auth/";
        private const string HttpsPrefix = "https://";

        /// <summary>
        /// The name of the field to generate, based on a trimmed and Pascal-cased
        /// version of <see cref="Value"/>.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// The value of the scope, as defined by the key within the Discovery doc.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// The description of the scope, as defined in the Discovery doc.
        /// </summary>
        public string Description { get; }

        public AuthScope(string value, string description)
        {
            Value = value;
            Description = description;
            value = value.TrimEnd('/');
            if (value.StartsWith(GooglePrefix))
            {
                value = value[GooglePrefix.Length..];
            }
            else if (value.StartsWith(HttpsPrefix))
            {
                value = value[HttpsPrefix.Length..];
            }
            FieldName = value.ToMemberName();
        }
    }
}
