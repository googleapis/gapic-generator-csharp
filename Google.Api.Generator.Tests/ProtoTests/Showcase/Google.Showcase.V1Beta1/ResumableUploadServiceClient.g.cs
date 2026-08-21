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
using gaggr = Google.Api.Gax.Grpc.Rest;
using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using gciv = Google.Cloud.Iam.V1;
using gcl = Google.Cloud.Location;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Settings for <see cref="ResumableUploadServiceClient"/> instances.</summary>
    public sealed partial class ResumableUploadServiceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="ResumableUploadServiceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="ResumableUploadServiceSettings"/>.</returns>
        public static ResumableUploadServiceSettings GetDefault() => new ResumableUploadServiceSettings();

        /// <summary>
        /// Constructs a new <see cref="ResumableUploadServiceSettings"/> object with default settings.
        /// </summary>
        public ResumableUploadServiceSettings()
        {
        }

        private ResumableUploadServiceSettings(ResumableUploadServiceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            UploadMediaSettings = existing.UploadMediaSettings;
            UploadMediaResumableUploadSettings = existing.UploadMediaResumableUploadSettings;
            LocationsSettings = existing.LocationsSettings;
            IAMPolicySettings = existing.IAMPolicySettings;
            OnCopy(existing);
        }

        partial void OnCopy(ResumableUploadServiceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ResumableUploadServiceClient.UploadMedia</c> and <c>ResumableUploadServiceClient.UploadMediaAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UploadMediaSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// The settings to use for resumable upload calls to <c>ResumableUploadServiceClient.UploadMedia</c>.
        /// </summary>
        public gaggr::ResumableUploadSettings UploadMediaResumableUploadSettings { get; set; } = gaggr::ResumableUploadSettings.Default;

        /// <summary>
        /// The settings to use for the <see cref="gcl::LocationsClient"/> associated with the client.
        /// </summary>
        public gcl::LocationsSettings LocationsSettings { get; set; } = gcl::LocationsSettings.GetDefault();

        /// <summary>
        /// The settings to use for the <see cref="gciv::IAMPolicyClient"/> associated with the client.
        /// </summary>
        public gciv::IAMPolicySettings IAMPolicySettings { get; set; } = gciv::IAMPolicySettings.GetDefault();

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="ResumableUploadServiceSettings"/> object.</returns>
        public ResumableUploadServiceSettings Clone() => new ResumableUploadServiceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="ResumableUploadServiceClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class ResumableUploadServiceClientBuilder : gaxgrpc::ClientBuilderBase<ResumableUploadServiceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public ResumableUploadServiceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public ResumableUploadServiceClientBuilder() : base(ResumableUploadServiceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref ResumableUploadServiceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<ResumableUploadServiceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override ResumableUploadServiceClient Build()
        {
            ResumableUploadServiceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<ResumableUploadServiceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<ResumableUploadServiceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private ResumableUploadServiceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            grpccore::CallInvoker restCallInvoker = MaybeCreateRestCallInvoker(callInvoker);
            return ResumableUploadServiceClient.Create(callInvoker, restCallInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<ResumableUploadServiceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            grpccore::CallInvoker restCallInvoker = await MaybeCreateRestCallInvokerAsync(callInvoker, cancellationToken).ConfigureAwait(false);
            return ResumableUploadServiceClient.Create(callInvoker, restCallInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => ResumableUploadServiceClient.ChannelPool;
    }

    /// <summary>ResumableUploadService client wrapper, for convenient use.</summary>
    /// <remarks>
    /// A service showcasing universal resumable upload protocol support.
    /// </remarks>
    public abstract partial class ResumableUploadServiceClient
    {
        /// <summary>
        /// The default endpoint for the ResumableUploadService service, which is a host of "localhost:7469" and a port
        /// of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "localhost:7469:443";

        /// <summary>The default ResumableUploadService scopes.</summary>
        /// <remarks>The default ResumableUploadService scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(ResumableUploadService.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc | gax::ApiTransports.Rest, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="ResumableUploadServiceClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="ResumableUploadServiceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="ResumableUploadServiceClient"/>.</returns>
        public static stt::Task<ResumableUploadServiceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new ResumableUploadServiceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="ResumableUploadServiceClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="ResumableUploadServiceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="ResumableUploadServiceClient"/>.</returns>
        public static ResumableUploadServiceClient Create() => new ResumableUploadServiceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="ResumableUploadServiceClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="restCallInvoker">
        /// The optional REST <see cref="grpccore::CallInvoker"/> for resumable upload operations.
        /// </param>
        /// <param name="settings">Optional <see cref="ResumableUploadServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="ResumableUploadServiceClient"/>.</returns>
        internal static ResumableUploadServiceClient Create(grpccore::CallInvoker callInvoker, grpccore::CallInvoker restCallInvoker, ResumableUploadServiceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            ResumableUploadService.ResumableUploadServiceClient grpcClient = new ResumableUploadService.ResumableUploadServiceClient(callInvoker);
            return new ResumableUploadServiceClientImpl(grpcClient, restCallInvoker, settings, logger);
        }

        /// <summary>
        /// Creates a <see cref="ResumableUploadServiceClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="ResumableUploadServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="ResumableUploadServiceClient"/>.</returns>
        internal static ResumableUploadServiceClient Create(grpccore::CallInvoker callInvoker, ResumableUploadServiceSettings settings = null, mel::ILogger logger = null) =>
            Create(callInvoker, null, settings, logger);

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

        /// <summary>The underlying gRPC ResumableUploadService client</summary>
        public virtual ResumableUploadService.ResumableUploadServiceClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public virtual gcl::LocationsClient LocationsClient => throw new sys::NotImplementedException();

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public virtual gciv::IAMPolicyClient IAMPolicyClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a <see cref="gaggr::ResumableUploadSession{UploadMediaRequest,UploadMediaResponse}"/> for resumable
        /// upload calls to <c>UploadMedia</c>.
        /// </summary>
        /// <returns>
        /// A new <see cref="gaggr::ResumableUploadSession{UploadMediaRequest,UploadMediaResponse}"/> instance.
        /// </returns>
        public virtual gaggr::ResumableUploadSession<UploadMediaRequest, UploadMediaResponse> UploadMedia() =>
            throw new sys::NotImplementedException();
    }

    /// <summary>ResumableUploadService client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// A service showcasing universal resumable upload protocol support.
    /// </remarks>
    public sealed partial class ResumableUploadServiceClientImpl : ResumableUploadServiceClient
    {
        private readonly gaggr::ApiResumableUploadCall<UploadMediaRequest, UploadMediaResponse> _callResumableUploadMedia;

        /// <summary>
        /// Constructs a client wrapper for the ResumableUploadService service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="restCallInvoker">
        /// The REST <see cref="grpccore::CallInvoker"/> to use for resumable upload operations, or null.
        /// </param>
        /// <param name="settings">
        /// The base <see cref="ResumableUploadServiceSettings"/> used within this client.
        /// </param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public ResumableUploadServiceClientImpl(ResumableUploadService.ResumableUploadServiceClient grpcClient, grpccore::CallInvoker restCallInvoker, ResumableUploadServiceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            ResumableUploadServiceSettings effectiveSettings = settings ?? ResumableUploadServiceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(new gaxgrpc::ClientHelper.Options
            {
                Settings = effectiveSettings,
                Logger = logger,
            });
            LocationsClient = new gcl::LocationsClientImpl(grpcClient.CreateLocationsClient(), effectiveSettings.LocationsSettings, logger);
            IAMPolicyClient = new gciv::IAMPolicyClientImpl(grpcClient.CreateIAMPolicyClient(), effectiveSettings.IAMPolicySettings, logger);
            if (restCallInvoker != null)
            {
                _callResumableUploadMedia = clientHelper.BuildResumableUploadCall<UploadMediaRequest, UploadMediaResponse>("google.showcase.v1beta1.ResumableUploadService", "UploadMedia", restCallInvoker, effectiveSettings.UploadMediaSettings, effectiveSettings.UploadMediaResumableUploadSettings);
            }
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        /// <summary>
        /// Constructs a client wrapper for the ResumableUploadService service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="ResumableUploadServiceSettings"/> used within this client.
        /// </param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public ResumableUploadServiceClientImpl(ResumableUploadService.ResumableUploadServiceClient grpcClient, ResumableUploadServiceSettings settings, mel::ILogger logger) : this(grpcClient, null, settings, logger)
        {
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_UploadMediaApiCall(ref gaggr::ApiResumableUploadCall<UploadMediaRequest, UploadMediaResponse> call);

        partial void OnConstruction(ResumableUploadService.ResumableUploadServiceClient grpcClient, ResumableUploadServiceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC ResumableUploadService client</summary>
        public override ResumableUploadService.ResumableUploadServiceClient GrpcClient { get; }

        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public override gcl::LocationsClient LocationsClient { get; }

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public override gciv::IAMPolicyClient IAMPolicyClient { get; }

        partial void Modify_UploadMediaRequest(ref UploadMediaRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Creates a <see cref="gaggr::ResumableUploadSession{UploadMediaRequest,UploadMediaResponse}"/> for resumable
        /// upload calls to <c>UploadMedia</c>.
        /// </summary>
        /// <returns>
        /// A new <see cref="gaggr::ResumableUploadSession{UploadMediaRequest,UploadMediaResponse}"/> instance.
        /// </returns>
        public override gaggr::ResumableUploadSession<UploadMediaRequest, UploadMediaResponse> UploadMedia()
        {
            if (_callResumableUploadMedia == null)
            {
                throw new sys::InvalidOperationException("Resumable uploads require REST transport support / RestCallInvoker.");
            }
            return _callResumableUploadMedia.CreateSession();
        }
    }

    public static partial class ResumableUploadService
    {
        public partial class ResumableUploadServiceClient
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
