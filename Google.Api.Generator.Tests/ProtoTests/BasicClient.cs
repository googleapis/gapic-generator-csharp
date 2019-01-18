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

namespace Testing
{
    /// <summary>Settings for a <see cref="BasicClient"/>.</summary>
    public sealed partial class BasicSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="BasicSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="BasicSettings"/>.</returns>
        public static BasicSettings GetDefault() => new BasicSettings();

        /// <summary>Constructs a new <see cref="BasicSettings"/> object with default settings.</summary>
        public BasicSettings()
        {
        }

        private BasicSettings(BasicSettings existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            IdempotentMethodSettings = existing.IdempotentMethodSettings;
            NonIdempotentMethodSettings = existing.NonIdempotentMethodSettings;
            OnCopy(existing);
        }

        partial void OnCopy(BasicSettings existing);

        private static readonly gaxgrpc::CallSettings _defaultIdempotentCallSettings = gaxgrpc::CallSettings.FromCallTiming(gaxgrpc::CallTiming.FromRetry(new gaxgrpc::RetrySettings(retryBackoff: new gaxgrpc::BackoffSettings(delay: sys::TimeSpan.FromMilliseconds(100), maxDelay: sys::TimeSpan.FromSeconds(60), delayMultiplier: 1.3), timeoutBackoff: new gaxgrpc::BackoffSettings(delay: sys::TimeSpan.FromSeconds(20), maxDelay: sys::TimeSpan.FromSeconds(20), delayMultiplier: 1), totalExpiration: gax::Expiration.FromTimeout(sys::TimeSpan.FromSeconds(20)), retryFilter: gaxgrpc::RetrySettings.FilterForStatusCodes(grpccore::StatusCode.Internal, grpccore::StatusCode.Unavailable))));

        private static readonly gaxgrpc::CallSettings _defaultNonIdempotentCallSettings = gaxgrpc::CallSettings.FromCallTiming(gaxgrpc::CallTiming.FromTimeout(sys::TimeSpan.FromSeconds(20)));

        /// <summary><see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to<c>BasicClient.IdempotentMethod</c> and <c>BasicClient.IdempotentMethodAsync</c>.</summary>
        /// <remarks>The default <c>BasicClient.IdempotentMethod</c> and <c>BasicClient.IdempotentMethodAsync</c> <see cref="gaxgrpc::RetrySettings"/>are:<list type="bullet"><item><description>Initial retry delay: 100 milliseconds.</description></item><item><description>Retry delay multiplier: 1.3</description></item><item><description>Retry maximum delay: 60 seconds.</description></item><item><description>Initial timeout: 20 seconds.</description></item><item><description>Timeout multiplier: 1</description></item><item><description>Timeout maximum delay: 20 seconds.</description></item><item><description>Total timeout: 20 seconds.</description></item></list>By default retry will be attempted on the following response status codes:<list type="bullet"><item><description><see cref="grpccore::StatusCode.Internal"/></description></item><item><description><see cref="grpccore::StatusCode.Unavailable"/></description></item></list></remarks>
        public gaxgrpc::CallSettings IdempotentMethodSettings { get; set; } = _defaultIdempotentCallSettings;

