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
using lro = Google.LongRunning;
using mel = Microsoft.Extensions.Logging;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.Lro
{
    /// <summary>Settings for <see cref="LroClient"/> instances.</summary>
    public sealed partial class LroSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="LroSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="LroSettings"/>.</returns>
        public static LroSettings GetDefault() => new LroSettings();

        /// <summary>Constructs a new <see cref="LroSettings"/> object with default settings.</summary>
        public LroSettings()
        {
        }

        private LroSettings(LroSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            SignatureMethodSettings = existing.SignatureMethodSettings;
            SignatureMethodOperationsSettings = existing.SignatureMethodOperationsSettings.Clone();
            ResourcedMethodSettings = existing.ResourcedMethodSettings;
            ResourcedMethodOperationsSettings = existing.ResourcedMethodOperationsSettings.Clone();
            CustomDefaultPollingMethodSettings = existing.CustomDefaultPollingMethodSettings;
            CustomDefaultPollingMethodOperationsSettings = existing.CustomDefaultPollingMethodOperationsSettings.Clone();
            OnCopy(existing);
        }

        partial void OnCopy(LroSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>LroClient.SignatureMethod</c>
        ///  and <c>LroClient.SignatureMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SignatureMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// Long Running Operation settings for calls to <c>LroClient.SignatureMethod</c> and
        /// <c>LroClient.SignatureMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// Uses default <see cref="gax::PollSettings"/> of:
        /// <list type="bullet">
        /// <item><description>Initial delay: 20 seconds.</description></item>
        /// <item><description>Delay multiplier: 1.5</description></item>
        /// <item><description>Maximum delay: 45 seconds.</description></item>
        /// <item><description>Total timeout: 24 hours.</description></item>
        /// </list>
        /// </remarks>
        public lro::OperationsSettings SignatureMethodOperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>LroClient.ResourcedMethod</c>
        ///  and <c>LroClient.ResourcedMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ResourcedMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// Long Running Operation settings for calls to <c>LroClient.ResourcedMethod</c> and
        /// <c>LroClient.ResourcedMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// Uses default <see cref="gax::PollSettings"/> of:
        /// <list type="bullet">
        /// <item><description>Initial delay: 20 seconds.</description></item>
        /// <item><description>Delay multiplier: 1.5</description></item>
        /// <item><description>Maximum delay: 45 seconds.</description></item>
        /// <item><description>Total timeout: 24 hours.</description></item>
        /// </list>
        /// </remarks>
        public lro::OperationsSettings ResourcedMethodOperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>LroClient.CustomDefaultPollingMethod</c> and <c>LroClient.CustomDefaultPollingMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CustomDefaultPollingMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// Long Running Operation settings for calls to <c>LroClient.CustomDefaultPollingMethod</c> and
        /// <c>LroClient.CustomDefaultPollingMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// Uses default <see cref="gax::PollSettings"/> of:
        /// <list type="bullet">
        /// <item><description>Initial delay: 20 seconds.</description></item>
        /// <item><description>Delay multiplier: 1.5</description></item>
        /// <item><description>Maximum delay: 45 seconds.</description></item>
        /// <item><description>Total timeout: 24 hours.</description></item>
        /// </list>
        /// </remarks>
        public lro::OperationsSettings CustomDefaultPollingMethodOperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="LroSettings"/> object.</returns>
        public LroSettings Clone() => new LroSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="LroClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class LroClientBuilder : gaxgrpc::ClientBuilderBase<LroClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public LroSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public LroClientBuilder() : base(LroClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref LroClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<LroClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override LroClient Build()
        {
            LroClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<LroClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<LroClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private LroClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return LroClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<LroClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return LroClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => LroClient.ChannelPool;
    }

    /// <summary>Lro client wrapper, for convenient use.</summary>
    /// <remarks>
    /// LRO service to test.
    /// </remarks>
    public abstract partial class LroClient
    {
        /// <summary>
        /// The default endpoint for the Lro service, which is a host of "lro.example.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "lro.example.com:443";

        /// <summary>The default Lro scopes.</summary>
        /// <remarks>The default Lro scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Lro.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="LroClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="LroClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="LroClient"/>.</returns>
        public static stt::Task<LroClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new LroClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="LroClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="LroClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="LroClient"/>.</returns>
        public static LroClient Create() => new LroClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="LroClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="LroSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="LroClient"/>.</returns>
        internal static LroClient Create(grpccore::CallInvoker callInvoker, LroSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Lro.LroClient grpcClient = new Lro.LroClient(callInvoker);
            return new LroClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC Lro client</summary>
        public virtual Lro.LroClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> SignatureMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(Request request, st::CancellationToken cancellationToken) =>
            SignatureMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>SignatureMethod</c>.</summary>
        public virtual lro::OperationsClient SignatureMethodOperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of <c>SignatureMethod</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> PollOnceSignatureMethod(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), SignatureMethodOperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>SignatureMethod</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> PollOnceSignatureMethodAsync(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), SignatureMethodOperationsClient, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> SignatureMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethod(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethodAsync(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(string name, st::CancellationToken cancellationToken) =>
            SignatureMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested> ResourcedMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> ResourcedMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> ResourcedMethodAsync(ResourceRequest request, st::CancellationToken cancellationToken) =>
            ResourcedMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>ResourcedMethod</c>.</summary>
        public virtual lro::OperationsClient ResourcedMethodOperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of <c>ResourcedMethod</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested> PollOnceResourcedMethod(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), ResourcedMethodOperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>ResourcedMethod</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> PollOnceResourcedMethodAsync(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), ResourcedMethodOperationsClient, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested> ResourcedMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> ResourcedMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethodAsync(new ResourceRequest { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> ResourcedMethodAsync(string name, st::CancellationToken cancellationToken) =>
            ResourcedMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested> ResourcedMethod(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest { ResourceName = name, }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> ResourcedMethodAsync(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethodAsync(new ResourceRequest { ResourceName = name, }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> ResourcedMethodAsync(ResourceName name, st::CancellationToken cancellationToken) =>
            ResourcedMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> CustomDefaultPollingMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> CustomDefaultPollingMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> CustomDefaultPollingMethodAsync(Request request, st::CancellationToken cancellationToken) =>
            CustomDefaultPollingMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>CustomDefaultPollingMethod</c>.</summary>
        public virtual lro::OperationsClient CustomDefaultPollingMethodOperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>CustomDefaultPollingMethod</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> PollOnceCustomDefaultPollingMethod(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), CustomDefaultPollingMethodOperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>CustomDefaultPollingMethod</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> PollOnceCustomDefaultPollingMethodAsync(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), CustomDefaultPollingMethodOperationsClient, callSettings);

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> CustomDefaultPollingMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            CustomDefaultPollingMethod(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> CustomDefaultPollingMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            CustomDefaultPollingMethodAsync(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> CustomDefaultPollingMethodAsync(string name, st::CancellationToken cancellationToken) =>
            CustomDefaultPollingMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Lro client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// LRO service to test.
    /// </remarks>
    public sealed partial class LroClientImpl : LroClient
    {
        private readonly gaxgrpc::ApiCall<Request, lro::Operation> _callSignatureMethod;

        private readonly gaxgrpc::ApiCall<ResourceRequest, lro::Operation> _callResourcedMethod;

        private readonly gaxgrpc::ApiCall<Request, lro::Operation> _callCustomDefaultPollingMethod;

        /// <summary>
        /// Constructs a client wrapper for the Lro service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="LroSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public LroClientImpl(Lro.LroClient grpcClient, LroSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            LroSettings effectiveSettings = settings ?? LroSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(new gaxgrpc::ClientHelper.Options
            {
                Settings = effectiveSettings,
                Logger = logger,
            });
            SignatureMethodOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.SignatureMethodOperationsSettings, logger);
            ResourcedMethodOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.ResourcedMethodOperationsSettings, logger);
            CustomDefaultPollingMethodOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.CustomDefaultPollingMethodOperationsSettings, logger);
            _callSignatureMethod = clientHelper.BuildApiCall<Request, lro::Operation>("SignatureMethod", grpcClient.SignatureMethodAsync, grpcClient.SignatureMethod, effectiveSettings.SignatureMethodSettings);
            Modify_ApiCall(ref _callSignatureMethod);
            Modify_SignatureMethodApiCall(ref _callSignatureMethod);
            _callResourcedMethod = clientHelper.BuildApiCall<ResourceRequest, lro::Operation>("ResourcedMethod", grpcClient.ResourcedMethodAsync, grpcClient.ResourcedMethod, effectiveSettings.ResourcedMethodSettings);
            Modify_ApiCall(ref _callResourcedMethod);
            Modify_ResourcedMethodApiCall(ref _callResourcedMethod);
            _callCustomDefaultPollingMethod = clientHelper.BuildApiCall<Request, lro::Operation>("CustomDefaultPollingMethod", grpcClient.CustomDefaultPollingMethodAsync, grpcClient.CustomDefaultPollingMethod, effectiveSettings.CustomDefaultPollingMethodSettings);
            Modify_ApiCall(ref _callCustomDefaultPollingMethod);
            Modify_CustomDefaultPollingMethodApiCall(ref _callCustomDefaultPollingMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_SignatureMethodApiCall(ref gaxgrpc::ApiCall<Request, lro::Operation> call);

        partial void Modify_ResourcedMethodApiCall(ref gaxgrpc::ApiCall<ResourceRequest, lro::Operation> call);

        partial void Modify_CustomDefaultPollingMethodApiCall(ref gaxgrpc::ApiCall<Request, lro::Operation> call);

        partial void OnConstruction(Lro.LroClient grpcClient, LroSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Lro client</summary>
        public override Lro.LroClient GrpcClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ResourceRequest(ref ResourceRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>The long-running operations client for <c>SignatureMethod</c>.</summary>
        public override lro::OperationsClient SignatureMethodOperationsClient { get; }

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<LroResponse, LroMetadata> SignatureMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(_callSignatureMethod.Sync(request, callSettings), SignatureMethodOperationsClient);
        }

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(await _callSignatureMethod.Async(request, callSettings).ConfigureAwait(false), SignatureMethodOperationsClient);
        }

        /// <summary>The long-running operations client for <c>ResourcedMethod</c>.</summary>
        public override lro::OperationsClient ResourcedMethodOperationsClient { get; }

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested> ResourcedMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResourceRequest(ref request, ref callSettings);
            return new lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>(_callResourcedMethod.Sync(request, callSettings), ResourcedMethodOperationsClient);
        }

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>> ResourcedMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResourceRequest(ref request, ref callSettings);
            return new lro::Operation<LroResponse.Types.Nested, LroMetadata.Types.Nested>(await _callResourcedMethod.Async(request, callSettings).ConfigureAwait(false), ResourcedMethodOperationsClient);
        }

        /// <summary>The long-running operations client for <c>CustomDefaultPollingMethod</c>.</summary>
        public override lro::OperationsClient CustomDefaultPollingMethodOperationsClient { get; }

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<LroResponse, LroMetadata> CustomDefaultPollingMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(_callCustomDefaultPollingMethod.Sync(request, callSettings), CustomDefaultPollingMethodOperationsClient);
        }

        /// <summary>
        /// Test an LRO RPC with customized default polling settings.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<LroResponse, LroMetadata>> CustomDefaultPollingMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(await _callCustomDefaultPollingMethod.Async(request, callSettings).ConfigureAwait(false), CustomDefaultPollingMethodOperationsClient);
        }
    }

    public static partial class Lro
    {
        public partial class LroClient
        {
            /// <summary>
            /// Creates a new instance of <see cref="lro::Operations.OperationsClient"/> using the same call invoker as
            /// this client.
            /// </summary>
            /// <returns>A new Operations client for the same target as this client.</returns>
            public virtual lro::Operations.OperationsClient CreateOperationsClient() =>
                new lro::Operations.OperationsClient(CallInvoker);
        }
    }
}
