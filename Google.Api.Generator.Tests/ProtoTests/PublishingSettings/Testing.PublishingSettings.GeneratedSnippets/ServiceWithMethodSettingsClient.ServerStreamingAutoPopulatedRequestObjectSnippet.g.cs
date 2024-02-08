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
    // [START unknown_generated_ServiceWithMethodSettings_ServerStreamingAutoPopulated_sync]
    using Google.Api.Gax.Grpc;
    using System.Threading.Tasks;
    using Testing.PublishingSettings;

    public sealed partial class GeneratedServiceWithMethodSettingsClientSnippets
    {
        /// <summary>Snippet for ServerStreamingAutoPopulated</summary>
        /// <remarks>
        /// This snippet has been automatically generated and should be regarded as a code template only.
        /// It will require modifications to work:
        /// - It may require correct/in-range values for request initialization.
        /// - It may require specifying regional endpoints when creating the service client as shown in
        ///   https://cloud.google.com/dotnet/docs/reference/help/client-configuration#endpoint.
        /// </remarks>
        public async Task ServerStreamingAutoPopulatedRequestObject()
        {
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = ServiceWithMethodSettingsClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
            };
            // Make the request, returning a streaming response
            using ServiceWithMethodSettingsClient.ServerStreamingAutoPopulatedStream response = serviceWithMethodSettingsClient.ServerStreamingAutoPopulated(request);

            // Read streaming responses from server until complete
            // Note that C# 8 code can use await foreach
            AsyncResponseStream<Response> responseStream = response.GetResponseStream();
            while (await responseStream.MoveNextAsync())
            {
                Response responseItem = responseStream.Current;
                // Do something with streamed response
            }
            // The response stream has completed
        }
    }
    // [END unknown_generated_ServiceWithMethodSettings_ServerStreamingAutoPopulated_sync]
}
