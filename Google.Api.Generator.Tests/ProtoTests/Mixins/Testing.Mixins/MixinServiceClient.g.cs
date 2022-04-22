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
using gciv = Google.Cloud.Iam.V1;
using gcl = Google.Cloud.Location;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.Mixins
{
    /// <summary>Settings for <see cref="MixinServiceClient"/> instances.</summary>
    public sealed partial class MixinServiceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="MixinServiceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="MixinServiceSettings"/>.</returns>
        public static MixinServiceSettings GetDefault() => new MixinServiceSettings();

        /// <summary>Constructs a new <see cref="MixinServiceSettings"/> object with default settings.</summary>
        public MixinServiceSettings()
        {
        }

        // TEST_START
        private MixinServiceSettings(MixinServiceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            MethodSettings = existing.MethodSettings;
            LocationsSettings = existing.LocationsSettings;
            IAMPolicySettings = existing.IAMPolicySettings;
            OnCopy(existing);
        }
        // TEST_END

        partial void OnCopy(MixinServiceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>MixinServiceClient.Method</c>
        ///  and <c>MixinServiceClient.MethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings MethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        // TEST_START
        /// <summary>
        /// The settings to use for the <see cref="gcl::LocationsClient"/> associated with the client.
        /// </summary>
        public gcl::LocationsSettings LocationsSettings { get; set; } = gcl::LocationsSettings.GetDefault();

        /// <summary>
        /// The settings to use for the <see cref="gciv::IAMPolicyClient"/> associated with the client.
        /// </summary>
        public gciv::IAMPolicySettings IAMPolicySettings { get; set; } = gciv::IAMPolicySettings.GetDefault();
        // TEST_END

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="MixinServiceSettings"/> object.</returns>
        public MixinServiceSettings Clone() => new MixinServiceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="MixinServiceClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class MixinServiceClientBuilder : gaxgrpc::ClientBuilderBase<MixinServiceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public MixinServiceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public MixinServiceClientBuilder() : base(MixinServiceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref MixinServiceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<MixinServiceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override MixinServiceClient Build()
        {
            MixinServiceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<MixinServiceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<MixinServiceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private MixinServiceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return MixinServiceClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<MixinServiceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return MixinServiceClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => MixinServiceClient.ChannelPool;
    }

    /// <summary>MixinService client wrapper, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public abstract partial class MixinServiceClient
    {
        /// <summary>
        /// The default endpoint for the MixinService service, which is a host of "mixins.example.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "mixins.example.com:443";

        /// <summary>The default MixinService scopes.</summary>
        /// <remarks>
        /// The default MixinService scopes are:
        /// <list type="bullet">
        /// <item><description>scope1</description></item>
        /// <item><description>scope2</description></item>
        /// </list>
        /// </remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { "scope1", "scope2", });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(MixinService.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="MixinServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="MixinServiceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="MixinServiceClient"/>.</returns>
        public static stt::Task<MixinServiceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new MixinServiceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="MixinServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="MixinServiceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="MixinServiceClient"/>.</returns>
        public static MixinServiceClient Create() => new MixinServiceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="MixinServiceClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="MixinServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="MixinServiceClient"/>.</returns>
        internal static MixinServiceClient Create(grpccore::CallInvoker callInvoker, MixinServiceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            MixinService.MixinServiceClient grpcClient = new MixinService.MixinServiceClient(callInvoker);
            return new MixinServiceClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC MixinService client</summary>
        public virtual MixinService.MixinServiceClient GrpcClient => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public virtual gcl::LocationsClient LocationsClient => throw new sys::NotImplementedException();

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public virtual gciv::IAMPolicyClient IAMPolicyClient => throw new sys::NotImplementedException();
        // TEST_END

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodAsync(Request request, st::CancellationToken cancellationToken) =>
            MethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>MixinService client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class MixinServiceClientImpl : MixinServiceClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callMethod;

        // TEST_START
        /// <summary>
        /// Constructs a client wrapper for the MixinService service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="MixinServiceSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public MixinServiceClientImpl(MixinService.MixinServiceClient grpcClient, MixinServiceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            MixinServiceSettings effectiveSettings = settings ?? MixinServiceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            LocationsClient = new gcl::LocationsClientImpl(grpcClient.CreateLocationsClient(), effectiveSettings.LocationsSettings, logger);
            IAMPolicyClient = new gciv::IAMPolicyClientImpl(grpcClient.CreateIAMPolicyClient(), effectiveSettings.IAMPolicySettings, logger);
            _callMethod = clientHelper.BuildApiCall<Request, Response>("Method", grpcClient.MethodAsync, grpcClient.Method, effectiveSettings.MethodSettings);
            Modify_ApiCall(ref _callMethod);
            Modify_MethodApiCall(ref _callMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }
        // TEST_END

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_MethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void OnConstruction(MixinService.MixinServiceClient grpcClient, MixinServiceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC MixinService client</summary>
        public override MixinService.MixinServiceClient GrpcClient { get; }

        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public override gcl::LocationsClient LocationsClient { get; }

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public override gciv::IAMPolicyClient IAMPolicyClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response Method(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> MethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callMethod.Async(request, callSettings);
        }
    }

    // TEST_START
    public static partial class MixinService
    {
        public partial class MixinServiceClient
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
    // TEST_END
}
