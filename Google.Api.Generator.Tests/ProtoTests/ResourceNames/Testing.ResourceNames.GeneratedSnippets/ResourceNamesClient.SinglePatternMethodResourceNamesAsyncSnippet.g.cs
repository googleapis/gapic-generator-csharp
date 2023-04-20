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
    // [START unknown_generated_ResourceNames_SinglePatternMethod_async_flattened_resourceNames]
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Testing.ResourceNames;

    public sealed partial class GeneratedResourceNamesClientSnippets
    {
        /// <summary>Snippet for SinglePatternMethodAsync</summary>
        /// <remarks>
        /// This snippet has been automatically generated and should be regarded as a code template only.
        /// It will require modifications to work:
        /// - It may require correct/in-range values for request initialization.
        /// - It may require specifying regional endpoints when creating the service client as shown in
        ///   https://cloud.google.com/dotnet/docs/reference/help/client-configuration#endpoint.
        /// </remarks>
        public async Task SinglePatternMethodResourceNamesAsync()
        {
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            SinglePatternName realName = SinglePatternName.FromItem("[ITEM_ID]");
            SinglePatternName @ref = SinglePatternName.FromItem("[ITEM_ID]");
            IEnumerable<SinglePatternName> repeatedRef = new SinglePatternName[]
            {
                SinglePatternName.FromItem("[ITEM_ID]"),
            };
            SinglePatternName valueRef = SinglePatternName.FromItem("[ITEM_ID]");
            IEnumerable<SinglePatternName> repeatedValueRef = new SinglePatternName[]
            {
                SinglePatternName.FromItem("[ITEM_ID]"),
            };
            // Make the request
            Response response = await resourceNamesClient.SinglePatternMethodAsync(realName, @ref, repeatedRef, valueRef, repeatedValueRef);
        }
    }
    // [END unknown_generated_ResourceNames_SinglePatternMethod_async_flattened_resourceNames]
}
