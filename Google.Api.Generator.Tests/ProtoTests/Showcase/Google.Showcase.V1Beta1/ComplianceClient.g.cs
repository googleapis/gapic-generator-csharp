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

namespace Google.Showcase.V1Beta1
{
    /// <summary>Settings for <see cref="ComplianceClient"/> instances.</summary>
    public sealed partial class ComplianceSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="ComplianceSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="ComplianceSettings"/>.</returns>
        public static ComplianceSettings GetDefault() => new ComplianceSettings();

        /// <summary>Constructs a new <see cref="ComplianceSettings"/> object with default settings.</summary>
        public ComplianceSettings()
        {
        }

        private ComplianceSettings(ComplianceSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            RepeatDataBodySettings = existing.RepeatDataBodySettings;
            RepeatDataBodyInfoSettings = existing.RepeatDataBodyInfoSettings;
            RepeatDataQuerySettings = existing.RepeatDataQuerySettings;
            RepeatDataSimplePathSettings = existing.RepeatDataSimplePathSettings;
            RepeatDataPathResourceSettings = existing.RepeatDataPathResourceSettings;
            RepeatDataPathTrailingResourceSettings = existing.RepeatDataPathTrailingResourceSettings;
            RepeatDataBodyPutSettings = existing.RepeatDataBodyPutSettings;
            RepeatDataBodyPatchSettings = existing.RepeatDataBodyPatchSettings;
            OnCopy(existing);
        }

