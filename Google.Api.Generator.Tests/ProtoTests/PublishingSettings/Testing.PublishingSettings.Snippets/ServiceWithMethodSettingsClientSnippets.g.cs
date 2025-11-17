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
    using Google.Api.Gax;
    using Google.Api.Gax.Grpc;
    using Google.LongRunning;
    using System;
    using System.Threading.Tasks;
    using Testing.PublishingSettings;

    /// <summary>Generated snippets.</summary>
    public sealed class AllGeneratedServiceWithMethodSettingsClientSnippets
    {
        /// <summary>Snippet for UnaryAutoPopulated</summary>
        public void UnaryAutoPopulatedRequestObject()
        {
            // Snippet: UnaryAutoPopulated(Request, CallSettings)
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = ServiceWithMethodSettingsClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
            };
            // Make the request
            Response response = serviceWithMethodSettingsClient.UnaryAutoPopulated(request);
            // End snippet
        }

        /// <summary>Snippet for UnaryAutoPopulatedAsync</summary>
        public async Task UnaryAutoPopulatedRequestObjectAsync()
        {
            // Snippet: UnaryAutoPopulatedAsync(Request, CallSettings)
            // Additional: UnaryAutoPopulatedAsync(Request, CancellationToken)
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = await ServiceWithMethodSettingsClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
            };
            // Make the request
            Response response = await serviceWithMethodSettingsClient.UnaryAutoPopulatedAsync(request);
            // End snippet
        }

        /// <summary>Snippet for ServerStreamingAutoPopulated</summary>
        public async Task ServerStreamingAutoPopulatedRequestObject()
        {
            // Snippet: ServerStreamingAutoPopulated(Request, CallSettings)
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
            // End snippet
        }

        /// <summary>Snippet for BidiStreamingAutoPopulated</summary>
        public async Task BidiStreamingAutoPopulated()
        {
            // Snippet: BidiStreamingAutoPopulated(CallSettings, BidirectionalStreamingSettings)
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = ServiceWithMethodSettingsClient.Create();
            // Initialize streaming call, retrieving the stream object
            using ServiceWithMethodSettingsClient.BidiStreamingAutoPopulatedStream response = serviceWithMethodSettingsClient.BidiStreamingAutoPopulated();

            // Sending requests and retrieving responses can be arbitrarily interleaved
            // Exact sequence will depend on client/server behavior

            // Create task to do something with responses from server
            Task responseHandlerTask = Task.Run(async () =>
            {
                // Note that C# 8 code can use await foreach
                AsyncResponseStream<Response> responseStream = response.GetResponseStream();
                while (await responseStream.MoveNextAsync())
                {
                    Response responseItem = responseStream.Current;
                    // Do something with streamed response
                }
                // The response stream has completed
            });

            // Send requests to the server
            bool done = false;
            while (!done)
            {
                // Initialize a request
                Request request = new Request
                {
                    String1 = "",
                    String2 = "",
                };
                // Stream a request to the server
                await response.WriteAsync(request);
                // Set "done" to true when sending requests is complete
            }

            // Complete writing requests to the stream
            await response.WriteCompleteAsync();
            // Await the response handler
            // This will complete once all server responses have been processed
            await responseHandlerTask;
            // End snippet
        }

        /// <summary>Snippet for LroAutoPopulated</summary>
        public void LroAutoPopulatedRequestObject()
        {
            // Snippet: LroAutoPopulated(Request, CallSettings)
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = ServiceWithMethodSettingsClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
            };
            // Make the request
            Operation<Response, Response> response = serviceWithMethodSettingsClient.LroAutoPopulated(request);

            // Poll until the returned long-running operation is complete
            Operation<Response, Response> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            Response result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<Response, Response> retrievedResponse = serviceWithMethodSettingsClient.PollOnceLroAutoPopulated(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                Response retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for LroAutoPopulatedAsync</summary>
        public async Task LroAutoPopulatedRequestObjectAsync()
        {
            // Snippet: LroAutoPopulatedAsync(Request, CallSettings)
            // Additional: LroAutoPopulatedAsync(Request, CancellationToken)
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = await ServiceWithMethodSettingsClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
            };
            // Make the request
            Operation<Response, Response> response = await serviceWithMethodSettingsClient.LroAutoPopulatedAsync(request);

            // Poll until the returned long-running operation is complete
            Operation<Response, Response> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            Response result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<Response, Response> retrievedResponse = await serviceWithMethodSettingsClient.PollOnceLroAutoPopulatedAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                Response retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for PaginatedAutoPopulated</summary>
        public void PaginatedAutoPopulatedRequestObject()
        {
            // Snippet: PaginatedAutoPopulated(PaginatedRequest, CallSettings)
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = ServiceWithMethodSettingsClient.Create();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { };
            // Make the request
            PagedEnumerable<PaginatedResponse, Response> response = serviceWithMethodSettingsClient.PaginatedAutoPopulated(request);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (PaginatedResponse page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (Response item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<Response> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (Response item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for PaginatedAutoPopulatedAsync</summary>
        public async Task PaginatedAutoPopulatedRequestObjectAsync()
        {
            // Snippet: PaginatedAutoPopulatedAsync(PaginatedRequest, CallSettings)
            // Create client
            ServiceWithMethodSettingsClient serviceWithMethodSettingsClient = await ServiceWithMethodSettingsClient.CreateAsync();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { };
            // Make the request
            PagedAsyncEnumerable<PaginatedResponse, Response> response = serviceWithMethodSettingsClient.PaginatedAutoPopulatedAsync(request);

            // Iterate over all response items, lazily performing RPCs as required
            await foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await foreach (PaginatedResponse page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (Response item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<Response> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (Response item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }
    }
}
