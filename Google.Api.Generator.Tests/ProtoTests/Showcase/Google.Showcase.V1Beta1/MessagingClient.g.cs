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

#pragma warning disable CS8981
using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using gciv = Google.Cloud.Iam.V1;
using gcl = Google.Cloud.Location;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using lro = Google.LongRunning;
using mel = Microsoft.Extensions.Logging;
using proto = Google.Protobuf;
using sc = System.Collections;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;
using wkt = Google.Protobuf.WellKnownTypes;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Settings for <see cref="MessagingClient"/> instances.</summary>
    public sealed partial class MessagingSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="MessagingSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="MessagingSettings"/>.</returns>
        public static MessagingSettings GetDefault() => new MessagingSettings();

        /// <summary>Constructs a new <see cref="MessagingSettings"/> object with default settings.</summary>
        public MessagingSettings()
        {
        }

        private MessagingSettings(MessagingSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            CreateRoomSettings = existing.CreateRoomSettings;
            GetRoomSettings = existing.GetRoomSettings;
            UpdateRoomSettings = existing.UpdateRoomSettings;
            DeleteRoomSettings = existing.DeleteRoomSettings;
            ListRoomsSettings = existing.ListRoomsSettings;
            CreateBlurbSettings = existing.CreateBlurbSettings;
            GetBlurbSettings = existing.GetBlurbSettings;
            UpdateBlurbSettings = existing.UpdateBlurbSettings;
            DeleteBlurbSettings = existing.DeleteBlurbSettings;
            ListBlurbsSettings = existing.ListBlurbsSettings;
            SearchBlurbsSettings = existing.SearchBlurbsSettings;
            SearchBlurbsOperationsSettings = existing.SearchBlurbsOperationsSettings.Clone();
            StreamBlurbsSettings = existing.StreamBlurbsSettings;
            SendBlurbsSettings = existing.SendBlurbsSettings;
            SendBlurbsStreamingSettings = existing.SendBlurbsStreamingSettings;
            ConnectSettings = existing.ConnectSettings;
            ConnectStreamingSettings = existing.ConnectStreamingSettings;
            LocationsSettings = existing.LocationsSettings;
            IAMPolicySettings = existing.IAMPolicySettings;
            OnCopy(existing);
        }

        partial void OnCopy(MessagingSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.CreateRoom</c>
        ///  and <c>MessagingClient.CreateRoomAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CreateRoomSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.GetRoom</c>
        /// and <c>MessagingClient.GetRoomAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetRoomSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.UpdateRoom</c>
        ///  and <c>MessagingClient.UpdateRoomAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdateRoomSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.DeleteRoom</c>
        ///  and <c>MessagingClient.DeleteRoomAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteRoomSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.ListRooms</c>
        ///  and <c>MessagingClient.ListRoomsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListRoomsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.CreateBlurb</c>
        ///  and <c>MessagingClient.CreateBlurbAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CreateBlurbSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.GetBlurb</c>
        ///  and <c>MessagingClient.GetBlurbAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetBlurbSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.UpdateBlurb</c>
        ///  and <c>MessagingClient.UpdateBlurbAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdateBlurbSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.DeleteBlurb</c>
        ///  and <c>MessagingClient.DeleteBlurbAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteBlurbSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.ListBlurbs</c>
        ///  and <c>MessagingClient.ListBlurbsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListBlurbsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MessagingClient.SearchBlurbs</c> and <c>MessagingClient.SearchBlurbsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SearchBlurbsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// Long Running Operation settings for calls to <c>MessagingClient.SearchBlurbs</c> and
        /// <c>MessagingClient.SearchBlurbsAsync</c>.
        /// </summary>
        /// <remarks>
        /// Uses default <see cref="gax::PollSettings"/> of:
        /// <list type="bullet">
        /// <item><description>Initial delay: 20 seconds.</description></item>
        /// <item><description>Delay multiplier: 1.5</description></item>
        /// <item><description>Maximum delay: 45 seconds.</description></item>
        /// <item><description>Total timeout: 24 hours.</description></item>
        /// </list>
        /// </remarks>
        public lro::OperationsSettings SearchBlurbsOperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MessagingClient.StreamBlurbs</c> and <c>MessagingClient.StreamBlurbsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings StreamBlurbsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.SendBlurbs</c>
        ///  and <c>MessagingClient.SendBlurbsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SendBlurbsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::ClientStreamingSettings"/> for calls to <c>MessagingClient.SendBlurbs</c> and
        /// <c>MessagingClient.SendBlurbsAsync</c>.
        /// </summary>
        /// <remarks>The default local send queue size is 100.</remarks>
        public gaxgrpc::ClientStreamingSettings SendBlurbsStreamingSettings { get; set; } = new gaxgrpc::ClientStreamingSettings(100);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MessagingClient.Connect</c>
        /// and <c>MessagingClient.ConnectAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ConnectSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::BidirectionalStreamingSettings"/> for calls to <c>MessagingClient.Connect</c> and
        /// <c>MessagingClient.ConnectAsync</c>.
        /// </summary>
        /// <remarks>The default local send queue size is 100.</remarks>
        public gaxgrpc::BidirectionalStreamingSettings ConnectStreamingSettings { get; set; } = new gaxgrpc::BidirectionalStreamingSettings(100);

        /// <summary>
        /// The settings to use for the <see cref="gcl::LocationsClient"/> associated with the client.
        /// </summary>
        public gcl::LocationsSettings LocationsSettings { get; set; } = gcl::LocationsSettings.GetDefault();

        /// <summary>
        /// The settings to use for the <see cref="gciv::IAMPolicyClient"/> associated with the client.
        /// </summary>
        public gciv::IAMPolicySettings IAMPolicySettings { get; set; } = gciv::IAMPolicySettings.GetDefault();

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="MessagingSettings"/> object.</returns>
        public MessagingSettings Clone() => new MessagingSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="MessagingClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class MessagingClientBuilder : gaxgrpc::ClientBuilderBase<MessagingClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public MessagingSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public MessagingClientBuilder() : base(MessagingClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref MessagingClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<MessagingClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override MessagingClient Build()
        {
            MessagingClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<MessagingClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<MessagingClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private MessagingClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return MessagingClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<MessagingClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return MessagingClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => MessagingClient.ChannelPool;
    }

    /// <summary>Messaging client wrapper, for convenient use.</summary>
    /// <remarks>
    /// A simple messaging service that implements chat rooms and profile posts.
    /// 
    /// This messaging service showcases the features that API clients
    /// generated by gapic-generators implement.
    /// </remarks>
    public abstract partial class MessagingClient
    {
        /// <summary>
        /// The default endpoint for the Messaging service, which is a host of "localhost:7469" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "localhost:7469:443";

        /// <summary>The default Messaging scopes.</summary>
        /// <remarks>The default Messaging scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Messaging.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc | gax::ApiTransports.Rest, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="MessagingClient"/> using the default credentials, endpoint and settings.
        /// To specify custom credentials or other settings, use <see cref="MessagingClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="MessagingClient"/>.</returns>
        public static stt::Task<MessagingClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new MessagingClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="MessagingClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="MessagingClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="MessagingClient"/>.</returns>
        public static MessagingClient Create() => new MessagingClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="MessagingClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="MessagingSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="MessagingClient"/>.</returns>
        internal static MessagingClient Create(grpccore::CallInvoker callInvoker, MessagingSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Messaging.MessagingClient grpcClient = new Messaging.MessagingClient(callInvoker);
            return new MessagingClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC Messaging client</summary>
        public virtual Messaging.MessagingClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public virtual gcl::LocationsClient LocationsClient => throw new sys::NotImplementedException();

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public virtual gciv::IAMPolicyClient IAMPolicyClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Room CreateRoom(CreateRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> CreateRoomAsync(CreateRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> CreateRoomAsync(CreateRoomRequest request, st::CancellationToken cancellationToken) =>
            CreateRoomAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="displayName">
        /// The human readable name of the chat room.
        /// </param>
        /// <param name="description">
        /// The description of the chat room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Room CreateRoom(string displayName, string description, gaxgrpc::CallSettings callSettings = null) =>
            CreateRoom(new CreateRoomRequest
            {
                Room = new Room
                {
                    DisplayName = gax::GaxPreconditions.CheckNotNullOrEmpty(displayName, nameof(displayName)),
                    Description = description ?? "",
                },
            }, callSettings);

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="displayName">
        /// The human readable name of the chat room.
        /// </param>
        /// <param name="description">
        /// The description of the chat room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> CreateRoomAsync(string displayName, string description, gaxgrpc::CallSettings callSettings = null) =>
            CreateRoomAsync(new CreateRoomRequest
            {
                Room = new Room
                {
                    DisplayName = gax::GaxPreconditions.CheckNotNullOrEmpty(displayName, nameof(displayName)),
                    Description = description ?? "",
                },
            }, callSettings);

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="displayName">
        /// The human readable name of the chat room.
        /// </param>
        /// <param name="description">
        /// The description of the chat room.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> CreateRoomAsync(string displayName, string description, st::CancellationToken cancellationToken) =>
            CreateRoomAsync(displayName, description, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Room GetRoom(GetRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> GetRoomAsync(GetRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> GetRoomAsync(GetRoomRequest request, st::CancellationToken cancellationToken) =>
            GetRoomAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Room GetRoom(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetRoom(new GetRoomRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> GetRoomAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetRoomAsync(new GetRoomRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> GetRoomAsync(string name, st::CancellationToken cancellationToken) =>
            GetRoomAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Room GetRoom(RoomName name, gaxgrpc::CallSettings callSettings = null) =>
            GetRoom(new GetRoomRequest
            {
                RoomName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> GetRoomAsync(RoomName name, gaxgrpc::CallSettings callSettings = null) =>
            GetRoomAsync(new GetRoomRequest
            {
                RoomName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> GetRoomAsync(RoomName name, st::CancellationToken cancellationToken) =>
            GetRoomAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Room UpdateRoom(UpdateRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> UpdateRoomAsync(UpdateRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Room> UpdateRoomAsync(UpdateRoomRequest request, st::CancellationToken cancellationToken) =>
            UpdateRoomAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteRoom(DeleteRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteRoomAsync(DeleteRoomRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteRoomAsync(DeleteRoomRequest request, st::CancellationToken cancellationToken) =>
            DeleteRoomAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteRoom(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteRoom(new DeleteRoomRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteRoomAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteRoomAsync(new DeleteRoomRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteRoomAsync(string name, st::CancellationToken cancellationToken) =>
            DeleteRoomAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteRoom(RoomName name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteRoom(new DeleteRoomRequest
            {
                RoomName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteRoomAsync(RoomName name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteRoomAsync(new DeleteRoomRequest
            {
                RoomName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested room.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteRoomAsync(RoomName name, st::CancellationToken cancellationToken) =>
            DeleteRoomAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all chat rooms.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Room"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListRoomsResponse, Room> ListRooms(ListRoomsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all chat rooms.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Room"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListRoomsResponse, Room> ListRoomsAsync(ListRoomsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb CreateBlurb(CreateBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(CreateBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(CreateBlurbRequest request, st::CancellationToken cancellationToken) =>
            CreateBlurbAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="text">
        /// The textual content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb CreateBlurb(string parent, string user, string text, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurb(new CreateBlurbRequest
            {
                Parent = gax::GaxPreconditions.CheckNotNullOrEmpty(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    User = gax::GaxPreconditions.CheckNotNullOrEmpty(user, nameof(user)),
                    Text = text ?? "",
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="text">
        /// The textual content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(string parent, string user, string text, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurbAsync(new CreateBlurbRequest
            {
                Parent = gax::GaxPreconditions.CheckNotNullOrEmpty(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    User = gax::GaxPreconditions.CheckNotNullOrEmpty(user, nameof(user)),
                    Text = text ?? "",
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="text">
        /// The textual content of this blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(string parent, string user, string text, st::CancellationToken cancellationToken) =>
            CreateBlurbAsync(parent, user, text, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="text">
        /// The textual content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb CreateBlurb(RoomName parent, UserName user, string text, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurb(new CreateBlurbRequest
            {
                ParentAsRoomName = gax::GaxPreconditions.CheckNotNull(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    UserAsUserName = gax::GaxPreconditions.CheckNotNull(user, nameof(user)),
                    Text = text ?? "",
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="text">
        /// The textual content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(RoomName parent, UserName user, string text, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurbAsync(new CreateBlurbRequest
            {
                ParentAsRoomName = gax::GaxPreconditions.CheckNotNull(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    UserAsUserName = gax::GaxPreconditions.CheckNotNull(user, nameof(user)),
                    Text = text ?? "",
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="text">
        /// The textual content of this blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(RoomName parent, UserName user, string text, st::CancellationToken cancellationToken) =>
            CreateBlurbAsync(parent, user, text, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="image">
        /// The image content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb CreateBlurb(string parent, string user, proto::ByteString image, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurb(new CreateBlurbRequest
            {
                Parent = gax::GaxPreconditions.CheckNotNullOrEmpty(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    User = gax::GaxPreconditions.CheckNotNullOrEmpty(user, nameof(user)),
                    Image = image ?? proto::ByteString.Empty,
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="image">
        /// The image content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(string parent, string user, proto::ByteString image, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurbAsync(new CreateBlurbRequest
            {
                Parent = gax::GaxPreconditions.CheckNotNullOrEmpty(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    User = gax::GaxPreconditions.CheckNotNullOrEmpty(user, nameof(user)),
                    Image = image ?? proto::ByteString.Empty,
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="image">
        /// The image content of this blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(string parent, string user, proto::ByteString image, st::CancellationToken cancellationToken) =>
            CreateBlurbAsync(parent, user, image, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="image">
        /// The image content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb CreateBlurb(RoomName parent, UserName user, proto::ByteString image, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurb(new CreateBlurbRequest
            {
                ParentAsRoomName = gax::GaxPreconditions.CheckNotNull(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    UserAsUserName = gax::GaxPreconditions.CheckNotNull(user, nameof(user)),
                    Image = image ?? proto::ByteString.Empty,
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="image">
        /// The image content of this blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(RoomName parent, UserName user, proto::ByteString image, gaxgrpc::CallSettings callSettings = null) =>
            CreateBlurbAsync(new CreateBlurbRequest
            {
                ParentAsRoomName = gax::GaxPreconditions.CheckNotNull(parent, nameof(parent)),
                Blurb = new Blurb
                {
                    UserAsUserName = gax::GaxPreconditions.CheckNotNull(user, nameof(user)),
                    Image = image ?? proto::ByteString.Empty,
                },
            }, callSettings);

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the chat room or user profile that this blurb will
        /// be tied to.
        /// </param>
        /// <param name="user">
        /// The resource name of the blurb's author.
        /// </param>
        /// <param name="image">
        /// The image content of this blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> CreateBlurbAsync(RoomName parent, UserName user, proto::ByteString image, st::CancellationToken cancellationToken) =>
            CreateBlurbAsync(parent, user, image, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb GetBlurb(GetBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> GetBlurbAsync(GetBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> GetBlurbAsync(GetBlurbRequest request, st::CancellationToken cancellationToken) =>
            GetBlurbAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb GetBlurb(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetBlurb(new GetBlurbRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> GetBlurbAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetBlurbAsync(new GetBlurbRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> GetBlurbAsync(string name, st::CancellationToken cancellationToken) =>
            GetBlurbAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb GetBlurb(BlurbName name, gaxgrpc::CallSettings callSettings = null) =>
            GetBlurb(new GetBlurbRequest
            {
                BlurbName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> GetBlurbAsync(BlurbName name, gaxgrpc::CallSettings callSettings = null) =>
            GetBlurbAsync(new GetBlurbRequest
            {
                BlurbName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> GetBlurbAsync(BlurbName name, st::CancellationToken cancellationToken) =>
            GetBlurbAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Blurb UpdateBlurb(UpdateBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> UpdateBlurbAsync(UpdateBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Blurb> UpdateBlurbAsync(UpdateBlurbRequest request, st::CancellationToken cancellationToken) =>
            UpdateBlurbAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteBlurb(DeleteBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteBlurbAsync(DeleteBlurbRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteBlurbAsync(DeleteBlurbRequest request, st::CancellationToken cancellationToken) =>
            DeleteBlurbAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteBlurb(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteBlurb(new DeleteBlurbRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteBlurbAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteBlurbAsync(new DeleteBlurbRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteBlurbAsync(string name, st::CancellationToken cancellationToken) =>
            DeleteBlurbAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteBlurb(BlurbName name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteBlurb(new DeleteBlurbRequest
            {
                BlurbName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteBlurbAsync(BlurbName name, gaxgrpc::CallSettings callSettings = null) =>
            DeleteBlurbAsync(new DeleteBlurbRequest
            {
                BlurbName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="name">
        /// The resource name of the requested blurb.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteBlurbAsync(BlurbName name, st::CancellationToken cancellationToken) =>
            DeleteBlurbAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Blurb"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListBlurbsResponse, Blurb> ListBlurbs(ListBlurbsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Blurb"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListBlurbsResponse, Blurb> ListBlurbsAsync(ListBlurbsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the requested room or profile whos blurbs to list.
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Blurb"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListBlurbsResponse, Blurb> ListBlurbs(string parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ListBlurbsRequest request = new ListBlurbsRequest
            {
                Parent = gax::GaxPreconditions.CheckNotNullOrEmpty(parent, nameof(parent)),
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ListBlurbs(request);
        }

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the requested room or profile whos blurbs to list.
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Blurb"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListBlurbsResponse, Blurb> ListBlurbsAsync(string parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ListBlurbsRequest request = new ListBlurbsRequest
            {
                Parent = gax::GaxPreconditions.CheckNotNullOrEmpty(parent, nameof(parent)),
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ListBlurbsAsync(request);
        }

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the requested room or profile whos blurbs to list.
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Blurb"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListBlurbsResponse, Blurb> ListBlurbs(RoomName parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ListBlurbsRequest request = new ListBlurbsRequest
            {
                ParentAsRoomName = gax::GaxPreconditions.CheckNotNull(parent, nameof(parent)),
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ListBlurbs(request);
        }

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="parent">
        /// The resource name of the requested room or profile whos blurbs to list.
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Blurb"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListBlurbsResponse, Blurb> ListBlurbsAsync(RoomName parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ListBlurbsRequest request = new ListBlurbsRequest
            {
                ParentAsRoomName = gax::GaxPreconditions.CheckNotNull(parent, nameof(parent)),
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ListBlurbsAsync(request);
        }

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata> SearchBlurbs(SearchBlurbsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> SearchBlurbsAsync(SearchBlurbsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> SearchBlurbsAsync(SearchBlurbsRequest request, st::CancellationToken cancellationToken) =>
            SearchBlurbsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>SearchBlurbs</c>.</summary>
        public virtual lro::OperationsClient SearchBlurbsOperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of <c>SearchBlurbs</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata> PollOnceSearchBlurbs(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), SearchBlurbsOperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>SearchBlurbs</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> PollOnceSearchBlurbsAsync(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), SearchBlurbsOperationsClient, callSettings);

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="parent">
        /// The rooms or profiles to search. If unset, `SearchBlurbs` will search all
        /// rooms and all profiles.
        /// </param>
        /// <param name="query">
        /// The query used to search for blurbs containing to words of this string.
        /// Only posts that contain an exact match of a queried word will be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata> SearchBlurbs(string parent, string query, gaxgrpc::CallSettings callSettings = null) =>
            SearchBlurbs(new SearchBlurbsRequest
            {
                Query = gax::GaxPreconditions.CheckNotNullOrEmpty(query, nameof(query)),
                Parent = parent ?? "",
            }, callSettings);

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="parent">
        /// The rooms or profiles to search. If unset, `SearchBlurbs` will search all
        /// rooms and all profiles.
        /// </param>
        /// <param name="query">
        /// The query used to search for blurbs containing to words of this string.
        /// Only posts that contain an exact match of a queried word will be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> SearchBlurbsAsync(string parent, string query, gaxgrpc::CallSettings callSettings = null) =>
            SearchBlurbsAsync(new SearchBlurbsRequest
            {
                Query = gax::GaxPreconditions.CheckNotNullOrEmpty(query, nameof(query)),
                Parent = parent ?? "",
            }, callSettings);

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="parent">
        /// The rooms or profiles to search. If unset, `SearchBlurbs` will search all
        /// rooms and all profiles.
        /// </param>
        /// <param name="query">
        /// The query used to search for blurbs containing to words of this string.
        /// Only posts that contain an exact match of a queried word will be returned.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> SearchBlurbsAsync(string parent, string query, st::CancellationToken cancellationToken) =>
            SearchBlurbsAsync(parent, query, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="parent">
        /// The rooms or profiles to search. If unset, `SearchBlurbs` will search all
        /// rooms and all profiles.
        /// </param>
        /// <param name="query">
        /// The query used to search for blurbs containing to words of this string.
        /// Only posts that contain an exact match of a queried word will be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata> SearchBlurbs(RoomName parent, string query, gaxgrpc::CallSettings callSettings = null) =>
            SearchBlurbs(new SearchBlurbsRequest
            {
                Query = gax::GaxPreconditions.CheckNotNullOrEmpty(query, nameof(query)),
                ParentAsRoomName = parent,
            }, callSettings);

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="parent">
        /// The rooms or profiles to search. If unset, `SearchBlurbs` will search all
        /// rooms and all profiles.
        /// </param>
        /// <param name="query">
        /// The query used to search for blurbs containing to words of this string.
        /// Only posts that contain an exact match of a queried word will be returned.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> SearchBlurbsAsync(RoomName parent, string query, gaxgrpc::CallSettings callSettings = null) =>
            SearchBlurbsAsync(new SearchBlurbsRequest
            {
                Query = gax::GaxPreconditions.CheckNotNullOrEmpty(query, nameof(query)),
                ParentAsRoomName = parent,
            }, callSettings);

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="parent">
        /// The rooms or profiles to search. If unset, `SearchBlurbs` will search all
        /// rooms and all profiles.
        /// </param>
        /// <param name="query">
        /// The query used to search for blurbs containing to words of this string.
        /// Only posts that contain an exact match of a queried word will be returned.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> SearchBlurbsAsync(RoomName parent, string query, st::CancellationToken cancellationToken) =>
            SearchBlurbsAsync(parent, query, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Server streaming methods for <see cref="StreamBlurbs(StreamBlurbsRequest,gaxgrpc::CallSettings)"/>.
        /// </summary>
        public abstract partial class StreamBlurbsStream : gaxgrpc::ServerStreamingBase<StreamBlurbsResponse>
        {
        }

        /// <summary>
        /// This returns a stream that emits the blurbs that are created for a
        /// particular chat room or user profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual StreamBlurbsStream StreamBlurbs(StreamBlurbsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Client streaming methods for
        /// <see cref="SendBlurbs(gaxgrpc::CallSettings,gaxgrpc::ClientStreamingSettings)"/>.
        /// </summary>
        public abstract partial class SendBlurbsStream : gaxgrpc::ClientStreamingBase<CreateBlurbRequest, SendBlurbsResponse>
        {
        }

        /// <summary>
        /// This is a stream to create multiple blurbs. If an invalid blurb is
        /// requested to be created, the stream will close with an error.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public virtual SendBlurbsStream SendBlurbs(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Bidirectional streaming methods for
        /// <see cref="Connect(gaxgrpc::CallSettings,gaxgrpc::BidirectionalStreamingSettings)"/>.
        /// </summary>
        public abstract partial class ConnectStream : gaxgrpc::BidirectionalStreamingBase<ConnectRequest, StreamBlurbsResponse>
        {
        }

        /// <summary>
        /// This method starts a bidirectional stream that receives all blurbs that
        /// are being created after the stream has started and sends requests to create
        /// blurbs. If an invalid blurb is requested to be created, the stream will
        /// close with an error.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public virtual ConnectStream Connect(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();
    }

    /// <summary>Messaging client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// A simple messaging service that implements chat rooms and profile posts.
    /// 
    /// This messaging service showcases the features that API clients
    /// generated by gapic-generators implement.
    /// </remarks>
    public sealed partial class MessagingClientImpl : MessagingClient
    {
        private readonly gaxgrpc::ApiCall<CreateRoomRequest, Room> _callCreateRoom;

        private readonly gaxgrpc::ApiCall<GetRoomRequest, Room> _callGetRoom;

        private readonly gaxgrpc::ApiCall<UpdateRoomRequest, Room> _callUpdateRoom;

        private readonly gaxgrpc::ApiCall<DeleteRoomRequest, wkt::Empty> _callDeleteRoom;

        private readonly gaxgrpc::ApiCall<ListRoomsRequest, ListRoomsResponse> _callListRooms;

        private readonly gaxgrpc::ApiCall<CreateBlurbRequest, Blurb> _callCreateBlurb;

        private readonly gaxgrpc::ApiCall<GetBlurbRequest, Blurb> _callGetBlurb;

        private readonly gaxgrpc::ApiCall<UpdateBlurbRequest, Blurb> _callUpdateBlurb;

        private readonly gaxgrpc::ApiCall<DeleteBlurbRequest, wkt::Empty> _callDeleteBlurb;

        private readonly gaxgrpc::ApiCall<ListBlurbsRequest, ListBlurbsResponse> _callListBlurbs;

        private readonly gaxgrpc::ApiCall<SearchBlurbsRequest, lro::Operation> _callSearchBlurbs;

        private readonly gaxgrpc::ApiServerStreamingCall<StreamBlurbsRequest, StreamBlurbsResponse> _callStreamBlurbs;

        private readonly gaxgrpc::ApiClientStreamingCall<CreateBlurbRequest, SendBlurbsResponse> _callSendBlurbs;

        private readonly gaxgrpc::ApiBidirectionalStreamingCall<ConnectRequest, StreamBlurbsResponse> _callConnect;

        /// <summary>
        /// Constructs a client wrapper for the Messaging service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="MessagingSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public MessagingClientImpl(Messaging.MessagingClient grpcClient, MessagingSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            MessagingSettings effectiveSettings = settings ?? MessagingSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(new gaxgrpc::ClientHelper.Options
            {
                Settings = effectiveSettings,
                Logger = logger,
            });
            SearchBlurbsOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.SearchBlurbsOperationsSettings, logger);
            LocationsClient = new gcl::LocationsClientImpl(grpcClient.CreateLocationsClient(), effectiveSettings.LocationsSettings, logger);
            IAMPolicyClient = new gciv::IAMPolicyClientImpl(grpcClient.CreateIAMPolicyClient(), effectiveSettings.IAMPolicySettings, logger);
            _callCreateRoom = clientHelper.BuildApiCall<CreateRoomRequest, Room>("CreateRoom", grpcClient.CreateRoomAsync, grpcClient.CreateRoom, effectiveSettings.CreateRoomSettings);
            Modify_ApiCall(ref _callCreateRoom);
            Modify_CreateRoomApiCall(ref _callCreateRoom);
            _callGetRoom = clientHelper.BuildApiCall<GetRoomRequest, Room>("GetRoom", grpcClient.GetRoomAsync, grpcClient.GetRoom, effectiveSettings.GetRoomSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callGetRoom);
            Modify_GetRoomApiCall(ref _callGetRoom);
            _callUpdateRoom = clientHelper.BuildApiCall<UpdateRoomRequest, Room>("UpdateRoom", grpcClient.UpdateRoomAsync, grpcClient.UpdateRoom, effectiveSettings.UpdateRoomSettings).WithGoogleRequestParam("room.name", request => request.Room?.Name);
            Modify_ApiCall(ref _callUpdateRoom);
            Modify_UpdateRoomApiCall(ref _callUpdateRoom);
            _callDeleteRoom = clientHelper.BuildApiCall<DeleteRoomRequest, wkt::Empty>("DeleteRoom", grpcClient.DeleteRoomAsync, grpcClient.DeleteRoom, effectiveSettings.DeleteRoomSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callDeleteRoom);
            Modify_DeleteRoomApiCall(ref _callDeleteRoom);
            _callListRooms = clientHelper.BuildApiCall<ListRoomsRequest, ListRoomsResponse>("ListRooms", grpcClient.ListRoomsAsync, grpcClient.ListRooms, effectiveSettings.ListRoomsSettings);
            Modify_ApiCall(ref _callListRooms);
            Modify_ListRoomsApiCall(ref _callListRooms);
            _callCreateBlurb = clientHelper.BuildApiCall<CreateBlurbRequest, Blurb>("CreateBlurb", grpcClient.CreateBlurbAsync, grpcClient.CreateBlurb, effectiveSettings.CreateBlurbSettings).WithGoogleRequestParam("parent", request => request.Parent);
            Modify_ApiCall(ref _callCreateBlurb);
            Modify_CreateBlurbApiCall(ref _callCreateBlurb);
            _callGetBlurb = clientHelper.BuildApiCall<GetBlurbRequest, Blurb>("GetBlurb", grpcClient.GetBlurbAsync, grpcClient.GetBlurb, effectiveSettings.GetBlurbSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callGetBlurb);
            Modify_GetBlurbApiCall(ref _callGetBlurb);
            _callUpdateBlurb = clientHelper.BuildApiCall<UpdateBlurbRequest, Blurb>("UpdateBlurb", grpcClient.UpdateBlurbAsync, grpcClient.UpdateBlurb, effectiveSettings.UpdateBlurbSettings).WithGoogleRequestParam("blurb.name", request => request.Blurb?.Name);
            Modify_ApiCall(ref _callUpdateBlurb);
            Modify_UpdateBlurbApiCall(ref _callUpdateBlurb);
            _callDeleteBlurb = clientHelper.BuildApiCall<DeleteBlurbRequest, wkt::Empty>("DeleteBlurb", grpcClient.DeleteBlurbAsync, grpcClient.DeleteBlurb, effectiveSettings.DeleteBlurbSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callDeleteBlurb);
            Modify_DeleteBlurbApiCall(ref _callDeleteBlurb);
            _callListBlurbs = clientHelper.BuildApiCall<ListBlurbsRequest, ListBlurbsResponse>("ListBlurbs", grpcClient.ListBlurbsAsync, grpcClient.ListBlurbs, effectiveSettings.ListBlurbsSettings).WithGoogleRequestParam("parent", request => request.Parent);
            Modify_ApiCall(ref _callListBlurbs);
            Modify_ListBlurbsApiCall(ref _callListBlurbs);
            _callSearchBlurbs = clientHelper.BuildApiCall<SearchBlurbsRequest, lro::Operation>("SearchBlurbs", grpcClient.SearchBlurbsAsync, grpcClient.SearchBlurbs, effectiveSettings.SearchBlurbsSettings).WithGoogleRequestParam("parent", request => request.Parent);
            Modify_ApiCall(ref _callSearchBlurbs);
            Modify_SearchBlurbsApiCall(ref _callSearchBlurbs);
            _callStreamBlurbs = clientHelper.BuildApiCall<StreamBlurbsRequest, StreamBlurbsResponse>("StreamBlurbs", grpcClient.StreamBlurbs, effectiveSettings.StreamBlurbsSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callStreamBlurbs);
            Modify_StreamBlurbsApiCall(ref _callStreamBlurbs);
            _callSendBlurbs = clientHelper.BuildApiCall<CreateBlurbRequest, SendBlurbsResponse>("SendBlurbs", grpcClient.SendBlurbs, effectiveSettings.SendBlurbsSettings, effectiveSettings.SendBlurbsStreamingSettings);
            Modify_ApiCall(ref _callSendBlurbs);
            Modify_SendBlurbsApiCall(ref _callSendBlurbs);
            _callConnect = clientHelper.BuildApiCall<ConnectRequest, StreamBlurbsResponse>("Connect", grpcClient.Connect, effectiveSettings.ConnectSettings, effectiveSettings.ConnectStreamingSettings);
            Modify_ApiCall(ref _callConnect);
            Modify_ConnectApiCall(ref _callConnect);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiBidirectionalStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiServerStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiClientStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_CreateRoomApiCall(ref gaxgrpc::ApiCall<CreateRoomRequest, Room> call);

        partial void Modify_GetRoomApiCall(ref gaxgrpc::ApiCall<GetRoomRequest, Room> call);

        partial void Modify_UpdateRoomApiCall(ref gaxgrpc::ApiCall<UpdateRoomRequest, Room> call);

        partial void Modify_DeleteRoomApiCall(ref gaxgrpc::ApiCall<DeleteRoomRequest, wkt::Empty> call);

        partial void Modify_ListRoomsApiCall(ref gaxgrpc::ApiCall<ListRoomsRequest, ListRoomsResponse> call);

        partial void Modify_CreateBlurbApiCall(ref gaxgrpc::ApiCall<CreateBlurbRequest, Blurb> call);

        partial void Modify_GetBlurbApiCall(ref gaxgrpc::ApiCall<GetBlurbRequest, Blurb> call);

        partial void Modify_UpdateBlurbApiCall(ref gaxgrpc::ApiCall<UpdateBlurbRequest, Blurb> call);

        partial void Modify_DeleteBlurbApiCall(ref gaxgrpc::ApiCall<DeleteBlurbRequest, wkt::Empty> call);

        partial void Modify_ListBlurbsApiCall(ref gaxgrpc::ApiCall<ListBlurbsRequest, ListBlurbsResponse> call);

        partial void Modify_SearchBlurbsApiCall(ref gaxgrpc::ApiCall<SearchBlurbsRequest, lro::Operation> call);

        partial void Modify_StreamBlurbsApiCall(ref gaxgrpc::ApiServerStreamingCall<StreamBlurbsRequest, StreamBlurbsResponse> call);

        partial void Modify_SendBlurbsApiCall(ref gaxgrpc::ApiClientStreamingCall<CreateBlurbRequest, SendBlurbsResponse> call);

        partial void Modify_ConnectApiCall(ref gaxgrpc::ApiBidirectionalStreamingCall<ConnectRequest, StreamBlurbsResponse> call);

        partial void OnConstruction(Messaging.MessagingClient grpcClient, MessagingSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Messaging client</summary>
        public override Messaging.MessagingClient GrpcClient { get; }

        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public override gcl::LocationsClient LocationsClient { get; }

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public override gciv::IAMPolicyClient IAMPolicyClient { get; }

        partial void Modify_CreateRoomRequest(ref CreateRoomRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetRoomRequest(ref GetRoomRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdateRoomRequest(ref UpdateRoomRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteRoomRequest(ref DeleteRoomRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListRoomsRequest(ref ListRoomsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_CreateBlurbRequest(ref CreateBlurbRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetBlurbRequest(ref GetBlurbRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdateBlurbRequest(ref UpdateBlurbRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteBlurbRequest(ref DeleteBlurbRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListBlurbsRequest(ref ListBlurbsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SearchBlurbsRequest(ref SearchBlurbsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_StreamBlurbsRequest(ref StreamBlurbsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_CreateBlurbRequestCallSettings(ref gaxgrpc::CallSettings settings);

        partial void Modify_CreateBlurbRequestRequest(ref CreateBlurbRequest request);

        partial void Modify_ConnectRequestCallSettings(ref gaxgrpc::CallSettings settings);

        partial void Modify_ConnectRequestRequest(ref ConnectRequest request);

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Room CreateRoom(CreateRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateRoomRequest(ref request, ref callSettings);
            return _callCreateRoom.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Room> CreateRoomAsync(CreateRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateRoomRequest(ref request, ref callSettings);
            return _callCreateRoom.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Room GetRoom(GetRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRoomRequest(ref request, ref callSettings);
            return _callGetRoom.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the Room with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Room> GetRoomAsync(GetRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRoomRequest(ref request, ref callSettings);
            return _callGetRoom.Async(request, callSettings);
        }

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Room UpdateRoom(UpdateRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateRoomRequest(ref request, ref callSettings);
            return _callUpdateRoom.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates a room.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Room> UpdateRoomAsync(UpdateRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateRoomRequest(ref request, ref callSettings);
            return _callUpdateRoom.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override void DeleteRoom(DeleteRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRoomRequest(ref request, ref callSettings);
            _callDeleteRoom.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes a room and all of its blurbs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task DeleteRoomAsync(DeleteRoomRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRoomRequest(ref request, ref callSettings);
            return _callDeleteRoom.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all chat rooms.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Room"/> resources.</returns>
        public override gax::PagedEnumerable<ListRoomsResponse, Room> ListRooms(ListRoomsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRoomsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<ListRoomsRequest, ListRoomsResponse, Room>(_callListRooms, request, callSettings);
        }

        /// <summary>
        /// Lists all chat rooms.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Room"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<ListRoomsResponse, Room> ListRoomsAsync(ListRoomsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRoomsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<ListRoomsRequest, ListRoomsResponse, Room>(_callListRooms, request, callSettings);
        }

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Blurb CreateBlurb(CreateBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateBlurbRequest(ref request, ref callSettings);
            return _callCreateBlurb.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a blurb. If the parent is a room, the blurb is understood to be a
        /// message in that room. If the parent is a profile, the blurb is understood
        /// to be a post on the profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Blurb> CreateBlurbAsync(CreateBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateBlurbRequest(ref request, ref callSettings);
            return _callCreateBlurb.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Blurb GetBlurb(GetBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetBlurbRequest(ref request, ref callSettings);
            return _callGetBlurb.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the Blurb with the given resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Blurb> GetBlurbAsync(GetBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetBlurbRequest(ref request, ref callSettings);
            return _callGetBlurb.Async(request, callSettings);
        }

        /// <summary>
        /// Updates a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Blurb UpdateBlurb(UpdateBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateBlurbRequest(ref request, ref callSettings);
            return _callUpdateBlurb.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Blurb> UpdateBlurbAsync(UpdateBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateBlurbRequest(ref request, ref callSettings);
            return _callUpdateBlurb.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override void DeleteBlurb(DeleteBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteBlurbRequest(ref request, ref callSettings);
            _callDeleteBlurb.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes a blurb.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task DeleteBlurbAsync(DeleteBlurbRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteBlurbRequest(ref request, ref callSettings);
            return _callDeleteBlurb.Async(request, callSettings);
        }

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Blurb"/> resources.</returns>
        public override gax::PagedEnumerable<ListBlurbsResponse, Blurb> ListBlurbs(ListBlurbsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListBlurbsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<ListBlurbsRequest, ListBlurbsResponse, Blurb>(_callListBlurbs, request, callSettings);
        }

        /// <summary>
        /// Lists blurbs for a specific chat room or user profile depending on the
        /// parent resource name.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Blurb"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<ListBlurbsResponse, Blurb> ListBlurbsAsync(ListBlurbsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListBlurbsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<ListBlurbsRequest, ListBlurbsResponse, Blurb>(_callListBlurbs, request, callSettings);
        }

        /// <summary>The long-running operations client for <c>SearchBlurbs</c>.</summary>
        public override lro::OperationsClient SearchBlurbsOperationsClient { get; }

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata> SearchBlurbs(SearchBlurbsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SearchBlurbsRequest(ref request, ref callSettings);
            return new lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>(_callSearchBlurbs.Sync(request, callSettings), SearchBlurbsOperationsClient);
        }

        /// <summary>
        /// This method searches through all blurbs across all rooms and profiles
        /// for blurbs containing to words found in the query. Only posts that
        /// contain an exact match of a queried word will be returned.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>> SearchBlurbsAsync(SearchBlurbsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SearchBlurbsRequest(ref request, ref callSettings);
            return new lro::Operation<SearchBlurbsResponse, SearchBlurbsMetadata>(await _callSearchBlurbs.Async(request, callSettings).ConfigureAwait(false), SearchBlurbsOperationsClient);
        }

        internal sealed partial class StreamBlurbsStreamImpl : StreamBlurbsStream
        {
            /// <summary>Construct the server streaming method for <c>StreamBlurbs</c>.</summary>
            /// <param name="call">The underlying gRPC server streaming call.</param>
            public StreamBlurbsStreamImpl(grpccore::AsyncServerStreamingCall<StreamBlurbsResponse> call) => GrpcCall = call;

            public override grpccore::AsyncServerStreamingCall<StreamBlurbsResponse> GrpcCall { get; }
        }

        /// <summary>
        /// This returns a stream that emits the blurbs that are created for a
        /// particular chat room or user profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public override MessagingClient.StreamBlurbsStream StreamBlurbs(StreamBlurbsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_StreamBlurbsRequest(ref request, ref callSettings);
            return new StreamBlurbsStreamImpl(_callStreamBlurbs.Call(request, callSettings));
        }

        internal sealed partial class SendBlurbsStreamImpl : SendBlurbsStream
        {
            /// <summary>Construct the client streaming method for <c>SendBlurbs</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC client streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{CreateBlurbRequest}"/> instance associated with this
            /// streaming call.
            /// </param>
            public SendBlurbsStreamImpl(MessagingClientImpl service, grpccore::AsyncClientStreamingCall<CreateBlurbRequest, SendBlurbsResponse> call, gaxgrpc::BufferedClientStreamWriter<CreateBlurbRequest> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private MessagingClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<CreateBlurbRequest> _writeBuffer;

            public override grpccore::AsyncClientStreamingCall<CreateBlurbRequest, SendBlurbsResponse> GrpcCall { get; }

            private CreateBlurbRequest ModifyRequest(CreateBlurbRequest request)
            {
                _service.Modify_CreateBlurbRequestRequest(ref request);
                return request;
            }

            public override stt::Task TryWriteAsync(CreateBlurbRequest message) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message));

            public override stt::Task WriteAsync(CreateBlurbRequest message) =>
                _writeBuffer.WriteAsync(ModifyRequest(message));

            public override stt::Task TryWriteAsync(CreateBlurbRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message), options);

            public override stt::Task WriteAsync(CreateBlurbRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.WriteAsync(ModifyRequest(message), options);

            public override stt::Task TryWriteCompleteAsync() => _writeBuffer.TryWriteCompleteAsync();

            public override stt::Task WriteCompleteAsync() => _writeBuffer.WriteCompleteAsync();
        }

        /// <summary>
        /// This is a stream to create multiple blurbs. If an invalid blurb is
        /// requested to be created, the stream will close with an error.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public override MessagingClient.SendBlurbsStream SendBlurbs(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null)
        {
            Modify_CreateBlurbRequestCallSettings(ref callSettings);
            gaxgrpc::ClientStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callSendBlurbs.StreamingSettings;
            grpccore::AsyncClientStreamingCall<CreateBlurbRequest, SendBlurbsResponse> call = _callSendBlurbs.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<CreateBlurbRequest> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<CreateBlurbRequest>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new SendBlurbsStreamImpl(this, call, writeBuffer);
        }

        internal sealed partial class ConnectStreamImpl : ConnectStream
        {
            /// <summary>Construct the bidirectional streaming method for <c>Connect</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC duplex streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{ConnectRequest}"/> instance associated with this
            /// streaming call.
            /// </param>
            public ConnectStreamImpl(MessagingClientImpl service, grpccore::AsyncDuplexStreamingCall<ConnectRequest, StreamBlurbsResponse> call, gaxgrpc::BufferedClientStreamWriter<ConnectRequest> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private MessagingClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<ConnectRequest> _writeBuffer;

            public override grpccore::AsyncDuplexStreamingCall<ConnectRequest, StreamBlurbsResponse> GrpcCall { get; }

            private ConnectRequest ModifyRequest(ConnectRequest request)
            {
                _service.Modify_ConnectRequestRequest(ref request);
                return request;
            }

            public override stt::Task TryWriteAsync(ConnectRequest message) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message));

            public override stt::Task WriteAsync(ConnectRequest message) => _writeBuffer.WriteAsync(ModifyRequest(message));

            public override stt::Task TryWriteAsync(ConnectRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message), options);

            public override stt::Task WriteAsync(ConnectRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.WriteAsync(ModifyRequest(message), options);

            public override stt::Task TryWriteCompleteAsync() => _writeBuffer.TryWriteCompleteAsync();

            public override stt::Task WriteCompleteAsync() => _writeBuffer.WriteCompleteAsync();
        }

        /// <summary>
        /// This method starts a bidirectional stream that receives all blurbs that
        /// are being created after the stream has started and sends requests to create
        /// blurbs. If an invalid blurb is requested to be created, the stream will
        /// close with an error.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public override MessagingClient.ConnectStream Connect(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null)
        {
            Modify_ConnectRequestCallSettings(ref callSettings);
            gaxgrpc::BidirectionalStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callConnect.StreamingSettings;
            grpccore::AsyncDuplexStreamingCall<ConnectRequest, StreamBlurbsResponse> call = _callConnect.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<ConnectRequest> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<ConnectRequest>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new ConnectStreamImpl(this, call, writeBuffer);
        }
    }

    public partial class ListRoomsRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class ListBlurbsRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class ListRoomsResponse : gaxgrpc::IPageResponse<Room>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<Room> GetEnumerator() => Rooms.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public partial class ListBlurbsResponse : gaxgrpc::IPageResponse<Blurb>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<Blurb> GetEnumerator() => Blurbs.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static partial class Messaging
    {
        public partial class MessagingClient
        {
            /// <summary>
            /// Creates a new instance of <see cref="lro::Operations.OperationsClient"/> using the same call invoker as
            /// this client.
            /// </summary>
            /// <returns>A new Operations client for the same target as this client.</returns>
            public virtual lro::Operations.OperationsClient CreateOperationsClient() =>
                new lro::Operations.OperationsClient(CallInvoker);
        }
    }

    public static partial class Messaging
    {
        public partial class MessagingClient
        {
            /// <summary>
            /// Creates a new instance of <see cref="gcl::Locations.LocationsClient"/> using the same call invoker as
            /// this client.
            /// </summary>
            /// <returns>
            /// A new <see cref="gcl::Locations.LocationsClient"/> for the same target as this client.
            /// </returns>
            public virtual gcl::Locations.LocationsClient CreateLocationsClient() =>
                new gcl::Locations.LocationsClient(CallInvoker);

            /// <summary>
            /// Creates a new instance of <see cref="gciv::IAMPolicy.IAMPolicyClient"/> using the same call invoker as
            /// this client.
            /// </summary>
            /// <returns>
            /// A new <see cref="gciv::IAMPolicy.IAMPolicyClient"/> for the same target as this client.
            /// </returns>
            public virtual gciv::IAMPolicy.IAMPolicyClient CreateIAMPolicyClient() =>
                new gciv::IAMPolicy.IAMPolicyClient(CallInvoker);
        }
    }
}
