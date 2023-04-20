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
    public sealed class AllGeneratedDeprecatedClientSnippets
    {
        /// <summary>Snippet for DeprecatedFieldMethod</summary>
        public void DeprecatedFieldMethodRequestObject()
        {
            // Snippet: DeprecatedFieldMethod(DeprecatedFieldRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            DeprecatedFieldRequest request = new DeprecatedFieldRequest { };
            // Make the request
            Response response = deprecatedClient.DeprecatedFieldMethod(request);
            // End snippet
        }

        /// <summary>Snippet for DeprecatedFieldMethodAsync</summary>
        public async Task DeprecatedFieldMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedFieldMethodAsync(DeprecatedFieldRequest, CallSettings)
            // Additional: DeprecatedFieldMethodAsync(DeprecatedFieldRequest, CancellationToken)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            DeprecatedFieldRequest request = new DeprecatedFieldRequest { };
            // Make the request
            Response response = await deprecatedClient.DeprecatedFieldMethodAsync(request);
            // End snippet
        }

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
#pragma warning disable CS0612
            Response response = deprecatedClient.DeprecatedFieldMethod(deprecatedField1, deprecatedField2);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedFieldMethodAsync</summary>
        public async Task DeprecatedFieldMethodAsync()
        {
            // Snippet: DeprecatedFieldMethodAsync(string, string, CallSettings)
            // Additional: DeprecatedFieldMethodAsync(string, string, CancellationToken)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            string deprecatedField1 = "";
            string deprecatedField2 = "";
            // Make the request
#pragma warning disable CS0612
            Response response = await deprecatedClient.DeprecatedFieldMethodAsync(deprecatedField1, deprecatedField2);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedMessageMethod</summary>
        public void DeprecatedMessageMethodRequestObject()
        {
            // Snippet: DeprecatedMessageMethod(DeprecatedMessageRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
#pragma warning disable CS0612
            DeprecatedMessageRequest request = new DeprecatedMessageRequest { };
#pragma warning restore CS0612
            // Make the request
#pragma warning disable CS0612
            Response response = deprecatedClient.DeprecatedMessageMethod(request);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedMessageMethodAsync</summary>
        public async Task DeprecatedMessageMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedMessageMethodAsync(DeprecatedMessageRequest, CallSettings)
            // Additional: DeprecatedMessageMethodAsync(DeprecatedMessageRequest, CancellationToken)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
#pragma warning disable CS0612
            DeprecatedMessageRequest request = new DeprecatedMessageRequest { };
#pragma warning restore CS0612
            // Make the request
#pragma warning disable CS0612
            Response response = await deprecatedClient.DeprecatedMessageMethodAsync(request);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedMethod</summary>
        public void DeprecatedMethodRequestObject()
        {
            // Snippet: DeprecatedMethod(Request, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
#pragma warning disable CS0612
            Response response = deprecatedClient.DeprecatedMethod(request);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedMethodAsync</summary>
        public async Task DeprecatedMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedMethodAsync(Request, CallSettings)
            // Additional: DeprecatedMethodAsync(Request, CancellationToken)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
#pragma warning disable CS0612
            Response response = await deprecatedClient.DeprecatedMethodAsync(request);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedResponseMethod</summary>
        public void DeprecatedResponseMethodRequestObject()
        {
            // Snippet: DeprecatedResponseMethod(Request, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
#pragma warning disable CS0612
            DeprecatedMessageResponse response = deprecatedClient.DeprecatedResponseMethod(request);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedResponseMethodAsync</summary>
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
