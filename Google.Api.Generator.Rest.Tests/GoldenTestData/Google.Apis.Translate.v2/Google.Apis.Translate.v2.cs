// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.

// Generated code. DO NOT EDIT!

namespace Google.Apis.Translate.v2
{
    /// <summary>The Translate Service.</summary>
    public class TranslateService : Google.Apis.Services.BaseClientService
    {
        /// <summary>The API version.</summary>
        public const string Version = "v2";

        /// <summary>The discovery version used to generate this service.</summary>
        public static Google.Apis.Discovery.DiscoveryVersion DiscoveryVersionUsed =
            Google.Apis.Discovery.DiscoveryVersion.Version_1_0;

        /// <summary>Constructs a new service.</summary>
        public TranslateService() :
            this(new Google.Apis.Services.BaseClientService.Initializer()) {}

        /// <summary>Constructs a new service.</summary>
        /// <param name="initializer">The service initializer.</param>
        public TranslateService(Google.Apis.Services.BaseClientService.Initializer initializer)
            : base(initializer)
        {
            Detections = new DetectionsResource(this);
            Languages = new LanguagesResource(this);
            Translations = new TranslationsResource(this);
        }

        /// <summary>Gets the service supported features.</summary>
        public override System.Collections.Generic.IList<string> Features => new string[] {"dataWrapper"};

        /// <summary>Gets the service name.</summary>
        public override string Name => "translate";

        /// <summary>Gets the service base URI.</summary>
        public override string BaseUri =>
        #if NETSTANDARD1_3 || NETSTANDARD2_0 || NET45
            BaseUriOverride ?? "https://translation.googleapis.com/language/translate/";
        #else
            "https://translation.googleapis.com/language/translate/";
        #endif

        /// <summary>Gets the service base path.</summary>
        public override string BasePath => "language/translate/";

        #if !NET40
        /// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>
        public override string BatchUri => "https://translation.googleapis.com/batch/translate";

        /// <summary>Gets the batch base path; <c>null</c> if unspecified.</summary>
        public override string BatchPath => "batch/translate";
        #endif

        /// <summary>Available OAuth 2.0 scopes for use with the Google Cloud Translation API.</summary>
        public class Scope
        {
            /// <summary>View and manage your data across Google Cloud Platform services</summary>
            public static string CloudPlatform = "https://www.googleapis.com/auth/cloud-platform";

            /// <summary>Translate text from one language to another using Google Translate</summary>
            public static string CloudTranslation = "https://www.googleapis.com/auth/cloud-translation";

        }

        /// <summary>Available OAuth 2.0 scope constants for use with the Google Cloud Translation API.</summary>
        public static class ScopeConstants
        {
            /// <summary>View and manage your data across Google Cloud Platform services</summary>
            public const string CloudPlatform = "https://www.googleapis.com/auth/cloud-platform";

            /// <summary>Translate text from one language to another using Google Translate</summary>
            public const string CloudTranslation = "https://www.googleapis.com/auth/cloud-translation";

        }



        /// <summary>Gets the Detections resource.</summary>
        public virtual DetectionsResource Detections { get; }

        /// <summary>Gets the Languages resource.</summary>
        public virtual LanguagesResource Languages { get; }

        /// <summary>Gets the Translations resource.</summary>
        public virtual TranslationsResource Translations { get; }
    }

    ///<summary>A base abstract class for Translate requests.</summary>
    public abstract class TranslateBaseServiceRequest<TResponse> : Google.Apis.Requests.ClientServiceRequest<TResponse>
    {
        ///<summary>Constructs a new TranslateBaseServiceRequest instance.</summary>
        protected TranslateBaseServiceRequest(Google.Apis.Services.IClientService service)
            : base(service)
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
            Value1,
            /// <summary>v2 error format</summary>
            [Google.Apis.Util.StringValueAttribute("2")]
            Value2,
        }

