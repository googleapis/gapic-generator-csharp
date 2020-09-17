// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.

// Generated code. DO NOT EDIT!

namespace Google.Apis.Storage.v1
{
    /// <summary>The Storage Service.</summary>
    public class StorageService : Google.Apis.Services.BaseClientService
    {
        /// <summary>The API version.</summary>
        public const string Version = "v1";

        /// <summary>The discovery version used to generate this service.</summary>
        public static Google.Apis.Discovery.DiscoveryVersion DiscoveryVersionUsed = Google.Apis.Discovery.DiscoveryVersion.Version_1_0;

        /// <summary>Constructs a new service.</summary>
        public StorageService() : this(new Google.Apis.Services.BaseClientService.Initializer())
        {
        }

        /// <summary>Constructs a new service.</summary>
        /// <param name="initializer">The service initializer.</param>
        public StorageService(Google.Apis.Services.BaseClientService.Initializer initializer) : base(initializer)
        {
            BucketAccessControls = new BucketAccessControlsResource(this);
            Buckets = new BucketsResource(this);
            Channels = new ChannelsResource(this);
            DefaultObjectAccessControls = new DefaultObjectAccessControlsResource(this);
            Notifications = new NotificationsResource(this);
            ObjectAccessControls = new ObjectAccessControlsResource(this);
            Objects = new ObjectsResource(this);
            Projects = new ProjectsResource(this);
        }

        /// <summary>Gets the service supported features.</summary>
        public override System.Collections.Generic.IList<string> Features => new string[0];

        /// <summary>Gets the service name.</summary>
        public override string Name => "storage";

        /// <summary>Gets the service base URI.</summary>
        public override string BaseUri =>
        #if NETSTANDARD1_3 || NETSTANDARD2_0 || NET45
            BaseUriOverride ?? "https://storage.googleapis.com/storage/v1/";
        #else
            "https://storage.googleapis.com/storage/v1/";
        #endif

        /// <summary>Gets the service base path.</summary>
        public override string BasePath => "storage/v1/";

        #if !NET40
        /// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>
        public override string BatchUri => "https://storage.googleapis.com/batch/storage/v1";

        /// <summary>Gets the batch base path; <c>null</c> if unspecified.</summary>
        public override string BatchPath => "batch/storage/v1";
        #endif

        /// <summary>Available OAuth 2.0 scopes for use with the Cloud Storage JSON API.</summary>
        public class Scope
        {
            /// <summary>View and manage your data across Google Cloud Platform services</summary>
            public static string CloudPlatform = "https://www.googleapis.com/auth/cloud-platform";

            /// <summary>View your data across Google Cloud Platform services</summary>
            public static string CloudPlatformReadOnly = "https://www.googleapis.com/auth/cloud-platform.read-only";

            /// <summary>Manage your data and permissions in Google Cloud Storage</summary>
            public static string DevstorageFullControl = "https://www.googleapis.com/auth/devstorage.full_control";

            /// <summary>View your data in Google Cloud Storage</summary>
            public static string DevstorageReadOnly = "https://www.googleapis.com/auth/devstorage.read_only";

            /// <summary>Manage your data in Google Cloud Storage</summary>
            public static string DevstorageReadWrite = "https://www.googleapis.com/auth/devstorage.read_write";

        }

        /// <summary>Available OAuth 2.0 scope constants for use with the Cloud Storage JSON API.</summary>
        public static class ScopeConstants
        {
            /// <summary>View and manage your data across Google Cloud Platform services</summary>
            public const string CloudPlatform = "https://www.googleapis.com/auth/cloud-platform";

            /// <summary>View your data across Google Cloud Platform services</summary>
            public const string CloudPlatformReadOnly = "https://www.googleapis.com/auth/cloud-platform.read-only";

            /// <summary>Manage your data and permissions in Google Cloud Storage</summary>
            public const string DevstorageFullControl = "https://www.googleapis.com/auth/devstorage.full_control";

            /// <summary>View your data in Google Cloud Storage</summary>
            public const string DevstorageReadOnly = "https://www.googleapis.com/auth/devstorage.read_only";

            /// <summary>Manage your data in Google Cloud Storage</summary>
            public const string DevstorageReadWrite = "https://www.googleapis.com/auth/devstorage.read_write";

        }



        /// <summary>Gets the BucketAccessControls resource.</summary>
        public virtual BucketAccessControlsResource BucketAccessControls { get; }

        /// <summary>Gets the Buckets resource.</summary>
        public virtual BucketsResource Buckets { get; }

        /// <summary>Gets the Channels resource.</summary>
        public virtual ChannelsResource Channels { get; }

        /// <summary>Gets the DefaultObjectAccessControls resource.</summary>
        public virtual DefaultObjectAccessControlsResource DefaultObjectAccessControls { get; }

        /// <summary>Gets the Notifications resource.</summary>
        public virtual NotificationsResource Notifications { get; }

        /// <summary>Gets the ObjectAccessControls resource.</summary>
        public virtual ObjectAccessControlsResource ObjectAccessControls { get; }

        /// <summary>Gets the Objects resource.</summary>
        public virtual ObjectsResource Objects { get; }

        /// <summary>Gets the Projects resource.</summary>
        public virtual ProjectsResource Projects { get; }
    }

    /// <summary>A base abstract class for Storage requests.</summary>
    public abstract class StorageBaseServiceRequest<TResponse> : Google.Apis.Requests.ClientServiceRequest<TResponse>
    {
        /// <summary>Constructs a new StorageBaseServiceRequest instance.</summary>
        protected StorageBaseServiceRequest(Google.Apis.Services.IClientService service) : base(service)
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
            Json,
        }

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

