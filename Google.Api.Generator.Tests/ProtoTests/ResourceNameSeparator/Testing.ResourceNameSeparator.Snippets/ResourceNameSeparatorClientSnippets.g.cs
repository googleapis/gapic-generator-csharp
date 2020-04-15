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

namespace Testing.ResourceNameSeparator.Snippets
{
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedResourceNameSeparatorClientSnippets
    {
        /// <summary>Snippet for Method1</summary>
        public void Method1RequestObject()
        {
            // Snippet: Method1(Request, CallSettings)
            // Create client
            ResourceNameSeparatorClient resourceNameSeparatorClient = ResourceNameSeparatorClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            // Make the request
            Response response = resourceNameSeparatorClient.Method1(request);
            // End snippet
        }

        /// <summary>Snippet for Method1Async</summary>
        public async Task Method1RequestObjectAsync()
        {
            // Snippet: Method1Async(Request, CallSettings)
            // Additional: Method1Async(Request, CancellationToken)
            // Create client
            ResourceNameSeparatorClient resourceNameSeparatorClient = await ResourceNameSeparatorClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            // Make the request
            Response response = await resourceNameSeparatorClient.Method1Async(request);
            // End snippet
        }

        /// <summary>Snippet for Method1</summary>
        public void Method1()
        {
            // Snippet: Method1(string, string, CallSettings)
            // Create client
            ResourceNameSeparatorClient resourceNameSeparatorClient = ResourceNameSeparatorClient.Create();
            // Initialize request argument(s)
            string name = "items/[ITEM_A_ID]~[ITEM_B_ID]/details/[DETAILS_A_ID]_[DETAILS_B_ID]:[DETAILS_C_ID]/extra/[EXTRA_ID]";
            string @ref = "items/[ITEM_A_ID]~[ITEM_B_ID]/details/[DETAILS_A_ID]_[DETAILS_B_ID]:[DETAILS_C_ID]/extra/[EXTRA_ID]";
            // Make the request
            Response response = resourceNameSeparatorClient.Method1(name, @ref);
            // End snippet
        }

        /// <summary>Snippet for Method1Async</summary>
        public async Task Method1Async()
        {
            // Snippet: Method1Async(string, string, CallSettings)
            // Additional: Method1Async(string, string, CancellationToken)
            // Create client
            ResourceNameSeparatorClient resourceNameSeparatorClient = await ResourceNameSeparatorClient.CreateAsync();
            // Initialize request argument(s)
            string name = "items/[ITEM_A_ID]~[ITEM_B_ID]/details/[DETAILS_A_ID]_[DETAILS_B_ID]:[DETAILS_C_ID]/extra/[EXTRA_ID]";
            string @ref = "items/[ITEM_A_ID]~[ITEM_B_ID]/details/[DETAILS_A_ID]_[DETAILS_B_ID]:[DETAILS_C_ID]/extra/[EXTRA_ID]";
            // Make the request
            Response response = await resourceNameSeparatorClient.Method1Async(name, @ref);
            // End snippet
        }

        /// <summary>Snippet for Method1</summary>
        public void Method1ResourceNames()
        {
            // Snippet: Method1(RequestName, RequestName, CallSettings)
            // Create client
            ResourceNameSeparatorClient resourceNameSeparatorClient = ResourceNameSeparatorClient.Create();
            // Initialize request argument(s)
            RequestName name = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]");
            RequestName @ref = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]");
            // Make the request
            Response response = resourceNameSeparatorClient.Method1(name, @ref);
            // End snippet
        }

        /// <summary>Snippet for Method1Async</summary>
        public async Task Method1ResourceNamesAsync()
        {
            // Snippet: Method1Async(RequestName, RequestName, CallSettings)
            // Additional: Method1Async(RequestName, RequestName, CancellationToken)
            // Create client
            ResourceNameSeparatorClient resourceNameSeparatorClient = await ResourceNameSeparatorClient.CreateAsync();
            // Initialize request argument(s)
            RequestName name = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]");
            RequestName @ref = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]");
            // Make the request
            Response response = await resourceNameSeparatorClient.Method1Async(name, @ref);
            // End snippet
        }
    }
}
