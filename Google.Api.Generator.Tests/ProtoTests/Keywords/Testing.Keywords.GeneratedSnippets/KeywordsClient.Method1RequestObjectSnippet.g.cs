﻿// Copyright 2019 Google LLC
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

namespace Testing.Keywords.Snippets
{
    // [START unknown_generated_Keywords_Method1_sync]
    using Testing.Keywords;

    public sealed partial class GeneratedKeywordsClientSnippets
    {
        /// <summary>Snippet for Method1</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public void Method1RequestObject()
        {
            // Create client
            KeywordsClient keywordsClient = KeywordsClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = 0,
                Void = Enum.Void,
                Request_ = "",
                Types_ = "",
            };
            // Make the request
            Response response = keywordsClient.Method1(request);
        }
    }
    // [END unknown_generated_Keywords_Method1_sync]
}
