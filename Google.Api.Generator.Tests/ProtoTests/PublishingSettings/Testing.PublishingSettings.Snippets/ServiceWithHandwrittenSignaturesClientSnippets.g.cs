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
    using System.Threading.Tasks;
    using Testing.PublishingSettings;

    /// <summary>Generated snippets.</summary>
    public sealed class AllGeneratedServiceWithHandwrittenSignaturesClientSnippets
    {
        /// <summary>Snippet for AMethod</summary>
        public void AMethodRequestObject()
        {
            // Snippet: AMethod(Request, CallSettings)
            // Create client
            ServiceWithHandwrittenSignaturesClient serviceWithHandwrittenSignaturesClient = ServiceWithHandwrittenSignaturesClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
                RequestId = "",
            };
            // Make the request
            Response response = serviceWithHandwrittenSignaturesClient.AMethod(request);
            // End snippet
        }

        /// <summary>Snippet for AMethodAsync</summary>
        public async Task AMethodRequestObjectAsync()
        {
            // Snippet: AMethodAsync(Request, CallSettings)
            // Additional: AMethodAsync(Request, CancellationToken)
            // Create client
            ServiceWithHandwrittenSignaturesClient serviceWithHandwrittenSignaturesClient = await ServiceWithHandwrittenSignaturesClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request
            {
                String1 = "",
                String2 = "",
                RequestId = "",
            };
            // Make the request
            Response response = await serviceWithHandwrittenSignaturesClient.AMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AMethod</summary>
        public void AMethod1()
        {
            // Snippet: AMethod(string, CallSettings)
            // Create client
            ServiceWithHandwrittenSignaturesClient serviceWithHandwrittenSignaturesClient = ServiceWithHandwrittenSignaturesClient.Create();
            // Initialize request argument(s)
            string string1 = "";
            // Make the request
            Response response = serviceWithHandwrittenSignaturesClient.AMethod(string1);
            // End snippet
        }

        /// <summary>Snippet for AMethodAsync</summary>
        public async Task AMethod1Async()
        {
            // Snippet: AMethodAsync(string, CallSettings)
            // Additional: AMethodAsync(string, CancellationToken)
            // Create client
            ServiceWithHandwrittenSignaturesClient serviceWithHandwrittenSignaturesClient = await ServiceWithHandwrittenSignaturesClient.CreateAsync();
            // Initialize request argument(s)
            string string1 = "";
            // Make the request
            Response response = await serviceWithHandwrittenSignaturesClient.AMethodAsync(string1);
            // End snippet
        }

        /// <summary>Snippet for AMethod</summary>
        public void AMethod2()
        {
            // Snippet: AMethod(string, string, CallSettings)
            // Create client
            ServiceWithHandwrittenSignaturesClient serviceWithHandwrittenSignaturesClient = ServiceWithHandwrittenSignaturesClient.Create();
            // Initialize request argument(s)
            string string1 = "";
            string string2 = "";
            // Make the request
            Response response = serviceWithHandwrittenSignaturesClient.AMethod(string1, string2);
            // End snippet
        }

        /// <summary>Snippet for AMethodAsync</summary>
        public async Task AMethod2Async()
        {
            // Snippet: AMethodAsync(string, string, CallSettings)
            // Additional: AMethodAsync(string, string, CancellationToken)
            // Create client
            ServiceWithHandwrittenSignaturesClient serviceWithHandwrittenSignaturesClient = await ServiceWithHandwrittenSignaturesClient.CreateAsync();
            // Initialize request argument(s)
            string string1 = "";
            string string2 = "";
            // Make the request
            Response response = await serviceWithHandwrittenSignaturesClient.AMethodAsync(string1, string2);
            // End snippet
        }
    }
}