        /// <summary>Returns response with indentations and line breaks.</summary>
        [Google.Apis.Util.RequestParameterAttribute("prettyPrint", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<bool> PrettyPrint { get; set; }

        /// <summary>An opaque string that represents a user for quota purposes. Must not exceed 40
        /// characters.</summary>
        [Google.Apis.Util.RequestParameterAttribute("quotaUser", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string QuotaUser { get; set; }

        /// <summary>Deprecated. Please use quotaUser instead.</summary>
        [Google.Apis.Util.RequestParameterAttribute("userIp", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string UserIp { get; set; }

        /// <summary>Initializes Storage parameter list.</summary>
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

    /// <summary>The "bucketAccessControls" collection of methods.</summary>
    public class BucketAccessControlsResource
    {
        private const string Resource = "bucketAccessControls";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public BucketAccessControlsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Permanently deletes the ACL entry for the specified entity on the specified bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual DeleteRequest Delete(string bucket, string entity)
        {
            return new DeleteRequest(service, bucket, entity);
        }

        /// <summary>Permanently deletes the ACL entry for the specified entity on the specified bucket.</summary>
        public class DeleteRequest : StorageBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/acl/{entity}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Returns the ACL entry for the specified entity on the specified bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual GetRequest Get(string bucket, string entity)
        {
            return new GetRequest(service, bucket, entity);
        }

        /// <summary>Returns the ACL entry for the specified entity on the specified bucket.</summary>
        public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.BucketAccessControl>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/acl/{entity}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Creates a new ACL entry on the specified bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual InsertRequest Insert(Google.Apis.Storage.v1.Data.BucketAccessControl body, string bucket)
        {
            return new InsertRequest(service, body, bucket);
        }

        /// <summary>Creates a new ACL entry on the specified bucket.</summary>
        public class InsertRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.BucketAccessControl>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.BucketAccessControl body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.BucketAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/acl";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Retrieves ACL entries on the specified bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual ListRequest List(string bucket)
        {
            return new ListRequest(service, bucket);
        }

        /// <summary>Retrieves ACL entries on the specified bucket.</summary>
        public class ListRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.BucketAccessControls>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string bucket) : base(service)
            {
                Bucket = bucket;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/acl";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Patches an ACL entry on the specified bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual PatchRequest Patch(Google.Apis.Storage.v1.Data.BucketAccessControl body, string bucket, string entity)
        {
            return new PatchRequest(service, body, bucket, entity);
        }

        /// <summary>Patches an ACL entry on the specified bucket.</summary>
        public class PatchRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.BucketAccessControl>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.BucketAccessControl body, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.BucketAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/acl/{entity}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Updates an ACL entry on the specified bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual UpdateRequest Update(Google.Apis.Storage.v1.Data.BucketAccessControl body, string bucket, string entity)
        {
            return new UpdateRequest(service, body, bucket, entity);
        }

        /// <summary>Updates an ACL entry on the specified bucket.</summary>
        public class UpdateRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.BucketAccessControl>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.BucketAccessControl body, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.BucketAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/acl/{entity}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }
    }

    /// <summary>The "buckets" collection of methods.</summary>
    public class BucketsResource
    {
        private const string Resource = "buckets";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public BucketsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Permanently deletes an empty bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual DeleteRequest Delete(string bucket)
        {
            return new DeleteRequest(service, bucket);
        }

        /// <summary>Permanently deletes an empty bucket.</summary>
        public class DeleteRequest : StorageBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string bucket) : base(service)
            {
                Bucket = bucket;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>If set, only deletes the bucket if its metageneration matches this value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>If set, only deletes the bucket if its metageneration does not match this value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Returns metadata for the specified bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual GetRequest Get(string bucket)
        {
            return new GetRequest(service, bucket);
        }

        /// <summary>Returns metadata for the specified bucket.</summary>
        public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Bucket>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string bucket) : base(service)
            {
                Bucket = bucket;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Makes the return of the bucket metadata conditional on whether the bucket's current
            /// metageneration matches the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the return of the bucket metadata conditional on whether the bucket's current
            /// metageneration does not match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit owner, acl and defaultObjectAcl properties.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Returns an IAM policy for the specified bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual GetIamPolicyRequest GetIamPolicy(string bucket)
        {
            return new GetIamPolicyRequest(service, bucket);
        }

        /// <summary>Returns an IAM policy for the specified bucket.</summary>
        public class GetIamPolicyRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Policy>
        {
            /// <summary>Constructs a new GetIamPolicy request.</summary>
            public GetIamPolicyRequest(Google.Apis.Services.IClientService service, string bucket) : base(service)
            {
                Bucket = bucket;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The IAM policy format version to be returned. If the optionsRequestedPolicyVersion is for an
            /// older version that doesn't support part of the requested IAM policy, the request fails.</summary>
            [Google.Apis.Util.RequestParameterAttribute("optionsRequestedPolicyVersion", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<int> OptionsRequestedPolicyVersion { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "getIamPolicy";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/iam";

            /// <summary>Initializes GetIamPolicy parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("optionsRequestedPolicyVersion", new Google.Apis.Discovery.Parameter
                {
                    Name = "optionsRequestedPolicyVersion",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Creates a new bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="project">A valid API project identifier.</param>
        public virtual InsertRequest Insert(Google.Apis.Storage.v1.Data.Bucket body, string project)
        {
            return new InsertRequest(service, body, project);
        }

        /// <summary>Creates a new bucket.</summary>
        public class InsertRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Bucket>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Bucket body, string project) : base(service)
            {
                Project = project;
                Body = body;
                InitParameters();
            }


            /// <summary>A valid API project identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("project", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Project { get; private set; }

            /// <summary>Apply a predefined set of access controls to this bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedAclEnum> PredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to this bucket.</summary>
            public enum PredefinedAclEnum
            {
                /// <summary>Project team owners get OWNER access, and allAuthenticatedUsers get READER
                /// access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Project team members get access according to their roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Project team owners get OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
                /// <summary>Project team owners get OWNER access, and allUsers get WRITER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicReadWrite")]
                PublicReadWrite,
            }

            /// <summary>Apply a predefined set of default object access controls to this bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedDefaultObjectAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedDefaultObjectAclEnum> PredefinedDefaultObjectAcl { get; set; }

            /// <summary>Apply a predefined set of default object access controls to this bucket.</summary>
            public enum PredefinedDefaultObjectAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the bucket resource specifies acl or
            /// defaultObjectAcl properties, when it defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the bucket resource specifies acl or
            /// defaultObjectAcl properties, when it defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit owner, acl and defaultObjectAcl properties.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Bucket Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("project", new Google.Apis.Discovery.Parameter
                {
                    Name = "project",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedDefaultObjectAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedDefaultObjectAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Retrieves a list of buckets for a given project.</summary>
        /// <param name="project">A valid API project identifier.</param>
        public virtual ListRequest List(string project)
        {
            return new ListRequest(service, project);
        }

        /// <summary>Retrieves a list of buckets for a given project.</summary>
        public class ListRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Buckets>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string project) : base(service)
            {
                Project = project;
                InitParameters();
            }


            /// <summary>A valid API project identifier.</summary>
            [Google.Apis.Util.RequestParameterAttribute("project", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Project { get; private set; }

            /// <summary>Maximum number of buckets to return in a single response. The service will use this parameter
            /// or 1,000 items, whichever is smaller.</summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> MaxResults { get; set; }

            /// <summary>A previously-returned page token representing part of the larger set of results to
            /// view.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>Filter results to buckets whose names begin with this prefix.</summary>
            [Google.Apis.Util.RequestParameterAttribute("prefix", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Prefix { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit owner, acl and defaultObjectAcl properties.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("project", new Google.Apis.Discovery.Parameter
                {
                    Name = "project",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxResults", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxResults",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "1000",
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
                RequestParameters.Add("prefix", new Google.Apis.Discovery.Parameter
                {
                    Name = "prefix",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Locks retention policy on a bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="ifMetagenerationMatch">Makes the operation
        /// conditional on whether bucket's current metageneration matches the given value.</param>
        public virtual LockRetentionPolicyRequest LockRetentionPolicy(string bucket, long ifMetagenerationMatch)
        {
            return new LockRetentionPolicyRequest(service, bucket, ifMetagenerationMatch);
        }

        /// <summary>Locks retention policy on a bucket.</summary>
        public class LockRetentionPolicyRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Bucket>
        {
            /// <summary>Constructs a new LockRetentionPolicy request.</summary>
            public LockRetentionPolicyRequest(Google.Apis.Services.IClientService service, string bucket, long ifMetagenerationMatch) : base(service)
            {
                Bucket = bucket;
                IfMetagenerationMatch = ifMetagenerationMatch;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Makes the operation conditional on whether bucket's current metageneration matches the given
            /// value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual long IfMetagenerationMatch { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "lockRetentionPolicy";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/lockRetentionPolicy";

            /// <summary>Initializes LockRetentionPolicy parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Patches a bucket. Changes to the bucket will be readable immediately after writing, but
        /// configuration changes may take time to propagate.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual PatchRequest Patch(Google.Apis.Storage.v1.Data.Bucket body, string bucket)
        {
            return new PatchRequest(service, body, bucket);
        }

        /// <summary>Patches a bucket. Changes to the bucket will be readable immediately after writing, but
        /// configuration changes may take time to propagate.</summary>
        public class PatchRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Bucket>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Bucket body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Makes the return of the bucket metadata conditional on whether the bucket's current
            /// metageneration matches the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the return of the bucket metadata conditional on whether the bucket's current
            /// metageneration does not match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Apply a predefined set of access controls to this bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedAclEnum> PredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to this bucket.</summary>
            public enum PredefinedAclEnum
            {
                /// <summary>Project team owners get OWNER access, and allAuthenticatedUsers get READER
                /// access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Project team members get access according to their roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Project team owners get OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
                /// <summary>Project team owners get OWNER access, and allUsers get WRITER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicReadWrite")]
                PublicReadWrite,
            }

            /// <summary>Apply a predefined set of default object access controls to this bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedDefaultObjectAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedDefaultObjectAclEnum> PredefinedDefaultObjectAcl { get; set; }

            /// <summary>Apply a predefined set of default object access controls to this bucket.</summary>
            public enum PredefinedDefaultObjectAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit owner, acl and defaultObjectAcl properties.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Bucket Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedDefaultObjectAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedDefaultObjectAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Updates an IAM policy for the specified bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual SetIamPolicyRequest SetIamPolicy(Google.Apis.Storage.v1.Data.Policy body, string bucket)
        {
            return new SetIamPolicyRequest(service, body, bucket);
        }

        /// <summary>Updates an IAM policy for the specified bucket.</summary>
        public class SetIamPolicyRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Policy>
        {
            /// <summary>Constructs a new SetIamPolicy request.</summary>
            public SetIamPolicyRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Policy body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Policy Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "setIamPolicy";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/iam";

            /// <summary>Initializes SetIamPolicy parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Tests a set of permissions on the given bucket to see which, if any, are held by the
        /// caller.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="permissions">Permissions to test.</param>
        public virtual TestIamPermissionsRequest TestIamPermissions(string bucket, Google.Apis.Util.Repeatable<string> permissions)
        {
            return new TestIamPermissionsRequest(service, bucket, permissions);
        }

        /// <summary>Tests a set of permissions on the given bucket to see which, if any, are held by the
        /// caller.</summary>
        public class TestIamPermissionsRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.TestIamPermissionsResponse>
        {
            /// <summary>Constructs a new TestIamPermissions request.</summary>
            public TestIamPermissionsRequest(Google.Apis.Services.IClientService service, string bucket, Google.Apis.Util.Repeatable<string> permissions) : base(service)
            {
                Bucket = bucket;
                Permissions = permissions;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Permissions to test.</summary>
            [Google.Apis.Util.RequestParameterAttribute("permissions", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> Permissions { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "testIamPermissions";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/iam/testPermissions";

            /// <summary>Initializes TestIamPermissions parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("permissions", new Google.Apis.Discovery.Parameter
                {
                    Name = "permissions",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Updates a bucket. Changes to the bucket will be readable immediately after writing, but
        /// configuration changes may take time to propagate.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual UpdateRequest Update(Google.Apis.Storage.v1.Data.Bucket body, string bucket)
        {
            return new UpdateRequest(service, body, bucket);
        }

        /// <summary>Updates a bucket. Changes to the bucket will be readable immediately after writing, but
        /// configuration changes may take time to propagate.</summary>
        public class UpdateRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Bucket>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Bucket body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Makes the return of the bucket metadata conditional on whether the bucket's current
            /// metageneration matches the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the return of the bucket metadata conditional on whether the bucket's current
            /// metageneration does not match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Apply a predefined set of access controls to this bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedAclEnum> PredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to this bucket.</summary>
            public enum PredefinedAclEnum
            {
                /// <summary>Project team owners get OWNER access, and allAuthenticatedUsers get READER
                /// access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Project team members get access according to their roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Project team owners get OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
                /// <summary>Project team owners get OWNER access, and allUsers get WRITER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicReadWrite")]
                PublicReadWrite,
            }

            /// <summary>Apply a predefined set of default object access controls to this bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedDefaultObjectAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedDefaultObjectAclEnum> PredefinedDefaultObjectAcl { get; set; }

            /// <summary>Apply a predefined set of default object access controls to this bucket.</summary>
            public enum PredefinedDefaultObjectAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit owner, acl and defaultObjectAcl properties.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Bucket Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedDefaultObjectAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedDefaultObjectAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
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
        public virtual StopRequest Stop(Google.Apis.Storage.v1.Data.Channel body)
        {
            return new StopRequest(service, body);
        }

        /// <summary>Stop watching resources through this channel</summary>
        public class StopRequest : StorageBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Stop request.</summary>
            public StopRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Channel body) : base(service)
            {
                Body = body;
                InitParameters();
            }



            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Channel Body { get; set; }

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

    /// <summary>The "defaultObjectAccessControls" collection of methods.</summary>
    public class DefaultObjectAccessControlsResource
    {
        private const string Resource = "defaultObjectAccessControls";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public DefaultObjectAccessControlsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Permanently deletes the default object ACL entry for the specified entity on the specified
        /// bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual DeleteRequest Delete(string bucket, string entity)
        {
            return new DeleteRequest(service, bucket, entity);
        }

        /// <summary>Permanently deletes the default object ACL entry for the specified entity on the specified
        /// bucket.</summary>
        public class DeleteRequest : StorageBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/defaultObjectAcl/{entity}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Returns the default object ACL entry for the specified entity on the specified bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual GetRequest Get(string bucket, string entity)
        {
            return new GetRequest(service, bucket, entity);
        }

        /// <summary>Returns the default object ACL entry for the specified entity on the specified bucket.</summary>
        public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/defaultObjectAcl/{entity}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Creates a new default object ACL entry on the specified bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual InsertRequest Insert(Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket)
        {
            return new InsertRequest(service, body, bucket);
        }

        /// <summary>Creates a new default object ACL entry on the specified bucket.</summary>
        public class InsertRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.ObjectAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/defaultObjectAcl";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Retrieves default object ACL entries on the specified bucket.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        public virtual ListRequest List(string bucket)
        {
            return new ListRequest(service, bucket);
        }

        /// <summary>Retrieves default object ACL entries on the specified bucket.</summary>
        public class ListRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControls>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string bucket) : base(service)
            {
                Bucket = bucket;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>If present, only return default ACL listing if the bucket's current metageneration matches this
            /// value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>If present, only return default ACL listing if the bucket's current metageneration does not
            /// match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/defaultObjectAcl";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Patches a default object ACL entry on the specified bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual PatchRequest Patch(Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string entity)
        {
            return new PatchRequest(service, body, bucket, entity);
        }

        /// <summary>Patches a default object ACL entry on the specified bucket.</summary>
        public class PatchRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.ObjectAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/defaultObjectAcl/{entity}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Updates a default object ACL entry on the specified bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="entity">The entity holding the permission. Can
        /// be user-userId, user-emailAddress, group-groupId, group-emailAddress, allUsers, or
        /// allAuthenticatedUsers.</param>
        public virtual UpdateRequest Update(Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string entity)
        {
            return new UpdateRequest(service, body, bucket, entity);
        }

        /// <summary>Updates a default object ACL entry on the specified bucket.</summary>
        public class UpdateRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string entity) : base(service)
            {
                Bucket = bucket;
                Entity = entity;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.ObjectAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/defaultObjectAcl/{entity}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }
    }

    /// <summary>The "notifications" collection of methods.</summary>
    public class NotificationsResource
    {
        private const string Resource = "notifications";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public NotificationsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Permanently deletes a notification subscription.</summary>
        /// <param name="bucket">The parent bucket of the notification.</param>
        /// <param name="notification">ID of the
        /// notification to delete.</param>
        public virtual DeleteRequest Delete(string bucket, string notification)
        {
            return new DeleteRequest(service, bucket, notification);
        }

        /// <summary>Permanently deletes a notification subscription.</summary>
        public class DeleteRequest : StorageBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string bucket, string notification) : base(service)
            {
                Bucket = bucket;
                Notification = notification;
                InitParameters();
            }


            /// <summary>The parent bucket of the notification.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>ID of the notification to delete.</summary>
            [Google.Apis.Util.RequestParameterAttribute("notification", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Notification { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/notificationConfigs/{notification}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("notification", new Google.Apis.Discovery.Parameter
                {
                    Name = "notification",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>View a notification configuration.</summary>
        /// <param name="bucket">The parent bucket of the notification.</param>
        /// <param name="notification">Notification
        /// ID</param>
        public virtual GetRequest Get(string bucket, string notification)
        {
            return new GetRequest(service, bucket, notification);
        }

        /// <summary>View a notification configuration.</summary>
        public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Notification>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string bucket, string notification) : base(service)
            {
                Bucket = bucket;
                Notification = notification;
                InitParameters();
            }


            /// <summary>The parent bucket of the notification.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Notification ID</summary>
            [Google.Apis.Util.RequestParameterAttribute("notification", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Notification { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/notificationConfigs/{notification}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("notification", new Google.Apis.Discovery.Parameter
                {
                    Name = "notification",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Creates a notification subscription for a given bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">The parent bucket of the notification.</param>
        public virtual InsertRequest Insert(Google.Apis.Storage.v1.Data.Notification body, string bucket)
        {
            return new InsertRequest(service, body, bucket);
        }

        /// <summary>Creates a notification subscription for a given bucket.</summary>
        public class InsertRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Notification>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Notification body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>The parent bucket of the notification.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Notification Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/notificationConfigs";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Retrieves a list of notification subscriptions for a given bucket.</summary>
        /// <param name="bucket">Name of a Google Cloud Storage bucket.</param>
        public virtual ListRequest List(string bucket)
        {
            return new ListRequest(service, bucket);
        }

        /// <summary>Retrieves a list of notification subscriptions for a given bucket.</summary>
        public class ListRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Notifications>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string bucket) : base(service)
            {
                Bucket = bucket;
                InitParameters();
            }


            /// <summary>Name of a Google Cloud Storage bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/notificationConfigs";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }
    }

    /// <summary>The "objectAccessControls" collection of methods.</summary>
    public class ObjectAccessControlsResource
    {
        private const string Resource = "objectAccessControls";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public ObjectAccessControlsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Permanently deletes the ACL entry for the specified entity on the specified object.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="storageObject">Name of the object. For
        /// information about how to URL encode object names to be path safe, see Encoding URI Path Parts.</param>
        ///
        /// <param name="entity">The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
        /// emailAddress, allUsers, or allAuthenticatedUsers.</param>
        public virtual DeleteRequest Delete(string bucket, string storageObject, string entity)
        {
            return new DeleteRequest(service, bucket, storageObject, entity);
        }

        /// <summary>Permanently deletes the ACL entry for the specified entity on the specified object.</summary>
        public class DeleteRequest : StorageBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string bucket, string storageObject, string entity) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Entity = entity;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/acl/{entity}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Returns the ACL entry for the specified entity on the specified object.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="storageObject">Name of the object. For
        /// information about how to URL encode object names to be path safe, see Encoding URI Path Parts.</param>
        ///
        /// <param name="entity">The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
        /// emailAddress, allUsers, or allAuthenticatedUsers.</param>
        public virtual GetRequest Get(string bucket, string storageObject, string entity)
        {
            return new GetRequest(service, bucket, storageObject, entity);
        }

        /// <summary>Returns the ACL entry for the specified entity on the specified object.</summary>
        public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string bucket, string storageObject, string entity) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Entity = entity;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/acl/{entity}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Creates a new ACL entry on the specified object.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="storageObject">Name of the object. For
        /// information about how to URL encode object names to be path safe, see Encoding URI Path Parts.</param>
        public virtual InsertRequest Insert(Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string storageObject)
        {
            return new InsertRequest(service, body, bucket, storageObject);
        }

        /// <summary>Creates a new ACL entry on the specified object.</summary>
        public class InsertRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.ObjectAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/acl";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Retrieves ACL entries on the specified object.</summary>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="storageObject">Name of the object. For
        /// information about how to URL encode object names to be path safe, see Encoding URI Path Parts.</param>
        public virtual ListRequest List(string bucket, string storageObject)
        {
            return new ListRequest(service, bucket, storageObject);
        }

        /// <summary>Retrieves ACL entries on the specified object.</summary>
        public class ListRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControls>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/acl";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Patches an ACL entry on the specified object.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="storageObject">Name of the object. For
        /// information about how to URL encode object names to be path safe, see Encoding URI Path Parts.</param>
        ///
        /// <param name="entity">The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
        /// emailAddress, allUsers, or allAuthenticatedUsers.</param>
        public virtual PatchRequest Patch(Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string storageObject, string entity)
        {
            return new PatchRequest(service, body, bucket, storageObject, entity);
        }

        /// <summary>Patches an ACL entry on the specified object.</summary>
        public class PatchRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string storageObject, string entity) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Entity = entity;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.ObjectAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/acl/{entity}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Updates an ACL entry on the specified object.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of a bucket.</param>
        /// <param name="storageObject">Name of the object. For
        /// information about how to URL encode object names to be path safe, see Encoding URI Path Parts.</param>
        ///
        /// <param name="entity">The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
        /// emailAddress, allUsers, or allAuthenticatedUsers.</param>
        public virtual UpdateRequest Update(Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string storageObject, string entity)
        {
            return new UpdateRequest(service, body, bucket, storageObject, entity);
        }

        /// <summary>Updates an ACL entry on the specified object.</summary>
        public class UpdateRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ObjectAccessControl>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.ObjectAccessControl body, string bucket, string storageObject, string entity) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Entity = entity;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of a bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>The entity holding the permission. Can be user-userId, user-emailAddress, group-groupId, group-
            /// emailAddress, allUsers, or allAuthenticatedUsers.</summary>
            [Google.Apis.Util.RequestParameterAttribute("entity", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Entity { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.ObjectAccessControl Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/acl/{entity}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("entity", new Google.Apis.Discovery.Parameter
                {
                    Name = "entity",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }
    }

    /// <summary>The "objects" collection of methods.</summary>
    public class ObjectsResource
    {
        private const string Resource = "objects";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public ObjectsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Concatenates a list of existing objects into a new object in the same bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="destinationBucket">Name of the bucket containing the source objects. The destination object is stored
        /// in this bucket.</param>
        /// <param name="destinationObject">Name of the new object. For information about how to
        /// URL encode object names to be path safe, see Encoding URI Path Parts.</param>
        public virtual ComposeRequest Compose(Google.Apis.Storage.v1.Data.ComposeRequest body, string destinationBucket, string destinationObject)
        {
            return new ComposeRequest(service, body, destinationBucket, destinationObject);
        }

        /// <summary>Concatenates a list of existing objects into a new object in the same bucket.</summary>
        public class ComposeRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Object>
        {
            /// <summary>Constructs a new Compose request.</summary>
            public ComposeRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.ComposeRequest body, string destinationBucket, string destinationObject) : base(service)
            {
                DestinationBucket = destinationBucket;
                DestinationObject = destinationObject;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket containing the source objects. The destination object is stored in this
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationBucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string DestinationBucket { get; private set; }

            /// <summary>Name of the new object. For information about how to URL encode object names to be path safe,
            /// see Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationObject", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string DestinationObject { get; private set; }

            /// <summary>Apply a predefined set of access controls to the destination object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationPredefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<DestinationPredefinedAclEnum> DestinationPredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to the destination object.</summary>
            public enum DestinationPredefinedAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Resource name of the Cloud KMS key, of the form projects/my-project/locations/global/keyRings
            /// /my-kr/cryptoKeys/my-key, that will be used to encrypt the object. Overrides the object metadata's
            /// kms_key_name value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("kmsKeyName", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string KmsKeyName { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.ComposeRequest Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "compose";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{destinationBucket}/o/{destinationObject}/compose";

            /// <summary>Initializes Compose parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("destinationBucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationBucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationObject", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationObject",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationPredefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationPredefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("kmsKeyName", new Google.Apis.Discovery.Parameter
                {
                    Name = "kmsKeyName",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Copies a source object to a destination object. Optionally overrides metadata.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="sourceBucket">Name of the bucket in which to find the source object.</param>
        /// <param
        /// name="sourceObject">Name of the source object. For information about how to URL encode object names to be path safe,
        /// see Encoding URI Path Parts.</param>
        /// <param name="destinationBucket">Name of the bucket in which to store
        /// the new object. Overrides the provided object metadata's bucket value, if any.For information about how to URL
        /// encode object names to be path safe, see Encoding URI Path Parts.</param>
        /// <param
        /// name="destinationObject">Name of the new object. Required when the object metadata is not otherwise provided.
        /// Overrides the object metadata's name value, if any.</param>
        public virtual CopyRequest Copy(Google.Apis.Storage.v1.Data.Object body, string sourceBucket, string sourceObject, string destinationBucket, string destinationObject)
        {
            return new CopyRequest(service, body, sourceBucket, sourceObject, destinationBucket, destinationObject);
        }

        /// <summary>Copies a source object to a destination object. Optionally overrides metadata.</summary>
        public class CopyRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Object>
        {
            /// <summary>Constructs a new Copy request.</summary>
            public CopyRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Object body, string sourceBucket, string sourceObject, string destinationBucket, string destinationObject) : base(service)
            {
                SourceBucket = sourceBucket;
                SourceObject = sourceObject;
                DestinationBucket = destinationBucket;
                DestinationObject = destinationObject;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket in which to find the source object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("sourceBucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string SourceBucket { get; private set; }

            /// <summary>Name of the source object. For information about how to URL encode object names to be path
            /// safe, see Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("sourceObject", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string SourceObject { get; private set; }

            /// <summary>Name of the bucket in which to store the new object. Overrides the provided object metadata's
            /// bucket value, if any.For information about how to URL encode object names to be path safe, see Encoding
            /// URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationBucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string DestinationBucket { get; private set; }

            /// <summary>Name of the new object. Required when the object metadata is not otherwise provided. Overrides
            /// the object metadata's name value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationObject", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string DestinationObject { get; private set; }

            /// <summary>Resource name of the Cloud KMS key, of the form projects/my-project/locations/global/keyRings
            /// /my-kr/cryptoKeys/my-key, that will be used to encrypt the object. Overrides the object metadata's
            /// kms_key_name value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationKmsKeyName", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string DestinationKmsKeyName { get; set; }

            /// <summary>Apply a predefined set of access controls to the destination object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationPredefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<DestinationPredefinedAclEnum> DestinationPredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to the destination object.</summary>
            public enum DestinationPredefinedAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Makes the operation conditional on whether the destination object's current generation matches
            /// the given value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the destination object's current generation does not
            /// match the given value. If no live object exists, the precondition fails. Setting to 0 makes the
            /// operation succeed only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the destination object's current metageneration
            /// matches the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the destination object's current metageneration does
            /// not match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current generation matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current generation does not
            /// match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current metageneration matches
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current metageneration does not
            /// match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceMetagenerationNotMatch { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>If present, selects a specific revision of the source object (as opposed to the latest version,
            /// the default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("sourceGeneration", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> SourceGeneration { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Object Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "copy";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{sourceBucket}/o/{sourceObject}/copyTo/b/{destinationBucket}/o/{destinationObject}";

            /// <summary>Initializes Copy parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("sourceBucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "sourceBucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sourceObject", new Google.Apis.Discovery.Parameter
                {
                    Name = "sourceObject",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationBucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationBucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationObject", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationObject",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationKmsKeyName", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationKmsKeyName",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationPredefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationPredefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sourceGeneration", new Google.Apis.Discovery.Parameter
                {
                    Name = "sourceGeneration",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Deletes an object and its metadata. Deletions are permanent if versioning is not enabled for the
        /// bucket, or if the generation parameter is used.</summary>
        /// <param name="bucket">Name of the bucket in which the object resides.</param>
        /// <param
        /// name="storageObject">Name of the object. For information about how to URL encode object names to be path safe, see
        /// Encoding URI Path Parts.</param>
        public virtual DeleteRequest Delete(string bucket, string storageObject)
        {
            return new DeleteRequest(service, bucket, storageObject);
        }

        /// <summary>Deletes an object and its metadata. Deletions are permanent if versioning is not enabled for the
        /// bucket, or if the generation parameter is used.</summary>
        public class DeleteRequest : StorageBaseServiceRequest<string>
        {
            /// <summary>Constructs a new Delete request.</summary>
            public DeleteRequest(Google.Apis.Services.IClientService service, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                InitParameters();
            }


            /// <summary>Name of the bucket in which the object resides.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, permanently deletes a specific revision of this object (as opposed to the latest
            /// version, the default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation does not match the
            /// given value. If no live object exists, the precondition fails. Setting to 0 makes the operation succeed
            /// only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration does not match
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "delete";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "DELETE";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}";

            /// <summary>Initializes Delete parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Retrieves an object or its metadata.</summary>
        /// <param name="bucket">Name of the bucket in which the object resides.</param>
        /// <param
        /// name="storageObject">Name of the object. For information about how to URL encode object names to be path safe, see
        /// Encoding URI Path Parts.</param>
        public virtual GetRequest Get(string bucket, string storageObject)
        {
            return new GetRequest(service, bucket, storageObject);
        }

        /// <summary>Retrieves an object or its metadata.</summary>
        public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Object>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                MediaDownloader = new Google.Apis.Download.MediaDownloader(service);
                InitParameters();
            }


            /// <summary>Name of the bucket in which the object resides.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation does not match the
            /// given value. If no live object exists, the precondition fails. Setting to 0 makes the operation succeed
            /// only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration does not match
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "get";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}";

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

            /// <summary>Gets the media downloader.</summary>
            public Google.Apis.Download.IMediaDownloader MediaDownloader { get; private set; }

            /// <summary>
            /// <para>Synchronously download the media into the given stream.</para>
            /// <para>Warning: This method hides download errors; use <see cref="DownloadWithStatus"/> instead.</para>
            /// </summary>
            public virtual void Download(System.IO.Stream stream)
            {
                MediaDownloader.Download(this.GenerateRequestUri(), stream);
            }

            /// <summary>Synchronously download the media into the given stream.</summary>
            /// <returns>The final status of the download; including whether the download succeeded or failed.</returns>
            public virtual Google.Apis.Download.IDownloadProgress DownloadWithStatus(System.IO.Stream stream)
            {
                return MediaDownloader.Download(this.GenerateRequestUri(), stream);
            }

            /// <summary>Asynchronously download the media into the given stream.</summary>
            public virtual System.Threading.Tasks.Task<Google.Apis.Download.IDownloadProgress> DownloadAsync(System.IO.Stream stream)
            {
                return MediaDownloader.DownloadAsync(this.GenerateRequestUri(), stream);
            }

            /// <summary>Asynchronously download the media into the given stream.</summary>
            public virtual System.Threading.Tasks.Task<Google.Apis.Download.IDownloadProgress> DownloadAsync(System.IO.Stream stream,
                System.Threading.CancellationToken cancellationToken)
            {
                return MediaDownloader.DownloadAsync(this.GenerateRequestUri(), stream, cancellationToken);
            }

            #if !NET40
            /// <summary>Synchronously download a range of the media into the given stream.</summary>
            public virtual Google.Apis.Download.IDownloadProgress DownloadRange(System.IO.Stream stream, System.Net.Http.Headers.RangeHeaderValue range)
            {
                var mediaDownloader = new Google.Apis.Download.MediaDownloader(Service);
                mediaDownloader.Range = range;
                return mediaDownloader.Download(this.GenerateRequestUri(), stream);
            }

            /// <summary>Asynchronously download a range of the media into the given stream.</summary>
            public virtual System.Threading.Tasks.Task<Google.Apis.Download.IDownloadProgress> DownloadRangeAsync(System.IO.Stream stream,
                System.Net.Http.Headers.RangeHeaderValue range,
                System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                var mediaDownloader = new Google.Apis.Download.MediaDownloader(Service);
                mediaDownloader.Range = range;
                return mediaDownloader.DownloadAsync(this.GenerateRequestUri(), stream, cancellationToken);
            }
            #endif

        }

        /// <summary>Returns an IAM policy for the specified object.</summary>
        /// <param name="bucket">Name of the bucket in which the object resides.</param>
        /// <param
        /// name="storageObject">Name of the object. For information about how to URL encode object names to be path safe, see
        /// Encoding URI Path Parts.</param>
        public virtual GetIamPolicyRequest GetIamPolicy(string bucket, string storageObject)
        {
            return new GetIamPolicyRequest(service, bucket, storageObject);
        }

        /// <summary>Returns an IAM policy for the specified object.</summary>
        public class GetIamPolicyRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Policy>
        {
            /// <summary>Constructs a new GetIamPolicy request.</summary>
            public GetIamPolicyRequest(Google.Apis.Services.IClientService service, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                InitParameters();
            }


            /// <summary>Name of the bucket in which the object resides.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "getIamPolicy";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/iam";

            /// <summary>Initializes GetIamPolicy parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Stores a new object and metadata.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of the bucket in which to store the new object. Overrides the provided object metadata's
        /// bucket value, if any.</param>
        public virtual InsertRequest Insert(Google.Apis.Storage.v1.Data.Object body, string bucket)
        {
            return new InsertRequest(service, body, bucket);
        }

        /// <summary>Stores a new object and metadata.</summary>
        public class InsertRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Object>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Object body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket in which to store the new object. Overrides the provided object metadata's
            /// bucket value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>If set, sets the contentEncoding property of the final object to this value. Setting this
            /// parameter is equivalent to setting the contentEncoding metadata property. This can be useful when
            /// uploading an object with uploadType=media to indicate the encoding of the content being
            /// uploaded.</summary>
            [Google.Apis.Util.RequestParameterAttribute("contentEncoding", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ContentEncoding { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation does not match the
            /// given value. If no live object exists, the precondition fails. Setting to 0 makes the operation succeed
            /// only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration does not match
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Resource name of the Cloud KMS key, of the form projects/my-project/locations/global/keyRings
            /// /my-kr/cryptoKeys/my-key, that will be used to encrypt the object. Overrides the object metadata's
            /// kms_key_name value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("kmsKeyName", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string KmsKeyName { get; set; }

            /// <summary>Name of the object. Required when the object metadata is not otherwise provided. Overrides the
            /// object metadata's name value, if any. For information about how to URL encode object names to be path
            /// safe, see Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("name", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Name { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedAclEnum> PredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            public enum PredefinedAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Object Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "insert";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o";

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("contentEncoding", new Google.Apis.Discovery.Parameter
                {
                    Name = "contentEncoding",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("kmsKeyName", new Google.Apis.Discovery.Parameter
                {
                    Name = "kmsKeyName",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("name", new Google.Apis.Discovery.Parameter
                {
                    Name = "name",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Stores a new object and metadata.</summary>
        /// <remarks>
        /// Considerations regarding <paramref name="stream"/>:
        /// <list type="bullet">
        /// <item><description>
        /// If <paramref name="stream"/> is seekable, then the stream position will be reset to
        /// <c>0</c> before reading commences. If <paramref name="stream"/> is not
        /// seekable, then it will be read from its current position.
        /// </description></item>
        /// <item><description>
        /// Caller is responsible for maintaining the <paramref name="stream"/> open until the
        /// upload is completed.
        /// </description></item>
        /// <item><description>
        /// Caller is responsible for closing the <paramref name="stream"/>.
        /// </description></item>
        /// </list>
        /// </remarks>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of the bucket in which to store the new object. Overrides the provided object metadata's
        /// bucket value, if any.</param>
        /// <param name="stream">The stream to upload. See remarks for further information.</param>
        /// <param name="contentType">The content type of the stream to upload.</param>
        public virtual InsertMediaUpload Insert(Google.Apis.Storage.v1.Data.Object body, string bucket, System.IO.Stream stream, string contentType)
        {
            return new InsertMediaUpload(service, body, bucket, stream, contentType);
        }

        /// <summary>Insert media upload which supports resumable upload.</summary>
        public class InsertMediaUpload : Google.Apis.Upload.ResumableUpload<Google.Apis.Storage.v1.Data.Object, Google.Apis.Storage.v1.Data.Object>
        {

            /// <summary>Data format for the response.</summary>
            [Google.Apis.Util.RequestParameterAttribute("alt", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<AltEnum> Alt { get; set; }

            /// <summary>Data format for the response.</summary>
            public enum AltEnum
            {
                /// <summary>Responses with Content-Type of application/json</summary>
                [Google.Apis.Util.StringValueAttribute("json")]
                Json,
            }

            /// <summary>Selector specifying which fields to include in a partial response.</summary>
            [Google.Apis.Util.RequestParameterAttribute("fields", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Fields { get; set; }

            /// <summary>API key. Your API key identifies your project and provides you with API access, quota, and
            /// reports. Required unless you provide an OAuth 2.0 token.</summary>
            [Google.Apis.Util.RequestParameterAttribute("key", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Key { get; set; }

            /// <summary>OAuth 2.0 token for the current user.</summary>
            [Google.Apis.Util.RequestParameterAttribute("oauth_token", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string OauthToken { get; set; }

            /// <summary>Returns response with indentations and line breaks.</summary>
            [Google.Apis.Util.RequestParameterAttribute("prettyPrint", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> PrettyPrint { get; set; }

            /// <summary>An opaque string that represents a user for quota purposes. Must not exceed 40
            /// characters.</summary>
            [Google.Apis.Util.RequestParameterAttribute("quotaUser", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string QuotaUser { get; set; }

            /// <summary>Deprecated. Please use quotaUser instead.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userIp", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserIp { get; set; }


            /// <summary>Name of the bucket in which to store the new object. Overrides the provided object metadata's
            /// bucket value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>If set, sets the contentEncoding property of the final object to this value. Setting this
            /// parameter is equivalent to setting the contentEncoding metadata property. This can be useful when
            /// uploading an object with uploadType=media to indicate the encoding of the content being
            /// uploaded.</summary>
            [Google.Apis.Util.RequestParameterAttribute("contentEncoding", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ContentEncoding { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation does not match the
            /// given value. If no live object exists, the precondition fails. Setting to 0 makes the operation succeed
            /// only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration does not match
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Resource name of the Cloud KMS key, of the form projects/my-project/locations/global/keyRings
            /// /my-kr/cryptoKeys/my-key, that will be used to encrypt the object. Overrides the object metadata's
            /// kms_key_name value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("kmsKeyName", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string KmsKeyName { get; set; }

            /// <summary>Name of the object. Required when the object metadata is not otherwise provided. Overrides the
            /// object metadata's name value, if any. For information about how to URL encode object names to be path
            /// safe, see Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("name", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Name { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedAclEnum> PredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            public enum PredefinedAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }

            /// <summary>Constructs a new Insert media upload instance.</summary>
            /// <remarks>
            /// Considerations regarding <paramref name="stream"/>:
            /// <list type="bullet">
            /// <item><description>
            /// If <paramref name="stream"/> is seekable, then the stream position will be reset to
            /// <c>0</c> before reading commences. If <paramref name="stream"/> is not
            /// seekable, then it will be read from its current position.
            /// </description></item>
            /// <item><description>
            /// Caller is responsible for maintaining the <paramref name="stream"/> open until the
            /// upload is completed.
            /// </description></item>
            /// <item><description>
            /// Caller is responsible for closing the <paramref name="stream"/>.
            /// </description></item>
            /// </list>
            /// </remarks>
            public InsertMediaUpload(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Object body, string bucket, System.IO.Stream stream, string contentType)
                : base(service, string.Format("/{0}/{1}{2}", "upload", service.BasePath, "b/{bucket}/o"), "POST", stream, contentType)
            {
                Bucket = bucket;
                Body = body;
            }
        }

        /// <summary>Retrieves a list of objects matching the criteria.</summary>
        /// <param name="bucket">Name of the bucket in which to look for objects.</param>
        public virtual ListRequest List(string bucket)
        {
            return new ListRequest(service, bucket);
        }

        /// <summary>Retrieves a list of objects matching the criteria.</summary>
        public class ListRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Objects>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service, string bucket) : base(service)
            {
                Bucket = bucket;
                InitParameters();
            }


            /// <summary>Name of the bucket in which to look for objects.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Returns results in a directory-like mode. items will contain only objects whose names, aside
            /// from the prefix, do not contain delimiter. Objects whose names, aside from the prefix, contain delimiter
            /// will have their name, truncated after the delimiter, returned in prefixes. Duplicate prefixes are
            /// omitted.</summary>
            [Google.Apis.Util.RequestParameterAttribute("delimiter", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Delimiter { get; set; }

            /// <summary>Filter results to objects whose names are lexicographically before endOffset. If startOffset is
            /// also set, the objects listed will have names between startOffset (inclusive) and endOffset
            /// (exclusive).</summary>
            [Google.Apis.Util.RequestParameterAttribute("endOffset", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string EndOffset { get; set; }

            /// <summary>If true, objects that end in exactly one instance of delimiter will have their metadata
            /// included in items in addition to prefixes.</summary>
            [Google.Apis.Util.RequestParameterAttribute("includeTrailingDelimiter", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> IncludeTrailingDelimiter { get; set; }

            /// <summary>Maximum number of items plus prefixes to return in a single page of responses. As duplicate
            /// prefixes are omitted, fewer total results may be returned than requested. The service will use this
            /// parameter or 1,000 items, whichever is smaller.</summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> MaxResults { get; set; }

            /// <summary>A previously-returned page token representing part of the larger set of results to
            /// view.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>Filter results to objects whose names begin with this prefix.</summary>
            [Google.Apis.Util.RequestParameterAttribute("prefix", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Prefix { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>Filter results to objects whose names are lexicographically equal to or after startOffset. If
            /// endOffset is also set, the objects listed will have names between startOffset (inclusive) and endOffset
            /// (exclusive).</summary>
            [Google.Apis.Util.RequestParameterAttribute("startOffset", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string StartOffset { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }

            /// <summary>If true, lists all versions of an object as distinct results. The default is false. For more
            /// information, see Object Versioning.</summary>
            [Google.Apis.Util.RequestParameterAttribute("versions", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> Versions { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "list";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o";

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("delimiter", new Google.Apis.Discovery.Parameter
                {
                    Name = "delimiter",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("endOffset", new Google.Apis.Discovery.Parameter
                {
                    Name = "endOffset",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("includeTrailingDelimiter", new Google.Apis.Discovery.Parameter
                {
                    Name = "includeTrailingDelimiter",
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
                    DefaultValue = "1000",
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
                RequestParameters.Add("prefix", new Google.Apis.Discovery.Parameter
                {
                    Name = "prefix",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("startOffset", new Google.Apis.Discovery.Parameter
                {
                    Name = "startOffset",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("versions", new Google.Apis.Discovery.Parameter
                {
                    Name = "versions",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Patches an object's metadata.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of the bucket in which the object resides.</param>
        /// <param
        /// name="storageObject">Name of the object. For information about how to URL encode object names to be path safe, see
        /// Encoding URI Path Parts.</param>
        public virtual PatchRequest Patch(Google.Apis.Storage.v1.Data.Object body, string bucket, string storageObject)
        {
            return new PatchRequest(service, body, bucket, storageObject);
        }

        /// <summary>Patches an object's metadata.</summary>
        public class PatchRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Object>
        {
            /// <summary>Constructs a new Patch request.</summary>
            public PatchRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Object body, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket in which the object resides.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation does not match the
            /// given value. If no live object exists, the precondition fails. Setting to 0 makes the operation succeed
            /// only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration does not match
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedAclEnum> PredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            public enum PredefinedAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request, for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Object Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "patch";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PATCH";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}";

            /// <summary>Initializes Patch parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Rewrites a source object to a destination object. Optionally overrides metadata.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="sourceBucket">Name of the bucket in which to find the source object.</param>
        /// <param
        /// name="sourceObject">Name of the source object. For information about how to URL encode object names to be path safe,
        /// see Encoding URI Path Parts.</param>
        /// <param name="destinationBucket">Name of the bucket in which to store
        /// the new object. Overrides the provided object metadata's bucket value, if any.</param>
        /// <param
        /// name="destinationObject">Name of the new object. Required when the object metadata is not otherwise provided.
        /// Overrides the object metadata's name value, if any. For information about how to URL encode object names to be path
        /// safe, see Encoding URI Path Parts.</param>
        public virtual RewriteRequest Rewrite(Google.Apis.Storage.v1.Data.Object body, string sourceBucket, string sourceObject, string destinationBucket, string destinationObject)
        {
            return new RewriteRequest(service, body, sourceBucket, sourceObject, destinationBucket, destinationObject);
        }

        /// <summary>Rewrites a source object to a destination object. Optionally overrides metadata.</summary>
        public class RewriteRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.RewriteResponse>
        {
            /// <summary>Constructs a new Rewrite request.</summary>
            public RewriteRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Object body, string sourceBucket, string sourceObject, string destinationBucket, string destinationObject) : base(service)
            {
                SourceBucket = sourceBucket;
                SourceObject = sourceObject;
                DestinationBucket = destinationBucket;
                DestinationObject = destinationObject;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket in which to find the source object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("sourceBucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string SourceBucket { get; private set; }

            /// <summary>Name of the source object. For information about how to URL encode object names to be path
            /// safe, see Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("sourceObject", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string SourceObject { get; private set; }

            /// <summary>Name of the bucket in which to store the new object. Overrides the provided object metadata's
            /// bucket value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationBucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string DestinationBucket { get; private set; }

            /// <summary>Name of the new object. Required when the object metadata is not otherwise provided. Overrides
            /// the object metadata's name value, if any. For information about how to URL encode object names to be
            /// path safe, see Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationObject", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string DestinationObject { get; private set; }

            /// <summary>Resource name of the Cloud KMS key, of the form projects/my-project/locations/global/keyRings
            /// /my-kr/cryptoKeys/my-key, that will be used to encrypt the object. Overrides the object metadata's
            /// kms_key_name value, if any.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationKmsKeyName", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string DestinationKmsKeyName { get; set; }

            /// <summary>Apply a predefined set of access controls to the destination object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("destinationPredefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<DestinationPredefinedAclEnum> DestinationPredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to the destination object.</summary>
            public enum DestinationPredefinedAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation does not match the
            /// given value. If no live object exists, the precondition fails. Setting to 0 makes the operation succeed
            /// only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the destination object's current metageneration
            /// matches the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the destination object's current metageneration does
            /// not match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current generation matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current generation does not
            /// match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current metageneration matches
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the source object's current metageneration does not
            /// match the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifSourceMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfSourceMetagenerationNotMatch { get; set; }

            /// <summary>The maximum number of bytes that will be rewritten per rewrite request. Most callers shouldn't
            /// need to specify this parameter - it is primarily in place to support testing. If specified the value
            /// must be an integral multiple of 1 MiB (1048576). Also, this only applies to requests where the source
            /// and destination span locations and/or storage classes. Finally, this value must not change across
            /// rewrite calls else you'll get an error that the rewriteToken is invalid.</summary>
            [Google.Apis.Util.RequestParameterAttribute("maxBytesRewrittenPerCall", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> MaxBytesRewrittenPerCall { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl, unless the object resource specifies the acl
            /// property, when it defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>Include this field (from the previous rewrite response) on each rewrite request after the first
            /// one, until the rewrite response 'done' flag is true. Calls that provide a rewriteToken can omit all
            /// other request fields, but if included those fields must match the values provided in the first rewrite
            /// request.</summary>
            [Google.Apis.Util.RequestParameterAttribute("rewriteToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string RewriteToken { get; set; }

            /// <summary>If present, selects a specific revision of the source object (as opposed to the latest version,
            /// the default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("sourceGeneration", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> SourceGeneration { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Object Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "rewrite";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{sourceBucket}/o/{sourceObject}/rewriteTo/b/{destinationBucket}/o/{destinationObject}";

            /// <summary>Initializes Rewrite parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("sourceBucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "sourceBucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sourceObject", new Google.Apis.Discovery.Parameter
                {
                    Name = "sourceObject",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationBucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationBucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationObject", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationObject",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationKmsKeyName", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationKmsKeyName",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("destinationPredefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "destinationPredefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifSourceMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifSourceMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("maxBytesRewrittenPerCall", new Google.Apis.Discovery.Parameter
                {
                    Name = "maxBytesRewrittenPerCall",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("rewriteToken", new Google.Apis.Discovery.Parameter
                {
                    Name = "rewriteToken",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("sourceGeneration", new Google.Apis.Discovery.Parameter
                {
                    Name = "sourceGeneration",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Updates an IAM policy for the specified object.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of the bucket in which the object resides.</param>
        /// <param
        /// name="storageObject">Name of the object. For information about how to URL encode object names to be path safe, see
        /// Encoding URI Path Parts.</param>
        public virtual SetIamPolicyRequest SetIamPolicy(Google.Apis.Storage.v1.Data.Policy body, string bucket, string storageObject)
        {
            return new SetIamPolicyRequest(service, body, bucket, storageObject);
        }

        /// <summary>Updates an IAM policy for the specified object.</summary>
        public class SetIamPolicyRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Policy>
        {
            /// <summary>Constructs a new SetIamPolicy request.</summary>
            public SetIamPolicyRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Policy body, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket in which the object resides.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Policy Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "setIamPolicy";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/iam";

            /// <summary>Initializes SetIamPolicy parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Tests a set of permissions on the given object to see which, if any, are held by the
        /// caller.</summary>
        /// <param name="bucket">Name of the bucket in which the object resides.</param>
        /// <param
        /// name="storageObject">Name of the object. For information about how to URL encode object names to be path safe, see
        /// Encoding URI Path Parts.</param>
        /// <param name="permissions">Permissions to test.</param>
        public virtual TestIamPermissionsRequest TestIamPermissions(string bucket, string storageObject, Google.Apis.Util.Repeatable<string> permissions)
        {
            return new TestIamPermissionsRequest(service, bucket, storageObject, permissions);
        }

        /// <summary>Tests a set of permissions on the given object to see which, if any, are held by the
        /// caller.</summary>
        public class TestIamPermissionsRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.TestIamPermissionsResponse>
        {
            /// <summary>Constructs a new TestIamPermissions request.</summary>
            public TestIamPermissionsRequest(Google.Apis.Services.IClientService service, string bucket, string storageObject, Google.Apis.Util.Repeatable<string> permissions) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Permissions = permissions;
                InitParameters();
            }


            /// <summary>Name of the bucket in which the object resides.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>Permissions to test.</summary>
            [Google.Apis.Util.RequestParameterAttribute("permissions", Google.Apis.Util.RequestParameterType.Query)]
            public virtual Google.Apis.Util.Repeatable<string> Permissions { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets the method name.</summary>
            public override string MethodName => "testIamPermissions";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "GET";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}/iam/testPermissions";

            /// <summary>Initializes TestIamPermissions parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("permissions", new Google.Apis.Discovery.Parameter
                {
                    Name = "permissions",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Updates an object's metadata.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of the bucket in which the object resides.</param>
        /// <param
        /// name="storageObject">Name of the object. For information about how to URL encode object names to be path safe, see
        /// Encoding URI Path Parts.</param>
        public virtual UpdateRequest Update(Google.Apis.Storage.v1.Data.Object body, string bucket, string storageObject)
        {
            return new UpdateRequest(service, body, bucket, storageObject);
        }

        /// <summary>Updates an object's metadata.</summary>
        public class UpdateRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Object>
        {
            /// <summary>Constructs a new Update request.</summary>
            public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Object body, string bucket, string storageObject) : base(service)
            {
                Bucket = bucket;
                Object = storageObject;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket in which the object resides.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Name of the object. For information about how to URL encode object names to be path safe, see
            /// Encoding URI Path Parts.</summary>
            [Google.Apis.Util.RequestParameterAttribute("object", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Object { get; private set; }

            /// <summary>If present, selects a specific revision of this object (as opposed to the latest version, the
            /// default).</summary>
            [Google.Apis.Util.RequestParameterAttribute("generation", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> Generation { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation matches the given
            /// value. Setting to 0 makes the operation succeed only if there are no live versions of the
            /// object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current generation does not match the
            /// given value. If no live object exists, the precondition fails. Setting to 0 makes the operation succeed
            /// only if there is a live version of the object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifGenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfGenerationNotMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration matches the
            /// given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationMatch { get; set; }

            /// <summary>Makes the operation conditional on whether the object's current metageneration does not match
            /// the given value.</summary>
            [Google.Apis.Util.RequestParameterAttribute("ifMetagenerationNotMatch", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> IfMetagenerationNotMatch { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            [Google.Apis.Util.RequestParameterAttribute("predefinedAcl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<PredefinedAclEnum> PredefinedAcl { get; set; }

            /// <summary>Apply a predefined set of access controls to this object.</summary>
            public enum PredefinedAclEnum
            {
                /// <summary>Object owner gets OWNER access, and allAuthenticatedUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("authenticatedRead")]
                AuthenticatedRead,
                /// <summary>Object owner gets OWNER access, and project team owners get OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerFullControl")]
                BucketOwnerFullControl,
                /// <summary>Object owner gets OWNER access, and project team owners get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("bucketOwnerRead")]
                BucketOwnerRead,
                /// <summary>Object owner gets OWNER access.</summary>
                [Google.Apis.Util.StringValueAttribute("private")]
                Private__,
                /// <summary>Object owner gets OWNER access, and project team members get access according to their
                /// roles.</summary>
                [Google.Apis.Util.StringValueAttribute("projectPrivate")]
                ProjectPrivate,
                /// <summary>Object owner gets OWNER access, and allUsers get READER access.</summary>
                [Google.Apis.Util.StringValueAttribute("publicRead")]
                PublicRead,
            }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to full.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Object Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "update";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "PUT";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/{object}";

            /// <summary>Initializes Update parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("object", new Google.Apis.Discovery.Parameter
                {
                    Name = "object",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("generation", new Google.Apis.Discovery.Parameter
                {
                    Name = "generation",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifGenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifGenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("ifMetagenerationNotMatch", new Google.Apis.Discovery.Parameter
                {
                    Name = "ifMetagenerationNotMatch",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("predefinedAcl", new Google.Apis.Discovery.Parameter
                {
                    Name = "predefinedAcl",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }

        /// <summary>Watch for changes on all objects in a bucket.</summary>
        /// <param name="body">The body of the request.</param>
        /// <param name="bucket">Name of the bucket in which to look for objects.</param>
        public virtual WatchAllRequest WatchAll(Google.Apis.Storage.v1.Data.Channel body, string bucket)
        {
            return new WatchAllRequest(service, body, bucket);
        }

        /// <summary>Watch for changes on all objects in a bucket.</summary>
        public class WatchAllRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.Channel>
        {
            /// <summary>Constructs a new WatchAll request.</summary>
            public WatchAllRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.Channel body, string bucket) : base(service)
            {
                Bucket = bucket;
                Body = body;
                InitParameters();
            }


            /// <summary>Name of the bucket in which to look for objects.</summary>
            [Google.Apis.Util.RequestParameterAttribute("bucket", Google.Apis.Util.RequestParameterType.Path)]
            public virtual string Bucket { get; private set; }

            /// <summary>Returns results in a directory-like mode. items will contain only objects whose names, aside
            /// from the prefix, do not contain delimiter. Objects whose names, aside from the prefix, contain delimiter
            /// will have their name, truncated after the delimiter, returned in prefixes. Duplicate prefixes are
            /// omitted.</summary>
            [Google.Apis.Util.RequestParameterAttribute("delimiter", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Delimiter { get; set; }

            /// <summary>Filter results to objects whose names are lexicographically before endOffset. If startOffset is
            /// also set, the objects listed will have names between startOffset (inclusive) and endOffset
            /// (exclusive).</summary>
            [Google.Apis.Util.RequestParameterAttribute("endOffset", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string EndOffset { get; set; }

            /// <summary>If true, objects that end in exactly one instance of delimiter will have their metadata
            /// included in items in addition to prefixes.</summary>
            [Google.Apis.Util.RequestParameterAttribute("includeTrailingDelimiter", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> IncludeTrailingDelimiter { get; set; }

            /// <summary>Maximum number of items plus prefixes to return in a single page of responses. As duplicate
            /// prefixes are omitted, fewer total results may be returned than requested. The service will use this
            /// parameter or 1,000 items, whichever is smaller.</summary>
            [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<long> MaxResults { get; set; }

            /// <summary>A previously-returned page token representing part of the larger set of results to
            /// view.</summary>
            [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string PageToken { get; set; }

            /// <summary>Filter results to objects whose names begin with this prefix.</summary>
            [Google.Apis.Util.RequestParameterAttribute("prefix", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string Prefix { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Set of properties to return. Defaults to noAcl.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Include all properties.</summary>
                [Google.Apis.Util.StringValueAttribute("full")]
                Full,
                /// <summary>Omit the owner, acl property.</summary>
                [Google.Apis.Util.StringValueAttribute("noAcl")]
                NoAcl,
            }

            /// <summary>The project to be billed for this request if the target bucket is requester-pays
            /// bucket.</summary>
            [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ProvisionalUserProject { get; set; }

            /// <summary>Filter results to objects whose names are lexicographically equal to or after startOffset. If
            /// endOffset is also set, the objects listed will have names between startOffset (inclusive) and endOffset
            /// (exclusive).</summary>
            [Google.Apis.Util.RequestParameterAttribute("startOffset", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string StartOffset { get; set; }

            /// <summary>The project to be billed for this request. Required for Requester Pays buckets.</summary>
            [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string UserProject { get; set; }

            /// <summary>If true, lists all versions of an object as distinct results. The default is false. For more
            /// information, see Object Versioning.</summary>
            [Google.Apis.Util.RequestParameterAttribute("versions", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<bool> Versions { get; set; }


            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Storage.v1.Data.Channel Body { get; set; }

            /// <summary>Returns the body of the request.</summary>
            protected override object GetBody() => Body;

            /// <summary>Gets the method name.</summary>
            public override string MethodName => "watchAll";

            /// <summary>Gets the HTTP method.</summary>
            public override string HttpMethod => "POST";

            /// <summary>Gets the REST path.</summary>
            public override string RestPath => "b/{bucket}/o/watch";

            /// <summary>Initializes WatchAll parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add("bucket", new Google.Apis.Discovery.Parameter
                {
                    Name = "bucket",
                    IsRequired = true,
                    ParameterType = "path",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("delimiter", new Google.Apis.Discovery.Parameter
                {
                    Name = "delimiter",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("endOffset", new Google.Apis.Discovery.Parameter
                {
                    Name = "endOffset",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("includeTrailingDelimiter", new Google.Apis.Discovery.Parameter
                {
                    Name = "includeTrailingDelimiter",
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
                    DefaultValue = "1000",
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
                RequestParameters.Add("prefix", new Google.Apis.Discovery.Parameter
                {
                    Name = "prefix",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("projection", new Google.Apis.Discovery.Parameter
                {
                    Name = "projection",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "provisionalUserProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("startOffset", new Google.Apis.Discovery.Parameter
                {
                    Name = "startOffset",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                {
                    Name = "userProject",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
                RequestParameters.Add("versions", new Google.Apis.Discovery.Parameter
                {
                    Name = "versions",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            }

        }
    }

    /// <summary>The "projects" collection of methods.</summary>
    public class ProjectsResource
    {
        private const string Resource = "projects";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public ProjectsResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;
            HmacKeys = new HmacKeysResource(service);
            ServiceAccount = new ServiceAccountResource(service);

        }

        /// <summary>Gets the HmacKeys resource.</summary>
        public virtual HmacKeysResource HmacKeys { get; }

        /// <summary>The "hmacKeys" collection of methods.</summary>
        public class HmacKeysResource
        {
            private const string Resource = "hmacKeys";

            /// <summary>The service which this resource belongs to.</summary>
            private readonly Google.Apis.Services.IClientService service;

            /// <summary>Constructs a new resource.</summary>
            public HmacKeysResource(Google.Apis.Services.IClientService service)
            {
                this.service = service;

            }


            /// <summary>Creates a new HMAC key for the specified service account.</summary>
            /// <param name="projectId">Project ID owning the service account.</param>
            /// <param
            /// name="serviceAccountEmail">Email address of the service account.</param>
            public virtual CreateRequest Create(string projectId, string serviceAccountEmail)
            {
                return new CreateRequest(service, projectId, serviceAccountEmail);
            }

            /// <summary>Creates a new HMAC key for the specified service account.</summary>
            public class CreateRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.HmacKey>
            {
                /// <summary>Constructs a new Create request.</summary>
                public CreateRequest(Google.Apis.Services.IClientService service, string projectId, string serviceAccountEmail) : base(service)
                {
                    ProjectId = projectId;
                    ServiceAccountEmail = serviceAccountEmail;
                    InitParameters();
                }


                /// <summary>Project ID owning the service account.</summary>
                [Google.Apis.Util.RequestParameterAttribute("projectId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string ProjectId { get; private set; }

                /// <summary>Email address of the service account.</summary>
                [Google.Apis.Util.RequestParameterAttribute("serviceAccountEmail", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string ServiceAccountEmail { get; private set; }

                /// <summary>The project to be billed for this request.</summary>
                [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string UserProject { get; set; }


                /// <summary>Gets the method name.</summary>
                public override string MethodName => "create";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "POST";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "projects/{projectId}/hmacKeys";

                /// <summary>Initializes Create parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();

                    RequestParameters.Add("projectId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projectId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("serviceAccountEmail", new Google.Apis.Discovery.Parameter
                    {
                        Name = "serviceAccountEmail",
                        IsRequired = true,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                    {
                        Name = "userProject",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }

            }

            /// <summary>Deletes an HMAC key.</summary>
            /// <param name="projectId">Project ID owning the requested key</param>
            /// <param name="accessId">Name of the HMAC
            /// key to be deleted.</param>
            public virtual DeleteRequest Delete(string projectId, string accessId)
            {
                return new DeleteRequest(service, projectId, accessId);
            }

            /// <summary>Deletes an HMAC key.</summary>
            public class DeleteRequest : StorageBaseServiceRequest<string>
            {
                /// <summary>Constructs a new Delete request.</summary>
                public DeleteRequest(Google.Apis.Services.IClientService service, string projectId, string accessId) : base(service)
                {
                    ProjectId = projectId;
                    AccessId = accessId;
                    InitParameters();
                }


                /// <summary>Project ID owning the requested key</summary>
                [Google.Apis.Util.RequestParameterAttribute("projectId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string ProjectId { get; private set; }

                /// <summary>Name of the HMAC key to be deleted.</summary>
                [Google.Apis.Util.RequestParameterAttribute("accessId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string AccessId { get; private set; }

                /// <summary>The project to be billed for this request.</summary>
                [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string UserProject { get; set; }


                /// <summary>Gets the method name.</summary>
                public override string MethodName => "delete";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "DELETE";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "projects/{projectId}/hmacKeys/{accessId}";

                /// <summary>Initializes Delete parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();

                    RequestParameters.Add("projectId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projectId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("accessId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "accessId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                    {
                        Name = "userProject",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }

            }

            /// <summary>Retrieves an HMAC key's metadata</summary>
            /// <param name="projectId">Project ID owning the service account of the requested key.</param>
            /// <param
            /// name="accessId">Name of the HMAC key.</param>
            public virtual GetRequest Get(string projectId, string accessId)
            {
                return new GetRequest(service, projectId, accessId);
            }

            /// <summary>Retrieves an HMAC key's metadata</summary>
            public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.HmacKeyMetadata>
            {
                /// <summary>Constructs a new Get request.</summary>
                public GetRequest(Google.Apis.Services.IClientService service, string projectId, string accessId) : base(service)
                {
                    ProjectId = projectId;
                    AccessId = accessId;
                    InitParameters();
                }


                /// <summary>Project ID owning the service account of the requested key.</summary>
                [Google.Apis.Util.RequestParameterAttribute("projectId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string ProjectId { get; private set; }

                /// <summary>Name of the HMAC key.</summary>
                [Google.Apis.Util.RequestParameterAttribute("accessId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string AccessId { get; private set; }

                /// <summary>The project to be billed for this request.</summary>
                [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string UserProject { get; set; }


                /// <summary>Gets the method name.</summary>
                public override string MethodName => "get";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "GET";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "projects/{projectId}/hmacKeys/{accessId}";

                /// <summary>Initializes Get parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();

                    RequestParameters.Add("projectId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projectId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("accessId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "accessId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                    {
                        Name = "userProject",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }

            }

            /// <summary>Retrieves a list of HMAC keys matching the criteria.</summary>
            /// <param name="projectId">Name of the project in which to look for HMAC keys.</param>
            public virtual ListRequest List(string projectId)
            {
                return new ListRequest(service, projectId);
            }

            /// <summary>Retrieves a list of HMAC keys matching the criteria.</summary>
            public class ListRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.HmacKeysMetadata>
            {
                /// <summary>Constructs a new List request.</summary>
                public ListRequest(Google.Apis.Services.IClientService service, string projectId) : base(service)
                {
                    ProjectId = projectId;
                    InitParameters();
                }


                /// <summary>Name of the project in which to look for HMAC keys.</summary>
                [Google.Apis.Util.RequestParameterAttribute("projectId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string ProjectId { get; private set; }

                /// <summary>Maximum number of items to return in a single page of responses. The service uses this
                /// parameter or 250 items, whichever is smaller. The max number of items per page will also be limited
                /// by the number of distinct service accounts in the response. If the number of service accounts in a
                /// single response is too high, the page will truncated and a next page token will be
                /// returned.</summary>
                [Google.Apis.Util.RequestParameterAttribute("maxResults", Google.Apis.Util.RequestParameterType.Query)]
                public virtual System.Nullable<long> MaxResults { get; set; }

                /// <summary>A previously-returned page token representing part of the larger set of results to
                /// view.</summary>
                [Google.Apis.Util.RequestParameterAttribute("pageToken", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string PageToken { get; set; }

                /// <summary>If present, only keys for the given service account are returned.</summary>
                [Google.Apis.Util.RequestParameterAttribute("serviceAccountEmail", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string ServiceAccountEmail { get; set; }

                /// <summary>Whether or not to show keys in the DELETED state.</summary>
                [Google.Apis.Util.RequestParameterAttribute("showDeletedKeys", Google.Apis.Util.RequestParameterType.Query)]
                public virtual System.Nullable<bool> ShowDeletedKeys { get; set; }

                /// <summary>The project to be billed for this request.</summary>
                [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string UserProject { get; set; }


                /// <summary>Gets the method name.</summary>
                public override string MethodName => "list";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "GET";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "projects/{projectId}/hmacKeys";

                /// <summary>Initializes List parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();

                    RequestParameters.Add("projectId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projectId",
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
                        DefaultValue = "250",
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
                    RequestParameters.Add("serviceAccountEmail", new Google.Apis.Discovery.Parameter
                    {
                        Name = "serviceAccountEmail",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("showDeletedKeys", new Google.Apis.Discovery.Parameter
                    {
                        Name = "showDeletedKeys",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                    {
                        Name = "userProject",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }

            }

            /// <summary>Updates the state of an HMAC key. See the HMAC Key resource descriptor for valid
            /// states.</summary>
            /// <param name="body">The body of the request.</param>
            /// <param name="projectId">Project ID owning the service account of the updated key.</param>
            /// <param
            /// name="accessId">Name of the HMAC key being updated.</param>
            public virtual UpdateRequest Update(Google.Apis.Storage.v1.Data.HmacKeyMetadata body, string projectId, string accessId)
            {
                return new UpdateRequest(service, body, projectId, accessId);
            }

            /// <summary>Updates the state of an HMAC key. See the HMAC Key resource descriptor for valid
            /// states.</summary>
            public class UpdateRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.HmacKeyMetadata>
            {
                /// <summary>Constructs a new Update request.</summary>
                public UpdateRequest(Google.Apis.Services.IClientService service, Google.Apis.Storage.v1.Data.HmacKeyMetadata body, string projectId, string accessId) : base(service)
                {
                    ProjectId = projectId;
                    AccessId = accessId;
                    Body = body;
                    InitParameters();
                }


                /// <summary>Project ID owning the service account of the updated key.</summary>
                [Google.Apis.Util.RequestParameterAttribute("projectId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string ProjectId { get; private set; }

                /// <summary>Name of the HMAC key being updated.</summary>
                [Google.Apis.Util.RequestParameterAttribute("accessId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string AccessId { get; private set; }

                /// <summary>The project to be billed for this request.</summary>
                [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string UserProject { get; set; }


                /// <summary>Gets or sets the body of this request.</summary>
                Google.Apis.Storage.v1.Data.HmacKeyMetadata Body { get; set; }

                /// <summary>Returns the body of the request.</summary>
                protected override object GetBody() => Body;

                /// <summary>Gets the method name.</summary>
                public override string MethodName => "update";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "PUT";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "projects/{projectId}/hmacKeys/{accessId}";

                /// <summary>Initializes Update parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();

                    RequestParameters.Add("projectId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projectId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("accessId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "accessId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                    {
                        Name = "userProject",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }

            }
        }
        /// <summary>Gets the ServiceAccount resource.</summary>
        public virtual ServiceAccountResource ServiceAccount { get; }

        /// <summary>The "serviceAccount" collection of methods.</summary>
        public class ServiceAccountResource
        {
            private const string Resource = "serviceAccount";

            /// <summary>The service which this resource belongs to.</summary>
            private readonly Google.Apis.Services.IClientService service;

            /// <summary>Constructs a new resource.</summary>
            public ServiceAccountResource(Google.Apis.Services.IClientService service)
            {
                this.service = service;

            }


            /// <summary>Get the email address of this project's Google Cloud Storage service account.</summary>
            /// <param name="projectId">Project ID</param>
            public virtual GetRequest Get(string projectId)
            {
                return new GetRequest(service, projectId);
            }

            /// <summary>Get the email address of this project's Google Cloud Storage service account.</summary>
            public class GetRequest : StorageBaseServiceRequest<Google.Apis.Storage.v1.Data.ServiceAccount>
            {
                /// <summary>Constructs a new Get request.</summary>
                public GetRequest(Google.Apis.Services.IClientService service, string projectId) : base(service)
                {
                    ProjectId = projectId;
                    InitParameters();
                }


                /// <summary>Project ID</summary>
                [Google.Apis.Util.RequestParameterAttribute("projectId", Google.Apis.Util.RequestParameterType.Path)]
                public virtual string ProjectId { get; private set; }

                /// <summary>The project to be billed for this request if the target bucket is requester-pays
                /// bucket.</summary>
                [Google.Apis.Util.RequestParameterAttribute("provisionalUserProject", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string ProvisionalUserProject { get; set; }

                /// <summary>The project to be billed for this request.</summary>
                [Google.Apis.Util.RequestParameterAttribute("userProject", Google.Apis.Util.RequestParameterType.Query)]
                public virtual string UserProject { get; set; }


                /// <summary>Gets the method name.</summary>
                public override string MethodName => "get";

                /// <summary>Gets the HTTP method.</summary>
                public override string HttpMethod => "GET";

                /// <summary>Gets the REST path.</summary>
                public override string RestPath => "projects/{projectId}/serviceAccount";

                /// <summary>Initializes Get parameter list.</summary>
                protected override void InitParameters()
                {
                    base.InitParameters();

                    RequestParameters.Add("projectId", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projectId",
                        IsRequired = true,
                        ParameterType = "path",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("provisionalUserProject", new Google.Apis.Discovery.Parameter
                    {
                        Name = "provisionalUserProject",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                    RequestParameters.Add("userProject", new Google.Apis.Discovery.Parameter
                    {
                        Name = "userProject",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                }

            }
        }
    }
}

namespace Google.Apis.Storage.v1.Data
{    

    /// <summary>A bucket.</summary>
    public class Bucket : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Access controls on the bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("acl")]
        public virtual System.Collections.Generic.IList<BucketAccessControl> Acl { get; set; } 

        /// <summary>The bucket's billing configuration.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("billing")]
        public virtual BillingData Billing { get; set; } 

        /// <summary>The bucket's Cross-Origin Resource Sharing (CORS) configuration.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("cors")]
        public virtual System.Collections.Generic.IList<CorsData> Cors { get; set; } 

        /// <summary>The default value for event-based hold on newly created objects in this bucket. Event-based hold is
        /// a way to retain objects indefinitely until an event occurs, signified by the hold's release. After being
        /// released, such objects will be subject to bucket-level retention (if any). One sample use case of this flag
        /// is for banks to hold loan documents for at least 3 years after loan is paid in full. Here, bucket-level
        /// retention is 3 years and the event is loan being paid in full. In this example, these objects will be held
        /// intact for any number of years until the event has occurred (event-based hold on the object is released) and
        /// then 3 more years after that. That means retention duration of the objects begins from the moment event-
        /// based hold transitioned from true to false. Objects under event-based hold cannot be deleted, overwritten or
        /// archived until the hold is removed.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("defaultEventBasedHold")]
        public virtual System.Nullable<bool> DefaultEventBasedHold { get; set; } 

        /// <summary>Default access controls to apply to new objects when no ACL is provided.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("defaultObjectAcl")]
        public virtual System.Collections.Generic.IList<ObjectAccessControl> DefaultObjectAcl { get; set; } 

        /// <summary>Encryption configuration for a bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("encryption")]
        public virtual EncryptionData Encryption { get; set; } 

        /// <summary>HTTP 1.1 Entity tag for the bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; } 

        /// <summary>The bucket's IAM configuration.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("iamConfiguration")]
        public virtual IamConfigurationData IamConfiguration { get; set; } 

        /// <summary>The ID of the bucket. For buckets, the id and name properties are the same.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The kind of item this is. For buckets, this is always storage#bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>User-provided labels, in key/value pairs.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("labels")]
        public virtual System.Collections.Generic.IDictionary<string,string> Labels { get; set; } 

        /// <summary>The bucket's lifecycle configuration. See lifecycle management for more information.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("lifecycle")]
        public virtual LifecycleData Lifecycle { get; set; } 

        /// <summary>The location of the bucket. Object data for objects in the bucket resides in physical storage
        /// within this region. Defaults to US. See the developer's guide for the authoritative list.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("location")]
        public virtual string Location { get; set; } 

        /// <summary>The type of the bucket location.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("locationType")]
        public virtual string LocationType { get; set; } 

        /// <summary>The bucket's logging configuration, which defines the destination bucket and optional name prefix
        /// for the current bucket's logs.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("logging")]
        public virtual LoggingData Logging { get; set; } 

        /// <summary>The metadata generation of this bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("metageneration")]
        public virtual System.Nullable<long> Metageneration { get; set; } 

        /// <summary>The name of the bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public virtual string Name { get; set; } 

        /// <summary>The owner of the bucket. This is always the project team's owner group.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("owner")]
        public virtual OwnerData Owner { get; set; } 

        /// <summary>The project number of the project the bucket belongs to.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("projectNumber")]
        public virtual System.Nullable<ulong> ProjectNumber { get; set; } 

        /// <summary>The bucket's retention policy. The retention policy enforces a minimum retention time for all
        /// objects contained in the bucket, based on their creation time. Any attempt to overwrite or delete objects
        /// younger than the retention period will result in a PERMISSION_DENIED error. An unlocked retention policy can
        /// be modified or removed from the bucket via a storage.buckets.update operation. A locked retention policy
        /// cannot be removed or shortened in duration for the lifetime of the bucket. Attempting to remove or decrease
        /// period of a locked retention policy will result in a PERMISSION_DENIED error.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("retentionPolicy")]
        public virtual RetentionPolicyData RetentionPolicy { get; set; } 

        /// <summary>The URI of this bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("selfLink")]
        public virtual string SelfLink { get; set; } 

        /// <summary>The bucket's default storage class, used whenever no storageClass is specified for a newly-created
        /// object. This defines how objects in the bucket are stored and determines the SLA and the cost of storage.
        /// Values include MULTI_REGIONAL, REGIONAL, STANDARD, NEARLINE, COLDLINE, ARCHIVE, and
        /// DURABLE_REDUCED_AVAILABILITY. If this value is not specified when the bucket is created, it will default to
        /// STANDARD. For more information, see storage classes.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("storageClass")]
        public virtual string StorageClass { get; set; } 

        /// <summary>The creation time of the bucket in RFC 3339 format.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeCreated")]
        public virtual string TimeCreatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeCreatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> TimeCreated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeCreatedRaw);
            set => TimeCreatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The modification time of the bucket in RFC 3339 format.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("updated")]
        public virtual string UpdatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> Updated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The bucket's versioning configuration.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("versioning")]
        public virtual VersioningData Versioning { get; set; } 

        /// <summary>The bucket's website configuration, controlling how the service behaves when accessing bucket
        /// contents as a web site. See the Static Website Examples for more information.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("website")]
        public virtual WebsiteData Website { get; set; } 

        /// <summary>The zone or zones from which the bucket is intended to use zonal quota. Requests for data from
        /// outside the specified affinities are still allowed but won't be able to use zonal quota. The zone or zones
        /// need to be within the bucket location otherwise the requests will fail with a 400 Bad Request
        /// response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("zoneAffinity")]
        public virtual System.Collections.Generic.IList<string> ZoneAffinity { get; set; } 

        /// <summary>If set, objects placed in this bucket are required to be separated by disaster domain.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("zoneSeparation")]
        public virtual System.Nullable<bool> ZoneSeparation { get; set; } 

        

        /// <summary>The bucket's billing configuration.</summary>
        public class BillingData
        {
            /// <summary>When set to true, Requester Pays is enabled for this bucket.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("requesterPays")]
            public virtual System.Nullable<bool> RequesterPays { get; set; } 

        }    

        public class CorsData
        {
            /// <summary>The value, in seconds, to return in the  Access-Control-Max-Age header used in preflight
            /// responses.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("maxAgeSeconds")]
            public virtual System.Nullable<int> MaxAgeSeconds { get; set; } 

            /// <summary>The list of HTTP methods on which to include CORS response headers, (GET, OPTIONS, POST, etc)
            /// Note: "*" is permitted in the list of methods, and means "any method".</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("method")]
            public virtual System.Collections.Generic.IList<string> Method { get; set; } 

            /// <summary>The list of Origins eligible to receive CORS response headers. Note: "*" is permitted in the
            /// list of origins, and means "any Origin".</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("origin")]
            public virtual System.Collections.Generic.IList<string> Origin { get; set; } 

            /// <summary>The list of HTTP headers other than the simple response headers to give permission for the
            /// user-agent to share across domains.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("responseHeader")]
            public virtual System.Collections.Generic.IList<string> ResponseHeader { get; set; } 

        }    

        /// <summary>Encryption configuration for a bucket.</summary>
        public class EncryptionData
        {
            /// <summary>A Cloud KMS key that will be used to encrypt objects inserted into this bucket, if no
            /// encryption method is specified.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("defaultKmsKeyName")]
            public virtual string DefaultKmsKeyName { get; set; } 

        }    

        /// <summary>The bucket's IAM configuration.</summary>
        public class IamConfigurationData
        {
            /// <summary>The bucket's uniform bucket-level access configuration. The feature was formerly known as
            /// Bucket Policy Only. For backward compatibility, this field will be populated with identical information
            /// as the uniformBucketLevelAccess field. We recommend using the uniformBucketLevelAccess field to enable
            /// and disable the feature.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("bucketPolicyOnly")]
            public virtual BucketPolicyOnlyData BucketPolicyOnly { get; set; } 

            /// <summary>The bucket's uniform bucket-level access configuration.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("uniformBucketLevelAccess")]
            public virtual UniformBucketLevelAccessData UniformBucketLevelAccess { get; set; } 

            

            /// <summary>The bucket's uniform bucket-level access configuration. The feature was formerly known as
            /// Bucket Policy Only. For backward compatibility, this field will be populated with identical information
            /// as the uniformBucketLevelAccess field. We recommend using the uniformBucketLevelAccess field to enable
            /// and disable the feature.</summary>
            public class BucketPolicyOnlyData
            {
                /// <summary>If set, access is controlled only by bucket-level or above IAM policies.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("enabled")]
                public virtual System.Nullable<bool> Enabled { get; set; } 

                /// <summary>The deadline for changing iamConfiguration.bucketPolicyOnly.enabled from true to false in
                /// RFC 3339 format. iamConfiguration.bucketPolicyOnly.enabled may be changed from true to false until
                /// the locked time, after which the field is immutable.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("lockedTime")]
                public virtual string LockedTimeRaw { get; set; }

                /// <summary><seealso cref="System.DateTime"/> representation of <see cref="LockedTimeRaw"/>.</summary>
                [Newtonsoft.Json.JsonIgnoreAttribute]
                public virtual System.Nullable<System.DateTime> LockedTime
                {
                    get => Google.Apis.Util.Utilities.GetDateTimeFromString(LockedTimeRaw);
                    set => LockedTimeRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
                }

            }    

            /// <summary>The bucket's uniform bucket-level access configuration.</summary>
            public class UniformBucketLevelAccessData
            {
                /// <summary>If set, access is controlled only by bucket-level or above IAM policies.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("enabled")]
                public virtual System.Nullable<bool> Enabled { get; set; } 

                /// <summary>The deadline for changing iamConfiguration.uniformBucketLevelAccess.enabled from true to
                /// false in RFC 3339  format. iamConfiguration.uniformBucketLevelAccess.enabled may be changed from
                /// true to false until the locked time, after which the field is immutable.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("lockedTime")]
                public virtual string LockedTimeRaw { get; set; }

                /// <summary><seealso cref="System.DateTime"/> representation of <see cref="LockedTimeRaw"/>.</summary>
                [Newtonsoft.Json.JsonIgnoreAttribute]
                public virtual System.Nullable<System.DateTime> LockedTime
                {
                    get => Google.Apis.Util.Utilities.GetDateTimeFromString(LockedTimeRaw);
                    set => LockedTimeRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
                }

            }
        }    

        /// <summary>The bucket's lifecycle configuration. See lifecycle management for more information.</summary>
        public class LifecycleData
        {
            /// <summary>A lifecycle management rule, which is made of an action to take and the condition(s) under
            /// which the action will be taken.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("rule")]
            public virtual System.Collections.Generic.IList<RuleData> Rule { get; set; } 

            

            public class RuleData
            {
                /// <summary>The action to take.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("action")]
                public virtual ActionData Action { get; set; } 

                /// <summary>The condition(s) under which the action will be taken.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("condition")]
                public virtual ConditionData Condition { get; set; } 

                

                /// <summary>The action to take.</summary>
                public class ActionData
                {
                    /// <summary>Target storage class. Required iff the type of the action is SetStorageClass.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("storageClass")]
                    public virtual string StorageClass { get; set; } 

                    /// <summary>Type of the action. Currently, only Delete and SetStorageClass are supported.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("type")]
                    public virtual string Type { get; set; } 

                }    

                /// <summary>The condition(s) under which the action will be taken.</summary>
                public class ConditionData
                {
                    /// <summary>Age of an object (in days). This condition is satisfied when an object reaches the
                    /// specified age.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("age")]
                    public virtual System.Nullable<int> Age { get; set; } 

                    /// <summary>A date in RFC 3339 format with only the date part (for instance, "2013-01-15"). This
                    /// condition is satisfied when an object is created before midnight of the specified date in
                    /// UTC.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("createdBefore")]
                    public virtual string CreatedBefore { get; set; } 

                    /// <summary>A date in RFC 3339 format with only the date part (for instance, "2013-01-15"). This
                    /// condition is satisfied when the custom time on an object is before this date in UTC.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("customTimeBefore")]
                    public virtual string CustomTimeBefore { get; set; } 

                    /// <summary>Number of days elapsed since the user-specified timestamp set on an object. The
                    /// condition is satisfied if the days elapsed is at least this number. If no custom timestamp is
                    /// specified on an object, the condition does not apply.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("daysSinceCustomTime")]
                    public virtual System.Nullable<int> DaysSinceCustomTime { get; set; } 

                    /// <summary>Number of days elapsed since the noncurrent timestamp of an object. The condition is
                    /// satisfied if the days elapsed is at least this number. This condition is relevant only for
                    /// versioned objects. The value of the field must be a nonnegative integer. If it's zero, the
                    /// object version will become eligible for Lifecycle action as soon as it becomes
                    /// noncurrent.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("daysSinceNoncurrentTime")]
                    public virtual System.Nullable<int> DaysSinceNoncurrentTime { get; set; } 

                    /// <summary>Relevant only for versioned objects. If the value is true, this condition matches live
                    /// objects; if the value is false, it matches archived objects.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("isLive")]
                    public virtual System.Nullable<bool> IsLive { get; set; } 

                    /// <summary>A regular expression that satisfies the RE2 syntax. This condition is satisfied when
                    /// the name of the object matches the RE2 pattern. Note: This feature is currently in the "Early
                    /// Access" launch stage and is only available to a whitelisted set of users; that means that this
                    /// feature may be changed in backward-incompatible ways and that it is not guaranteed to be
                    /// released.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("matchesPattern")]
                    public virtual string MatchesPattern { get; set; } 

                    /// <summary>Objects having any of the storage classes specified by this condition will be matched.
                    /// Values include MULTI_REGIONAL, REGIONAL, NEARLINE, COLDLINE, ARCHIVE, STANDARD, and
                    /// DURABLE_REDUCED_AVAILABILITY.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("matchesStorageClass")]
                    public virtual System.Collections.Generic.IList<string> MatchesStorageClass { get; set; } 

                    /// <summary>A date in RFC 3339 format with only the date part (for instance, "2013-01-15"). This
                    /// condition is satisfied when the noncurrent time on an object is before this date in UTC. This
                    /// condition is relevant only for versioned objects.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("noncurrentTimeBefore")]
                    public virtual string NoncurrentTimeBefore { get; set; } 

                    /// <summary>Relevant only for versioned objects. If the value is N, this condition is satisfied
                    /// when there are at least N versions (including the live version) newer than this version of the
                    /// object.</summary>
                    [Newtonsoft.Json.JsonPropertyAttribute("numNewerVersions")]
                    public virtual System.Nullable<int> NumNewerVersions { get; set; } 

                }
            }
        }    

        /// <summary>The bucket's logging configuration, which defines the destination bucket and optional name prefix
        /// for the current bucket's logs.</summary>
        public class LoggingData
        {
            /// <summary>The destination bucket where the current bucket's logs should be placed.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("logBucket")]
            public virtual string LogBucket { get; set; } 

            /// <summary>A prefix for log object names.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("logObjectPrefix")]
            public virtual string LogObjectPrefix { get; set; } 

        }    

        /// <summary>The owner of the bucket. This is always the project team's owner group.</summary>
        public class OwnerData
        {
            /// <summary>The entity, in the form project-owner-projectId.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("entity")]
            public virtual string Entity { get; set; } 

            /// <summary>The ID for the entity.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("entityId")]
            public virtual string EntityId { get; set; } 

        }    

        /// <summary>The bucket's retention policy. The retention policy enforces a minimum retention time for all
        /// objects contained in the bucket, based on their creation time. Any attempt to overwrite or delete objects
        /// younger than the retention period will result in a PERMISSION_DENIED error. An unlocked retention policy can
        /// be modified or removed from the bucket via a storage.buckets.update operation. A locked retention policy
        /// cannot be removed or shortened in duration for the lifetime of the bucket. Attempting to remove or decrease
        /// period of a locked retention policy will result in a PERMISSION_DENIED error.</summary>
        public class RetentionPolicyData
        {
            /// <summary>Server-determined value that indicates the time from which policy was enforced and effective.
            /// This value is in RFC 3339 format.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("effectiveTime")]
            public virtual string EffectiveTimeRaw { get; set; }

            /// <summary><seealso cref="System.DateTime"/> representation of <see cref="EffectiveTimeRaw"/>.</summary>
            [Newtonsoft.Json.JsonIgnoreAttribute]
            public virtual System.Nullable<System.DateTime> EffectiveTime
            {
                get => Google.Apis.Util.Utilities.GetDateTimeFromString(EffectiveTimeRaw);
                set => EffectiveTimeRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
            }

            /// <summary>Once locked, an object retention policy cannot be modified.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("isLocked")]
            public virtual System.Nullable<bool> IsLocked { get; set; } 

            /// <summary>The duration in seconds that objects need to be retained. Retention duration must be greater
            /// than zero and less than 100 years. Note that enforcement of retention periods less than a day is not
            /// guaranteed. Such periods should only be used for testing purposes.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("retentionPeriod")]
            public virtual System.Nullable<long> RetentionPeriod { get; set; } 

        }    

        /// <summary>The bucket's versioning configuration.</summary>
        public class VersioningData
        {
            /// <summary>While set to true, versioning is fully enabled for this bucket.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("enabled")]
            public virtual System.Nullable<bool> Enabled { get; set; } 

        }    

        /// <summary>The bucket's website configuration, controlling how the service behaves when accessing bucket
        /// contents as a web site. See the Static Website Examples for more information.</summary>
        public class WebsiteData
        {
            /// <summary>If the requested object path is missing, the service will ensure the path has a trailing '/',
            /// append this suffix, and attempt to retrieve the resulting object. This allows the creation of index.html
            /// objects to represent directory pages.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("mainPageSuffix")]
            public virtual string MainPageSuffix { get; set; } 

            /// <summary>If the requested object path is missing, and any mainPageSuffix object is missing, if
            /// applicable, the service will return the named object from this bucket as the content for a 404 Not Found
            /// result.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("notFoundPage")]
            public virtual string NotFoundPage { get; set; } 

        }
    }    

    /// <summary>An access-control entry.</summary>
    public class BucketAccessControl : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The name of the bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("bucket")]
        public virtual string Bucket { get; set; } 

        /// <summary>The domain associated with the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("domain")]
        public virtual string Domain { get; set; } 

        /// <summary>The email address associated with the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("email")]
        public virtual string Email { get; set; } 

        /// <summary>The entity holding the permission, in one of the following forms: - user-userId - user-email -
        /// group-groupId - group-email - domain-domain - project-team-projectId - allUsers - allAuthenticatedUsers
        /// Examples: - The user liz@example.com would be user-liz@example.com. - The group example@googlegroups.com
        /// would be group-example@googlegroups.com. - To refer to all members of the Google Apps for Business domain
        /// example.com, the entity would be domain-example.com.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("entity")]
        public virtual string Entity { get; set; } 

        /// <summary>The ID for the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("entityId")]
        public virtual string EntityId { get; set; } 

        /// <summary>HTTP 1.1 Entity tag for the access-control entry.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; } 

        /// <summary>The ID of the access-control entry.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The kind of item this is. For bucket access control entries, this is always
        /// storage#bucketAccessControl.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The project team associated with the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("projectTeam")]
        public virtual ProjectTeamData ProjectTeam { get; set; } 

        /// <summary>The access permission for the entity.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("role")]
        public virtual string Role { get; set; } 

        /// <summary>The link to this access-control entry.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("selfLink")]
        public virtual string SelfLink { get; set; } 

        

        /// <summary>The project team associated with the entity, if any.</summary>
        public class ProjectTeamData
        {
            /// <summary>The project number.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("projectNumber")]
            public virtual string ProjectNumber { get; set; } 

            /// <summary>The team.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("team")]
            public virtual string Team { get; set; } 

        }
    }    

    /// <summary>An access-control list.</summary>
    public class BucketAccessControls : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The list of items.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<BucketAccessControl> Items { get; set; } 

        /// <summary>The kind of item this is. For lists of bucket access control entries, this is always
        /// storage#bucketAccessControls.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>A list of buckets.</summary>
    public class Buckets : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The list of items.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<Bucket> Items { get; set; } 

        /// <summary>The kind of item this is. For lists of buckets, this is always storage#buckets.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The continuation token, used to page through large result sets. Provide this value in a subsequent
        /// request to return the next page of results.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>An notification channel used to watch for resource changes.</summary>
    public class Channel : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The address where notifications are delivered for this channel.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("address")]
        public virtual string Address { get; set; } 

        /// <summary>Date and time of notification channel expiration, expressed as a Unix timestamp, in milliseconds.
        /// Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("expiration")]
        public virtual System.Nullable<long> Expiration { get; set; } 

        /// <summary>A UUID or similar unique string that identifies this channel.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>Identifies this as a notification channel used to watch for changes to a resource, which is
        /// "api#channel".</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>Additional parameters controlling delivery channel behavior. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("params")]
        public virtual System.Collections.Generic.IDictionary<string,string> Params__ { get; set; } 

        /// <summary>A Boolean value to indicate whether payload is wanted. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("payload")]
        public virtual System.Nullable<bool> Payload { get; set; } 

        /// <summary>An opaque ID that identifies the resource being watched on this channel. Stable across different
        /// API versions.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resourceId")]
        public virtual string ResourceId { get; set; } 

        /// <summary>A version-specific identifier for the watched resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resourceUri")]
        public virtual string ResourceUri { get; set; } 

        /// <summary>An arbitrary string delivered to the target address with each notification delivered over this
        /// channel. Optional.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("token")]
        public virtual string Token { get; set; } 

        /// <summary>The type of delivery mechanism used for this channel.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("type")]
        public virtual string Type { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>A Compose request.</summary>
    public class ComposeRequest : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Properties of the resulting object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("destination")]
        public virtual Object Destination { get; set; } 

        /// <summary>The kind of item this is.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The list of source objects that will be concatenated into a single object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("sourceObjects")]
        public virtual System.Collections.Generic.IList<SourceObjectsData> SourceObjects { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
        

        public class SourceObjectsData
        {
            /// <summary>The generation of this object to use as the source.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("generation")]
            public virtual System.Nullable<long> Generation { get; set; } 

            /// <summary>The source object's name. All source objects must reside in the same bucket.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("name")]
            public virtual string Name { get; set; } 

            /// <summary>Conditions that must be met for this operation to execute.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("objectPreconditions")]
            public virtual ObjectPreconditionsData ObjectPreconditions { get; set; } 

            

            /// <summary>Conditions that must be met for this operation to execute.</summary>
            public class ObjectPreconditionsData
            {
                /// <summary>Only perform the composition if the generation of the source object that would be used
                /// matches this value. If this value and a generation are both specified, they must be the same value
                /// or the call will fail.</summary>
                [Newtonsoft.Json.JsonPropertyAttribute("ifGenerationMatch")]
                public virtual System.Nullable<long> IfGenerationMatch { get; set; } 

            }
        }
    }    

    /// <summary>Represents an expression text. Example: title: "User account presence" description: "Determines whether
    /// the request has a user account" expression: "size(request.user) > 0"</summary>
    public class Expr : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>An optional description of the expression. This is a longer text which describes the expression,
        /// e.g. when hovered over it in a UI.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("description")]
        public virtual string Description { get; set; } 

        /// <summary>Textual representation of an expression in Common Expression Language syntax. The application
        /// context of the containing message determines which well-known feature set of CEL is supported.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("expression")]
        public virtual string Expression { get; set; } 

        /// <summary>An optional string indicating the location of the expression for error reporting, e.g. a file name
        /// and a position in the file.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("location")]
        public virtual string Location { get; set; } 

        /// <summary>An optional title for the expression, i.e. a short string describing its purpose. This can be used
        /// e.g. in UIs which allow to enter the expression.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("title")]
        public virtual string Title { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>JSON template to produce a JSON-style HMAC Key resource for Create responses.</summary>
    public class HmacKey : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The kind of item this is. For HMAC keys, this is always storage#hmacKey.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>Key metadata.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("metadata")]
        public virtual HmacKeyMetadata Metadata { get; set; } 

        /// <summary>HMAC secret key material.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("secret")]
        public virtual string Secret { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>JSON template to produce a JSON-style HMAC Key metadata resource.</summary>
    public class HmacKeyMetadata : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The ID of the HMAC Key.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("accessId")]
        public virtual string AccessId { get; set; } 

        /// <summary>HTTP 1.1 Entity tag for the HMAC key.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; } 

        /// <summary>The ID of the HMAC key, including the Project ID and the Access ID.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The kind of item this is. For HMAC Key metadata, this is always storage#hmacKeyMetadata.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>Project ID owning the service account to which the key authenticates.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("projectId")]
        public virtual string ProjectId { get; set; } 

        /// <summary>The link to this resource.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("selfLink")]
        public virtual string SelfLink { get; set; } 

        /// <summary>The email address of the key's associated service account.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("serviceAccountEmail")]
        public virtual string ServiceAccountEmail { get; set; } 

        /// <summary>The state of the key. Can be one of ACTIVE, INACTIVE, or DELETED.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("state")]
        public virtual string State { get; set; } 

        /// <summary>The creation time of the HMAC key in RFC 3339 format.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeCreated")]
        public virtual string TimeCreatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeCreatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> TimeCreated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeCreatedRaw);
            set => TimeCreatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The last modification time of the HMAC key metadata in RFC 3339 format.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("updated")]
        public virtual string UpdatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> Updated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

    }    

    /// <summary>A list of hmacKeys.</summary>
    public class HmacKeysMetadata : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The list of items.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<HmacKeyMetadata> Items { get; set; } 

        /// <summary>The kind of item this is. For lists of hmacKeys, this is always storage#hmacKeysMetadata.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The continuation token, used to page through large result sets. Provide this value in a subsequent
        /// request to return the next page of results.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>A subscription to receive Google PubSub notifications.</summary>
    public class Notification : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>An optional list of additional attributes to attach to each Cloud PubSub message published for this
        /// notification subscription.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("custom_attributes")]
        public virtual System.Collections.Generic.IDictionary<string,string> CustomAttributes { get; set; } 

        /// <summary>HTTP 1.1 Entity tag for this subscription notification.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; } 

        /// <summary>If present, only send notifications about listed event types. If empty, sent notifications for all
        /// event types.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("event_types")]
        public virtual System.Collections.Generic.IList<string> EventTypes { get; set; } 

        /// <summary>The ID of the notification.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The kind of item this is. For notifications, this is always storage#notification.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>If present, only apply this notification configuration to object names that begin with this
        /// prefix.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("object_name_prefix")]
        public virtual string ObjectNamePrefix { get; set; } 

        /// <summary>The desired content of the Payload.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("payload_format")]
        public virtual string PayloadFormat { get; set; } 

        /// <summary>The canonical URL of this notification.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("selfLink")]
        public virtual string SelfLink { get; set; } 

        /// <summary>The Cloud PubSub topic to which this subscription publishes. Formatted as:
        /// '//pubsub.googleapis.com/projects/{project-identifier}/topics/{my-topic}'</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("topic")]
        public virtual string Topic { get; set; } 

    }    

    /// <summary>A list of notification subscriptions.</summary>
    public class Notifications : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The list of items.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<Notification> Items { get; set; } 

        /// <summary>The kind of item this is. For lists of notifications, this is always
        /// storage#notifications.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>An object.</summary>
    public class Object : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Access controls on the object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("acl")]
        public virtual System.Collections.Generic.IList<ObjectAccessControl> Acl { get; set; } 

        /// <summary>The name of the bucket containing this object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("bucket")]
        public virtual string Bucket { get; set; } 

        /// <summary>Cache-Control directive for the object data. If omitted, and the object is accessible to all
        /// anonymous users, the default will be public, max-age=3600.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("cacheControl")]
        public virtual string CacheControl { get; set; } 

        /// <summary>Number of underlying components that make up this object. Components are accumulated by compose
        /// operations.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("componentCount")]
        public virtual System.Nullable<int> ComponentCount { get; set; } 

        /// <summary>Content-Disposition of the object data.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("contentDisposition")]
        public virtual string ContentDisposition { get; set; } 

        /// <summary>Content-Encoding of the object data.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("contentEncoding")]
        public virtual string ContentEncoding { get; set; } 

        /// <summary>Content-Language of the object data.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("contentLanguage")]
        public virtual string ContentLanguage { get; set; } 

        /// <summary>Content-Type of the object data. If an object is stored without a Content-Type, it is served as
        /// application/octet-stream.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("contentType")]
        public virtual string ContentType { get; set; } 

        /// <summary>CRC32c checksum, as described in RFC 4960, Appendix B; encoded using base64 in big-endian byte
        /// order. For more information about using the CRC32c checksum, see Hashes and ETags: Best Practices.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("crc32c")]
        public virtual string Crc32c { get; set; } 

        /// <summary>A timestamp in RFC 3339 format specified by the user for an object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("customTime")]
        public virtual string CustomTimeRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="CustomTimeRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> CustomTime
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(CustomTimeRaw);
            set => CustomTimeRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>Metadata of customer-supplied encryption key, if the object is encrypted by such a key.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("customerEncryption")]
        public virtual CustomerEncryptionData CustomerEncryption { get; set; } 

        /// <summary>HTTP 1.1 Entity tag for the object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; } 

        /// <summary>Whether an object is under event-based hold. Event-based hold is a way to retain objects until an
        /// event occurs, which is signified by the hold's release (i.e. this value is set to false). After being
        /// released (set to false), such objects will be subject to bucket-level retention (if any). One sample use
        /// case of this flag is for banks to hold loan documents for at least 3 years after loan is paid in full. Here,
        /// bucket-level retention is 3 years and the event is the loan being paid in full. In this example, these
        /// objects will be held intact for any number of years until the event has occurred (event-based hold on the
        /// object is released) and then 3 more years after that. That means retention duration of the objects begins
        /// from the moment event-based hold transitioned from true to false.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("eventBasedHold")]
        public virtual System.Nullable<bool> EventBasedHold { get; set; } 

        /// <summary>The content generation of this object. Used for object versioning.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("generation")]
        public virtual System.Nullable<long> Generation { get; set; } 

        /// <summary>The ID of the object, including the bucket name, object name, and generation number.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The kind of item this is. For objects, this is always storage#object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>Not currently supported. Specifying the parameter causes the request to fail with status code 400 -
        /// Bad Request.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kmsKeyName")]
        public virtual string KmsKeyName { get; set; } 

        /// <summary>MD5 hash of the data; encoded using base64. For more information about using the MD5 hash, see
        /// Hashes and ETags: Best Practices.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("md5Hash")]
        public virtual string Md5Hash { get; set; } 

        /// <summary>Media download link.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("mediaLink")]
        public virtual string MediaLink { get; set; } 

        /// <summary>User-provided metadata, in key/value pairs.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("metadata")]
        public virtual System.Collections.Generic.IDictionary<string,string> Metadata { get; set; } 

        /// <summary>The version of the metadata for this object at this generation. Used for preconditions and for
        /// detecting changes in metadata. A metageneration number is only meaningful in the context of a particular
        /// generation of a particular object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("metageneration")]
        public virtual System.Nullable<long> Metageneration { get; set; } 

        /// <summary>The name of the object. Required if not specified by URL parameter.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public virtual string Name { get; set; } 

        /// <summary>The owner of the object. This will always be the uploader of the object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("owner")]
        public virtual OwnerData Owner { get; set; } 

        /// <summary>A server-determined value that specifies the earliest time that the object's retention period
        /// expires. This value is in RFC 3339 format. Note 1: This field is not provided for objects with an active
        /// event-based hold, since retention expiration is unknown until the hold is removed. Note 2: This value can be
        /// provided even when temporary hold is set (so that the user can reason about policy without having to first
        /// unset the temporary hold).</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("retentionExpirationTime")]
        public virtual string RetentionExpirationTimeRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="RetentionExpirationTimeRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> RetentionExpirationTime
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(RetentionExpirationTimeRaw);
            set => RetentionExpirationTimeRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The link to this object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("selfLink")]
        public virtual string SelfLink { get; set; } 

        /// <summary>Content-Length of the data in bytes.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("size")]
        public virtual System.Nullable<ulong> Size { get; set; } 

        /// <summary>Storage class of the object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("storageClass")]
        public virtual string StorageClass { get; set; } 

        /// <summary>Whether an object is under temporary hold. While this flag is set to true, the object is protected
        /// against deletion and overwrites. A common use case of this flag is regulatory investigations where objects
        /// need to be retained while the investigation is ongoing. Note that unlike event-based hold, temporary hold
        /// does not impact retention expiration time of an object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("temporaryHold")]
        public virtual System.Nullable<bool> TemporaryHold { get; set; } 

        /// <summary>The creation time of the object in RFC 3339 format.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeCreated")]
        public virtual string TimeCreatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeCreatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> TimeCreated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeCreatedRaw);
            set => TimeCreatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The deletion time of the object in RFC 3339 format. Will be returned if and only if this version of
        /// the object has been deleted.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeDeleted")]
        public virtual string TimeDeletedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeDeletedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> TimeDeleted
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeDeletedRaw);
            set => TimeDeletedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The time at which the object's storage class was last changed. When the object is initially
        /// created, it will be set to timeCreated.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("timeStorageClassUpdated")]
        public virtual string TimeStorageClassUpdatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="TimeStorageClassUpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> TimeStorageClassUpdated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(TimeStorageClassUpdatedRaw);
            set => TimeStorageClassUpdatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        /// <summary>The modification time of the object metadata in RFC 3339 format.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("updated")]
        public virtual string UpdatedRaw { get; set; }

        /// <summary><seealso cref="System.DateTime"/> representation of <see cref="UpdatedRaw"/>.</summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual System.Nullable<System.DateTime> Updated
        {
            get => Google.Apis.Util.Utilities.GetDateTimeFromString(UpdatedRaw);
            set => UpdatedRaw = Google.Apis.Util.Utilities.GetStringFromDateTime(value);
        }

        

        /// <summary>Metadata of customer-supplied encryption key, if the object is encrypted by such a key.</summary>
        public class CustomerEncryptionData
        {
            /// <summary>The encryption algorithm.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("encryptionAlgorithm")]
            public virtual string EncryptionAlgorithm { get; set; } 

            /// <summary>SHA256 hash value of the encryption key.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("keySha256")]
            public virtual string KeySha256 { get; set; } 

        }    

        /// <summary>The owner of the object. This will always be the uploader of the object.</summary>
        public class OwnerData
        {
            /// <summary>The entity, in the form user-userId.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("entity")]
            public virtual string Entity { get; set; } 

            /// <summary>The ID for the entity.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("entityId")]
            public virtual string EntityId { get; set; } 

        }
    }    

    /// <summary>An access-control entry.</summary>
    public class ObjectAccessControl : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The name of the bucket.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("bucket")]
        public virtual string Bucket { get; set; } 

        /// <summary>The domain associated with the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("domain")]
        public virtual string Domain { get; set; } 

        /// <summary>The email address associated with the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("email")]
        public virtual string Email { get; set; } 

        /// <summary>The entity holding the permission, in one of the following forms: - user-userId - user-email -
        /// group-groupId - group-email - domain-domain - project-team-projectId - allUsers - allAuthenticatedUsers
        /// Examples: - The user liz@example.com would be user-liz@example.com. - The group example@googlegroups.com
        /// would be group-example@googlegroups.com. - To refer to all members of the Google Apps for Business domain
        /// example.com, the entity would be domain-example.com.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("entity")]
        public virtual string Entity { get; set; } 

        /// <summary>The ID for the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("entityId")]
        public virtual string EntityId { get; set; } 

        /// <summary>HTTP 1.1 Entity tag for the access-control entry.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; } 

        /// <summary>The content generation of the object, if applied to an object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("generation")]
        public virtual System.Nullable<long> Generation { get; set; } 

        /// <summary>The ID of the access-control entry.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The kind of item this is. For object access control entries, this is always
        /// storage#objectAccessControl.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The name of the object, if applied to an object.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("object")]
        public virtual string Object__ { get; set; } 

        /// <summary>The project team associated with the entity, if any.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("projectTeam")]
        public virtual ProjectTeamData ProjectTeam { get; set; } 

        /// <summary>The access permission for the entity.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("role")]
        public virtual string Role { get; set; } 

        /// <summary>The link to this access-control entry.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("selfLink")]
        public virtual string SelfLink { get; set; } 

        

        /// <summary>The project team associated with the entity, if any.</summary>
        public class ProjectTeamData
        {
            /// <summary>The project number.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("projectNumber")]
            public virtual string ProjectNumber { get; set; } 

            /// <summary>The team.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("team")]
            public virtual string Team { get; set; } 

        }
    }    

    /// <summary>An access-control list.</summary>
    public class ObjectAccessControls : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The list of items.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<ObjectAccessControl> Items { get; set; } 

        /// <summary>The kind of item this is. For lists of object access control entries, this is always
        /// storage#objectAccessControls.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>A list of objects.</summary>
    public class Objects : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The list of items.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<Object> Items { get; set; } 

        /// <summary>The kind of item this is. For lists of objects, this is always storage#objects.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The continuation token, used to page through large result sets. Provide this value in a subsequent
        /// request to return the next page of results.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; } 

        /// <summary>The list of prefixes of objects matching-but-not-listed up to and including the requested
        /// delimiter.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("prefixes")]
        public virtual System.Collections.Generic.IList<string> Prefixes { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>A bucket/object IAM policy.</summary>
    public class Policy : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>An association between a role, which comes with a set of permissions, and members who may assume
        /// that role.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("bindings")]
        public virtual System.Collections.Generic.IList<BindingsData> Bindings { get; set; } 

        /// <summary>HTTP 1.1  Entity tag for the policy.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("etag")]
        public virtual string ETag { get; set; } 

        /// <summary>The kind of item this is. For policies, this is always storage#policy. This field is ignored on
        /// input.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The ID of the resource to which this policy belongs. Will be of the form projects/_/buckets/bucket
        /// for buckets, and projects/_/buckets/bucket/objects/object for objects. A specific generation may be
        /// specified by appending #generationNumber to the end of the object name, e.g. projects/_/buckets/my-
        /// bucket/objects/data.txt#17. The current generation can be denoted with #0. This field is ignored on
        /// input.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resourceId")]
        public virtual string ResourceId { get; set; } 

        /// <summary>The IAM policy format version.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("version")]
        public virtual System.Nullable<int> Version { get; set; } 

        

        public class BindingsData
        {
            /// <summary>The condition that is associated with this binding. NOTE: an unsatisfied condition will not
            /// allow user access via current binding. Different bindings, including their conditions, are examined
            /// independently.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("condition")]
            public virtual Expr Condition { get; set; } 

            /// <summary>A collection of identifiers for members who may assume the provided role. Recognized
            /// identifiers are as follows: - allUsers — A special identifier that represents anyone on the internet;
            /// with or without a Google account. - allAuthenticatedUsers — A special identifier that represents anyone
            /// who is authenticated with a Google account or a service account. - user:emailid — An email address that
            /// represents a specific account. For example, user:alice@gmail.com or user:joe@example.com. -
            /// serviceAccount:emailid — An email address that represents a service account. For example,
            /// serviceAccount:my-other-app@appspot.gserviceaccount.com . - group:emailid — An email address that
            /// represents a Google group. For example, group:admins@example.com. - domain:domain — A Google Apps domain
            /// name that represents all the users of that domain. For example, domain:google.com or domain:example.com.
            /// - projectOwner:projectid — Owners of the given project. For example, projectOwner:my-example-project -
            /// projectEditor:projectid — Editors of the given project. For example, projectEditor:my-example-project -
            /// projectViewer:projectid — Viewers of the given project. For example, projectViewer:my-example-
            /// project</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("members")]
            public virtual System.Collections.Generic.IList<string> Members { get; set; } 

            /// <summary>The role to which members belong. Two types of roles are supported: new IAM roles, which grant
            /// permissions that do not map directly to those provided by ACLs, and legacy IAM roles, which do map
            /// directly to ACL permissions. All roles are of the format roles/storage.specificRole. The new IAM roles
            /// are: - roles/storage.admin — Full control of Google Cloud Storage resources. -
            /// roles/storage.objectViewer — Read-Only access to Google Cloud Storage objects. -
            /// roles/storage.objectCreator — Access to create objects in Google Cloud Storage. -
            /// roles/storage.objectAdmin — Full control of Google Cloud Storage objects.   The legacy IAM roles are: -
            /// roles/storage.legacyObjectReader — Read-only access to objects without listing. Equivalent to an ACL
            /// entry on an object with the READER role. - roles/storage.legacyObjectOwner — Read/write access to
            /// existing objects without listing. Equivalent to an ACL entry on an object with the OWNER role. -
            /// roles/storage.legacyBucketReader — Read access to buckets with object listing. Equivalent to an ACL
            /// entry on a bucket with the READER role. - roles/storage.legacyBucketWriter — Read access to buckets with
            /// object listing/creation/deletion. Equivalent to an ACL entry on a bucket with the WRITER role. -
            /// roles/storage.legacyBucketOwner — Read and write access to existing buckets with object
            /// listing/creation/deletion. Equivalent to an ACL entry on a bucket with the OWNER role.</summary>
            [Newtonsoft.Json.JsonPropertyAttribute("role")]
            public virtual string Role { get; set; } 

        }
    }    

    /// <summary>A rewrite response.</summary>
    public class RewriteResponse : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>true if the copy is finished; otherwise, false if the copy is in progress. This property is always
        /// present in the response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("done")]
        public virtual System.Nullable<bool> Done { get; set; } 

        /// <summary>The kind of item this is.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The total size of the object being copied in bytes. This property is always present in the
        /// response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("objectSize")]
        public virtual System.Nullable<long> ObjectSize { get; set; } 

        /// <summary>A resource containing the metadata for the copied-to object. This property is present in the
        /// response only when copying completes.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("resource")]
        public virtual Object Resource { get; set; } 

        /// <summary>A token to use in subsequent requests to continue copying data. This token is present in the
        /// response only when there is more data to copy.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("rewriteToken")]
        public virtual string RewriteToken { get; set; } 

        /// <summary>The total bytes written so far, which can be used to provide a waiting user with a progress
        /// indicator. This property is always present in the response.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("totalBytesRewritten")]
        public virtual System.Nullable<long> TotalBytesRewritten { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>A subscription to receive Google PubSub notifications.</summary>
    public class ServiceAccount : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The ID of the notification.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("email_address")]
        public virtual string EmailAddress { get; set; } 

        /// <summary>The kind of item this is. For notifications, this is always storage#notification.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    /// <summary>A storage.(buckets|objects).testIamPermissions response.</summary>
    public class TestIamPermissionsResponse : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>The kind of item this is.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>The permissions held by the caller. Permissions are always of the format
        /// storage.resource.capability, where resource is one of buckets or objects. The supported permissions are as
        /// follows: - storage.buckets.delete — Delete bucket. - storage.buckets.get — Read bucket metadata. -
        /// storage.buckets.getIamPolicy — Read bucket IAM policy. - storage.buckets.create — Create bucket. -
        /// storage.buckets.list — List buckets. - storage.buckets.setIamPolicy — Update bucket IAM policy. -
        /// storage.buckets.update — Update bucket metadata. - storage.objects.delete — Delete object. -
        /// storage.objects.get — Read object data and metadata. - storage.objects.getIamPolicy — Read object IAM
        /// policy. - storage.objects.create — Create object. - storage.objects.list — List objects. -
        /// storage.objects.setIamPolicy — Update object IAM policy. - storage.objects.update — Update object
        /// metadata.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("permissions")]
        public virtual System.Collections.Generic.IList<string> Permissions { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }
}
