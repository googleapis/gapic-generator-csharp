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
using wkt = Google.Protobuf.WellKnownTypes;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using sc = System.Collections;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Settings for <see cref="TestingClient"/> instances.</summary>
    public sealed partial class TestingSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="TestingSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="TestingSettings"/>.</returns>
        public static TestingSettings GetDefault() => new TestingSettings();

        /// <summary>Constructs a new <see cref="TestingSettings"/> object with default settings.</summary>
        public TestingSettings()
        {
        }

        private TestingSettings(TestingSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            CreateSessionSettings = existing.CreateSessionSettings;
            GetSessionSettings = existing.GetSessionSettings;
            ListSessionsSettings = existing.ListSessionsSettings;
            DeleteSessionSettings = existing.DeleteSessionSettings;
            ReportSessionSettings = existing.ReportSessionSettings;
            ListTestsSettings = existing.ListTestsSettings;
            DeleteTestSettings = existing.DeleteTestSettings;
            VerifyTestSettings = existing.VerifyTestSettings;
            OnCopy(existing);
        }

        partial void OnCopy(TestingSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.CreateSession</c>
        ///  and <c>TestingClient.CreateSessionAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CreateSessionSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.GetSession</c>
        ///  and <c>TestingClient.GetSessionAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSessionSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.ListSessions</c>
        ///  and <c>TestingClient.ListSessionsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSessionsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.DeleteSession</c>
        ///  and <c>TestingClient.DeleteSessionAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSessionSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.ReportSession</c>
        ///  and <c>TestingClient.ReportSessionAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ReportSessionSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.ListTests</c>
        /// and <c>TestingClient.ListTestsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListTestsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.DeleteTest</c>
        ///  and <c>TestingClient.DeleteTestAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteTestSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TestingClient.VerifyTest</c>
        ///  and <c>TestingClient.VerifyTestAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings VerifyTestSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="TestingSettings"/> object.</returns>
        public TestingSettings Clone() => new TestingSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="TestingClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class TestingClientBuilder : gaxgrpc::ClientBuilderBase<TestingClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public TestingSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public TestingClientBuilder() : base(TestingClient.ServiceMetadata)
        {
        }

        partial void InterceptBuild(ref TestingClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<TestingClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override TestingClient Build()
        {
            TestingClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<TestingClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<TestingClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private TestingClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return TestingClient.Create(callInvoker, Settings, Logger);
        }

        private async stt::Task<TestingClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return TestingClient.Create(callInvoker, Settings, Logger);
        }

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => TestingClient.ChannelPool;
    }

    /// <summary>Testing client wrapper, for convenient use.</summary>
    /// <remarks>
    /// A service to facilitate running discrete sets of tests
    /// against Showcase.
    /// </remarks>
    public abstract partial class TestingClient
    {
        /// <summary>
        /// The default endpoint for the Testing service, which is a host of "localhost:7469" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "localhost:7469:443";

        /// <summary>The default Testing scopes.</summary>
        /// <remarks>The default Testing scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        /// <summary>The service metadata associated with this client type.</summary>
        public static gaxgrpc::ServiceMetadata ServiceMetadata { get; } = new gaxgrpc::ServiceMetadata(Testing.Descriptor, DefaultEndpoint, DefaultScopes, true, gax::ApiTransports.Grpc | gax::ApiTransports.Rest, PackageApiMetadata.ApiMetadata);

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(ServiceMetadata);

        /// <summary>
        /// Asynchronously creates a <see cref="TestingClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="TestingClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="TestingClient"/>.</returns>
        public static stt::Task<TestingClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new TestingClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="TestingClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="TestingClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="TestingClient"/>.</returns>
        public static TestingClient Create() => new TestingClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="TestingClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="TestingSettings"/>.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/>.</param>
        /// <returns>The created <see cref="TestingClient"/>.</returns>
        internal static TestingClient Create(grpccore::CallInvoker callInvoker, TestingSettings settings = null, mel::ILogger logger = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Testing.TestingClient grpcClient = new Testing.TestingClient(callInvoker);
            return new TestingClientImpl(grpcClient, settings, logger);
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

        /// <summary>The underlying gRPC Testing client</summary>
        public virtual Testing.TestingClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a new testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Session CreateSession(CreateSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a new testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Session> CreateSessionAsync(CreateSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a new testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Session> CreateSessionAsync(CreateSessionRequest request, st::CancellationToken cancellationToken) =>
            CreateSessionAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets a testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Session GetSession(GetSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets a testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Session> GetSessionAsync(GetSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets a testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Session> GetSessionAsync(GetSessionRequest request, st::CancellationToken cancellationToken) =>
            GetSessionAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the current test sessions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Session"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListSessionsResponse, Session> ListSessions(ListSessionsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the current test sessions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Session"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListSessionsResponse, Session> ListSessionsAsync(ListSessionsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Delete a test session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteSession(DeleteSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Delete a test session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteSessionAsync(DeleteSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Delete a test session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteSessionAsync(DeleteSessionRequest request, st::CancellationToken cancellationToken) =>
            DeleteSessionAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Report on the status of a session.
        /// This generates a report detailing which tests have been completed,
        /// and an overall rollup.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual ReportSessionResponse ReportSession(ReportSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Report on the status of a session.
        /// This generates a report detailing which tests have been completed,
        /// and an overall rollup.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ReportSessionResponse> ReportSessionAsync(ReportSessionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Report on the status of a session.
        /// This generates a report detailing which tests have been completed,
        /// and an overall rollup.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ReportSessionResponse> ReportSessionAsync(ReportSessionRequest request, st::CancellationToken cancellationToken) =>
            ReportSessionAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// List the tests of a sessesion.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Test"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListTestsResponse, Test> ListTests(ListTestsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// List the tests of a sessesion.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Test"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListTestsResponse, Test> ListTestsAsync(ListTestsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Explicitly decline to implement a test.
        /// 
        /// This removes the test from subsequent `ListTests` calls, and
        /// attempting to do the test will error.
        /// 
        /// This method will error if attempting to delete a required test.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void DeleteTest(DeleteTestRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Explicitly decline to implement a test.
        /// 
        /// This removes the test from subsequent `ListTests` calls, and
        /// attempting to do the test will error.
        /// 
        /// This method will error if attempting to delete a required test.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteTestAsync(DeleteTestRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Explicitly decline to implement a test.
        /// 
        /// This removes the test from subsequent `ListTests` calls, and
        /// attempting to do the test will error.
        /// 
        /// This method will error if attempting to delete a required test.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task DeleteTestAsync(DeleteTestRequest request, st::CancellationToken cancellationToken) =>
            DeleteTestAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Register a response to a test.
        /// 
        /// In cases where a test involves registering a final answer at the
        /// end of the test, this method provides the means to do so.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VerifyTestResponse VerifyTest(VerifyTestRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Register a response to a test.
        /// 
        /// In cases where a test involves registering a final answer at the
        /// end of the test, this method provides the means to do so.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VerifyTestResponse> VerifyTestAsync(VerifyTestRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Register a response to a test.
        /// 
        /// In cases where a test involves registering a final answer at the
        /// end of the test, this method provides the means to do so.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VerifyTestResponse> VerifyTestAsync(VerifyTestRequest request, st::CancellationToken cancellationToken) =>
            VerifyTestAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Testing client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// A service to facilitate running discrete sets of tests
    /// against Showcase.
    /// </remarks>
    public sealed partial class TestingClientImpl : TestingClient
    {
        private readonly gaxgrpc::ApiCall<CreateSessionRequest, Session> _callCreateSession;

        private readonly gaxgrpc::ApiCall<GetSessionRequest, Session> _callGetSession;

        private readonly gaxgrpc::ApiCall<ListSessionsRequest, ListSessionsResponse> _callListSessions;

        private readonly gaxgrpc::ApiCall<DeleteSessionRequest, wkt::Empty> _callDeleteSession;

        private readonly gaxgrpc::ApiCall<ReportSessionRequest, ReportSessionResponse> _callReportSession;

        private readonly gaxgrpc::ApiCall<ListTestsRequest, ListTestsResponse> _callListTests;

        private readonly gaxgrpc::ApiCall<DeleteTestRequest, wkt::Empty> _callDeleteTest;

        private readonly gaxgrpc::ApiCall<VerifyTestRequest, VerifyTestResponse> _callVerifyTest;

        /// <summary>
        /// Constructs a client wrapper for the Testing service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="TestingSettings"/> used within this client.</param>
        /// <param name="logger">Optional <see cref="mel::ILogger"/> to use within this client.</param>
        public TestingClientImpl(Testing.TestingClient grpcClient, TestingSettings settings, mel::ILogger logger)
        {
            GrpcClient = grpcClient;
            TestingSettings effectiveSettings = settings ?? TestingSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callCreateSession = clientHelper.BuildApiCall<CreateSessionRequest, Session>("CreateSession", grpcClient.CreateSessionAsync, grpcClient.CreateSession, effectiveSettings.CreateSessionSettings);
            Modify_ApiCall(ref _callCreateSession);
            Modify_CreateSessionApiCall(ref _callCreateSession);
            _callGetSession = clientHelper.BuildApiCall<GetSessionRequest, Session>("GetSession", grpcClient.GetSessionAsync, grpcClient.GetSession, effectiveSettings.GetSessionSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callGetSession);
            Modify_GetSessionApiCall(ref _callGetSession);
            _callListSessions = clientHelper.BuildApiCall<ListSessionsRequest, ListSessionsResponse>("ListSessions", grpcClient.ListSessionsAsync, grpcClient.ListSessions, effectiveSettings.ListSessionsSettings);
            Modify_ApiCall(ref _callListSessions);
            Modify_ListSessionsApiCall(ref _callListSessions);
            _callDeleteSession = clientHelper.BuildApiCall<DeleteSessionRequest, wkt::Empty>("DeleteSession", grpcClient.DeleteSessionAsync, grpcClient.DeleteSession, effectiveSettings.DeleteSessionSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callDeleteSession);
            Modify_DeleteSessionApiCall(ref _callDeleteSession);
            _callReportSession = clientHelper.BuildApiCall<ReportSessionRequest, ReportSessionResponse>("ReportSession", grpcClient.ReportSessionAsync, grpcClient.ReportSession, effectiveSettings.ReportSessionSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callReportSession);
            Modify_ReportSessionApiCall(ref _callReportSession);
            _callListTests = clientHelper.BuildApiCall<ListTestsRequest, ListTestsResponse>("ListTests", grpcClient.ListTestsAsync, grpcClient.ListTests, effectiveSettings.ListTestsSettings).WithGoogleRequestParam("parent", request => request.Parent);
            Modify_ApiCall(ref _callListTests);
            Modify_ListTestsApiCall(ref _callListTests);
            _callDeleteTest = clientHelper.BuildApiCall<DeleteTestRequest, wkt::Empty>("DeleteTest", grpcClient.DeleteTestAsync, grpcClient.DeleteTest, effectiveSettings.DeleteTestSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callDeleteTest);
            Modify_DeleteTestApiCall(ref _callDeleteTest);
            _callVerifyTest = clientHelper.BuildApiCall<VerifyTestRequest, VerifyTestResponse>("VerifyTest", grpcClient.VerifyTestAsync, grpcClient.VerifyTest, effectiveSettings.VerifyTestSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callVerifyTest);
            Modify_VerifyTestApiCall(ref _callVerifyTest);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_CreateSessionApiCall(ref gaxgrpc::ApiCall<CreateSessionRequest, Session> call);

        partial void Modify_GetSessionApiCall(ref gaxgrpc::ApiCall<GetSessionRequest, Session> call);

        partial void Modify_ListSessionsApiCall(ref gaxgrpc::ApiCall<ListSessionsRequest, ListSessionsResponse> call);

        partial void Modify_DeleteSessionApiCall(ref gaxgrpc::ApiCall<DeleteSessionRequest, wkt::Empty> call);

        partial void Modify_ReportSessionApiCall(ref gaxgrpc::ApiCall<ReportSessionRequest, ReportSessionResponse> call);

        partial void Modify_ListTestsApiCall(ref gaxgrpc::ApiCall<ListTestsRequest, ListTestsResponse> call);

        partial void Modify_DeleteTestApiCall(ref gaxgrpc::ApiCall<DeleteTestRequest, wkt::Empty> call);

        partial void Modify_VerifyTestApiCall(ref gaxgrpc::ApiCall<VerifyTestRequest, VerifyTestResponse> call);

        partial void OnConstruction(Testing.TestingClient grpcClient, TestingSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Testing client</summary>
        public override Testing.TestingClient GrpcClient { get; }

        partial void Modify_CreateSessionRequest(ref CreateSessionRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetSessionRequest(ref GetSessionRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListSessionsRequest(ref ListSessionsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteSessionRequest(ref DeleteSessionRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ReportSessionRequest(ref ReportSessionRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListTestsRequest(ref ListTestsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteTestRequest(ref DeleteTestRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_VerifyTestRequest(ref VerifyTestRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Creates a new testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Session CreateSession(CreateSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateSessionRequest(ref request, ref callSettings);
            return _callCreateSession.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a new testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Session> CreateSessionAsync(CreateSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateSessionRequest(ref request, ref callSettings);
            return _callCreateSession.Async(request, callSettings);
        }

        /// <summary>
        /// Gets a testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Session GetSession(GetSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSessionRequest(ref request, ref callSettings);
            return _callGetSession.Sync(request, callSettings);
        }

        /// <summary>
        /// Gets a testing session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Session> GetSessionAsync(GetSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSessionRequest(ref request, ref callSettings);
            return _callGetSession.Async(request, callSettings);
        }

        /// <summary>
        /// Lists the current test sessions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Session"/> resources.</returns>
        public override gax::PagedEnumerable<ListSessionsResponse, Session> ListSessions(ListSessionsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListSessionsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<ListSessionsRequest, ListSessionsResponse, Session>(_callListSessions, request, callSettings);
        }

        /// <summary>
        /// Lists the current test sessions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Session"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<ListSessionsResponse, Session> ListSessionsAsync(ListSessionsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListSessionsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<ListSessionsRequest, ListSessionsResponse, Session>(_callListSessions, request, callSettings);
        }

        /// <summary>
        /// Delete a test session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override void DeleteSession(DeleteSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSessionRequest(ref request, ref callSettings);
            _callDeleteSession.Sync(request, callSettings);
        }

        /// <summary>
        /// Delete a test session.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task DeleteSessionAsync(DeleteSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSessionRequest(ref request, ref callSettings);
            return _callDeleteSession.Async(request, callSettings);
        }

        /// <summary>
        /// Report on the status of a session.
        /// This generates a report detailing which tests have been completed,
        /// and an overall rollup.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override ReportSessionResponse ReportSession(ReportSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ReportSessionRequest(ref request, ref callSettings);
            return _callReportSession.Sync(request, callSettings);
        }

        /// <summary>
        /// Report on the status of a session.
        /// This generates a report detailing which tests have been completed,
        /// and an overall rollup.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<ReportSessionResponse> ReportSessionAsync(ReportSessionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ReportSessionRequest(ref request, ref callSettings);
            return _callReportSession.Async(request, callSettings);
        }

        /// <summary>
        /// List the tests of a sessesion.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Test"/> resources.</returns>
        public override gax::PagedEnumerable<ListTestsResponse, Test> ListTests(ListTestsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTestsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<ListTestsRequest, ListTestsResponse, Test>(_callListTests, request, callSettings);
        }

        /// <summary>
        /// List the tests of a sessesion.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Test"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<ListTestsResponse, Test> ListTestsAsync(ListTestsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTestsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<ListTestsRequest, ListTestsResponse, Test>(_callListTests, request, callSettings);
        }

        /// <summary>
        /// Explicitly decline to implement a test.
        /// 
        /// This removes the test from subsequent `ListTests` calls, and
        /// attempting to do the test will error.
        /// 
        /// This method will error if attempting to delete a required test.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override void DeleteTest(DeleteTestRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTestRequest(ref request, ref callSettings);
            _callDeleteTest.Sync(request, callSettings);
        }

        /// <summary>
        /// Explicitly decline to implement a test.
        /// 
        /// This removes the test from subsequent `ListTests` calls, and
        /// attempting to do the test will error.
        /// 
        /// This method will error if attempting to delete a required test.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task DeleteTestAsync(DeleteTestRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTestRequest(ref request, ref callSettings);
            return _callDeleteTest.Async(request, callSettings);
        }

        /// <summary>
        /// Register a response to a test.
        /// 
        /// In cases where a test involves registering a final answer at the
        /// end of the test, this method provides the means to do so.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override VerifyTestResponse VerifyTest(VerifyTestRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_VerifyTestRequest(ref request, ref callSettings);
            return _callVerifyTest.Sync(request, callSettings);
        }

        /// <summary>
        /// Register a response to a test.
        /// 
        /// In cases where a test involves registering a final answer at the
        /// end of the test, this method provides the means to do so.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<VerifyTestResponse> VerifyTestAsync(VerifyTestRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_VerifyTestRequest(ref request, ref callSettings);
            return _callVerifyTest.Async(request, callSettings);
        }
    }

    public partial class ListSessionsRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class ListTestsRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class ListSessionsResponse : gaxgrpc::IPageResponse<Session>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<Session> GetEnumerator() => Sessions.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public partial class ListTestsResponse : gaxgrpc::IPageResponse<Test>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<Test> GetEnumerator() => Tests.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
