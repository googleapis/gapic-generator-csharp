namespace Testing.Basic
{
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedBasicSnippets
    {
        /// <summary>Snippet for IdempotentMethod</summary>
        public void IdempotentMethod_RequestObject()
        {
            // Snippet: IdempotentMethod(Request, CallSettings)
            // Create client
            BasicClient basicClient = BasicClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = basicClient.IdempotentMethod(request);
            // End snippet
        }

        /// <summary>Snippet for IdempotentMethodAsync</summary>
        public async Task IdempotentMethodAsync_RequestObject()
        {
            // Snippet: IdempotentMethodAsync(Request, CallSettings)
            // Additional: IdempotentMethodAsync(Request, CancellationToken)
            // Create client
            BasicClient basicClient = await BasicClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = await basicClient.IdempotentMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for NonIdempotentMethod</summary>
        public void NonIdempotentMethod_RequestObject()
        {
            // Snippet: NonIdempotentMethod(Request, CallSettings)
            // Create client
            BasicClient basicClient = BasicClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = basicClient.NonIdempotentMethod(request);
            // End snippet
        }

        /// <summary>Snippet for NonIdempotentMethodAsync</summary>
        public async Task NonIdempotentMethodAsync_RequestObject()
        {
            // Snippet: NonIdempotentMethodAsync(Request, CallSettings)
            // Additional: NonIdempotentMethodAsync(Request, CancellationToken)
            // Create client
            BasicClient basicClient = await BasicClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = await basicClient.NonIdempotentMethodAsync(request);
            // End snippet
        }
    }
}
