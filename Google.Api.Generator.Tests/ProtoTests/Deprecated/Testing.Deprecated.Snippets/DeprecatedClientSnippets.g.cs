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
    using System;
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

        /// <summary>Snippet for DeprecatedResourcesFieldPaginatedMethod</summary>
        public void DeprecatedResourcesFieldPaginatedMethodRequestObject()
        {
            // Snippet: DeprecatedResourcesFieldPaginatedMethod(PaginatedRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { Name = "", };
            // Make the request
            PagedEnumerable<DeprecatedResourcesFieldPaginatedResponse, Response> response = deprecatedClient.DeprecatedResourcesFieldPaginatedMethod(request);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (DeprecatedResourcesFieldPaginatedResponse page in response.AsRawResponses())
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

        /// <summary>Snippet for DeprecatedResourcesFieldPaginatedMethodAsync</summary>
        public async Task DeprecatedResourcesFieldPaginatedMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedResourcesFieldPaginatedMethodAsync(PaginatedRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { Name = "", };
            // Make the request
            PagedAsyncEnumerable<DeprecatedResourcesFieldPaginatedResponse, Response> response = deprecatedClient.DeprecatedResourcesFieldPaginatedMethodAsync(request);

            // Iterate over all response items, lazily performing RPCs as required
            await foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await foreach (DeprecatedResourcesFieldPaginatedResponse page in response.AsRawResponses())
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

        /// <summary>Snippet for DeprecatedResourcesFieldPaginatedMethod</summary>
        public void DeprecatedResourcesFieldPaginatedMethod()
        {
            // Snippet: DeprecatedResourcesFieldPaginatedMethod(string, string, int?, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            string name = "";
            // Make the request
            PagedEnumerable<DeprecatedResourcesFieldPaginatedResponse, Response> response = deprecatedClient.DeprecatedResourcesFieldPaginatedMethod(name);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (DeprecatedResourcesFieldPaginatedResponse page in response.AsRawResponses())
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

        /// <summary>Snippet for DeprecatedResourcesFieldPaginatedMethodAsync</summary>
        public async Task DeprecatedResourcesFieldPaginatedMethodAsync()
        {
            // Snippet: DeprecatedResourcesFieldPaginatedMethodAsync(string, string, int?, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            string name = "";
            // Make the request
            PagedAsyncEnumerable<DeprecatedResourcesFieldPaginatedResponse, Response> response = deprecatedClient.DeprecatedResourcesFieldPaginatedMethodAsync(name);

            // Iterate over all response items, lazily performing RPCs as required
            await foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await foreach (DeprecatedResourcesFieldPaginatedResponse page in response.AsRawResponses())
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

        /// <summary>Snippet for DeprecatedPaginatedMethod</summary>
        public void DeprecatedPaginatedMethodRequestObject()
        {
            // Snippet: DeprecatedPaginatedMethod(PaginatedRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { Name = "", };
            // Make the request
#pragma warning disable CS0612
            PagedEnumerable<PaginatedResponse, Response> response = deprecatedClient.DeprecatedPaginatedMethod(request);
#pragma warning restore CS0612

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

        /// <summary>Snippet for DeprecatedPaginatedMethodAsync</summary>
        public async Task DeprecatedPaginatedMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedPaginatedMethodAsync(PaginatedRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { Name = "", };
            // Make the request
#pragma warning disable CS0612
            PagedAsyncEnumerable<PaginatedResponse, Response> response = deprecatedClient.DeprecatedPaginatedMethodAsync(request);
#pragma warning restore CS0612

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

        /// <summary>Snippet for DeprecatedResponsePaginatedMethod</summary>
        public void DeprecatedResponsePaginatedMethodRequestObject()
        {
            // Snippet: DeprecatedResponsePaginatedMethod(PaginatedRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = DeprecatedClient.Create();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { Name = "", };
            // Make the request
#pragma warning disable CS0612
            PagedEnumerable<DeprecatedPaginatedResponse, Response> response = deprecatedClient.DeprecatedResponsePaginatedMethod(request);
#pragma warning restore CS0612

            // Iterate over all response items, lazily performing RPCs as required
            foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
#pragma warning disable CS0612
            foreach (DeprecatedPaginatedResponse page in response.AsRawResponses())
#pragma warning restore CS0612
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

        /// <summary>Snippet for DeprecatedResponsePaginatedMethodAsync</summary>
        public async Task DeprecatedResponsePaginatedMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedResponsePaginatedMethodAsync(PaginatedRequest, CallSettings)
            // Create client
            DeprecatedClient deprecatedClient = await DeprecatedClient.CreateAsync();
            // Initialize request argument(s)
            PaginatedRequest request = new PaginatedRequest { Name = "", };
            // Make the request
#pragma warning disable CS0612
            PagedAsyncEnumerable<DeprecatedPaginatedResponse, Response> response = deprecatedClient.DeprecatedResponsePaginatedMethodAsync(request);
#pragma warning restore CS0612

            // Iterate over all response items, lazily performing RPCs as required
            await foreach (Response item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
#pragma warning disable CS0612
            await foreach (DeprecatedPaginatedResponse page in response.AsRawResponses())
#pragma warning restore CS0612
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
