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
using linq = System.Linq;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.MethodSignatures
{
    /// <summary>Settings for <see cref="MethodSignaturesClient"/> instances.</summary>
    public sealed partial class MethodSignaturesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="MethodSignaturesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="MethodSignaturesSettings"/>.</returns>
        public static MethodSignaturesSettings GetDefault() => new MethodSignaturesSettings();

        /// <summary>Constructs a new <see cref="MethodSignaturesSettings"/> object with default settings.</summary>
        public MethodSignaturesSettings()
        {
        }

        private MethodSignaturesSettings(MethodSignaturesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            SimpleMethodSettings = existing.SimpleMethodSettings;
            PrimitiveArgsSettings = existing.PrimitiveArgsSettings;
            StringArgsSettings = existing.StringArgsSettings;
            BytesArgsSettings = existing.BytesArgsSettings;
            MessageArgsSettings = existing.MessageArgsSettings;
            MapArgsSettings = existing.MapArgsSettings;
            EnumArgsSettings = existing.EnumArgsSettings;
            NestedArgsSettings = existing.NestedArgsSettings;
            WktArgsSettings = existing.WktArgsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(MethodSignaturesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.SimpleMethod</c> and <c>MethodSignaturesClient.SimpleMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SimpleMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.PrimitiveArgs</c> and <c>MethodSignaturesClient.PrimitiveArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PrimitiveArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.StringArgs</c> and <c>MethodSignaturesClient.StringArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings StringArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.BytesArgs</c> and <c>MethodSignaturesClient.BytesArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings BytesArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.MessageArgs</c> and <c>MethodSignaturesClient.MessageArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings MessageArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.MapArgs</c> and <c>MethodSignaturesClient.MapArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings MapArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.EnumArgs</c> and <c>MethodSignaturesClient.EnumArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings EnumArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.NestedArgs</c> and <c>MethodSignaturesClient.NestedArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings NestedArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>MethodSignaturesClient.WktArgs</c> and <c>MethodSignaturesClient.WktArgsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings WktArgsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="MethodSignaturesSettings"/> object.</returns>
        public MethodSignaturesSettings Clone() => new MethodSignaturesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="MethodSignaturesClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class MethodSignaturesClientBuilder : gaxgrpc::ClientBuilderBase<MethodSignaturesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public MethodSignaturesSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public MethodSignaturesClientBuilder() : base(MethodSignaturesClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref MethodSignaturesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<MethodSignaturesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override MethodSignaturesClient Build()
        {
            MethodSignaturesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<MethodSignaturesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<MethodSignaturesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private MethodSignaturesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return MethodSignaturesClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        private async stt::Task<MethodSignaturesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return MethodSignaturesClient.Create(callInvoker, GetEffectiveSettings(Settings?.Clone()), Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => MethodSignaturesClient.ChannelPool;
    }

    /// <summary>MethodSignatures client wrapper, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public abstract partial class MethodSignaturesClient
    {
        /// <summary>
        /// The default endpoint for the MethodSignatures service, which is a host of "methodsignatures.example.com" and
        /// a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "methodsignatures.example.com:443";

        /// <summary>The default MethodSignatures scopes.</summary>
        /// <remarks>The default MethodSignatures scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(MethodSignatures.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="MethodSignaturesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="MethodSignaturesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="MethodSignaturesClient"/>.</returns>
        public static stt::Task<MethodSignaturesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new MethodSignaturesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="MethodSignaturesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="MethodSignaturesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="MethodSignaturesClient"/>.</returns>
        public static MethodSignaturesClient Create() => new MethodSignaturesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="MethodSignaturesClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="MethodSignaturesSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="MethodSignaturesClient"/>.</returns>
        internal static MethodSignaturesClient Create(grpccore::CallInvoker callInvoker, MethodSignaturesSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            MethodSignatures.MethodSignaturesClient grpcClient = new MethodSignatures.MethodSignaturesClient(callInvoker);
            return new MethodSignaturesClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC MethodSignatures client</summary>
        public virtual MethodSignatures.MethodSignaturesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(SimpleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(SimpleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(SimpleRequest request, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleRequest { }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleRequest { }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(int aNumber, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleRequest { ANumber = aNumber, }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(int aNumber, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleRequest { ANumber = aNumber, }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(int aNumber, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(aNumber, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(string aString, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleRequest
            {
                AString = aString ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string aString, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleRequest
            {
                AString = aString ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string aString, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(aString, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(int aNumber, string aString, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleRequest
            {
                ANumber = aNumber,
                AString = aString ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(int aNumber, string aString, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleRequest
            {
                ANumber = aNumber,
                AString = aString ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(int aNumber, string aString, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(aNumber, aString, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(string aString, int aNumber, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleRequest
            {
                ANumber = aNumber,
                AString = aString ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string aString, int aNumber, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleRequest
            {
                ANumber = aNumber,
                AString = aString ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// Another number with some test (preformatted) documetation
        /// that spans more than one line.
        /// </param>
        /// <param name="aNumber">
        /// A number with some test (preformatted) documentation.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string aString, int aNumber, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(aString, aNumber, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response PrimitiveArgs(PrimitiveRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> PrimitiveArgsAsync(PrimitiveRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> PrimitiveArgsAsync(PrimitiveRequest request, st::CancellationToken cancellationToken) =>
            PrimitiveArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response PrimitiveArgs(int optional, int required, scg::IEnumerable<int> repeatedOptional, scg::IEnumerable<int> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            PrimitiveArgs(new PrimitiveRequest
            {
                Optional = optional,
                Required = required,
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<int>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> PrimitiveArgsAsync(int optional, int required, scg::IEnumerable<int> repeatedOptional, scg::IEnumerable<int> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            PrimitiveArgsAsync(new PrimitiveRequest
            {
                Optional = optional,
                Required = required,
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<int>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> PrimitiveArgsAsync(int optional, int required, scg::IEnumerable<int> repeatedOptional, scg::IEnumerable<int> repeatedRequired, st::CancellationToken cancellationToken) =>
            PrimitiveArgsAsync(optional, required, repeatedOptional, repeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response StringArgs(StringRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> StringArgsAsync(StringRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> StringArgsAsync(StringRequest request, st::CancellationToken cancellationToken) =>
            StringArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response StringArgs(string optional, string required, scg::IEnumerable<string> repeatedOptional, scg::IEnumerable<string> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            StringArgs(new StringRequest
            {
                Optional = optional ?? "",
                Required = gax::GaxPreconditions.CheckNotNullOrEmpty(required, nameof(required)),
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<string>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> StringArgsAsync(string optional, string required, scg::IEnumerable<string> repeatedOptional, scg::IEnumerable<string> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            StringArgsAsync(new StringRequest
            {
                Optional = optional ?? "",
                Required = gax::GaxPreconditions.CheckNotNullOrEmpty(required, nameof(required)),
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<string>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> StringArgsAsync(string optional, string required, scg::IEnumerable<string> repeatedOptional, scg::IEnumerable<string> repeatedRequired, st::CancellationToken cancellationToken) =>
            StringArgsAsync(optional, required, repeatedOptional, repeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response BytesArgs(BytesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> BytesArgsAsync(BytesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> BytesArgsAsync(BytesRequest request, st::CancellationToken cancellationToken) =>
            BytesArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response BytesArgs(proto::ByteString optional, proto::ByteString required, scg::IEnumerable<proto::ByteString> repeatedOptional, scg::IEnumerable<proto::ByteString> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            BytesArgs(new BytesRequest
            {
                Optional = optional ?? proto::ByteString.Empty,
                Required = gax::GaxPreconditions.CheckNotNull(required, nameof(required)),
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<proto::ByteString>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> BytesArgsAsync(proto::ByteString optional, proto::ByteString required, scg::IEnumerable<proto::ByteString> repeatedOptional, scg::IEnumerable<proto::ByteString> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            BytesArgsAsync(new BytesRequest
            {
                Optional = optional ?? proto::ByteString.Empty,
                Required = gax::GaxPreconditions.CheckNotNull(required, nameof(required)),
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<proto::ByteString>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> BytesArgsAsync(proto::ByteString optional, proto::ByteString required, scg::IEnumerable<proto::ByteString> repeatedOptional, scg::IEnumerable<proto::ByteString> repeatedRequired, st::CancellationToken cancellationToken) =>
            BytesArgsAsync(optional, required, repeatedOptional, repeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MessageArgs(MessageRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MessageArgsAsync(MessageRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MessageArgsAsync(MessageRequest request, st::CancellationToken cancellationToken) =>
            MessageArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MessageArgs(MessageRequest.Types.Msg optional, MessageRequest.Types.Msg required, scg::IEnumerable<MessageRequest.Types.Msg> repeatedOptional, scg::IEnumerable<MessageRequest.Types.Msg> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            MessageArgs(new MessageRequest
            {
                Optional = optional,
                Required = gax::GaxPreconditions.CheckNotNull(required, nameof(required)),
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<MessageRequest.Types.Msg>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MessageArgsAsync(MessageRequest.Types.Msg optional, MessageRequest.Types.Msg required, scg::IEnumerable<MessageRequest.Types.Msg> repeatedOptional, scg::IEnumerable<MessageRequest.Types.Msg> repeatedRequired, gaxgrpc::CallSettings callSettings = null) =>
            MessageArgsAsync(new MessageRequest
            {
                Optional = optional,
                Required = gax::GaxPreconditions.CheckNotNull(required, nameof(required)),
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<MessageRequest.Types.Msg>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MessageArgsAsync(MessageRequest.Types.Msg optional, MessageRequest.Types.Msg required, scg::IEnumerable<MessageRequest.Types.Msg> repeatedOptional, scg::IEnumerable<MessageRequest.Types.Msg> repeatedRequired, st::CancellationToken cancellationToken) =>
            MessageArgsAsync(optional, required, repeatedOptional, repeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MapArgs(MapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MapArgsAsync(MapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MapArgsAsync(MapRequest request, st::CancellationToken cancellationToken) =>
            MapArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MapArgs(scg::IDictionary<string, string> optional, scg::IDictionary<int, MapRequest.Types.Msg> required, gaxgrpc::CallSettings callSettings = null) =>
            MapArgs(new MapRequest
            {
                Optional =
                {
                    optional ?? new scg::Dictionary<string, string>(),
                },
                Required =
                {
                    gax::GaxPreconditions.CheckNotNull(required, nameof(required)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MapArgsAsync(scg::IDictionary<string, string> optional, scg::IDictionary<int, MapRequest.Types.Msg> required, gaxgrpc::CallSettings callSettings = null) =>
            MapArgsAsync(new MapRequest
            {
                Optional =
                {
                    optional ?? new scg::Dictionary<string, string>(),
                },
                Required =
                {
                    gax::GaxPreconditions.CheckNotNull(required, nameof(required)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MapArgsAsync(scg::IDictionary<string, string> optional, scg::IDictionary<int, MapRequest.Types.Msg> required, st::CancellationToken cancellationToken) =>
            MapArgsAsync(optional, required, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response EnumArgs(EnumRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> EnumArgsAsync(EnumRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> EnumArgsAsync(EnumRequest request, st::CancellationToken cancellationToken) =>
            EnumArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="topLevelOptional">
        /// </param>
        /// <param name="topLevelRequired">
        /// </param>
        /// <param name="repeatedTopLevelOptional">
        /// </param>
        /// <param name="repeatedTopLevelRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response EnumArgs(EnumRequest.Types.Enum optional, EnumRequest.Types.Enum required, scg::IEnumerable<EnumRequest.Types.Enum> repeatedOptional, scg::IEnumerable<EnumRequest.Types.Enum> repeatedRequired, TopLevelEnum topLevelOptional, TopLevelEnum topLevelRequired, scg::IEnumerable<TopLevelEnum> repeatedTopLevelOptional, scg::IEnumerable<TopLevelEnum> repeatedTopLevelRequired, gaxgrpc::CallSettings callSettings = null) =>
            EnumArgs(new EnumRequest
            {
                Optional = optional,
                Required = required,
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<EnumRequest.Types.Enum>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
                TopLevelOptional = topLevelOptional,
                TopLevelRequired = topLevelRequired,
                RepeatedTopLevelOptional =
                {
                    repeatedTopLevelOptional ?? linq::Enumerable.Empty<TopLevelEnum>(),
                },
                RepeatedTopLevelRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedTopLevelRequired, nameof(repeatedTopLevelRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="topLevelOptional">
        /// </param>
        /// <param name="topLevelRequired">
        /// </param>
        /// <param name="repeatedTopLevelOptional">
        /// </param>
        /// <param name="repeatedTopLevelRequired">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> EnumArgsAsync(EnumRequest.Types.Enum optional, EnumRequest.Types.Enum required, scg::IEnumerable<EnumRequest.Types.Enum> repeatedOptional, scg::IEnumerable<EnumRequest.Types.Enum> repeatedRequired, TopLevelEnum topLevelOptional, TopLevelEnum topLevelRequired, scg::IEnumerable<TopLevelEnum> repeatedTopLevelOptional, scg::IEnumerable<TopLevelEnum> repeatedTopLevelRequired, gaxgrpc::CallSettings callSettings = null) =>
            EnumArgsAsync(new EnumRequest
            {
                Optional = optional,
                Required = required,
                RepeatedOptional =
                {
                    repeatedOptional ?? linq::Enumerable.Empty<EnumRequest.Types.Enum>(),
                },
                RepeatedRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequired, nameof(repeatedRequired)),
                },
                TopLevelOptional = topLevelOptional,
                TopLevelRequired = topLevelRequired,
                RepeatedTopLevelOptional =
                {
                    repeatedTopLevelOptional ?? linq::Enumerable.Empty<TopLevelEnum>(),
                },
                RepeatedTopLevelRequired =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedTopLevelRequired, nameof(repeatedTopLevelRequired)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optional">
        /// </param>
        /// <param name="required">
        /// </param>
        /// <param name="repeatedOptional">
        /// </param>
        /// <param name="repeatedRequired">
        /// </param>
        /// <param name="topLevelOptional">
        /// </param>
        /// <param name="topLevelRequired">
        /// </param>
        /// <param name="repeatedTopLevelOptional">
        /// </param>
        /// <param name="repeatedTopLevelRequired">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> EnumArgsAsync(EnumRequest.Types.Enum optional, EnumRequest.Types.Enum required, scg::IEnumerable<EnumRequest.Types.Enum> repeatedOptional, scg::IEnumerable<EnumRequest.Types.Enum> repeatedRequired, TopLevelEnum topLevelOptional, TopLevelEnum topLevelRequired, scg::IEnumerable<TopLevelEnum> repeatedTopLevelOptional, scg::IEnumerable<TopLevelEnum> repeatedTopLevelRequired, st::CancellationToken cancellationToken) =>
            EnumArgsAsync(optional, required, repeatedOptional, repeatedRequired, topLevelOptional, topLevelRequired, repeatedTopLevelOptional, repeatedTopLevelRequired, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response NestedArgs(NestedRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NestedArgsAsync(NestedRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NestedArgsAsync(NestedRequest request, st::CancellationToken cancellationToken) =>
            NestedArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// </param>
        /// <param name="aNumber">
        /// </param>
        /// <param name="anotherNumber">
        /// </param>
        /// <param name="aBool">
        /// </param>
        /// <param name="topLevelString">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response NestedArgs(string aString, int aNumber, int anotherNumber, bool aBool, string topLevelString, gaxgrpc::CallSettings callSettings = null) =>
            NestedArgs(new NestedRequest
            {
                TopLevelString = topLevelString ?? "",
                Nest1 = new NestedRequest.Types.Nest1
                {
                    AString = aString ?? "",
                    Nest2 = new NestedRequest.Types.Nest1.Types.Nest2
                    {
                        ANumber = aNumber,
                        AnotherNumber = anotherNumber,
                    },
                    NestOuter = new NestedOuter { ABool = aBool, },
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// </param>
        /// <param name="aNumber">
        /// </param>
        /// <param name="anotherNumber">
        /// </param>
        /// <param name="aBool">
        /// </param>
        /// <param name="topLevelString">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NestedArgsAsync(string aString, int aNumber, int anotherNumber, bool aBool, string topLevelString, gaxgrpc::CallSettings callSettings = null) =>
            NestedArgsAsync(new NestedRequest
            {
                TopLevelString = topLevelString ?? "",
                Nest1 = new NestedRequest.Types.Nest1
                {
                    AString = aString ?? "",
                    Nest2 = new NestedRequest.Types.Nest1.Types.Nest2
                    {
                        ANumber = aNumber,
                        AnotherNumber = anotherNumber,
                    },
                    NestOuter = new NestedOuter { ABool = aBool, },
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="aString">
        /// </param>
        /// <param name="aNumber">
        /// </param>
        /// <param name="anotherNumber">
        /// </param>
        /// <param name="aBool">
        /// </param>
        /// <param name="topLevelString">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NestedArgsAsync(string aString, int aNumber, int anotherNumber, bool aBool, string topLevelString, st::CancellationToken cancellationToken) =>
            NestedArgsAsync(aString, aNumber, anotherNumber, aBool, topLevelString, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WktArgs(WktRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WktArgsAsync(WktRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WktArgsAsync(WktRequest request, st::CancellationToken cancellationToken) =>
            WktArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="optionalInt32">
        /// </param>
        /// <param name="requiredInt32">
        /// </param>
        /// <param name="repeatedOptionalInt32">
        /// </param>
        /// <param name="repeatedRequiredInt32">
        /// </param>
        /// <param name="optionalString">
        /// </param>
        /// <param name="requiredString">
        /// </param>
        /// <param name="repeatedOptionalString">
        /// </param>
        /// <param name="repeatedRequiredString">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WktArgs(int? optionalInt32, int? requiredInt32, scg::IEnumerable<int?> repeatedOptionalInt32, scg::IEnumerable<int?> repeatedRequiredInt32, string optionalString, string requiredString, scg::IEnumerable<string> repeatedOptionalString, scg::IEnumerable<string> repeatedRequiredString, gaxgrpc::CallSettings callSettings = null) =>
            WktArgs(new WktRequest
            {
                OptionalInt32 = optionalInt32,
                RequiredInt32 = requiredInt32 ?? throw new sys::ArgumentNullException(nameof(requiredInt32)),
                RepeatedOptionalInt32 =
                {
                    repeatedOptionalInt32 ?? linq::Enumerable.Empty<int?>(),
                },
                RepeatedRequiredInt32 =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequiredInt32, nameof(repeatedRequiredInt32)),
                },
                OptionalString = optionalString,
                RequiredString = gax::GaxPreconditions.CheckNotNull(requiredString, nameof(requiredString)),
                RepeatedOptionalString =
                {
                    repeatedOptionalString ?? linq::Enumerable.Empty<string>(),
                },
                RepeatedRequiredString =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequiredString, nameof(repeatedRequiredString)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optionalInt32">
        /// </param>
        /// <param name="requiredInt32">
        /// </param>
        /// <param name="repeatedOptionalInt32">
        /// </param>
        /// <param name="repeatedRequiredInt32">
        /// </param>
        /// <param name="optionalString">
        /// </param>
        /// <param name="requiredString">
        /// </param>
        /// <param name="repeatedOptionalString">
        /// </param>
        /// <param name="repeatedRequiredString">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WktArgsAsync(int? optionalInt32, int? requiredInt32, scg::IEnumerable<int?> repeatedOptionalInt32, scg::IEnumerable<int?> repeatedRequiredInt32, string optionalString, string requiredString, scg::IEnumerable<string> repeatedOptionalString, scg::IEnumerable<string> repeatedRequiredString, gaxgrpc::CallSettings callSettings = null) =>
            WktArgsAsync(new WktRequest
            {
                OptionalInt32 = optionalInt32,
                RequiredInt32 = requiredInt32 ?? throw new sys::ArgumentNullException(nameof(requiredInt32)),
                RepeatedOptionalInt32 =
                {
                    repeatedOptionalInt32 ?? linq::Enumerable.Empty<int?>(),
                },
                RepeatedRequiredInt32 =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequiredInt32, nameof(repeatedRequiredInt32)),
                },
                OptionalString = optionalString,
                RequiredString = gax::GaxPreconditions.CheckNotNull(requiredString, nameof(requiredString)),
                RepeatedOptionalString =
                {
                    repeatedOptionalString ?? linq::Enumerable.Empty<string>(),
                },
                RepeatedRequiredString =
                {
                    gax::GaxPreconditions.CheckNotNull(repeatedRequiredString, nameof(repeatedRequiredString)),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="optionalInt32">
        /// </param>
        /// <param name="requiredInt32">
        /// </param>
        /// <param name="repeatedOptionalInt32">
        /// </param>
        /// <param name="repeatedRequiredInt32">
        /// </param>
        /// <param name="optionalString">
        /// </param>
        /// <param name="requiredString">
        /// </param>
        /// <param name="repeatedOptionalString">
        /// </param>
        /// <param name="repeatedRequiredString">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WktArgsAsync(int? optionalInt32, int? requiredInt32, scg::IEnumerable<int?> repeatedOptionalInt32, scg::IEnumerable<int?> repeatedRequiredInt32, string optionalString, string requiredString, scg::IEnumerable<string> repeatedOptionalString, scg::IEnumerable<string> repeatedRequiredString, st::CancellationToken cancellationToken) =>
            WktArgsAsync(optionalInt32, requiredInt32, repeatedOptionalInt32, repeatedRequiredInt32, optionalString, requiredString, repeatedOptionalString, repeatedRequiredString, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>MethodSignatures client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class MethodSignaturesClientImpl : MethodSignaturesClient
    {
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callSimpleMethod;

        private readonly gaxgrpc::ApiCall<PrimitiveRequest, Response> _callPrimitiveArgs;

        private readonly gaxgrpc::ApiCall<StringRequest, Response> _callStringArgs;

        private readonly gaxgrpc::ApiCall<BytesRequest, Response> _callBytesArgs;

        private readonly gaxgrpc::ApiCall<MessageRequest, Response> _callMessageArgs;

        private readonly gaxgrpc::ApiCall<MapRequest, Response> _callMapArgs;

        private readonly gaxgrpc::ApiCall<EnumRequest, Response> _callEnumArgs;

        private readonly gaxgrpc::ApiCall<NestedRequest, Response> _callNestedArgs;

        private readonly gaxgrpc::ApiCall<WktRequest, Response> _callWktArgs;

        /// <summary>
        /// Constructs a client wrapper for the MethodSignatures service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="MethodSignaturesSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public MethodSignaturesClientImpl(MethodSignatures.MethodSignaturesClient grpcClient, MethodSignaturesSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            MethodSignaturesSettings effectiveSettings = settings ?? MethodSignaturesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callSimpleMethod = clientHelper.BuildApiCall<SimpleRequest, Response>("SimpleMethod", grpcClient.SimpleMethodAsync, grpcClient.SimpleMethod, effectiveSettings.SimpleMethodSettings);
            Modify_ApiCall(ref _callSimpleMethod);
            Modify_SimpleMethodApiCall(ref _callSimpleMethod);
            _callPrimitiveArgs = clientHelper.BuildApiCall<PrimitiveRequest, Response>("PrimitiveArgs", grpcClient.PrimitiveArgsAsync, grpcClient.PrimitiveArgs, effectiveSettings.PrimitiveArgsSettings);
            Modify_ApiCall(ref _callPrimitiveArgs);
            Modify_PrimitiveArgsApiCall(ref _callPrimitiveArgs);
            _callStringArgs = clientHelper.BuildApiCall<StringRequest, Response>("StringArgs", grpcClient.StringArgsAsync, grpcClient.StringArgs, effectiveSettings.StringArgsSettings);
            Modify_ApiCall(ref _callStringArgs);
            Modify_StringArgsApiCall(ref _callStringArgs);
            _callBytesArgs = clientHelper.BuildApiCall<BytesRequest, Response>("BytesArgs", grpcClient.BytesArgsAsync, grpcClient.BytesArgs, effectiveSettings.BytesArgsSettings);
            Modify_ApiCall(ref _callBytesArgs);
            Modify_BytesArgsApiCall(ref _callBytesArgs);
            _callMessageArgs = clientHelper.BuildApiCall<MessageRequest, Response>("MessageArgs", grpcClient.MessageArgsAsync, grpcClient.MessageArgs, effectiveSettings.MessageArgsSettings);
            Modify_ApiCall(ref _callMessageArgs);
            Modify_MessageArgsApiCall(ref _callMessageArgs);
            _callMapArgs = clientHelper.BuildApiCall<MapRequest, Response>("MapArgs", grpcClient.MapArgsAsync, grpcClient.MapArgs, effectiveSettings.MapArgsSettings);
            Modify_ApiCall(ref _callMapArgs);
            Modify_MapArgsApiCall(ref _callMapArgs);
            _callEnumArgs = clientHelper.BuildApiCall<EnumRequest, Response>("EnumArgs", grpcClient.EnumArgsAsync, grpcClient.EnumArgs, effectiveSettings.EnumArgsSettings);
            Modify_ApiCall(ref _callEnumArgs);
            Modify_EnumArgsApiCall(ref _callEnumArgs);
            _callNestedArgs = clientHelper.BuildApiCall<NestedRequest, Response>("NestedArgs", grpcClient.NestedArgsAsync, grpcClient.NestedArgs, effectiveSettings.NestedArgsSettings);
            Modify_ApiCall(ref _callNestedArgs);
            Modify_NestedArgsApiCall(ref _callNestedArgs);
            _callWktArgs = clientHelper.BuildApiCall<WktRequest, Response>("WktArgs", grpcClient.WktArgsAsync, grpcClient.WktArgs, effectiveSettings.WktArgsSettings);
            Modify_ApiCall(ref _callWktArgs);
            Modify_WktArgsApiCall(ref _callWktArgs);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_SimpleMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);

        partial void Modify_PrimitiveArgsApiCall(ref gaxgrpc::ApiCall<PrimitiveRequest, Response> call);

        partial void Modify_StringArgsApiCall(ref gaxgrpc::ApiCall<StringRequest, Response> call);

        partial void Modify_BytesArgsApiCall(ref gaxgrpc::ApiCall<BytesRequest, Response> call);

        partial void Modify_MessageArgsApiCall(ref gaxgrpc::ApiCall<MessageRequest, Response> call);

        partial void Modify_MapArgsApiCall(ref gaxgrpc::ApiCall<MapRequest, Response> call);

        partial void Modify_EnumArgsApiCall(ref gaxgrpc::ApiCall<EnumRequest, Response> call);

        partial void Modify_NestedArgsApiCall(ref gaxgrpc::ApiCall<NestedRequest, Response> call);

        partial void Modify_WktArgsApiCall(ref gaxgrpc::ApiCall<WktRequest, Response> call);

        partial void OnConstruction(MethodSignatures.MethodSignaturesClient grpcClient, MethodSignaturesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC MethodSignatures client</summary>
        public override MethodSignatures.MethodSignaturesClient GrpcClient { get; }

        partial void Modify_SimpleRequest(ref SimpleRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PrimitiveRequest(ref PrimitiveRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_StringRequest(ref StringRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_BytesRequest(ref BytesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_MessageRequest(ref MessageRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_MapRequest(ref MapRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_EnumRequest(ref EnumRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_NestedRequest(ref NestedRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_WktRequest(ref WktRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response SimpleMethod(SimpleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SimpleRequest(ref request, ref callSettings);
            return _callSimpleMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> SimpleMethodAsync(SimpleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SimpleRequest(ref request, ref callSettings);
            return _callSimpleMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response PrimitiveArgs(PrimitiveRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PrimitiveRequest(ref request, ref callSettings);
            return _callPrimitiveArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> PrimitiveArgsAsync(PrimitiveRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PrimitiveRequest(ref request, ref callSettings);
            return _callPrimitiveArgs.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response StringArgs(StringRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_StringRequest(ref request, ref callSettings);
            return _callStringArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> StringArgsAsync(StringRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_StringRequest(ref request, ref callSettings);
            return _callStringArgs.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response BytesArgs(BytesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_BytesRequest(ref request, ref callSettings);
            return _callBytesArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> BytesArgsAsync(BytesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_BytesRequest(ref request, ref callSettings);
            return _callBytesArgs.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response MessageArgs(MessageRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_MessageRequest(ref request, ref callSettings);
            return _callMessageArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> MessageArgsAsync(MessageRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_MessageRequest(ref request, ref callSettings);
            return _callMessageArgs.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response MapArgs(MapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_MapRequest(ref request, ref callSettings);
            return _callMapArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> MapArgsAsync(MapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_MapRequest(ref request, ref callSettings);
            return _callMapArgs.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response EnumArgs(EnumRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_EnumRequest(ref request, ref callSettings);
            return _callEnumArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> EnumArgsAsync(EnumRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_EnumRequest(ref request, ref callSettings);
            return _callEnumArgs.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response NestedArgs(NestedRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_NestedRequest(ref request, ref callSettings);
            return _callNestedArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> NestedArgsAsync(NestedRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_NestedRequest(ref request, ref callSettings);
            return _callNestedArgs.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response WktArgs(WktRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WktRequest(ref request, ref callSettings);
            return _callWktArgs.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> WktArgsAsync(WktRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WktRequest(ref request, ref callSettings);
            return _callWktArgs.Async(request, callSettings);
        }
    }
}
