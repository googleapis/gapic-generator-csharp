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

namespace Testing.Basic
{
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedBasicSnippets
    {
        /// <summary>Snippet for IdempotentMethod</summary>
        public void IdempotentMethod_RequestObject()
        {
            // Snippet: IdempotentMethod(Request, CallSettings)
            // Create client
            BasicClient basicClient = BasicClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = basicClient.IdempotentMethod(request);
            // End snippet
        }

        /// <summary>Snippet for IdempotentMethodAsync</summary>
        public async Task IdempotentMethodAsync_RequestObject()
        {
            // Snippet: IdempotentMethodAsync(Request, CallSettings)
            // Additional: IdempotentMethodAsync(Request, CancellationToken)
            // Create client
            BasicClient basicClient = await BasicClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = await basicClient.IdempotentMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for NonIdempotentMethod</summary>
        public void NonIdempotentMethod_RequestObject()
        {
            // Snippet: NonIdempotentMethod(Request, CallSettings)
            // Create client
            BasicClient basicClient = BasicClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = basicClient.NonIdempotentMethod(request);
            // End snippet
        }

        /// <summary>Snippet for NonIdempotentMethodAsync</summary>
        public async Task NonIdempotentMethodAsync_RequestObject()
        {
            // Snippet: NonIdempotentMethodAsync(Request, CallSettings)
            // Additional: NonIdempotentMethodAsync(Request, CancellationToken)
            // Create client
            BasicClient basicClient = await BasicClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = await basicClient.NonIdempotentMethodAsync(request);
            // End snippet
        }
    }
}
