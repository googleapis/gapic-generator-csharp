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
    using Google.Api.Gax;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Testing.ResourceNames;

    /// <summary>Generated snippets.</summary>
    public sealed class AllGeneratedResourceNamesClientSnippets
    {
        /// <summary>Snippet for SinglePatternMethod</summary>
        public void SinglePatternMethodRequestObject()
        {
            // Snippet: SinglePatternMethod(SinglePattern, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            // Make the request
            Response response = resourceNamesClient.SinglePatternMethod(request);
            // End snippet
        }

        /// <summary>Snippet for SinglePatternMethodAsync</summary>
        public async Task SinglePatternMethodRequestObjectAsync()
        {
            // Snippet: SinglePatternMethodAsync(SinglePattern, CallSettings)
            // Additional: SinglePatternMethodAsync(SinglePattern, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            // Make the request
            Response response = await resourceNamesClient.SinglePatternMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SinglePatternMethod</summary>
        public void SinglePatternMethod()
        {
            // Snippet: SinglePatternMethod(string, string, IEnumerable<string>, string, IEnumerable<string>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            string realName = "items/[ITEM_ID]";
            string @ref = "items/[ITEM_ID]";
            IEnumerable<string> repeatedRef = new string[] { "items/[ITEM_ID]", };
            string valueRef = "items/[ITEM_ID]";
            IEnumerable<string> repeatedValueRef = new string[] { "items/[ITEM_ID]", };
            // Make the request
            Response response = resourceNamesClient.SinglePatternMethod(realName, @ref, repeatedRef, valueRef, repeatedValueRef);
            // End snippet
        }

        /// <summary>Snippet for SinglePatternMethodAsync</summary>
        public async Task SinglePatternMethodAsync()
        {
            // Snippet: SinglePatternMethodAsync(string, string, IEnumerable<string>, string, IEnumerable<string>, CallSettings)
            // Additional: SinglePatternMethodAsync(string, string, IEnumerable<string>, string, IEnumerable<string>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            string realName = "items/[ITEM_ID]";
            string @ref = "items/[ITEM_ID]";
            IEnumerable<string> repeatedRef = new string[] { "items/[ITEM_ID]", };
            string valueRef = "items/[ITEM_ID]";
            IEnumerable<string> repeatedValueRef = new string[] { "items/[ITEM_ID]", };
            // Make the request
            Response response = await resourceNamesClient.SinglePatternMethodAsync(realName, @ref, repeatedRef, valueRef, repeatedValueRef);
            // End snippet
        }

        /// <summary>Snippet for SinglePatternMethod</summary>
        public void SinglePatternMethodResourceNames()
        {
            // Snippet: SinglePatternMethod(SinglePatternName, SinglePatternName, IEnumerable<SinglePatternName>, SinglePatternName, IEnumerable<SinglePatternName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            SinglePatternName realName = SinglePatternName.FromItem("[ITEM_ID]");
            SinglePatternName @ref = SinglePatternName.FromItem("[ITEM_ID]");
            IEnumerable<SinglePatternName> repeatedRef = new SinglePatternName[]
            {
                SinglePatternName.FromItem("[ITEM_ID]"),
            };
            SinglePatternName valueRef = SinglePatternName.FromItem("[ITEM_ID]");
            IEnumerable<SinglePatternName> repeatedValueRef = new SinglePatternName[]
            {
                SinglePatternName.FromItem("[ITEM_ID]"),
            };
            // Make the request
            Response response = resourceNamesClient.SinglePatternMethod(realName, @ref, repeatedRef, valueRef, repeatedValueRef);
            // End snippet
        }

        /// <summary>Snippet for SinglePatternMethodAsync</summary>
        public async Task SinglePatternMethodResourceNamesAsync()
        {
            // Snippet: SinglePatternMethodAsync(SinglePatternName, SinglePatternName, IEnumerable<SinglePatternName>, SinglePatternName, IEnumerable<SinglePatternName>, CallSettings)
            // Additional: SinglePatternMethodAsync(SinglePatternName, SinglePatternName, IEnumerable<SinglePatternName>, SinglePatternName, IEnumerable<SinglePatternName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            SinglePatternName realName = SinglePatternName.FromItem("[ITEM_ID]");
            SinglePatternName @ref = SinglePatternName.FromItem("[ITEM_ID]");
            IEnumerable<SinglePatternName> repeatedRef = new SinglePatternName[]
            {
                SinglePatternName.FromItem("[ITEM_ID]"),
            };
            SinglePatternName valueRef = SinglePatternName.FromItem("[ITEM_ID]");
            IEnumerable<SinglePatternName> repeatedValueRef = new SinglePatternName[]
            {
                SinglePatternName.FromItem("[ITEM_ID]"),
            };
            // Make the request
            Response response = await resourceNamesClient.SinglePatternMethodAsync(realName, @ref, repeatedRef, valueRef, repeatedValueRef);
            // End snippet
        }

        /// <summary>Snippet for DeprecatedPatternMethod</summary>
        public void DeprecatedPatternMethodRequestObject()
        {
            // Snippet: DeprecatedPatternMethod(DeprecatedPattern, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            DeprecatedPattern request = new DeprecatedPattern { };
            // Make the request
            Response response = resourceNamesClient.DeprecatedPatternMethod(request);
            // End snippet
        }

        /// <summary>Snippet for DeprecatedPatternMethodAsync</summary>
        public async Task DeprecatedPatternMethodRequestObjectAsync()
        {
            // Snippet: DeprecatedPatternMethodAsync(DeprecatedPattern, CallSettings)
            // Additional: DeprecatedPatternMethodAsync(DeprecatedPattern, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            DeprecatedPattern request = new DeprecatedPattern { };
            // Make the request
            Response response = await resourceNamesClient.DeprecatedPatternMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for DeprecatedPatternMethod</summary>
        public void DeprecatedPatternMethod()
        {
            // Snippet: DeprecatedPatternMethod(string, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            string name = "items/[ITEM_ID]";
            // Make the request
#pragma warning disable CS0612
            Response response = resourceNamesClient.DeprecatedPatternMethod(name);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedPatternMethodAsync</summary>
        public async Task DeprecatedPatternMethodAsync()
        {
            // Snippet: DeprecatedPatternMethodAsync(string, CallSettings)
            // Additional: DeprecatedPatternMethodAsync(string, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            string name = "items/[ITEM_ID]";
            // Make the request
#pragma warning disable CS0612
            Response response = await resourceNamesClient.DeprecatedPatternMethodAsync(name);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedPatternMethod</summary>
        public void DeprecatedPatternMethodResourceNames()
        {
            // Snippet: DeprecatedPatternMethod(DeprecatedPatternName, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            DeprecatedPatternName name = DeprecatedPatternName.FromItem("[ITEM_ID]");
            // Make the request
#pragma warning disable CS0612
            Response response = resourceNamesClient.DeprecatedPatternMethod(name);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for DeprecatedPatternMethodAsync</summary>
        public async Task DeprecatedPatternMethodResourceNamesAsync()
        {
            // Snippet: DeprecatedPatternMethodAsync(DeprecatedPatternName, CallSettings)
            // Additional: DeprecatedPatternMethodAsync(DeprecatedPatternName, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            DeprecatedPatternName name = DeprecatedPatternName.FromItem("[ITEM_ID]");
            // Make the request
#pragma warning disable CS0612
            Response response = await resourceNamesClient.DeprecatedPatternMethodAsync(name);
#pragma warning restore CS0612
            // End snippet
        }

        /// <summary>Snippet for WildcardOnlyPatternMethod</summary>
        public void WildcardOnlyPatternMethodRequestObject()
        {
            // Snippet: WildcardOnlyPatternMethod(WildcardOnlyPattern, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new UnparsedResourceName("a/wildcard/resource"),
                },
            };
            // Make the request
            Response response = resourceNamesClient.WildcardOnlyPatternMethod(request);
            // End snippet
        }

        /// <summary>Snippet for WildcardOnlyPatternMethodAsync</summary>
        public async Task WildcardOnlyPatternMethodRequestObjectAsync()
        {
            // Snippet: WildcardOnlyPatternMethodAsync(WildcardOnlyPattern, CallSettings)
            // Additional: WildcardOnlyPatternMethodAsync(WildcardOnlyPattern, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new UnparsedResourceName("a/wildcard/resource"),
                },
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardOnlyPatternMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for WildcardOnlyPatternMethod</summary>
        public void WildcardOnlyPatternMethod()
        {
            // Snippet: WildcardOnlyPatternMethod(string, string, IEnumerable<string>, string, IEnumerable<string>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            string name = "a/wildcard/resource";
            string @ref = "a/wildcard/resource";
            IEnumerable<string> repeatedRef = new string[]
            {
                "a/wildcard/resource",
            };
            string refSugar = "a/wildcard/resource";
            IEnumerable<string> repeatedRefSugar = new string[]
            {
                "a/wildcard/resource",
            };
            // Make the request
            Response response = resourceNamesClient.WildcardOnlyPatternMethod(name, @ref, repeatedRef, refSugar, repeatedRefSugar);
            // End snippet
        }

        /// <summary>Snippet for WildcardOnlyPatternMethodAsync</summary>
        public async Task WildcardOnlyPatternMethodAsync()
        {
            // Snippet: WildcardOnlyPatternMethodAsync(string, string, IEnumerable<string>, string, IEnumerable<string>, CallSettings)
            // Additional: WildcardOnlyPatternMethodAsync(string, string, IEnumerable<string>, string, IEnumerable<string>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            string name = "a/wildcard/resource";
            string @ref = "a/wildcard/resource";
            IEnumerable<string> repeatedRef = new string[]
            {
                "a/wildcard/resource",
            };
            string refSugar = "a/wildcard/resource";
            IEnumerable<string> repeatedRefSugar = new string[]
            {
                "a/wildcard/resource",
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardOnlyPatternMethodAsync(name, @ref, repeatedRef, refSugar, repeatedRefSugar);
            // End snippet
        }

        /// <summary>Snippet for WildcardOnlyPatternMethod</summary>
        public void WildcardOnlyPatternMethodResourceNames()
        {
            // Snippet: WildcardOnlyPatternMethod(IResourceName, IResourceName, IEnumerable<IResourceName>, IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            IResourceName refSugar = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRefSugar = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardOnlyPatternMethod(name, @ref, repeatedRef, refSugar, repeatedRefSugar);
            // End snippet
        }

        /// <summary>Snippet for WildcardOnlyPatternMethodAsync</summary>
        public async Task WildcardOnlyPatternMethodResourceNamesAsync()
        {
            // Snippet: WildcardOnlyPatternMethodAsync(IResourceName, IResourceName, IEnumerable<IResourceName>, IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Additional: WildcardOnlyPatternMethodAsync(IResourceName, IResourceName, IEnumerable<IResourceName>, IResourceName, IEnumerable<IResourceName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            IResourceName refSugar = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRefSugar = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardOnlyPatternMethodAsync(name, @ref, repeatedRef, refSugar, repeatedRefSugar);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodRequestObject()
        {
            // Snippet: WildcardMultiPatternMethod(WildcardMultiPattern, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromSingularItem(),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromSingularItem(),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromSingularItem(),
                },
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(request);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodRequestObjectAsync()
        {
            // Snippet: WildcardMultiPatternMethodAsync(WildcardMultiPattern, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(WildcardMultiPattern, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromSingularItem(),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromSingularItem(),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromSingularItem(),
                },
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethod()
        {
            // Snippet: WildcardMultiPatternMethod(string, string, IEnumerable<string>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            string name = "singular_item";
            string @ref = "singular_item";
            IEnumerable<string> repeatedRef = new string[] { "singular_item", };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodAsync()
        {
            // Snippet: WildcardMultiPatternMethodAsync(string, string, IEnumerable<string>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(string, string, IEnumerable<string>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            string name = "singular_item";
            string @ref = "singular_item";
            IEnumerable<string> repeatedRef = new string[] { "singular_item", };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames1()
        {
            // Snippet: WildcardMultiPatternMethod(WildcardMultiPatternName, WildcardMultiPatternName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames1Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, WildcardMultiPatternName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, WildcardMultiPatternName, IEnumerable<WildcardMultiPatternName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames2()
        {
            // Snippet: WildcardMultiPatternMethod(WildcardMultiPatternName, WildcardMultiPatternName, IEnumerable<IResourceName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames2Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, WildcardMultiPatternName, IEnumerable<IResourceName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, WildcardMultiPatternName, IEnumerable<IResourceName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames3()
        {
            // Snippet: WildcardMultiPatternMethod(WildcardMultiPatternName, IResourceName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames3Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, IResourceName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, IResourceName, IEnumerable<WildcardMultiPatternName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames4()
        {
            // Snippet: WildcardMultiPatternMethod(WildcardMultiPatternName, IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames4Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(WildcardMultiPatternName, IResourceName, IEnumerable<IResourceName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPatternName name = WildcardMultiPatternName.FromSingularItem();
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames5()
        {
            // Snippet: WildcardMultiPatternMethod(IResourceName, WildcardMultiPatternName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames5Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(IResourceName, WildcardMultiPatternName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(IResourceName, WildcardMultiPatternName, IEnumerable<WildcardMultiPatternName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames6()
        {
            // Snippet: WildcardMultiPatternMethod(IResourceName, WildcardMultiPatternName, IEnumerable<IResourceName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames6Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(IResourceName, WildcardMultiPatternName, IEnumerable<IResourceName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(IResourceName, WildcardMultiPatternName, IEnumerable<IResourceName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            WildcardMultiPatternName @ref = WildcardMultiPatternName.FromSingularItem();
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames7()
        {
            // Snippet: WildcardMultiPatternMethod(IResourceName, IResourceName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames7Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(IResourceName, IResourceName, IEnumerable<WildcardMultiPatternName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(IResourceName, IResourceName, IEnumerable<WildcardMultiPatternName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<WildcardMultiPatternName> repeatedRef = new WildcardMultiPatternName[]
            {
                WildcardMultiPatternName.FromSingularItem(),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethod</summary>
        public void WildcardMultiPatternMethodResourceNames8()
        {
            // Snippet: WildcardMultiPatternMethod(IResourceName, IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMethod(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMethodAsync</summary>
        public async Task WildcardMultiPatternMethodResourceNames8Async()
        {
            // Snippet: WildcardMultiPatternMethodAsync(IResourceName, IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Additional: WildcardMultiPatternMethodAsync(IResourceName, IResourceName, IEnumerable<IResourceName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            IResourceName name = new UnparsedResourceName("a/wildcard/resource");
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMethodAsync(name, @ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethod</summary>
        public void WildcardMultiPatternMultipleMethodRequestObject()
        {
            // Snippet: WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultiple, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                WildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMultipleMethod(request);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethodAsync</summary>
        public async Task WildcardMultiPatternMultipleMethodRequestObjectAsync()
        {
            // Snippet: WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultiple, CallSettings)
            // Additional: WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultiple, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                WildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMultipleMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethod</summary>
        public void WildcardMultiPatternMultipleMethod()
        {
            // Snippet: WildcardMultiPatternMultipleMethod(string, IEnumerable<string>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            string @ref = "constPattern";
            IEnumerable<string> repeatedRef = new string[] { "constPattern", };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMultipleMethod(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethodAsync</summary>
        public async Task WildcardMultiPatternMultipleMethodAsync()
        {
            // Snippet: WildcardMultiPatternMultipleMethodAsync(string, IEnumerable<string>, CallSettings)
            // Additional: WildcardMultiPatternMultipleMethodAsync(string, IEnumerable<string>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            string @ref = "constPattern";
            IEnumerable<string> repeatedRef = new string[] { "constPattern", };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethod</summary>
        public void WildcardMultiPatternMultipleMethodResourceNames1()
        {
            // Snippet: WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultipleName, IEnumerable<WildcardMultiPatternMultipleName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPatternMultipleName @ref = WildcardMultiPatternMultipleName.FromConstPattern();
            IEnumerable<WildcardMultiPatternMultipleName> repeatedRef = new WildcardMultiPatternMultipleName[]
            {
                WildcardMultiPatternMultipleName.FromConstPattern(),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMultipleMethod(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethodAsync</summary>
        public async Task WildcardMultiPatternMultipleMethodResourceNames1Async()
        {
            // Snippet: WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName, IEnumerable<WildcardMultiPatternMultipleName>, CallSettings)
            // Additional: WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName, IEnumerable<WildcardMultiPatternMultipleName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPatternMultipleName @ref = WildcardMultiPatternMultipleName.FromConstPattern();
            IEnumerable<WildcardMultiPatternMultipleName> repeatedRef = new WildcardMultiPatternMultipleName[]
            {
                WildcardMultiPatternMultipleName.FromConstPattern(),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethod</summary>
        public void WildcardMultiPatternMultipleMethodResourceNames2()
        {
            // Snippet: WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultipleName, IEnumerable<IResourceName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            WildcardMultiPatternMultipleName @ref = WildcardMultiPatternMultipleName.FromConstPattern();
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMultipleMethod(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethodAsync</summary>
        public async Task WildcardMultiPatternMultipleMethodResourceNames2Async()
        {
            // Snippet: WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName, IEnumerable<IResourceName>, CallSettings)
            // Additional: WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName, IEnumerable<IResourceName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            WildcardMultiPatternMultipleName @ref = WildcardMultiPatternMultipleName.FromConstPattern();
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethod</summary>
        public void WildcardMultiPatternMultipleMethodResourceNames3()
        {
            // Snippet: WildcardMultiPatternMultipleMethod(IResourceName, IEnumerable<WildcardMultiPatternMultipleName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<WildcardMultiPatternMultipleName> repeatedRef = new WildcardMultiPatternMultipleName[]
            {
                WildcardMultiPatternMultipleName.FromConstPattern(),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMultipleMethod(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethodAsync</summary>
        public async Task WildcardMultiPatternMultipleMethodResourceNames3Async()
        {
            // Snippet: WildcardMultiPatternMultipleMethodAsync(IResourceName, IEnumerable<WildcardMultiPatternMultipleName>, CallSettings)
            // Additional: WildcardMultiPatternMultipleMethodAsync(IResourceName, IEnumerable<WildcardMultiPatternMultipleName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<WildcardMultiPatternMultipleName> repeatedRef = new WildcardMultiPatternMultipleName[]
            {
                WildcardMultiPatternMultipleName.FromConstPattern(),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethod</summary>
        public void WildcardMultiPatternMultipleMethodResourceNames4()
        {
            // Snippet: WildcardMultiPatternMultipleMethod(IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = resourceNamesClient.WildcardMultiPatternMultipleMethod(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for WildcardMultiPatternMultipleMethodAsync</summary>
        public async Task WildcardMultiPatternMultipleMethodResourceNames4Async()
        {
            // Snippet: WildcardMultiPatternMultipleMethodAsync(IResourceName, IEnumerable<IResourceName>, CallSettings)
            // Additional: WildcardMultiPatternMultipleMethodAsync(IResourceName, IEnumerable<IResourceName>, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            IResourceName @ref = new UnparsedResourceName("a/wildcard/resource");
            IEnumerable<IResourceName> repeatedRef = new IResourceName[]
            {
                new UnparsedResourceName("a/wildcard/resource"),
            };
            // Make the request
            Response response = await resourceNamesClient.WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef);
            // End snippet
        }

        /// <summary>Snippet for LooseValidationPatternMethod</summary>
        public void LooseValidationPatternMethodRequestObject()
        {
            // Snippet: LooseValidationPatternMethod(LooseValidationPattern, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            LooseValidationPattern request = new LooseValidationPattern
            {
                LooseValidationPatternName = LooseValidationPatternName.FromParentItem("[PARENT_ID]", "[ITEM_ID]"),
            };
            // Make the request
            Response response = resourceNamesClient.LooseValidationPatternMethod(request);
            // End snippet
        }

        /// <summary>Snippet for LooseValidationPatternMethodAsync</summary>
        public async Task LooseValidationPatternMethodRequestObjectAsync()
        {
            // Snippet: LooseValidationPatternMethodAsync(LooseValidationPattern, CallSettings)
            // Additional: LooseValidationPatternMethodAsync(LooseValidationPattern, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            LooseValidationPattern request = new LooseValidationPattern
            {
                LooseValidationPatternName = LooseValidationPatternName.FromParentItem("[PARENT_ID]", "[ITEM_ID]"),
            };
            // Make the request
            Response response = await resourceNamesClient.LooseValidationPatternMethodAsync(request);
            // End snippet
        }

        /// <summary>Snippet for LooseValidationPatternMethod</summary>
        public void LooseValidationPatternMethod()
        {
            // Snippet: LooseValidationPatternMethod(string, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            string name = "parents/[PARENT_ID]/invalid_name/items/[ITEM_ID]";
            // Make the request
            Response response = resourceNamesClient.LooseValidationPatternMethod(name);
            // End snippet
        }

        /// <summary>Snippet for LooseValidationPatternMethodAsync</summary>
        public async Task LooseValidationPatternMethodAsync()
        {
            // Snippet: LooseValidationPatternMethodAsync(string, CallSettings)
            // Additional: LooseValidationPatternMethodAsync(string, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            string name = "parents/[PARENT_ID]/invalid_name/items/[ITEM_ID]";
            // Make the request
            Response response = await resourceNamesClient.LooseValidationPatternMethodAsync(name);
            // End snippet
        }

        /// <summary>Snippet for LooseValidationPatternMethod</summary>
        public void LooseValidationPatternMethodResourceNames()
        {
            // Snippet: LooseValidationPatternMethod(LooseValidationPatternName, CallSettings)
            // Create client
            ResourceNamesClient resourceNamesClient = ResourceNamesClient.Create();
            // Initialize request argument(s)
            LooseValidationPatternName name = LooseValidationPatternName.FromParentItem("[PARENT_ID]", "[ITEM_ID]");
            // Make the request
            Response response = resourceNamesClient.LooseValidationPatternMethod(name);
            // End snippet
        }

        /// <summary>Snippet for LooseValidationPatternMethodAsync</summary>
        public async Task LooseValidationPatternMethodResourceNamesAsync()
        {
            // Snippet: LooseValidationPatternMethodAsync(LooseValidationPatternName, CallSettings)
            // Additional: LooseValidationPatternMethodAsync(LooseValidationPatternName, CancellationToken)
            // Create client
            ResourceNamesClient resourceNamesClient = await ResourceNamesClient.CreateAsync();
            // Initialize request argument(s)
            LooseValidationPatternName name = LooseValidationPatternName.FromParentItem("[PARENT_ID]", "[ITEM_ID]");
            // Make the request
            Response response = await resourceNamesClient.LooseValidationPatternMethodAsync(name);
            // End snippet
        }
    }
}
