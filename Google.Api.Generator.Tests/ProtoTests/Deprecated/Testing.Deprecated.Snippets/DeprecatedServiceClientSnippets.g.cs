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
    using Testing.Deprecated;

    /// <summary>Generated snippets.</summary>
    public sealed class AllGeneratedDeprecatedServiceClientSnippets
    {
        /// <summary>Snippet for NonDeprecatedMethod</summary>
        public void NonDeprecatedMethodRequestObject()
        {
            // Snippet: NonDeprecatedMethod(Request, CallSettings)
            // Create client
            DeprecatedServiceClient deprecatedServiceClient = DeprecatedServiceClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = deprecatedServiceClient.NonDeprecatedMethod(request);
            // End snippet
        }

        /// <summary>Snippet for NonDeprecatedMethodAsync</summary>
        public async Task NonDeprecatedMethodRequestObjectAsync()
        {
            // Snippet: NonDeprecatedMethodAsync(Request, CallSettings)
            // Additional: NonDeprecatedMethodAsync(Request, CancellationToken)
            // Create client
            DeprecatedServiceClient deprecatedServiceClient = await DeprecatedServiceClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = await deprecatedServiceClient.NonDeprecatedMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for DeprecatedMethod</summary>
        public void DeprecatedMethodRequestObject()
        {
            // Snippet: DeprecatedMethod(Request, CallSettings)
            // Create client
            DeprecatedServiceClient deprecatedServiceClient = DeprecatedServiceClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
#pragma warning disable CS0612
            Response response = deprecatedServiceClient.DeprecatedMethod(request);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedMethodAsync</summary>
        public async Task DeprecatedMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedMethodAsync(Request, CallSettings)
            // Additional: DeprecatedMethodAsync(Request, CancellationToken)
            // Create client
            DeprecatedServiceClient deprecatedServiceClient = await DeprecatedServiceClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
#pragma warning disable CS0612
            Response response = await deprecatedServiceClient.DeprecatedMethodAsync(request);
#pragma warning restore CS0612
            // End snippet
        }
    }
}