        /// <summary><see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to<c>BasicClient.NonIdempotentMethod</c> and <c>BasicClient.NonIdempotentMethodAsync</c>.</summary>
        /// <remarks>By default, retry will not be attempted.</remarks>
        public gaxgrpc::CallSettings NonIdempotentMethodSettings { get; set; } = _defaultNonIdempotentCallSettings;

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="BasicSettings"/> object.</returns>
        public BasicSettings Clone() => new BasicSettings(this);
    }

    /// <summary>Basic client wrapper, for convenient use.</summary>
    public abstract partial class BasicClient
    {
        /// <summary>The default endpoint for the Basic service, which is a host of "basic.example.com" and a port of 443.</summary>
        public static gaxgrpc::ServiceEndpoint DefaultEndpoint { get; } = new gaxgrpc::ServiceEndpoint("basic.example.com", 443);

        /// <summary>The default Basic scopes.</summary>
        /// <remarks>The default Basic scopes are:<list type="bullet"><item><description>scope1</description></item><item><description>scope2</description></item></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[]
        {
            "scope1",
            "scope2",
        });

        private static readonly gaxgrpc::ChannelPool s_channelPool = new gaxgrpc::ChannelPool(DefaultScopes);

        /// <summary>Asynchronously creates a <see cref="BasicClient"/>, applying defaults for all unspecified settings, and creating a channel connecting to the given endpoint with application default credentials where necessary. See the example for how to use custom credentials.</summary>
        /// <example>This sample shows how to create a client using default credentials:<code>using Google.Cloud.Vision.V1;...// When running on Google Cloud Platform this will use the project Compute Credential.// Or set the GOOGLE_APPLICATION_CREDENTIALS environment variable to the path of a JSON// credential file to use that credential.ImageAnnotatorClient client = await ImageAnnotatorClient.CreateAsync();</code>This sample shows how to create a client using credentials loaded from a JSON file:<code>using Google.Cloud.Vision.V1;using Google.Apis.Auth.OAuth2;using Grpc.Auth;using Grpc.Core;...GoogleCredential cred = GoogleCredential.FromFile("/path/to/credentials.json");Channel channel = new Channel(    ImageAnnotatorClient.DefaultEndpoint.Host, ImageAnnotatorClient.DefaultEndpoint.Port, cred.ToChannelCredentials());ImageAnnotatorClient client = ImageAnnotatorClient.Create(channel);...// Shutdown the channel when it is no longer required.await channel.ShutdownAsync();</code></example>
        /// <param name="endpoint">Optional <see cref="gaxgrpc::ServiceEndpoint"/>.</param>
        /// <param name="settings">Optional <see cref="BasicSettings"/>.</param>
        /// <returns>The task representing the created <see cref="BasicClient"/>.</returns>
        public static async stt::Task<BasicClient> CreateAsync(gaxgrpc::ServiceEndpoint endpoint = null, BasicSettings settings = null)
        {
            grpccore::Channel channel = await s_channelPool.GetChannelAsync(endpoint ?? DefaultEndpoint).ConfigureAwait(false);
            return Create(channel, settings);
        }

        /// <summary>Synchronously creates a <see cref="BasicClient"/>, applying defaults for all unspecified settings, and creating a channel connecting to the given endpoint with application default credentials where necessary. See the example for how to use custom credentials.</summary>
        /// <example>This sample shows how to create a client using default credentials:<code>using Google.Cloud.Vision.V1;...// When running on Google Cloud Platform this will use the project Compute Credential.// Or set the GOOGLE_APPLICATION_CREDENTIALS environment variable to the path of a JSON// credential file to use that credential.ImageAnnotatorClient client = ImageAnnotatorClient.Create();</code>This sample shows how to create a client using credentials loaded from a JSON file:<code>using Google.Cloud.Vision.V1;using Google.Apis.Auth.OAuth2;using Grpc.Auth;using Grpc.Core;...GoogleCredential cred = GoogleCredential.FromFile("/path/to/credentials.json");Channel channel = new Channel(    ImageAnnotatorClient.DefaultEndpoint.Host, ImageAnnotatorClient.DefaultEndpoint.Port, cred.ToChannelCredentials());ImageAnnotatorClient client = ImageAnnotatorClient.Create(channel);...// Shutdown the channel when it is no longer required.await channel.ShutdownAsync();</code></example>
        /// <param name="endpoint">Optional <see cref="gaxgrpc::ServiceEndpoint"/>.</param>
        /// <param name="settings">Optional <see cref="BasicSettings"/>.</param>
        /// <returns>The created <see cref="BasicClient"/>.</returns>
        public static BasicClient Create(gaxgrpc::ServiceEndpoint endpoint = null, BasicSettings settings = null)
        {
            grpccore::Channel channel = s_channelPool.GetChannel(endpoint ?? DefaultEndpoint);
            return Create(channel, settings);
        }

        /// <summary>Creates a <see cref="BasicClient"/> which uses the specified channel for remote operations.</summary>
        /// <param name="channel">The <see cref="grpccore::Channel"/> for remote operations. Must not be null.</param>
        /// <param name="settings">Optional <see cref="BasicSettings"/>.</param>
        /// <returns>The created <see cref="BasicClient"/>.</returns>
        public static BasicClient Create(grpccore::Channel channel, BasicSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(channel, nameof(channel));
            return Create(new grpccore::DefaultCallInvoker(channel));
        }

        /// <summary>Creates a <see cref="BasicClient"/> which uses the specified call invoker for remote operations.</summary>
        /// <param name="callInvoker">The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.</param>
        /// <param name="settings">Optional <see cref="BasicSettings"/>.</param>
        /// <returns>The created <see cref="BasicClient"/>.</returns>
        public static BasicClient Create(grpccore::CallInvoker callInvoker, BasicSettings settings = null)
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

        /// <summary>Shuts down any channels automatically created by <see cref="Create(grpccore::CallInvoker,BasicSettings)"/> and <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,BasicSettings)"/>. Channels which weren't automatically created are not affected.</summary>
        /// <remarks>After calling this method, further calls to <see cref="Create(grpccore::CallInvoker,BasicSettings)"/> and <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,BasicSettings)"/> will create new channels, which could in turn be shut down by another call to this method.</remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => s_channelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC Basic client</summary>
        public virtual Basic.BasicClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>Test summary text for IdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response IdempotentMethod(Request request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        /// <summary>Test summary text for IdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> IdempotentMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        /// <summary>Test summary text for IdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> IdempotentMethodAsync(Request request, st::CancellationToken cancellationToken) => IdempotentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>Test summary text for NonIdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response NonIdempotentMethod(Request request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        /// <summary>Test summary text for NonIdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NonIdempotentMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        /// <summary>Test summary text for NonIdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> NonIdempotentMethodAsync(Request request, st::CancellationToken cancellationToken) => NonIdempotentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Basic client wrapper implementation, for convenient use.</summary>
    public sealed partial class BasicClientImpl : BasicClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callIdempotentMethod;

        private readonly gaxgrpc::ApiCall<Request, Response> _callNonIdempotentMethod;

        /// <summary>Constructs a client wrapper for the Basic service, with the specified gRPC client and settings.</summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="BasicSettings"/> used within this client.</param>
        public BasicClientImpl(Basic.BasicClient grpcClient, BasicSettings settings)
        {
            GrpcClient = grpcClient;
            BasicSettings effectiveSettings = settings ?? BasicSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callIdempotentMethod = clientHelper.BuildApiCall<Request, Response>(grpcClient.IdempotentMethodAsync, grpcClient.IdempotentMethod, effectiveSettings.IdempotentMethodSettings);
            Modify_ApiCall(ref _callIdempotentMethod);
            Modify_IdempotentMethodApiCall(ref _callIdempotentMethod);
            _callNonIdempotentMethod = clientHelper.BuildApiCall<Request, Response>(grpcClient.NonIdempotentMethodAsync, grpcClient.NonIdempotentMethod, effectiveSettings.NonIdempotentMethodSettings);
            Modify_ApiCall(ref _callNonIdempotentMethod);
            Modify_NonIdempotentMethodApiCall(ref _callNonIdempotentMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_IdempotentMethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void Modify_NonIdempotentMethodApiCall(ref gaxgrpc::ApiCall<Request, Response> call);

        partial void OnConstruction(Basic.BasicClient grpcClient, BasicSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Basic client</summary>
        public override Basic.BasicClient GrpcClient { get; }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>Test summary text for IdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response IdempotentMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callIdempotentMethod.Sync(request, callSettings);
        }

        /// <summary>Test summary text for IdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> IdempotentMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callIdempotentMethod.Async(request, callSettings);
        }

        /// <summary>Test summary text for NonIdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response NonIdempotentMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callNonIdempotentMethod.Sync(request, callSettings);
        }

        /// <summary>Test summary text for NonIdempotentMethod</summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> NonIdempotentMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callNonIdempotentMethod.Async(request, callSettings);
        }
    }
}
