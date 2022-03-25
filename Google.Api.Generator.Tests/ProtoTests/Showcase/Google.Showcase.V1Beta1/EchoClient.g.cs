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
using lro = Google.LongRunning;
using proto = Google.Protobuf;
using gr = Google.Rpc;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using sys = System;
using sc = System.Collections;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Settings for <see cref="EchoClient"/> instances.</summary>
    public sealed partial class EchoSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="EchoSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="EchoSettings"/>.</returns>
        public static EchoSettings GetDefault() => new EchoSettings();

        /// <summary>Constructs a new <see cref="EchoSettings"/> object with default settings.</summary>
        public EchoSettings()
        {
        }

        private EchoSettings(EchoSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            EchoCallSettings = existing.EchoCallSettings;
            ExpandSettings = existing.ExpandSettings;
            CollectSettings = existing.CollectSettings;
            CollectStreamingSettings = existing.CollectStreamingSettings;
            ChatSettings = existing.ChatSettings;
            ChatStreamingSettings = existing.ChatStreamingSettings;
            PagedExpandSettings = existing.PagedExpandSettings;
            PagedExpandLegacySettings = existing.PagedExpandLegacySettings;
            PagedExpandLegacyMappedSettings = existing.PagedExpandLegacyMappedSettings;
            WaitSettings = existing.WaitSettings;
            WaitOperationsSettings = existing.WaitOperationsSettings.Clone();
            BlockSettings = existing.BlockSettings;
            OnCopy(existing);
        }

        partial void OnCopy(EchoSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>EchoClient.EchoCall</c> and
        /// <c>EchoClient.EchoCallAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings EchoCallSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>EchoClient.Expand</c> and
        /// <c>EchoClient.ExpandAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ExpandSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>EchoClient.Collect</c> and
        /// <c>EchoClient.CollectAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CollectSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::ClientStreamingSettings"/> for calls to <c>EchoClient.Collect</c> and
        /// <c>EchoClient.CollectAsync</c>.
        /// </summary>
        /// <remarks>The default local send queue size is 100.</remarks>
        public gaxgrpc::ClientStreamingSettings CollectStreamingSettings { get; set; } = new gaxgrpc::ClientStreamingSettings(100);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>EchoClient.Chat</c> and
        /// <c>EchoClient.ChatAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ChatSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::BidirectionalStreamingSettings"/> for calls to <c>EchoClient.Chat</c> and
        /// <c>EchoClient.ChatAsync</c>.
        /// </summary>
        /// <remarks>The default local send queue size is 100.</remarks>
        public gaxgrpc::BidirectionalStreamingSettings ChatStreamingSettings { get; set; } = new gaxgrpc::BidirectionalStreamingSettings(100);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>EchoClient.PagedExpand</c>
        /// and <c>EchoClient.PagedExpandAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PagedExpandSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>EchoClient.PagedExpandLegacy</c> and <c>EchoClient.PagedExpandLegacyAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PagedExpandLegacySettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>EchoClient.PagedExpandLegacyMapped</c> and <c>EchoClient.PagedExpandLegacyMappedAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PagedExpandLegacyMappedSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>EchoClient.Wait</c> and
        /// <c>EchoClient.WaitAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings WaitSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// Long Running Operation settings for calls to <c>EchoClient.Wait</c> and <c>EchoClient.WaitAsync</c>.
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
        public lro::OperationsSettings WaitOperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>EchoClient.Block</c> and
        /// <c>EchoClient.BlockAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings BlockSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="EchoSettings"/> object.</returns>
        public EchoSettings Clone() => new EchoSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="EchoClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class EchoClientBuilder : gaxgrpc::ClientBuilderBase<EchoClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public EchoSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public EchoClientBuilder()
        {
        }

        partial void InterceptBuild(ref EchoClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<EchoClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override EchoClient Build()
        {
            EchoClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<EchoClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<EchoClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private EchoClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return EchoClient.Create(callInvoker, Settings);
        }

        private async stt::Task<EchoClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return EchoClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => EchoClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => EchoClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => EchoClient.ChannelPool;

        /// <summary>Returns the API descriptor for this API.</summary>
        protected override gaxgrpc::ApiDescriptor ApiDescriptor => GaxApiDescriptor.ApiDescriptor;
    }

    /// <summary>Echo client wrapper, for convenient use.</summary>
    /// <remarks>
    /// This service is used showcase the four main types of rpcs - unary, server
    /// side streaming, client side streaming, and bidirectional streaming. This
    /// service also exposes methods that explicitly implement server delay, and
    /// paginated calls. Set the 'showcase-trailer' metadata key on any method
    /// to have the values echoed in the response trailers. Set the
    /// 'x-goog-request-params' metadata key on any method to have the values
    /// echoed in the response headers.
    /// </remarks>
    public abstract partial class EchoClient
    {
        /// <summary>
        /// The default endpoint for the Echo service, which is a host of "localhost:7469" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "localhost:7469:443";

        /// <summary>The default Echo scopes.</summary>
        /// <remarks>The default Echo scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(GaxApiDescriptor.ApiDescriptor, DefaultScopes, true);

        /// <summary>
        /// Asynchronously creates a <see cref="EchoClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="EchoClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="EchoClient"/>.</returns>
        public static stt::Task<EchoClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new EchoClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="EchoClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="EchoClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="EchoClient"/>.</returns>
        public static EchoClient Create() => new EchoClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="EchoClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="EchoSettings"/>.</param>
        /// <returns>The created <see cref="EchoClient"/>.</returns>
        internal static EchoClient Create(grpccore::CallInvoker callInvoker, EchoSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Echo.EchoClient grpcClient = new Echo.EchoClient(callInvoker);
            return new EchoClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC Echo client</summary>
        public virtual Echo.EchoClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// This method simply echoes the request. This method showcases unary RPCs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual EchoResponse EchoCall(EchoRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method simply echoes the request. This method showcases unary RPCs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EchoResponse> EchoCallAsync(EchoRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method simply echoes the request. This method showcases unary RPCs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<EchoResponse> EchoCallAsync(EchoRequest request, st::CancellationToken cancellationToken) =>
            EchoCallAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>Server streaming methods for <see cref="Expand(ExpandRequest,gaxgrpc::CallSettings)"/>.</summary>
        public abstract partial class ExpandStream : gaxgrpc::ServerStreamingBase<EchoResponse>
        {
        }

        /// <summary>
        /// This method splits the given content into words and will pass each word back
        /// through the stream. This method showcases server-side streaming RPCs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual ExpandStream Expand(ExpandRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method splits the given content into words and will pass each word back
        /// through the stream. This method showcases server-side streaming RPCs.
        /// </summary>
        /// <param name="content">
        /// The content that will be split into words and returned on the stream.
        /// </param>
        /// <param name="error">
        /// The error that is thrown after all words are sent on the stream.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual ExpandStream Expand(string content, gr::Status error, gaxgrpc::CallSettings callSettings = null) =>
            Expand(new ExpandRequest
            {
                Content = content ?? "",
                Error = error,
            }, callSettings);

        /// <summary>
        /// Client streaming methods for <see cref="Collect(gaxgrpc::CallSettings,gaxgrpc::ClientStreamingSettings)"/>.
        /// </summary>
        public abstract partial class CollectStream : gaxgrpc::ClientStreamingBase<EchoRequest, EchoResponse>
        {
        }

        /// <summary>
        /// This method will collect the words given to it. When the stream is closed
        /// by the client, this method will return the a concatenation of the strings
        /// passed to it. This method showcases client-side streaming RPCs.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public virtual CollectStream Collect(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Bidirectional streaming methods for
        /// <see cref="Chat(gaxgrpc::CallSettings,gaxgrpc::BidirectionalStreamingSettings)"/>.
        /// </summary>
        public abstract partial class ChatStream : gaxgrpc::BidirectionalStreamingBase<EchoRequest, EchoResponse>
        {
        }

        /// <summary>
        /// This method, upon receiving a request on the stream, will pass the same
        /// content back on the stream. This method showcases bidirectional
        /// streaming RPCs.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public virtual ChatStream Chat(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This is similar to the Expand method but instead of returning a stream of
        /// expanded words, this method returns a paged list of expanded words.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="EchoResponse"/> resources.</returns>
        public virtual gax::PagedEnumerable<PagedExpandResponse, EchoResponse> PagedExpand(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This is similar to the Expand method but instead of returning a stream of
        /// expanded words, this method returns a paged list of expanded words.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="EchoResponse"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<PagedExpandResponse, EchoResponse> PagedExpandAsync(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This is similar to the PagedExpand except that it uses
        /// max_results instead of page_size, as some legacy APIs still
        /// do. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="EchoResponse"/> resources.</returns>
        public virtual gax::PagedEnumerable<PagedExpandResponse, EchoResponse> PagedExpandLegacy(PagedExpandLegacyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This is similar to the PagedExpand except that it uses
        /// max_results instead of page_size, as some legacy APIs still
        /// do. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="EchoResponse"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<PagedExpandResponse, EchoResponse> PagedExpandLegacyAsync(PagedExpandLegacyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method returns a map containing lists of words that appear in the input, keyed by their
        /// initial character. The only words returned are the ones included in the current page,
        /// as determined by page_token and page_size, which both refer to the word indices in the
        /// input. This paging result consisting of a map of lists is a pattern used by some legacy
        /// APIs. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="scg::KeyValuePair{TKey,TValue}"/> resources.</returns>
        public virtual gax::PagedEnumerable<PagedExpandLegacyMappedResponse, scg::KeyValuePair<string, PagedExpandResponseList>> PagedExpandLegacyMapped(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method returns a map containing lists of words that appear in the input, keyed by their
        /// initial character. The only words returned are the ones included in the current page,
        /// as determined by page_token and page_size, which both refer to the word indices in the
        /// input. This paging result consisting of a map of lists is a pattern used by some legacy
        /// APIs. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>
        /// A pageable asynchronous sequence of <see cref="scg::KeyValuePair{TKey,TValue}"/> resources.
        /// </returns>
        public virtual gax::PagedAsyncEnumerable<PagedExpandLegacyMappedResponse, scg::KeyValuePair<string, PagedExpandResponseList>> PagedExpandLegacyMappedAsync(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method will wait for the requested amount of time and then return.
        /// This method showcases how a client handles a request timeout.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<WaitResponse, WaitMetadata> Wait(WaitRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method will wait for the requested amount of time and then return.
        /// This method showcases how a client handles a request timeout.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<WaitResponse, WaitMetadata>> WaitAsync(WaitRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method will wait for the requested amount of time and then return.
        /// This method showcases how a client handles a request timeout.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<WaitResponse, WaitMetadata>> WaitAsync(WaitRequest request, st::CancellationToken cancellationToken) =>
            WaitAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>Wait</c>.</summary>
        public virtual lro::OperationsClient WaitOperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of <c>Wait</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<WaitResponse, WaitMetadata> PollOnceWait(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<WaitResponse, WaitMetadata>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), WaitOperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of <c>Wait</c>
        /// .
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<WaitResponse, WaitMetadata>> PollOnceWaitAsync(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<WaitResponse, WaitMetadata>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), WaitOperationsClient, callSettings);

        /// <summary>
        /// This method will block (wait) for the requested amount of time
        /// and then return the response or error.
        /// This method showcases how a client handles delays or retries.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BlockResponse Block(BlockRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method will block (wait) for the requested amount of time
        /// and then return the response or error.
        /// This method showcases how a client handles delays or retries.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BlockResponse> BlockAsync(BlockRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// This method will block (wait) for the requested amount of time
        /// and then return the response or error.
        /// This method showcases how a client handles delays or retries.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BlockResponse> BlockAsync(BlockRequest request, st::CancellationToken cancellationToken) =>
            BlockAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Echo client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// This service is used showcase the four main types of rpcs - unary, server
    /// side streaming, client side streaming, and bidirectional streaming. This
    /// service also exposes methods that explicitly implement server delay, and
    /// paginated calls. Set the 'showcase-trailer' metadata key on any method
    /// to have the values echoed in the response trailers. Set the
    /// 'x-goog-request-params' metadata key on any method to have the values
    /// echoed in the response headers.
    /// </remarks>
    public sealed partial class EchoClientImpl : EchoClient
    {
        private readonly gaxgrpc::ApiCall<EchoRequest, EchoResponse> _callEchoCall;

        private readonly gaxgrpc::ApiServerStreamingCall<ExpandRequest, EchoResponse> _callExpand;

        private readonly gaxgrpc::ApiClientStreamingCall<EchoRequest, EchoResponse> _callCollect;

        private readonly gaxgrpc::ApiBidirectionalStreamingCall<EchoRequest, EchoResponse> _callChat;

        private readonly gaxgrpc::ApiCall<PagedExpandRequest, PagedExpandResponse> _callPagedExpand;

        private readonly gaxgrpc::ApiCall<PagedExpandLegacyRequest, PagedExpandResponse> _callPagedExpandLegacy;

        private readonly gaxgrpc::ApiCall<PagedExpandRequest, PagedExpandLegacyMappedResponse> _callPagedExpandLegacyMapped;

        private readonly gaxgrpc::ApiCall<WaitRequest, lro::Operation> _callWait;

        private readonly gaxgrpc::ApiCall<BlockRequest, BlockResponse> _callBlock;

        /// <summary>
        /// Constructs a client wrapper for the Echo service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="EchoSettings"/> used within this client.</param>
        public EchoClientImpl(Echo.EchoClient grpcClient, EchoSettings settings)
        {
            GrpcClient = grpcClient;
            EchoSettings effectiveSettings = settings ?? EchoSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            WaitOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.WaitOperationsSettings);
            _callEchoCall = clientHelper.BuildApiCall<EchoRequest, EchoResponse>(grpcClient.EchoCallAsync, grpcClient.EchoCall, effectiveSettings.EchoCallSettings).WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<EchoRequest>().WithExtractedParameter("header", "^(.+)$", request => request.Header).WithExtractedParameter("routing_id", "^(.+)$", request => request.Header).WithExtractedParameter("table_name", "^(regions/[^/]+/zones/[^/]+(?:/.*)?)$", request => request.Header).WithExtractedParameter("table_name", "^(projects/[^/]+/instances/[^/]+(?:/.*)?)$", request => request.Header).WithExtractedParameter("super_id", "^(projects/[^/]+)(?:/.*)?$", request => request.Header).WithExtractedParameter("instance_id", "^projects/[^/]+/(instances/[^/]+)(?:/.*)?$", request => request.Header).WithExtractedParameter("baz", "^(.+)$", request => request.OtherHeader).WithExtractedParameter("qux", "^(projects/[^/]+)(?:/.*)?$", request => request.OtherHeader));
            Modify_ApiCall(ref _callEchoCall);
            Modify_EchoCallApiCall(ref _callEchoCall);
            _callExpand = clientHelper.BuildApiCall<ExpandRequest, EchoResponse>(grpcClient.Expand, effectiveSettings.ExpandSettings);
            Modify_ApiCall(ref _callExpand);
            Modify_ExpandApiCall(ref _callExpand);
            _callCollect = clientHelper.BuildApiCall<EchoRequest, EchoResponse>(grpcClient.Collect, effectiveSettings.CollectSettings, effectiveSettings.CollectStreamingSettings);
            Modify_ApiCall(ref _callCollect);
            Modify_CollectApiCall(ref _callCollect);
            _callChat = clientHelper.BuildApiCall<EchoRequest, EchoResponse>(grpcClient.Chat, effectiveSettings.ChatSettings, effectiveSettings.ChatStreamingSettings);
            Modify_ApiCall(ref _callChat);
            Modify_ChatApiCall(ref _callChat);
            _callPagedExpand = clientHelper.BuildApiCall<PagedExpandRequest, PagedExpandResponse>(grpcClient.PagedExpandAsync, grpcClient.PagedExpand, effectiveSettings.PagedExpandSettings);
            Modify_ApiCall(ref _callPagedExpand);
            Modify_PagedExpandApiCall(ref _callPagedExpand);
            _callPagedExpandLegacy = clientHelper.BuildApiCall<PagedExpandLegacyRequest, PagedExpandResponse>(grpcClient.PagedExpandLegacyAsync, grpcClient.PagedExpandLegacy, effectiveSettings.PagedExpandLegacySettings);
            Modify_ApiCall(ref _callPagedExpandLegacy);
            Modify_PagedExpandLegacyApiCall(ref _callPagedExpandLegacy);
            _callPagedExpandLegacyMapped = clientHelper.BuildApiCall<PagedExpandRequest, PagedExpandLegacyMappedResponse>(grpcClient.PagedExpandLegacyMappedAsync, grpcClient.PagedExpandLegacyMapped, effectiveSettings.PagedExpandLegacyMappedSettings);
            Modify_ApiCall(ref _callPagedExpandLegacyMapped);
            Modify_PagedExpandLegacyMappedApiCall(ref _callPagedExpandLegacyMapped);
            _callWait = clientHelper.BuildApiCall<WaitRequest, lro::Operation>(grpcClient.WaitAsync, grpcClient.Wait, effectiveSettings.WaitSettings);
            Modify_ApiCall(ref _callWait);
            Modify_WaitApiCall(ref _callWait);
            _callBlock = clientHelper.BuildApiCall<BlockRequest, BlockResponse>(grpcClient.BlockAsync, grpcClient.Block, effectiveSettings.BlockSettings);
            Modify_ApiCall(ref _callBlock);
            Modify_BlockApiCall(ref _callBlock);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiBidirectionalStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiServerStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiClientStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_EchoCallApiCall(ref gaxgrpc::ApiCall<EchoRequest, EchoResponse> call);

        partial void Modify_ExpandApiCall(ref gaxgrpc::ApiServerStreamingCall<ExpandRequest, EchoResponse> call);

        partial void Modify_CollectApiCall(ref gaxgrpc::ApiClientStreamingCall<EchoRequest, EchoResponse> call);

        partial void Modify_ChatApiCall(ref gaxgrpc::ApiBidirectionalStreamingCall<EchoRequest, EchoResponse> call);

        partial void Modify_PagedExpandApiCall(ref gaxgrpc::ApiCall<PagedExpandRequest, PagedExpandResponse> call);

        partial void Modify_PagedExpandLegacyApiCall(ref gaxgrpc::ApiCall<PagedExpandLegacyRequest, PagedExpandResponse> call);

        partial void Modify_PagedExpandLegacyMappedApiCall(ref gaxgrpc::ApiCall<PagedExpandRequest, PagedExpandLegacyMappedResponse> call);

        partial void Modify_WaitApiCall(ref gaxgrpc::ApiCall<WaitRequest, lro::Operation> call);

        partial void Modify_BlockApiCall(ref gaxgrpc::ApiCall<BlockRequest, BlockResponse> call);

        partial void OnConstruction(Echo.EchoClient grpcClient, EchoSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Echo client</summary>
        public override Echo.EchoClient GrpcClient { get; }

        partial void Modify_EchoRequest(ref EchoRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ExpandRequest(ref ExpandRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_EchoRequestCallSettings(ref gaxgrpc::CallSettings settings);

        partial void Modify_EchoRequestRequest(ref EchoRequest request);

        partial void Modify_PagedExpandRequest(ref PagedExpandRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PagedExpandLegacyRequest(ref PagedExpandLegacyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_WaitRequest(ref WaitRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_BlockRequest(ref BlockRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// This method simply echoes the request. This method showcases unary RPCs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override EchoResponse EchoCall(EchoRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_EchoRequest(ref request, ref callSettings);
            return _callEchoCall.Sync(request, callSettings);
        }

        /// <summary>
        /// This method simply echoes the request. This method showcases unary RPCs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<EchoResponse> EchoCallAsync(EchoRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_EchoRequest(ref request, ref callSettings);
            return _callEchoCall.Async(request, callSettings);
        }

        internal sealed partial class ExpandStreamImpl : ExpandStream
        {
            /// <summary>Construct the server streaming method for <c>Expand</c>.</summary>
            /// <param name="call">The underlying gRPC server streaming call.</param>
            public ExpandStreamImpl(grpccore::AsyncServerStreamingCall<EchoResponse> call) => GrpcCall = call;

            public override grpccore::AsyncServerStreamingCall<EchoResponse> GrpcCall { get; }
        }

        /// <summary>
        /// This method splits the given content into words and will pass each word back
        /// through the stream. This method showcases server-side streaming RPCs.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public override EchoClient.ExpandStream Expand(ExpandRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ExpandRequest(ref request, ref callSettings);
            return new ExpandStreamImpl(_callExpand.Call(request, callSettings));
        }

        internal sealed partial class CollectStreamImpl : CollectStream
        {
            /// <summary>Construct the client streaming method for <c>Collect</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC client streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{EchoRequest}"/> instance associated with this
            /// streaming call.
            /// </param>
            public CollectStreamImpl(EchoClientImpl service, grpccore::AsyncClientStreamingCall<EchoRequest, EchoResponse> call, gaxgrpc::BufferedClientStreamWriter<EchoRequest> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private EchoClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<EchoRequest> _writeBuffer;

            public override grpccore::AsyncClientStreamingCall<EchoRequest, EchoResponse> GrpcCall { get; }

            private EchoRequest ModifyRequest(EchoRequest request)
            {
                _service.Modify_EchoRequestRequest(ref request);
                return request;
            }

            public override stt::Task TryWriteAsync(EchoRequest message) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message));

            public override stt::Task WriteAsync(EchoRequest message) => _writeBuffer.WriteAsync(ModifyRequest(message));

            public override stt::Task TryWriteAsync(EchoRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message), options);

            public override stt::Task WriteAsync(EchoRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.WriteAsync(ModifyRequest(message), options);

            public override stt::Task TryWriteCompleteAsync() => _writeBuffer.TryWriteCompleteAsync();

            public override stt::Task WriteCompleteAsync() => _writeBuffer.WriteCompleteAsync();
        }

        /// <summary>
        /// This method will collect the words given to it. When the stream is closed
        /// by the client, this method will return the a concatenation of the strings
        /// passed to it. This method showcases client-side streaming RPCs.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public override EchoClient.CollectStream Collect(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null)
        {
            Modify_EchoRequestCallSettings(ref callSettings);
            gaxgrpc::ClientStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callCollect.StreamingSettings;
            grpccore::AsyncClientStreamingCall<EchoRequest, EchoResponse> call = _callCollect.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<EchoRequest> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<EchoRequest>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new CollectStreamImpl(this, call, writeBuffer);
        }

        internal sealed partial class ChatStreamImpl : ChatStream
        {
            /// <summary>Construct the bidirectional streaming method for <c>Chat</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC duplex streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{EchoRequest}"/> instance associated with this
            /// streaming call.
            /// </param>
            public ChatStreamImpl(EchoClientImpl service, grpccore::AsyncDuplexStreamingCall<EchoRequest, EchoResponse> call, gaxgrpc::BufferedClientStreamWriter<EchoRequest> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private EchoClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<EchoRequest> _writeBuffer;

            public override grpccore::AsyncDuplexStreamingCall<EchoRequest, EchoResponse> GrpcCall { get; }

            private EchoRequest ModifyRequest(EchoRequest request)
            {
                _service.Modify_EchoRequestRequest(ref request);
                return request;
            }

            public override stt::Task TryWriteAsync(EchoRequest message) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message));

            public override stt::Task WriteAsync(EchoRequest message) => _writeBuffer.WriteAsync(ModifyRequest(message));

            public override stt::Task TryWriteAsync(EchoRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message), options);

            public override stt::Task WriteAsync(EchoRequest message, grpccore::WriteOptions options) =>
                _writeBuffer.WriteAsync(ModifyRequest(message), options);

            public override stt::Task TryWriteCompleteAsync() => _writeBuffer.TryWriteCompleteAsync();

            public override stt::Task WriteCompleteAsync() => _writeBuffer.WriteCompleteAsync();
        }

        /// <summary>
        /// This method, upon receiving a request on the stream, will pass the same
        /// content back on the stream. This method showcases bidirectional
        /// streaming RPCs.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public override EchoClient.ChatStream Chat(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null)
        {
            Modify_EchoRequestCallSettings(ref callSettings);
            gaxgrpc::BidirectionalStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callChat.StreamingSettings;
            grpccore::AsyncDuplexStreamingCall<EchoRequest, EchoResponse> call = _callChat.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<EchoRequest> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<EchoRequest>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new ChatStreamImpl(this, call, writeBuffer);
        }

        /// <summary>
        /// This is similar to the Expand method but instead of returning a stream of
        /// expanded words, this method returns a paged list of expanded words.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="EchoResponse"/> resources.</returns>
        public override gax::PagedEnumerable<PagedExpandResponse, EchoResponse> PagedExpand(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PagedExpandRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<PagedExpandRequest, PagedExpandResponse, EchoResponse>(_callPagedExpand, request, callSettings);
        }

        /// <summary>
        /// This is similar to the Expand method but instead of returning a stream of
        /// expanded words, this method returns a paged list of expanded words.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="EchoResponse"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<PagedExpandResponse, EchoResponse> PagedExpandAsync(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PagedExpandRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<PagedExpandRequest, PagedExpandResponse, EchoResponse>(_callPagedExpand, request, callSettings);
        }

        /// <summary>
        /// This is similar to the PagedExpand except that it uses
        /// max_results instead of page_size, as some legacy APIs still
        /// do. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="EchoResponse"/> resources.</returns>
        public override gax::PagedEnumerable<PagedExpandResponse, EchoResponse> PagedExpandLegacy(PagedExpandLegacyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PagedExpandLegacyRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<PagedExpandLegacyRequest, PagedExpandResponse, EchoResponse>(_callPagedExpandLegacy, request, callSettings);
        }

        /// <summary>
        /// This is similar to the PagedExpand except that it uses
        /// max_results instead of page_size, as some legacy APIs still
        /// do. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="EchoResponse"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<PagedExpandResponse, EchoResponse> PagedExpandLegacyAsync(PagedExpandLegacyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PagedExpandLegacyRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<PagedExpandLegacyRequest, PagedExpandResponse, EchoResponse>(_callPagedExpandLegacy, request, callSettings);
        }

        /// <summary>
        /// This method returns a map containing lists of words that appear in the input, keyed by their
        /// initial character. The only words returned are the ones included in the current page,
        /// as determined by page_token and page_size, which both refer to the word indices in the
        /// input. This paging result consisting of a map of lists is a pattern used by some legacy
        /// APIs. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="scg::KeyValuePair{TKey,TValue}"/> resources.</returns>
        public override gax::PagedEnumerable<PagedExpandLegacyMappedResponse, scg::KeyValuePair<string, PagedExpandResponseList>> PagedExpandLegacyMapped(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PagedExpandRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<PagedExpandRequest, PagedExpandLegacyMappedResponse, scg::KeyValuePair<string, PagedExpandResponseList>>(_callPagedExpandLegacyMapped, request, callSettings);
        }

        /// <summary>
        /// This method returns a map containing lists of words that appear in the input, keyed by their
        /// initial character. The only words returned are the ones included in the current page,
        /// as determined by page_token and page_size, which both refer to the word indices in the
        /// input. This paging result consisting of a map of lists is a pattern used by some legacy
        /// APIs. New APIs should NOT use this pattern.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>
        /// A pageable asynchronous sequence of <see cref="scg::KeyValuePair{TKey,TValue}"/> resources.
        /// </returns>
        public override gax::PagedAsyncEnumerable<PagedExpandLegacyMappedResponse, scg::KeyValuePair<string, PagedExpandResponseList>> PagedExpandLegacyMappedAsync(PagedExpandRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PagedExpandRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<PagedExpandRequest, PagedExpandLegacyMappedResponse, scg::KeyValuePair<string, PagedExpandResponseList>>(_callPagedExpandLegacyMapped, request, callSettings);
        }

        /// <summary>The long-running operations client for <c>Wait</c>.</summary>
        public override lro::OperationsClient WaitOperationsClient { get; }

        /// <summary>
        /// This method will wait for the requested amount of time and then return.
        /// This method showcases how a client handles a request timeout.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<WaitResponse, WaitMetadata> Wait(WaitRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WaitRequest(ref request, ref callSettings);
            return new lro::Operation<WaitResponse, WaitMetadata>(_callWait.Sync(request, callSettings), WaitOperationsClient);
        }

        /// <summary>
        /// This method will wait for the requested amount of time and then return.
        /// This method showcases how a client handles a request timeout.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<WaitResponse, WaitMetadata>> WaitAsync(WaitRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WaitRequest(ref request, ref callSettings);
            return new lro::Operation<WaitResponse, WaitMetadata>(await _callWait.Async(request, callSettings).ConfigureAwait(false), WaitOperationsClient);
        }

        /// <summary>
        /// This method will block (wait) for the requested amount of time
        /// and then return the response or error.
        /// This method showcases how a client handles delays or retries.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override BlockResponse Block(BlockRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_BlockRequest(ref request, ref callSettings);
            return _callBlock.Sync(request, callSettings);
        }

        /// <summary>
        /// This method will block (wait) for the requested amount of time
        /// and then return the response or error.
        /// This method showcases how a client handles delays or retries.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<BlockResponse> BlockAsync(BlockRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_BlockRequest(ref request, ref callSettings);
            return _callBlock.Async(request, callSettings);
        }
    }

    public partial class PagedExpandRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class PagedExpandLegacyRequest : gaxgrpc::IPageRequest
    {
        /// <inheritdoc/>
        public int PageSize
        {
            get => MaxResults;
            set => MaxResults = value;
        }
    }

    public partial class PagedExpandResponse : gaxgrpc::IPageResponse<EchoResponse>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<EchoResponse> GetEnumerator() => Responses.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public partial class PagedExpandLegacyMappedResponse : gaxgrpc::IPageResponse<scg::KeyValuePair<string, PagedExpandResponseList>>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<scg::KeyValuePair<string, PagedExpandResponseList>> GetEnumerator() =>
            Alphabetized.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static partial class Echo
    {
        public partial class EchoClient
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