        /// <summary>OAuth access token.</summary>
        [Google.Apis.Util.RequestParameterAttribute("access_token", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string AccessToken { get; set; }

        /// <summary>Data format for response.</summary>
        /// [default: json]
        [Google.Apis.Util.RequestParameterAttribute("alt", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<AltEnum> Alt { get; set; }

        /// <summary>Data format for response.</summary>
        public enum AltEnum
        {
            /// <summary>Responses with Content-Type of application/json</summary>
            [Google.Apis.Util.StringValueAttribute("json")]
            Json,
            /// <summary>Media download with context-dependent Content-Type</summary>
            [Google.Apis.Util.StringValueAttribute("media")]
            Media,
            /// <summary>Responses with Content-Type of application/x-protobuf</summary>
            [Google.Apis.Util.StringValueAttribute("proto")]
            Proto,
        }

        /// <summary>OAuth bearer token.</summary>
        [Google.Apis.Util.RequestParameterAttribute("bearer_token", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string BearerToken { get; set; }

        /// <summary>JSONP</summary>
        [Google.Apis.Util.RequestParameterAttribute("callback", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Callback { get; set; }

        /// <summary>Selector specifying which fields to include in a partial response.</summary>
        [Google.Apis.Util.RequestParameterAttribute("fields", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Fields { get; set; }

        /// <summary>API key. Your API key identifies your project and provides you with API access, quota, and reports.
        /// Required unless you provide an OAuth 2.0 token.</summary>
        [Google.Apis.Util.RequestParameterAttribute("key", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Key { get; set; }

        /// <summary>OAuth 2.0 token for the current user.</summary>
        [Google.Apis.Util.RequestParameterAttribute("oauth_token", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string OauthToken { get; set; }

        /// <summary>Pretty-print response.</summary>
        /// [default: true]
        [Google.Apis.Util.RequestParameterAttribute("pp", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<bool> Pp { get; set; }

        /// <summary>Returns response with indentations and line breaks.</summary>
        /// [default: true]
        [Google.Apis.Util.RequestParameterAttribute("prettyPrint", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<bool> PrettyPrint { get; set; }

        /// <summary>Available to use for quota purposes for server-side applications. Can be any arbitrary string
        /// assigned to a user, but should not exceed 40 characters. Overrides userIp if both are provided.</summary>
        [Google.Apis.Util.RequestParameterAttribute("quotaUser", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string QuotaUser { get; set; }

        /// <summary>Legacy upload protocol for media (e.g. "media", "multipart").</summary>
        [Google.Apis.Util.RequestParameterAttribute("uploadType", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string UploadType { get; set; }

        /// <summary>Upload protocol for media (e.g. "raw", "multipart").</summary>
        [Google.Apis.Util.RequestParameterAttribute("upload_protocol", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string UploadProtocol { get; set; }

        /// <summary>Initializes Translate parameter list.</summary>
        protected override void InitParameters()
        {
            base.InitParameters();

            RequestParameters.Add(
                "$.xgafv", new Google.Apis.Discovery.Parameter
                {
                    Name = "$.xgafv",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "access_token", new Google.Apis.Discovery.Parameter
                {
                    Name = "access_token",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "alt", new Google.Apis.Discovery.Parameter
                {
                    Name = "alt",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "json",
                    Pattern = null,
                });
            RequestParameters.Add(
                "bearer_token", new Google.Apis.Discovery.Parameter
                {
                    Name = "bearer_token",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "callback", new Google.Apis.Discovery.Parameter
                {
                    Name = "callback",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "fields", new Google.Apis.Discovery.Parameter
                {
                    Name = "fields",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "key", new Google.Apis.Discovery.Parameter
                {
                    Name = "key",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "oauth_token", new Google.Apis.Discovery.Parameter
                {
                    Name = "oauth_token",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "pp", new Google.Apis.Discovery.Parameter
                {
                    Name = "pp",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "true",
                    Pattern = null,
                });
            RequestParameters.Add(
                "prettyPrint", new Google.Apis.Discovery.Parameter
                {
                    Name = "prettyPrint",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "true",
                    Pattern = null,
                });
            RequestParameters.Add(
                "quotaUser", new Google.Apis.Discovery.Parameter
                {
                    Name = "quotaUser",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "uploadType", new Google.Apis.Discovery.Parameter
                {
                    Name = "uploadType",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "upload_protocol", new Google.Apis.Discovery.Parameter
                {
                    Name = "upload_protocol",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
        }
    }

    /// <summary>The "detections" collection of methods.</summary>
    public class DetectionsResource
    {
        private const string Resource = "detections";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public DetectionsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Detects the language of text within a request.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual DetectRequest Detect(Google.Apis.Translate.v2.Data.DetectLanguageRequest body)
        {
            return new DetectRequest(service, body);
        }

        /// <summary>Detects the language of text within a request.</summary>
        public class DetectRequest : TranslateBaseServiceRequest<Google.Apis.Translate.v2.Data.DetectionsListResponse>
        {
            /// <summary>Constructs a new Detect request.</summary>
            public DetectRequest(Google.Apis.Services.IClientService service, Google.Apis.Translate.v2.Data.DetectLanguageRequest body)
                : base(service)
            {
                Body = body;
                InitParameters();
            }



            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Translate.v2.Data.DetectLanguageRequest Body { get; set; }

            ///<summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            ///<summary>Gets the method name.</summary>
            public override string MethodName => "detect";

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            ///<summary>Gets the REST path.</summary>
            public override string RestPath => "v2/detect";

            /// <summary>Initializes Detect parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

            }

        }

        /// <summary>Detects the language of text within a request.</summary>
        /// <param name="q">The input text upon which to perform language detection. Repeat this parameter to perform language
        /// detection on multiple text inputs.</param>
        public virtual ListRequest List(Google.Apis.Util.Repeatable<string> q)
        {
            return new ListRequest(service, q);
        }

        /// <summary>Detects the language of text within a request.</summary>
        public class ListRequest : TranslateBaseServiceRequest<Google.Apis.Translate.v2.Data.DetectionsListResponse>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, Google.Apis.Util.Repeatable<string> q)
                : base(service)
            {
                Q = q;
                InitParameters();
            }


            /// <summary>The input text upon which to perform language detection. Repeat this parameter to perform
            /// language detection on multiple text inputs.</summary>
            [Google.Apis.Util.RequestParameterAttribute("q", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> Q { get; private set; }


            ///<summary>Gets the method name.</summary>
            public override string MethodName => "list";

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            ///<summary>Gets the REST path.</summary>
            public override string RestPath => "v2/detect";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add(
                    "q", new Google.Apis.Discovery.Parameter
                    {
                        Name = "q",
                        IsRequired = true,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
            }

        }
    }

    /// <summary>The "languages" collection of methods.</summary>
    public class LanguagesResource
    {
        private const string Resource = "languages";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public LanguagesResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Returns a list of supported languages for translation.</summary>
        public virtual ListRequest List()
        {
            return new ListRequest(service);
        }

        /// <summary>Returns a list of supported languages for translation.</summary>
        public class ListRequest : TranslateBaseServiceRequest<Google.Apis.Translate.v2.Data.LanguagesListResponse>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service)
                : base(service)
            {
                InitParameters();
            }


            /// <summary>The model type for which supported languages should be returned.</summary>
            [Google.Apis.Util.RequestParameterAttribute("model", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Model { get; set; }

            /// <summary>The language to use to return localized, human readable names of supported languages.</summary>
            [Google.Apis.Util.RequestParameterAttribute("target", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Target { get; set; }


            ///<summary>Gets the method name.</summary>
            public override string MethodName => "list";

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            ///<summary>Gets the REST path.</summary>
            public override string RestPath => "v2/languages";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add(
                    "model", new Google.Apis.Discovery.Parameter
                    {
                        Name = "model",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "target", new Google.Apis.Discovery.Parameter
                    {
                        Name = "target",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
            }

        }
    }

    /// <summary>The "translations" collection of methods.</summary>
    public class TranslationsResource
    {
        private const string Resource = "translations";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public TranslationsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Translates input text, returning translated text.</summary>
        /// <param name="q">The input text to translate. Repeat this parameter to perform translation operations on multiple
        /// text inputs.</param>
        /// <param name="target">The language to use for translation of the input text, set to one
        /// of the language codes listed in Language Support.</param>
        public virtual ListRequest List(Google.Apis.Util.Repeatable<string> q, string target)
        {
            return new ListRequest(service, q, target);
        }

        /// <summary>Translates input text, returning translated text.</summary>
        public class ListRequest : TranslateBaseServiceRequest<Google.Apis.Translate.v2.Data.TranslationsListResponse>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, Google.Apis.Util.Repeatable<string> q, string target)
                : base(service)
            {
                Q = q;
                Target = target;
                InitParameters();
            }


            /// <summary>The input text to translate. Repeat this parameter to perform translation operations on
            /// multiple text inputs.</summary>
            [Google.Apis.Util.RequestParameterAttribute("q", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> Q { get; private set; }

            /// <summary>The language to use for translation of the input text, set to one of the language codes listed
            /// in Language Support.</summary>
            [Google.Apis.Util.RequestParameterAttribute("target", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Target { get; private set; }

            /// <summary>The customization id for translate</summary>
            [Google.Apis.Util.RequestParameterAttribute("cid", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> Cid { get; set; }

            /// <summary>The format of the source text, in either HTML (default) or plain-text. A value of "html"
            /// indicates HTML and a value of "text" indicates plain-text.</summary>
            [Google.Apis.Util.RequestParameterAttribute("format", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<FormatEnum> Format { get; set; }

            /// <summary>The format of the source text, in either HTML (default) or plain-text. A value of "html"
            /// indicates HTML and a value of "text" indicates plain-text.</summary>
            public enum FormatEnum
            {
                /// <summary>Specifies the input is in HTML</summary>
                [Google.Apis.Util.StringValueAttribute("html")]
                Html,
                /// <summary>Specifies the input is in plain textual format</summary>
                [Google.Apis.Util.StringValueAttribute("text")]
                Text,
            }

            /// <summary>The `model` type requested for this translation. Valid values are listed in public
            /// documentation.</summary>
            [Google.Apis.Util.RequestParameterAttribute("model", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Model { get; set; }

            /// <summary>The language of the source text, set to one of the language codes listed in Language Support.
            /// If the source language is not specified, the API will attempt to identify the source language
            /// automatically and return it within the response.</summary>
            [Google.Apis.Util.RequestParameterAttribute("source", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Source { get; set; }


            ///<summary>Gets the method name.</summary>
            public override string MethodName => "list";

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            ///<summary>Gets the REST path.</summary>
            public override string RestPath => "v2";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add(
                    "q", new Google.Apis.Discovery.Parameter
                    {
                        Name = "q",
                        IsRequired = true,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "target", new Google.Apis.Discovery.Parameter
                    {
                        Name = "target",
                        IsRequired = true,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "cid", new Google.Apis.Discovery.Parameter
                    {
                        Name = "cid",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "format", new Google.Apis.Discovery.Parameter
                    {
                        Name = "format",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "model", new Google.Apis.Discovery.Parameter
                    {
                        Name = "model",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "source", new Google.Apis.Discovery.Parameter
                    {
                        Name = "source",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
            }

        }

        /// <summary>Translates input text, returning translated text.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual TranslateRequest Translate(Google.Apis.Translate.v2.Data.TranslateTextRequest body)
        {
            return new TranslateRequest(service, body);
        }

        /// <summary>Translates input text, returning translated text.</summary>
        public class TranslateRequest : TranslateBaseServiceRequest<Google.Apis.Translate.v2.Data.TranslationsListResponse>
        {
            /// <summary>Constructs a new Translate request.</summary>
            public TranslateRequest(Google.Apis.Services.IClientService service, Google.Apis.Translate.v2.Data.TranslateTextRequest body)
                : base(service)
            {
                Body = body;
                InitParameters();
            }



            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Translate.v2.Data.TranslateTextRequest Body { get; set; }

            ///<summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            ///<summary>Gets the method name.</summary>
            public override string MethodName => "translate";

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            ///<summary>Gets the REST path.</summary>
            public override string RestPath => "v2";

            /// <summary>Initializes Translate parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

            }

        }
    }
}

namespace Google.Apis.Translate.v2.Data
{    

    /// <summary>The request message for language detection.</summary>
    public class DetectLanguageRequest : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The input text upon which to perform language detection. Repeat this parameter to perform language
        /// detection on multiple text inputs.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("q")]
        public virtual System.Collections.Generic.IList<string> Q { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class DetectionsListResponse : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>A detections contains detection results of several text</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("detections")]
        public virtual System.Collections.Generic.IList<System.Collections.Generic.IList<DetectionsResourceItems>> Detections { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class DetectionsResourceItems : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The confidence of the detection result of this language.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("confidence")]
        public virtual System.Nullable<float> Confidence { get; set; } 

        /// <summary>A boolean to indicate is the language detection result reliable.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("isReliable")]
        public virtual System.Nullable<bool> IsReliable { get; set; } 

        /// <summary>The language we detected.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("language")]
        public virtual string Language { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>The request message for discovering supported languages.</summary>
    public class GetSupportedLanguagesRequest : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The language to use to return localized, human readable names of supported languages.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("target")]
        public virtual string Target { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class LanguagesListResponse : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>List of source/target languages supported by the translation API. If target parameter is
        /// unspecified, the list is sorted by the ASCII code point order of the language code. If target parameter is
        /// specified, the list is sorted by the collation order of the language name in the target language.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("languages")]
        public virtual System.Collections.Generic.IList<LanguagesResource> Languages { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class LanguagesResource : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Supported language code, generally consisting of its ISO 639-1 identifier. (E.g. 'en', 'ja'). In
        /// certain cases, BCP-47 codes including language + region identifiers are returned (e.g. 'zh-TW' and 'zh-
        /// CH')</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("language")]
        public virtual string Language { get; set; } 

        /// <summary>Human readable name of the language localized to the target language.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public virtual string Name { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>The main translation request message for the Cloud Translation API.</summary>
    public class TranslateTextRequest : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The format of the source text, in either HTML (default) or plain-text. A value of "html" indicates
        /// HTML and a value of "text" indicates plain-text.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("format")]
        public virtual string Format { get; set; } 

        /// <summary>The `model` type requested for this translation. Valid values are listed in public
        /// documentation.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("model")]
        public virtual string Model { get; set; } 

        /// <summary>The input text to translate. Repeat this parameter to perform translation operations on multiple
        /// text inputs.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("q")]
        public virtual System.Collections.Generic.IList<string> Q { get; set; } 

        /// <summary>The language of the source text, set to one of the language codes listed in Language Support. If
        /// the source language is not specified, the API will attempt to identify the source language automatically and
        /// return it within the response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("source")]
        public virtual string Source { get; set; } 

        /// <summary>The language to use for translation of the input text, set to one of the language codes listed in
        /// Language Support.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("target")]
        public virtual string Target { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>The main language translation response message.</summary>
    public class TranslationsListResponse : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Translations contains list of translation results of given text</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("translations")]
        public virtual System.Collections.Generic.IList<TranslationsResource> Translations { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class TranslationsResource : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The source language of the initial request, detected automatically, if no source language was
        /// passed within the initial request. If the source language was passed, auto-detection of the language will
        /// not occur and this field will be empty.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("detectedSourceLanguage")]
        public virtual string DetectedSourceLanguage { get; set; } 

        /// <summary>The `model` type used for this translation. Valid values are listed in public documentation. Can be
        /// different from requested `model`. Present only if specific model type was explicitly requested.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("model")]
        public virtual string Model { get; set; } 

        /// <summary>Text translated into the target language.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("translatedText")]
        public virtual string TranslatedText { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }
}
