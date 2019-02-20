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
    }
}
