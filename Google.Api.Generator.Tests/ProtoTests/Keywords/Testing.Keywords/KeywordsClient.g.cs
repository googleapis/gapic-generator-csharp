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

namespace Testing.Keywords
{
    /// <summary>Settings for <see cref="KeywordsClient"/> instances.</summary>
    public sealed partial class KeywordsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="KeywordsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="KeywordsSettings"/>.</returns>
        public static KeywordsSettings GetDefault() => new KeywordsSettings();

        /// <summary>Constructs a new <see cref="KeywordsSettings"/> object with default settings.</summary>
        public KeywordsSettings()
        {
        }

        private KeywordsSettings(KeywordsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            Method1Settings = existing.Method1Settings;
            Method2Settings = existing.Method2Settings;
            OnCopy(existing);
        }

        partial void OnCopy(KeywordsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>KeywordsClient.Method1</c>
        /// and <c>KeywordsClient.Method1Async</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings Method1Settings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>KeywordsClient.Method2</c>
        /// and <c>KeywordsClient.Method2Async</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings Method2Settings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="KeywordsSettings"/> object.</returns>
        public KeywordsSettings Clone() => new KeywordsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="KeywordsClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class KeywordsClientBuilder : gaxgrpc::ClientBuilderBase<KeywordsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public KeywordsSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public KeywordsClientBuilder() : base(KeywordsClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref KeywordsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<KeywordsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override KeywordsClient Build()
        {
            KeywordsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<KeywordsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<KeywordsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private KeywordsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return KeywordsClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<KeywordsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return KeywordsClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => KeywordsClient.ChannelPool;
    }

    /// <summary>Keywords client wrapper, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public abstract partial class KeywordsClient
    {
        /// <summary>The default endpoint for the Keywords service, which is a host of "" and a port of 443.</summary>
        public static string DefaultEndpoint { get; } = ":443";

        /// <summary>The default Keywords scopes.</summary>
        /// <remarks>The default Keywords scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Keywords.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="KeywordsClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="KeywordsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="KeywordsClient"/>.</returns>
        public static stt::Task<KeywordsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new KeywordsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="KeywordsClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="KeywordsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="KeywordsClient"/>.</returns>
        public static KeywordsClient Create() => new KeywordsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="KeywordsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="KeywordsSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="KeywordsClient"/>.</returns>
        internal static KeywordsClient Create(grpccore::CallInvoker callInvoker, KeywordsSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Keywords.KeywordsClient grpcClient = new Keywords.KeywordsClient(callInvoker);
            return new KeywordsClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC Keywords client</summary>
        public virtual Keywords.KeywordsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method1(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(Request request, st::CancellationToken cancellationToken) =>
            Method1Async(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="event">
        /// </param>
        /// <param name="switch">
        /// </param>
        /// <param name="void">
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="types">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method1(string @event, int @switch, Enum @void, string request, string types, gaxgrpc::CallSettings callSettings = null) =>
            Method1(new Request
            {
                Event = @event ?? "",
                Switch = @switch,
                Void = @void,
                Request_ = request ?? "",
                Types_ = types ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="event">
        /// </param>
        /// <param name="switch">
        /// </param>
        /// <param name="void">
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="types">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(string @event, int @switch, Enum @void, string request, string types, gaxgrpc::CallSettings callSettings = null) =>
            Method1Async(new Request
            {
                Event = @event ?? "",
                Switch = @switch,
                Void = @void,
                Request_ = request ?? "",
                Types_ = types ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="event">
        /// </param>
        /// <param name="switch">
        /// </param>
        /// <param name="void">
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="types">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(string @event, int @switch, Enum @void, string request, string types, st::CancellationToken cancellationToken) =>
            Method1Async(@event, @switch, @void, request, types, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="event">
        /// </param>
        /// <param name="switch">
        /// </param>
        /// <param name="void">
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="types">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method1(ResourceName @event, int @switch, Enum @void, string request, string types, gaxgrpc::CallSettings callSettings = null) =>
            Method1(new Request
            {
                EventAsResourceName = @event,
                Switch = @switch,
                Void = @void,
                Request_ = request ?? "",
                Types_ = types ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="event">
        /// </param>
        /// <param name="switch">
        /// </param>
        /// <param name="void">
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="types">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(ResourceName @event, int @switch, Enum @void, string request, string types, gaxgrpc::CallSettings callSettings = null) =>
            Method1Async(new Request
            {
                EventAsResourceName = @event,
                Switch = @switch,
                Void = @void,
                Request_ = request ?? "",
                Types_ = types ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="event">
        /// </param>
        /// <param name="switch">
        /// </param>
        /// <param name="void">
        /// </param>
        /// <param name="request">
        /// </param>
        /// <param name="types">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(ResourceName @event, int @switch, Enum @void, string request, string types, st::CancellationToken cancellationToken) =>
            Method1Async(@event, @switch, @void, request, types, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method2(Resource request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method2Async(Resource request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method2Async(Resource request, st::CancellationToken cancellationToken) =>
            Method2Async(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="while">
        /// </param>
        /// <param name="enum">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method2(string @while, Enum @enum, gaxgrpc::CallSettings callSettings = null) =>
            Method2(new Resource
            {
                While = @while ?? "",
                Enum = @enum,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="while">
        /// </param>
        /// <param name="enum">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method2Async(string @while, Enum @enum, gaxgrpc::CallSettings callSettings = null) =>
            Method2Async(new Resource
            {
                While = @while ?? "",
                Enum = @enum,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="while">
        /// </param>
        /// <param name="enum">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method2Async(string @while, Enum @enum, st::CancellationToken cancellationToken) =>
            Method2Async(@while, @enum, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="while">
        /// </param>
        /// <param name="enum">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method2(ResourceName @while, Enum @enum, gaxgrpc::CallSettings callSettings = null) =>
            Method2(new Resource
            {
                WhileAsResourceName = @while,
                Enum = @enum,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="while">
        /// </param>
        /// <param name="enum">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method2Async(ResourceName @while, Enum @enum, gaxgrpc::CallSettings callSettings = null) =>
            Method2Async(new Resource
            {
                WhileAsResourceName = @while,
                Enum = @enum,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="while">
        /// </param>
        /// <param name="enum">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method2Async(ResourceName @while, Enum @enum, st::CancellationToken cancellationToken) =>
            Method2Async(@while, @enum, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Keywords client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class KeywordsClientImpl : KeywordsClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callMethod1;

        private readonly gaxgrpc::ApiCall<Resource, Response> _callMethod2;

        /// <summary>
        /// Constructs a client wrapper for the Keywords service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="KeywordsSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public KeywordsClientImpl(Keywords.KeywordsClient grpcClient, KeywordsSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            KeywordsSettings effectiveSettings = settings ?? KeywordsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callMethod1 = clientHelper.BuildApiCall<Request, Response>("Method1", grpcClient.Method1Async, grpcClient.Method1, effectiveSettings.Method1Settings);
            Modify_ApiCall(ref _callMethod1);
            Modify_Method1ApiCall(ref _callMethod1);
            _callMethod2 = clientHelper.BuildApiCall<Resource, Response>("Method2", grpcClient.Method2Async, grpcClient.Method2, effectiveSettings.Method2Settings);
            Modify_ApiCall(ref _callMethod2);
            Modify_Method2ApiCall(ref _callMethod2);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_Method1ApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void Modify_Method2ApiCall(ref gaxgrpc::ApiCall<Resource, Response> call);

        partial void OnConstruction(Keywords.KeywordsClient grpcClient, KeywordsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Keywords client</summary>
        public override Keywords.KeywordsClient GrpcClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        partial void Modify_Resource(ref Resource request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response Method1(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callMethod1.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> Method1Async(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callMethod1.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response Method2(Resource request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Resource(ref request, ref callSettings);
            return _callMethod2.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> Method2Async(Resource request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Resource(ref request, ref callSettings);
            return _callMethod2.Async(request, callSettings);
        }
    }
}
