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

namespace Testing.BasicLro.Snippets
{
    using Google.LongRunning;

    public sealed partial class GeneratedBasicLroClientStandaloneSnippets
    {
        /// <summary>Snippet for Method1</summary>
        public void Method1RequestObject()
        {
            // Snippet: Method1(Request, CallSettings)
            // Create client
            BasicLroClient basicLroClient = BasicLroClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Operation<LroResponse, LroMetadata> response = basicLroClient.Method1(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = basicLroClient.PollOnceMethod1(operationName);
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
