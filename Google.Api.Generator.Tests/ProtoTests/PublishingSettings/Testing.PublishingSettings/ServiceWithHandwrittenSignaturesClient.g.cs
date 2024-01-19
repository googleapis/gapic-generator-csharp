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

namespace Testing.PublishingSettings
{
    /// <summary>Settings for <see cref="ServiceWithHandwrittenSignaturesClient"/> instances.</summary>
    public sealed partial class ServiceWithHandwrittenSignaturesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="ServiceWithHandwrittenSignaturesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="ServiceWithHandwrittenSignaturesSettings"/>.</returns>
        public static ServiceWithHandwrittenSignaturesSettings GetDefault() => new ServiceWithHandwrittenSignaturesSettings();

        /// <summary>
        /// Constructs a new <see cref="ServiceWithHandwrittenSignaturesSettings"/> object with default settings.
        /// </summary>
        public ServiceWithHandwrittenSignaturesSettings()
        {
        }

        private ServiceWithHandwrittenSignaturesSettings(ServiceWithHandwrittenSignaturesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AMethodSettings = existing.AMethodSettings;
            OnCopy(existing);
        }

        partial void OnCopy(ServiceWithHandwrittenSignaturesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithHandwrittenSignaturesClient.AMethod</c> and
        /// <c>ServiceWithHandwrittenSignaturesClient.AMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="ServiceWithHandwrittenSignaturesSettings"/> object.</returns>
        public ServiceWithHandwrittenSignaturesSettings Clone() => new ServiceWithHandwrittenSignaturesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="ServiceWithHandwrittenSignaturesClient"/> to provide simple configuration of
    /// credentials, endpoint etc.
    /// </summary>
    public sealed partial class ServiceWithHandwrittenSignaturesClientBuilder : gaxgrpc::ClientBuilderBase<ServiceWithHandwrittenSignaturesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public ServiceWithHandwrittenSignaturesSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public ServiceWithHandwrittenSignaturesClientBuilder() : base(ServiceWithHandwrittenSignaturesClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref ServiceWithHandwrittenSignaturesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<ServiceWithHandwrittenSignaturesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override ServiceWithHandwrittenSignaturesClient Build()
        {
            ServiceWithHandwrittenSignaturesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<ServiceWithHandwrittenSignaturesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<ServiceWithHandwrittenSignaturesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private ServiceWithHandwrittenSignaturesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return ServiceWithHandwrittenSignaturesClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<ServiceWithHandwrittenSignaturesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return ServiceWithHandwrittenSignaturesClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => ServiceWithHandwrittenSignaturesClient.ChannelPool;
    }

    /// <summary>ServiceWithHandwrittenSignatures client wrapper, for convenient use.</summary>
    /// <remarks>
    /// This is a service with a handwritten signature.
    /// </remarks>
    public abstract partial class ServiceWithHandwrittenSignaturesClient
    {
        /// <summary>
        /// The default endpoint for the ServiceWithHandwrittenSignatures service, which is a host of "" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = ":443";

        /// <summary>The default ServiceWithHandwrittenSignatures scopes.</summary>
        /// <remarks>The default ServiceWithHandwrittenSignatures scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(ServiceWithHandwrittenSignatures.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="ServiceWithHandwrittenSignaturesClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="ServiceWithHandwrittenSignaturesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="ServiceWithHandwrittenSignaturesClient"/>.</returns>
        public static stt::Task<ServiceWithHandwrittenSignaturesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new ServiceWithHandwrittenSignaturesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="ServiceWithHandwrittenSignaturesClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="ServiceWithHandwrittenSignaturesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="ServiceWithHandwrittenSignaturesClient"/>.</returns>
        public static ServiceWithHandwrittenSignaturesClient Create() =>
            new ServiceWithHandwrittenSignaturesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="ServiceWithHandwrittenSignaturesClient"/> which uses the specified call invoker for
        /// remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="ServiceWithHandwrittenSignaturesSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="ServiceWithHandwrittenSignaturesClient"/>.</returns>
        internal static ServiceWithHandwrittenSignaturesClient Create(grpccore::CallInvoker callInvoker, ServiceWithHandwrittenSignaturesSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            ServiceWithHandwrittenSignatures.ServiceWithHandwrittenSignaturesClient grpcClient = new ServiceWithHandwrittenSignatures.ServiceWithHandwrittenSignaturesClient(callInvoker);
            return new ServiceWithHandwrittenSignaturesClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC ServiceWithHandwrittenSignatures client</summary>
        public virtual ServiceWithHandwrittenSignatures.ServiceWithHandwrittenSignaturesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response AMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> AMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> AMethodAsync(Request request, st::CancellationToken cancellationToken) =>
            AMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="string1">
        /// </param>
        /// <param name="string2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response AMethod(string string1, string string2, gaxgrpc::CallSettings callSettings = null) =>
            AMethod(new Request
            {
                String1 = string1 ?? "",
                String2 = string2 ?? "",
            }, callSettings);

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="string1">
        /// </param>
        /// <param name="string2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> AMethodAsync(string string1, string string2, gaxgrpc::CallSettings callSettings = null) =>
            AMethodAsync(new Request
            {
                String1 = string1 ?? "",
                String2 = string2 ?? "",
            }, callSettings);

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="string1">
        /// </param>
        /// <param name="string2">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> AMethodAsync(string string1, string string2, st::CancellationToken cancellationToken) =>
            AMethodAsync(string1, string2, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>ServiceWithHandwrittenSignatures client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// This is a service with a handwritten signature.
    /// </remarks>
    public sealed partial class ServiceWithHandwrittenSignaturesClientImpl : ServiceWithHandwrittenSignaturesClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callAMethod;

        /// <summary>
        /// Constructs a client wrapper for the ServiceWithHandwrittenSignatures service, with the specified gRPC client
        /// and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="ServiceWithHandwrittenSignaturesSettings"/> used within this client.
        /// </param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public ServiceWithHandwrittenSignaturesClientImpl(ServiceWithHandwrittenSignatures.ServiceWithHandwrittenSignaturesClient grpcClient, ServiceWithHandwrittenSignaturesSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            ServiceWithHandwrittenSignaturesSettings effectiveSettings = settings ?? ServiceWithHandwrittenSignaturesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callAMethod = clientHelper.BuildApiCall<Request, Response>("AMethod", grpcClient.AMethodAsync, grpcClient.AMethod, effectiveSettings.AMethodSettings);
            Modify_ApiCall(ref _callAMethod);
            Modify_AMethodApiCall(ref _callAMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AMethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void OnConstruction(ServiceWithHandwrittenSignatures.ServiceWithHandwrittenSignaturesClient grpcClient, ServiceWithHandwrittenSignaturesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC ServiceWithHandwrittenSignatures client</summary>
        public override ServiceWithHandwrittenSignatures.ServiceWithHandwrittenSignaturesClient GrpcClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response AMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callAMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> AMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callAMethod.Async(request, callSettings);
        }
    }
}
