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

namespace Testing.ResourceNames.Snippets
{
    // [START unknown_generated_ResourceNames_WildcardMultiPatternMultipleMethod_sync_flattened_resourceNames3]
    using Google.Api.Gax;
    using System.Collections.Generic;
    using Testing.ResourceNames;

    public sealed partial class GeneratedResourceNamesClientSnippets
    {
        /// <summary>Snippet for WildcardMultiPatternMultipleMethod</summary>
        /// <remarks>
        /// This snippet has been automatically generated and should be regarded as a code template only.
        /// It will require modifications to work:
        /// - It may require correct/in-range values for request initialization.
        /// - It may require specifying regional endpoints when creating the service client as shown in
        ///   https://cloud.google.com/dotnet/docs/reference/help/client-configuration#endpoint.
        /// </remarks>
        public void WildcardMultiPatternMultipleMethodResourceNames3()
        {
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<WildcardMultiPatternMultipleName> repeatedRef = new WildcardMultiPatternMultipleName[]
            {
                WildcardMultiPatternMultipleName.FromConstPattern(),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMultipleMethod(@ref, repeatedRef);
        }
    }
    // [END unknown_generated_ResourceNames_WildcardMultiPatternMultipleMethod_sync_flattened_resourceNames3]
}
