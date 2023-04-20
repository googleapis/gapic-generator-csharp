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

#pragma warning disable CS8981

namespace GoogleCSharpSnippets
{
    // [START snippets_generated_Snippets_MethodLroSignatures_async]
    using Google.LongRunning;
    using System.Threading.Tasks;
    using ts = Testing.Snippets;

    public sealed partial class GeneratedSnippetsClientSnippets
    {
        /// <summary>Snippet for MethodLroSignaturesAsync</summary>
        /// <remarks>
        /// This snippet has been automatically generated and should be regarded as a code template only.
        /// It will require modifications to work:
        /// - It may require correct/in-range values for request initialization.
        /// - It may require specifying regional endpoints when creating the service client as shown in
        ///   https://cloud.google.com/dotnet/docs/reference/help/client-configuration#endpoint.
        /// </remarks>
        public async Task MethodLroSignaturesRequestObjectAsync()
        {
            // Create client
            ts::SnippetsClient snippetsClient = await ts::SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            ts::SignatureRequest request = new ts::SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Operation<ts::LroResponse, ts::LroMetadata> response = await snippetsClient.MethodLroSignaturesAsync(request);

            // Poll until the returned long-running operation is complete
            Operation<ts::LroResponse, ts::LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            ts::LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<ts::LroResponse, ts::LroMetadata> retrievedResponse = await snippetsClient.PollOnceMethodLroSignaturesAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                ts::LroResponse retrievedResult = retrievedResponse.Result;
            }
        }
    }
    // [END snippets_generated_Snippets_MethodLroSignatures_async]
}
