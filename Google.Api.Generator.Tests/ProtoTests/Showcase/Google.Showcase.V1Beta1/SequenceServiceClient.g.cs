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
using proto = Google.Protobuf;
using wkt = Google.Protobuf.WellKnownTypes;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Settings for <see cref="SequenceServiceClient"/> instances.</summary>
    public sealed partial class SequenceServiceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="SequenceServiceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="SequenceServiceSettings"/>.</returns>
        public static SequenceServiceSettings GetDefault() => new SequenceServiceSettings();

        /// <summary>Constructs a new <see cref="SequenceServiceSettings"/> object with default settings.</summary>
        public SequenceServiceSettings()
        {
        }

        private SequenceServiceSettings(SequenceServiceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            CreateSequenceSettings = existing.CreateSequenceSettings;
            GetSequenceReportSettings = existing.GetSequenceReportSettings;
            AttemptSequenceSettings = existing.AttemptSequenceSettings;
            LocationsSettings = existing.LocationsSettings;
            IAMPolicySettings = existing.IAMPolicySettings;
            OnCopy(existing);
        }

        partial void OnCopy(SequenceServiceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SequenceServiceClient.CreateSequence</c> and <c>SequenceServiceClient.CreateSequenceAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CreateSequenceSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SequenceServiceClient.GetSequenceReport</c> and <c>SequenceServiceClient.GetSequenceReportAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSequenceReportSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SequenceServiceClient.AttemptSequence</c> and <c>SequenceServiceClient.AttemptSequenceAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AttemptSequenceSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// The settings to use for the <see cref="gcl::LocationsClient"/> associated with the client.
        /// </summary>
        public gcl::LocationsSettings LocationsSettings { get; set; } = gcl::LocationsSettings.GetDefault();

        /// <summary>
        /// The settings to use for the <see cref="gciv::IAMPolicyClient"/> associated with the client.
        /// </summary>
        public gciv::IAMPolicySettings IAMPolicySettings { get; set; } = gciv::IAMPolicySettings.GetDefault();

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="SequenceServiceSettings"/> object.</returns>
        public SequenceServiceSettings Clone() => new SequenceServiceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="SequenceServiceClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class SequenceServiceClientBuilder : gaxgrpc::ClientBuilderBase<SequenceServiceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public SequenceServiceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public SequenceServiceClientBuilder() : base(SequenceServiceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref SequenceServiceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<SequenceServiceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override SequenceServiceClient Build()
        {
            SequenceServiceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<SequenceServiceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<SequenceServiceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private SequenceServiceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return SequenceServiceClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<SequenceServiceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return SequenceServiceClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => SequenceServiceClient.ChannelPool;
    }

    /// <summary>SequenceService client wrapper, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public abstract partial class SequenceServiceClient
    {
        /// <summary>
        /// The default endpoint for the SequenceService service, which is a host of "localhost:7469" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "localhost:7469:443";

        /// <summary>The default SequenceService scopes.</summary>
        /// <remarks>The default SequenceService scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(SequenceService.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc | gax::ApiTransports.Rest, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="SequenceServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="SequenceServiceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="SequenceServiceClient"/>.</returns>
        public static stt::Task<SequenceServiceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new SequenceServiceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="SequenceServiceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="SequenceServiceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="SequenceServiceClient"/>.</returns>
        public static SequenceServiceClient Create() => new SequenceServiceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="SequenceServiceClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="SequenceServiceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="SequenceServiceClient"/>.</returns>
        internal static SequenceServiceClient Create(grpccore::CallInvoker callInvoker, SequenceServiceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            SequenceService.SequenceServiceClient grpcClient = new SequenceService.SequenceServiceClient(callInvoker);
            return new SequenceServiceClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC SequenceService client</summary>
        public virtual SequenceService.SequenceServiceClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public virtual gcl::LocationsClient LocationsClient => throw new sys::NotImplementedException();

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public virtual gciv::IAMPolicyClient IAMPolicyClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Sequence CreateSequence(CreateSequenceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Sequence> CreateSequenceAsync(CreateSequenceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Sequence> CreateSequenceAsync(CreateSequenceRequest request, st::CancellationToken cancellationToken) =>
            CreateSequenceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="sequence">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Sequence CreateSequence(Sequence sequence, gaxgrpc::CallSettings callSettings = null) =>
            CreateSequence(new CreateSequenceRequest { Sequence = sequence, }, callSettings);

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="sequence">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Sequence> CreateSequenceAsync(Sequence sequence, gaxgrpc::CallSettings callSettings = null) =>
            CreateSequenceAsync(new CreateSequenceRequest { Sequence = sequence, }, callSettings);

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="sequence">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Sequence> CreateSequenceAsync(Sequence sequence, st::CancellationToken cancellationToken) =>
            CreateSequenceAsync(sequence, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SequenceReport GetSequenceReport(GetSequenceReportRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SequenceReport> GetSequenceReportAsync(GetSequenceReportRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SequenceReport> GetSequenceReportAsync(GetSequenceReportRequest request, st::CancellationToken cancellationToken) =>
            GetSequenceReportAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SequenceReport GetSequenceReport(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetSequenceReport(new GetSequenceReportRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SequenceReport> GetSequenceReportAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            GetSequenceReportAsync(new GetSequenceReportRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SequenceReport> GetSequenceReportAsync(string name, st::CancellationToken cancellationToken) =>
            GetSequenceReportAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SequenceReport GetSequenceReport(SequenceReportName name, gaxgrpc::CallSettings callSettings = null) =>
            GetSequenceReport(new GetSequenceReportRequest
            {
                SequenceReportName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SequenceReport> GetSequenceReportAsync(SequenceReportName name, gaxgrpc::CallSettings callSettings = null) =>
            GetSequenceReportAsync(new GetSequenceReportRequest
            {
                SequenceReportName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SequenceReport> GetSequenceReportAsync(SequenceReportName name, st::CancellationToken cancellationToken) =>
            GetSequenceReportAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void AttemptSequence(AttemptSequenceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task AttemptSequenceAsync(AttemptSequenceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task AttemptSequenceAsync(AttemptSequenceRequest request, st::CancellationToken cancellationToken) =>
            AttemptSequenceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void AttemptSequence(string name, gaxgrpc::CallSettings callSettings = null) =>
            AttemptSequence(new AttemptSequenceRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task AttemptSequenceAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            AttemptSequenceAsync(new AttemptSequenceRequest
            {
                Name = gax::GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task AttemptSequenceAsync(string name, st::CancellationToken cancellationToken) =>
            AttemptSequenceAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void AttemptSequence(SequenceName name, gaxgrpc::CallSettings callSettings = null) =>
            AttemptSequence(new AttemptSequenceRequest
            {
                SequenceName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task AttemptSequenceAsync(SequenceName name, gaxgrpc::CallSettings callSettings = null) =>
            AttemptSequenceAsync(new AttemptSequenceRequest
            {
                SequenceName = gax::GaxPreconditions.CheckNotNull(name, nameof(name)),
            }, callSettings);

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task AttemptSequenceAsync(SequenceName name, st::CancellationToken cancellationToken) =>
            AttemptSequenceAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>SequenceService client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class SequenceServiceClientImpl : SequenceServiceClient
    {
        private readonly gaxgrpc::ApiCall<CreateSequenceRequest, Sequence> _callCreateSequence;

        private readonly gaxgrpc::ApiCall<GetSequenceReportRequest, SequenceReport> _callGetSequenceReport;

        private readonly gaxgrpc::ApiCall<AttemptSequenceRequest, wkt::Empty> _callAttemptSequence;

        /// <summary>
        /// Constructs a client wrapper for the SequenceService service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="SequenceServiceSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public SequenceServiceClientImpl(SequenceService.SequenceServiceClient grpcClient, SequenceServiceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            SequenceServiceSettings effectiveSettings = settings ?? SequenceServiceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(new gaxgrpc::ClientHelper.Options
            {
                Settings = effectiveSettings,
                Logger = logger,
            });
            LocationsClient = new gcl::LocationsClientImpl(grpcClient.CreateLocationsClient(), effectiveSettings.LocationsSettings, logger);
            IAMPolicyClient = new gciv::IAMPolicyClientImpl(grpcClient.CreateIAMPolicyClient(), effectiveSettings.IAMPolicySettings, logger);
            _callCreateSequence = clientHelper.BuildApiCall<CreateSequenceRequest, Sequence>("CreateSequence", grpcClient.CreateSequenceAsync, grpcClient.CreateSequence, effectiveSettings.CreateSequenceSettings);
            Modify_ApiCall(ref _callCreateSequence);
            Modify_CreateSequenceApiCall(ref _callCreateSequence);
            _callGetSequenceReport = clientHelper.BuildApiCall<GetSequenceReportRequest, SequenceReport>("GetSequenceReport", grpcClient.GetSequenceReportAsync, grpcClient.GetSequenceReport, effectiveSettings.GetSequenceReportSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callGetSequenceReport);
            Modify_GetSequenceReportApiCall(ref _callGetSequenceReport);
            _callAttemptSequence = clientHelper.BuildApiCall<AttemptSequenceRequest, wkt::Empty>("AttemptSequence", grpcClient.AttemptSequenceAsync, grpcClient.AttemptSequence, effectiveSettings.AttemptSequenceSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callAttemptSequence);
            Modify_AttemptSequenceApiCall(ref _callAttemptSequence);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_CreateSequenceApiCall(ref gaxgrpc::ApiCall<CreateSequenceRequest, Sequence> call);

        partial void Modify_GetSequenceReportApiCall(ref gaxgrpc::ApiCall<GetSequenceReportRequest, SequenceReport> call);

        partial void Modify_AttemptSequenceApiCall(ref gaxgrpc::ApiCall<AttemptSequenceRequest, wkt::Empty> call);

        partial void OnConstruction(SequenceService.SequenceServiceClient grpcClient, SequenceServiceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC SequenceService client</summary>
        public override SequenceService.SequenceServiceClient GrpcClient { get; }

        /// <summary>The <see cref="gcl::LocationsClient"/> associated with this client.</summary>
        public override gcl::LocationsClient LocationsClient { get; }

        /// <summary>The <see cref="gciv::IAMPolicyClient"/> associated with this client.</summary>
        public override gciv::IAMPolicyClient IAMPolicyClient { get; }

        partial void Modify_CreateSequenceRequest(ref CreateSequenceRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetSequenceReportRequest(ref GetSequenceReportRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_AttemptSequenceRequest(ref AttemptSequenceRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Sequence CreateSequence(CreateSequenceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateSequenceRequest(ref request, ref callSettings);
            return _callCreateSequence.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Sequence> CreateSequenceAsync(CreateSequenceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateSequenceRequest(ref request, ref callSettings);
            return _callCreateSequence.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SequenceReport GetSequenceReport(GetSequenceReportRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSequenceReportRequest(ref request, ref callSettings);
            return _callGetSequenceReport.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SequenceReport> GetSequenceReportAsync(GetSequenceReportRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSequenceReportRequest(ref request, ref callSettings);
            return _callGetSequenceReport.Async(request, callSettings);
        }

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override void AttemptSequence(AttemptSequenceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AttemptSequenceRequest(ref request, ref callSettings);
            _callAttemptSequence.Sync(request, callSettings);
        }

        /// <summary>
        /// Attempts a sequence.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task AttemptSequenceAsync(AttemptSequenceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AttemptSequenceRequest(ref request, ref callSettings);
            return _callAttemptSequence.Async(request, callSettings);
        }
    }

    public static partial class SequenceService
    {
        public partial class SequenceServiceClient
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
