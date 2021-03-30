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

namespace Testing.Snippets.Snippets
{
    using System.Threading.Tasks;
    using ts = Testing.Snippets;

    public sealed partial class GeneratedSnippetsClientStandaloneSnippets
    {
        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public async Task MethodThreeSignaturesRequestObjectAsync()
        {
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(request);
        }
    }
}
