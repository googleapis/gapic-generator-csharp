// Copyright 2022 Google LLC
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

namespace Google.Apis.Calendar.v3
{
    /// <summary>The Calendar Service.</summary>
    public class CalendarService : Google.Apis.Services.BaseClientService
    {
        /// <summary>The API version.</summary>
        public const string Version = "v3";

        /// <summary>The discovery version used to generate this service.</summary>
        public static Google.Apis.Discovery.DiscoveryVersion DiscoveryVersionUsed = Google.Apis.Discovery.DiscoveryVersion.Version_1_0;

        /// <summary>Constructs a new service.</summary>
        public CalendarService() : this(new Google.Apis.Services.BaseClientService.Initializer())
        {
        }

        /// <summary>Constructs a new service.</summary>
        /// <param name="initializer">The service initializer.</param>
        public CalendarService(Google.Apis.Services.BaseClientService.Initializer initializer) : base(initializer)
        {
            Acl = new AclResource(this);
            CalendarList = new CalendarListResource(this);
            Calendars = new CalendarsResource(this);
            Channels = new ChannelsResource(this);
            Colors = new ColorsResource(this);
            Events = new EventsResource(this);
            Freebusy = new FreebusyResource(this);
            Settings = new SettingsResource(this);
        }

        /// <summary>Gets the service supported features.</summary>
        public override System.Collections.Generic.IList<string> Features => new string[0];

        /// <summary>Gets the service name.</summary>
        public override string Name => "calendar";

        /// <summary>Gets the service base URI.</summary>
        public override string BaseUri => BaseUriOverride ?? "https://www.googleapis.com/calendar/v3/";

        /// <summary>Gets the service base path.</summary>
        public override string BasePath => "calendar/v3/";

        /// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>
        public override string BatchUri => "https://www.googleapis.com/batch/calendar/v3";

        /// <summary>Gets the batch base path; <c>null</c> if unspecified.</summary>
        public override string BatchPath => "batch/calendar/v3";

        /// <summary>Available OAuth 2.0 scopes for use with the Calendar API.</summary>
        public class Scope
        {
            /// <summary>
            /// See, edit, share, and permanently delete all the calendars you can access using Google Calendar
            /// </summary>
            public static string Calendar = "https://www.googleapis.com/auth/calendar";

            /// <summary>View and edit events on all your calendars</summary>
            public static string CalendarEvents = "https://www.googleapis.com/auth/calendar.events";

            /// <summary>View events on all your calendars</summary>
            public static string CalendarEventsReadonly = "https://www.googleapis.com/auth/calendar.events.readonly";

            /// <summary>See and download any calendar you can access using your Google Calendar</summary>
            public static string CalendarReadonly = "https://www.googleapis.com/auth/calendar.readonly";

            /// <summary>View your Calendar settings</summary>
            public static string CalendarSettingsReadonly = "https://www.googleapis.com/auth/calendar.settings.readonly";
        }

        /// <summary>Available OAuth 2.0 scope constants for use with the Calendar API.</summary>
        public static class ScopeConstants
        {
            /// <summary>
            /// See, edit, share, and permanently delete all the calendars you can access using Google Calendar
            /// </summary>
            public const string Calendar = "https://www.googleapis.com/auth/calendar";

            /// <summary>View and edit events on all your calendars</summary>
            public const string CalendarEvents = "https://www.googleapis.com/auth/calendar.events";

            /// <summary>View events on all your calendars</summary>
            public const string CalendarEventsReadonly = "https://www.googleapis.com/auth/calendar.events.readonly";

            /// <summary>See and download any calendar you can access using your Google Calendar</summary>
            public const string CalendarReadonly = "https://www.googleapis.com/auth/calendar.readonly";

            /// <summary>View your Calendar settings</summary>
            public const string CalendarSettingsReadonly = "https://www.googleapis.com/auth/calendar.settings.readonly";
        }

        /// <summary>Gets the Acl resource.</summary>
        public virtual AclResource Acl { get; }

        /// <summary>Gets the CalendarList resource.</summary>
        public virtual CalendarListResource CalendarList { get; }

        /// <summary>Gets the Calendars resource.</summary>
        public virtual CalendarsResource Calendars { get; }

        /// <summary>Gets the Channels resource.</summary>
        public virtual ChannelsResource Channels { get; }

        /// <summary>Gets the Colors resource.</summary>
        public virtual ColorsResource Colors { get; }

        /// <summary>Gets the Events resource.</summary>
        public virtual EventsResource Events { get; }

        /// <summary>Gets the Freebusy resource.</summary>
        public virtual FreebusyResource Freebusy { get; }

        /// <summary>Gets the Settings resource.</summary>
        public virtual SettingsResource Settings { get; }
    }

    /// <summary>A base abstract class for Calendar requests.</summary>
    public abstract class CalendarBaseServiceRequest<TResponse> : Google.Apis.Requests.ClientServiceRequest<TResponse>
    {
        /// <summary>Constructs a new CalendarBaseServiceRequest instance.</summary>
        protected CalendarBaseServiceRequest(Google.Apis.Services.IClientService service) : base(service)
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

        /// <summary>Initializes Calendar parameter list.</summary>
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

    /// <summary>The "acl" collection of methods.</summary>
    public class AclResource
    {
        private const string Resource = "acl";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public AclResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Deletes an access control rule.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="ruleId">ACL rule identifier.</param>
        public virtual DeleteRequest Delete(string calendarId, string ruleId)
        {
            return new DeleteRequest(this.service, calendarId, ruleId);
        }

