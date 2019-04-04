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
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace ResourceUpgradeTest
{
    /// <summary>Settings for a <see cref="SvcClient"/>.</summary>
    public sealed partial class SvcSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="SvcSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="SvcSettings"/>.</returns>
        public static SvcSettings GetDefault() => new SvcSettings();

        /// <summary>Constructs a new <see cref="SvcSettings"/> object with default settings.</summary>
        public SvcSettings()
        {
        }

        private SvcSettings(SvcSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            MSettings = existing.MSettings;
            OnCopy(existing);
        }

        partial void OnCopy(SvcSettings existing);

        private static readonly gaxgrpc::CallSettings _defaultNonIdempotentCallSettings = gaxgrpc::CallSettings.FromCallTiming(gaxgrpc::CallTiming.FromTimeout(sys::TimeSpan.FromSeconds(20)));

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SvcClient.M</c> and
        /// <c>SvcClient.MAsync</c>.
        /// </summary>
        /// <remarks>By default, retry will not be attempted.</remarks>
        public gaxgrpc::CallSettings MSettings { get; set; } = _defaultNonIdempotentCallSettings;

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="SvcSettings"/> object.</returns>
        public SvcSettings Clone() => new SvcSettings(this);
    }

    /// <summary>Svc client wrapper, for convenient use.</summary>
    public abstract partial class SvcClient
    {
        /// <summary>The default endpoint for the Svc service, which is a host of "" and a port of 443.</summary>
        public static gaxgrpc::ServiceEndpoint DefaultEndpoint { get; } = new gaxgrpc::ServiceEndpoint("", 443);

        /// <summary>The default Svc scopes.</summary>
        /// <remarks>The default Svc scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        private static readonly gaxgrpc::ChannelPool s_channelPool = new gaxgrpc::ChannelPool(DefaultScopes);

        /// <summary>
        /// Asynchronously creates a <see cref="SvcClient"/>, applying defaults for all unspecified settings, and
        /// creating a channel connecting to the given endpoint with application default credentials where necessary.
        /// See the example for how to use custom credentials.
        /// </summary>
        /// <example>
        /// This sample shows how to create a client using default credentials:
        /// <code>
        /// using Google.Cloud.Vision.V1;
        /// ...
        /// // When running on Google Cloud Platform this will use the project Compute Credential.
        /// // Or set the GOOGLE_APPLICATION_CREDENTIALS environment variable to the path of a JSON
        /// // credential file to use that credential.
        /// ImageAnnotatorClient client = await ImageAnnotatorClient.CreateAsync();
        /// </code>
        /// This sample shows how to create a client using credentials loaded from a JSON file:
        /// <code>
        /// using Google.Cloud.Vision.V1;
        /// using Google.Apis.Auth.OAuth2;
        /// using Grpc.Auth;
        /// using Grpc.Core;
        /// ...
        /// GoogleCredential cred = GoogleCredential.FromFile("/path/to/credentials.json");
        /// Channel channel = new Channel(
        ///     ImageAnnotatorClient.DefaultEndpoint.Host, ImageAnnotatorClient.DefaultEndpoint.Port, cred.ToChannelCredentials());
        /// ImageAnnotatorClient client = ImageAnnotatorClient.Create(channel);
        /// ...
        /// // Shutdown the channel when it is no longer required.
        /// await channel.ShutdownAsync();
        /// </code>
        /// </example>
        /// <param name="endpoint">Optional <see cref="gaxgrpc::ServiceEndpoint"/>.</param>
        /// <param name="settings">Optional <see cref="SvcSettings"/>.</param>
        /// <returns>The task representing the created <see cref="SvcClient"/>.</returns>
        public static async stt::Task<SvcClient> CreateAsync(gaxgrpc::ServiceEndpoint endpoint = null, SvcSettings settings = null)
        {
            grpccore::Channel channel = await s_channelPool.GetChannelAsync(endpoint ?? DefaultEndpoint).ConfigureAwait(false);
            return Create(channel, settings);
        }

        /// <summary>
        /// Synchronously creates a <see cref="SvcClient"/>, applying defaults for all unspecified settings, and
        /// creating a channel connecting to the given endpoint with application default credentials where necessary.
        /// See the example for how to use custom credentials.
        /// </summary>
        /// <example>
        /// This sample shows how to create a client using default credentials:
        /// <code>
        /// using Google.Cloud.Vision.V1;
        /// ...
        /// // When running on Google Cloud Platform this will use the project Compute Credential.
        /// // Or set the GOOGLE_APPLICATION_CREDENTIALS environment variable to the path of a JSON
        /// // credential file to use that credential.
        /// ImageAnnotatorClient client = ImageAnnotatorClient.Create();
        /// </code>
        /// This sample shows how to create a client using credentials loaded from a JSON file:
        /// <code>
        /// using Google.Cloud.Vision.V1;
        /// using Google.Apis.Auth.OAuth2;
        /// using Grpc.Auth;
        /// using Grpc.Core;
        /// ...
        /// GoogleCredential cred = GoogleCredential.FromFile("/path/to/credentials.json");
        /// Channel channel = new Channel(
        ///     ImageAnnotatorClient.DefaultEndpoint.Host, ImageAnnotatorClient.DefaultEndpoint.Port, cred.ToChannelCredentials());
        /// ImageAnnotatorClient client = ImageAnnotatorClient.Create(channel);
        /// ...
        /// // Shutdown the channel when it is no longer required.
        /// channel.ShutdownAsync().Wait();
        /// </code>
        /// </example>
        /// <param name="endpoint">Optional <see cref="gaxgrpc::ServiceEndpoint"/>.</param>
        /// <param name="settings">Optional <see cref="SvcSettings"/>.</param>
        /// <returns>The created <see cref="SvcClient"/>.</returns>
        public static SvcClient Create(gaxgrpc::ServiceEndpoint endpoint = null, SvcSettings settings = null)
        {
            grpccore::Channel channel = s_channelPool.GetChannel(endpoint ?? DefaultEndpoint);
            return Create(channel, settings);
        }

        /// <summary>Creates a <see cref="SvcClient"/> which uses the specified channel for remote operations.</summary>
        /// <param name="channel">The <see cref="grpccore::Channel"/> for remote operations. Must not be null.</param>
        /// <param name="settings">Optional <see cref="SvcSettings"/>.</param>
        /// <returns>The created <see cref="SvcClient"/>.</returns>
        public static SvcClient Create(grpccore::Channel channel, SvcSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(channel, nameof(channel));
            return Create(new grpccore::DefaultCallInvoker(channel), settings);
        }

        /// <summary>
        /// Creates a <see cref="SvcClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="SvcSettings"/>.</param>
        /// <returns>The created <see cref="SvcClient"/>.</returns>
        public static SvcClient Create(grpccore::CallInvoker callInvoker, SvcSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Svc.SvcClient grpcClient = new Svc.SvcClient(callInvoker);
            return new SvcClientImpl(grpcClient, settings);
        }

        /// <summary>
        /// Shuts down any channels automatically created by <see cref="Create(grpccore::CallInvoker,SvcSettings)"/> and
        /// <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,SvcSettings)"/>. Channels which weren't automatically
        /// created are not affected.
        /// </summary>
        /// <remarks>
        /// After calling this method, further calls to <see cref="Create(grpccore::CallInvoker,SvcSettings)"/> and
        /// <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,SvcSettings)"/> will create new channels, which could in
        /// turn be shut down by another call to this method.
        /// </remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => s_channelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC Svc client</summary>
        public virtual Svc.SvcClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response M(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(Request request, st::CancellationToken cancellationToken) =>
            MAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="anotherName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response M(string name, string anotherName, gaxgrpc::CallSettings callSettings = null) =>
            M(new Request
            {
                Name = name ?? "",
                AnotherName = anotherName ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="anotherName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(string name, string anotherName, gaxgrpc::CallSettings callSettings = null) =>
            MAsync(new Request
            {
                Name = name ?? "",
                AnotherName = anotherName ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="anotherName">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(string name, string anotherName, st::CancellationToken cancellationToken) =>
            MAsync(name, anotherName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="anotherName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response M(RequestName name, RequestName anotherName, gaxgrpc::CallSettings callSettings = null) =>
            M(new Request
            {
                RequestName = name,
                AnotherNameAsRequestName = anotherName,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="anotherName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(RequestName name, RequestName anotherName, gaxgrpc::CallSettings callSettings = null) =>
            MAsync(new Request
            {
                RequestName = name,
                AnotherNameAsRequestName = anotherName,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="anotherName">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(RequestName name, RequestName anotherName, st::CancellationToken cancellationToken) =>
            MAsync(name, anotherName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response M(string name, gaxgrpc::CallSettings callSettings = null) =>
            M(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            MAsync(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(string name, st::CancellationToken cancellationToken) =>
            MAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response M(RequestName name, gaxgrpc::CallSettings callSettings = null) =>
            M(new Request { RequestName = name, }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(RequestName name, gaxgrpc::CallSettings callSettings = null) =>
            MAsync(new Request { RequestName = name, }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MAsync(RequestName name, st::CancellationToken cancellationToken) =>
            MAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Svc client wrapper implementation, for convenient use.</summary>
    public sealed partial class SvcClientImpl : SvcClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callM;

        /// <summary>
        /// Constructs a client wrapper for the Svc service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="SvcSettings"/> used within this client.</param>
        public SvcClientImpl(Svc.SvcClient grpcClient, SvcSettings settings)
        {
            GrpcClient = grpcClient;
            SvcSettings effectiveSettings = settings ?? SvcSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callM = clientHelper.BuildApiCall<Request, Response>(grpcClient.MAsync, grpcClient.M, effectiveSettings.MSettings);
            Modify_ApiCall(ref _callM);
            Modify_MApiCall(ref _callM);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_MApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void OnConstruction(Svc.SvcClient grpcClient, SvcSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Svc client</summary>
        public override Svc.SvcClient GrpcClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response M(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callM.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> MAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callM.Async(request, callSettings);
        }
    }
}
