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

namespace Testing.Paginated.Snippets
{
    using Google.Api.Gax;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedPaginatedClientSnippets
    {
        /// <summary>Snippet for SignatureMethod</summary>
        public void SignatureMethod_RequestObject()
        {
            // Snippet: SignatureMethod(Request, CallSettings)
            // Create client
            PaginatedClient paginatedClient = PaginatedClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                AString = "",
                ANumber = 0,
            };
            // Make the request
            PagedEnumerable<Response, string> response = paginatedClient.SignatureMethod(request);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (string item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (Response page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for SignatureMethod</summary>
        public async Task SignatureMethodAsync_RequestObject()
        {
            // Snippet: SignatureMethodAsync(Request, CallSettings)
            // Create client
            PaginatedClient paginatedClient = await PaginatedClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request
            {
                AString = "",
                ANumber = 0,
            };
            // Make the request
            PagedAsyncEnumerable<Response, string> response = paginatedClient.SignatureMethodAsync(request);

            // Iterate over all response items, lazily performing RPCs as required
            await response.ForEachAsync((string item) =>
            {
                // Do something with each item
                Console.WriteLine(item);
            });

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await response.AsRawResponses().ForEachAsync((Response page) =>
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            });

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for SignatureMethod</summary>
        public void SignatureMethod1()
        {
            // Snippet: SignatureMethod(string, int, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = PaginatedClient.Create();
            // Initialize request argument(s)
            string aString = "";
            int aNumber = 0;
            // Make the request
            PagedEnumerable<Response, string> response = paginatedClient.SignatureMethod(aString, aNumber);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (string item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (Response page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for SignatureMethod</summary>
        public async Task SignatureMethod1Async()
        {
            // Snippet: SignatureMethodAsync(string, int, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = await PaginatedClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            int aNumber = 0;
            // Make the request
            PagedAsyncEnumerable<Response, string> response = paginatedClient.SignatureMethodAsync(aString, aNumber);

            // Iterate over all response items, lazily performing RPCs as required
            await response.ForEachAsync((string item) =>
            {
                // Do something with each item
                Console.WriteLine(item);
            });

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await response.AsRawResponses().ForEachAsync((Response page) =>
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            });

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for SignatureMethod</summary>
        public void SignatureMethod2()
        {
            // Snippet: SignatureMethod(string, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = PaginatedClient.Create();
            // Initialize request argument(s)
            string aString = "";
            // Make the request
            PagedEnumerable<Response, string> response = paginatedClient.SignatureMethod(aString: aString);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (string item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (Response page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for SignatureMethod</summary>
        public async Task SignatureMethod2Async()
        {
            // Snippet: SignatureMethodAsync(string, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = await PaginatedClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            // Make the request
            PagedAsyncEnumerable<Response, string> response = paginatedClient.SignatureMethodAsync(aString: aString);

            // Iterate over all response items, lazily performing RPCs as required
            await response.ForEachAsync((string item) =>
            {
                // Do something with each item
                Console.WriteLine(item);
            });

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await response.AsRawResponses().ForEachAsync((Response page) =>
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            });

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for SignatureMethod</summary>
        public void SignatureMethod3()
        {
            // Snippet: SignatureMethod(string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = PaginatedClient.Create();
            // Make the request
            PagedEnumerable<Response, string> response = paginatedClient.SignatureMethod();

            // Iterate over all response items, lazily performing RPCs as required
            foreach (string item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (Response page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for SignatureMethod</summary>
        public async Task SignatureMethod3Async()
        {
            // Snippet: SignatureMethodAsync(string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = await PaginatedClient.CreateAsync();
            // Make the request
            PagedAsyncEnumerable<Response, string> response = paginatedClient.SignatureMethodAsync();

            // Iterate over all response items, lazily performing RPCs as required
            await response.ForEachAsync((string item) =>
            {
                // Do something with each item
                Console.WriteLine(item);
            });

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await response.AsRawResponses().ForEachAsync((Response page) =>
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (string item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            });

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<string> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (string item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for ResourcedMethod</summary>
        public void ResourcedMethod_RequestObject()
        {
            // Snippet: ResourcedMethod(ResourceRequest, CallSettings)
            // Create client
            PaginatedClient paginatedClient = PaginatedClient.Create();
            // Initialize request argument(s)
            ResourceRequest request = new ResourceRequest
            {
                ResourceName = new ResourceName("[ITEM_ID]"),
            };
            // Make the request
            PagedEnumerable<ResourceResponse, ResourceName> response = paginatedClient.ResourcedMethod(request);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (ResourceName item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (ResourceResponse page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (ResourceName item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<ResourceName> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (ResourceName item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for ResourcedMethod</summary>
        public async Task ResourcedMethodAsync_RequestObject()
        {
            // Snippet: ResourcedMethodAsync(ResourceRequest, CallSettings)
            // Create client
            PaginatedClient paginatedClient = await PaginatedClient.CreateAsync();
            // Initialize request argument(s)
            ResourceRequest request = new ResourceRequest
            {
                ResourceName = new ResourceName("[ITEM_ID]"),
            };
            // Make the request
            PagedAsyncEnumerable<ResourceResponse, ResourceName> response = paginatedClient.ResourcedMethodAsync(request);

            // Iterate over all response items, lazily performing RPCs as required
            await response.ForEachAsync((ResourceName item) =>
            {
                // Do something with each item
                Console.WriteLine(item);
            });

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await response.AsRawResponses().ForEachAsync((ResourceResponse page) =>
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (ResourceName item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            });

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<ResourceName> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (ResourceName item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for ResourcedMethod</summary>
        public void ResourcedMethod()
        {
            // Snippet: ResourcedMethod(string, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = PaginatedClient.Create();
            // Initialize request argument(s)
            string name = "items/[ITEM_ID]";
            // Make the request
            PagedEnumerable<ResourceResponse, ResourceName> response = paginatedClient.ResourcedMethod(name);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (ResourceName item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (ResourceResponse page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (ResourceName item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<ResourceName> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (ResourceName item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for ResourcedMethod</summary>
        public async Task ResourcedMethodAsync()
        {
            // Snippet: ResourcedMethodAsync(string, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = await PaginatedClient.CreateAsync();
            // Initialize request argument(s)
            string name = "items/[ITEM_ID]";
            // Make the request
            PagedAsyncEnumerable<ResourceResponse, ResourceName> response = paginatedClient.ResourcedMethodAsync(name);

            // Iterate over all response items, lazily performing RPCs as required
            await response.ForEachAsync((ResourceName item) =>
            {
                // Do something with each item
                Console.WriteLine(item);
            });

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await response.AsRawResponses().ForEachAsync((ResourceResponse page) =>
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (ResourceName item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            });

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<ResourceName> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (ResourceName item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for ResourcedMethod</summary>
        public void ResourcedMethod_ResourceNames()
        {
            // Snippet: ResourcedMethod(ResourceName, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = PaginatedClient.Create();
            // Initialize request argument(s)
            ResourceName name = new ResourceName("[ITEM_ID]");
            // Make the request
            PagedEnumerable<ResourceResponse, ResourceName> response = paginatedClient.ResourcedMethod(name);

            // Iterate over all response items, lazily performing RPCs as required
            foreach (ResourceName item in response)
            {
                // Do something with each item
                Console.WriteLine(item);
            }

            // Or iterate over pages (of server-defined size), performing one RPC per page
            foreach (ResourceResponse page in response.AsRawResponses())
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (ResourceName item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            }

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<ResourceName> singlePage = response.ReadPage(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (ResourceName item in singlePage)
            {
                // Do something with each item
                Console.WriteLine(item);
            }
            // Store the pageToken, for when the next page is required.
            string nextPageToken = singlePage.NextPageToken;
            // End snippet
        }

        /// <summary>Snippet for ResourcedMethod</summary>
        public async Task ResourcedMethodAsync_ResourceNames()
        {
            // Snippet: ResourcedMethodAsync(ResourceName, string, int?, CallSettings)
            // Create client
            PaginatedClient paginatedClient = await PaginatedClient.CreateAsync();
            // Initialize request argument(s)
            ResourceName name = new ResourceName("[ITEM_ID]");
            // Make the request
            PagedAsyncEnumerable<ResourceResponse, ResourceName> response = paginatedClient.ResourcedMethodAsync(name);

            // Iterate over all response items, lazily performing RPCs as required
            await response.ForEachAsync((ResourceName item) =>
            {
                // Do something with each item
                Console.WriteLine(item);
            });

            // Or iterate over pages (of server-defined size), performing one RPC per page
            await response.AsRawResponses().ForEachAsync((ResourceResponse page) =>
            {
                // Do something with each page of items
                Console.WriteLine("A page of results:");
                foreach (ResourceName item in page)
                {
                    // Do something with each item
                    Console.WriteLine(item);
                }
            });

            // Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required
            int pageSize = 10;
            Page<ResourceName> singlePage = await response.ReadPageAsync(pageSize);
            // Do something with the page of items
            Console.WriteLine($"A page of {pageSize} results (unless it's the final page):");
            foreach (ResourceName item in singlePage)
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
