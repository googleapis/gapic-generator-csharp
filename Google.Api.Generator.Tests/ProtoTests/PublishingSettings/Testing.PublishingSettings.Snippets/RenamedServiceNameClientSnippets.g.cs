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

namespace GoogleCSharpSnippets
{
    using System.Threading.Tasks;
    using Testing.PublishingSettings;

    /// <summary>Generated snippets.</summary>
    public sealed class AllGeneratedRenamedServiceNameClientSnippets
    {
        /// <summary>Snippet for AMethod</summary>
        public void AMethodRequestObject()
        {
            // Snippet: AMethod(Request, CallSettings)
            // Create client
            RenamedServiceNameClient renamedServiceNameClient = RenamedServiceNameClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
                RequestId = "",
                RequestIdWithPresence = "",
            };
            // Make the request
            Response response = renamedServiceNameClient.AMethod(request);
            // End snippet
        }

        /// <summary>Snippet for AMethodAsync</summary>
        public async Task AMethodRequestObjectAsync()
        {
            // Snippet: AMethodAsync(Request, CallSettings)
            // Additional: AMethodAsync(Request, CancellationToken)
            // Create client
            RenamedServiceNameClient renamedServiceNameClient = await RenamedServiceNameClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
                RequestId = "",
                RequestIdWithPresence = "",
            };
            // Make the request
            Response response = await renamedServiceNameClient.AMethodAsync(request);
            // End snippet
        }
    }
}
