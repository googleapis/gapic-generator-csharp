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

namespace Testing.Editions
{
    /// <summary>Settings for <see cref="Edition2023Client"/> instances.</summary>
    public sealed partial class Edition2023Settings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="Edition2023Settings"/>.</summary>
        /// <returns>A new instance of the default <see cref="Edition2023Settings"/>.</returns>
        public static Edition2023Settings GetDefault() => new Edition2023Settings();

        /// <summary>Constructs a new <see cref="Edition2023Settings"/> object with default settings.</summary>
        public Edition2023Settings()
        {
        }

        private Edition2023Settings(Edition2023Settings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            Method1Settings = existing.Method1Settings;
            OnCopy(existing);
        }

        partial void OnCopy(Edition2023Settings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>Edition2023Client.Method1</c>
        ///  and <c>Edition2023Client.Method1Async</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings Method1Settings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="Edition2023Settings"/> object.</returns>
        public Edition2023Settings Clone() => new Edition2023Settings(this);
    }

    /// <summary>
    /// Builder class for <see cref="Edition2023Client"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class Edition2023ClientBuilder : gaxgrpc::ClientBuilderBase<Edition2023Client>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public Edition2023Settings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public Edition2023ClientBuilder() : base(Edition2023Client.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref Edition2023Client client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<Edition2023Client> task);

        /// <summary>Builds the resulting client.</summary>
        public override Edition2023Client Build()
        {
            Edition2023Client client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<Edition2023Client> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<Edition2023Client> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private Edition2023Client BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return Edition2023Client.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<Edition2023Client> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return Edition2023Client.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => Edition2023Client.ChannelPool;
    }

    /// <summary>Edition2023 client wrapper, for convenient use.</summary>
    /// <remarks>
    /// Test service
    /// </remarks>
    public abstract partial class Edition2023Client
    {
        /// <summary>
        /// The default endpoint for the Edition2023 service, which is a host of "" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = ":443";

        /// <summary>The default Edition2023 scopes.</summary>
        /// <remarks>The default Edition2023 scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Edition2023.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="Edition2023Client"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="Edition2023ClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="Edition2023Client"/>.</returns>
        public static stt::Task<Edition2023Client> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new Edition2023ClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="Edition2023Client"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="Edition2023ClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="Edition2023Client"/>.</returns>
        public static Edition2023Client Create() => new Edition2023ClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="Edition2023Client"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="Edition2023Settings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="Edition2023Client"/>.</returns>
        internal static Edition2023Client Create(grpccore::CallInvoker callInvoker, Edition2023Settings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Edition2023.Edition2023Client grpcClient = new Edition2023.Edition2023Client(callInvoker);
            return new Edition2023ClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC Edition2023 client</summary>
        public virtual Edition2023.Edition2023Client GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Edition2023Response Method1(Edition2023Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Edition2023Response> Method1Async(Edition2023Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Edition2023Response> Method1Async(Edition2023Request request, st::CancellationToken cancellationToken) =>
            Method1Async(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="name">
        /// Equivalent to proto3 optional
        /// </param>
        /// <param name="number">
        /// Equivalent to proto3 default
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Edition2023Response Method1(string name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1(new Edition2023Request
            {
                Name = name ?? "",
                Number = number,
            }, callSettings);

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="name">
        /// Equivalent to proto3 optional
        /// </param>
        /// <param name="number">
        /// Equivalent to proto3 default
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Edition2023Response> Method1Async(string name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1Async(new Edition2023Request
            {
                Name = name ?? "",
                Number = number,
            }, callSettings);

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="name">
        /// Equivalent to proto3 optional
        /// </param>
        /// <param name="number">
        /// Equivalent to proto3 default
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Edition2023Response> Method1Async(string name, int number, st::CancellationToken cancellationToken) =>
            Method1Async(name, number, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="name">
        /// Equivalent to proto3 optional
        /// </param>
        /// <param name="number">
        /// Equivalent to proto3 default
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Edition2023Response Method1(Edition2023ResourceName name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1(new Edition2023Request
            {
                Edition2023ResourceName = name,
                Number = number,
            }, callSettings);

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="name">
        /// Equivalent to proto3 optional
        /// </param>
        /// <param name="number">
        /// Equivalent to proto3 default
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Edition2023Response> Method1Async(Edition2023ResourceName name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1Async(new Edition2023Request
            {
                Edition2023ResourceName = name,
                Number = number,
            }, callSettings);

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="name">
        /// Equivalent to proto3 optional
        /// </param>
        /// <param name="number">
        /// Equivalent to proto3 default
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Edition2023Response> Method1Async(Edition2023ResourceName name, int number, st::CancellationToken cancellationToken) =>
            Method1Async(name, number, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Edition2023 client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// Test service
    /// </remarks>
    public sealed partial class Edition2023ClientImpl : Edition2023Client
    {
        private readonly gaxgrpc::ApiCall<Edition2023Request, Edition2023Response> _callMethod1;

        /// <summary>
        /// Constructs a client wrapper for the Edition2023 service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="Edition2023Settings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public Edition2023ClientImpl(Edition2023.Edition2023Client grpcClient, Edition2023Settings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            Edition2023Settings effectiveSettings = settings ?? Edition2023Settings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(new gaxgrpc::ClientHelper.Options
            {
                Settings = effectiveSettings,
                Logger = logger,
            });
            _callMethod1 = clientHelper.BuildApiCall<Edition2023Request, Edition2023Response>("Method1", grpcClient.Method1Async, grpcClient.Method1, effectiveSettings.Method1Settings);
            Modify_ApiCall(ref _callMethod1);
            Modify_Method1ApiCall(ref _callMethod1);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_Method1ApiCall(ref gaxgrpc::ApiCall<Edition2023Request, Edition2023Response> call);

        partial void OnConstruction(Edition2023.Edition2023Client grpcClient, Edition2023Settings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Edition2023 client</summary>
        public override Edition2023.Edition2023Client GrpcClient { get; }

        partial void Modify_Edition2023Request(ref Edition2023Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Edition2023Response Method1(Edition2023Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Edition2023Request(ref request, ref callSettings);
            return _callMethod1.Sync(request, callSettings);
        }

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Edition2023Response> Method1Async(Edition2023Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Edition2023Request(ref request, ref callSettings);
            return _callMethod1.Async(request, callSettings);
        }
    }
}
