// Copyright 2019 Google LLC
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

// Generated code. DO NOT EDIT!

namespace Testing.Deprecated.Snippets
{
    using Testing.Deprecated;

    public sealed partial class GeneratedDeprecatedClientStandaloneSnippets
    {
        /// <summary>Snippet for DeprecatedFieldMethod</summary>
        public void DeprecatedFieldMethod()
        {
            // Snippet: DeprecatedFieldMethod(string, string, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            string deprecatedField1 = "";
            string deprecatedField2 = "";
            // Make the request
            Response response = deprecatedClient.DeprecatedFieldMethod(deprecatedField1, deprecatedField2);
            // End snippet
        }
    }
}
