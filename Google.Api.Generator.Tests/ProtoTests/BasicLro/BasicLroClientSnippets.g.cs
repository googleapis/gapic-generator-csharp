using Google.LongRunning;
using System.Threading.Tasks;

namespace Testing.Basiclro
{
    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedBasicLroSnippets
    {
        /// <summary>Snippet for Method1</summary>
        public void Method1_RequestObject()
        {
            // Snippet: Method1(Request, CallSettings)
            // Create client
            BasicLroClient basicLroClient = BasicLroClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Operation<LroResponse, LroMetadata> response = basicLroClient.Method1(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = basicLroClient.PollOnceMethod1(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for Method1Async</summary>
        public async Task Method1Async_RequestObject()
        {
            // Snippet: Method1Async(Request, CallSettings)
            // Additional: Method1Async(Request, CancellationToken)
            // Create client
            BasicLroClient basicLroClient = await BasicLroClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Operation<LroResponse, LroMetadata> response = await basicLroClient.Method1Async(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = await basicLroClient.PollOnceMethod1Async(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }
    }
}
