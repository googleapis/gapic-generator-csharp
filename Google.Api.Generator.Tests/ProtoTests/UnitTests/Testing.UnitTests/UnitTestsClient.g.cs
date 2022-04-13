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
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using linq = System.Linq;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.UnitTests
{
    /// <summary>Settings for <see cref="UnitTestsClient"/> instances.</summary>
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
            MethodLroOperationsSettings = existing.MethodLroOperationsSettings.Clone();
            OnCopy(existing);
        }

        partial void OnCopy(UnitTestsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>UnitTestsClient.MethodValues</c> and <c>UnitTestsClient.MethodValuesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings MethodValuesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UnitTestsClient.MethodLro</c>
        ///  and <c>UnitTestsClient.MethodLroAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings MethodLroSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

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

    /// <summary>
    /// Builder class for <see cref="UnitTestsClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class UnitTestsClientBuilder : gaxgrpc::ClientBuilderBase<UnitTestsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public UnitTestsSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public UnitTestsClientBuilder() : base(UnitTestsClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref UnitTestsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<UnitTestsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override UnitTestsClient Build()
        {
            UnitTestsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<UnitTestsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<UnitTestsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private UnitTestsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return UnitTestsClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<UnitTestsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return UnitTestsClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => UnitTestsClient.ChannelPool;
    }

    /// <summary>UnitTests client wrapper, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public abstract partial class UnitTestsClient
    {
        /// <summary>
        /// The default endpoint for the UnitTests service, which is a host of "unittests.example.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "unittests.example.com:443";

        /// <summary>The default UnitTests scopes.</summary>
        /// <remarks>The default UnitTests scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        internal static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(UnitTests.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="UnitTestsClient"/> using the default credentials, endpoint and settings.
        /// To specify custom credentials or other settings, use <see cref="UnitTestsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="UnitTestsClient"/>.</returns>
        public static stt::Task<UnitTestsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new UnitTestsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="UnitTestsClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="UnitTestsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="UnitTestsClient"/>.</returns>
        public static UnitTestsClient Create() => new UnitTestsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="UnitTestsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="UnitTestsSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="UnitTestsClient"/>.</returns>
        internal static UnitTestsClient Create(grpccore::CallInvoker callInvoker, UnitTestsSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            UnitTests.UnitTestsClient grpcClient = new UnitTests.UnitTestsClient(callInvoker);
            return new UnitTestsClientImpl(grpcClient, settings, logger);
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
        /// <param name="mapIntString">
        /// </param>
        /// <param name="singleWrappedString">
        /// </param>
        /// <param name="repeatedWrappedDouble">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<string> repeatedResourceName, scg::IDictionary<int, string> mapIntString, string singleWrappedString, scg::IEnumerable<double?> repeatedWrappedDouble, gaxgrpc::CallSettings callSettings = null) =>
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
                MapIntString =
                {
                    mapIntString ?? new scg::Dictionary<int, string>(),
                },
                SingleWrappedString = singleWrappedString,
                RepeatedWrappedDouble =
                {
                    repeatedWrappedDouble ?? linq::Enumerable.Empty<double?>(),
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
        /// <param name="mapIntString">
        /// </param>
        /// <param name="singleWrappedString">
        /// </param>
        /// <param name="repeatedWrappedDouble">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<string> repeatedResourceName, scg::IDictionary<int, string> mapIntString, string singleWrappedString, scg::IEnumerable<double?> repeatedWrappedDouble, gaxgrpc::CallSettings callSettings = null) =>
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
                MapIntString =
                {
                    mapIntString ?? new scg::Dictionary<int, string>(),
                },
                SingleWrappedString = singleWrappedString,
                RepeatedWrappedDouble =
                {
                    repeatedWrappedDouble ?? linq::Enumerable.Empty<double?>(),
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
        /// <param name="mapIntString">
        /// </param>
        /// <param name="singleWrappedString">
        /// </param>
        /// <param name="repeatedWrappedDouble">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<string> repeatedResourceName, scg::IDictionary<int, string> mapIntString, string singleWrappedString, scg::IEnumerable<double?> repeatedWrappedDouble, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(singleDouble, singleFloat, singleInt32, singleInt64, repeatedBool, repeatedBytes, repeatedResourceName, mapIntString, singleWrappedString, repeatedWrappedDouble, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

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
        /// <param name="mapIntString">
        /// </param>
        /// <param name="singleWrappedString">
        /// </param>
        /// <param name="repeatedWrappedDouble">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<AResourceName> repeatedResourceName, scg::IDictionary<int, string> mapIntString, string singleWrappedString, scg::IEnumerable<double?> repeatedWrappedDouble, gaxgrpc::CallSettings callSettings = null) =>
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
                MapIntString =
                {
                    mapIntString ?? new scg::Dictionary<int, string>(),
                },
                SingleWrappedString = singleWrappedString,
                RepeatedWrappedDouble =
                {
                    repeatedWrappedDouble ?? linq::Enumerable.Empty<double?>(),
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
        /// <param name="mapIntString">
        /// </param>
        /// <param name="singleWrappedString">
        /// </param>
        /// <param name="repeatedWrappedDouble">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<AResourceName> repeatedResourceName, scg::IDictionary<int, string> mapIntString, string singleWrappedString, scg::IEnumerable<double?> repeatedWrappedDouble, gaxgrpc::CallSettings callSettings = null) =>
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
                MapIntString =
                {
                    mapIntString ?? new scg::Dictionary<int, string>(),
                },
                SingleWrappedString = singleWrappedString,
                RepeatedWrappedDouble =
                {
                    repeatedWrappedDouble ?? linq::Enumerable.Empty<double?>(),
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
        /// <param name="mapIntString">
        /// </param>
        /// <param name="singleWrappedString">
        /// </param>
        /// <param name="repeatedWrappedDouble">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(double singleDouble, float singleFloat, int singleInt32, long singleInt64, scg::IEnumerable<bool> repeatedBool, scg::IEnumerable<proto::ByteString> repeatedBytes, scg::IEnumerable<AResourceName> repeatedResourceName, scg::IDictionary<int, string> mapIntString, string singleWrappedString, scg::IEnumerable<double?> repeatedWrappedDouble, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(singleDouble, singleFloat, singleInt32, singleInt64, repeatedBool, repeatedBytes, repeatedResourceName, mapIntString, singleWrappedString, repeatedWrappedDouble, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="singleResourceName">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="singleWildcardResource">
        /// </param>
        /// <param name="repeatedWildcardResource">
        /// </param>
        /// <param name="multiPatternResourceName">
        /// </param>
        /// <param name="repeatedMultiPatternResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(string singleResourceName, scg::IEnumerable<string> repeatedResourceName, string singleWildcardResource, scg::IEnumerable<string> repeatedWildcardResource, string multiPatternResourceName, scg::IEnumerable<string> repeatedMultiPatternResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValues(new ValuesRequest
            {
                SingleResourceName = singleResourceName ?? "",
                RepeatedResourceName =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<string>(),
                },
                SingleWildcardResource = singleWildcardResource ?? "",
                RepeatedWildcardResource =
                {
                    repeatedWildcardResource ?? linq::Enumerable.Empty<string>(),
                },
                MultiPatternResourceName = multiPatternResourceName ?? "",
                RepeatedMultiPatternResourceName =
                {
                    repeatedMultiPatternResourceName ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleResourceName">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="singleWildcardResource">
        /// </param>
        /// <param name="repeatedWildcardResource">
        /// </param>
        /// <param name="multiPatternResourceName">
        /// </param>
        /// <param name="repeatedMultiPatternResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(string singleResourceName, scg::IEnumerable<string> repeatedResourceName, string singleWildcardResource, scg::IEnumerable<string> repeatedWildcardResource, string multiPatternResourceName, scg::IEnumerable<string> repeatedMultiPatternResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValuesAsync(new ValuesRequest
            {
                SingleResourceName = singleResourceName ?? "",
                RepeatedResourceName =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<string>(),
                },
                SingleWildcardResource = singleWildcardResource ?? "",
                RepeatedWildcardResource =
                {
                    repeatedWildcardResource ?? linq::Enumerable.Empty<string>(),
                },
                MultiPatternResourceName = multiPatternResourceName ?? "",
                RepeatedMultiPatternResourceName =
                {
                    repeatedMultiPatternResourceName ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleResourceName">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="singleWildcardResource">
        /// </param>
        /// <param name="repeatedWildcardResource">
        /// </param>
        /// <param name="multiPatternResourceName">
        /// </param>
        /// <param name="repeatedMultiPatternResourceName">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(string singleResourceName, scg::IEnumerable<string> repeatedResourceName, string singleWildcardResource, scg::IEnumerable<string> repeatedWildcardResource, string multiPatternResourceName, scg::IEnumerable<string> repeatedMultiPatternResourceName, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(singleResourceName, repeatedResourceName, singleWildcardResource, repeatedWildcardResource, multiPatternResourceName, repeatedMultiPatternResourceName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="singleResourceName">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="singleWildcardResource">
        /// </param>
        /// <param name="repeatedWildcardResource">
        /// </param>
        /// <param name="multiPatternResourceName">
        /// </param>
        /// <param name="repeatedMultiPatternResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodValues(AResourceName singleResourceName, scg::IEnumerable<AResourceName> repeatedResourceName, gax::IResourceName singleWildcardResource, scg::IEnumerable<gax::IResourceName> repeatedWildcardResource, MultiPatternResourceName multiPatternResourceName, scg::IEnumerable<MultiPatternResourceName> repeatedMultiPatternResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValues(new ValuesRequest
            {
                SingleResourceNameAsAResourceName = singleResourceName,
                RepeatedResourceNameAsAResourceNames =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<AResourceName>(),
                },
                SingleWildcardResourceAsResourceName = singleWildcardResource,
                RepeatedWildcardResourceAsResourceNames =
                {
                    repeatedWildcardResource ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
                MultiPatternResourceNameAsMultiPatternResourceName = multiPatternResourceName,
                RepeatedMultiPatternResourceNameAsMultiPatternResourceNames =
                {
                    repeatedMultiPatternResourceName ?? linq::Enumerable.Empty<MultiPatternResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleResourceName">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="singleWildcardResource">
        /// </param>
        /// <param name="repeatedWildcardResource">
        /// </param>
        /// <param name="multiPatternResourceName">
        /// </param>
        /// <param name="repeatedMultiPatternResourceName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(AResourceName singleResourceName, scg::IEnumerable<AResourceName> repeatedResourceName, gax::IResourceName singleWildcardResource, scg::IEnumerable<gax::IResourceName> repeatedWildcardResource, MultiPatternResourceName multiPatternResourceName, scg::IEnumerable<MultiPatternResourceName> repeatedMultiPatternResourceName, gaxgrpc::CallSettings callSettings = null) =>
            MethodValuesAsync(new ValuesRequest
            {
                SingleResourceNameAsAResourceName = singleResourceName,
                RepeatedResourceNameAsAResourceNames =
                {
                    repeatedResourceName ?? linq::Enumerable.Empty<AResourceName>(),
                },
                SingleWildcardResourceAsResourceName = singleWildcardResource,
                RepeatedWildcardResourceAsResourceNames =
                {
                    repeatedWildcardResource ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
                MultiPatternResourceNameAsMultiPatternResourceName = multiPatternResourceName,
                RepeatedMultiPatternResourceNameAsMultiPatternResourceNames =
                {
                    repeatedMultiPatternResourceName ?? linq::Enumerable.Empty<MultiPatternResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="singleResourceName">
        /// </param>
        /// <param name="repeatedResourceName">
        /// </param>
        /// <param name="singleWildcardResource">
        /// </param>
        /// <param name="repeatedWildcardResource">
        /// </param>
        /// <param name="multiPatternResourceName">
        /// </param>
        /// <param name="repeatedMultiPatternResourceName">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodValuesAsync(AResourceName singleResourceName, scg::IEnumerable<AResourceName> repeatedResourceName, gax::IResourceName singleWildcardResource, scg::IEnumerable<gax::IResourceName> repeatedWildcardResource, MultiPatternResourceName multiPatternResourceName, scg::IEnumerable<MultiPatternResourceName> repeatedMultiPatternResourceName, st::CancellationToken cancellationToken) =>
            MethodValuesAsync(singleResourceName, repeatedResourceName, singleWildcardResource, repeatedWildcardResource, multiPatternResourceName, repeatedMultiPatternResourceName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

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
    /// <remarks>
    /// </remarks>
    public sealed partial class UnitTestsClientImpl : UnitTestsClient
    {
        private readonly gaxgrpc::ApiCall<ValuesRequest, Response> _callMethodValues;

        private readonly gaxgrpc::ApiCall<LroRequest, lro::Operation> _callMethodLro;

        /// <summary>
        /// Constructs a client wrapper for the UnitTests service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="UnitTestsSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public UnitTestsClientImpl(UnitTests.UnitTestsClient grpcClient, UnitTestsSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            UnitTestsSettings effectiveSettings = settings ?? UnitTestsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            MethodLroOperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.MethodLroOperationsSettings, logger);
            _callMethodValues = clientHelper.BuildApiCall<ValuesRequest, Response>("MethodValues", grpcClient.MethodValuesAsync, grpcClient.MethodValues, effectiveSettings.MethodValuesSettings);
            Modify_ApiCall(ref _callMethodValues);
            Modify_MethodValuesApiCall(ref _callMethodValues);
            _callMethodLro = clientHelper.BuildApiCall<LroRequest, lro::Operation>("MethodLro", grpcClient.MethodLroAsync, grpcClient.MethodLro, effectiveSettings.MethodLroSettings);
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
