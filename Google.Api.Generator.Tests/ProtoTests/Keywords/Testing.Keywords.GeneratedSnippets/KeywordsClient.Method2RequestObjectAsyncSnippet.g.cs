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

namespace Testing.Keywords.Snippets
{
    // [START unknown_generated_Keywords_Method2_async]
    using System.Threading.Tasks;
    using Testing.Keywords;

    public sealed partial class GeneratedKeywordsClientSnippets
    {
        /// <summary>Snippet for Method2Async</summary>
        /// <remarks>
        /// This snippet has been automatically generated and should be regarded as a code template only.
        /// It will require modifications to work:
        /// - It may require correct/in-range values for request initialization.
        /// - It may require specifying regional endpoints when creating the service client as shown in
        ///   https://cloud.google.com/dotnet/docs/reference/help/client-configuration#endpoint.
        /// </remarks>
        public async Task Method2RequestObjectAsync()
        {
            // Create client
            KeywordsClient keywordsClient = await KeywordsClient.CreateAsync();
            // Initialize request argument(s)
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.Void,
            };
            // Make the request
            Response response = await keywordsClient.Method2Async(request);
        }
    }
    // [END unknown_generated_Keywords_Method2_async]
}
