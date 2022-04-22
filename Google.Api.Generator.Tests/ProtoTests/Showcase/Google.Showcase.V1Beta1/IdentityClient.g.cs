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

using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using proto = Google.Protobuf;
using wkt = Google.Protobuf.WellKnownTypes;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using sc = System.Collections;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Settings for <see cref="IdentityClient"/> instances.</summary>
    public sealed partial class IdentitySettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="IdentitySettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="IdentitySettings"/>.</returns>
        public static IdentitySettings GetDefault() => new IdentitySettings();

        /// <summary>Constructs a new <see cref="IdentitySettings"/> object with default settings.</summary>
        public IdentitySettings()
        {
        }

        private IdentitySettings(IdentitySettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            CreateUserSettings = existing.CreateUserSettings;
            GetUserSettings = existing.GetUserSettings;
            UpdateUserSettings = existing.UpdateUserSettings;
            DeleteUserSettings = existing.DeleteUserSettings;
            ListUsersSettings = existing.ListUsersSettings;
            OnCopy(existing);
        }

        partial void OnCopy(IdentitySettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>IdentityClient.CreateUser</c>
        ///  and <c>IdentityClient.CreateUserAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CreateUserSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>IdentityClient.GetUser</c>
        /// and <c>IdentityClient.GetUserAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetUserSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>IdentityClient.UpdateUser</c>
        ///  and <c>IdentityClient.UpdateUserAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdateUserSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>IdentityClient.DeleteUser</c>
        ///  and <c>IdentityClient.DeleteUserAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteUserSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>IdentityClient.ListUsers</c>
        ///  and <c>IdentityClient.ListUsersAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListUsersSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="IdentitySettings"/> object.</returns>
        public IdentitySettings Clone() => new IdentitySettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="IdentityClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class IdentityClientBuilder : gaxgrpc::ClientBuilderBase<IdentityClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public IdentitySettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public IdentityClientBuilder() : base(IdentityClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref IdentityClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<IdentityClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override IdentityClient Build()
        {
            IdentityClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<IdentityClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<IdentityClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private IdentityClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return IdentityClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<IdentityClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return IdentityClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => IdentityClient.ChannelPool;
    }

    /// <summary>Identity client wrapper, for convenient use.</summary>
    /// <remarks>
    /// A simple identity service.
    /// </remarks>
    public abstract partial class IdentityClient
    {
        /// <summary>
        /// The default endpoint for the Identity service, which is a host of "localhost:7469" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "localhost:7469:443";

        /// <summary>The default Identity scopes.</summary>
        /// <remarks>The default Identity scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Identity.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="IdentityClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="IdentityClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="IdentityClient"/>.</returns>
        public static stt::Task<IdentityClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new IdentityClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="IdentityClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="IdentityClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="IdentityClient"/>.</returns>
        public static IdentityClient Create() => new IdentityClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="IdentityClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="IdentitySettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="IdentityClient"/>.</returns>
        internal static IdentityClient Create(grpccore::CallInvoker callInvoker, IdentitySettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Identity.IdentityClient grpcClient = new Identity.IdentityClient(callInvoker);
            return new IdentityClientImpl(grpcClient, settings, logger);
        }

        /// <summary>
        /// Shuts down any channels automatically created by <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/>. Channels which weren't automatically created are not
        /// affected.
        /// </summary>
        /// <remarks>
        /// After calling this method, further calls to <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/> will create new channels, which could in turn be shut down
        /// by another call to this method.
        /// </remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => ChannelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC Identity client</summary>
        public virtual Identity.IdentityClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual User CreateUser(CreateUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> CreateUserAsync(CreateUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> CreateUserAsync(CreateUserRequest request, st::CancellationToken cancellationToken) =>
            CreateUserAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="displayName">
        /// The display_name of the user.
        /// </param>
        /// <param name="email">
        /// The email address of the user.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual User CreateUser(string displayName, string email, gaxgrpc::CallSettings callSettings = null) =>
            CreateUser(new CreateUserRequest
            {
                User = new User
                {
                    DisplayName = gax::GaxPreconditions.CheckNotNullOrEmpty(displayName, nameof(displayName)),
                    Email = gax::GaxPreconditions.CheckNotNullOrEmpty(email, nameof(email)),
                },
            }, callSettings);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="displayName">
        /// The display_name of the user.
        /// </param>
        /// <param name="email">
        /// The email address of the user.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> CreateUserAsync(string displayName, string email, gaxgrpc::CallSettings callSettings = null) =>
            CreateUserAsync(new CreateUserRequest
            {
                User = new User
                {
                    DisplayName = gax::GaxPreconditions.CheckNotNullOrEmpty(displayName, nameof(displayName)),
                    Email = gax::GaxPreconditions.CheckNotNullOrEmpty(email, nameof(email)),
                },
            }, callSettings);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="displayName">
        /// The display_name of the user.
        /// </param>
        /// <param name="email">
        /// The email address of the user.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> CreateUserAsync(string displayName, string email, st::CancellationToken cancellationToken) =>
            CreateUserAsync(displayName, email, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="displayName">
        /// The display_name of the user.
        /// </param>
        /// <param name="email">
        /// The email address of the user.
        /// </param>
        /// <param name="age">
        /// The age of the user in years.
        /// </param>
        /// <param name="nickname">
        /// The nickname of the user.
        /// 
        /// (-- aip.dev/not-precedent: An empty string is a valid nickname.
        /// Ordinarily, proto3_optional should not be used on a `string` field. --)
        /// </param>
        /// <param name="enableNotifications">
        /// Enables the receiving of notifications. The default is true if unset.
        /// 
        /// (-- aip.dev/not-precedent: The default for the feature is true.
        /// Ordinarily, the default for a `bool` field should be false. --)
        /// </param>
        /// <param name="heightFeet">
        /// The height of the user in feet.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual User CreateUser(string displayName, string email, int age, string nickname, bool enableNotifications, double heightFeet, gaxgrpc::CallSettings callSettings = null) =>
            CreateUser(new CreateUserRequest
            {
                User = new User
                {
                    DisplayName = gax::GaxPreconditions.CheckNotNullOrEmpty(displayName, nameof(displayName)),
                    Email = gax::GaxPreconditions.CheckNotNullOrEmpty(email, nameof(email)),
                    Age = age,
                    HeightFeet = heightFeet,
                    Nickname = nickname ?? "",
                    EnableNotifications = enableNotifications,
                },
            }, callSettings);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="displayName">
        /// The display_name of the user.
        /// </param>
        /// <param name="email">
        /// The email address of the user.
        /// </param>
        /// <param name="age">
        /// The age of the user in years.
        /// </param>
        /// <param name="nickname">
        /// The nickname of the user.
        /// 
        /// (-- aip.dev/not-precedent: An empty string is a valid nickname.
        /// Ordinarily, proto3_optional should not be used on a `string` field. --)
        /// </param>
        /// <param name="enableNotifications">
        /// Enables the receiving of notifications. The default is true if unset.
        /// 
        /// (-- aip.dev/not-precedent: The default for the feature is true.
        /// Ordinarily, the default for a `bool` field should be false. --)
        /// </param>
        /// <param name="heightFeet">
        /// The height of the user in feet.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> CreateUserAsync(string displayName, string email, int age, string nickname, bool enableNotifications, double heightFeet, gaxgrpc::CallSettings callSettings = null) =>
            CreateUserAsync(new CreateUserRequest
            {
                User = new User
                {
                    DisplayName = gax::GaxPreconditions.CheckNotNullOrEmpty(displayName, nameof(displayName)),
                    Email = gax::GaxPreconditions.CheckNotNullOrEmpty(email, nameof(email)),
                    Age = age,
                    HeightFeet = heightFeet,
                    Nickname = nickname ?? "",
                    EnableNotifications = enableNotifications,
                },
            }, callSettings);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="displayName">
        /// The display_name of the user.
        /// </param>
        /// <param name="email">
        /// The email address of the user.
        /// </param>
        /// <param name="age">
        /// The age of the user in years.
        /// </param>
        /// <param name="nickname">
        /// The nickname of the user.
        /// 
        /// (-- aip.dev/not-precedent: An empty string is a valid nickname.
        /// Ordinarily, proto3_optional should not be used on a `string` field. --)
        /// </param>
        /// <param name="enableNotifications">
        /// Enables the receiving of notifications. The default is true if unset.
        /// 
        /// (-- aip.dev/not-precedent: The default for the feature is true.
        /// Ordinarily, the default for a `bool` field should be false. --)
        /// </param>
        /// <param name="heightFeet">
        /// The height of the user in feet.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> CreateUserAsync(string displayName, string email, int age, string nickname, bool enableNotifications, double heightFeet, st::CancellationToken cancellationToken) =>
            CreateUserAsync(displayName, email, age, nickname, enableNotifications, heightFeet, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual User GetUser(GetUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> GetUserAsync(GetUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> GetUserAsync(GetUserRequest request, st::CancellationToken cancellationToken) =>
            GetUserAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested user.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual User GetUser(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetUser(new GetUserRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested user.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> GetUserAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetUserAsync(new GetUserRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested user.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> GetUserAsync(string name, st::CancellationToken cancellationToken) =>
            GetUserAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested user.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual User GetUser(UserName name, gaxgrpc::CallSettings callSettings = null) =>
            GetUser(new GetUserRequest
            {
                UserName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested user.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> GetUserAsync(UserName name, gaxgrpc::CallSettings callSettings = null) =>
            GetUserAsync(new GetUserRequest
            {
                UserName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested user.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> GetUserAsync(UserName name, st::CancellationToken cancellationToken) =>
            GetUserAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual User UpdateUser(UpdateUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> UpdateUserAsync(UpdateUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<User> UpdateUserAsync(UpdateUserRequest request, st::CancellationToken cancellationToken) =>
            UpdateUserAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteUser(DeleteUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteUserAsync(DeleteUserRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteUserAsync(DeleteUserRequest request, st::CancellationToken cancellationToken) =>
            DeleteUserAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="name">
        /// The resource name of the user to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteUser(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteUser(new DeleteUserRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="name">
        /// The resource name of the user to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteUserAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteUserAsync(new DeleteUserRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="name">
        /// The resource name of the user to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteUserAsync(string name, st::CancellationToken cancellationToken) =>
            DeleteUserAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="name">
        /// The resource name of the user to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteUser(UserName name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteUser(new DeleteUserRequest
            {
                UserName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="name">
        /// The resource name of the user to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteUserAsync(UserName name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteUserAsync(new DeleteUserRequest
            {
                UserName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="name">
        /// The resource name of the user to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteUserAsync(UserName name, st::CancellationToken cancellationToken) =>
            DeleteUserAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all users.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="User"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListUsersResponse, User> ListUsers(ListUsersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all users.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="User"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListUsersResponse, User> ListUsersAsync(ListUsersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();
    }

    /// <summary>Identity client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// A simple identity service.
    /// </remarks>
    public sealed partial class IdentityClientImpl : IdentityClient
    {
        private readonly gaxgrpc::ApiCall<CreateUserRequest, User> _callCreateUser;

        private readonly gaxgrpc::ApiCall<GetUserRequest, User> _callGetUser;

        private readonly gaxgrpc::ApiCall<UpdateUserRequest, User> _callUpdateUser;

        private readonly gaxgrpc::ApiCall<DeleteUserRequest, wkt::Empty> _callDeleteUser;

        private readonly gaxgrpc::ApiCall<ListUsersRequest, ListUsersResponse> _callListUsers;

        /// <summary>
        /// Constructs a client wrapper for the Identity service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="IdentitySettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public IdentityClientImpl(Identity.IdentityClient grpcClient, IdentitySettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            IdentitySettings effectiveSettings = settings ?? IdentitySettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callCreateUser = clientHelper.BuildApiCall<CreateUserRequest, User>("CreateUser", grpcClient.CreateUserAsync, grpcClient.CreateUser, effectiveSettings.CreateUserSettings);
            Modify_ApiCall(ref _callCreateUser);
            Modify_CreateUserApiCall(ref _callCreateUser);
            _callGetUser = clientHelper.BuildApiCall<GetUserRequest, User>("GetUser", grpcClient.GetUserAsync, grpcClient.GetUser, effectiveSettings.GetUserSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callGetUser);
            Modify_GetUserApiCall(ref _callGetUser);
            _callUpdateUser = clientHelper.BuildApiCall<UpdateUserRequest, User>("UpdateUser", grpcClient.UpdateUserAsync, grpcClient.UpdateUser, effectiveSettings.UpdateUserSettings).WithGoogleRequestParam("user.name", request => request.User?.Name);
            Modify_ApiCall(ref _callUpdateUser);
            Modify_UpdateUserApiCall(ref _callUpdateUser);
            _callDeleteUser = clientHelper.BuildApiCall<DeleteUserRequest, wkt::Empty>("DeleteUser", grpcClient.DeleteUserAsync, grpcClient.DeleteUser, effectiveSettings.DeleteUserSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callDeleteUser);
            Modify_DeleteUserApiCall(ref _callDeleteUser);
            _callListUsers = clientHelper.BuildApiCall<ListUsersRequest, ListUsersResponse>("ListUsers", grpcClient.ListUsersAsync, grpcClient.ListUsers, effectiveSettings.ListUsersSettings);
            Modify_ApiCall(ref _callListUsers);
            Modify_ListUsersApiCall(ref _callListUsers);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_CreateUserApiCall(ref gaxgrpc::ApiCall<CreateUserRequest, User> call);

        partial void Modify_GetUserApiCall(ref gaxgrpc::ApiCall<GetUserRequest, User> call);

        partial void Modify_UpdateUserApiCall(ref gaxgrpc::ApiCall<UpdateUserRequest, User> call);

        partial void Modify_DeleteUserApiCall(ref gaxgrpc::ApiCall<DeleteUserRequest, wkt::Empty> call);

        partial void Modify_ListUsersApiCall(ref gaxgrpc::ApiCall<ListUsersRequest, ListUsersResponse> call);

        partial void OnConstruction(Identity.IdentityClient grpcClient, IdentitySettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Identity client</summary>
        public override Identity.IdentityClient GrpcClient { get; }

        partial void Modify_CreateUserRequest(ref CreateUserRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetUserRequest(ref GetUserRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdateUserRequest(ref UpdateUserRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteUserRequest(ref DeleteUserRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListUsersRequest(ref ListUsersRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override User CreateUser(CreateUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateUserRequest(ref request, ref callSettings);
            return _callCreateUser.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<User> CreateUserAsync(CreateUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateUserRequest(ref request, ref callSettings);
            return _callCreateUser.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override User GetUser(GetUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetUserRequest(ref request, ref callSettings);
            return _callGetUser.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the User with the given uri.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<User> GetUserAsync(GetUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetUserRequest(ref request, ref callSettings);
            return _callGetUser.Async(request, callSettings);
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override User UpdateUser(UpdateUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateUserRequest(ref request, ref callSettings);
            return _callUpdateUser.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<User> UpdateUserAsync(UpdateUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateUserRequest(ref request, ref callSettings);
            return _callUpdateUser.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override void DeleteUser(DeleteUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteUserRequest(ref request, ref callSettings);
            _callDeleteUser.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes a user, their profile, and all of their authored messages.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task DeleteUserAsync(DeleteUserRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteUserRequest(ref request, ref callSettings);
            return _callDeleteUser.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all users.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="User"/> resources.</returns>
        public override gax::PagedEnumerable<ListUsersResponse, User> ListUsers(ListUsersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListUsersRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<ListUsersRequest, ListUsersResponse, User>(_callListUsers, request, callSettings);
        }

        /// <summary>
        /// Lists all users.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="User"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<ListUsersResponse, User> ListUsersAsync(ListUsersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListUsersRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<ListUsersRequest, ListUsersResponse, User>(_callListUsers, request, callSettings);
        }
    }

    public partial class ListUsersRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class ListUsersResponse : gaxgrpc::IPageResponse<User>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<User> GetEnumerator() => Users.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
