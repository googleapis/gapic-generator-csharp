﻿// Copyright 2019 Google LLC
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
using gaxgrpccore = Google.Api.Gax.Grpc.GrpcCore;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.Basic
{
    /// <summary>Settings for <see cref="BasicClient"/> instances.</summary>
    public sealed partial class BasicSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="BasicSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="BasicSettings"/>.</returns>
        public static BasicSettings GetDefault() => new BasicSettings();

        /// <summary>Constructs a new <see cref="BasicSettings"/> object with default settings.</summary>
        public BasicSettings()
        {
        }

        private BasicSettings(BasicSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AMethodSettings = existing.AMethodSettings;
            OnCopy(existing);
        }

        partial void OnCopy(BasicSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>BasicClient.AMethod</c> and
        /// <c>BasicClient.AMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="BasicSettings"/> object.</returns>
        public BasicSettings Clone() => new BasicSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="BasicClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class BasicClientBuilder : gaxgrpc::ClientBuilderBase<BasicClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public BasicSettings Settings { get; set; }

        partial void InterceptBuild(ref BasicClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<BasicClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override BasicClient Build()
        {
            BasicClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<BasicClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<BasicClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private BasicClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return BasicClient.Create(callInvoker, Settings);
        }

        private async stt::Task<BasicClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return BasicClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => BasicClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => BasicClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => BasicClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => gaxgrpccore::GrpcCoreAdapter.Instance;
    }

    /// <summary>Basic client wrapper, for convenient use.</summary>
    /// <remarks>
    /// This is a basic service.
    /// </remarks>
    public abstract partial class BasicClient
    {
        /// <summary>
        /// The default endpoint for the Basic service, which is a host of "basic.example.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "basic.example.com:443";

        /// <summary>The default Basic scopes.</summary>
        /// <remarks>
        /// The default Basic scopes are:
        /// <list type="bullet">
        /// <item><description>scope1</description></item>
        /// <item><description>scope2</description></item>
        /// </list>
        /// </remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { "scope1", "scope2", });

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(DefaultScopes);

        /// <summary>
        /// Asynchronously creates a <see cref="BasicClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="BasicClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="BasicClient"/>.</returns>
        public static stt::Task<BasicClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new BasicClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="BasicClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="BasicClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="BasicClient"/>.</returns>
        public static BasicClient Create() => new BasicClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="BasicClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="BasicSettings"/>.</param>
        /// <returns>The created <see cref="BasicClient"/>.</returns>
        internal static BasicClient Create(grpccore::CallInvoker callInvoker, BasicSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Basic.BasicClient grpcClient = new Basic.BasicClient(callInvoker);
            return new BasicClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC Basic client</summary>
        public virtual Basic.BasicClient GrpcClient => throw new sys::NotImplementedException();

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
    }

    /// <summary>Basic client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// This is a basic service.
    /// </remarks>
    public sealed partial class BasicClientImpl : BasicClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callAMethod;

        /// <summary>
        /// Constructs a client wrapper for the Basic service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="BasicSettings"/> used within this client.</param>
        public BasicClientImpl(Basic.BasicClient grpcClient, BasicSettings settings)
        {
            GrpcClient = grpcClient;
            BasicSettings effectiveSettings = settings ?? BasicSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAMethod = clientHelper.BuildApiCall<Request, Response>(grpcClient.AMethodAsync, grpcClient.AMethod, effectiveSettings.AMethodSettings);
            Modify_ApiCall(ref _callAMethod);
            Modify_AMethodApiCall(ref _callAMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AMethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void OnConstruction(Basic.BasicClient grpcClient, BasicSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Basic client</summary>
        public override Basic.BasicClient GrpcClient { get; }

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
