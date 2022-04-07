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
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.Deprecated
{
    /// <summary>Settings for <see cref="DeprecatedClient"/> instances.</summary>
    public sealed partial class DeprecatedSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="DeprecatedSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="DeprecatedSettings"/>.</returns>
        public static DeprecatedSettings GetDefault() => new DeprecatedSettings();

        /// <summary>Constructs a new <see cref="DeprecatedSettings"/> object with default settings.</summary>
        public DeprecatedSettings()
        {
        }

        private DeprecatedSettings(DeprecatedSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeprecatedFieldMethodSettings = existing.DeprecatedFieldMethodSettings;
            DeprecatedMessageMethodSettings = existing.DeprecatedMessageMethodSettings;
            DeprecatedMethodSettings = existing.DeprecatedMethodSettings;
            DeprecatedResponseMethodSettings = existing.DeprecatedResponseMethodSettings;
            OnCopy(existing);
        }

        partial void OnCopy(DeprecatedSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DeprecatedClient.DeprecatedFieldMethod</c> and <c>DeprecatedClient.DeprecatedFieldMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeprecatedFieldMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DeprecatedClient.DeprecatedMessageMethod</c> and <c>DeprecatedClient.DeprecatedMessageMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeprecatedMessageMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DeprecatedClient.DeprecatedMethod</c> and <c>DeprecatedClient.DeprecatedMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeprecatedMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>DeprecatedClient.DeprecatedResponseMethod</c> and <c>DeprecatedClient.DeprecatedResponseMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeprecatedResponseMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="DeprecatedSettings"/> object.</returns>
        public DeprecatedSettings Clone() => new DeprecatedSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="DeprecatedClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class DeprecatedClientBuilder : gaxgrpc::ClientBuilderBase<DeprecatedClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public DeprecatedSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public DeprecatedClientBuilder() : base(DeprecatedClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref DeprecatedClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<DeprecatedClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override DeprecatedClient Build()
        {
            DeprecatedClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<DeprecatedClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<DeprecatedClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private DeprecatedClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return DeprecatedClient.Create(callInvoker, Settings);
        }

        private async stt::Task<DeprecatedClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return DeprecatedClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => DeprecatedClient.ChannelPool;
    }

    /// <summary>Deprecated client wrapper, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public abstract partial class DeprecatedClient
    {
        /// <summary>
        /// The default endpoint for the Deprecated service, which is a host of "deprecated.example.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "deprecated.example.com:443";

        /// <summary>The default Deprecated scopes.</summary>
        /// <remarks>The default Deprecated scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        internal static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Deprecated.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="DeprecatedClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="DeprecatedClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="DeprecatedClient"/>.</returns>
        public static stt::Task<DeprecatedClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new DeprecatedClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="DeprecatedClient"/> using the default credentials, endpoint and settings.
        /// To specify custom credentials or other settings, use <see cref="DeprecatedClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="DeprecatedClient"/>.</returns>
        public static DeprecatedClient Create() => new DeprecatedClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="DeprecatedClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="DeprecatedSettings"/>.</param>
        /// <returns>The created <see cref="DeprecatedClient"/>.</returns>
        internal static DeprecatedClient Create(grpccore::CallInvoker callInvoker, DeprecatedSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Deprecated.DeprecatedClient grpcClient = new Deprecated.DeprecatedClient(callInvoker);
            return new DeprecatedClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC Deprecated client</summary>
        public virtual Deprecated.DeprecatedClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response DeprecatedFieldMethod(DeprecatedFieldRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> DeprecatedFieldMethodAsync(DeprecatedFieldRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> DeprecatedFieldMethodAsync(DeprecatedFieldRequest request, st::CancellationToken cancellationToken) =>
            DeprecatedFieldMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="deprecatedField1">
        /// </param>
        /// <param name="deprecatedField2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual Response DeprecatedFieldMethod(string deprecatedField1, string deprecatedField2, gaxgrpc::CallSettings callSettings = null) =>
            DeprecatedFieldMethod(new DeprecatedFieldRequest
            {
                DeprecatedField1 = deprecatedField1 ?? "",
                DeprecatedField2 = deprecatedField2 ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="deprecatedField1">
        /// </param>
        /// <param name="deprecatedField2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedFieldMethodAsync(string deprecatedField1, string deprecatedField2, gaxgrpc::CallSettings callSettings = null) =>
            DeprecatedFieldMethodAsync(new DeprecatedFieldRequest
            {
                DeprecatedField1 = deprecatedField1 ?? "",
                DeprecatedField2 = deprecatedField2 ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="deprecatedField1">
        /// </param>
        /// <param name="deprecatedField2">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedFieldMethodAsync(string deprecatedField1, string deprecatedField2, st::CancellationToken cancellationToken) =>
            DeprecatedFieldMethodAsync(deprecatedField1, deprecatedField2, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public virtual Response DeprecatedMessageMethod(DeprecatedMessageRequest request, gaxgrpc::CallSettings callSettings = null) =>
#pragma warning restore CS0612
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public virtual stt::Task<Response> DeprecatedMessageMethodAsync(DeprecatedMessageRequest request, gaxgrpc::CallSettings callSettings = null) =>
#pragma warning restore CS0612
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public virtual stt::Task<Response> DeprecatedMessageMethodAsync(DeprecatedMessageRequest request, st::CancellationToken cancellationToken) =>
#pragma warning restore CS0612
            DeprecatedMessageMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

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

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public virtual DeprecatedMessageResponse DeprecatedResponseMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
#pragma warning restore CS0612
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public virtual stt::Task<DeprecatedMessageResponse> DeprecatedResponseMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
#pragma warning restore CS0612
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public virtual stt::Task<DeprecatedMessageResponse> DeprecatedResponseMethodAsync(Request request, st::CancellationToken cancellationToken) =>
#pragma warning restore CS0612
            DeprecatedResponseMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Deprecated client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class DeprecatedClientImpl : DeprecatedClient
    {
        private readonly gaxgrpc::ApiCall<DeprecatedFieldRequest, Response> _callDeprecatedFieldMethod;

#pragma warning disable CS0612
        private readonly gaxgrpc::ApiCall<DeprecatedMessageRequest, Response> _callDeprecatedMessageMethod;
#pragma warning restore CS0612

        private readonly gaxgrpc::ApiCall<Request, Response> _callDeprecatedMethod;

#pragma warning disable CS0612
        private readonly gaxgrpc::ApiCall<Request, DeprecatedMessageResponse> _callDeprecatedResponseMethod;
#pragma warning restore CS0612

        /// <summary>
        /// Constructs a client wrapper for the Deprecated service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="DeprecatedSettings"/> used within this client.</param>
        public DeprecatedClientImpl(Deprecated.DeprecatedClient grpcClient, DeprecatedSettings settings)
        {
            GrpcClient = grpcClient;
            DeprecatedSettings effectiveSettings = settings ?? DeprecatedSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDeprecatedFieldMethod = clientHelper.BuildApiCall<DeprecatedFieldRequest, Response>(grpcClient.DeprecatedFieldMethodAsync, grpcClient.DeprecatedFieldMethod, effectiveSettings.DeprecatedFieldMethodSettings);
            Modify_ApiCall(ref _callDeprecatedFieldMethod);
            Modify_DeprecatedFieldMethodApiCall(ref _callDeprecatedFieldMethod);
#pragma warning disable CS0612
            _callDeprecatedMessageMethod = clientHelper.BuildApiCall<DeprecatedMessageRequest, Response>(grpcClient.DeprecatedMessageMethodAsync, grpcClient.DeprecatedMessageMethod, effectiveSettings.DeprecatedMessageMethodSettings);
#pragma warning restore CS0612
            Modify_ApiCall(ref _callDeprecatedMessageMethod);
            Modify_DeprecatedMessageMethodApiCall(ref _callDeprecatedMessageMethod);
#pragma warning disable CS0612
            _callDeprecatedMethod = clientHelper.BuildApiCall<Request, Response>(grpcClient.DeprecatedMethodAsync, grpcClient.DeprecatedMethod, effectiveSettings.DeprecatedMethodSettings);
#pragma warning restore CS0612
            Modify_ApiCall(ref _callDeprecatedMethod);
            Modify_DeprecatedMethodApiCall(ref _callDeprecatedMethod);
#pragma warning disable CS0612
            _callDeprecatedResponseMethod = clientHelper.BuildApiCall<Request, DeprecatedMessageResponse>(grpcClient.DeprecatedResponseMethodAsync, grpcClient.DeprecatedResponseMethod, effectiveSettings.DeprecatedResponseMethodSettings);
#pragma warning restore CS0612
            Modify_ApiCall(ref _callDeprecatedResponseMethod);
            Modify_DeprecatedResponseMethodApiCall(ref _callDeprecatedResponseMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeprecatedFieldMethodApiCall(ref gaxgrpc::ApiCall<DeprecatedFieldRequest, Response> call);

#pragma warning disable CS0612
        partial void Modify_DeprecatedMessageMethodApiCall(ref gaxgrpc::ApiCall<DeprecatedMessageRequest, Response> call);
#pragma warning restore CS0612

        partial void Modify_DeprecatedMethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

#pragma warning disable CS0612
        partial void Modify_DeprecatedResponseMethodApiCall(ref gaxgrpc::ApiCall<Request, DeprecatedMessageResponse> call);
#pragma warning restore CS0612

        partial void OnConstruction(Deprecated.DeprecatedClient grpcClient, DeprecatedSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Deprecated client</summary>
        public override Deprecated.DeprecatedClient GrpcClient { get; }

        partial void Modify_DeprecatedFieldRequest(ref DeprecatedFieldRequest request, ref gaxgrpc::CallSettings settings);

#pragma warning disable CS0612
        partial void Modify_DeprecatedMessageRequest(ref DeprecatedMessageRequest request, ref gaxgrpc::CallSettings settings);
#pragma warning restore CS0612

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response DeprecatedFieldMethod(DeprecatedFieldRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeprecatedFieldRequest(ref request, ref callSettings);
            return _callDeprecatedFieldMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> DeprecatedFieldMethodAsync(DeprecatedFieldRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeprecatedFieldRequest(ref request, ref callSettings);
            return _callDeprecatedFieldMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public override Response DeprecatedMessageMethod(DeprecatedMessageRequest request, gaxgrpc::CallSettings callSettings = null)
#pragma warning restore CS0612
        {
            Modify_DeprecatedMessageRequest(ref request, ref callSettings);
            return _callDeprecatedMessageMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public override stt::Task<Response> DeprecatedMessageMethodAsync(DeprecatedMessageRequest request, gaxgrpc::CallSettings callSettings = null)
#pragma warning restore CS0612
        {
            Modify_DeprecatedMessageRequest(ref request, ref callSettings);
            return _callDeprecatedMessageMethod.Async(request, callSettings);
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

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public override DeprecatedMessageResponse DeprecatedResponseMethod(Request request, gaxgrpc::CallSettings callSettings = null)
#pragma warning restore CS0612
        {
            Modify_Request(ref request, ref callSettings);
            return _callDeprecatedResponseMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
#pragma warning disable CS0612
        public override stt::Task<DeprecatedMessageResponse> DeprecatedResponseMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
#pragma warning restore CS0612
        {
            Modify_Request(ref request, ref callSettings);
            return _callDeprecatedResponseMethod.Async(request, callSettings);
        }
    }
}
