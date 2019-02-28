using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using lro = Google.LongRunning;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using linq = System.Linq;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.UnitTests
{
    /// <summary>Settings for a <see cref="UnitTestsClient"/>.</summary>
    public sealed partial class UnitTestsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="UnitTestsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="UnitTestsSettings"/>.</returns>
        public static UnitTestsSettings GetDefault() => new UnitTestsSettings();

        /// <summary>Constructs a new <see cref="UnitTestsSettings"/> object with default settings.</summary>
        public UnitTestsSettings()
        {
        }

        private UnitTestsSettings(UnitTestsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            MethodValuesSettings = existing.MethodValuesSettings;
            MethodLroSettings = existing.MethodLroSettings;
            MethodLroOperationsSettings = existing.MethodLroOperationsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(UnitTestsSettings existing);

        private static readonly gaxgrpc::CallSettings _defaultNonIdempotentCallSettings = gaxgrpc::CallSettings.FromCallTiming(gaxgrpc::CallTiming.FromTimeout(sys::TimeSpan.FromSeconds(20)));

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>UnitTestsClient.MethodValues</c> and <c>UnitTestsClient.MethodValuesAsync</c>.
        /// </summary>
        /// <remarks>By default, retry will not be attempted.</remarks>
        public gaxgrpc::CallSettings MethodValuesSettings { get; set; } = _defaultNonIdempotentCallSettings;

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UnitTestsClient.MethodLro</c>
        ///  and <c>UnitTestsClient.MethodLroAsync</c>.
        /// </summary>
        /// <remarks>By default, retry will not be attempted.</remarks>
        public gaxgrpc::CallSettings MethodLroSettings { get; set; } = _defaultNonIdempotentCallSettings;

        /// <summary>
        /// Long Running Operation settings for calls to <c>UnitTestsClient.MethodLro</c> and
        /// <c>UnitTestsClient.MethodLroAsync</c>.
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
        public lro::OperationsSettings MethodLroOperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="UnitTestsSettings"/> object.</returns>
        public UnitTestsSettings Clone() => new UnitTestsSettings(this);
    }

    /// <summary>UnitTests client wrapper, for convenient use.</summary>
    public abstract partial class UnitTestsClient
    {
        /// <summary>
        /// The default endpoint for the UnitTests service, which is a host of "unittests.example.com" and a port of
        /// 443.
        /// </summary>
        public static gaxgrpc::ServiceEndpoint DefaultEndpoint { get; } = new gaxgrpc::ServiceEndpoint("unittests.example.com", 443);

        /// <summary>The default UnitTests scopes.</summary>
        /// <remarks>The default UnitTests scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        private static readonly gaxgrpc::ChannelPool s_channelPool = new gaxgrpc::ChannelPool(DefaultScopes);

        /// <summary>
        /// Asynchronously creates a <see cref="UnitTestsClient"/>, applying defaults for all unspecified settings, and
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
        /// <param name="settings">Optional <see cref="UnitTestsSettings"/>.</param>
        /// <returns>The task representing the created <see cref="UnitTestsClient"/>.</returns>
        public static async stt::Task<UnitTestsClient> CreateAsync(gaxgrpc::ServiceEndpoint endpoint = null, UnitTestsSettings settings = null)
        {
            grpccore::Channel channel = await s_channelPool.GetChannelAsync(endpoint ?? DefaultEndpoint).ConfigureAwait(false);
            return Create(channel, settings);
        }

        /// <summary>
        /// Synchronously creates a <see cref="UnitTestsClient"/>, applying defaults for all unspecified settings, and
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
        /// await channel.ShutdownAsync();
        /// </code>
        /// </example>
        /// <param name="endpoint">Optional <see cref="gaxgrpc::ServiceEndpoint"/>.</param>
        /// <param name="settings">Optional <see cref="UnitTestsSettings"/>.</param>
        /// <returns>The created <see cref="UnitTestsClient"/>.</returns>
        public static UnitTestsClient Create(gaxgrpc::ServiceEndpoint endpoint = null, UnitTestsSettings settings = null)
        {
            grpccore::Channel channel = s_channelPool.GetChannel(endpoint ?? DefaultEndpoint);
            return Create(channel, settings);
        }

        /// <summary>
        /// Creates a <see cref="UnitTestsClient"/> which uses the specified channel for remote operations.
        /// </summary>
        /// <param name="channel">The <see cref="grpccore::Channel"/> for remote operations. Must not be null.</param>
        /// <param name="settings">Optional <see cref="UnitTestsSettings"/>.</param>
        /// <returns>The created <see cref="UnitTestsClient"/>.</returns>
        public static UnitTestsClient Create(grpccore::Channel channel, UnitTestsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(channel, nameof(channel));
            return Create(new grpccore::DefaultCallInvoker(channel));
        }

        /// <summary>
        /// Creates a <see cref="UnitTestsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="UnitTestsSettings"/>.</param>
        /// <returns>The created <see cref="UnitTestsClient"/>.</returns>
        public static UnitTestsClient Create(grpccore::CallInvoker callInvoker, UnitTestsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            UnitTests.UnitTestsClient grpcClient = new UnitTests.UnitTestsClient(callInvoker);
            return new UnitTestsClientImpl(grpcClient, settings);
        }

        /// <summary>
        /// Shuts down any channels automatically created by
        /// <see cref="Create(grpccore::CallInvoker,UnitTestsSettings)"/> and
        /// <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,UnitTestsSettings)"/>. Channels which weren't automatically
        /// created are not affected.
        /// </summary>
        /// <remarks>
        /// After calling this method, further calls to <see cref="Create(grpccore::CallInvoker,UnitTestsSettings)"/>
        /// and <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,UnitTestsSettings)"/> will create new channels, which
        /// could in turn be shut down by another call to this method.
        /// </remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => s_channelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC UnitTests client</summary>
        public virtual UnitTests.UnitTestsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(ValuesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(ValuesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(ValuesRequest request, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(double singleDouble, gaxgrpc::CallSettings callSettings = null) =>
            MethodValues(new ValuesRequest
            {
                SingleDouble = singleDouble,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, gaxgrpc::CallSettings callSettings = null) =>
            MethodValuesAsync(new ValuesRequest
            {
                SingleDouble = singleDouble,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(singleDouble, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="singleFloat">
        /// </param>
        /// <param name="singleInt32">
        /// </param>
        /// <param name="singleInt64">
        /// </param>
        /// <param name="repeatedBool">
        /// </param>
        /// <param name="repeatedBytes">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<string> repeatedResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValues(new ValuesRequest
            {
                SingleDouble = singleDouble,
                SingleFloat = singleFloat,
                SingleInt32 = singleInt32,
                SingleInt64 = singleInt64,
                RepeatedBool =
                {
                    repeatedBool ?? linq::Enumerable.Empty<bool>(),
                },
                RepeatedBytes =
                {
                    repeatedBytes ?? linq::Enumerable.Empty<proto::ByteString>(),
                },
                RepeatedResourceName =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="singleFloat">
        /// </param>
        /// <param name="singleInt32">
        /// </param>
        /// <param name="singleInt64">
        /// </param>
        /// <param name="repeatedBool">
        /// </param>
        /// <param name="repeatedBytes">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<string> repeatedResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValuesAsync(new ValuesRequest
            {
                SingleDouble = singleDouble,
                SingleFloat = singleFloat,
                SingleInt32 = singleInt32,
                SingleInt64 = singleInt64,
                RepeatedBool =
                {
                    repeatedBool ?? linq::Enumerable.Empty<bool>(),
                },
                RepeatedBytes =
                {
                    repeatedBytes ?? linq::Enumerable.Empty<proto::ByteString>(),
                },
                RepeatedResourceName =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="singleFloat">
        /// </param>
        /// <param name="singleInt32">
        /// </param>
        /// <param name="singleInt64">
        /// </param>
        /// <param name="repeatedBool">
        /// </param>
        /// <param name="repeatedBytes">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<string> repeatedResourceName, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(singleDouble, singleFloat, singleInt32, singleInt64, repeatedBool, repeatedBytes, repeatedResourceName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="singleFloat">
        /// </param>
        /// <param name="singleInt32">
        /// </param>
        /// <param name="singleInt64">
        /// </param>
        /// <param name="repeatedBool">
        /// </param>
        /// <param name="repeatedBytes">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<AResourceName> repeatedResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValues(new ValuesRequest
            {
                SingleDouble = singleDouble,
                SingleFloat = singleFloat,
                SingleInt32 = singleInt32,
                SingleInt64 = singleInt64,
                RepeatedBool =
                {
                    repeatedBool ?? linq::Enumerable.Empty<bool>(),
                },
                RepeatedBytes =
                {
                    repeatedBytes ?? linq::Enumerable.Empty<proto::ByteString>(),
                },
                RepeatedResourceNameAsAResourceNames =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<AResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="singleFloat">
        /// </param>
        /// <param name="singleInt32">
        /// </param>
        /// <param name="singleInt64">
        /// </param>
        /// <param name="repeatedBool">
        /// </param>
        /// <param name="repeatedBytes">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<AResourceName> repeatedResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValuesAsync(new ValuesRequest
            {
                SingleDouble = singleDouble,
                SingleFloat = singleFloat,
                SingleInt32 = singleInt32,
                SingleInt64 = singleInt64,
                RepeatedBool =
                {
                    repeatedBool ?? linq::Enumerable.Empty<bool>(),
                },
                RepeatedBytes =
                {
                    repeatedBytes ?? linq::Enumerable.Empty<proto::ByteString>(),
                },
                RepeatedResourceNameAsAResourceNames =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<AResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleDouble">
        /// </param>
        /// <param name="singleFloat">
        /// </param>
        /// <param name="singleInt32">
        /// </param>
        /// <param name="singleInt64">
        /// </param>
        /// <param name="repeatedBool">
        /// </param>
        /// <param name="repeatedBytes">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<AResourceName> repeatedResourceName, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(singleDouble, singleFloat, singleInt32, singleInt64, repeatedBool, repeatedBytes, repeatedResourceName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// LRO method, to test the client mocking supports LRO.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> MethodLro(LroRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// LRO method, to test the client mocking supports LRO.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> MethodLroAsync(LroRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// LRO method, to test the client mocking supports LRO.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> MethodLroAsync(LroRequest request, st::CancellationToken cancellationToken) =>
            MethodLroAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>MethodLro</c>.</summary>
        public virtual lro::OperationsClient MethodLroOperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of <c>MethodLro</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> PollOnceMethodLro(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), MethodLroOperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>MethodLro</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> PollOnceMethodLroAsync(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), MethodLroOperationsClient, callSettings);
    }

    /// <summary>UnitTests client wrapper implementation, for convenient use.</summary>
    public sealed partial class UnitTestsClientImpl : UnitTestsClient
    {
        private readonly gaxgrpc::ApiCall<ValuesRequest, Response> _callMethodValues;

        private readonly gaxgrpc::ApiCall<LroRequest, lro::Operation> _callMethodLro;

        /// <summary>
        /// Constructs a client wrapper for the UnitTests service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="UnitTestsSettings"/> used within this client.</param>
        public UnitTestsClientImpl(UnitTests.UnitTestsClient grpcClient, UnitTestsSettings settings)
        {
            GrpcClient = grpcClient;
            UnitTestsSettings effectiveSettings = settings ?? UnitTestsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            MethodLroOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.MethodLroOperationsSettings);
            _callMethodValues = clientHelper.BuildApiCall<ValuesRequest, Response>(grpcClient.MethodValuesAsync, grpcClient.MethodValues, effectiveSettings.MethodValuesSettings);
            Modify_ApiCall(ref _callMethodValues);
            Modify_MethodValuesApiCall(ref _callMethodValues);
            _callMethodLro = clientHelper.BuildApiCall<LroRequest, lro::Operation>(grpcClient.MethodLroAsync, grpcClient.MethodLro, effectiveSettings.MethodLroSettings);
            Modify_ApiCall(ref _callMethodLro);
            Modify_MethodLroApiCall(ref _callMethodLro);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_MethodValuesApiCall(ref gaxgrpc::ApiCall<ValuesRequest, Response> call);

        partial void Modify_MethodLroApiCall(ref gaxgrpc::ApiCall<LroRequest, lro::Operation> call);

        partial void OnConstruction(UnitTests.UnitTestsClient grpcClient, UnitTestsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC UnitTests client</summary>
        public override UnitTests.UnitTestsClient GrpcClient { get; }

        partial void Modify_ValuesRequest(ref ValuesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_LroRequest(ref LroRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response MethodValues(ValuesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ValuesRequest(ref request, ref callSettings);
            return _callMethodValues.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> MethodValuesAsync(ValuesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ValuesRequest(ref request, ref callSettings);
            return _callMethodValues.Async(request, callSettings);
        }

        /// <summary>The long-running operations client for <c>MethodLro</c>.</summary>
        public override lro::OperationsClient MethodLroOperationsClient { get; }

        /// <summary>
        /// LRO method, to test the client mocking supports LRO.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<LroResponse, LroMetadata> MethodLro(LroRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_LroRequest(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(_callMethodLro.Sync(request, callSettings), MethodLroOperationsClient);
        }

        /// <summary>
        /// LRO method, to test the client mocking supports LRO.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<LroResponse, LroMetadata>> MethodLroAsync(LroRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_LroRequest(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(await _callMethodLro.Async(request, callSettings).ConfigureAwait(false), MethodLroOperationsClient);
        }
    }

    public static partial class UnitTests
    {
        public partial class UnitTestsClient
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
