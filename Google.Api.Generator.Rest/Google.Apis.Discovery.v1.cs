// Copyright 2024 Google LLC
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

namespace Google.Apis.Discovery.v1
{
    /// <summary>The Discovery Service.</summary>
    public class DiscoveryService : Google.Apis.Services.BaseClientService
    {
        /// <summary>The API version.</summary>
        public const string Version = "v1";

        /// <summary>The discovery version used to generate this service.</summary>
        public static Google.Apis.Discovery.DiscoveryVersion DiscoveryVersionUsed = Google.Apis.Discovery.DiscoveryVersion.Version_1_0;

        /// <summary>Constructs a new service.</summary>
        public DiscoveryService() : this(new Google.Apis.Services.BaseClientService.Initializer())
        {
        }

        /// <summary>Constructs a new service.</summary>
        /// <param name="initializer">The service initializer.</param>
        public DiscoveryService(Google.Apis.Services.BaseClientService.Initializer initializer) : base(initializer)
        {
            Apis = new ApisResource(this);
            BaseUri = GetEffectiveUri(BaseUriOverride, "https://www.googleapis.com/discovery/v1/");
            BatchUri = GetEffectiveUri(null, "https://www.googleapis.com/batch/discovery/v1");
        }

        /// <summary>Gets the service supported features.</summary>
        public override System.Collections.Generic.IList<string> Features => new string[0];

        /// <summary>Gets the service name.</summary>
        public override string Name => "discovery";

        /// <summary>Gets the service base URI.</summary>
        public override string BaseUri { get; }

        /// <summary>Gets the service base path.</summary>
        public override string BasePath => "discovery/v1/";

        /// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>
        public override string BatchUri { get; }

        /// <summary>Gets the batch base path; <c>null</c> if unspecified.</summary>
        public override string BatchPath => "batch/discovery/v1";

        /// <summary>Gets the Apis resource.</summary>
        public virtual ApisResource Apis { get; }
    }

    /// <summary>A base abstract class for Discovery requests.</summary>
    public abstract class DiscoveryBaseServiceRequest<TResponse> : Google.Apis.Requests.ClientServiceRequest<TResponse>
    {
        /// <summary>Constructs a new DiscoveryBaseServiceRequest instance.</summary>
        protected DiscoveryBaseServiceRequest(Google.Apis.Services.IClientService service) : base(service)
        {
        }

