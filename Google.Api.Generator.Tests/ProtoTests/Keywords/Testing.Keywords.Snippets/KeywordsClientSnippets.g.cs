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

namespace Testing.Keywords.Snippets
{
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class AllGeneratedKeywordsClientSnippets
    {
        /// <summary>Snippet for Method1</summary>
        public void Method1RequestObject()
        {
            // Snippet: Method1(Request, CallSettings)
            // Create client
            KeywordsClient keywordsClient = KeywordsClient.Create();
            // Initialize request argument(s)
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = 0,
                Void = Enum.Void,
                Request_ = "",
                Types_ = "",
            };
            // Make the request
            Response response = keywordsClient.Method1(request);
            // End snippet
        }

        /// <summary>Snippet for Method1Async</summary>
        public async Task Method1RequestObjectAsync()
        {
            // Snippet: Method1Async(Request, CallSettings)
            // Additional: Method1Async(Request, CancellationToken)
            // Create client
            KeywordsClient keywordsClient = await KeywordsClient.CreateAsync();
            // Initialize request argument(s)
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = 0,
                Void = Enum.Void,
                Request_ = "",
                Types_ = "",
            };
            // Make the request
            Response response = await keywordsClient.Method1Async(request);
            // End snippet
        }

        /// <summary>Snippet for Method1</summary>
        public void Method1()
        {
            // Snippet: Method1(string, int, Enum, string, string, CallSettings)
            // Create client
            KeywordsClient keywordsClient = KeywordsClient.Create();
            // Initialize request argument(s)
            string @event = "items/[ITEM_ID]";
            int @switch = 0;
            Enum @void = Enum.Void;
            string request = "";
            string types = "";
            // Make the request
            Response response = keywordsClient.Method1(@event, @switch, @void, request, types);
            // End snippet
        }

        /// <summary>Snippet for Method1Async</summary>
        public async Task Method1Async()
        {
            // Snippet: Method1Async(string, int, Enum, string, string, CallSettings)
            // Additional: Method1Async(string, int, Enum, string, string, CancellationToken)
            // Create client
            KeywordsClient keywordsClient = await KeywordsClient.CreateAsync();
            // Initialize request argument(s)
            string @event = "items/[ITEM_ID]";
            int @switch = 0;
            Enum @void = Enum.Void;
            string request = "";
            string types = "";
            // Make the request
            Response response = await keywordsClient.Method1Async(@event, @switch, @void, request, types);
            // End snippet
        }

        /// <summary>Snippet for Method1</summary>
        public void Method1ResourceNames()
        {
            // Snippet: Method1(ResourceName, int, Enum, string, string, CallSettings)
            // Create client
            KeywordsClient keywordsClient = KeywordsClient.Create();
            // Initialize request argument(s)
            ResourceName @event = ResourceName.FromItem("[ITEM_ID]");
            int @switch = 0;
            Enum @void = Enum.Void;
            string request = "";
            string types = "";
            // Make the request
            Response response = keywordsClient.Method1(@event, @switch, @void, request, types);
            // End snippet
        }

        /// <summary>Snippet for Method1Async</summary>
        public async Task Method1ResourceNamesAsync()
        {
            // Snippet: Method1Async(ResourceName, int, Enum, string, string, CallSettings)
            // Additional: Method1Async(ResourceName, int, Enum, string, string, CancellationToken)
            // Create client
            KeywordsClient keywordsClient = await KeywordsClient.CreateAsync();
            // Initialize request argument(s)
            ResourceName @event = ResourceName.FromItem("[ITEM_ID]");
            int @switch = 0;
            Enum @void = Enum.Void;
            string request = "";
            string types = "";
            // Make the request
            Response response = await keywordsClient.Method1Async(@event, @switch, @void, request, types);
            // End snippet
        }

        /// <summary>Snippet for Method2</summary>
        public void Method2RequestObject()
        {
            // Snippet: Method2(Resource, CallSettings)
            // Create client
            KeywordsClient keywordsClient = KeywordsClient.Create();
            // Initialize request argument(s)
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.Void,
            };
            // Make the request
            Response response = keywordsClient.Method2(request);
            // End snippet
        }

        /// <summary>Snippet for Method2Async</summary>
        public async Task Method2RequestObjectAsync()
        {
            // Snippet: Method2Async(Resource, CallSettings)
            // Additional: Method2Async(Resource, CancellationToken)
            // Create client
            KeywordsClient keywordsClient = await KeywordsClient.CreateAsync();
            // Initialize request argument(s)
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.Void,
            };
            // Make the request
            Response response = await keywordsClient.Method2Async(request);
            // End snippet
        }

        /// <summary>Snippet for Method2</summary>
        public void Method2()
        {
            // Snippet: Method2(string, Enum, CallSettings)
            // Create client
            KeywordsClient keywordsClient = KeywordsClient.Create();
            // Initialize request argument(s)
            string @while = "items/[ITEM_ID]";
            Enum @enum = Enum.Void;
            // Make the request
            Response response = keywordsClient.Method2(@while, @enum);
            // End snippet
        }

        /// <summary>Snippet for Method2Async</summary>
        public async Task Method2Async()
        {
            // Snippet: Method2Async(string, Enum, CallSettings)
            // Additional: Method2Async(string, Enum, CancellationToken)
            // Create client
            KeywordsClient keywordsClient = await KeywordsClient.CreateAsync();
            // Initialize request argument(s)
            string @while = "items/[ITEM_ID]";
            Enum @enum = Enum.Void;
            // Make the request
            Response response = await keywordsClient.Method2Async(@while, @enum);
            // End snippet
        }

        /// <summary>Snippet for Method2</summary>
        public void Method2ResourceNames()
        {
            // Snippet: Method2(ResourceName, Enum, CallSettings)
            // Create client
            KeywordsClient keywordsClient = KeywordsClient.Create();
            // Initialize request argument(s)
            ResourceName @while = ResourceName.FromItem("[ITEM_ID]");
            Enum @enum = Enum.Void;
            // Make the request
            Response response = keywordsClient.Method2(@while, @enum);
            // End snippet
        }

        /// <summary>Snippet for Method2Async</summary>
        public async Task Method2ResourceNamesAsync()
        {
            // Snippet: Method2Async(ResourceName, Enum, CallSettings)
            // Additional: Method2Async(ResourceName, Enum, CancellationToken)
            // Create client
            KeywordsClient keywordsClient = await KeywordsClient.CreateAsync();
            // Initialize request argument(s)
            ResourceName @while = ResourceName.FromItem("[ITEM_ID]");
            Enum @enum = Enum.Void;
            // Make the request
            Response response = await keywordsClient.Method2Async(@while, @enum);
            // End snippet
        }
    }
}
