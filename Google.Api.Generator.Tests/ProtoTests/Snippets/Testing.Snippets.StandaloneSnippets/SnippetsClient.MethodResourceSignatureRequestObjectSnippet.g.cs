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
    public sealed partial class GeneratedSnippetsClientStandaloneSnippets
    {
        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignatureRequestObject()
        {
            // Snippet: MethodResourceSignature(ResourceSignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = SimpleResourceName.FromItem("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = SimpleResourceName.FromItem("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = SimpleResourceName.FromItem("[ITEM_ID]"),
            };
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(request);
            // End snippet
        }
    }
}
