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
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.PublishingSettings
{
    /// <summary>Settings for <see cref="ServiceWithResourcesClient"/> instances.</summary>
    public sealed partial class ServiceWithResourcesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="ServiceWithResourcesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="ServiceWithResourcesSettings"/>.</returns>
        public static ServiceWithResourcesSettings GetDefault() => new ServiceWithResourcesSettings();

        /// <summary>Constructs a new <see cref="ServiceWithResourcesSettings"/> object with default settings.</summary>
        public ServiceWithResourcesSettings()
        {
        }

        private ServiceWithResourcesSettings(ServiceWithResourcesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AMethodSettings = existing.AMethodSettings;
            OnCopy(existing);
        }

        partial void OnCopy(ServiceWithResourcesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ServiceWithResourcesClient.AMethod</c> and <c>ServiceWithResourcesClient.AMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="ServiceWithResourcesSettings"/> object.</returns>
        public ServiceWithResourcesSettings Clone() => new ServiceWithResourcesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="ServiceWithResourcesClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class ServiceWithResourcesClientBuilder : gaxgrpc::ClientBuilderBase<ServiceWithResourcesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public ServiceWithResourcesSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public ServiceWithResourcesClientBuilder() : base(ServiceWithResourcesClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref ServiceWithResourcesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<ServiceWithResourcesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override ServiceWithResourcesClient Build()
        {
            ServiceWithResourcesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<ServiceWithResourcesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<ServiceWithResourcesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private ServiceWithResourcesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return ServiceWithResourcesClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<ServiceWithResourcesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return ServiceWithResourcesClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => ServiceWithResourcesClient.ChannelPool;
    }

    /// <summary>ServiceWithResources client wrapper, for convenient use.</summary>
    /// <remarks>
    /// This is a service using resources.
    /// </remarks>
    public abstract partial class ServiceWithResourcesClient
    {
        /// <summary>
        /// The default endpoint for the ServiceWithResources service, which is a host of "" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = ":443";

        /// <summary>The default ServiceWithResources scopes.</summary>
        /// <remarks>The default ServiceWithResources scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(ServiceWithResources.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="ServiceWithResourcesClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="ServiceWithResourcesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="ServiceWithResourcesClient"/>.</returns>
        public static stt::Task<ServiceWithResourcesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new ServiceWithResourcesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="ServiceWithResourcesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use
        /// <see cref="ServiceWithResourcesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="ServiceWithResourcesClient"/>.</returns>
        public static ServiceWithResourcesClient Create() => new ServiceWithResourcesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="ServiceWithResourcesClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="ServiceWithResourcesSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="ServiceWithResourcesClient"/>.</returns>
        internal static ServiceWithResourcesClient Create(grpccore::CallInvoker callInvoker, ServiceWithResourcesSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            ServiceWithResources.ServiceWithResourcesClient grpcClient = new ServiceWithResources.ServiceWithResourcesClient(callInvoker);
            return new ServiceWithResourcesClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC ServiceWithResources client</summary>
        public virtual ServiceWithResources.ServiceWithResourcesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Resource AMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Resource> AMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Resource> AMethodAsync(ResourceRequest request, st::CancellationToken cancellationToken) =>
            AMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>ServiceWithResources client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// This is a service using resources.
    /// </remarks>
    public sealed partial class ServiceWithResourcesClientImpl : ServiceWithResourcesClient
    {
        private readonly gaxgrpc::ApiCall<ResourceRequest, Resource> _callAMethod;

        /// <summary>
        /// Constructs a client wrapper for the ServiceWithResources service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="ServiceWithResourcesSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public ServiceWithResourcesClientImpl(ServiceWithResources.ServiceWithResourcesClient grpcClient, ServiceWithResourcesSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            ServiceWithResourcesSettings effectiveSettings = settings ?? ServiceWithResourcesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(new gaxgrpc::ClientHelper.Options
            {
                Settings = effectiveSettings,
                Logger = logger,
            });
            _callAMethod = clientHelper.BuildApiCall<ResourceRequest, Resource>("AMethod", grpcClient.AMethodAsync, grpcClient.AMethod, effectiveSettings.AMethodSettings);
            Modify_ApiCall(ref _callAMethod);
            Modify_AMethodApiCall(ref _callAMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AMethodApiCall(ref gaxgrpc::ApiCall<ResourceRequest, Resource> call);

        partial void OnConstruction(ServiceWithResources.ServiceWithResourcesClient grpcClient, ServiceWithResourcesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC ServiceWithResources client</summary>
        public override ServiceWithResources.ServiceWithResourcesClient GrpcClient { get; }

        partial void Modify_ResourceRequest(ref ResourceRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Resource AMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResourceRequest(ref request, ref callSettings);
            return _callAMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// Test summary text for AMethod
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Resource> AMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResourceRequest(ref request, ref callSettings);
            return _callAMethod.Async(request, callSettings);
        }
    }
}
