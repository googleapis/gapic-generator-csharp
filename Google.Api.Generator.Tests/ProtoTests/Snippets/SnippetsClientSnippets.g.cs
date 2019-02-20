namespace Testing.Snippets
{
    using Google.Api.Gax;
    using Google.Protobuf;
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
        public async Task MethodThreeSignaturesAsync1()
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
        public async Task MethodThreeSignaturesAsync2()
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
        public async Task MethodThreeSignaturesAsync3()
        {
            // Snippet: MethodThreeSignaturesAsync(CallSettings)
            // Additional: MethodThreeSignaturesAsync(CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync();
            // End snippet
        }
    }
}
