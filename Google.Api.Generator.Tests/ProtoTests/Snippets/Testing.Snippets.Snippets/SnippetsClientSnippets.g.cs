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

namespace Testing.Snippets.Snippets
{
    using Google.Api.Gax;
    using Google.LongRunning;
    using Google.Protobuf;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ts = Testing.Snippets;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedSnippetsClientSnippets
    {
        /// <summary>Snippet for MethodDefaultValues</summary>
        public void MethodDefaultValues_RequestObject()
        {
            // Snippet: MethodDefaultValues(DefaultValuesRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            DefaultValuesRequest request = new DefaultValuesRequest
            {
                SingleDouble = 0,
                SingleFloat = 0F,
                SingleInt32 = 0,
                SingleInt64 = 0L,
                SingleUint32 = 0U,
                SingleUint64 = 0UL,
                SingleSint32 = 0,
                SingleSint64 = 0L,
                SingleFixed32 = 0U,
                SingleFixed64 = 0UL,
                SingleSfixed32 = 0,
                SingleSfixed64 = 0L,
                SingleBool = false,
                SingleString = "",
                SingleBytes = ByteString.Empty,
                SingleMessage = new AnotherMessage(),
                SingleNestedMessage = new DefaultValuesRequest.Types.NestedMessage(),
                SingleEnum = Enum.Default,
                SingleNestedEnum = DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                RepeatedDouble = { 0, },
                RepeatedFloat = { 0F, },
                RepeatedInt32 = { 0, },
                RepeatedInt64 = { 0L, },
                RepeatedUint32 = { 0U, },
                RepeatedUint64 = { 0UL, },
                RepeatedSint32 = { 0, },
                RepeatedSint64 = { 0L, },
                RepeatedFixed32 = { 0U, },
                RepeatedFixed64 = { 0UL, },
                RepeatedSfixed32 = { 0, },
                RepeatedSfixed64 = { 0L, },
                RepeatedBool = { false, },
                RepeatedString = { "", },
                RepeatedBytes = { ByteString.Empty, },
                RepeatedMessage =
                {
                    new AnotherMessage(),
                },
                RepeatedNestedMessage =
                {
                    new DefaultValuesRequest.Types.NestedMessage(),
                },
                RepeatedEnum = { Enum.Default, },
                RepeatedNestedEnum =
                {
                    DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                },
                SingleResourceNameAsAResourceName = new AResourceName("[ITEM_ID]", "[PART_ID]"),
                RepeatedResourceNameAsAResourceNames =
                {
                    new AResourceName("[ITEM_ID]", "[PART_ID]"),
                },
                SingleWildcardResourceAsResourceName = new UnknownResourceName("a/wildcard/resource"),
                RepeatedWildcardResourceAsResourceNames =
                {
                    new UnknownResourceName("a/wildcard/resource"),
                },
                MultiPatternResourceNameAsMultiPatternResourceNameOneOf = MultiPatternResourceNameOneOf.From(new RootAItemName("[ROOT_A_ID]", "[ITEM_ID]")),
                RepeatedMultiPatternResourceNameAsMultiPatternResourceNameOneOfs =
                {
                    MultiPatternResourceNameOneOf.From(new RootAItemName("[ROOT_A_ID]", "[ITEM_ID]")),
                },
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = snippetsClient.MethodDefaultValues(request);
            // End snippet
        }

        /// <summary>Snippet for MethodDefaultValuesAsync</summary>
        public async Task MethodDefaultValuesAsync_RequestObject()
        {
            // Snippet: MethodDefaultValuesAsync(DefaultValuesRequest, CallSettings)
            // Additional: MethodDefaultValuesAsync(DefaultValuesRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            DefaultValuesRequest request = new DefaultValuesRequest
            {
                SingleDouble = 0,
                SingleFloat = 0F,
                SingleInt32 = 0,
                SingleInt64 = 0L,
                SingleUint32 = 0U,
                SingleUint64 = 0UL,
                SingleSint32 = 0,
                SingleSint64 = 0L,
                SingleFixed32 = 0U,
                SingleFixed64 = 0UL,
                SingleSfixed32 = 0,
                SingleSfixed64 = 0L,
                SingleBool = false,
                SingleString = "",
                SingleBytes = ByteString.Empty,
                SingleMessage = new AnotherMessage(),
                SingleNestedMessage = new DefaultValuesRequest.Types.NestedMessage(),
                SingleEnum = Enum.Default,
                SingleNestedEnum = DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                RepeatedDouble = { 0, },
                RepeatedFloat = { 0F, },
                RepeatedInt32 = { 0, },
                RepeatedInt64 = { 0L, },
                RepeatedUint32 = { 0U, },
                RepeatedUint64 = { 0UL, },
                RepeatedSint32 = { 0, },
                RepeatedSint64 = { 0L, },
                RepeatedFixed32 = { 0U, },
                RepeatedFixed64 = { 0UL, },
                RepeatedSfixed32 = { 0, },
                RepeatedSfixed64 = { 0L, },
                RepeatedBool = { false, },
                RepeatedString = { "", },
                RepeatedBytes = { ByteString.Empty, },
                RepeatedMessage =
                {
                    new AnotherMessage(),
                },
                RepeatedNestedMessage =
                {
                    new DefaultValuesRequest.Types.NestedMessage(),
                },
                RepeatedEnum = { Enum.Default, },
                RepeatedNestedEnum =
                {
                    DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                },
                SingleResourceNameAsAResourceName = new AResourceName("[ITEM_ID]", "[PART_ID]"),
                RepeatedResourceNameAsAResourceNames =
                {
                    new AResourceName("[ITEM_ID]", "[PART_ID]"),
                },
                SingleWildcardResourceAsResourceName = new UnknownResourceName("a/wildcard/resource"),
                RepeatedWildcardResourceAsResourceNames =
                {
                    new UnknownResourceName("a/wildcard/resource"),
                },
                MultiPatternResourceNameAsMultiPatternResourceNameOneOf = MultiPatternResourceNameOneOf.From(new RootAItemName("[ROOT_A_ID]", "[ITEM_ID]")),
                RepeatedMultiPatternResourceNameAsMultiPatternResourceNameOneOfs =
                {
                    MultiPatternResourceNameOneOf.From(new RootAItemName("[ROOT_A_ID]", "[ITEM_ID]")),
                },
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = await snippetsClient.MethodDefaultValuesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodDefaultValues</summary>
        public void MethodDefaultValues()
        {
            // Snippet: MethodDefaultValues(IEnumerable<double>, IEnumerable<DefaultValuesRequest.Types.NestedMessage>, IEnumerable<string>, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            IEnumerable<double> repeatedDouble = new double[] { 0, };
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage = new DefaultValuesRequest.Types.NestedMessage[]
            {
                new DefaultValuesRequest.Types.NestedMessage(),
            };
            IEnumerable<string> repeatedResourceName = new string[]
            {
                "items/[ITEM_ID]/parts/[PART_ID]",
            };
            // Make the request
            Response response = snippetsClient.MethodDefaultValues(repeatedDouble, repeatedNestedMessage, repeatedResourceName);
            // End snippet
        }

        /// <summary>Snippet for MethodDefaultValuesAsync</summary>
        public async Task MethodDefaultValuesAsync()
        {
            // Snippet: MethodDefaultValuesAsync(IEnumerable<double>, IEnumerable<DefaultValuesRequest.Types.NestedMessage>, IEnumerable<string>, CallSettings)
            // Additional: MethodDefaultValuesAsync(IEnumerable<double>, IEnumerable<DefaultValuesRequest.Types.NestedMessage>, IEnumerable<string>, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            IEnumerable<double> repeatedDouble = new double[] { 0, };
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage = new DefaultValuesRequest.Types.NestedMessage[]
            {
                new DefaultValuesRequest.Types.NestedMessage(),
            };
            IEnumerable<string> repeatedResourceName = new string[]
            {
                "items/[ITEM_ID]/parts/[PART_ID]",
            };
            // Make the request
            Response response = await snippetsClient.MethodDefaultValuesAsync(repeatedDouble, repeatedNestedMessage, repeatedResourceName);
            // End snippet
        }

        /// <summary>Snippet for MethodDefaultValues</summary>
        public void MethodDefaultValues_ResourceNames()
        {
            // Snippet: MethodDefaultValues(IEnumerable<double>, IEnumerable<DefaultValuesRequest.Types.NestedMessage>, AResourceName, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            IEnumerable<double> repeatedDouble = new double[] { 0, };
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage = new DefaultValuesRequest.Types.NestedMessage[]
            {
                new DefaultValuesRequest.Types.NestedMessage(),
            };
            IEnumerable<AResourceName> repeatedResourceName = new AResourceName[]
            {
                new AResourceName("[ITEM_ID]", "[PART_ID]"),
            };
            // Make the request
            Response response = snippetsClient.MethodDefaultValues(repeatedDouble, repeatedNestedMessage, repeatedResourceName);
            // End snippet
        }

        /// <summary>Snippet for MethodDefaultValuesAsync</summary>
        public async Task MethodDefaultValuesAsync_ResourceNames()
        {
            // Snippet: MethodDefaultValuesAsync(IEnumerable<double>, IEnumerable<DefaultValuesRequest.Types.NestedMessage>, AResourceName, CallSettings)
            // Additional: MethodDefaultValuesAsync(IEnumerable<double>, IEnumerable<DefaultValuesRequest.Types.NestedMessage>, AResourceName, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            IEnumerable<double> repeatedDouble = new double[] { 0, };
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage = new DefaultValuesRequest.Types.NestedMessage[]
            {
                new DefaultValuesRequest.Types.NestedMessage(),
            };
            IEnumerable<AResourceName> repeatedResourceName = new AResourceName[]
            {
                new AResourceName("[ITEM_ID]", "[PART_ID]"),
            };
            // Make the request
            Response response = await snippetsClient.MethodDefaultValuesAsync(repeatedDouble, repeatedNestedMessage, repeatedResourceName);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignature</summary>
        public void MethodOneSignature_RequestObject()
        {
            // Snippet: MethodOneSignature(SignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = snippetsClient.MethodOneSignature(request);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignatureAsync</summary>
        public async Task MethodOneSignatureAsync_RequestObject()
        {
            // Snippet: MethodOneSignatureAsync(SignatureRequest, CallSettings)
            // Additional: MethodOneSignatureAsync(SignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = await snippetsClient.MethodOneSignatureAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignature</summary>
        public void MethodOneSignature()
        {
            // Snippet: MethodOneSignature(string, int, bool, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = snippetsClient.MethodOneSignature(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignatureAsync</summary>
        public async Task MethodOneSignatureAsync()
        {
            // Snippet: MethodOneSignatureAsync(string, int, bool, CallSettings)
            // Additional: MethodOneSignatureAsync(string, int, bool, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = await snippetsClient.MethodOneSignatureAsync(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures_RequestObject()
        {
            // Snippet: MethodThreeSignatures(SignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures(request);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignaturesAsync_RequestObject()
        {
            // Snippet: MethodThreeSignaturesAsync(SignatureRequest, CallSettings)
            // Additional: MethodThreeSignaturesAsync(SignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures1()
        {
            // Snippet: MethodThreeSignatures(string, int, bool, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignatures1Async()
        {
            // Snippet: MethodThreeSignaturesAsync(string, int, bool, CallSettings)
            // Additional: MethodThreeSignaturesAsync(string, int, bool, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures2()
        {
            // Snippet: MethodThreeSignatures(string, bool, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            bool aBool = false;
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures(aString, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignatures2Async()
        {
            // Snippet: MethodThreeSignaturesAsync(string, bool, CallSettings)
            // Additional: MethodThreeSignaturesAsync(string, bool, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            bool aBool = false;
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(aString, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures3()
        {
            // Snippet: MethodThreeSignatures(CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures();
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignatures3Async()
        {
            // Snippet: MethodThreeSignaturesAsync(CallSettings)
            // Additional: MethodThreeSignaturesAsync(CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync();
            // End snippet
        }

        /// <summary>Snippet for MethodMapSignature</summary>
        public void MethodMapSignature_RequestObject()
        {
            // Snippet: MethodMapSignature(SignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = snippetsClient.MethodMapSignature(request);
            // End snippet
        }

        /// <summary>Snippet for MethodMapSignatureAsync</summary>
        public async Task MethodMapSignatureAsync_RequestObject()
        {
            // Snippet: MethodMapSignatureAsync(SignatureRequest, CallSettings)
            // Additional: MethodMapSignatureAsync(SignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Response response = await snippetsClient.MethodMapSignatureAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodMapSignature</summary>
        public void MethodMapSignature()
        {
            // Snippet: MethodMapSignature(IDictionary<int,string>, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            IDictionary<int, string> mapIntString = new Dictionary<int, string> { { 0, "" }, };
            // Make the request
            Response response = snippetsClient.MethodMapSignature(mapIntString);
            // End snippet
        }

        /// <summary>Snippet for MethodMapSignatureAsync</summary>
        public async Task MethodMapSignatureAsync()
        {
            // Snippet: MethodMapSignatureAsync(IDictionary<int,string>, CallSettings)
            // Additional: MethodMapSignatureAsync(IDictionary<int,string>, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            IDictionary<int, string> mapIntString = new Dictionary<int, string> { { 0, "" }, };
            // Make the request
            Response response = await snippetsClient.MethodMapSignatureAsync(mapIntString);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature_RequestObject()
        {
            // Snippet: MethodResourceSignature(ResourceSignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
            };
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(request);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignatureAsync_RequestObject()
        {
            // Snippet: MethodResourceSignatureAsync(ResourceSignatureRequest, CallSettings)
            // Additional: MethodResourceSignatureAsync(ResourceSignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
            };
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature1()
        {
            // Snippet: MethodResourceSignature(string, string, string, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature1Async()
        {
            // Snippet: MethodResourceSignatureAsync(string, string, string, CallSettings)
            // Additional: MethodResourceSignatureAsync(string, string, string, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature1_ResourceNames()
        {
            // Snippet: MethodResourceSignature(SimpleResourceName, SimpleResourceName, SimpleResourceName, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName secondName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName thirdName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature1Async_ResourceNames()
        {
            // Snippet: MethodResourceSignatureAsync(SimpleResourceName, SimpleResourceName, SimpleResourceName, CallSettings)
            // Additional: MethodResourceSignatureAsync(SimpleResourceName, SimpleResourceName, SimpleResourceName, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName secondName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName thirdName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature2()
        {
            // Snippet: MethodResourceSignature(string, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature2Async()
        {
            // Snippet: MethodResourceSignatureAsync(string, CallSettings)
            // Additional: MethodResourceSignatureAsync(string, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature2_ResourceNames()
        {
            // Snippet: MethodResourceSignature(SimpleResourceName, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature2Async_ResourceNames()
        {
            // Snippet: MethodResourceSignatureAsync(SimpleResourceName, CallSettings)
            // Additional: MethodResourceSignatureAsync(SimpleResourceName, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName);
            // End snippet
        }

        /// <summary>Snippet for MethodLroSignatures</summary>
        public void MethodLroSignatures_RequestObject()
        {
            // Snippet: MethodLroSignatures(SignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Operation<LroResponse, LroMetadata> response = snippetsClient.MethodLroSignatures(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = snippetsClient.PollOnceMethodLroSignatures(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroSignaturesAsync</summary>
        public async Task MethodLroSignaturesAsync_RequestObject()
        {
            // Snippet: MethodLroSignaturesAsync(SignatureRequest, CallSettings)
            // Additional: MethodLroSignaturesAsync(SignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request
            Operation<LroResponse, LroMetadata> response = await snippetsClient.MethodLroSignaturesAsync(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = await snippetsClient.PollOnceMethodLroSignaturesAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroSignatures</summary>
        public void MethodLroSignatures()
        {
            // Snippet: MethodLroSignatures(string, int, bool, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Operation<LroResponse, LroMetadata> response = snippetsClient.MethodLroSignatures(aString, anInt, aBool);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = snippetsClient.PollOnceMethodLroSignatures(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroSignaturesAsync</summary>
        public async Task MethodLroSignaturesAsync()
        {
            // Snippet: MethodLroSignaturesAsync(string, int, bool, CallSettings)
            // Additional: MethodLroSignaturesAsync(string, int, bool, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Operation<LroResponse, LroMetadata> response = await snippetsClient.MethodLroSignaturesAsync(aString, anInt, aBool);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = await snippetsClient.PollOnceMethodLroSignaturesAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroResourceSignature</summary>
        public void MethodLroResourceSignature_RequestObject()
        {
            // Snippet: MethodLroResourceSignature(ResourceSignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
            };
            // Make the request
            Operation<LroResponse, LroMetadata> response = snippetsClient.MethodLroResourceSignature(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = snippetsClient.PollOnceMethodLroResourceSignature(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroResourceSignatureAsync</summary>
        public async Task MethodLroResourceSignatureAsync_RequestObject()
        {
            // Snippet: MethodLroResourceSignatureAsync(ResourceSignatureRequest, CallSettings)
            // Additional: MethodLroResourceSignatureAsync(ResourceSignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
            };
            // Make the request
            Operation<LroResponse, LroMetadata> response = await snippetsClient.MethodLroResourceSignatureAsync(request);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = await snippetsClient.PollOnceMethodLroResourceSignatureAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroResourceSignature</summary>
        public void MethodLroResourceSignature()
        {
            // Snippet: MethodLroResourceSignature(string, string, string, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request
            Operation<LroResponse, LroMetadata> response = snippetsClient.MethodLroResourceSignature(firstName, secondName, thirdName);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = snippetsClient.PollOnceMethodLroResourceSignature(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroResourceSignatureAsync</summary>
        public async Task MethodLroResourceSignatureAsync()
        {
            // Snippet: MethodLroResourceSignatureAsync(string, string, string, CallSettings)
            // Additional: MethodLroResourceSignatureAsync(string, string, string, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request
            Operation<LroResponse, LroMetadata> response = await snippetsClient.MethodLroResourceSignatureAsync(firstName, secondName, thirdName);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = await snippetsClient.PollOnceMethodLroResourceSignatureAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroResourceSignature</summary>
        public void MethodLroResourceSignature_ResourceNames()
        {
            // Snippet: MethodLroResourceSignature(SimpleResourceName, SimpleResourceName, SimpleResourceName, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName secondName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName thirdName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Operation<LroResponse, LroMetadata> response = snippetsClient.MethodLroResourceSignature(firstName, secondName, thirdName);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = response.PollUntilCompleted();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = snippetsClient.PollOnceMethodLroResourceSignature(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodLroResourceSignatureAsync</summary>
        public async Task MethodLroResourceSignatureAsync_ResourceNames()
        {
            // Snippet: MethodLroResourceSignatureAsync(SimpleResourceName, SimpleResourceName, SimpleResourceName, CallSettings)
            // Additional: MethodLroResourceSignatureAsync(SimpleResourceName, SimpleResourceName, SimpleResourceName, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName secondName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName thirdName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Operation<LroResponse, LroMetadata> response = await snippetsClient.MethodLroResourceSignatureAsync(firstName, secondName, thirdName);

            // Poll until the returned long-running operation is complete
            Operation<LroResponse, LroMetadata> completedResponse = await response.PollUntilCompletedAsync();
            // Retrieve the operation result
            LroResponse result = completedResponse.Result;

            // Or get the name of the operation
            string operationName = response.Name;
            // This name can be stored, then the long-running operation retrieved later by name
            Operation<LroResponse, LroMetadata> retrievedResponse = await snippetsClient.PollOnceMethodLroResourceSignatureAsync(operationName);
            // Check if the retrieved long-running operation has completed
            if (retrievedResponse.IsCompleted)
            {
                // If it has completed, then access the result
                LroResponse retrievedResult = retrievedResponse.Result;
            }
            // End snippet
        }

        /// <summary>Snippet for MethodServerStreaming</summary>
        public async Task MethodServerStreaming_RequestObject()
        {
            // Snippet: MethodServerStreaming(SignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
                MapIntString = { { 0, "" }, },
            };
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingStream response = snippetsClient.MethodServerStreaming(request);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.GetResponseStream(CancellationToken.None);
            while (await responseStream.MoveNextAsync())
            {
                Response responseItem = responseStream.Current;
                // Do something with streamed response
            }
            // The response stream has completed
            // End snippet
        }

        /// <summary>Snippet for MethodServerStreaming</summary>
        public async Task MethodServerStreaming1()
        {
            // Snippet: MethodServerStreaming(string, bool, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            bool aBool = false;
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingStream response = snippetsClient.MethodServerStreaming(aString, aBool);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.GetResponseStream(CancellationToken.None);
            while (await responseStream.MoveNextAsync())
            {
                Response responseItem = responseStream.Current;
                // Do something with streamed response
            }
            // The response stream has completed
            // End snippet
        }

        /// <summary>Snippet for MethodServerStreaming</summary>
        public async Task MethodServerStreaming2()
        {
            // Snippet: MethodServerStreaming(CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingStream response = snippetsClient.MethodServerStreaming();

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.GetResponseStream(CancellationToken.None);
            while (await responseStream.MoveNextAsync())
            {
                Response responseItem = responseStream.Current;
                // Do something with streamed response
            }
            // The response stream has completed
            // End snippet
        }

        /// <summary>Snippet for MethodServerStreamingResources</summary>
        public async Task MethodServerStreamingResources_RequestObject()
        {
            // Snippet: MethodServerStreamingResources(ResourceSignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
            };
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingResourcesStream response = snippetsClient.MethodServerStreamingResources(request);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.GetResponseStream(CancellationToken.None);
            while (await responseStream.MoveNextAsync())
            {
                Response responseItem = responseStream.Current;
                // Do something with streamed response
            }
            // The response stream has completed
            // End snippet
        }

        /// <summary>Snippet for MethodServerStreamingResources</summary>
        public async Task MethodServerStreamingResources()
        {
            // Snippet: MethodServerStreamingResources(string, string, string, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingResourcesStream response = snippetsClient.MethodServerStreamingResources(firstName, secondName, thirdName);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.GetResponseStream(CancellationToken.None);
            while (await responseStream.MoveNextAsync())
            {
                Response responseItem = responseStream.Current;
                // Do something with streamed response
            }
            // The response stream has completed
            // End snippet
        }

        /// <summary>Snippet for MethodServerStreamingResources</summary>
        public async Task MethodServerStreamingResources_ResourceNames()
        {
            // Snippet: MethodServerStreamingResources(SimpleResourceName, SimpleResourceName, SimpleResourceName, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName secondName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName thirdName = new SimpleResourceName("[ITEM_ID]");
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingResourcesStream response = snippetsClient.MethodServerStreamingResources(firstName, secondName, thirdName);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.GetResponseStream(CancellationToken.None);
            while (await responseStream.MoveNextAsync())
            {
                Response responseItem = responseStream.Current;
                // Do something with streamed response
            }
            // The response stream has completed
            // End snippet
        }

        /// <summary>Snippet for MethodBidiStreaming</summary>
        public async Task MethodBidiStreaming()
        {
            // Snippet: MethodBidiStreaming(CallSettings, BidirectionalStreamingSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize streaming call, retrieving the stream object
            SnippetsClient.MethodBidiStreamingStream response = snippetsClient.MethodBidiStreaming();

            // Sending requests and retrieving responses can be arbitrarily interleaved
            // Exact sequence will depend on client/server behavior

            // Create task to do something with responses from server
            Task responseHandlerTask = Task.Run(async () =>
            {
                IAsyncEnumerator<Response> responseStream = response.GetResponseStream(CancellationToken.None);
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
                SignatureRequest request = new SignatureRequest
                {
                    AString = "",
                    AnInt = 0,
                    ABool = false,
                    MapIntString = { { 0, "" }, },
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

        /// <summary>Snippet for TaskMethod</summary>
        public void TaskMethod_RequestObject()
        {
            // Snippet: TaskMethod(Task, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            ts::Task request = new ts::Task { };
            // Make the request
            ts::Task response = snippetsClient.TaskMethod(request);
            // End snippet
        }

        /// <summary>Snippet for TaskMethodAsync</summary>
        public async Task TaskMethodAsync_RequestObject()
        {
            // Snippet: TaskMethodAsync(Task, CallSettings)
            // Additional: TaskMethodAsync(Task, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            ts::Task request = new ts::Task { };
            // Make the request
            ts::Task response = await snippetsClient.TaskMethodAsync(request);
            // End snippet
        }
    }
}
