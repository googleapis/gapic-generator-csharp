namespace Testing.Snippets
{
    using Google.Api.Gax;
    using Google.LongRunning;
    using Google.Protobuf;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedSnippetsSnippets
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
            };
            // Make the request
            Response response = await snippetsClient.MethodDefaultValuesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodDefaultValues</summary>
        public void MethodDefaultValues()
        {
            // Snippet: MethodDefaultValues(IEnumerable, IEnumerable, IEnumerable, CallSettings)
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
            // Snippet: MethodDefaultValuesAsync(IEnumerable, IEnumerable, IEnumerable, CallSettings)
            // Additional: MethodDefaultValuesAsync(IEnumerable, IEnumerable, IEnumerable, CancellationToken)
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
            // Snippet: MethodDefaultValues(IEnumerable, IEnumerable, AResourceName, CallSettings)
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
            // Snippet: MethodDefaultValuesAsync(IEnumerable, IEnumerable, AResourceName, CallSettings)
            // Additional: MethodDefaultValuesAsync(IEnumerable, IEnumerable, AResourceName, CancellationToken)
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
            };
            // Make the request
            Response response = await snippetsClient.MethodOneSignatureAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignature</summary>
        public void MethodOneSignature()
        {
            // Snippet: MethodOneSignature(String, Int32, Boolean, CallSettings)
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
            // Snippet: MethodOneSignatureAsync(String, Int32, Boolean, CallSettings)
            // Additional: MethodOneSignatureAsync(String, Int32, Boolean, CancellationToken)
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
            };
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures1()
        {
            // Snippet: MethodThreeSignatures(String, Int32, Boolean, CallSettings)
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
            // Snippet: MethodThreeSignaturesAsync(String, Int32, Boolean, CallSettings)
            // Additional: MethodThreeSignaturesAsync(String, Int32, Boolean, CancellationToken)
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
            // Snippet: MethodThreeSignatures(String, Boolean, CallSettings)
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
            // Snippet: MethodThreeSignaturesAsync(String, Boolean, CallSettings)
            // Additional: MethodThreeSignaturesAsync(String, Boolean, CancellationToken)
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
            // Snippet: MethodResourceSignature(String, String, String, CallSettings)
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
            // Snippet: MethodResourceSignatureAsync(String, String, String, CallSettings)
            // Additional: MethodResourceSignatureAsync(String, String, String, CancellationToken)
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
            // Snippet: MethodResourceSignature(String, CallSettings)
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
            // Snippet: MethodResourceSignatureAsync(String, CallSettings)
            // Additional: MethodResourceSignatureAsync(String, CancellationToken)
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
            // Snippet: MethodLroSignatures(String, Int32, Boolean, CallSettings)
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
            // Snippet: MethodLroSignaturesAsync(String, Int32, Boolean, CallSettings)
            // Additional: MethodLroSignaturesAsync(String, Int32, Boolean, CancellationToken)
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
            // Snippet: MethodLroResourceSignature(String, String, String, CallSettings)
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
            // Snippet: MethodLroResourceSignatureAsync(String, String, String, CallSettings)
            // Additional: MethodLroResourceSignatureAsync(String, String, String, CancellationToken)
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
            };
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingStream response = snippetsClient.MethodServerStreaming(request);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.ResponseStream;
            while (await responseStream.MoveNext())
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
            // Snippet: MethodServerStreaming(String, Boolean, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            bool aBool = false;
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingStream response = snippetsClient.MethodServerStreaming(aString, aBool);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.ResponseStream;
            while (await responseStream.MoveNext())
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
            IAsyncEnumerator<Response> responseStream = response.ResponseStream;
            while (await responseStream.MoveNext())
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
            IAsyncEnumerator<Response> responseStream = response.ResponseStream;
            while (await responseStream.MoveNext())
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
            // Snippet: MethodServerStreamingResources(String, String, String, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request, returning a streaming response
            SnippetsClient.MethodServerStreamingResourcesStream response = snippetsClient.MethodServerStreamingResources(firstName, secondName, thirdName);

            // Read streaming responses from server until complete
            IAsyncEnumerator<Response> responseStream = response.ResponseStream;
            while (await responseStream.MoveNext())
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
            IAsyncEnumerator<Response> responseStream = response.ResponseStream;
            while (await responseStream.MoveNext())
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
                IAsyncEnumerator<Response> responseStream = response.ResponseStream;
                while (await responseStream.MoveNext())
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
    }
}
