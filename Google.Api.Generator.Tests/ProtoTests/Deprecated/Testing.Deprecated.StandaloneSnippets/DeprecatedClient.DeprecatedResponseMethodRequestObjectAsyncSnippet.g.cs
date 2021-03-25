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
    using System.Threading.Tasks;
    using Testing.Deprecated;

    public sealed partial class GeneratedDeprecatedClientStandaloneSnippets
    {
        /// <summary>Snippet for DeprecatedResponseMethodAsync</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public async Task DeprecatedResponseMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedResponseMethodAsync(Request, CallSettings)
            // Additional: DeprecatedResponseMethodAsync(Request, CancellationToken)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
#pragma warning disable CS0612
            DeprecatedMessageResponse response = await deprecatedClient.DeprecatedResponseMethodAsync(request);
#pragma warning restore CS0612
            // End snippet
        }
    }
}
