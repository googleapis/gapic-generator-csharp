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
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Google.Ads.GoogleAds.V23.Services
{
    /// <summary>Settings for <see cref="YouTubeVideoUploadServiceClient"/> instances.</summary>
    public sealed partial class YouTubeVideoUploadServiceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="YouTubeVideoUploadServiceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="YouTubeVideoUploadServiceSettings"/>.</returns>
        public static YouTubeVideoUploadServiceSettings GetDefault() => new YouTubeVideoUploadServiceSettings();

        /// <summary>
        /// Constructs a new <see cref="YouTubeVideoUploadServiceSettings"/> object with default settings.
        /// </summary>
        public YouTubeVideoUploadServiceSettings()
        {
        }

        private YouTubeVideoUploadServiceSettings(YouTubeVideoUploadServiceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            CreateYouTubeVideoUploadSettings = existing.CreateYouTubeVideoUploadSettings;
            CreateYouTubeVideoUploadResumableUploadSettings = existing.CreateYouTubeVideoUploadResumableUploadSettings;
            OnCopy(existing);
        }

        partial void OnCopy(YouTubeVideoUploadServiceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>YouTubeVideoUploadServiceClient.CreateYouTubeVideoUpload</c> and
        /// <c>YouTubeVideoUploadServiceClient.CreateYouTubeVideoUploadAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CreateYouTubeVideoUploadSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// The settings to use for resumable upload calls to
        /// <c>YouTubeVideoUploadServiceClient.CreateYouTubeVideoUpload</c>.
        /// </summary>
        public gaggr::ResumableUploadSettings CreateYouTubeVideoUploadResumableUploadSettings { get; set; } = gaggr::ResumableUploadSettings.Default;

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="YouTubeVideoUploadServiceSettings"/> object.</returns>
        public YouTubeVideoUploadServiceSettings Clone() => new YouTubeVideoUploadServiceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="YouTubeVideoUploadServiceClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class YouTubeVideoUploadServiceClientBuilder : gaxgrpc::ClientBuilderBase<YouTubeVideoUploadServiceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public YouTubeVideoUploadServiceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public YouTubeVideoUploadServiceClientBuilder() : base(YouTubeVideoUploadServiceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref YouTubeVideoUploadServiceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<YouTubeVideoUploadServiceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override YouTubeVideoUploadServiceClient Build()
        {
            YouTubeVideoUploadServiceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<YouTubeVideoUploadServiceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<YouTubeVideoUploadServiceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private YouTubeVideoUploadServiceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            grpccore::CallInvoker restCallInvoker = MaybeCreateRestCallInvoker(callInvoker);
            return YouTubeVideoUploadServiceClient.Create(callInvoker, restCallInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<YouTubeVideoUploadServiceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            grpccore::CallInvoker restCallInvoker = await MaybeCreateRestCallInvokerAsync(callInvoker, cancellationToken).ConfigureAwait(false);
            return YouTubeVideoUploadServiceClient.Create(callInvoker, restCallInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => YouTubeVideoUploadServiceClient.ChannelPool;
    }

    /// <summary>YouTubeVideoUploadService client wrapper, for convenient use.</summary>
    /// <remarks>
    /// Service for uploading YouTube videos with resumable upload support.
    /// </remarks>
    public abstract partial class YouTubeVideoUploadServiceClient
    {
        /// <summary>
        /// The default endpoint for the YouTubeVideoUploadService service, which is a host of
        /// "googleads.googleapis.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "googleads.googleapis.com:443";

        /// <summary>The default YouTubeVideoUploadService scopes.</summary>
        /// <remarks>The default YouTubeVideoUploadService scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(YouTubeVideoUploadService.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc | gax::ApiTransports.Rest, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="YouTubeVideoUploadServiceClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="YouTubeVideoUploadServiceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="YouTubeVideoUploadServiceClient"/>.</returns>
        public static stt::Task<YouTubeVideoUploadServiceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new YouTubeVideoUploadServiceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="YouTubeVideoUploadServiceClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="YouTubeVideoUploadServiceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="YouTubeVideoUploadServiceClient"/>.</returns>
        public static YouTubeVideoUploadServiceClient Create() => new YouTubeVideoUploadServiceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="YouTubeVideoUploadServiceClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="restCallInvoker">
        /// The optional REST <see cref="grpccore::CallInvoker"/> for resumable upload operations.
        /// </param>
        /// <param name="settings">Optional <see cref="YouTubeVideoUploadServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="YouTubeVideoUploadServiceClient"/>.</returns>
        internal static YouTubeVideoUploadServiceClient Create(grpccore::CallInvoker callInvoker, grpccore::CallInvoker restCallInvoker, YouTubeVideoUploadServiceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            YouTubeVideoUploadService.YouTubeVideoUploadServiceClient grpcClient = new YouTubeVideoUploadService.YouTubeVideoUploadServiceClient(callInvoker);
            return new YouTubeVideoUploadServiceClientImpl(grpcClient, restCallInvoker, settings, logger);
        }

        /// <summary>
        /// Creates a <see cref="YouTubeVideoUploadServiceClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="YouTubeVideoUploadServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="YouTubeVideoUploadServiceClient"/>.</returns>
        internal static YouTubeVideoUploadServiceClient Create(grpccore::CallInvoker callInvoker, YouTubeVideoUploadServiceSettings settings = null, mel::ILogger logger = null) =>
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

        /// <summary>The underlying gRPC YouTubeVideoUploadService client</summary>
        public virtual YouTubeVideoUploadService.YouTubeVideoUploadServiceClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a
        /// <see cref="gaggr::ResumableUploadSession{CreateYouTubeVideoUploadRequest,CreateYouTubeVideoUploadResponse}"/>
        ///  for resumable upload calls to <c>CreateYouTubeVideoUpload</c>.
        /// </summary>
        /// <returns>
        /// A new
        /// <see cref="gaggr::ResumableUploadSession{CreateYouTubeVideoUploadRequest,CreateYouTubeVideoUploadResponse}"/>
        ///  instance.
        /// </returns>
        public virtual gaggr::ResumableUploadSession<CreateYouTubeVideoUploadRequest, CreateYouTubeVideoUploadResponse> CreateYouTubeVideoUpload() =>
            throw new sys::NotImplementedException();
    }

    /// <summary>YouTubeVideoUploadService client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// Service for uploading YouTube videos with resumable upload support.
    /// </remarks>
    public sealed partial class YouTubeVideoUploadServiceClientImpl : YouTubeVideoUploadServiceClient
    {
        private readonly gaggr::ApiResumableUploadCall<CreateYouTubeVideoUploadRequest, CreateYouTubeVideoUploadResponse> _callResumableCreateYouTubeVideoUpload;

        /// <summary>
        /// Constructs a client wrapper for the YouTubeVideoUploadService service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="restCallInvoker">
        /// The REST <see cref="grpccore::CallInvoker"/> to use for resumable upload operations, or null.
        /// </param>
        /// <param name="settings">
        /// The base <see cref="YouTubeVideoUploadServiceSettings"/> used within this client.
        /// </param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public YouTubeVideoUploadServiceClientImpl(YouTubeVideoUploadService.YouTubeVideoUploadServiceClient grpcClient, grpccore::CallInvoker restCallInvoker, YouTubeVideoUploadServiceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            YouTubeVideoUploadServiceSettings effectiveSettings = settings ?? YouTubeVideoUploadServiceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(new gaxgrpc::ClientHelper.Options
            {
                Settings = effectiveSettings,
                Logger = logger,
            });
            if (restCallInvoker != null)
            {
                _callResumableCreateYouTubeVideoUpload = clientHelper.BuildResumableUploadCall<CreateYouTubeVideoUploadRequest, CreateYouTubeVideoUploadResponse>("google.ads.googleads.v23.services.YouTubeVideoUploadService", "CreateYouTubeVideoUpload", restCallInvoker, effectiveSettings.CreateYouTubeVideoUploadSettings, effectiveSettings.CreateYouTubeVideoUploadResumableUploadSettings);
            }
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        /// <summary>
        /// Constructs a client wrapper for the YouTubeVideoUploadService service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="YouTubeVideoUploadServiceSettings"/> used within this client.
        /// </param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public YouTubeVideoUploadServiceClientImpl(YouTubeVideoUploadService.YouTubeVideoUploadServiceClient grpcClient, YouTubeVideoUploadServiceSettings settings, mel::ILogger logger) : this(grpcClient, null, settings, logger)
        {
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_CreateYouTubeVideoUploadApiCall(ref gaggr::ApiResumableUploadCall<CreateYouTubeVideoUploadRequest, CreateYouTubeVideoUploadResponse> call);

        partial void OnConstruction(YouTubeVideoUploadService.YouTubeVideoUploadServiceClient grpcClient, YouTubeVideoUploadServiceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC YouTubeVideoUploadService client</summary>
        public override YouTubeVideoUploadService.YouTubeVideoUploadServiceClient GrpcClient { get; }

        partial void Modify_CreateYouTubeVideoUploadRequest(ref CreateYouTubeVideoUploadRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Creates a
        /// <see cref="gaggr::ResumableUploadSession{CreateYouTubeVideoUploadRequest,CreateYouTubeVideoUploadResponse}"/>
        ///  for resumable upload calls to <c>CreateYouTubeVideoUpload</c>.
        /// </summary>
        /// <returns>
        /// A new
        /// <see cref="gaggr::ResumableUploadSession{CreateYouTubeVideoUploadRequest,CreateYouTubeVideoUploadResponse}"/>
        ///  instance.
        /// </returns>
        public override gaggr::ResumableUploadSession<CreateYouTubeVideoUploadRequest, CreateYouTubeVideoUploadResponse> CreateYouTubeVideoUpload()
        {
            if (_callResumableCreateYouTubeVideoUpload == null)
            {
                throw new sys::InvalidOperationException("Resumable uploads require REST transport support / RestCallInvoker.");
            }
            return _callResumableCreateYouTubeVideoUpload.CreateSession();
        }
    }
}
