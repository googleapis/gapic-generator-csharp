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
    using Google.LongRunning;
    using System.Threading.Tasks;
    using ts = Testing.Snippets;

    public sealed partial class GeneratedSnippetsClientStandaloneSnippets
    {
        /// <summary>Snippet for MethodLroResourceSignatureAsync</summary>
        public async Task MethodLroResourceSignatureRequestObjectAsync()
        {
            // Snippet: MethodLroResourceSignatureAsync(ResourceSignatureRequest, CallSettings)
            // Additional: MethodLroResourceSignatureAsync(ResourceSignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = SimpleResourceName.FromItem("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = SimpleResourceName.FromItem("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = SimpleResourceName.FromItem("[ITEM_ID]"),
            };
            // Make the request
            Operation<LroResponse, LroMetadata> response = await snippetsClient.MethodLroResourceSignatureAsync(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = await snippetsClient.PollOnceMethodLroResourceSignatureAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }
    }
}
