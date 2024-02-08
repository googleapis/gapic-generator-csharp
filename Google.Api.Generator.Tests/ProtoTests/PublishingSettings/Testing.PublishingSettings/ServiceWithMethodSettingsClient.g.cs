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
using lro = Google.LongRunning;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using sc = System.Collections;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.PublishingSettings
{
    /// <summary>Settings for <see cref="ServiceWithMethodSettingsClient"/> instances.</summary>
    public sealed partial class ServiceWithMethodSettingsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="ServiceWithMethodSettingsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="ServiceWithMethodSettingsSettings"/>.</returns>
        public static ServiceWithMethodSettingsSettings GetDefault() => new ServiceWithMethodSettingsSettings();

        /// <summary>
        /// Constructs a new <see cref="ServiceWithMethodSettingsSettings"/> object with default settings.
        /// </summary>
        public ServiceWithMethodSettingsSettings()
        {
        }

        private ServiceWithMethodSettingsSettings(ServiceWithMethodSettingsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            UnaryAutoPopulatedSettings = existing.UnaryAutoPopulatedSettings;
            ServerStreamingAutoPopulatedSettings = existing.ServerStreamingAutoPopulatedSettings;
            ClientStreamingAutoPopulatedSettings = existing.ClientStreamingAutoPopulatedSettings;
            ClientStreamingAutoPopulatedStreamingSettings = existing.ClientStreamingAutoPopulatedStreamingSettings;
            BidiStreamingAutoPopulatedSettings = existing.BidiStreamingAutoPopulatedSettings;
            BidiStreamingAutoPopulatedStreamingSettings = existing.BidiStreamingAutoPopulatedStreamingSettings;
            LroAutoPopulatedSettings = existing.LroAutoPopulatedSettings;
            LroAutoPopulatedOperationsSettings = existing.LroAutoPopulatedOperationsSettings.Clone();
            PaginatedAutoPopulatedSettings = existing.PaginatedAutoPopulatedSettings;
            OnCopy(existing);
        }

        partial void OnCopy(ServiceWithMethodSettingsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithMethodSettingsClient.UnaryAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.UnaryAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UnaryAutoPopulatedSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithMethodSettingsClient.ServerStreamingAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.ServerStreamingAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ServerStreamingAutoPopulatedSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithMethodSettingsClient.ClientStreamingAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.ClientStreamingAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ClientStreamingAutoPopulatedSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::ClientStreamingSettings"/> for calls to
        /// <c>ServiceWithMethodSettingsClient.ClientStreamingAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.ClientStreamingAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>The default local send queue size is 100.</remarks>
        public gaxgrpc::ClientStreamingSettings ClientStreamingAutoPopulatedStreamingSettings { get; set; } = new gaxgrpc::ClientStreamingSettings(100);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithMethodSettingsClient.BidiStreamingAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.BidiStreamingAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings BidiStreamingAutoPopulatedSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::BidirectionalStreamingSettings"/> for calls to
        /// <c>ServiceWithMethodSettingsClient.BidiStreamingAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.BidiStreamingAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>The default local send queue size is 100.</remarks>
        public gaxgrpc::BidirectionalStreamingSettings BidiStreamingAutoPopulatedStreamingSettings { get; set; } = new gaxgrpc::BidirectionalStreamingSettings(100);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithMethodSettingsClient.LroAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.LroAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings LroAutoPopulatedSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// Long Running Operation settings for calls to <c>ServiceWithMethodSettingsClient.LroAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.LroAutoPopulatedAsync</c>.
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
        public lro::OperationsSettings LroAutoPopulatedOperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithMethodSettingsClient.PaginatedAutoPopulated</c> and
        /// <c>ServiceWithMethodSettingsClient.PaginatedAutoPopulatedAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PaginatedAutoPopulatedSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="ServiceWithMethodSettingsSettings"/> object.</returns>
        public ServiceWithMethodSettingsSettings Clone() => new ServiceWithMethodSettingsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="ServiceWithMethodSettingsClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class ServiceWithMethodSettingsClientBuilder : gaxgrpc::ClientBuilderBase<ServiceWithMethodSettingsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public ServiceWithMethodSettingsSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public ServiceWithMethodSettingsClientBuilder() : base(ServiceWithMethodSettingsClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref ServiceWithMethodSettingsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<ServiceWithMethodSettingsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override ServiceWithMethodSettingsClient Build()
        {
            ServiceWithMethodSettingsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<ServiceWithMethodSettingsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<ServiceWithMethodSettingsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private ServiceWithMethodSettingsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return ServiceWithMethodSettingsClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<ServiceWithMethodSettingsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return ServiceWithMethodSettingsClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => ServiceWithMethodSettingsClient.ChannelPool;
    }

    /// <summary>ServiceWithMethodSettings client wrapper, for convenient use.</summary>
    /// <remarks>
    /// This is a service with method settings in the service config.
    /// </remarks>
    public abstract partial class ServiceWithMethodSettingsClient
    {
        /// <summary>
        /// The default endpoint for the ServiceWithMethodSettings service, which is a host of "" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = ":443";

        /// <summary>The default ServiceWithMethodSettings scopes.</summary>
        /// <remarks>The default ServiceWithMethodSettings scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(ServiceWithMethodSettings.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="ServiceWithMethodSettingsClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="ServiceWithMethodSettingsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="ServiceWithMethodSettingsClient"/>.</returns>
        public static stt::Task<ServiceWithMethodSettingsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new ServiceWithMethodSettingsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="ServiceWithMethodSettingsClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="ServiceWithMethodSettingsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="ServiceWithMethodSettingsClient"/>.</returns>
        public static ServiceWithMethodSettingsClient Create() => new ServiceWithMethodSettingsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="ServiceWithMethodSettingsClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="ServiceWithMethodSettingsSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="ServiceWithMethodSettingsClient"/>.</returns>
        internal static ServiceWithMethodSettingsClient Create(grpccore::CallInvoker callInvoker, ServiceWithMethodSettingsSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            ServiceWithMethodSettings.ServiceWithMethodSettingsClient grpcClient = new ServiceWithMethodSettings.ServiceWithMethodSettingsClient(callInvoker);
            return new ServiceWithMethodSettingsClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC ServiceWithMethodSettings client</summary>
        public virtual ServiceWithMethodSettings.ServiceWithMethodSettingsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response UnaryAutoPopulated(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> UnaryAutoPopulatedAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> UnaryAutoPopulatedAsync(Request request, st::CancellationToken cancellationToken) =>
            UnaryAutoPopulatedAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Server streaming methods for <see cref="ServerStreamingAutoPopulated(Request,gaxgrpc::CallSettings)"/>.
        /// </summary>
        public abstract partial class ServerStreamingAutoPopulatedStream : gaxgrpc::ServerStreamingBase<Response>
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual ServerStreamingAutoPopulatedStream ServerStreamingAutoPopulated(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Client streaming methods for
        /// <see cref="ClientStreamingAutoPopulated(gaxgrpc::CallSettings,gaxgrpc::ClientStreamingSettings)"/>.
        /// </summary>
        public abstract partial class ClientStreamingAutoPopulatedStream : gaxgrpc::ClientStreamingBase<Request, Response>
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public virtual ClientStreamingAutoPopulatedStream ClientStreamingAutoPopulated(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Bidirectional streaming methods for
        /// <see cref="BidiStreamingAutoPopulated(gaxgrpc::CallSettings,gaxgrpc::BidirectionalStreamingSettings)"/>.
        /// </summary>
        public abstract partial class BidiStreamingAutoPopulatedStream : gaxgrpc::BidirectionalStreamingBase<Request, Response>
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public virtual BidiStreamingAutoPopulatedStream BidiStreamingAutoPopulated(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<Response, Response> LroAutoPopulated(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<Response, Response>> LroAutoPopulatedAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<Response, Response>> LroAutoPopulatedAsync(Request request, st::CancellationToken cancellationToken) =>
            LroAutoPopulatedAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>LroAutoPopulated</c>.</summary>
        public virtual lro::OperationsClient LroAutoPopulatedOperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of <c>LroAutoPopulated</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<Response, Response> PollOnceLroAutoPopulated(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<Response, Response>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), LroAutoPopulatedOperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>LroAutoPopulated</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<Response, Response>> PollOnceLroAutoPopulatedAsync(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<Response, Response>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), LroAutoPopulatedOperationsClient, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response"/> resources.</returns>
        public virtual gax::PagedEnumerable<PaginatedResponse, Response> PaginatedAutoPopulated(PaginatedRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<PaginatedResponse, Response> PaginatedAutoPopulatedAsync(PaginatedRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();
    }

    /// <summary>ServiceWithMethodSettings client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// This is a service with method settings in the service config.
    /// </remarks>
    public sealed partial class ServiceWithMethodSettingsClientImpl : ServiceWithMethodSettingsClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callUnaryAutoPopulated;

        private readonly gaxgrpc::ApiServerStreamingCall<Request, Response> _callServerStreamingAutoPopulated;

        private readonly gaxgrpc::ApiClientStreamingCall<Request, Response> _callClientStreamingAutoPopulated;

        private readonly gaxgrpc::ApiBidirectionalStreamingCall<Request, Response> _callBidiStreamingAutoPopulated;

        private readonly gaxgrpc::ApiCall<Request, lro::Operation> _callLroAutoPopulated;

        private readonly gaxgrpc::ApiCall<PaginatedRequest, PaginatedResponse> _callPaginatedAutoPopulated;

        /// <summary>
        /// Constructs a client wrapper for the ServiceWithMethodSettings service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="ServiceWithMethodSettingsSettings"/> used within this client.
        /// </param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public ServiceWithMethodSettingsClientImpl(ServiceWithMethodSettings.ServiceWithMethodSettingsClient grpcClient, ServiceWithMethodSettingsSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            ServiceWithMethodSettingsSettings effectiveSettings = settings ?? ServiceWithMethodSettingsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            LroAutoPopulatedOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.LroAutoPopulatedOperationsSettings, logger);
            _callUnaryAutoPopulated = clientHelper.BuildApiCall<Request, Response>("UnaryAutoPopulated", grpcClient.UnaryAutoPopulatedAsync, grpcClient.UnaryAutoPopulated, effectiveSettings.UnaryAutoPopulatedSettings);
            Modify_ApiCall(ref _callUnaryAutoPopulated);
            Modify_UnaryAutoPopulatedApiCall(ref _callUnaryAutoPopulated);
            _callServerStreamingAutoPopulated = clientHelper.BuildApiCall<Request, Response>("ServerStreamingAutoPopulated", grpcClient.ServerStreamingAutoPopulated, effectiveSettings.ServerStreamingAutoPopulatedSettings);
            Modify_ApiCall(ref _callServerStreamingAutoPopulated);
            Modify_ServerStreamingAutoPopulatedApiCall(ref _callServerStreamingAutoPopulated);
            _callClientStreamingAutoPopulated = clientHelper.BuildApiCall<Request, Response>("ClientStreamingAutoPopulated", grpcClient.ClientStreamingAutoPopulated, effectiveSettings.ClientStreamingAutoPopulatedSettings, effectiveSettings.ClientStreamingAutoPopulatedStreamingSettings);
            Modify_ApiCall(ref _callClientStreamingAutoPopulated);
            Modify_ClientStreamingAutoPopulatedApiCall(ref _callClientStreamingAutoPopulated);
            _callBidiStreamingAutoPopulated = clientHelper.BuildApiCall<Request, Response>("BidiStreamingAutoPopulated", grpcClient.BidiStreamingAutoPopulated, effectiveSettings.BidiStreamingAutoPopulatedSettings, effectiveSettings.BidiStreamingAutoPopulatedStreamingSettings);
            Modify_ApiCall(ref _callBidiStreamingAutoPopulated);
            Modify_BidiStreamingAutoPopulatedApiCall(ref _callBidiStreamingAutoPopulated);
            _callLroAutoPopulated = clientHelper.BuildApiCall<Request, lro::Operation>("LroAutoPopulated", grpcClient.LroAutoPopulatedAsync, grpcClient.LroAutoPopulated, effectiveSettings.LroAutoPopulatedSettings);
            Modify_ApiCall(ref _callLroAutoPopulated);
            Modify_LroAutoPopulatedApiCall(ref _callLroAutoPopulated);
            _callPaginatedAutoPopulated = clientHelper.BuildApiCall<PaginatedRequest, PaginatedResponse>("PaginatedAutoPopulated", grpcClient.PaginatedAutoPopulatedAsync, grpcClient.PaginatedAutoPopulated, effectiveSettings.PaginatedAutoPopulatedSettings);
            Modify_ApiCall(ref _callPaginatedAutoPopulated);
            Modify_PaginatedAutoPopulatedApiCall(ref _callPaginatedAutoPopulated);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiBidirectionalStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiServerStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiClientStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_UnaryAutoPopulatedApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void Modify_ServerStreamingAutoPopulatedApiCall(ref gaxgrpc::ApiServerStreamingCall<Request, Response> call);

        partial void Modify_ClientStreamingAutoPopulatedApiCall(ref gaxgrpc::ApiClientStreamingCall<Request, Response> call);

        partial void Modify_BidiStreamingAutoPopulatedApiCall(ref gaxgrpc::ApiBidirectionalStreamingCall<Request, Response> call);

        partial void Modify_LroAutoPopulatedApiCall(ref gaxgrpc::ApiCall<Request, lro::Operation> call);

        partial void Modify_PaginatedAutoPopulatedApiCall(ref gaxgrpc::ApiCall<PaginatedRequest, PaginatedResponse> call);

        partial void OnConstruction(ServiceWithMethodSettings.ServiceWithMethodSettingsClient grpcClient, ServiceWithMethodSettingsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC ServiceWithMethodSettings client</summary>
        public override ServiceWithMethodSettings.ServiceWithMethodSettingsClient GrpcClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RequestCallSettings(ref gaxgrpc::CallSettings settings);

        partial void Modify_RequestRequest(ref Request request);

        partial void Modify_PaginatedRequest(ref PaginatedRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response UnaryAutoPopulated(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callUnaryAutoPopulated.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> UnaryAutoPopulatedAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callUnaryAutoPopulated.Async(request, callSettings);
        }

        internal sealed partial class ServerStreamingAutoPopulatedStreamImpl : ServerStreamingAutoPopulatedStream
        {
            /// <summary>Construct the server streaming method for <c>ServerStreamingAutoPopulated</c>.</summary>
            /// <param name="call">The underlying gRPC server streaming call.</param>
            public ServerStreamingAutoPopulatedStreamImpl(grpccore::AsyncServerStreamingCall<Response> call) => GrpcCall = call;

            public override grpccore::AsyncServerStreamingCall<Response> GrpcCall { get; }
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public override ServiceWithMethodSettingsClient.ServerStreamingAutoPopulatedStream ServerStreamingAutoPopulated(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new ServerStreamingAutoPopulatedStreamImpl(_callServerStreamingAutoPopulated.Call(request, callSettings));
        }

        internal sealed partial class ClientStreamingAutoPopulatedStreamImpl : ClientStreamingAutoPopulatedStream
        {
            /// <summary>Construct the client streaming method for <c>ClientStreamingAutoPopulated</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC client streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{Request}"/> instance associated with this streaming
            /// call.
            /// </param>
            public ClientStreamingAutoPopulatedStreamImpl(ServiceWithMethodSettingsClientImpl service, grpccore::AsyncClientStreamingCall<Request, Response> call, gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private ServiceWithMethodSettingsClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<Request> _writeBuffer;

            public override grpccore::AsyncClientStreamingCall<Request, Response> GrpcCall { get; }

            private Request ModifyRequest(Request request)
            {
                _service.Modify_RequestRequest(ref request);
                return request;
            }

            public override stt::Task TryWriteAsync(Request message) => _writeBuffer.TryWriteAsync(ModifyRequest(message));

            public override stt::Task WriteAsync(Request message) => _writeBuffer.WriteAsync(ModifyRequest(message));

            public override stt::Task TryWriteAsync(Request message, grpccore::WriteOptions options) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message), options);

            public override stt::Task WriteAsync(Request message, grpccore::WriteOptions options) =>
                _writeBuffer.WriteAsync(ModifyRequest(message), options);

            public override stt::Task TryWriteCompleteAsync() => _writeBuffer.TryWriteCompleteAsync();

            public override stt::Task WriteCompleteAsync() => _writeBuffer.WriteCompleteAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public override ServiceWithMethodSettingsClient.ClientStreamingAutoPopulatedStream ClientStreamingAutoPopulated(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null)
        {
            Modify_RequestCallSettings(ref callSettings);
            gaxgrpc::ClientStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callClientStreamingAutoPopulated.StreamingSettings;
            grpccore::AsyncClientStreamingCall<Request, Response> call = _callClientStreamingAutoPopulated.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<Request>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new ClientStreamingAutoPopulatedStreamImpl(this, call, writeBuffer);
        }

        internal sealed partial class BidiStreamingAutoPopulatedStreamImpl : BidiStreamingAutoPopulatedStream
        {
            /// <summary>Construct the bidirectional streaming method for <c>BidiStreamingAutoPopulated</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC duplex streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{Request}"/> instance associated with this streaming
            /// call.
            /// </param>
            public BidiStreamingAutoPopulatedStreamImpl(ServiceWithMethodSettingsClientImpl service, grpccore::AsyncDuplexStreamingCall<Request, Response> call, gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private ServiceWithMethodSettingsClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<Request> _writeBuffer;

            public override grpccore::AsyncDuplexStreamingCall<Request, Response> GrpcCall { get; }

            private Request ModifyRequest(Request request)
            {
                _service.Modify_RequestRequest(ref request);
                return request;
            }

            public override stt::Task TryWriteAsync(Request message) => _writeBuffer.TryWriteAsync(ModifyRequest(message));

            public override stt::Task WriteAsync(Request message) => _writeBuffer.WriteAsync(ModifyRequest(message));

            public override stt::Task TryWriteAsync(Request message, grpccore::WriteOptions options) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message), options);

            public override stt::Task WriteAsync(Request message, grpccore::WriteOptions options) =>
                _writeBuffer.WriteAsync(ModifyRequest(message), options);

            public override stt::Task TryWriteCompleteAsync() => _writeBuffer.TryWriteCompleteAsync();

            public override stt::Task WriteCompleteAsync() => _writeBuffer.WriteCompleteAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public override ServiceWithMethodSettingsClient.BidiStreamingAutoPopulatedStream BidiStreamingAutoPopulated(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null)
        {
            Modify_RequestCallSettings(ref callSettings);
            gaxgrpc::BidirectionalStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callBidiStreamingAutoPopulated.StreamingSettings;
            grpccore::AsyncDuplexStreamingCall<Request, Response> call = _callBidiStreamingAutoPopulated.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<Request>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new BidiStreamingAutoPopulatedStreamImpl(this, call, writeBuffer);
        }

        /// <summary>The long-running operations client for <c>LroAutoPopulated</c>.</summary>
        public override lro::OperationsClient LroAutoPopulatedOperationsClient { get; }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<Response, Response> LroAutoPopulated(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<Response, Response>(_callLroAutoPopulated.Sync(request, callSettings), LroAutoPopulatedOperationsClient);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<Response, Response>> LroAutoPopulatedAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<Response, Response>(await _callLroAutoPopulated.Async(request, callSettings).ConfigureAwait(false), LroAutoPopulatedOperationsClient);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response"/> resources.</returns>
        public override gax::PagedEnumerable<PaginatedResponse, Response> PaginatedAutoPopulated(PaginatedRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PaginatedRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<PaginatedRequest, PaginatedResponse, Response>(_callPaginatedAutoPopulated, request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<PaginatedResponse, Response> PaginatedAutoPopulatedAsync(PaginatedRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PaginatedRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<PaginatedRequest, PaginatedResponse, Response>(_callPaginatedAutoPopulated, request, callSettings);
        }
    }

    public partial class PaginatedRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class PaginatedResponse : gaxgrpc::IPageResponse<Response>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<Response> GetEnumerator() => Responses.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static partial class ServiceWithMethodSettings
    {
        public partial class ServiceWithMethodSettingsClient
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
}
