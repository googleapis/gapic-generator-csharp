// Copyright 2021 Google LLC
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

namespace Google.Apis.ManufacturerCenter.v1
{
    /// <summary>The ManufacturerCenter Service.</summary>
    public class ManufacturerCenterService : Google.Apis.Services.BaseClientService
    {
        /// <summary>The API version.</summary>
        public const string Version = "v1";

        /// <summary>The discovery version used to generate this service.</summary>
        public static Google.Apis.Discovery.DiscoveryVersion DiscoveryVersionUsed = Google.Apis.Discovery.DiscoveryVersion.Version_1_0;

        /// <summary>Constructs a new service.</summary>
        public ManufacturerCenterService() : this(new Google.Apis.Services.BaseClientService.Initializer())
        {
        }

        /// <summary>Constructs a new service.</summary>
        /// <param name="initializer">The service initializer.</param>
        public ManufacturerCenterService(Google.Apis.Services.BaseClientService.Initializer initializer) : base(initializer)
        {
            Accounts = new AccountsResource(this);
        }

        /// <summary>Gets the service supported features.</summary>
        public override System.Collections.Generic.IList<string> Features => new string[0];

        /// <summary>Gets the service name.</summary>
        public override string Name => "manufacturers";

        /// <summary>Gets the service base URI.</summary>
        public override string BaseUri =>
        #if NETSTANDARD1_3 || NETSTANDARD2_0 || NET45
            BaseUriOverride ?? "https://manufacturers.googleapis.com/";
        #else
            "https://manufacturers.googleapis.com/";
        #endif

        /// <summary>Gets the service base path.</summary>
        public override string BasePath => "";

        #if !NET40
        /// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>
        public override string BatchUri => "https://manufacturers.googleapis.com/batch";

        /// <summary>Gets the batch base path; <c>null</c> if unspecified.</summary>
        public override string BatchPath => "batch";
        #endif

        /// <summary>Available OAuth 2.0 scopes for use with the Manufacturer Center API.</summary>
        public class Scope
        {
            /// <summary>Manage your product listings for Google Manufacturer Center</summary>
            public static string Manufacturercenter = "https://www.googleapis.com/auth/manufacturercenter";
        }

        /// <summary>Available OAuth 2.0 scope constants for use with the Manufacturer Center API.</summary>
        public static class ScopeConstants
        {
            /// <summary>Manage your product listings for Google Manufacturer Center</summary>
            public const string Manufacturercenter = "https://www.googleapis.com/auth/manufacturercenter";
        }

        /// <summary>Gets the Accounts resource.</summary>
        public virtual AccountsResource Accounts { get; }
    }

    /// <summary>A base abstract class for ManufacturerCenter requests.</summary>
    public abstract class ManufacturerCenterBaseServiceRequest<TResponse> : Google.Apis.Requests.ClientServiceRequest<TResponse>
    {
        /// <summary>Constructs a new ManufacturerCenterBaseServiceRequest instance.</summary>
        protected ManufacturerCenterBaseServiceRequest(Google.Apis.Services.IClientService service) : base(service)
        {
        }

