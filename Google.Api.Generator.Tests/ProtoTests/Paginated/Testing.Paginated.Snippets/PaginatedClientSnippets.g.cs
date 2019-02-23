namespace Testing.Paginated
{
    using Google.Api.Gax;
    using System;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedPaginatedSnippets
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
        public void SignatureMethod()
        {
            // Snippet: SignatureMethod(String, Int32, CallSettings)
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
        public void ResourcedMethod()
        {
            // Snippet: ResourcedMethod(String, CallSettings)
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
    }
}