        /// <summary>Deletes an access control rule.</summary>
        public class DeleteRequest : CalendarBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string calendarId, string ruleId) : base(service)
            {
                CalendarId = calendarId;
                RuleId = ruleId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>ACL rule identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ruleId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string RuleId { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/acl/{ruleId}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ruleId", new Google.Apis.Discovery.Parameter
                {
                    Name = "ruleId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns an access control rule.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="ruleId">ACL rule identifier.</param>
        public virtual GetRequest Get(string calendarId, string ruleId)
        {
            return new GetRequest(this.service, calendarId, ruleId);
        }

        /// <summary>Returns an access control rule.</summary>
        public class GetRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.AclRule>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string calendarId, string ruleId) : base(service)
            {
                CalendarId = calendarId;
                RuleId = ruleId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>ACL rule identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ruleId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string RuleId { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/acl/{ruleId}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ruleId", new Google.Apis.Discovery.Parameter
                {
                    Name = "ruleId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Creates an access control rule.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual InsertRequest Insert(Google.Apis.Calendar.v3.Data.AclRule body, string calendarId)
        {
            return new InsertRequest(this.service, body, calendarId);
        }

        /// <summary>Creates an access control rule.</summary>
        public class InsertRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.AclRule>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.AclRule body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Whether to send notifications about the calendar sharing change. Optional. The default is True.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.AclRule Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/acl";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns the rules in the access control list for the calendar.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual ListRequest List(string calendarId)
        {
            return new ListRequest(this.service, calendarId);
        }

        /// <summary>Returns the rules in the access control list for the calendar.</summary>
        public class ListRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Acl>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page
            /// size can never be larger than 250 entries. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Whether to include deleted ACLs in the result. Deleted ACLs are represented by role equal to "none".
            /// Deleted ACLs will always be included if syncToken is provided. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("showDeleted", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowDeleted { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. All
            /// entries deleted since the previous list request will always be in the result set and it is not allowed
            /// to set showDeleted to False. If the syncToken expires, the server will respond with a 410 GONE response
            /// code and the client should clear its storage and perform a full synchronization without any syncToken.
            /// Learn more about incremental synchronization. Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/acl";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
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
                RequestParameters.Add("showDeleted", new Google.Apis.Discovery.Parameter
                {
                    Name = "showDeleted",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Updates an access control rule. This method supports patch semantics.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="ruleId">ACL rule identifier.</param>
        public virtual PatchRequest Patch(Google.Apis.Calendar.v3.Data.AclRule body, string calendarId, string ruleId)
        {
            return new PatchRequest(this.service, body, calendarId, ruleId);
        }

        /// <summary>Updates an access control rule. This method supports patch semantics.</summary>
        public class PatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.AclRule>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.AclRule body, string calendarId, string ruleId) : base(service)
            {
                CalendarId = calendarId;
                RuleId = ruleId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>ACL rule identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ruleId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string RuleId { get; private set; }

            /// <summary>
            /// Whether to send notifications about the calendar sharing change. Note that there are no notifications on
            /// access removal. Optional. The default is True.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.AclRule Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/acl/{ruleId}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ruleId", new Google.Apis.Discovery.Parameter
                {
                    Name = "ruleId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Updates an access control rule.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="ruleId">ACL rule identifier.</param>
        public virtual UpdateRequest Update(Google.Apis.Calendar.v3.Data.AclRule body, string calendarId, string ruleId)
        {
            return new UpdateRequest(this.service, body, calendarId, ruleId);
        }

        /// <summary>Updates an access control rule.</summary>
        public class UpdateRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.AclRule>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.AclRule body, string calendarId, string ruleId) : base(service)
            {
                CalendarId = calendarId;
                RuleId = ruleId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>ACL rule identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ruleId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string RuleId { get; private set; }

            /// <summary>
            /// Whether to send notifications about the calendar sharing change. Note that there are no notifications on
            /// access removal. Optional. The default is True.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.AclRule Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/acl/{ruleId}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ruleId", new Google.Apis.Discovery.Parameter
                {
                    Name = "ruleId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Watch for changes to ACL resources.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual WatchRequest Watch(Google.Apis.Calendar.v3.Data.Channel body, string calendarId)
        {
            return new WatchRequest(this.service, body, calendarId);
        }

        /// <summary>Watch for changes to ACL resources.</summary>
        public class WatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Channel>
        {
            /// <summary>Constructs a new Watch request.</summary>
            public WatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Channel body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page
            /// size can never be larger than 250 entries. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Whether to include deleted ACLs in the result. Deleted ACLs are represented by role equal to "none".
            /// Deleted ACLs will always be included if syncToken is provided. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("showDeleted", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowDeleted { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. All
            /// entries deleted since the previous list request will always be in the result set and it is not allowed
            /// to set showDeleted to False. If the syncToken expires, the server will respond with a 410 GONE response
            /// code and the client should clear its storage and perform a full synchronization without any syncToken.
            /// Learn more about incremental synchronization. Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Channel Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "watch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/acl/watch";

            /// <summary>Initializes Watch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
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
                RequestParameters.Add("showDeleted", new Google.Apis.Discovery.Parameter
                {
                    Name = "showDeleted",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }
    }

    /// <summary>The "calendarList" collection of methods.</summary>
    public class CalendarListResource
    {
        private const string Resource = "calendarList";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public CalendarListResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Removes a calendar from the user's calendar list.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual DeleteRequest Delete(string calendarId)
        {
            return new DeleteRequest(this.service, calendarId);
        }

        /// <summary>Removes a calendar from the user's calendar list.</summary>
        public class DeleteRequest : CalendarBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/calendarList/{calendarId}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns a calendar from the user's calendar list.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual GetRequest Get(string calendarId)
        {
            return new GetRequest(this.service, calendarId);
        }

        /// <summary>Returns a calendar from the user's calendar list.</summary>
        public class GetRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.CalendarListEntry>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/calendarList/{calendarId}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Inserts an existing calendar into the user's calendar list.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual InsertRequest Insert(Google.Apis.Calendar.v3.Data.CalendarListEntry body)
        {
            return new InsertRequest(this.service, body);
        }

        /// <summary>Inserts an existing calendar into the user's calendar list.</summary>
        public class InsertRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.CalendarListEntry>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.CalendarListEntry body) : base(service)
            {
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Whether to use the foregroundColor and backgroundColor fields to write the calendar colors (RGB). If
            /// this feature is used, the index-based colorId field will be set to the best matching option
            /// automatically. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("colorRgbFormat", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ColorRgbFormat { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.CalendarListEntry Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/calendarList";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("colorRgbFormat", new Google.Apis.Discovery.Parameter
                {
                    Name = "colorRgbFormat",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns the calendars on the user's calendar list.</summary>
        public virtual ListRequest List()
        {
            return new ListRequest(this.service);
        }

        /// <summary>Returns the calendars on the user's calendar list.</summary>
        public class ListRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.CalendarList>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service) : base(service)
            {
                InitParameters();
            }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page
            /// size can never be larger than 250 entries. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>
            /// The minimum access role for the user in the returned entries. Optional. The default is no restriction.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("minAccessRole", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<MinAccessRoleEnum> MinAccessRole { get; set; }

            /// <summary>
            /// The minimum access role for the user in the returned entries. Optional. The default is no restriction.
            /// </summary>
            public enum MinAccessRoleEnum
            {
                /// <summary>The user can read free/busy information.</summary>
                [Google.Apis.Util.StringValueAttribute("freeBusyReader")]
                FreeBusyReader = 0,

                /// <summary>The user can read and modify events and access control lists.</summary>
                [Google.Apis.Util.StringValueAttribute("owner")]
                Owner = 1,

                /// <summary>The user can read events that are not private.</summary>
                [Google.Apis.Util.StringValueAttribute("reader")]
                Reader = 2,

                /// <summary>The user can read and modify events.</summary>
                [Google.Apis.Util.StringValueAttribute("writer")]
                Writer = 3,
            }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Whether to include deleted calendar list entries in the result. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("showDeleted", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowDeleted { get; set; }

            /// <summary>Whether to show hidden entries. Optional. The default is False.</summary>
            [Google.Apis.Util.RequestParameterAttribute("showHidden", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowHidden { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. If
            /// only read-only fields such as calendar properties or ACLs have changed, the entry won't be returned. All
            /// entries deleted and hidden since the previous list request will always be in the result set and it is
            /// not allowed to set showDeleted neither showHidden to False. To ensure client state consistency
            /// minAccessRole query parameter cannot be specified together with nextSyncToken. If the syncToken expires,
            /// the server will respond with a 410 GONE response code and the client should clear its storage and
            /// perform a full synchronization without any syncToken. Learn more about incremental synchronization.
            /// Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/calendarList";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("minAccessRole", new Google.Apis.Discovery.Parameter
                {
                    Name = "minAccessRole",
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
                RequestParameters.Add("showDeleted", new Google.Apis.Discovery.Parameter
                {
                    Name = "showDeleted",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("showHidden", new Google.Apis.Discovery.Parameter
                {
                    Name = "showHidden",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>
        /// Updates an existing calendar on the user's calendar list. This method supports patch semantics.
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual PatchRequest Patch(Google.Apis.Calendar.v3.Data.CalendarListEntry body, string calendarId)
        {
            return new PatchRequest(this.service, body, calendarId);
        }

        /// <summary>
        /// Updates an existing calendar on the user's calendar list. This method supports patch semantics.
        /// </summary>
        public class PatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.CalendarListEntry>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.CalendarListEntry body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Whether to use the foregroundColor and backgroundColor fields to write the calendar colors (RGB). If
            /// this feature is used, the index-based colorId field will be set to the best matching option
            /// automatically. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("colorRgbFormat", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ColorRgbFormat { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.CalendarListEntry Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/calendarList/{calendarId}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("colorRgbFormat", new Google.Apis.Discovery.Parameter
                {
                    Name = "colorRgbFormat",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Updates an existing calendar on the user's calendar list.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual UpdateRequest Update(Google.Apis.Calendar.v3.Data.CalendarListEntry body, string calendarId)
        {
            return new UpdateRequest(this.service, body, calendarId);
        }

        /// <summary>Updates an existing calendar on the user's calendar list.</summary>
        public class UpdateRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.CalendarListEntry>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.CalendarListEntry body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Whether to use the foregroundColor and backgroundColor fields to write the calendar colors (RGB). If
            /// this feature is used, the index-based colorId field will be set to the best matching option
            /// automatically. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("colorRgbFormat", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ColorRgbFormat { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.CalendarListEntry Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/calendarList/{calendarId}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("colorRgbFormat", new Google.Apis.Discovery.Parameter
                {
                    Name = "colorRgbFormat",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Watch for changes to CalendarList resources.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual WatchRequest Watch(Google.Apis.Calendar.v3.Data.Channel body)
        {
            return new WatchRequest(this.service, body);
        }

        /// <summary>Watch for changes to CalendarList resources.</summary>
        public class WatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Channel>
        {
            /// <summary>Constructs a new Watch request.</summary>
            public WatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Channel body) : base(service)
            {
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page
            /// size can never be larger than 250 entries. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>
            /// The minimum access role for the user in the returned entries. Optional. The default is no restriction.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("minAccessRole", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<MinAccessRoleEnum> MinAccessRole { get; set; }

            /// <summary>
            /// The minimum access role for the user in the returned entries. Optional. The default is no restriction.
            /// </summary>
            public enum MinAccessRoleEnum
            {
                /// <summary>The user can read free/busy information.</summary>
                [Google.Apis.Util.StringValueAttribute("freeBusyReader")]
                FreeBusyReader = 0,

                /// <summary>The user can read and modify events and access control lists.</summary>
                [Google.Apis.Util.StringValueAttribute("owner")]
                Owner = 1,

                /// <summary>The user can read events that are not private.</summary>
                [Google.Apis.Util.StringValueAttribute("reader")]
                Reader = 2,

                /// <summary>The user can read and modify events.</summary>
                [Google.Apis.Util.StringValueAttribute("writer")]
                Writer = 3,
            }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Whether to include deleted calendar list entries in the result. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("showDeleted", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowDeleted { get; set; }

            /// <summary>Whether to show hidden entries. Optional. The default is False.</summary>
            [Google.Apis.Util.RequestParameterAttribute("showHidden", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowHidden { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. If
            /// only read-only fields such as calendar properties or ACLs have changed, the entry won't be returned. All
            /// entries deleted and hidden since the previous list request will always be in the result set and it is
            /// not allowed to set showDeleted neither showHidden to False. To ensure client state consistency
            /// minAccessRole query parameter cannot be specified together with nextSyncToken. If the syncToken expires,
            /// the server will respond with a 410 GONE response code and the client should clear its storage and
            /// perform a full synchronization without any syncToken. Learn more about incremental synchronization.
            /// Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Channel Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "watch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/calendarList/watch";

            /// <summary>Initializes Watch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("minAccessRole", new Google.Apis.Discovery.Parameter
                {
                    Name = "minAccessRole",
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
                RequestParameters.Add("showDeleted", new Google.Apis.Discovery.Parameter
                {
                    Name = "showDeleted",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("showHidden", new Google.Apis.Discovery.Parameter
                {
                    Name = "showHidden",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }
    }

    /// <summary>The "calendars" collection of methods.</summary>
    public class CalendarsResource
    {
        private const string Resource = "calendars";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public CalendarsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Clears a primary calendar. This operation deletes all events associated with the primary calendar of an
        /// account.
        /// </summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual ClearRequest Clear(string calendarId)
        {
            return new ClearRequest(this.service, calendarId);
        }

        /// <summary>
        /// Clears a primary calendar. This operation deletes all events associated with the primary calendar of an
        /// account.
        /// </summary>
        public class ClearRequest : CalendarBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Clear request.</summary>
            public ClearRequest(Google.Apis.Services.IClientService service, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "clear";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/clear";

            /// <summary>Initializes Clear parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>
        /// Deletes a secondary calendar. Use calendars.clear for clearing all events on primary calendars.
        /// </summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual DeleteRequest Delete(string calendarId)
        {
            return new DeleteRequest(this.service, calendarId);
        }

        /// <summary>
        /// Deletes a secondary calendar. Use calendars.clear for clearing all events on primary calendars.
        /// </summary>
        public class DeleteRequest : CalendarBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns metadata for a calendar.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual GetRequest Get(string calendarId)
        {
            return new GetRequest(this.service, calendarId);
        }

        /// <summary>Returns metadata for a calendar.</summary>
        public class GetRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Calendar>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Creates a secondary calendar.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual InsertRequest Insert(Google.Apis.Calendar.v3.Data.Calendar body)
        {
            return new InsertRequest(this.service, body);
        }

        /// <summary>Creates a secondary calendar.</summary>
        public class InsertRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Calendar>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Calendar body) : base(service)
            {
                Body = body;
                InitParameters();
            }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Calendar Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
            }
        }

        /// <summary>Updates metadata for a calendar. This method supports patch semantics.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual PatchRequest Patch(Google.Apis.Calendar.v3.Data.Calendar body, string calendarId)
        {
            return new PatchRequest(this.service, body, calendarId);
        }

        /// <summary>Updates metadata for a calendar. This method supports patch semantics.</summary>
        public class PatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Calendar>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Calendar body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Calendar Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Updates metadata for a calendar.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual UpdateRequest Update(Google.Apis.Calendar.v3.Data.Calendar body, string calendarId)
        {
            return new UpdateRequest(this.service, body, calendarId);
        }

        /// <summary>Updates metadata for a calendar.</summary>
        public class UpdateRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Calendar>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Calendar body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Calendar Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }
    }

    /// <summary>The "channels" collection of methods.</summary>
    public class ChannelsResource
    {
        private const string Resource = "channels";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public ChannelsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Stop watching resources through this channel</summary>
        /// <param name="body">The body of the request.</param>
        public virtual StopRequest Stop(Google.Apis.Calendar.v3.Data.Channel body)
        {
            return new StopRequest(this.service, body);
        }

        /// <summary>Stop watching resources through this channel</summary>
        public class StopRequest : CalendarBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Stop request.</summary>
            public StopRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Channel body) : base(service)
            {
                Body = body;
                InitParameters();
            }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Channel Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "stop";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "channels/stop";

            /// <summary>Initializes Stop parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
            }
        }
    }

    /// <summary>The "colors" collection of methods.</summary>
    public class ColorsResource
    {
        private const string Resource = "colors";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public ColorsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Returns the color definitions for calendars and events.</summary>
        public virtual GetRequest Get()
        {
            return new GetRequest(this.service);
        }

        /// <summary>Returns the color definitions for calendars and events.</summary>
        public class GetRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Colors>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service) : base(service)
            {
                InitParameters();
            }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "colors";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
            }
        }
    }

    /// <summary>The "events" collection of methods.</summary>
    public class EventsResource
    {
        private const string Resource = "events";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public EventsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Deletes an event.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="eventId">Event identifier.</param>
        public virtual DeleteRequest Delete(string calendarId, string eventId)
        {
            return new DeleteRequest(this.service, calendarId, eventId);
        }

        /// <summary>Deletes an event.</summary>
        public class DeleteRequest : CalendarBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string calendarId, string eventId) : base(service)
            {
                CalendarId = calendarId;
                EventId = eventId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Event identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("eventId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string EventId { get; private set; }

            /// <summary>
            /// Deprecated. Please use sendUpdates instead.  Whether to send notifications about the deletion of the
            /// event. Note that some emails might still be sent even if you set the value to false. The default is
            /// false.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>Guests who should receive notifications about the deletion of the event.</summary>
            [Google.Apis.Util.RequestParameterAttribute("sendUpdates", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<SendUpdatesEnum> SendUpdates { get; set; }

            /// <summary>Guests who should receive notifications about the deletion of the event.</summary>
            public enum SendUpdatesEnum
            {
                /// <summary>Notifications are sent to all guests.</summary>
                [Google.Apis.Util.StringValueAttribute("all")]
                All = 0,

                /// <summary>Notifications are sent to non-Google Calendar guests only.</summary>
                [Google.Apis.Util.StringValueAttribute("externalOnly")]
                ExternalOnly = 1,

                /// <summary>
                /// No notifications are sent. For calendar migration tasks, consider using the Events.import method
                /// instead.
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("none")]
                None = 2,
            }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/{eventId}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventId", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendUpdates", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendUpdates",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>
        /// Returns an event based on its Google Calendar ID. To retrieve an event using its iCalendar ID, call the
        /// events.list method using the iCalUID parameter.
        /// </summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="eventId">Event identifier.</param>
        public virtual GetRequest Get(string calendarId, string eventId)
        {
            return new GetRequest(this.service, calendarId, eventId);
        }

        /// <summary>
        /// Returns an event based on its Google Calendar ID. To retrieve an event using its iCalendar ID, call the
        /// events.list method using the iCalUID parameter.
        /// </summary>
        public class GetRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Event>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string calendarId, string eventId) : base(service)
            {
                CalendarId = calendarId;
                EventId = eventId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Event identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("eventId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string EventId { get; private set; }

            /// <summary>
            /// Deprecated and ignored. A value will always be returned in the email field for the organizer, creator
            /// and attendees, even if no real email address is available (i.e. a generated, non-working value will be
            /// provided).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("alwaysIncludeEmail", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> AlwaysIncludeEmail { get; set; }

            /// <summary>
            /// The maximum number of attendees to include in the response. If there are more than the specified number
            /// of attendees, only the participant is returned. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxAttendees", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxAttendees { get; set; }

            /// <summary>
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeZone", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string TimeZone { get; set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/{eventId}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventId", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("alwaysIncludeEmail", new Google.Apis.Discovery.Parameter
                {
                    Name = "alwaysIncludeEmail",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxAttendees", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxAttendees",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeZone", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeZone",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>
        /// Imports an event. This operation is used to add a private copy of an existing event to a calendar.
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual ImportRequest Import(Google.Apis.Calendar.v3.Data.Event body, string calendarId)
        {
            return new ImportRequest(this.service, body, calendarId);
        }

        /// <summary>
        /// Imports an event. This operation is used to add a private copy of an existing event to a calendar.
        /// </summary>
        public class ImportRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Event>
        {
            /// <summary>Constructs a new Import request.</summary>
            public ImportRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Event body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Version number of conference data supported by the API client. Version 0 assumes no conference data
            /// support and ignores conference data in the event's body. Version 1 enables support for copying of
            /// ConferenceData as well as for creating new conferences using the createRequest field of conferenceData.
            /// The default is 0.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("conferenceDataVersion", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> ConferenceDataVersion { get; set; }

            /// <summary>
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("supportsAttachments", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SupportsAttachments { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Event Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "import";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/import";

            /// <summary>Initializes Import parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("conferenceDataVersion", new Google.Apis.Discovery.Parameter
                {
                    Name = "conferenceDataVersion",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("supportsAttachments", new Google.Apis.Discovery.Parameter
                {
                    Name = "supportsAttachments",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Creates an event.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual InsertRequest Insert(Google.Apis.Calendar.v3.Data.Event body, string calendarId)
        {
            return new InsertRequest(this.service, body, calendarId);
        }

        /// <summary>Creates an event.</summary>
        public class InsertRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Event>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Event body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Version number of conference data supported by the API client. Version 0 assumes no conference data
            /// support and ignores conference data in the event's body. Version 1 enables support for copying of
            /// ConferenceData as well as for creating new conferences using the createRequest field of conferenceData.
            /// The default is 0.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("conferenceDataVersion", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> ConferenceDataVersion { get; set; }

            /// <summary>
            /// The maximum number of attendees to include in the response. If there are more than the specified number
            /// of attendees, only the participant is returned. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxAttendees", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxAttendees { get; set; }

            /// <summary>
            /// Deprecated. Please use sendUpdates instead.  Whether to send notifications about the creation of the new
            /// event. Note that some emails might still be sent even if you set the value to false. The default is
            /// false.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>
            /// Whether to send notifications about the creation of the new event. Note that some emails might still be
            /// sent. The default is false.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendUpdates", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<SendUpdatesEnum> SendUpdates { get; set; }

            /// <summary>
            /// Whether to send notifications about the creation of the new event. Note that some emails might still be
            /// sent. The default is false.
            /// </summary>
            public enum SendUpdatesEnum
            {
                /// <summary>Notifications are sent to all guests.</summary>
                [Google.Apis.Util.StringValueAttribute("all")]
                All = 0,

                /// <summary>Notifications are sent to non-Google Calendar guests only.</summary>
                [Google.Apis.Util.StringValueAttribute("externalOnly")]
                ExternalOnly = 1,

                /// <summary>
                /// No notifications are sent. Warning: Using the value none can have significant adverse effects,
                /// including events not syncing to external calendars or events being lost altogether for some users.
                /// For calendar migration tasks, consider using the events.import method instead.
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("none")]
                None = 2,
            }

            /// <summary>
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("supportsAttachments", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SupportsAttachments { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Event Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("conferenceDataVersion", new Google.Apis.Discovery.Parameter
                {
                    Name = "conferenceDataVersion",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxAttendees", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxAttendees",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendUpdates", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendUpdates",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("supportsAttachments", new Google.Apis.Discovery.Parameter
                {
                    Name = "supportsAttachments",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns instances of the specified recurring event.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="eventId">Recurring event identifier.</param>
        public virtual InstancesRequest Instances(string calendarId, string eventId)
        {
            return new InstancesRequest(this.service, calendarId, eventId);
        }

        /// <summary>Returns instances of the specified recurring event.</summary>
        public class InstancesRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Events>
        {
            /// <summary>Constructs a new Instances request.</summary>
            public InstancesRequest(Google.Apis.Services.IClientService service, string calendarId, string eventId) : base(service)
            {
                CalendarId = calendarId;
                EventId = eventId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Recurring event identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("eventId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string EventId { get; private set; }

            /// <summary>
            /// Deprecated and ignored. A value will always be returned in the email field for the organizer, creator
            /// and attendees, even if no real email address is available (i.e. a generated, non-working value will be
            /// provided).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("alwaysIncludeEmail", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> AlwaysIncludeEmail { get; set; }

            /// <summary>
            /// The maximum number of attendees to include in the response. If there are more than the specified number
            /// of attendees, only the participant is returned. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxAttendees", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxAttendees { get; set; }

            /// <summary>
            /// Maximum number of events returned on one result page. By default the value is 250 events. The page size
            /// can never be larger than 2500 events. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>The original start time of the instance in the result. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("originalStart", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string OriginalStart { get; set; }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Whether to include deleted events (with status equals "cancelled") in the result. Cancelled instances of
            /// recurring events will still be included if singleEvents is False. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("showDeleted", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowDeleted { get; set; }

            /// <summary>
            /// Upper bound (exclusive) for an event's start time to filter by. Optional. The default is not to filter
            /// by start time. Must be an RFC3339 timestamp with mandatory time zone offset.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeMax", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> TimeMax { get; set; }

            /// <summary>
            /// Lower bound (inclusive) for an event's end time to filter by. Optional. The default is not to filter by
            /// end time. Must be an RFC3339 timestamp with mandatory time zone offset.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeMin", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> TimeMin { get; set; }

            /// <summary>
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeZone", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string TimeZone { get; set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "instances";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/{eventId}/instances";

            /// <summary>Initializes Instances parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventId", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("alwaysIncludeEmail", new Google.Apis.Discovery.Parameter
                {
                    Name = "alwaysIncludeEmail",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxAttendees", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxAttendees",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("originalStart", new Google.Apis.Discovery.Parameter
                {
                    Name = "originalStart",
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
                RequestParameters.Add("showDeleted", new Google.Apis.Discovery.Parameter
                {
                    Name = "showDeleted",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeMax", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeMax",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeMin", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeMin",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeZone", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeZone",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns events on the specified calendar.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual ListRequest List(string calendarId)
        {
            return new ListRequest(this.service, calendarId);
        }

        /// <summary>Returns events on the specified calendar.</summary>
        public class ListRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Events>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Deprecated and ignored. A value will always be returned in the email field for the organizer, creator
            /// and attendees, even if no real email address is available (i.e. a generated, non-working value will be
            /// provided).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("alwaysIncludeEmail", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> AlwaysIncludeEmail { get; set; }

            /// <summary>
            /// Event types to return. Optional. Possible values are:  - "default"  - "focusTime"  - "outOfOffice"  -
            /// "workingLocation"This parameter can be repeated multiple times to return events of different types.
            /// Currently, these are the only allowed values for this field:  - ["default", "focusTime", "outOfOffice"]
            /// - ["default", "focusTime", "outOfOffice", "workingLocation"]  - ["workingLocation"] The default is
            /// ["default", "focusTime", "outOfOffice"]. Additional combinations of these four event types will be made
            /// available in later releases.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("eventTypes", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> EventTypes { get; set; }

            /// <summary>
            /// Specifies an event ID in the iCalendar format to be provided in the response. Optional. Use this if you
            /// want to search for an event by its iCalendar ID.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("iCalUID", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ICalUID { get; set; }

            /// <summary>
            /// The maximum number of attendees to include in the response. If there are more than the specified number
            /// of attendees, only the participant is returned. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxAttendees", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxAttendees { get; set; }

            /// <summary>
            /// Maximum number of events returned on one result page. The number of events in the resulting page may be
            /// less than this value, or none at all, even if there are more events matching the query. Incomplete pages
            /// can be detected by a non-empty nextPageToken field in the response. By default the value is 250 events.
            /// The page size can never be larger than 2500 events. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>
            /// The order of the events returned in the result. Optional. The default is an unspecified, stable order.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("orderBy", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<OrderByEnum> OrderBy { get; set; }

            /// <summary>
            /// The order of the events returned in the result. Optional. The default is an unspecified, stable order.
            /// </summary>
            public enum OrderByEnum
            {
                /// <summary>
                /// Order by the start date/time (ascending). This is only available when querying single events (i.e.
                /// the parameter singleEvents is True)
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("startTime")]
                StartTime = 0,

                /// <summary>Order by last modification time (ascending).</summary>
                [Google.Apis.Util.StringValueAttribute("updated")]
                Updated = 1,
            }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Extended properties constraint specified as propertyName=value. Matches only private properties. This
            /// parameter might be repeated multiple times to return events that match all given constraints.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("privateExtendedProperty", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> PrivateExtendedProperty { get; set; }

            /// <summary>
            /// Free text search terms to find events that match these terms in the following fields: summary,
            /// description, location, attendee's displayName, attendee's email. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("q", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Q { get; set; }

            /// <summary>
            /// Extended properties constraint specified as propertyName=value. Matches only shared properties. This
            /// parameter might be repeated multiple times to return events that match all given constraints.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sharedExtendedProperty", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> SharedExtendedProperty { get; set; }

            /// <summary>
            /// Whether to include deleted events (with status equals "cancelled") in the result. Cancelled instances of
            /// recurring events (but not the underlying recurring event) will still be included if showDeleted and
            /// singleEvents are both False. If showDeleted and singleEvents are both True, only single instances of
            /// deleted events (but not the underlying recurring events) are returned. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("showDeleted", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowDeleted { get; set; }

            /// <summary>Whether to include hidden invitations in the result. Optional. The default is False.</summary>
            [Google.Apis.Util.RequestParameterAttribute("showHiddenInvitations", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowHiddenInvitations { get; set; }

            /// <summary>
            /// Whether to expand recurring events into instances and only return single one-off events and instances of
            /// recurring events, but not the underlying recurring events themselves. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("singleEvents", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SingleEvents { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. All
            /// events deleted since the previous list request will always be in the result set and it is not allowed to
            /// set showDeleted to False. There are several query parameters that cannot be specified together with
            /// nextSyncToken to ensure consistency of the client state.  These are:  - iCalUID  - orderBy  -
            /// privateExtendedProperty  - q  - sharedExtendedProperty  - timeMin  - timeMax  - updatedMin All other
            /// query parameters should be the same as for the initial synchronization to avoid undefined behavior. If
            /// the syncToken expires, the server will respond with a 410 GONE response code and the client should clear
            /// its storage and perform a full synchronization without any syncToken. Learn more about incremental
            /// synchronization. Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>
            /// Upper bound (exclusive) for an event's start time to filter by. Optional. The default is not to filter
            /// by start time. Must be an RFC3339 timestamp with mandatory time zone offset, for example,
            /// 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but are ignored. If
            /// timeMin is set, timeMax must be greater than timeMin.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeMax", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> TimeMax { get; set; }

            /// <summary>
            /// Lower bound (exclusive) for an event's end time to filter by. Optional. The default is not to filter by
            /// end time. Must be an RFC3339 timestamp with mandatory time zone offset, for example,
            /// 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but are ignored. If
            /// timeMax is set, timeMin must be smaller than timeMax.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeMin", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> TimeMin { get; set; }

            /// <summary>
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeZone", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string TimeZone { get; set; }

            /// <summary>
            /// Lower bound for an event's last modification time (as a RFC3339 timestamp) to filter by. When specified,
            /// entries deleted since this time will always be included regardless of showDeleted. Optional. The default
            /// is not to filter by last modification time.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("updatedMin", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> UpdatedMin { get; set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("alwaysIncludeEmail", new Google.Apis.Discovery.Parameter
                {
                    Name = "alwaysIncludeEmail",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventTypes", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventTypes",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("iCalUID", new Google.Apis.Discovery.Parameter
                {
                    Name = "iCalUID",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxAttendees", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxAttendees",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "250",
                    Pattern = null,
                });
                RequestParameters.Add("orderBy", new Google.Apis.Discovery.Parameter
                {
                    Name = "orderBy",
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
                RequestParameters.Add("privateExtendedProperty", new Google.Apis.Discovery.Parameter
                {
                    Name = "privateExtendedProperty",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("q", new Google.Apis.Discovery.Parameter
                {
                    Name = "q",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sharedExtendedProperty", new Google.Apis.Discovery.Parameter
                {
                    Name = "sharedExtendedProperty",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("showDeleted", new Google.Apis.Discovery.Parameter
                {
                    Name = "showDeleted",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("showHiddenInvitations", new Google.Apis.Discovery.Parameter
                {
                    Name = "showHiddenInvitations",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("singleEvents", new Google.Apis.Discovery.Parameter
                {
                    Name = "singleEvents",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeMax", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeMax",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeMin", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeMin",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeZone", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeZone",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("updatedMin", new Google.Apis.Discovery.Parameter
                {
                    Name = "updatedMin",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Moves an event to another calendar, i.e. changes an event's organizer.</summary>
        /// <param name="calendarId">Calendar identifier of the source calendar where the event currently is on.</param>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="destination">
        /// Calendar identifier of the target calendar where the event is to be moved to.
        /// </param>
        public virtual MoveRequest Move(string calendarId, string eventId, string destination)
        {
            return new MoveRequest(this.service, calendarId, eventId, destination);
        }

        /// <summary>Moves an event to another calendar, i.e. changes an event's organizer.</summary>
        public class MoveRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Event>
        {
            /// <summary>Constructs a new Move request.</summary>
            public MoveRequest(Google.Apis.Services.IClientService service, string calendarId, string eventId, string destination) : base(service)
            {
                CalendarId = calendarId;
                EventId = eventId;
                Destination = destination;
                InitParameters();
            }

            /// <summary>Calendar identifier of the source calendar where the event currently is on.</summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Event identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("eventId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string EventId { get; private set; }

            /// <summary>Calendar identifier of the target calendar where the event is to be moved to.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destination", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Destination { get; private set; }

            /// <summary>
            /// Deprecated. Please use sendUpdates instead.  Whether to send notifications about the change of the
            /// event's organizer. Note that some emails might still be sent even if you set the value to false. The
            /// default is false.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>Guests who should receive notifications about the change of the event's organizer.</summary>
            [Google.Apis.Util.RequestParameterAttribute("sendUpdates", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<SendUpdatesEnum> SendUpdates { get; set; }

            /// <summary>Guests who should receive notifications about the change of the event's organizer.</summary>
            public enum SendUpdatesEnum
            {
                /// <summary>Notifications are sent to all guests.</summary>
                [Google.Apis.Util.StringValueAttribute("all")]
                All = 0,

                /// <summary>Notifications are sent to non-Google Calendar guests only.</summary>
                [Google.Apis.Util.StringValueAttribute("externalOnly")]
                ExternalOnly = 1,

                /// <summary>
                /// No notifications are sent. For calendar migration tasks, consider using the Events.import method
                /// instead.
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("none")]
                None = 2,
            }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "move";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/{eventId}/move";

            /// <summary>Initializes Move parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventId", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destination", new Google.Apis.Discovery.Parameter
                {
                    Name = "destination",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendUpdates", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendUpdates",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Updates an event. This method supports patch semantics.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="eventId">Event identifier.</param>
        public virtual PatchRequest Patch(Google.Apis.Calendar.v3.Data.Event body, string calendarId, string eventId)
        {
            return new PatchRequest(this.service, body, calendarId, eventId);
        }

        /// <summary>Updates an event. This method supports patch semantics.</summary>
        public class PatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Event>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Event body, string calendarId, string eventId) : base(service)
            {
                CalendarId = calendarId;
                EventId = eventId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Event identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("eventId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string EventId { get; private set; }

            /// <summary>
            /// Deprecated and ignored. A value will always be returned in the email field for the organizer, creator
            /// and attendees, even if no real email address is available (i.e. a generated, non-working value will be
            /// provided).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("alwaysIncludeEmail", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> AlwaysIncludeEmail { get; set; }

            /// <summary>
            /// Version number of conference data supported by the API client. Version 0 assumes no conference data
            /// support and ignores conference data in the event's body. Version 1 enables support for copying of
            /// ConferenceData as well as for creating new conferences using the createRequest field of conferenceData.
            /// The default is 0.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("conferenceDataVersion", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> ConferenceDataVersion { get; set; }

            /// <summary>
            /// The maximum number of attendees to include in the response. If there are more than the specified number
            /// of attendees, only the participant is returned. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxAttendees", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxAttendees { get; set; }

            /// <summary>
            /// Deprecated. Please use sendUpdates instead.  Whether to send notifications about the event update (for
            /// example, description changes, etc.). Note that some emails might still be sent even if you set the value
            /// to false. The default is false.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>
            /// Guests who should receive notifications about the event update (for example, title changes, etc.).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendUpdates", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<SendUpdatesEnum> SendUpdates { get; set; }

            /// <summary>
            /// Guests who should receive notifications about the event update (for example, title changes, etc.).
            /// </summary>
            public enum SendUpdatesEnum
            {
                /// <summary>Notifications are sent to all guests.</summary>
                [Google.Apis.Util.StringValueAttribute("all")]
                All = 0,

                /// <summary>Notifications are sent to non-Google Calendar guests only.</summary>
                [Google.Apis.Util.StringValueAttribute("externalOnly")]
                ExternalOnly = 1,

                /// <summary>
                /// No notifications are sent. For calendar migration tasks, consider using the Events.import method
                /// instead.
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("none")]
                None = 2,
            }

            /// <summary>
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("supportsAttachments", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SupportsAttachments { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Event Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/{eventId}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventId", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("alwaysIncludeEmail", new Google.Apis.Discovery.Parameter
                {
                    Name = "alwaysIncludeEmail",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("conferenceDataVersion", new Google.Apis.Discovery.Parameter
                {
                    Name = "conferenceDataVersion",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxAttendees", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxAttendees",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendUpdates", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendUpdates",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("supportsAttachments", new Google.Apis.Discovery.Parameter
                {
                    Name = "supportsAttachments",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Creates an event based on a simple text string.</summary>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="text">The text describing the event to be created.</param>
        public virtual QuickAddRequest QuickAdd(string calendarId, string text)
        {
            return new QuickAddRequest(this.service, calendarId, text);
        }

        /// <summary>Creates an event based on a simple text string.</summary>
        public class QuickAddRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Event>
        {
            /// <summary>Constructs a new QuickAdd request.</summary>
            public QuickAddRequest(Google.Apis.Services.IClientService service, string calendarId, string text) : base(service)
            {
                CalendarId = calendarId;
                Text = text;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>The text describing the event to be created.</summary>
            [Google.Apis.Util.RequestParameterAttribute("text", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Text { get; private set; }

            /// <summary>
            /// Deprecated. Please use sendUpdates instead.  Whether to send notifications about the creation of the
            /// event. Note that some emails might still be sent even if you set the value to false. The default is
            /// false.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>Guests who should receive notifications about the creation of the new event.</summary>
            [Google.Apis.Util.RequestParameterAttribute("sendUpdates", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<SendUpdatesEnum> SendUpdates { get; set; }

            /// <summary>Guests who should receive notifications about the creation of the new event.</summary>
            public enum SendUpdatesEnum
            {
                /// <summary>Notifications are sent to all guests.</summary>
                [Google.Apis.Util.StringValueAttribute("all")]
                All = 0,

                /// <summary>Notifications are sent to non-Google Calendar guests only.</summary>
                [Google.Apis.Util.StringValueAttribute("externalOnly")]
                ExternalOnly = 1,

                /// <summary>
                /// No notifications are sent. For calendar migration tasks, consider using the Events.import method
                /// instead.
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("none")]
                None = 2,
            }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "quickAdd";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/quickAdd";

            /// <summary>Initializes QuickAdd parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("text", new Google.Apis.Discovery.Parameter
                {
                    Name = "text",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendUpdates", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendUpdates",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Updates an event.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        /// <param name="eventId">Event identifier.</param>
        public virtual UpdateRequest Update(Google.Apis.Calendar.v3.Data.Event body, string calendarId, string eventId)
        {
            return new UpdateRequest(this.service, body, calendarId, eventId);
        }

        /// <summary>Updates an event.</summary>
        public class UpdateRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Event>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Event body, string calendarId, string eventId) : base(service)
            {
                CalendarId = calendarId;
                EventId = eventId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>Event identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("eventId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string EventId { get; private set; }

            /// <summary>
            /// Deprecated and ignored. A value will always be returned in the email field for the organizer, creator
            /// and attendees, even if no real email address is available (i.e. a generated, non-working value will be
            /// provided).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("alwaysIncludeEmail", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> AlwaysIncludeEmail { get; set; }

            /// <summary>
            /// Version number of conference data supported by the API client. Version 0 assumes no conference data
            /// support and ignores conference data in the event's body. Version 1 enables support for copying of
            /// ConferenceData as well as for creating new conferences using the createRequest field of conferenceData.
            /// The default is 0.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("conferenceDataVersion", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> ConferenceDataVersion { get; set; }

            /// <summary>
            /// The maximum number of attendees to include in the response. If there are more than the specified number
            /// of attendees, only the participant is returned. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxAttendees", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxAttendees { get; set; }

            /// <summary>
            /// Deprecated. Please use sendUpdates instead.  Whether to send notifications about the event update (for
            /// example, description changes, etc.). Note that some emails might still be sent even if you set the value
            /// to false. The default is false.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendNotifications", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SendNotifications { get; set; }

            /// <summary>
            /// Guests who should receive notifications about the event update (for example, title changes, etc.).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sendUpdates", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<SendUpdatesEnum> SendUpdates { get; set; }

            /// <summary>
            /// Guests who should receive notifications about the event update (for example, title changes, etc.).
            /// </summary>
            public enum SendUpdatesEnum
            {
                /// <summary>Notifications are sent to all guests.</summary>
                [Google.Apis.Util.StringValueAttribute("all")]
                All = 0,

                /// <summary>Notifications are sent to non-Google Calendar guests only.</summary>
                [Google.Apis.Util.StringValueAttribute("externalOnly")]
                ExternalOnly = 1,

                /// <summary>
                /// No notifications are sent. For calendar migration tasks, consider using the Events.import method
                /// instead.
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("none")]
                None = 2,
            }

            /// <summary>
            /// Whether API client performing operation supports event attachments. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("supportsAttachments", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SupportsAttachments { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Event Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/{eventId}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventId", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("alwaysIncludeEmail", new Google.Apis.Discovery.Parameter
                {
                    Name = "alwaysIncludeEmail",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("conferenceDataVersion", new Google.Apis.Discovery.Parameter
                {
                    Name = "conferenceDataVersion",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxAttendees", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxAttendees",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendNotifications", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendNotifications",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sendUpdates", new Google.Apis.Discovery.Parameter
                {
                    Name = "sendUpdates",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("supportsAttachments", new Google.Apis.Discovery.Parameter
                {
                    Name = "supportsAttachments",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Watch for changes to Events resources.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="calendarId">
        /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the
        /// primary calendar of the currently logged in user, use the "primary" keyword.
        /// </param>
        public virtual WatchRequest Watch(Google.Apis.Calendar.v3.Data.Channel body, string calendarId)
        {
            return new WatchRequest(this.service, body, calendarId);
        }

        /// <summary>Watch for changes to Events resources.</summary>
        public class WatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Channel>
        {
            /// <summary>Constructs a new Watch request.</summary>
            public WatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Channel body, string calendarId) : base(service)
            {
                CalendarId = calendarId;
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access
            /// the primary calendar of the currently logged in user, use the "primary" keyword.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("calendarId", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string CalendarId { get; private set; }

            /// <summary>
            /// Deprecated and ignored. A value will always be returned in the email field for the organizer, creator
            /// and attendees, even if no real email address is available (i.e. a generated, non-working value will be
            /// provided).
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("alwaysIncludeEmail", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> AlwaysIncludeEmail { get; set; }

            /// <summary>
            /// Event types to return. Optional. Possible values are:  - "default"  - "focusTime"  - "outOfOffice"  -
            /// "workingLocation"This parameter can be repeated multiple times to return events of different types.
            /// Currently, these are the only allowed values for this field:  - ["default", "focusTime", "outOfOffice"]
            /// - ["default", "focusTime", "outOfOffice", "workingLocation"]  - ["workingLocation"] The default is
            /// ["default", "focusTime", "outOfOffice"]. Additional combinations of these four event types will be made
            /// available in later releases.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("eventTypes", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> EventTypes { get; set; }

            /// <summary>
            /// Specifies an event ID in the iCalendar format to be provided in the response. Optional. Use this if you
            /// want to search for an event by its iCalendar ID.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("iCalUID", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ICalUID { get; set; }

            /// <summary>
            /// The maximum number of attendees to include in the response. If there are more than the specified number
            /// of attendees, only the participant is returned. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxAttendees", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxAttendees { get; set; }

            /// <summary>
            /// Maximum number of events returned on one result page. The number of events in the resulting page may be
            /// less than this value, or none at all, even if there are more events matching the query. Incomplete pages
            /// can be detected by a non-empty nextPageToken field in the response. By default the value is 250 events.
            /// The page size can never be larger than 2500 events. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>
            /// The order of the events returned in the result. Optional. The default is an unspecified, stable order.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("orderBy", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<OrderByEnum> OrderBy { get; set; }

            /// <summary>
            /// The order of the events returned in the result. Optional. The default is an unspecified, stable order.
            /// </summary>
            public enum OrderByEnum
            {
                /// <summary>
                /// Order by the start date/time (ascending). This is only available when querying single events (i.e.
                /// the parameter singleEvents is True)
                /// </summary>
                [Google.Apis.Util.StringValueAttribute("startTime")]
                StartTime = 0,

                /// <summary>Order by last modification time (ascending).</summary>
                [Google.Apis.Util.StringValueAttribute("updated")]
                Updated = 1,
            }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Extended properties constraint specified as propertyName=value. Matches only private properties. This
            /// parameter might be repeated multiple times to return events that match all given constraints.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("privateExtendedProperty", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> PrivateExtendedProperty { get; set; }

            /// <summary>
            /// Free text search terms to find events that match these terms in the following fields: summary,
            /// description, location, attendee's displayName, attendee's email. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("q", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Q { get; set; }

            /// <summary>
            /// Extended properties constraint specified as propertyName=value. Matches only shared properties. This
            /// parameter might be repeated multiple times to return events that match all given constraints.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("sharedExtendedProperty", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> SharedExtendedProperty { get; set; }

            /// <summary>
            /// Whether to include deleted events (with status equals "cancelled") in the result. Cancelled instances of
            /// recurring events (but not the underlying recurring event) will still be included if showDeleted and
            /// singleEvents are both False. If showDeleted and singleEvents are both True, only single instances of
            /// deleted events (but not the underlying recurring events) are returned. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("showDeleted", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowDeleted { get; set; }

            /// <summary>Whether to include hidden invitations in the result. Optional. The default is False.</summary>
            [Google.Apis.Util.RequestParameterAttribute("showHiddenInvitations", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> ShowHiddenInvitations { get; set; }

            /// <summary>
            /// Whether to expand recurring events into instances and only return single one-off events and instances of
            /// recurring events, but not the underlying recurring events themselves. Optional. The default is False.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("singleEvents", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> SingleEvents { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. All
            /// events deleted since the previous list request will always be in the result set and it is not allowed to
            /// set showDeleted to False. There are several query parameters that cannot be specified together with
            /// nextSyncToken to ensure consistency of the client state.  These are:  - iCalUID  - orderBy  -
            /// privateExtendedProperty  - q  - sharedExtendedProperty  - timeMin  - timeMax  - updatedMin All other
            /// query parameters should be the same as for the initial synchronization to avoid undefined behavior. If
            /// the syncToken expires, the server will respond with a 410 GONE response code and the client should clear
            /// its storage and perform a full synchronization without any syncToken. Learn more about incremental
            /// synchronization. Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>
            /// Upper bound (exclusive) for an event's start time to filter by. Optional. The default is not to filter
            /// by start time. Must be an RFC3339 timestamp with mandatory time zone offset, for example,
            /// 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but are ignored. If
            /// timeMin is set, timeMax must be greater than timeMin.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeMax", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> TimeMax { get; set; }

            /// <summary>
            /// Lower bound (exclusive) for an event's end time to filter by. Optional. The default is not to filter by
            /// end time. Must be an RFC3339 timestamp with mandatory time zone offset, for example,
            /// 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but are ignored. If
            /// timeMax is set, timeMin must be smaller than timeMax.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeMin", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> TimeMin { get; set; }

            /// <summary>
            /// Time zone used in the response. Optional. The default is the time zone of the calendar.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("timeZone", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string TimeZone { get; set; }

            /// <summary>
            /// Lower bound for an event's last modification time (as a RFC3339 timestamp) to filter by. When specified,
            /// entries deleted since this time will always be included regardless of showDeleted. Optional. The default
            /// is not to filter by last modification time.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("updatedMin", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<System.DateTime> UpdatedMin { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Channel Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "watch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "calendars/{calendarId}/events/watch";

            /// <summary>Initializes Watch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("calendarId", new Google.Apis.Discovery.Parameter
                {
                    Name = "calendarId",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("alwaysIncludeEmail", new Google.Apis.Discovery.Parameter
                {
                    Name = "alwaysIncludeEmail",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("eventTypes", new Google.Apis.Discovery.Parameter
                {
                    Name = "eventTypes",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("iCalUID", new Google.Apis.Discovery.Parameter
                {
                    Name = "iCalUID",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxAttendees", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxAttendees",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "250",
                    Pattern = null,
                });
                RequestParameters.Add("orderBy", new Google.Apis.Discovery.Parameter
                {
                    Name = "orderBy",
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
                RequestParameters.Add("privateExtendedProperty", new Google.Apis.Discovery.Parameter
                {
                    Name = "privateExtendedProperty",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("q", new Google.Apis.Discovery.Parameter
                {
                    Name = "q",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sharedExtendedProperty", new Google.Apis.Discovery.Parameter
                {
                    Name = "sharedExtendedProperty",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("showDeleted", new Google.Apis.Discovery.Parameter
                {
                    Name = "showDeleted",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("showHiddenInvitations", new Google.Apis.Discovery.Parameter
                {
                    Name = "showHiddenInvitations",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("singleEvents", new Google.Apis.Discovery.Parameter
                {
                    Name = "singleEvents",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeMax", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeMax",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeMin", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeMin",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("timeZone", new Google.Apis.Discovery.Parameter
                {
                    Name = "timeZone",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("updatedMin", new Google.Apis.Discovery.Parameter
                {
                    Name = "updatedMin",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }
    }

    /// <summary>The "freebusy" collection of methods.</summary>
    public class FreebusyResource
    {
        private const string Resource = "freebusy";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public FreebusyResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Returns free/busy information for a set of calendars.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual QueryRequest Query(Google.Apis.Calendar.v3.Data.FreeBusyRequest body)
        {
            return new QueryRequest(this.service, body);
        }

        /// <summary>Returns free/busy information for a set of calendars.</summary>
        public class QueryRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.FreeBusyResponse>
        {
            /// <summary>Constructs a new Query request.</summary>
            public QueryRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.FreeBusyRequest body) : base(service)
            {
                Body = body;
                InitParameters();
            }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.FreeBusyRequest Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "query";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "freeBusy";

            /// <summary>Initializes Query parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
            }
        }
    }

    /// <summary>The "settings" collection of methods.</summary>
    public class SettingsResource
    {
        private const string Resource = "settings";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public SettingsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
        }

        /// <summary>Returns a single user setting.</summary>
        /// <param name="setting">The id of the user setting.</param>
        public virtual GetRequest Get(string setting)
        {
            return new GetRequest(this.service, setting);
        }

        /// <summary>Returns a single user setting.</summary>
        public class GetRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Setting>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string setting) : base(service)
            {
                Setting = setting;
                InitParameters();
            }

            /// <summary>The id of the user setting.</summary>
            [Google.Apis.Util.RequestParameterAttribute("setting", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Setting { get; private set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/settings/{setting}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("setting", new Google.Apis.Discovery.Parameter
                {
                    Name = "setting",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Returns all user settings for the authenticated user.</summary>
        public virtual ListRequest List()
        {
            return new ListRequest(this.service);
        }

        /// <summary>Returns all user settings for the authenticated user.</summary>
        public class ListRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Settings>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service) : base(service)
            {
                InitParameters();
            }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page
            /// size can never be larger than 250 entries. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. If
            /// the syncToken expires, the server will respond with a 410 GONE response code and the client should clear
            /// its storage and perform a full synchronization without any syncToken. Learn more about incremental
            /// synchronization. Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/settings";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
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
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }

        /// <summary>Watch for changes to Settings resources.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual WatchRequest Watch(Google.Apis.Calendar.v3.Data.Channel body)
        {
            return new WatchRequest(this.service, body);
        }

        /// <summary>Watch for changes to Settings resources.</summary>
        public class WatchRequest : CalendarBaseServiceRequest<Google.Apis.Calendar.v3.Data.Channel>
        {
            /// <summary>Constructs a new Watch request.</summary>
            public WatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Calendar.v3.Data.Channel body) : base(service)
            {
                Body = body;
                InitParameters();
            }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page
            /// size can never be larger than 250 entries. Optional.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> MaxResults { get; set; }

            /// <summary>Token specifying which result page to return. Optional.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>
            /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list
            /// request. It makes the result of this list request contain only entries that have changed since then. If
            /// the syncToken expires, the server will respond with a 410 GONE response code and the client should clear
            /// its storage and perform a full synchronization without any syncToken. Learn more about incremental
            /// synchronization. Optional. The default is to return all entries.
            /// </summary>
            [Google.Apis.Util.RequestParameterAttribute("syncToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string SyncToken { get; set; }

            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Calendar.v3.Data.Channel Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "watch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "users/me/settings/watch";

            /// <summary>Initializes Watch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
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
                RequestParameters.Add("syncToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "syncToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }
        }
    }
}
namespace Google.Apis.Calendar.v3.Data
{
    public class Acl : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>ETag of the collection.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>List of rules on the access control list.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<AclRule> Items { get; set; }

        /// <summary>Type of the collection ("calendar#acl").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// Token used to access the next page of this result. Omitted if no further results are available, in which
        /// case nextSyncToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; }

        /// <summary>
        /// Token used at a later point in time to retrieve only the entries that have changed since this result was
        /// returned. Omitted if further results are available, in which case nextPageToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextSyncToken")]
        public virtual string NextSyncToken { get; set; }
    }

    public class AclRule : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>ETag of the resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>Identifier of the Access Control List (ACL) rule. See Sharing calendars.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>Type of the resource ("calendar#aclRule").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// The role assigned to the scope. Possible values are:   - "none" - Provides no access.  - "freeBusyReader" -
        /// Provides read access to free/busy information.  - "reader" - Provides read access to the calendar. Private
        /// events will appear to users with reader access, but event details will be hidden.  - "writer" - Provides
        /// read and write access to the calendar. Private events will appear to users with writer access, and event
        /// details will be visible.  - "owner" - Provides ownership of the calendar. This role has all of the
        /// permissions of the writer role with the additional ability to see and manipulate ACLs.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("role")]
        public virtual string Role { get; set; }

        /// <summary>The extent to which calendar access is granted by this ACL rule.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("scope")]
        public virtual ScopeData Scope { get; set; }

        /// <summary>The extent to which calendar access is granted by this ACL rule.</summary>
        public class ScopeData
        {
            /// <summary>
            /// The type of the scope. Possible values are:   - "default" - The public scope. This is the default value.
            ///  - "user" - Limits the scope to a single user.  - "group" - Limits the scope to a group.  - "domain" -
            /// Limits the scope to a domain.  Note: The permissions granted to the "default", or public, scope apply to
            /// any user, authenticated or not.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("type")]
            public virtual string Type { get; set; }

            /// <summary>
            /// The email address of a user or group, or the name of a domain, depending on the scope type. Omitted for
            /// type "default".
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("value")]
            public virtual string Value { get; set; }
        }
    }

    public class Calendar : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// Conferencing properties for this calendar, for example what types of conferences are allowed.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("conferenceProperties")]
        public virtual ConferenceProperties ConferenceProperties { get; set; }

        /// <summary>Description of the calendar. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>ETag of the resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>Identifier of the calendar. To retrieve IDs call the calendarList.list() method.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>Type of the resource ("calendar#calendar").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>Geographic location of the calendar as free-form text. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("location")]
        public virtual string Location { get; set; }

        /// <summary>Title of the calendar.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("summary")]
        public virtual string Summary { get; set; }

        /// <summary>
        /// The time zone of the calendar. (Formatted as an IANA Time Zone Database name, e.g. "Europe/Zurich".)
        /// Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeZone")]
        public virtual string TimeZone { get; set; }
    }

    public class CalendarList : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>ETag of the collection.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>Calendars that are present on the user's calendar list.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<CalendarListEntry> Items { get; set; }

        /// <summary>Type of the collection ("calendar#calendarList").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// Token used to access the next page of this result. Omitted if no further results are available, in which
        /// case nextSyncToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; }

        /// <summary>
        /// Token used at a later point in time to retrieve only the entries that have changed since this result was
        /// returned. Omitted if further results are available, in which case nextPageToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextSyncToken")]
        public virtual string NextSyncToken { get; set; }
    }

    public class CalendarListEntry : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The effective access role that the authenticated user has on the calendar. Read-only. Possible values are:
        /// - "freeBusyReader" - Provides read access to free/busy information.  - "reader" - Provides read access to
        /// the calendar. Private events will appear to users with reader access, but event details will be hidden.  -
        /// "writer" - Provides read and write access to the calendar. Private events will appear to users with writer
        /// access, and event details will be visible.  - "owner" - Provides ownership of the calendar. This role has
        /// all of the permissions of the writer role with the additional ability to see and manipulate ACLs.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("accessRole")]
        public virtual string AccessRole { get; set; }

        /// <summary>
        /// The main color of the calendar in the hexadecimal format "#0088aa". This property supersedes the index-based
        /// colorId property. To set or change this property, you need to specify colorRgbFormat=true in the parameters
        /// of the insert, update and patch methods. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("backgroundColor")]
        public virtual string BackgroundColor { get; set; }

        /// <summary>
        /// The color of the calendar. This is an ID referring to an entry in the calendar section of the colors
        /// definition (see the colors endpoint). This property is superseded by the backgroundColor and foregroundColor
        /// properties and can be ignored when using these properties. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("colorId")]
        public virtual string ColorId { get; set; }

        /// <summary>
        /// Conferencing properties for this calendar, for example what types of conferences are allowed.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("conferenceProperties")]
        public virtual ConferenceProperties ConferenceProperties { get; set; }

        /// <summary>The default reminders that the authenticated user has for this calendar.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("defaultReminders")]
        public virtual System.Collections.Generic.IList<EventReminder> DefaultReminders { get; set; }

        /// <summary>
        /// Whether this calendar list entry has been deleted from the calendar list. Read-only. Optional. The default
        /// is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("deleted")]
        public virtual System.Nullable<bool> Deleted { get; set; }

        /// <summary>Description of the calendar. Optional. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>ETag of the resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>
        /// The foreground color of the calendar in the hexadecimal format "#ffffff". This property supersedes the
        /// index-based colorId property. To set or change this property, you need to specify colorRgbFormat=true in the
        /// parameters of the insert, update and patch methods. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("foregroundColor")]
        public virtual string ForegroundColor { get; set; }

        /// <summary>
        /// Whether the calendar has been hidden from the list. Optional. The attribute is only returned when the
        /// calendar is hidden, in which case the value is true.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("hidden")]
        public virtual System.Nullable<bool> Hidden { get; set; }

        /// <summary>Identifier of the calendar.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>Type of the resource ("calendar#calendarListEntry").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>Geographic location of the calendar as free-form text. Optional. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("location")]
        public virtual string Location { get; set; }

        /// <summary>The notifications that the authenticated user is receiving for this calendar.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("notificationSettings")]
        public virtual NotificationSettingsData NotificationSettings { get; set; }

        /// <summary>
        /// Whether the calendar is the primary calendar of the authenticated user. Read-only. Optional. The default is
        /// False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("primary")]
        public virtual System.Nullable<bool> Primary { get; set; }

        /// <summary>Whether the calendar content shows up in the calendar UI. Optional. The default is False.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("selected")]
        public virtual System.Nullable<bool> Selected { get; set; }

        /// <summary>Title of the calendar. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("summary")]
        public virtual string Summary { get; set; }

        /// <summary>The summary that the authenticated user has set for this calendar. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("summaryOverride")]
        public virtual string SummaryOverride { get; set; }

        /// <summary>The time zone of the calendar. Optional. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeZone")]
        public virtual string TimeZone { get; set; }

        /// <summary>The notifications that the authenticated user is receiving for this calendar.</summary>
        public class NotificationSettingsData
        {
            /// <summary>The list of notifications set for this calendar.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("notifications")]
            public virtual System.Collections.Generic.IList<CalendarNotification> Notifications { get; set; }
        }
    }

    public class CalendarNotification : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The method used to deliver the notification. The possible value is:   - "email" - Notifications are sent via
        /// email.   Required when adding a notification.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("method")]
        public virtual string Method { get; set; }

        /// <summary>
        /// The type of notification. Possible values are:   - "eventCreation" - Notification sent when a new event is
        /// put on the calendar.  - "eventChange" - Notification sent when an event is changed.  - "eventCancellation" -
        /// Notification sent when an event is cancelled.  - "eventResponse" - Notification sent when an attendee
        /// responds to the event invitation.  - "agenda" - An agenda with the events of the day (sent out in the
        /// morning).   Required when adding a notification.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class Channel : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The address where notifications are delivered for this channel.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("address")]
        public virtual string Address { get; set; }

        /// <summary>
        /// Date and time of notification channel expiration, expressed as a Unix timestamp, in milliseconds. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("expiration")]
        public virtual System.Nullable<long> Expiration { get; set; }

        /// <summary>A UUID or similar unique string that identifies this channel.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>
        /// Identifies this as a notification channel used to watch for changes to a resource, which is "api#channel".
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>Additional parameters controlling delivery channel behavior. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("params")]
        public virtual System.Collections.Generic.IDictionary<string, string> Params__ { get; set; }

        /// <summary>A Boolean value to indicate whether payload is wanted. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("payload")]
        public virtual System.Nullable<bool> Payload { get; set; }

        /// <summary>
        /// An opaque ID that identifies the resource being watched on this channel. Stable across different API
        /// versions.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resourceId")]
        public virtual string ResourceId { get; set; }

        /// <summary>A version-specific identifier for the watched resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resourceUri")]
        public virtual string ResourceUri { get; set; }

        /// <summary>
        /// An arbitrary string delivered to the target address with each notification delivered over this channel.
        /// Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("token")]
        public virtual string Token { get; set; }

        /// <summary>
        /// The type of delivery mechanism used for this channel. Valid values are "web_hook" (or "webhook"). Both
        /// values refer to a channel where Http requests are used to deliver messages.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ColorDefinition : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The background color associated with this color definition.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("background")]
        public virtual string Background { get; set; }

        /// <summary>
        /// The foreground color that can be used to write on top of a background with 'background' color.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("foreground")]
        public virtual string Foreground { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class Colors : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// A global palette of calendar colors, mapping from the color ID to its definition. A calendarListEntry
        /// resource refers to one of these color IDs in its colorId field. Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("calendar")]
        public virtual System.Collections.Generic.IDictionary<string, ColorDefinition> Calendar { get; set; }

        /// <summary>
        /// A global palette of event colors, mapping from the color ID to its definition. An event resource may refer
        /// to one of these color IDs in its colorId field. Read-only.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("event")]
        public virtual System.Collections.Generic.IDictionary<string, ColorDefinition> Event__ { get; set; }

        /// <summary>Type of the resource ("calendar#colors").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>Last modification time of the color palette (as a RFC3339 timestamp). Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("updated")]
        public virtual string UpdatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? UpdatedDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use UpdatedDateTimeOffset instead.")]
        public virtual System.DateTime? Updated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ConferenceData : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The ID of the conference. Can be used by developers to keep track of conferences, should not be displayed to
        /// users. The ID value is formed differently for each conference solution type:   - eventHangout: ID is not
        /// set. (This conference type is deprecated.) - eventNamedHangout: ID is the name of the Hangout. (This
        /// conference type is deprecated.) - hangoutsMeet: ID is the 10-letter meeting code, for example aaa-bbbb-ccc.
        /// - addOn: ID is defined by the third-party provider.  Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("conferenceId")]
        public virtual string ConferenceId { get; set; }

        /// <summary>
        /// The conference solution, such as Google Meet. Unset for a conference with a failed create request. Either
        /// conferenceSolution and at least one entryPoint, or createRequest is required.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("conferenceSolution")]
        public virtual ConferenceSolution ConferenceSolution { get; set; }

        /// <summary>
        /// A request to generate a new conference and attach it to the event. The data is generated asynchronously. To
        /// see whether the data is present check the status field. Either conferenceSolution and at least one
        /// entryPoint, or createRequest is required.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("createRequest")]
        public virtual CreateConferenceRequest CreateRequest { get; set; }

        /// <summary>
        /// Information about individual conference entry points, such as URLs or phone numbers. All of them must belong
        /// to the same conference. Either conferenceSolution and at least one entryPoint, or createRequest is required.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("entryPoints")]
        public virtual System.Collections.Generic.IList<EntryPoint> EntryPoints { get; set; }

        /// <summary>
        /// Additional notes (such as instructions from the domain administrator, legal notices) to display to the user.
        /// Can contain HTML. The maximum length is 2048 characters. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("notes")]
        public virtual string Notes { get; set; }

        /// <summary>
        /// Additional properties related to a conference. An example would be a solution-specific setting for enabling
        /// video streaming.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("parameters")]
        public virtual ConferenceParameters Parameters { get; set; }

        /// <summary>
        /// The signature of the conference data. Generated on server side. Unset for a conference with a failed create
        /// request. Optional for a conference with a pending create request.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("signature")]
        public virtual string Signature { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ConferenceParameters : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Additional add-on specific data.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("addOnParameters")]
        public virtual ConferenceParametersAddOnParameters AddOnParameters { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ConferenceParametersAddOnParameters : Google.Apis.Requests.IDirectResponseSchema
    {
        [Newtonsoft.Json.JsonPropertyAttribute("parameters")]
        public virtual System.Collections.Generic.IDictionary<string, string> Parameters { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ConferenceProperties : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The types of conference solutions that are supported for this calendar. The possible values are:   -
        /// "eventHangout"  - "eventNamedHangout"  - "hangoutsMeet"  Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("allowedConferenceSolutionTypes")]
        public virtual System.Collections.Generic.IList<string> AllowedConferenceSolutionTypes { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ConferenceRequestStatus : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The current status of the conference create request. Read-only. The possible values are:   - "pending": the
        /// conference create request is still being processed. - "success": the conference create request succeeded,
        /// the entry points are populated. - "failure": the conference create request failed, there are no entry
        /// points.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("statusCode")]
        public virtual string StatusCode { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ConferenceSolution : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The user-visible icon for this solution.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("iconUri")]
        public virtual string IconUri { get; set; }

        /// <summary>The key which can uniquely identify the conference solution for this event.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("key")]
        public virtual ConferenceSolutionKey Key { get; set; }

        /// <summary>The user-visible name of this solution. Not localized.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public virtual string Name { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class ConferenceSolutionKey : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The conference solution type. If a client encounters an unfamiliar or empty type, it should still be able to
        /// display the entry points. However, it should disallow modifications. The possible values are:   -
        /// "eventHangout" for Hangouts for consumers (deprecated; existing events may show this conference solution
        /// type but new conferences cannot be created) - "eventNamedHangout" for classic Hangouts for Google Workspace
        /// users (deprecated; existing events may show this conference solution type but new conferences cannot be
        /// created) - "hangoutsMeet" for Google Meet (http://meet.google.com) - "addOn" for 3P conference providers
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class CreateConferenceRequest : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The conference solution, such as Hangouts or Google Meet.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("conferenceSolutionKey")]
        public virtual ConferenceSolutionKey ConferenceSolutionKey { get; set; }

        /// <summary>
        /// The client-generated unique ID for this request. Clients should regenerate this ID for every new request. If
        /// an ID provided is the same as for the previous request, the request is ignored.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("requestId")]
        public virtual string RequestId { get; set; }

        /// <summary>The status of the conference create request.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("status")]
        public virtual ConferenceRequestStatus Status { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class EntryPoint : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The access code to access the conference. The maximum length is 128 characters. When creating new conference
        /// data, populate only the subset of {meetingCode, accessCode, passcode, password, pin} fields that match the
        /// terminology that the conference provider uses. Only the populated fields should be displayed. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("accessCode")]
        public virtual string AccessCode { get; set; }

        /// <summary>
        /// Features of the entry point, such as being toll or toll-free. One entry point can have multiple features.
        /// However, toll and toll-free cannot be both set on the same entry point.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("entryPointFeatures")]
        public virtual System.Collections.Generic.IList<string> EntryPointFeatures { get; set; }

        /// <summary>
        /// The type of the conference entry point. Possible values are:   - "video" - joining a conference over HTTP. A
        /// conference can have zero or one video entry point. - "phone" - joining a conference by dialing a phone
        /// number. A conference can have zero or more phone entry points. - "sip" - joining a conference over SIP. A
        /// conference can have zero or one sip entry point. - "more" - further conference joining instructions, for
        /// example additional phone numbers. A conference can have zero or one more entry point. A conference with only
        /// a more entry point is not a valid conference.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("entryPointType")]
        public virtual string EntryPointType { get; set; }

        /// <summary>
        /// The label for the URI. Visible to end users. Not localized. The maximum length is 512 characters. Examples:
        ///  - for video: meet.google.com/aaa-bbbb-ccc - for phone: +1 123 268 2601 - for sip: 12345678@altostrat.com -
        /// for more: should not be filled   Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("label")]
        public virtual string Label { get; set; }

        /// <summary>
        /// The meeting code to access the conference. The maximum length is 128 characters. When creating new
        /// conference data, populate only the subset of {meetingCode, accessCode, passcode, password, pin} fields that
        /// match the terminology that the conference provider uses. Only the populated fields should be displayed.
        /// Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("meetingCode")]
        public virtual string MeetingCode { get; set; }

        /// <summary>
        /// The passcode to access the conference. The maximum length is 128 characters. When creating new conference
        /// data, populate only the subset of {meetingCode, accessCode, passcode, password, pin} fields that match the
        /// terminology that the conference provider uses. Only the populated fields should be displayed.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("passcode")]
        public virtual string Passcode { get; set; }

        /// <summary>
        /// The password to access the conference. The maximum length is 128 characters. When creating new conference
        /// data, populate only the subset of {meetingCode, accessCode, passcode, password, pin} fields that match the
        /// terminology that the conference provider uses. Only the populated fields should be displayed. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("password")]
        public virtual string Password { get; set; }

        /// <summary>
        /// The PIN to access the conference. The maximum length is 128 characters. When creating new conference data,
        /// populate only the subset of {meetingCode, accessCode, passcode, password, pin} fields that match the
        /// terminology that the conference provider uses. Only the populated fields should be displayed. Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("pin")]
        public virtual string Pin { get; set; }

        /// <summary>
        /// The CLDR/ISO 3166 region code for the country associated with this phone access. Example: "SE" for Sweden.
        /// Calendar backend will populate this field only for EntryPointType.PHONE.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("regionCode")]
        public virtual string RegionCode { get; set; }

        /// <summary>
        /// The URI of the entry point. The maximum length is 1300 characters. Format:   - for video, http: or https:
        /// schema is required. - for phone, tel: schema is required. The URI should include the entire dial sequence
        /// (e.g., tel:+12345678900,,,123456789;1234). - for sip, sip: schema is required, e.g.,
        /// sip:12345678@myprovider.com. - for more, http: or https: schema is required.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("uri")]
        public virtual string Uri { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class Error : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Domain, or broad category, of the error.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("domain")]
        public virtual string Domain { get; set; }

        /// <summary>
        /// Specific reason for the error. Some of the possible values are:   - "groupTooBig" - The group of users
        /// requested is too large for a single query.  - "tooManyCalendarsRequested" - The number of calendars
        /// requested is too large for a single query.  - "notFound" - The requested resource was not found.  -
        /// "internalError" - The API service has encountered an internal error.  Additional error types may be added in
        /// the future, so clients should gracefully handle additional error statuses not included in this list.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("reason")]
        public virtual string Reason { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class Event : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// Whether anyone can invite themselves to the event (deprecated). Optional. The default is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("anyoneCanAddSelf")]
        public virtual System.Nullable<bool> AnyoneCanAddSelf { get; set; }

        /// <summary>
        /// File attachments for the event. In order to modify attachments the supportsAttachments request parameter
        /// should be set to true. There can be at most 25 attachments per event,
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("attachments")]
        public virtual System.Collections.Generic.IList<EventAttachment> Attachments { get; set; }

        /// <summary>
        /// The attendees of the event. See the Events with attendees guide for more information on scheduling events
        /// with other calendar users. Service accounts need to use domain-wide delegation of authority to populate the
        /// attendee list.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("attendees")]
        public virtual System.Collections.Generic.IList<EventAttendee> Attendees { get; set; }

        /// <summary>
        /// Whether attendees may have been omitted from the event's representation. When retrieving an event, this may
        /// be due to a restriction specified by the maxAttendee query parameter. When updating an event, this can be
        /// used to only update the participant's response. Optional. The default is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("attendeesOmitted")]
        public virtual System.Nullable<bool> AttendeesOmitted { get; set; }

        /// <summary>
        /// The color of the event. This is an ID referring to an entry in the event section of the colors definition
        /// (see the  colors endpoint). Optional.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("colorId")]
        public virtual string ColorId { get; set; }

        /// <summary>
        /// The conference-related information, such as details of a Google Meet conference. To create new conference
        /// details use the createRequest field. To persist your changes, remember to set the conferenceDataVersion
        /// request parameter to 1 for all event modification requests.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("conferenceData")]
        public virtual ConferenceData ConferenceData { get; set; }

        /// <summary>Creation time of the event (as a RFC3339 timestamp). Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("created")]
        public virtual string CreatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="CreatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? CreatedDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(CreatedRaw);
            set => CreatedRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="CreatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use CreatedDateTimeOffset instead.")]
        public virtual System.DateTime? Created
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(CreatedRaw);
            set => CreatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The creator of the event. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("creator")]
        public virtual CreatorData Creator { get; set; }

        /// <summary>Description of the event. Can contain HTML. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// The (exclusive) end time of the event. For a recurring event, this is the end time of the first instance.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("end")]
        public virtual EventDateTime End { get; set; }

        /// <summary>
        /// Whether the end time is actually unspecified. An end time is still provided for compatibility reasons, even
        /// if this attribute is set to True. The default is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("endTimeUnspecified")]
        public virtual System.Nullable<bool> EndTimeUnspecified { get; set; }

        /// <summary>ETag of the resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>
        /// Specific type of the event. This cannot be modified after the event is created. Possible values are:   -
        /// "default" - A regular event or not further specified.  - "outOfOffice" - An out-of-office event.  -
        /// "focusTime" - A focus-time event.  - "workingLocation" - A working location event.  Currently, only "default
        /// " and "workingLocation" events can be created using the API. Extended support for other event types will be
        /// made available in later releases.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("eventType")]
        public virtual string EventType { get; set; }

        /// <summary>Extended properties of the event.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("extendedProperties")]
        public virtual ExtendedPropertiesData ExtendedProperties { get; set; }

        /// <summary>
        /// A gadget that extends this event. Gadgets are deprecated; this structure is instead only used for returning
        /// birthday calendar metadata.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("gadget")]
        public virtual GadgetData Gadget { get; set; }

        /// <summary>
        /// Whether attendees other than the organizer can invite others to the event. Optional. The default is True.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("guestsCanInviteOthers")]
        public virtual System.Nullable<bool> GuestsCanInviteOthers { get; set; }

        /// <summary>
        /// Whether attendees other than the organizer can modify the event. Optional. The default is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("guestsCanModify")]
        public virtual System.Nullable<bool> GuestsCanModify { get; set; }

        /// <summary>
        /// Whether attendees other than the organizer can see who the event's attendees are. Optional. The default is
        /// True.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("guestsCanSeeOtherGuests")]
        public virtual System.Nullable<bool> GuestsCanSeeOtherGuests { get; set; }

        /// <summary>An absolute link to the Google Hangout associated with this event. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("hangoutLink")]
        public virtual string HangoutLink { get; set; }

        /// <summary>An absolute link to this event in the Google Calendar Web UI. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("htmlLink")]
        public virtual string HtmlLink { get; set; }

        /// <summary>
        /// Event unique identifier as defined in RFC5545. It is used to uniquely identify events accross calendaring
        /// systems and must be supplied when importing events via the import method. Note that the iCalUID and the id
        /// are not identical and only one of them should be supplied at event creation time. One difference in their
        /// semantics is that in recurring events, all occurrences of one event have different ids while they all share
        /// the same iCalUIDs. To retrieve an event using its iCalUID, call the events.list method using the iCalUID
        /// parameter. To retrieve an event using its id, call the events.get method.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("iCalUID")]
        public virtual string ICalUID { get; set; }

        /// <summary>
        /// Opaque identifier of the event. When creating new single or recurring events, you can specify their IDs.
        /// Provided IDs must follow these rules:   - characters allowed in the ID are those used in base32hex encoding,
        /// i.e. lowercase letters a-v and digits 0-9, see section 3.1.2 in RFC2938  - the length of the ID must be
        /// between 5 and 1024 characters  - the ID must be unique per calendar  Due to the globally distributed nature
        /// of the system, we cannot guarantee that ID collisions will be detected at event creation time. To minimize
        /// the risk of collisions we recommend using an established UUID algorithm such as one described in RFC4122. If
        /// you do not specify an ID, it will be automatically generated by the server. Note that the icalUID and the id
        /// are not identical and only one of them should be supplied at event creation time. One difference in their
        /// semantics is that in recurring events, all occurrences of one event have different ids while they all share
        /// the same icalUIDs.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>Type of the resource ("calendar#event").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>Geographic location of the event as free-form text. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("location")]
        public virtual string Location { get; set; }

        /// <summary>
        /// Whether this is a locked event copy where no changes can be made to the main event fields "summary",
        /// "description", "location", "start", "end" or "recurrence". The default is False. Read-Only.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("locked")]
        public virtual System.Nullable<bool> Locked { get; set; }

        /// <summary>
        /// The organizer of the event. If the organizer is also an attendee, this is indicated with a separate entry in
        /// attendees with the organizer field set to True. To change the organizer, use the move operation. Read-only,
        /// except when importing an event.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("organizer")]
        public virtual OrganizerData Organizer { get; set; }

        /// <summary>
        /// For an instance of a recurring event, this is the time at which this event would start according to the
        /// recurrence data in the recurring event identified by recurringEventId. It uniquely identifies the instance
        /// within the recurring event series even if the instance was moved to a different time. Immutable.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("originalStartTime")]
        public virtual EventDateTime OriginalStartTime { get; set; }

        /// <summary>
        /// If set to True, Event propagation is disabled. Note that it is not the same thing as Private event
        /// properties. Optional. Immutable. The default is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("privateCopy")]
        public virtual System.Nullable<bool> PrivateCopy { get; set; }

        /// <summary>
        /// List of RRULE, EXRULE, RDATE and EXDATE lines for a recurring event, as specified in RFC5545. Note that
        /// DTSTART and DTEND lines are not allowed in this field; event start and end times are specified in the start
        /// and end fields. This field is omitted for single events or instances of recurring events.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("recurrence")]
        public virtual System.Collections.Generic.IList<string> Recurrence { get; set; }

        /// <summary>
        /// For an instance of a recurring event, this is the id of the recurring event to which this instance belongs.
        /// Immutable.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("recurringEventId")]
        public virtual string RecurringEventId { get; set; }

        /// <summary>Information about the event's reminders for the authenticated user.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("reminders")]
        public virtual RemindersData Reminders { get; set; }

        /// <summary>Sequence number as per iCalendar.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("sequence")]
        public virtual System.Nullable<int> Sequence { get; set; }

        /// <summary>
        /// Source from which the event was created. For example, a web page, an email message or any document
        /// identifiable by an URL with HTTP or HTTPS scheme. Can only be seen or modified by the creator of the event.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("source")]
        public virtual SourceData Source { get; set; }

        /// <summary>
        /// The (inclusive) start time of the event. For a recurring event, this is the start time of the first
        /// instance.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("start")]
        public virtual EventDateTime Start { get; set; }

        /// <summary>
        /// Status of the event. Optional. Possible values are:   - "confirmed" - The event is confirmed. This is the
        /// default status.  - "tentative" - The event is tentatively confirmed.  - "cancelled" - The event is cancelled
        /// (deleted). The list method returns cancelled events only on incremental sync (when syncToken or updatedMin
        /// are specified) or if the showDeleted flag is set to true. The get method always returns them. A cancelled
        /// status represents two different states depending on the event type:   - Cancelled exceptions of an
        /// uncancelled recurring event indicate that this instance should no longer be presented to the user. Clients
        /// should store these events for the lifetime of the parent recurring event. Cancelled exceptions are only
        /// guaranteed to have values for the id, recurringEventId and originalStartTime fields populated. The other
        /// fields might be empty.   - All other cancelled events represent deleted events. Clients should remove their
        /// locally synced copies. Such cancelled events will eventually disappear, so do not rely on them being
        /// available indefinitely. Deleted events are only guaranteed to have the id field populated.   On the
        /// organizer's calendar, cancelled events continue to expose event details (summary, location, etc.) so that
        /// they can be restored (undeleted). Similarly, the events to which the user was invited and that they manually
        /// removed continue to provide details. However, incremental sync requests with showDeleted set to false will
        /// not return these details. If an event changes its organizer (for example via the move operation) and the
        /// original organizer is not on the attendee list, it will leave behind a cancelled event where only the id
        /// field is guaranteed to be populated.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("status")]
        public virtual string Status { get; set; }

        /// <summary>Title of the event.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("summary")]
        public virtual string Summary { get; set; }

        /// <summary>
        /// Whether the event blocks time on the calendar. Optional. Possible values are:   - "opaque" - Default value.
        /// The event does block time on the calendar. This is equivalent to setting Show me as to Busy in the Calendar
        /// UI.  - "transparent" - The event does not block time on the calendar. This is equivalent to setting Show me
        /// as to Available in the Calendar UI.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("transparency")]
        public virtual string Transparency { get; set; }

        /// <summary>Last modification time of the event (as a RFC3339 timestamp). Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("updated")]
        public virtual string UpdatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? UpdatedDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use UpdatedDateTimeOffset instead.")]
        public virtual System.DateTime? Updated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>
        /// Visibility of the event. Optional. Possible values are:   - "default" - Uses the default visibility for
        /// events on the calendar. This is the default value.  - "public" - The event is public and event details are
        /// visible to all readers of the calendar.  - "private" - The event is private and only event attendees may
        /// view event details.  - "confidential" - The event is private. This value is provided for compatibility
        /// reasons.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("visibility")]
        public virtual string Visibility { get; set; }

        /// <summary>Working location event data.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("workingLocationProperties")]
        public virtual EventWorkingLocationProperties WorkingLocationProperties { get; set; }

        /// <summary>The creator of the event. Read-only.</summary>
        public class CreatorData
        {
            /// <summary>The creator's name, if available.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("displayName")]
            public virtual string DisplayName { get; set; }

            /// <summary>The creator's email address, if available.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("email")]
            public virtual string Email { get; set; }

            /// <summary>The creator's Profile ID, if available.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("id")]
            public virtual string Id { get; set; }

            /// <summary>
            /// Whether the creator corresponds to the calendar on which this copy of the event appears. Read-only. The
            /// default is False.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("self")]
            public virtual System.Nullable<bool> Self { get; set; }
        }

        /// <summary>Extended properties of the event.</summary>
        public class ExtendedPropertiesData
        {
            /// <summary>Properties that are private to the copy of the event that appears on this calendar.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("private")]
            public virtual System.Collections.Generic.IDictionary<string, string> Private__ { get; set; }

            /// <summary>Properties that are shared between copies of the event on other attendees' calendars.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("shared")]
            public virtual System.Collections.Generic.IDictionary<string, string> Shared { get; set; }
        }

        /// <summary>
        /// A gadget that extends this event. Gadgets are deprecated; this structure is instead only used for returning
        /// birthday calendar metadata.
        /// </summary>
        public class GadgetData
        {
            /// <summary>
            /// The gadget's display mode. Deprecated. Possible values are:   - "icon" - The gadget displays next to the
            /// event's title in the calendar view.  - "chip" - The gadget displays when the event is clicked.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("display")]
            public virtual string Display { get; set; }

            /// <summary>
            /// The gadget's height in pixels. The height must be an integer greater than 0. Optional. Deprecated.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("height")]
            public virtual System.Nullable<int> Height { get; set; }

            /// <summary>The gadget's icon URL. The URL scheme must be HTTPS. Deprecated.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("iconLink")]
            public virtual string IconLink { get; set; }

            /// <summary>The gadget's URL. The URL scheme must be HTTPS. Deprecated.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("link")]
            public virtual string Link { get; set; }

            /// <summary>Preferences.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("preferences")]
            public virtual System.Collections.Generic.IDictionary<string, string> Preferences { get; set; }

            /// <summary>The gadget's title. Deprecated.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("title")]
            public virtual string Title { get; set; }

            /// <summary>The gadget's type. Deprecated.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("type")]
            public virtual string Type { get; set; }

            /// <summary>
            /// The gadget's width in pixels. The width must be an integer greater than 0. Optional. Deprecated.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("width")]
            public virtual System.Nullable<int> Width { get; set; }
        }

        /// <summary>
        /// The organizer of the event. If the organizer is also an attendee, this is indicated with a separate entry in
        /// attendees with the organizer field set to True. To change the organizer, use the move operation. Read-only,
        /// except when importing an event.
        /// </summary>
        public class OrganizerData
        {
            /// <summary>The organizer's name, if available.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("displayName")]
            public virtual string DisplayName { get; set; }

            /// <summary>
            /// The organizer's email address, if available. It must be a valid email address as per RFC5322.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("email")]
            public virtual string Email { get; set; }

            /// <summary>The organizer's Profile ID, if available.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("id")]
            public virtual string Id { get; set; }

            /// <summary>
            /// Whether the organizer corresponds to the calendar on which this copy of the event appears. Read-only.
            /// The default is False.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("self")]
            public virtual System.Nullable<bool> Self { get; set; }
        }

        /// <summary>Information about the event's reminders for the authenticated user.</summary>
        public class RemindersData
        {
            /// <summary>
            /// If the event doesn't use the default reminders, this lists the reminders specific to the event, or, if
            /// not set, indicates that no reminders are set for this event. The maximum number of override reminders is
            /// 5.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("overrides")]
            public virtual System.Collections.Generic.IList<EventReminder> Overrides { get; set; }

            /// <summary>Whether the default reminders of the calendar apply to the event.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("useDefault")]
            public virtual System.Nullable<bool> UseDefault { get; set; }
        }

        /// <summary>
        /// Source from which the event was created. For example, a web page, an email message or any document
        /// identifiable by an URL with HTTP or HTTPS scheme. Can only be seen or modified by the creator of the event.
        /// </summary>
        public class SourceData
        {
            /// <summary>Title of the source; for example a title of a web page or an email subject.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("title")]
            public virtual string Title { get; set; }

            /// <summary>URL of the source pointing to a resource. The URL scheme must be HTTP or HTTPS.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("url")]
            public virtual string Url { get; set; }
        }
    }

    public class EventAttachment : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// ID of the attached file. Read-only. For Google Drive files, this is the ID of the corresponding Files
        /// resource entry in the Drive API.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("fileId")]
        public virtual string FileId { get; set; }

        /// <summary>
        /// URL link to the attachment. For adding Google Drive file attachments use the same format as in alternateLink
        /// property of the Files resource in the Drive API. Required when adding an attachment.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("fileUrl")]
        public virtual string FileUrl { get; set; }

        /// <summary>
        /// URL link to the attachment's icon. This field can only be modified for custom third-party attachments.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("iconLink")]
        public virtual string IconLink { get; set; }

        /// <summary>Internet media type (MIME type) of the attachment.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("mimeType")]
        public virtual string MimeType { get; set; }

        /// <summary>Attachment title.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("title")]
        public virtual string Title { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class EventAttendee : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Number of additional guests. Optional. The default is 0.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("additionalGuests")]
        public virtual System.Nullable<int> AdditionalGuests { get; set; }

        /// <summary>The attendee's response comment. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("comment")]
        public virtual string Comment { get; set; }

        /// <summary>The attendee's name, if available. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("displayName")]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// The attendee's email address, if available. This field must be present when adding an attendee. It must be a
        /// valid email address as per RFC5322. Required when adding an attendee.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("email")]
        public virtual string Email { get; set; }

        /// <summary>The attendee's Profile ID, if available.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>Whether this is an optional attendee. Optional. The default is False.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("optional")]
        public virtual System.Nullable<bool> Optional { get; set; }

        /// <summary>Whether the attendee is the organizer of the event. Read-only. The default is False.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("organizer")]
        public virtual System.Nullable<bool> Organizer { get; set; }

        /// <summary>
        /// Whether the attendee is a resource. Can only be set when the attendee is added to the event for the first
        /// time. Subsequent modifications are ignored. Optional. The default is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resource")]
        public virtual System.Nullable<bool> Resource { get; set; }

        /// <summary>
        /// The attendee's response status. Possible values are:   - "needsAction" - The attendee has not responded to
        /// the invitation (recommended for new events).  - "declined" - The attendee has declined the invitation.  -
        /// "tentative" - The attendee has tentatively accepted the invitation.  - "accepted" - The attendee has
        /// accepted the invitation.  Warning: If you add an event using the values declined, tentative, or accepted,
        /// attendees with the "Add invitations to my calendar" setting set to "When I respond to invitation in email"
        /// won't see an event on their calendar unless they choose to change their invitation response in the event
        /// invitation email.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("responseStatus")]
        public virtual string ResponseStatus { get; set; }

        /// <summary>
        /// Whether this entry represents the calendar on which this copy of the event appears. Read-only. The default
        /// is False.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("self")]
        public virtual System.Nullable<bool> Self { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class EventDateTime : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The date, in the format "yyyy-mm-dd", if this is an all-day event.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("date")]
        public virtual string Date { get; set; }

        /// <summary>
        /// The time, as a combined date-time value (formatted according to RFC3339). A time zone offset is required
        /// unless a time zone is explicitly specified in timeZone.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("dateTime")]
        public virtual string DateTimeRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="DateTimeRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? DateTimeDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(DateTimeRaw);
            set => DateTimeRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="DateTimeRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use DateTimeDateTimeOffset instead.")]
        public virtual System.DateTime? DateTime
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(DateTimeRaw);
            set => DateTimeRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>
        /// The time zone in which the time is specified. (Formatted as an IANA Time Zone Database name, e.g.
        /// "Europe/Zurich".) For recurring events this field is required and specifies the time zone in which the
        /// recurrence is expanded. For single events this field is optional and indicates a custom time zone for the
        /// event start/end.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeZone")]
        public virtual string TimeZone { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class EventReminder : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The method used by this reminder. Possible values are:   - "email" - Reminders are sent via email.  -
        /// "popup" - Reminders are sent via a UI popup.   Required when adding a reminder.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("method")]
        public virtual string Method { get; set; }

        /// <summary>
        /// Number of minutes before the start of the event when the reminder should trigger. Valid values are between 0
        /// and 40320 (4 weeks in minutes). Required when adding a reminder.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("minutes")]
        public virtual System.Nullable<int> Minutes { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class EventWorkingLocationProperties : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>If present, specifies that the user is working from a custom location.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("customLocation")]
        public virtual CustomLocationData CustomLocation { get; set; }

        /// <summary>If present, specifies that the user is working at home.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("homeOffice")]
        public virtual object HomeOffice { get; set; }

        /// <summary>If present, specifies that the user is working from an office.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("officeLocation")]
        public virtual OfficeLocationData OfficeLocation { get; set; }

        /// <summary>
        /// Type of the working location. Possible values are:   - "homeOffice" - The user is working at home.  -
        /// "officeLocation" - The user is working from an office.  - "customLocation" - The user is working from a
        /// custom location.  Any details are specified in a sub-field of the specified name, but this field may be
        /// missing if empty. Any other fields are ignored. Required when adding working location properties.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }

        /// <summary>If present, specifies that the user is working from a custom location.</summary>
        public class CustomLocationData
        {
            /// <summary>An optional extra label for additional information.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("label")]
            public virtual string Label { get; set; }
        }

        /// <summary>If present, specifies that the user is working from an office.</summary>
        public class OfficeLocationData
        {
            /// <summary>
            /// An optional building identifier. This should reference a building ID in the organization's Resources
            /// database.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("buildingId")]
            public virtual string BuildingId { get; set; }

            /// <summary>An optional desk identifier.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("deskId")]
            public virtual string DeskId { get; set; }

            /// <summary>An optional floor identifier.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("floorId")]
            public virtual string FloorId { get; set; }

            /// <summary>An optional floor section identifier.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("floorSectionId")]
            public virtual string FloorSectionId { get; set; }

            /// <summary>
            /// The office name that's displayed in Calendar Web and Mobile clients. We recommend you reference a
            /// building name in the organization's Resources database.
            /// </summary>
            [Newtonsoft.Json.JsonPropertyAttribute("label")]
            public virtual string Label { get; set; }
        }
    }

    public class Events : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// The user's access role for this calendar. Read-only. Possible values are:   - "none" - The user has no
        /// access.  - "freeBusyReader" - The user has read access to free/busy information.  - "reader" - The user has
        /// read access to the calendar. Private events will appear to users with reader access, but event details will
        /// be hidden.  - "writer" - The user has read and write access to the calendar. Private events will appear to
        /// users with writer access, and event details will be visible.  - "owner" - The user has ownership of the
        /// calendar. This role has all of the permissions of the writer role with the additional ability to see and
        /// manipulate ACLs.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("accessRole")]
        public virtual string AccessRole { get; set; }

        /// <summary>
        /// The default reminders on the calendar for the authenticated user. These reminders apply to all events on
        /// this calendar that do not explicitly override them (i.e. do not have reminders.useDefault set to True).
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("defaultReminders")]
        public virtual System.Collections.Generic.IList<EventReminder> DefaultReminders { get; set; }

        /// <summary>Description of the calendar. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; }

        /// <summary>ETag of the collection.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>List of events on the calendar.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<Event> Items { get; set; }

        /// <summary>Type of the collection ("calendar#events").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// Token used to access the next page of this result. Omitted if no further results are available, in which
        /// case nextSyncToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; }

        /// <summary>
        /// Token used at a later point in time to retrieve only the entries that have changed since this result was
        /// returned. Omitted if further results are available, in which case nextPageToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextSyncToken")]
        public virtual string NextSyncToken { get; set; }

        /// <summary>Title of the calendar. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("summary")]
        public virtual string Summary { get; set; }

        /// <summary>The time zone of the calendar. Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeZone")]
        public virtual string TimeZone { get; set; }

        /// <summary>Last modification time of the calendar (as a RFC3339 timestamp). Read-only.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("updated")]
        public virtual string UpdatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? UpdatedDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use UpdatedDateTimeOffset instead.")]
        public virtual System.DateTime? Updated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }
    }

    public class FreeBusyCalendar : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>List of time ranges during which this calendar should be regarded as busy.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("busy")]
        public virtual System.Collections.Generic.IList<TimePeriod> Busy { get; set; }

        /// <summary>Optional error(s) (if computation for the calendar failed).</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("errors")]
        public virtual System.Collections.Generic.IList<Error> Errors { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class FreeBusyGroup : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>List of calendars' identifiers within a group.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("calendars")]
        public virtual System.Collections.Generic.IList<string> Calendars { get; set; }

        /// <summary>Optional error(s) (if computation for the group failed).</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("errors")]
        public virtual System.Collections.Generic.IList<Error> Errors { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class FreeBusyRequest : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>
        /// Maximal number of calendars for which FreeBusy information is to be provided. Optional. Maximum value is 50.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("calendarExpansionMax")]
        public virtual System.Nullable<int> CalendarExpansionMax { get; set; }

        /// <summary>
        /// Maximal number of calendar identifiers to be provided for a single group. Optional. An error is returned for
        /// a group with more members than this value. Maximum value is 100.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("groupExpansionMax")]
        public virtual System.Nullable<int> GroupExpansionMax { get; set; }

        /// <summary>List of calendars and/or groups to query.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<FreeBusyRequestItem> Items { get; set; }

        /// <summary>The end of the interval for the query formatted as per RFC3339.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeMax")]
        public virtual string TimeMaxRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="TimeMaxRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? TimeMaxDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(TimeMaxRaw);
            set => TimeMaxRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeMaxRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use TimeMaxDateTimeOffset instead.")]
        public virtual System.DateTime? TimeMax
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeMaxRaw);
            set => TimeMaxRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The start of the interval for the query formatted as per RFC3339.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeMin")]
        public virtual string TimeMinRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="TimeMinRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? TimeMinDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(TimeMinRaw);
            set => TimeMinRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeMinRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use TimeMinDateTimeOffset instead.")]
        public virtual System.DateTime? TimeMin
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeMinRaw);
            set => TimeMinRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>Time zone used in the response. Optional. The default is UTC.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeZone")]
        public virtual string TimeZone { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class FreeBusyRequestItem : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The identifier of a calendar or a group.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class FreeBusyResponse : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>List of free/busy information for calendars.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("calendars")]
        public virtual System.Collections.Generic.IDictionary<string, FreeBusyCalendar> Calendars { get; set; }

        /// <summary>Expansion of groups.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("groups")]
        public virtual System.Collections.Generic.IDictionary<string, FreeBusyGroup> Groups { get; set; }

        /// <summary>Type of the resource ("calendar#freeBusy").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>The end of the interval.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeMax")]
        public virtual string TimeMaxRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="TimeMaxRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? TimeMaxDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(TimeMaxRaw);
            set => TimeMaxRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeMaxRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use TimeMaxDateTimeOffset instead.")]
        public virtual System.DateTime? TimeMax
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeMaxRaw);
            set => TimeMaxRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The start of the interval.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeMin")]
        public virtual string TimeMinRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="TimeMinRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? TimeMinDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(TimeMinRaw);
            set => TimeMinRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeMinRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use TimeMinDateTimeOffset instead.")]
        public virtual System.DateTime? TimeMin
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeMinRaw);
            set => TimeMinRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }

    public class Setting : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>ETag of the resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>The id of the user setting.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>Type of the resource ("calendar#setting").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// Value of the user setting. The format of the value depends on the ID of the setting. It must always be a
        /// UTF-8 string of length up to 1024 characters.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("value")]
        public virtual string Value { get; set; }
    }

    public class Settings : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Etag of the collection.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; }

        /// <summary>List of user settings.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<Setting> Items { get; set; }

        /// <summary>Type of the collection ("calendar#settings").</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// Token used to access the next page of this result. Omitted if no further results are available, in which
        /// case nextSyncToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; }

        /// <summary>
        /// Token used at a later point in time to retrieve only the entries that have changed since this result was
        /// returned. Omitted if further results are available, in which case nextPageToken is provided.
        /// </summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextSyncToken")]
        public virtual string NextSyncToken { get; set; }
    }

    public class TimePeriod : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The (exclusive) end of the time period.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("end")]
        public virtual string EndRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="EndRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? EndDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(EndRaw);
            set => EndRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="EndRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use EndDateTimeOffset instead.")]
        public virtual System.DateTime? End
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(EndRaw);
            set => EndRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The (inclusive) start of the time period.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("start")]
        public virtual string StartRaw { get; set; }

        /// <summary><seealso cref="System.DateTimeOffset"/> representation of <see cref="StartRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.DateTimeOffset? StartDateTimeOffset
        {
            get => Google.Apis.Util.DiscoveryFormat.ParseDateTimeToDateTimeOffset(StartRaw);
            set => StartRaw = Google.Apis.Util.DiscoveryFormat.FormatDateTimeOffsetToDateTime(value);
        }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="StartRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        [System.ObsoleteAttribute("This property is obsolete and may behave unexpectedly; please use StartDateTimeOffset instead.")]
        public virtual System.DateTime? Start
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(StartRaw);
            set => StartRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }
}