        /// <summary>V1 error format.</summary>
        [Google.Apis.Util.RequestParameterAttribute("$.xgafv", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<XgafvEnum> Xgafv { get; set; }

        /// <summary>V1 error format.</summary>
        public enum XgafvEnum
        {
            /// <summary>v1 error format</summary>
            [Google.Apis.Util.StringValueAttribute("1")]
            Value1 = 0,

            /// <summary>v2 error format</summary>
            [Google.Apis.Util.StringValueAttribute("2")]
            Value2 = 1,
        }

        /// <summary>OAuth access token.</summary>
        [Google.Apis.Util.RequestParameterAttribute("access_token", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string AccessToken { get; set; }

        /// <summary>Data format for response.</summary>
        [Google.Apis.Util.RequestParameterAttribute("alt", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<AltEnum> Alt { get; set; }

        /// <summary>Data format for response.</summary>
        public enum AltEnum
        {
            /// <summary>Responses with Content-Type of application/json</summary>
            [Google.Apis.Util.StringValueAttribute("json")]
            Json = 0,

            /// <summary>Media download with context-dependent Content-Type</summary>
            [Google.Apis.Util.StringValueAttribute("media")]
            Media = 1,

            /// <summary>Responses with Content-Type of application/x-protobuf</summary>
            [Google.Apis.Util.StringValueAttribute("proto")]
            Proto = 2,
        }

        /// <summary>JSONP</summary>
        [Google.Apis.Util.RequestParameterAttribute("callback", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Callback { get; set; }

        /// <summary>Selector specifying which fields to include in a partial response.</summary>
        [Google.Apis.Util.RequestParameterAttribute("fields", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Fields { get; set; }

        /// <summary>
        /// API key. Your API key identifies your project and provides you with API access, quota, and reports. Required
        /// unless you provide an OAuth 2.0 token.
        /// </summary>
        [Google.Apis.Util.RequestParameterAttribute("key", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Key { get; set; }

        /// <summary>OAuth 2.0 token for the current user.</summary>
        [Google.Apis.Util.RequestParameterAttribute("oauth_token", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string OauthToken { get; set; }

        /// <summary>Returns response with indentations and line breaks.</summary>
        [Google.Apis.Util.RequestParameterAttribute("prettyPrint", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<bool> PrettyPrint { get; set; }

        /// <summary>
        /// Available to use for quota purposes for server-side applications. Can be any arbitrary string assigned to a
        /// user, but should not exceed 40 characters.
        /// </summary>
        [Google.Apis.Util.RequestParameterAttribute("quotaUser", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string QuotaUser { get; set; }

        /// <summary>Legacy upload protocol for media (e.g. "media", "multipart").</summary>
        [Google.Apis.Util.RequestParameterAttribute("uploadType", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string UploadType { get; set; }

        /// <summary>Upload protocol for media (e.g. "raw", "multipart").</summary>
        [Google.Apis.Util.RequestParameterAttribute("upload_protocol", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string UploadProtocol { get; set; }

        /// <summary>Initializes ManufacturerCenter parameter list.</summary>
        protected override void InitParameters()
        {
            base.InitParameters();
            RequestParameters.Add("$.xgafv", new Google.Apis.Discovery.Parameter
            {
                Name = "$.xgafv",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("access_token", new Google.Apis.Discovery.Parameter
            {
                Name = "access_token",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("alt", new Google.Apis.Discovery.Parameter
            {
                Name = "alt",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = "json",
                Pattern = null,
            });
            RequestParameters.Add("callback", new Google.Apis.Discovery.Parameter
            {
                Name = "callback",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("fields", new Google.Apis.Discovery.Parameter
            {
                Name = "fields",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("key", new Google.Apis.Discovery.Parameter
            {
                Name = "key",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("oauth_token", new Google.Apis.Discovery.Parameter
            {
                Name = "oauth_token",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("prettyPrint", new Google.Apis.Discovery.Parameter
            {
                Name = "prettyPrint",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = "true",
                Pattern = null,
            });
            RequestParameters.Add("quotaUser", new Google.Apis.Discovery.Parameter
            {
                Name = "quotaUser",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("uploadType", new Google.Apis.Discovery.Parameter
            {
                Name = "uploadType",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
            RequestParameters.Add("upload_protocol", new Google.Apis.Discovery.Parameter
            {
                Name = "upload_protocol",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
        }
    }

    /// <summary>The "accounts" collection of methods.</summary>
    public class AccountsResource
    {
        private const string Resource = "accounts";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public AccountsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
            Products = new ProductsResource(service);
        }

        /// <summary>Gets the Products resource.</summary>
        public virtual ProductsResource Products { get; }

        /// <summary>The "products" collection of methods.</summary>
        public class ProductsResource
        {
            private const string Resource = "products";

            /// <summary>The service which this resource belongs to.</summary>
            private readonly Google.Apis.Services.IClientService service;

            /// <summary>Constructs a new resource.</summary>
            public ProductsResource(Google.Apis.Services.IClientService service)
            {
                this.service = service;
            }

            /// <summary>Deletes the product from a Manufacturer Center account.</summary>
            /// <param name="parent">
            /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
            /// account.
            /// </param>
            /// <param name="name">
            /// Name in the format `{target_country}:{content_language}:{product_id}`. `target_country` - The target
            /// country of the product as a CLDR territory code (for example, US). `content_language` - The content
            /// language of the product as a two-letter ISO 639-1 language code (for example, en). `product_id` - The ID
            /// of the product. For more information, see https://support.google.com/manufacturers/answer/6124116#id.
            /// </param>
            public virtual DeleteRequest Delete(string parent, string name)
            {
                return new DeleteRequest(service, parent, name);
            }

            /// <summary>Deletes the product from a Manufacturer Center account.</summary>
            public class DeleteRequest : ManufacturerCenterBaseServiceRequest<Google.Apis.ManufacturerCenter.v1.Data.Empty>
            {
                /// <summary>Constructs a new Delete request.</summary>
                public DeleteRequest(Google.Apis.Services.IClientService service, string parent, string name) : base(service)
                {
                    Parent = parent;
                    Name = name;
                    InitParameters();
                }

                /// <summary>
                /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
                /// account.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("parent", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string Parent { get; private set; }

                /// <summary>
                /// Name in the format `{target_country}:{content_language}:{product_id}`. `target_country` - The target
                /// country of the product as a CLDR territory code (for example, US). `content_language` - The content
                /// language of the product as a two-letter ISO 639-1 language code (for example, en). `product_id` -
                /// The ID of the product. For more information, see
                /// https://support.google.com/manufacturers/answer/6124116#id.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("name", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string Name { get; private set; }

                /// <summary>Gets the method name.</summary>
                public override string MethodName => "delete";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "DELETE";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "v1/{+parent}/products/{+name}";

                /// <summary>Initializes Delete parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();
                    RequestParameters.Add("parent", new Google.Apis.Discovery.Parameter
                    {
                        Name = "parent",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = @"^accounts/[^/]+$",
                    });
                    RequestParameters.Add("name", new Google.Apis.Discovery.Parameter
                    {
                        Name = "name",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = @"^[^/]+$",
                    });
                }
            }

            /// <summary>
            /// Gets the product from a Manufacturer Center account, including product issues. A recently updated
            /// product takes around 15 minutes to process. Changes are only visible after it has been processed. While
            /// some issues may be available once the product has been processed, other issues may take days to appear.
            /// </summary>
            /// <param name="parent">
            /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
            /// account.
            /// </param>
            /// <param name="name">
            /// Name in the format `{target_country}:{content_language}:{product_id}`. `target_country` - The target
            /// country of the product as a CLDR territory code (for example, US). `content_language` - The content
            /// language of the product as a two-letter ISO 639-1 language code (for example, en). `product_id` - The ID
            /// of the product. For more information, see https://support.google.com/manufacturers/answer/6124116#id.
            /// </param>
            public virtual GetRequest Get(string parent, string name)
            {
                return new GetRequest(service, parent, name);
            }

            /// <summary>
            /// Gets the product from a Manufacturer Center account, including product issues. A recently updated
            /// product takes around 15 minutes to process. Changes are only visible after it has been processed. While
            /// some issues may be available once the product has been processed, other issues may take days to appear.
            /// </summary>
            public class GetRequest : ManufacturerCenterBaseServiceRequest<Google.Apis.ManufacturerCenter.v1.Data.Product>
            {
                /// <summary>Constructs a new Get request.</summary>
                public GetRequest(Google.Apis.Services.IClientService service, string parent, string name) : base(service)
                {
                    Parent = parent;
                    Name = name;
                    InitParameters();
                }

                /// <summary>
                /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
                /// account.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("parent", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string Parent { get; private set; }

                /// <summary>
                /// Name in the format `{target_country}:{content_language}:{product_id}`. `target_country` - The target
                /// country of the product as a CLDR territory code (for example, US). `content_language` - The content
                /// language of the product as a two-letter ISO 639-1 language code (for example, en). `product_id` -
                /// The ID of the product. For more information, see
                /// https://support.google.com/manufacturers/answer/6124116#id.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("name", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string Name { get; private set; }

                /// <summary>
                /// The information to be included in the response. Only sections listed here will be returned.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("include", Google.Apis.Util.RequestParameterType.Query)]
                public virtual System.Nullable<IncludeEnum> Include { get; set; }

                /// <summary>
                /// The information to be included in the response. Only sections listed here will be returned.
                /// </summary>
                public enum IncludeEnum
                {
                    /// <summary>Unknown, never used.</summary>
                    [Google.Apis.Util.StringValueAttribute("UNKNOWN")]
                    UNKNOWN = 0,

                    /// <summary>Include the attributes of the product.</summary>
                    [Google.Apis.Util.StringValueAttribute("ATTRIBUTES")]
                    ATTRIBUTES = 1,

                    /// <summary>Include the issues of the product.</summary>
                    [Google.Apis.Util.StringValueAttribute("ISSUES")]
                    ISSUES = 2,

                    /// <summary>Include the destination statuses of the product.</summary>
                    [Google.Apis.Util.StringValueAttribute("DESTINATION_STATUSES")]
                    DESTINATIONSTATUSES = 3,
                }

                /// <summary>Gets the method name.</summary>
                public override string MethodName => "get";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "GET";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "v1/{+parent}/products/{+name}";

                /// <summary>Initializes Get parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();
                    RequestParameters.Add("parent", new Google.Apis.Discovery.Parameter
                    {
                        Name = "parent",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = @"^accounts/[^/]+$",
                    });
                    RequestParameters.Add("name", new Google.Apis.Discovery.Parameter
                    {
                        Name = "name",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = @"^[^/]+$",
                    });
                    RequestParameters.Add("include", new Google.Apis.Discovery.Parameter
                    {
                        Name = "include",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }
            }

            /// <summary>Lists all the products in a Manufacturer Center account.</summary>
            /// <param name="parent">
            /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
            /// account.
            /// </param>
            public virtual ListRequest List(string parent)
            {
                return new ListRequest(service, parent);
            }

            /// <summary>Lists all the products in a Manufacturer Center account.</summary>
            public class ListRequest : ManufacturerCenterBaseServiceRequest<Google.Apis.ManufacturerCenter.v1.Data.ListProductsResponse>
            {
                /// <summary>Constructs a new List request.</summary>
                public ListRequest(Google.Apis.Services.IClientService service, string parent) : base(service)
                {
                    Parent = parent;
                    InitParameters();
                }

                /// <summary>
                /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
                /// account.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("parent", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string Parent { get; private set; }

                /// <summary>
                /// The information to be included in the response. Only sections listed here will be returned.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("include", Google.Apis.Util.RequestParameterType.Query)]
                public virtual System.Nullable<IncludeEnum> Include { get; set; }

                /// <summary>
                /// The information to be included in the response. Only sections listed here will be returned.
                /// </summary>
                public enum IncludeEnum
                {
                    /// <summary>Unknown, never used.</summary>
                    [Google.Apis.Util.StringValueAttribute("UNKNOWN")]
                    UNKNOWN = 0,

                    /// <summary>Include the attributes of the product.</summary>
                    [Google.Apis.Util.StringValueAttribute("ATTRIBUTES")]
                    ATTRIBUTES = 1,

                    /// <summary>Include the issues of the product.</summary>
                    [Google.Apis.Util.StringValueAttribute("ISSUES")]
                    ISSUES = 2,

                    /// <summary>Include the destination statuses of the product.</summary>
                    [Google.Apis.Util.StringValueAttribute("DESTINATION_STATUSES")]
                    DESTINATIONSTATUSES = 3,
                }

                /// <summary>Maximum number of product statuses to return in the response, used for paging.</summary>
                [Google.Apis.Util.RequestParameterAttribute("pageSize", Google.Apis.Util.RequestParameterType.Query)]
                public virtual System.Nullable<int> PageSize { get; set; }

                /// <summary>The token returned by the previous request.</summary>
                [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string PageToken { get; set; }

                /// <summary>Gets the method name.</summary>
                public override string MethodName => "list";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "GET";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "v1/{+parent}/products";

                /// <summary>Initializes List parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();
                    RequestParameters.Add("parent", new Google.Apis.Discovery.Parameter
                    {
                        Name = "parent",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = @"^accounts/[^/]+$",
                    });
                    RequestParameters.Add("include", new Google.Apis.Discovery.Parameter
                    {
                        Name = "include",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("pageSize", new Google.Apis.Discovery.Parameter
                    {
                        Name = "pageSize",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("pageToken", new Google.Apis.Discovery.Parameter
                    {
                        Name = "pageToken",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }
            }

            /// <summary>
            /// Inserts or updates the attributes of the product in a Manufacturer Center account. Creates a product
            /// with the provided attributes. If the product already exists, then all attributes are replaced with the
            /// new ones. The checks at upload time are minimal. All required attributes need to be present for a
            /// product to be valid. Issues may show up later after the API has accepted a new upload for a product and
            /// it is possible to overwrite an existing valid product with an invalid product. To detect this, you
            /// should retrieve the product and check it for issues once the new version is available. Uploaded
            /// attributes first need to be processed before they can be retrieved. Until then, new products will be
            /// unavailable, and retrieval of previously uploaded products will return the original state of the
            /// product.
            /// </summary>
            /// <param name="body">The body of the request.</param>
            /// <param name="parent">
            /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
            /// account.
            /// </param>
            /// <param name="name">
            /// Name in the format `{target_country}:{content_language}:{product_id}`. `target_country` - The target
            /// country of the product as a CLDR territory code (for example, US). `content_language` - The content
            /// language of the product as a two-letter ISO 639-1 language code (for example, en). `product_id` - The ID
            /// of the product. For more information, see https://support.google.com/manufacturers/answer/6124116#id.
            /// </param>
            public virtual UpdateRequest Update(Google.Apis.ManufacturerCenter.v1.Data.Attributes body, string parent, string name)
            {
                return new UpdateRequest(service, body, parent, name);
            }

            /// <summary>
            /// Inserts or updates the attributes of the product in a Manufacturer Center account. Creates a product
            /// with the provided attributes. If the product already exists, then all attributes are replaced with the
            /// new ones. The checks at upload time are minimal. All required attributes need to be present for a
            /// product to be valid. Issues may show up later after the API has accepted a new upload for a product and
            /// it is possible to overwrite an existing valid product with an invalid product. To detect this, you
            /// should retrieve the product and check it for issues once the new version is available. Uploaded
            /// attributes first need to be processed before they can be retrieved. Until then, new products will be
            /// unavailable, and retrieval of previously uploaded products will return the original state of the
            /// product.
            /// </summary>
            public class UpdateRequest : ManufacturerCenterBaseServiceRequest<Google.Apis.ManufacturerCenter.v1.Data.Empty>
            {
                /// <summary>Constructs a new Update request.</summary>
                public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.ManufacturerCenter.v1.Data.Attributes body, string parent, string name) : base(service)
                {
                    Parent = parent;
                    Name = name;
                    Body = body;
                    InitParameters();
                }

                /// <summary>
                /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center
                /// account.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("parent", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string Parent { get; private set; }

                /// <summary>
                /// Name in the format `{target_country}:{content_language}:{product_id}`. `target_country` - The target
                /// country of the product as a CLDR territory code (for example, US). `content_language` - The content
                /// language of the product as a two-letter ISO 639-1 language code (for example, en). `product_id` -
                /// The ID of the product. For more information, see
                /// https://support.google.com/manufacturers/answer/6124116#id.
                /// </summary>
                [Google.Apis.Util.RequestParameterAttribute("name", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string Name { get; private set; }

                /// <summary>Gets or sets the body of this request.</summary>
                Google.Apis.ManufacturerCenter.v1.Data.Attributes Body { get; set; }

                /// <summary>Returns the body of the request.</summary>
                protected override object GetBody() => Body;

                /// <summary>Gets the method name.</summary>
                public override string MethodName => "update";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "PUT";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "v1/{+parent}/products/{+name}";

                /// <summary>Initializes Update parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();
                    RequestParameters.Add("parent", new Google.Apis.Discovery.Parameter
                    {
                        Name = "parent",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = @"^accounts/[^/]+$",
                    });
                    RequestParameters.Add("name", new Google.Apis.Discovery.Parameter
                    {
                        Name = "name",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = @"^[^/]+$",
                    });
                }
            }
        }
    }
}
namespace Google.Apis.ManufacturerCenter.v1.Data
{
    /// <summary>
    /// Attributes of the product. For more information, see https://support.google.com/manufacturers/answer/6124116.
    /// </summary>
    public class Attributes : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The additional images of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#addlimage.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("additionalImageLink")]
        public virtual System.Collections.Generic.IList<Image> AdditionalImageLink { get; set; }

        /// <summary>
        /// The target age group of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#agegroup.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("ageGroup")]
        public virtual string AgeGroup { get; set; }

        /// <summary>
        /// The brand name of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#brand.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("brand")]
        public virtual string Brand { get; set; }

        /// <summary>
        /// The capacity of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#capacity.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("capacity")]
        public virtual Capacity Capacity { get; set; }

        /// <summary>
        /// The color of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#color.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("color")]
        public virtual string Color { get; set; }

        /// <summary>
        /// The count of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#count.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("count")]
        public virtual Count Count { get; set; }

        /// <summary>
        /// The description of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#description.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// The disclosure date of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#disclosure.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("disclosureDate")]
        public virtual string DisclosureDate { get; set; }

        /// <summary>A list of excluded destinations.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("excludedDestination")]
        public virtual System.Collections.Generic.IList<string> ExcludedDestination { get; set; }

        /// <summary>
        /// The rich format description of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#featuredesc.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("featureDescription")]
        public virtual System.Collections.Generic.IList<FeatureDescription> FeatureDescription { get; set; }

        /// <summary>
        /// The flavor of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#flavor.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("flavor")]
        public virtual string Flavor { get; set; }

        /// <summary>
        /// The format of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#format.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("format")]
        public virtual string Format { get; set; }

        /// <summary>
        /// The target gender of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#gender.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("gender")]
        public virtual string Gender { get; set; }

        /// <summary>
        /// The Global Trade Item Number (GTIN) of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#gtin.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("gtin")]
        public virtual System.Collections.Generic.IList<string> Gtin { get; set; }

        /// <summary>
        /// The image of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#image.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("imageLink")]
        public virtual Image ImageLink { get; set; }

        /// <summary>A list of included destinations.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("includedDestination")]
        public virtual System.Collections.Generic.IList<string> IncludedDestination { get; set; }

        /// <summary>
        /// The item group id of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#itemgroupid.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("itemGroupId")]
        public virtual string ItemGroupId { get; set; }

        /// <summary>
        /// The material of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#material.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("material")]
        public virtual string Material { get; set; }

        /// <summary>
        /// The Manufacturer Part Number (MPN) of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#mpn.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("mpn")]
        public virtual string Mpn { get; set; }

        /// <summary>
        /// The pattern of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#pattern.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("pattern")]
        public virtual string Pattern { get; set; }

        /// <summary>
        /// The details of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#productdetail.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("productDetail")]
        public virtual System.Collections.Generic.IList<ProductDetail> ProductDetail { get; set; }

        /// <summary>
        /// The product highlights. For more information, see https://support.google.com/manufacturers/answer/10066942
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("productHighlight")]
        public virtual System.Collections.Generic.IList<string> ProductHighlight { get; set; }

        /// <summary>
        /// The name of the group of products related to the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#productline.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("productLine")]
        public virtual string ProductLine { get; set; }

        /// <summary>
        /// The canonical name of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#productname.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("productName")]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// The URL of the detail page of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#productpage.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("productPageUrl")]
        public virtual string ProductPageUrl { get; set; }

        /// <summary>
        /// The type or category of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#producttype.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("productType")]
        public virtual System.Collections.Generic.IList<string> ProductType { get; set; }

        /// <summary>
        /// The release date of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#release.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("releaseDate")]
        public virtual string ReleaseDate { get; set; }

        /// <summary>
        /// Rich product content. For more information, see https://support.google.com/manufacturers/answer/9389865
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("richProductContent")]
        public virtual System.Collections.Generic.IList<string> RichProductContent { get; set; }

        /// <summary>
        /// The scent of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#scent.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("scent")]
        public virtual string Scent { get; set; }

        /// <summary>
        /// The size of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#size.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("size")]
        public virtual string Size { get; set; }

        /// <summary>
        /// The size system of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#sizesystem.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("sizeSystem")]
        public virtual string SizeSystem { get; set; }

        /// <summary>
        /// The size type of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#sizetype.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("sizeType")]
        public virtual System.Collections.Generic.IList<string> SizeType { get; set; }

        /// <summary>
        /// The suggested retail price (MSRP) of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#price.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("suggestedRetailPrice")]
        public virtual Price SuggestedRetailPrice { get; set; }

        /// <summary>The target client id. Should only be used in the accounts of the data partners.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("targetClientId")]
        public virtual string TargetClientId { get; set; }

        /// <summary>
        /// The theme of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#theme.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("theme")]
        public virtual string Theme { get; set; }

        /// <summary>
        /// The title of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#title.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// The videos of the product. For more information, see
        /// https://support.google.com/manufacturers/answer/6124116#video.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("videoLink")]
        public virtual System.Collections.Generic.IList<string> VideoLink { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>
    /// The capacity of a product. For more information, see
    /// https://support.google.com/manufacturers/answer/6124116#capacity.
    /// </summary>
    public class Capacity : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The unit of the capacity, i.e., MB, GB, or TB.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("unit")]
        public virtual string Unit { get; set; }

        /// <summary>The numeric value of the capacity.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("value")]
        public virtual System.Nullable<long> Value { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>
    /// The number of products in a single package. For more information, see
    /// https://support.google.com/manufacturers/answer/6124116#count.
    /// </summary>
    public class Count : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The unit in which these products are counted.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("unit")]
        public virtual string Unit { get; set; }

        /// <summary>The numeric value of the number of products in a package.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("value")]
        public virtual System.Nullable<long> Value { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>The destination status.</summary>
    public class DestinationStatus : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The name of the destination.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("destination")]
        public virtual string Destination { get; set; }

        /// <summary>The status of the destination.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("status")]
        public virtual string Status { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>
    /// A generic empty message that you can re-use to avoid defining duplicated empty messages in your APIs. A typical
    /// example is to use it as the request or the response type of an API method. For instance: service Foo { rpc
    /// Bar(google.protobuf.Empty) returns (google.protobuf.Empty); } The JSON representation for `Empty` is empty JSON
    /// object `{}`.
    /// </summary>
    public class Empty : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>
    /// A feature description of the product. For more information, see
    /// https://support.google.com/manufacturers/answer/6124116#featuredesc.
    /// </summary>
    public class FeatureDescription : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>A short description of the feature.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("headline")]
        public virtual string Headline { get; set; }

        /// <summary>An optional image describing the feature.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("image")]
        public virtual Image Image { get; set; }

        /// <summary>A detailed description of the feature.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("text")]
        public virtual string Text { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>An image.</summary>
    public class Image : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The URL of the image. For crawled images, this is the provided URL. For uploaded images, this is a serving
        /// URL from Google if the image has been processed successfully.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("imageUrl")]
        public virtual string ImageUrl { get; set; }

        /// <summary>The status of the image. @OutputOnly</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("status")]
        public virtual string Status { get; set; }

        /// <summary>The type of the image, i.e., crawled or uploaded. @OutputOnly</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>Product issue.</summary>
    public class Issue : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// If present, the attribute that triggered the issue. For more information about attributes, see
        /// https://support.google.com/manufacturers/answer/6124116.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("attribute")]
        public virtual string Attribute { get; set; }

        /// <summary>Longer description of the issue focused on how to resolve it.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>The destination this issue applies to.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("destination")]
        public virtual string Destination { get; set; }

        /// <summary>What needs to happen to resolve the issue.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resolution")]
        public virtual string Resolution { get; set; }

        /// <summary>The severity of the issue.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("severity")]
        public virtual string Severity { get; set; }

        /// <summary>The timestamp when this issue appeared.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timestamp")]
        public virtual object Timestamp { get; set; }

        /// <summary>Short title describing the nature of the issue.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// The server-generated type of the issue, for example, “INCORRECT_TEXT_FORMATTING”, “IMAGE_NOT_SERVEABLE”,
        /// etc.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ListProductsResponse : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The token for the retrieval of the next page of product statuses.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; }

        /// <summary>List of the products.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("products")]
        public virtual System.Collections.Generic.IList<Product> Products { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>A price.</summary>
    public class Price : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The numeric value of the price.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("amount")]
        public virtual string Amount { get; set; }

        /// <summary>The currency in which the price is denoted.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("currency")]
        public virtual string Currency { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>Product data.</summary>
    public class Product : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// Attributes of the product uploaded to the Manufacturer Center. Manually edited attributes are taken into
        /// account.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("attributes")]
        public virtual Attributes Attributes { get; set; }

        /// <summary>
        /// The content language of the product as a two-letter ISO 639-1 language code (for example, en).
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("contentLanguage")]
        public virtual string ContentLanguage { get; set; }

        /// <summary>The status of the destinations.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("destinationStatuses")]
        public virtual System.Collections.Generic.IList<DestinationStatus> DestinationStatuses { get; set; }

        /// <summary>A server-generated list of issues associated with the product.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("issues")]
        public virtual System.Collections.Generic.IList<Issue> Issues { get; set; }

        /// <summary>
        /// Name in the format `{target_country}:{content_language}:{product_id}`. `target_country` - The target country
        /// of the product as a CLDR territory code (for example, US). `content_language` - The content language of the
        /// product as a two-letter ISO 639-1 language code (for example, en). `product_id` - The ID of the product. For
        /// more information, see https://support.google.com/manufacturers/answer/6124116#id.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Parent ID in the format `accounts/{account_id}`. `account_id` - The ID of the Manufacturer Center account.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("parent")]
        public virtual string Parent { get; set; }

        /// <summary>
        /// The ID of the product. For more information, see https://support.google.com/manufacturers/answer/6124116#id.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("productId")]
        public virtual string ProductId { get; set; }

        /// <summary>The target country of the product as a CLDR territory code (for example, US).</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("targetCountry")]
        public virtual string TargetCountry { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    /// <summary>
    /// A product detail of the product. For more information, see
    /// https://support.google.com/manufacturers/answer/6124116#productdetail.
    /// </summary>
    public class ProductDetail : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The name of the attribute.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("attributeName")]
        public virtual string AttributeName { get; set; }

        /// <summary>The value of the attribute.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("attributeValue")]
        public virtual string AttributeValue { get; set; }

        /// <summary>A short section name that can be reused between multiple product details.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("sectionName")]
        public virtual string SectionName { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }
}