        partial void OnCopy(ComplianceSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataBody</c> and <c>ComplianceClient.RepeatDataBodyAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataBodySettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataBodyInfo</c> and <c>ComplianceClient.RepeatDataBodyInfoAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataBodyInfoSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataQuery</c> and <c>ComplianceClient.RepeatDataQueryAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataQuerySettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataSimplePath</c> and <c>ComplianceClient.RepeatDataSimplePathAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataSimplePathSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataPathResource</c> and <c>ComplianceClient.RepeatDataPathResourceAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataPathResourceSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataPathTrailingResource</c> and
        /// <c>ComplianceClient.RepeatDataPathTrailingResourceAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataPathTrailingResourceSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataBodyPut</c> and <c>ComplianceClient.RepeatDataBodyPutAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataBodyPutSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ComplianceClient.RepeatDataBodyPatch</c> and <c>ComplianceClient.RepeatDataBodyPatchAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RepeatDataBodyPatchSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="ComplianceSettings"/> object.</returns>
        public ComplianceSettings Clone() => new ComplianceSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="ComplianceClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class ComplianceClientBuilder : gaxgrpc::ClientBuilderBase<ComplianceClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public ComplianceSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public ComplianceClientBuilder() : base(ComplianceClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref ComplianceClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<ComplianceClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override ComplianceClient Build()
        {
            ComplianceClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<ComplianceClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<ComplianceClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private ComplianceClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return ComplianceClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<ComplianceClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return ComplianceClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => ComplianceClient.ChannelPool;
    }

    /// <summary>Compliance client wrapper, for convenient use.</summary>
    /// <remarks>
    /// This service is used to test that GAPICs can transcode proto3 requests to
    /// REST format correctly for various types of HTTP annotations.
    /// </remarks>
    public abstract partial class ComplianceClient
    {
        /// <summary>
        /// The default endpoint for the Compliance service, which is a host of "localhost:7469" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "localhost:7469:443";

        /// <summary>The default Compliance scopes.</summary>
        /// <remarks>The default Compliance scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Compliance.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="ComplianceClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="ComplianceClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="ComplianceClient"/>.</returns>
        public static stt::Task<ComplianceClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new ComplianceClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="ComplianceClient"/> using the default credentials, endpoint and settings.
        /// To specify custom credentials or other settings, use <see cref="ComplianceClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="ComplianceClient"/>.</returns>
        public static ComplianceClient Create() => new ComplianceClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="ComplianceClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="ComplianceSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="ComplianceClient"/>.</returns>
        internal static ComplianceClient Create(grpccore::CallInvoker callInvoker, ComplianceSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Compliance.ComplianceClient grpcClient = new Compliance.ComplianceClient(callInvoker);
            return new ComplianceClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC Compliance client</summary>
        public virtual Compliance.ComplianceClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the entire request object in the REST body.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataBody(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the entire request object in the REST body.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the entire request object in the REST body.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataBodyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the a message-type field in the REST body. Per AIP-127, only
        /// top-level, non-repeated fields can be sent this way.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataBodyInfo(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the a message-type field in the REST body. Per AIP-127, only
        /// top-level, non-repeated fields can be sent this way.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyInfoAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the a message-type field in the REST body. Per AIP-127, only
        /// top-level, non-repeated fields can be sent this way.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyInfoAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataBodyInfoAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending all request fields as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataQuery(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending all request fields as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataQueryAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending all request fields as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataQueryAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataQueryAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending some parameters as "simple" path variables (i.e., of the form
        /// "/bar/{foo}" rather than "/{foo=bar/*}"), and the rest as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataSimplePath(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending some parameters as "simple" path variables (i.e., of the form
        /// "/bar/{foo}" rather than "/{foo=bar/*}"), and the rest as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataSimplePathAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending some parameters as "simple" path variables (i.e., of the form
        /// "/bar/{foo}" rather than "/{foo=bar/*}"), and the rest as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataSimplePathAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataSimplePathAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a path resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataPathResource(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a path resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataPathResourceAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a path resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataPathResourceAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataPathResourceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a trailing resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataPathTrailingResource(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a trailing resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataPathTrailingResourceAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a trailing resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataPathTrailingResourceAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataPathTrailingResourceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PUT method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataBodyPut(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PUT method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyPutAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PUT method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyPutAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataBodyPutAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PATCH method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RepeatResponse RepeatDataBodyPatch(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PATCH method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyPatchAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PATCH method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RepeatResponse> RepeatDataBodyPatchAsync(RepeatRequest request, st::CancellationToken cancellationToken) =>
            RepeatDataBodyPatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Compliance client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// This service is used to test that GAPICs can transcode proto3 requests to
    /// REST format correctly for various types of HTTP annotations.
    /// </remarks>
    public sealed partial class ComplianceClientImpl : ComplianceClient
    {
        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataBody;

        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataBodyInfo;

        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataQuery;

        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataSimplePath;

        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataPathResource;

        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataPathTrailingResource;

        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataBodyPut;

        private readonly gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> _callRepeatDataBodyPatch;

        /// <summary>
        /// Constructs a client wrapper for the Compliance service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="ComplianceSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public ComplianceClientImpl(Compliance.ComplianceClient grpcClient, ComplianceSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            ComplianceSettings effectiveSettings = settings ?? ComplianceSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callRepeatDataBody = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataBody", grpcClient.RepeatDataBodyAsync, grpcClient.RepeatDataBody, effectiveSettings.RepeatDataBodySettings);
            Modify_ApiCall(ref _callRepeatDataBody);
            Modify_RepeatDataBodyApiCall(ref _callRepeatDataBody);
            _callRepeatDataBodyInfo = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataBodyInfo", grpcClient.RepeatDataBodyInfoAsync, grpcClient.RepeatDataBodyInfo, effectiveSettings.RepeatDataBodyInfoSettings);
            Modify_ApiCall(ref _callRepeatDataBodyInfo);
            Modify_RepeatDataBodyInfoApiCall(ref _callRepeatDataBodyInfo);
            _callRepeatDataQuery = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataQuery", grpcClient.RepeatDataQueryAsync, grpcClient.RepeatDataQuery, effectiveSettings.RepeatDataQuerySettings);
            Modify_ApiCall(ref _callRepeatDataQuery);
            Modify_RepeatDataQueryApiCall(ref _callRepeatDataQuery);
            _callRepeatDataSimplePath = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataSimplePath", grpcClient.RepeatDataSimplePathAsync, grpcClient.RepeatDataSimplePath, effectiveSettings.RepeatDataSimplePathSettings).WithGoogleRequestParam("info.f_string", request => request.Info?.FString);
            Modify_ApiCall(ref _callRepeatDataSimplePath);
            Modify_RepeatDataSimplePathApiCall(ref _callRepeatDataSimplePath);
            _callRepeatDataPathResource = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataPathResource", grpcClient.RepeatDataPathResourceAsync, grpcClient.RepeatDataPathResource, effectiveSettings.RepeatDataPathResourceSettings).WithGoogleRequestParam("info.f_string", request => request.Info?.FString).WithGoogleRequestParam("info.f_child.f_string", request => request.Info?.FChild?.FString);
            Modify_ApiCall(ref _callRepeatDataPathResource);
            Modify_RepeatDataPathResourceApiCall(ref _callRepeatDataPathResource);
            _callRepeatDataPathTrailingResource = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataPathTrailingResource", grpcClient.RepeatDataPathTrailingResourceAsync, grpcClient.RepeatDataPathTrailingResource, effectiveSettings.RepeatDataPathTrailingResourceSettings).WithGoogleRequestParam("info.f_string", request => request.Info?.FString).WithGoogleRequestParam("info.f_child.f_string", request => request.Info?.FChild?.FString);
            Modify_ApiCall(ref _callRepeatDataPathTrailingResource);
            Modify_RepeatDataPathTrailingResourceApiCall(ref _callRepeatDataPathTrailingResource);
            _callRepeatDataBodyPut = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataBodyPut", grpcClient.RepeatDataBodyPutAsync, grpcClient.RepeatDataBodyPut, effectiveSettings.RepeatDataBodyPutSettings);
            Modify_ApiCall(ref _callRepeatDataBodyPut);
            Modify_RepeatDataBodyPutApiCall(ref _callRepeatDataBodyPut);
            _callRepeatDataBodyPatch = clientHelper.BuildApiCall<RepeatRequest, RepeatResponse>("RepeatDataBodyPatch", grpcClient.RepeatDataBodyPatchAsync, grpcClient.RepeatDataBodyPatch, effectiveSettings.RepeatDataBodyPatchSettings);
            Modify_ApiCall(ref _callRepeatDataBodyPatch);
            Modify_RepeatDataBodyPatchApiCall(ref _callRepeatDataBodyPatch);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_RepeatDataBodyApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void Modify_RepeatDataBodyInfoApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void Modify_RepeatDataQueryApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void Modify_RepeatDataSimplePathApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void Modify_RepeatDataPathResourceApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void Modify_RepeatDataPathTrailingResourceApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void Modify_RepeatDataBodyPutApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void Modify_RepeatDataBodyPatchApiCall(ref gaxgrpc::ApiCall<RepeatRequest, RepeatResponse> call);

        partial void OnConstruction(Compliance.ComplianceClient grpcClient, ComplianceSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Compliance client</summary>
        public override Compliance.ComplianceClient GrpcClient { get; }

        partial void Modify_RepeatRequest(ref RepeatRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the entire request object in the REST body.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataBody(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBody.Sync(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the entire request object in the REST body.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataBodyAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBody.Async(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the a message-type field in the REST body. Per AIP-127, only
        /// top-level, non-repeated fields can be sent this way.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataBodyInfo(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBodyInfo.Sync(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending the a message-type field in the REST body. Per AIP-127, only
        /// top-level, non-repeated fields can be sent this way.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataBodyInfoAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBodyInfo.Async(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending all request fields as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataQuery(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataQuery.Sync(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending all request fields as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataQueryAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataQuery.Async(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending some parameters as "simple" path variables (i.e., of the form
        /// "/bar/{foo}" rather than "/{foo=bar/*}"), and the rest as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataSimplePath(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataSimplePath.Sync(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request. This method exercises
        /// sending some parameters as "simple" path variables (i.e., of the form
        /// "/bar/{foo}" rather than "/{foo=bar/*}"), and the rest as query parameters.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataSimplePathAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataSimplePath.Async(request, callSettings);
        }

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a path resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataPathResource(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataPathResource.Sync(request, callSettings);
        }

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a path resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataPathResourceAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataPathResource.Async(request, callSettings);
        }

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a trailing resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataPathTrailingResource(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataPathTrailingResource.Sync(request, callSettings);
        }

        /// <summary>
        /// Same as RepeatDataSimplePath, but with a trailing resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataPathTrailingResourceAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataPathTrailingResource.Async(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PUT method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataBodyPut(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBodyPut.Sync(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PUT method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataBodyPutAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBodyPut.Async(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PATCH method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RepeatResponse RepeatDataBodyPatch(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBodyPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// This method echoes the ComplianceData request, using the HTTP PATCH method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RepeatResponse> RepeatDataBodyPatchAsync(RepeatRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RepeatRequest(ref request, ref callSettings);
            return _callRepeatDataBodyPatch.Async(request, callSettings);
        }
    }
}
