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

namespace 
{
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedSvcSnippets
    {
        /// <summary>Snippet for M</summary>
        public void M_RequestObject()
        {
            // Snippet: M(Request, CallSettings)
            // Create client
            SvcClient svcClient = SvcClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = svcClient.M(request);
            // End snippet
        }

        /// <summary>Snippet for MAsync</summary>
        public async Task MAsync_RequestObject()
        {
            // Snippet: MAsync(Request, CallSettings)
            // Additional: MAsync(Request, CancellationToken)
            // Create client
            SvcClient svcClient = await SvcClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = await svcClient.MAsync(request);
            // End snippet
        }
    }
}
