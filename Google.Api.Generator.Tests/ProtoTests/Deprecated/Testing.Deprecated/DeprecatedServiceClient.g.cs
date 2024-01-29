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
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.Deprecated
{
    /// <summary>Settings for <see cref="DeprecatedServiceClient"/> instances.</summary>
    public sealed partial class DeprecatedServiceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="DeprecatedServiceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="DeprecatedServiceSettings"/>.</returns>
        public static DeprecatedServiceSettings GetDefault() => new DeprecatedServiceSettings();

        /// <summary>Constructs a new <see cref="DeprecatedServiceSettings"/> object with default settings.</summary>
        public DeprecatedServiceSettings()
        {
        }

        private DeprecatedServiceSettings(DeprecatedServiceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            NonDeprecatedMethodSettings = existing.NonDeprecatedMethodSettings;
            DeprecatedMethodSettings = existing.DeprecatedMethodSettings;
            OnCopy(existing);
        }

        partial void OnCopy(DeprecatedServiceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DeprecatedServiceClient.NonDeprecatedMethod</c> and <c>DeprecatedServiceClient.NonDeprecatedMethodAsync</c>
        /// .
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings NonDeprecatedMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DeprecatedServiceClient.DeprecatedMethod</c> and <c>DeprecatedServiceClient.DeprecatedMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeprecatedMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="DeprecatedServiceSettings"/> object.</returns>
        public DeprecatedServiceSettings Clone() => new DeprecatedServiceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="DeprecatedServiceClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class DeprecatedServiceClientBuilder : gaxgrpc::ClientBuilderBase<DeprecatedServiceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public DeprecatedServiceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public DeprecatedServiceClientBuilder() : base(DeprecatedServiceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref DeprecatedServiceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<DeprecatedServiceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override DeprecatedServiceClient Build()
        {
            DeprecatedServiceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<DeprecatedServiceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<DeprecatedServiceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private DeprecatedServiceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return DeprecatedServiceClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<DeprecatedServiceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return DeprecatedServiceClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => DeprecatedServiceClient.ChannelPool;
    }

    /// <summary>DeprecatedService client wrapper, for convenient use.</summary>
    /// <remarks>
    /// A whole service that's deprecated this time. One RPC which is explicitly
    /// deprecated, and another that isn't.
    /// </remarks>
    public abstract partial class DeprecatedServiceClient
    {
        /// <summary>
        /// The default endpoint for the DeprecatedService service, which is a host of "deprecated.example.com" and a
        /// port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "deprecated.example.com:443";

        /// <summary>The default DeprecatedService scopes.</summary>
        /// <remarks>The default DeprecatedService scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(DeprecatedService.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="DeprecatedServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="DeprecatedServiceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="DeprecatedServiceClient"/>.</returns>
        public static stt::Task<DeprecatedServiceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new DeprecatedServiceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="DeprecatedServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="DeprecatedServiceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="DeprecatedServiceClient"/>.</returns>
        public static DeprecatedServiceClient Create() => new DeprecatedServiceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="DeprecatedServiceClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="DeprecatedServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="DeprecatedServiceClient"/>.</returns>
        internal static DeprecatedServiceClient Create(grpccore::CallInvoker callInvoker, DeprecatedServiceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            DeprecatedService.DeprecatedServiceClient grpcClient = new DeprecatedService.DeprecatedServiceClient(callInvoker);
            return new DeprecatedServiceClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC DeprecatedService client</summary>
        public virtual DeprecatedService.DeprecatedServiceClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response NonDeprecatedMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NonDeprecatedMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NonDeprecatedMethodAsync(Request request, st::CancellationToken cancellationToken) =>
            NonDeprecatedMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual Response DeprecatedMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedMethodAsync(Request request, st::CancellationToken cancellationToken) =>
            DeprecatedMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>DeprecatedService client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// A whole service that's deprecated this time. One RPC which is explicitly
    /// deprecated, and another that isn't.
    /// </remarks>
    public sealed partial class DeprecatedServiceClientImpl : DeprecatedServiceClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callNonDeprecatedMethod;

        private readonly gaxgrpc::ApiCall<Request, Response> _callDeprecatedMethod;

        /// <summary>
        /// Constructs a client wrapper for the DeprecatedService service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="DeprecatedServiceSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public DeprecatedServiceClientImpl(DeprecatedService.DeprecatedServiceClient grpcClient, DeprecatedServiceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            DeprecatedServiceSettings effectiveSettings = settings ?? DeprecatedServiceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callNonDeprecatedMethod = clientHelper.BuildApiCall<Request, Response>("NonDeprecatedMethod", grpcClient.NonDeprecatedMethodAsync, grpcClient.NonDeprecatedMethod, effectiveSettings.NonDeprecatedMethodSettings);
            Modify_ApiCall(ref _callNonDeprecatedMethod);
            Modify_NonDeprecatedMethodApiCall(ref _callNonDeprecatedMethod);
#pragma warning disable CS0612
            _callDeprecatedMethod = clientHelper.BuildApiCall<Request, Response>("DeprecatedMethod", grpcClient.DeprecatedMethodAsync, grpcClient.DeprecatedMethod, effectiveSettings.DeprecatedMethodSettings);
#pragma warning restore CS0612
            Modify_ApiCall(ref _callDeprecatedMethod);
            Modify_DeprecatedMethodApiCall(ref _callDeprecatedMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_NonDeprecatedMethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void Modify_DeprecatedMethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void OnConstruction(DeprecatedService.DeprecatedServiceClient grpcClient, DeprecatedServiceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC DeprecatedService client</summary>
        public override DeprecatedService.DeprecatedServiceClient GrpcClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response NonDeprecatedMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callNonDeprecatedMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> NonDeprecatedMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callNonDeprecatedMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
        public override Response DeprecatedMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callDeprecatedMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public override stt::Task<Response> DeprecatedMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callDeprecatedMethod.Async(request, callSettings);
        }
    }
}