        /// <summary>Data format for the response.</summary>
        [Google.Apis.Util.RequestParameterAttribute("alt", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<AltEnum> Alt { get; set; }

        /// <summary>Data format for the response.</summary>
        public enum AltEnum
        {
            /// <summary>Responses with Content-Type of application/json</summary>
            [Google.Apis.Util.StringValueAttribute("json")]
            Json = 0,
        }

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
        /// An opaque string that represents a user for quota purposes. Must not exceed 40 characters.
        /// </summary>
        [Google.Apis.Util.RequestParameterAttribute("quotaUser", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string QuotaUser { get; set; }

        /// <summary>Deprecated. Please use quotaUser instead.</summary>
        [Google.Apis.Util.RequestParameterAttribute("userIp", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string UserIp { get; set; }

        /// <summary>Initializes Discovery parameter list.</summary>
        protected override void InitParameters()
        {
            base.InitParameters();
            RequestParameters.Add("alt", new Google.Apis.Discovery.Parameter
            {
                Name = "alt",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = "json",
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
            RequestParameters.Add("userIp", new Google.Apis.Discovery.Parameter
            {
                Name = "userIp",
                IsRequired = false,
                ParameterType = "query",
                DefaultValue = null,
                Pattern = null,
            });
        }
    }

    /// <summary>The "apis" collection of methods.</summary>
    public class ApisResource
    {
        private const string Resource = "apis";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public ApisResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Retrieve the description of a particular version of an api.</summary>
        /// <param name="api">The name of the API.</param>
        /// <param name="version">The version of the API.</param>
        public virtual GetRestRequest GetRest(string api, string version)
        {
            return new GetRestRequest(this.service, api, version);
        }

        /// <summary>Retrieve the description of a particular version of an api.</summary>
        public class GetRestRequest : DiscoveryBaseServiceRequest<Google.Apis.Discovery.v1.Data.RestDescription>
        {
            /// <summary>Constructs a new GetRest request.</summary>
            public GetRestRequest(Google.Apis.Services.IClientService service, string api, string version) : base(service)
            {
                Api = api;
                Version = version;
                InitParameters();
            }

            /// <summary>The name of the API.</summary>
            [Google.Apis.Util.RequestParameterAttribute("api", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Api { get; private set; }

            /// <summary>The version of the API.</summary>
            [Google.Apis.Util.RequestParameterAttribute("version", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Version { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "getRest";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "apis/{api}/{version}/rest";

            /// <summary>Initializes GetRest parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("api", new Google.Apis.Discovery.Parameter
                {
                    Name = "api",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("version", new Google.Apis.Discovery.Parameter
                {
                    Name = "version",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Retrieve the list of APIs supported at this endpoint.</summary>
        public virtual ListRequest List()
        {
            return new ListRequest(this.service);
        }

        /// <summary>Retrieve the list of APIs supported at this endpoint.</summary>
        public class ListRequest : DiscoveryBaseServiceRequest<Google.Apis.Discovery.v1.Data.DirectoryList>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service) : base(service)
            {
                InitParameters();
            }

            /// <summary>Only include APIs with the given name.</summary>
            [Google.Apis.Util.RequestParameterAttribute("name", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Name { get; set; }

            /// <summary>Return only the preferred version of an API.</summary>
            [Google.Apis.Util.RequestParameterAttribute("preferred", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> Preferred { get; set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "apis";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("name", new Google.Apis.Discovery.Parameter
                {
                    Name = "name",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("preferred", new Google.Apis.Discovery.Parameter
                {
                    Name = "preferred",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "false",
                    Pattern = null,
                });
            }
        }
    }
}
namespace Google.Apis.Discovery.v1.Data
{
    public class DirectoryList : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Indicate the version of the Discovery API used to generate this doc.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("discoveryVersion")]
        public virtual string DiscoveryVersion { get; set; }

        /// <summary>The individual directory entries. One entry per api/version pair.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<ItemsData> Items { get; set; }

        /// <summary>The kind for this response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }

        /// <summary>The individual directory entries. One entry per api/version pair.</summary>
        public class ItemsData
        {
            /// <summary>The description of this API.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("description")]
            public virtual string Description { get; set; }

            /// <summary>A link to the discovery document.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("discoveryLink")]
            public virtual string DiscoveryLink { get; set; }

            /// <summary>The URL for the discovery REST document.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("discoveryRestUrl")]
            public virtual string DiscoveryRestUrl { get; set; }

            /// <summary>A link to human readable documentation for the API.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("documentationLink")]
            public virtual string DocumentationLink { get; set; }

            /// <summary>Links to 16x16 and 32x32 icons representing the API.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("icons")]
            public virtual IconsData Icons { get; set; }

            /// <summary>The id of this API.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("id")]
            public virtual string Id { get; set; }

            /// <summary>The kind for this response.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("kind")]
            public virtual string Kind { get; set; }

            /// <summary>Labels for the status of this API, such as labs or deprecated.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("labels")]
            public virtual System.Collections.Generic.IList<string> Labels { get; set; }

            /// <summary>The name of the API.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("name")]
            public virtual string Name { get; set; }

            /// <summary>True if this version is the preferred version to use.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("preferred")]
            public virtual System.Nullable<bool> Preferred { get; set; }

            /// <summary>The title of this API.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("title")]
            public virtual string Title { get; set; }

            /// <summary>The version of the API.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("version")]
            public virtual string Version { get; set; }

            /// <summary>Links to 16x16 and 32x32 icons representing the API.</summary>
            public class IconsData
            {
                /// <summary>The URL of the 16x16 icon.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("x16")]
                public virtual string X16 { get; set; }

                /// <summary>The URL of the 32x32 icon.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("x32")]
                public virtual string X32 { get; set; }
            }
        }
    }

    public class JsonSchema : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>A reference to another schema. The value of this property is the "id" of another schema.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("$ref")]
        public virtual string Ref__ { get; set; }

        /// <summary>
        /// If this is a schema for an object, this property is the schema for any additional properties with dynamic
        /// keys on this object.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("additionalProperties")]
        public virtual JsonSchema AdditionalProperties { get; set; }

        /// <summary>Additional information about this property.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("annotations")]
        public virtual AnnotationsData Annotations { get; set; }

        /// <summary>The default value of this property (if one exists).</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("default")]
        public virtual string Default__ { get; set; }

        /// <summary>Whether the parameter is deprecated.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("deprecated")]
        public virtual System.Nullable<bool> Deprecated { get; set; }

        /// <summary>A description of this object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>Values this parameter may take (if it is an enum).</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("enum")]
        public virtual System.Collections.Generic.IList<string> Enum__ { get; set; }

        /// <summary>
        /// The deprecation status for the enums. Each position maps to the corresponding value in the "enum" array.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("enumDeprecated")]
        public virtual System.Collections.Generic.IList<System.Nullable<bool>> EnumDeprecated { get; set; }

        /// <summary>
        /// The descriptions for the enums. Each position maps to the corresponding value in the "enum" array.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("enumDescriptions")]
        public virtual System.Collections.Generic.IList<string> EnumDescriptions { get; set; }

        /// <summary>
        /// An additional regular expression or key that helps constrain the value. For more details see:
        /// http://tools.ietf.org/html/draft-zyp-json-schema-03#section-5.23
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("format")]
        public virtual string Format { get; set; }

        /// <summary>Unique identifier for this schema.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>
        /// If this is a schema for an array, this property is the schema for each element in the array.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual JsonSchema Items { get; set; }

        /// <summary>Whether this parameter goes in the query or the path for REST requests.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("location")]
        public virtual string Location { get; set; }

        /// <summary>The maximum value of this parameter.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("maximum")]
        public virtual string Maximum { get; set; }

        /// <summary>The minimum value of this parameter.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("minimum")]
        public virtual string Minimum { get; set; }

        /// <summary>
        /// The regular expression this parameter must conform to. Uses Java 6 regex format:
        /// http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("pattern")]
        public virtual string Pattern { get; set; }

        /// <summary>If this is a schema for an object, list the schema for each property of this object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("properties")]
        public virtual System.Collections.Generic.IDictionary<string, JsonSchema> Properties { get; set; }

        /// <summary>
        /// The value is read-only, generated by the service. The value cannot be modified by the client. If the value
        /// is included in a POST, PUT, or PATCH request, it is ignored by the service.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("readOnly")]
        public virtual System.Nullable<bool> ReadOnly__ { get; set; }

        /// <summary>Whether this parameter may appear multiple times.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("repeated")]
        public virtual System.Nullable<bool> Repeated { get; set; }

        /// <summary>Whether the parameter is required.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("required")]
        public virtual System.Nullable<bool> Required { get; set; }

        /// <summary>
        /// The value type for this schema. A list of values can be found here:
        /// http://tools.ietf.org/html/draft-zyp-json-schema-03#section-5.1
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>
        /// In a variant data type, the value of one property is used to determine how to interpret the entire entity.
        /// Its value must exist in a map of descriminant values to schema names.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("variant")]
        public virtual VariantData Variant { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }

        /// <summary>Additional information about this property.</summary>
        public class AnnotationsData
        {
            /// <summary>A list of methods for which this property is required on requests.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("required")]
            public virtual System.Collections.Generic.IList<string> Required { get; set; }
        }

        /// <summary>
        /// In a variant data type, the value of one property is used to determine how to interpret the entire entity.
        /// Its value must exist in a map of descriminant values to schema names.
        /// </summary>
        public class VariantData
        {
            /// <summary>The name of the type discriminant property.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("discriminant")]
            public virtual string Discriminant { get; set; }

            /// <summary>The map of discriminant value to schema to use for parsing..</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("map")]
            public virtual System.Collections.Generic.IList<MapData> Map { get; set; }

            /// <summary>The map of discriminant value to schema to use for parsing..</summary>
            public class MapData
            {
                [Newtonsoft.Json.JsonPropertyAttribute("$ref")]
                public virtual string Ref__ { get; set; }

                [Newtonsoft.Json.JsonPropertyAttribute("type_value")]
                public virtual string TypeValue { get; set; }
            }
        }
    }

    public class RestDescription : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Authentication information.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("auth")]
        public virtual AuthData Auth { get; set; }

        /// <summary>[DEPRECATED] The base path for REST requests.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("basePath")]
        public virtual string BasePath { get; set; }

        /// <summary>[DEPRECATED] The base URL for REST requests.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("baseUrl")]
        public virtual string BaseUrl { get; set; }

        /// <summary>The path for REST batch requests.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("batchPath")]
        public virtual string BatchPath { get; set; }

        /// <summary>
        /// Indicates how the API name should be capitalized and split into various parts. Useful for generating pretty
        /// class names.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("canonicalName")]
        public virtual string CanonicalName { get; set; }

        /// <summary>The description of this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>Indicate the version of the Discovery API used to generate this doc.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("discoveryVersion")]
        public virtual string DiscoveryVersion { get; set; }

        /// <summary>A link to human readable documentation for the API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("documentationLink")]
        public virtual string DocumentationLink { get; set; }

        /// <summary>
        /// A list of location-based endpoint objects for this API. Each object contains the endpoint URL, location,
        /// description and deprecation status.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("endpoints")]
        public virtual System.Collections.Generic.IList<EndpointsData> Endpoints { get; set; }

        /// <summary>The ETag for this response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>Enable exponential backoff for suitable methods in the generated clients.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("exponentialBackoffDefault")]
        public virtual System.Nullable<bool> ExponentialBackoffDefault { get; set; }

        /// <summary>A list of supported features for this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("features")]
        public virtual System.Collections.Generic.IList<string> Features { get; set; }

        /// <summary>Links to 16x16 and 32x32 icons representing the API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("icons")]
        public virtual IconsData Icons { get; set; }

        /// <summary>The ID of this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>The kind for this response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>Labels for the status of this API, such as labs or deprecated.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("labels")]
        public virtual System.Collections.Generic.IList<string> Labels { get; set; }

        /// <summary>API-level methods for this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("methods")]
        public virtual System.Collections.Generic.IDictionary<string, RestMethod> Methods { get; set; }

        /// <summary>The name of this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// The domain of the owner of this API. Together with the ownerName and a packagePath values, this can be used
        /// to generate a library for this API which would have a unique fully qualified name.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("ownerDomain")]
        public virtual string OwnerDomain { get; set; }

        /// <summary>The name of the owner of this API. See ownerDomain.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("ownerName")]
        public virtual string OwnerName { get; set; }

        /// <summary>The package of the owner of this API. See ownerDomain.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("packagePath")]
        public virtual string PackagePath { get; set; }

        /// <summary>Common parameters that apply across all apis.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("parameters")]
        public virtual System.Collections.Generic.IDictionary<string, JsonSchema> Parameters { get; set; }

        /// <summary>The protocol described by this document.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("protocol")]
        public virtual string Protocol { get; set; }

        /// <summary>The resources in this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resources")]
        public virtual System.Collections.Generic.IDictionary<string, RestResource> Resources { get; set; }

        /// <summary>The version of this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("revision")]
        public virtual string Revision { get; set; }

        /// <summary>The root URL under which all API services live.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("rootUrl")]
        public virtual string RootUrl { get; set; }

        /// <summary>The schemas for this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("schemas")]
        public virtual System.Collections.Generic.IDictionary<string, JsonSchema> Schemas { get; set; }

        /// <summary>The base path for all REST requests.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("servicePath")]
        public virtual string ServicePath { get; set; }

        /// <summary>The title of this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("title")]
        public virtual string Title { get; set; }

        /// <summary>The version of this API.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("version")]
        public virtual string Version { get; set; }

        [Newtonsoft.Json.JsonPropertyAttribute("version_module")]
        public virtual System.Nullable<bool> VersionModule { get; set; }

        /// <summary>Authentication information.</summary>
        public class AuthData
        {
            /// <summary>OAuth 2.0 authentication information.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("oauth2")]
            public virtual Oauth2Data Oauth2 { get; set; }

            /// <summary>OAuth 2.0 authentication information.</summary>
            public class Oauth2Data
            {
                /// <summary>Available OAuth 2.0 scopes.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("scopes")]
                public virtual System.Collections.Generic.IDictionary<string, ScopesDataElement> Scopes { get; set; }

                /// <summary>The scope value.</summary>
                public class ScopesDataElement
                {
                    /// <summary>Description of scope.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("description")]
                    public virtual string Description { get; set; }
                }
            }
        }

        /// <summary>
        /// A list of location-based endpoint objects for this API. Each object contains the endpoint URL, location,
        /// description and deprecation status.
        /// </summary>
        public class EndpointsData
        {
            /// <summary>Whether this endpoint is deprecated</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("deprecated")]
            public virtual System.Nullable<bool> Deprecated { get; set; }

            /// <summary>A string describing the host designated by the URL</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("description")]
            public virtual string Description { get; set; }

            /// <summary>The URL of the endpoint target host</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("endpointUrl")]
            public virtual string EndpointUrl { get; set; }

            /// <summary>The location of the endpoint</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("location")]
            public virtual string Location { get; set; }
        }

        /// <summary>Links to 16x16 and 32x32 icons representing the API.</summary>
        public class IconsData
        {
            /// <summary>The URL of the 16x16 icon.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("x16")]
            public virtual string X16 { get; set; }

            /// <summary>The URL of the 32x32 icon.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("x32")]
            public virtual string X32 { get; set; }
        }
    }

    public class RestMethod : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The API Version of this method, as passed in via the `X-Goog-Api-Version` header or `$apiVersion` query
        /// parameter.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("apiVersion")]
        public virtual string ApiVersion { get; set; }

        /// <summary>Whether this method is deprecated.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("deprecated")]
        public virtual System.Nullable<bool> Deprecated { get; set; }

        /// <summary>Description of this method.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Whether this method requires an ETag to be specified. The ETag is sent as an HTTP If-Match or If-None-Match
        /// header.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etagRequired")]
        public virtual System.Nullable<bool> EtagRequired { get; set; }

        /// <summary>
        /// The URI path of this REST method in (RFC 6570) format without level 2 features ({+var}). Supplementary to
        /// the path property.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("flatPath")]
        public virtual string FlatPath { get; set; }

        /// <summary>HTTP method used by this method.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("httpMethod")]
        public virtual string HttpMethod { get; set; }

        /// <summary>
        /// A unique ID for this method. This property can be used to match methods between different versions of
        /// Discovery.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>Media upload parameters.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("mediaUpload")]
        public virtual MediaUploadData MediaUpload { get; set; }

        /// <summary>
        /// Ordered list of required parameters, serves as a hint to clients on how to structure their method
        /// signatures. The array is ordered such that the "most-significant" parameter appears first.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("parameterOrder")]
        public virtual System.Collections.Generic.IList<string> ParameterOrder { get; set; }

        /// <summary>Details for all parameters in this method.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("parameters")]
        public virtual System.Collections.Generic.IDictionary<string, JsonSchema> Parameters { get; set; }

        /// <summary>
        /// The URI path of this REST method. Should be used in conjunction with the basePath property at the api-level.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("path")]
        public virtual string Path { get; set; }

        /// <summary>The schema for the request.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("request")]
        public virtual RequestData Request { get; set; }

        /// <summary>The schema for the response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("response")]
        public virtual ResponseData Response { get; set; }

        /// <summary>OAuth 2.0 scopes applicable to this method.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("scopes")]
        public virtual System.Collections.Generic.IList<string> Scopes { get; set; }

        /// <summary>Whether this method supports media downloads.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("supportsMediaDownload")]
        public virtual System.Nullable<bool> SupportsMediaDownload { get; set; }

        /// <summary>Whether this method supports media uploads.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("supportsMediaUpload")]
        public virtual System.Nullable<bool> SupportsMediaUpload { get; set; }

        /// <summary>Whether this method supports subscriptions.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("supportsSubscription")]
        public virtual System.Nullable<bool> SupportsSubscription { get; set; }

        /// <summary>
        /// Indicates that downloads from this method should use the download service URL (i.e. "/download"). Only
        /// applies if the method supports media download.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("useMediaDownloadService")]
        public virtual System.Nullable<bool> UseMediaDownloadService { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }

        /// <summary>Media upload parameters.</summary>
        public class MediaUploadData
        {
            /// <summary>MIME Media Ranges for acceptable media uploads to this method.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("accept")]
            public virtual System.Collections.Generic.IList<string> Accept { get; set; }

            /// <summary>Maximum size of a media upload, such as "1MB", "2GB" or "3TB".</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("maxSize")]
            public virtual string MaxSize { get; set; }

            /// <summary>Supported upload protocols.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("protocols")]
            public virtual ProtocolsData Protocols { get; set; }

            /// <summary>Supported upload protocols.</summary>
            public class ProtocolsData
            {
                /// <summary>Supports the Resumable Media Upload protocol.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("resumable")]
                public virtual ResumableData Resumable { get; set; }

                /// <summary>Supports uploading as a single HTTP request.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("simple")]
                public virtual SimpleData Simple { get; set; }

                /// <summary>Supports the Resumable Media Upload protocol.</summary>
                public class ResumableData
                {
                    /// <summary>True if this endpoint supports uploading multipart media.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("multipart")]
                    public virtual System.Nullable<bool> Multipart { get; set; }

                    /// <summary>
                    /// The URI path to be used for upload. Should be used in conjunction with the basePath property at
                    /// the api-level.
                    /// </summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("path")]
                    public virtual string Path { get; set; }
                }

                /// <summary>Supports uploading as a single HTTP request.</summary>
                public class SimpleData
                {
                    /// <summary>True if this endpoint supports upload multipart media.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("multipart")]
                    public virtual System.Nullable<bool> Multipart { get; set; }

                    /// <summary>
                    /// The URI path to be used for upload. Should be used in conjunction with the basePath property at
                    /// the api-level.
                    /// </summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("path")]
                    public virtual string Path { get; set; }
                }
            }
        }

        /// <summary>The schema for the request.</summary>
        public class RequestData
        {
            /// <summary>Schema ID for the request schema.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("$ref")]
            public virtual string Ref__ { get; set; }

            /// <summary>parameter name.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("parameterName")]
            public virtual string ParameterName { get; set; }
        }

        /// <summary>The schema for the response.</summary>
        public class ResponseData
        {
            /// <summary>Schema ID for the response schema.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("$ref")]
            public virtual string Ref__ { get; set; }
        }
    }

    public class RestResource : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Whether this resource is deprecated.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("deprecated")]
        public virtual System.Nullable<bool> Deprecated { get; set; }

        /// <summary>Methods on this resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("methods")]
        public virtual System.Collections.Generic.IDictionary<string, RestMethod> Methods { get; set; }

        /// <summary>Sub-resources on this resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resources")]
        public virtual System.Collections.Generic.IDictionary<string, RestResource> Resources { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }
}
