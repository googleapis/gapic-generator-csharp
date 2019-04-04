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
using sc = System.Collections;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using sysnet = System.Net;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace ResourceUpgradeTest
{
    /// <summary>Settings for a <see cref="LoggingServiceV2Client"/>.</summary>
    public sealed partial class LoggingServiceV2Settings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="LoggingServiceV2Settings"/>.</summary>
        /// <returns>A new instance of the default <see cref="LoggingServiceV2Settings"/>.</returns>
        public static LoggingServiceV2Settings GetDefault() => new LoggingServiceV2Settings();

        /// <summary>Constructs a new <see cref="LoggingServiceV2Settings"/> object with default settings.</summary>
        public LoggingServiceV2Settings()
        {
        }

        private LoggingServiceV2Settings(LoggingServiceV2Settings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteLogSettings = existing.DeleteLogSettings;
            ListLogsSettings = existing.ListLogsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(LoggingServiceV2Settings existing);

        private static readonly gaxgrpc::CallSettings _defaultIdempotentCallSettings = gaxgrpc::CallSettings.FromCallTiming(gaxgrpc::CallTiming.FromRetry(new gaxgrpc::RetrySettings(retryBackoff: new gaxgrpc::BackoffSettings(delay: sys::TimeSpan.FromMilliseconds(100), maxDelay: sys::TimeSpan.FromSeconds(60), delayMultiplier: 1.3), timeoutBackoff: new gaxgrpc::BackoffSettings(delay: sys::TimeSpan.FromSeconds(20), maxDelay: sys::TimeSpan.FromSeconds(20), delayMultiplier: 1), totalExpiration: gax::Expiration.FromTimeout(sys::TimeSpan.FromSeconds(20)), retryFilter: gaxgrpc::RetrySettings.FilterForStatusCodes(grpccore::StatusCode.Internal, grpccore::StatusCode.Unavailable))));

        private static readonly gaxgrpc::CallSettings _defaultNonIdempotentCallSettings = gaxgrpc::CallSettings.FromCallTiming(gaxgrpc::CallTiming.FromTimeout(sys::TimeSpan.FromSeconds(20)));

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>LoggingServiceV2Client.DeleteLog</c> and <c>LoggingServiceV2Client.DeleteLogAsync</c>.
        /// </summary>
        /// <remarks>By default, retry will not be attempted.</remarks>
        public gaxgrpc::CallSettings DeleteLogSettings { get; set; } = _defaultNonIdempotentCallSettings;

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>LoggingServiceV2Client.ListLogs</c> and <c>LoggingServiceV2Client.ListLogsAsync</c>.
        /// </summary>
        /// <remarks>
        /// The default <c>LoggingServiceV2Client.ListLogs</c> and <c>LoggingServiceV2Client.ListLogsAsync</c>
        /// <see cref="gaxgrpc::RetrySettings"/> are:
        /// <list type="bullet">
        /// <item><description>Initial retry delay: 100 milliseconds.</description></item>
        /// <item><description>Retry delay multiplier: 1.3</description></item>
        /// <item><description>Retry maximum delay: 60 seconds.</description></item>
        /// <item><description>Initial timeout: 20 seconds.</description></item>
        /// <item><description>Timeout multiplier: 1</description></item>
        /// <item><description>Timeout maximum delay: 20 seconds.</description></item>
        /// <item><description>Total timeout: 20 seconds.</description></item>
        /// </list>
        /// By default retry will be attempted on the following response status codes:
        /// <list type="bullet">
        /// <item><description><see cref="grpccore::StatusCode.Internal"/></description></item>
        /// <item><description><see cref="grpccore::StatusCode.Unavailable"/></description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListLogsSettings { get; set; } = _defaultIdempotentCallSettings;

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="LoggingServiceV2Settings"/> object.</returns>
        public LoggingServiceV2Settings Clone() => new LoggingServiceV2Settings(this);
    }

    /// <summary>LoggingServiceV2 client wrapper, for convenient use.</summary>
    public abstract partial class LoggingServiceV2Client
    {
        /// <summary>
        /// The default endpoint for the LoggingServiceV2 service, which is a host of "" and a port of 443.
        /// </summary>
        public static gaxgrpc::ServiceEndpoint DefaultEndpoint { get; } = new gaxgrpc::ServiceEndpoint("", 443);

        /// <summary>The default LoggingServiceV2 scopes.</summary>
        /// <remarks>The default LoggingServiceV2 scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        private static readonly gaxgrpc::ChannelPool s_channelPool = new gaxgrpc::ChannelPool(DefaultScopes);

        /// <summary>
        /// Asynchronously creates a <see cref="LoggingServiceV2Client"/>, applying defaults for all unspecified
        /// settings, and creating a channel connecting to the given endpoint with application default credentials where
        /// necessary. See the example for how to use custom credentials.
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
        /// <param name="settings">Optional <see cref="LoggingServiceV2Settings"/>.</param>
        /// <returns>The task representing the created <see cref="LoggingServiceV2Client"/>.</returns>
        public static async stt::Task<LoggingServiceV2Client> CreateAsync(gaxgrpc::ServiceEndpoint endpoint = null, LoggingServiceV2Settings settings = null)
        {
            grpccore::Channel channel = await s_channelPool.GetChannelAsync(endpoint ?? DefaultEndpoint).ConfigureAwait(false);
            return Create(channel, settings);
        }

        /// <summary>
        /// Synchronously creates a <see cref="LoggingServiceV2Client"/>, applying defaults for all unspecified
        /// settings, and creating a channel connecting to the given endpoint with application default credentials where
        /// necessary. See the example for how to use custom credentials.
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
        /// <param name="settings">Optional <see cref="LoggingServiceV2Settings"/>.</param>
        /// <returns>The created <see cref="LoggingServiceV2Client"/>.</returns>
        public static LoggingServiceV2Client Create(gaxgrpc::ServiceEndpoint endpoint = null, LoggingServiceV2Settings settings = null)
        {
            grpccore::Channel channel = s_channelPool.GetChannel(endpoint ?? DefaultEndpoint);
            return Create(channel, settings);
        }

        /// <summary>
        /// Creates a <see cref="LoggingServiceV2Client"/> which uses the specified channel for remote operations.
        /// </summary>
        /// <param name="channel">The <see cref="grpccore::Channel"/> for remote operations. Must not be null.</param>
        /// <param name="settings">Optional <see cref="LoggingServiceV2Settings"/>.</param>
        /// <returns>The created <see cref="LoggingServiceV2Client"/>.</returns>
        public static LoggingServiceV2Client Create(grpccore::Channel channel, LoggingServiceV2Settings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(channel, nameof(channel));
            return Create(new grpccore::DefaultCallInvoker(channel), settings);
        }

        /// <summary>
        /// Creates a <see cref="LoggingServiceV2Client"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="LoggingServiceV2Settings"/>.</param>
        /// <returns>The created <see cref="LoggingServiceV2Client"/>.</returns>
        public static LoggingServiceV2Client Create(grpccore::CallInvoker callInvoker, LoggingServiceV2Settings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            LoggingServiceV2.LoggingServiceV2Client grpcClient = new LoggingServiceV2.LoggingServiceV2Client(callInvoker);
            return new LoggingServiceV2ClientImpl(grpcClient, settings);
        }

        /// <summary>
        /// Shuts down any channels automatically created by
        /// <see cref="Create(grpccore::CallInvoker,LoggingServiceV2Settings)"/> and
        /// <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,LoggingServiceV2Settings)"/>. Channels which weren't
        /// automatically created are not affected.
        /// </summary>
        /// <remarks>
        /// After calling this method, further calls to
        /// <see cref="Create(grpccore::CallInvoker,LoggingServiceV2Settings)"/> and
        /// <see cref="CreateAsync(gaxgrpc::ServiceEndpoint,LoggingServiceV2Settings)"/> will create new channels, which
        /// could in turn be shut down by another call to this method.
        /// </remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => s_channelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC LoggingServiceV2 client</summary>
        public virtual LoggingServiceV2.LoggingServiceV2Client GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Empty DeleteLog(DeleteLogRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Empty> DeleteLogAsync(DeleteLogRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Empty> DeleteLogAsync(DeleteLogRequest request, st::CancellationToken cancellationToken) =>
            DeleteLogAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="logName">
        /// Required. The resource name of the log to delete:
        /// "projects/[PROJECT_ID]/logs/[LOG_ID]"
        /// "organizations/[ORGANIZATION_ID]/logs/[LOG_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]/logs/[LOG_ID]"
        /// "folders/[FOLDER_ID]/logs/[LOG_ID]"
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Empty DeleteLog(string logName, gaxgrpc::CallSettings callSettings = null) =>
            DeleteLog(new DeleteLogRequest
            {
                LogName = logName ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="logName">
        /// Required. The resource name of the log to delete:
        /// "projects/[PROJECT_ID]/logs/[LOG_ID]"
        /// "organizations/[ORGANIZATION_ID]/logs/[LOG_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]/logs/[LOG_ID]"
        /// "folders/[FOLDER_ID]/logs/[LOG_ID]"
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Empty> DeleteLogAsync(string logName, gaxgrpc::CallSettings callSettings = null) =>
            DeleteLogAsync(new DeleteLogRequest
            {
                LogName = logName ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="logName">
        /// Required. The resource name of the log to delete:
        /// "projects/[PROJECT_ID]/logs/[LOG_ID]"
        /// "organizations/[ORGANIZATION_ID]/logs/[LOG_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]/logs/[LOG_ID]"
        /// "folders/[FOLDER_ID]/logs/[LOG_ID]"
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Empty> DeleteLogAsync(string logName, st::CancellationToken cancellationToken) =>
            DeleteLogAsync(logName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="logName">
        /// Required. The resource name of the log to delete:
        /// "projects/[PROJECT_ID]/logs/[LOG_ID]"
        /// "organizations/[ORGANIZATION_ID]/logs/[LOG_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]/logs/[LOG_ID]"
        /// "folders/[FOLDER_ID]/logs/[LOG_ID]"
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Empty DeleteLog(LogName logName, gaxgrpc::CallSettings callSettings = null) =>
            DeleteLog(new DeleteLogRequest
            {
                LogNameAsLogName = logName,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="logName">
        /// Required. The resource name of the log to delete:
        /// "projects/[PROJECT_ID]/logs/[LOG_ID]"
        /// "organizations/[ORGANIZATION_ID]/logs/[LOG_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]/logs/[LOG_ID]"
        /// "folders/[FOLDER_ID]/logs/[LOG_ID]"
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Empty> DeleteLogAsync(LogName logName, gaxgrpc::CallSettings callSettings = null) =>
            DeleteLogAsync(new DeleteLogRequest
            {
                LogNameAsLogName = logName,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="logName">
        /// Required. The resource name of the log to delete:
        /// "projects/[PROJECT_ID]/logs/[LOG_ID]"
        /// "organizations/[ORGANIZATION_ID]/logs/[LOG_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]/logs/[LOG_ID]"
        /// "folders/[FOLDER_ID]/logs/[LOG_ID]"
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Empty> DeleteLogAsync(LogName logName, st::CancellationToken cancellationToken) =>
            DeleteLogAsync(logName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListLogsResponse, string> ListLogs(ListLogsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListLogsResponse, string> ListLogsAsync(ListLogsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="parent">
        /// Required. The resource name that owns the logs:
        /// "projects/[PROJECT_ID]"
        /// "organizations/[ORGANIZATION_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]"
        /// "folders/[FOLDER_ID]"
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListLogsResponse, string> ListLogs(string parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ListLogs(new ListLogsRequest
            {
                Parent = parent ?? "",
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="parent">
        /// Required. The resource name that owns the logs:
        /// "projects/[PROJECT_ID]"
        /// "organizations/[ORGANIZATION_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]"
        /// "folders/[FOLDER_ID]"
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListLogsResponse, string> ListLogsAsync(string parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ListLogsAsync(new ListLogsRequest
            {
                Parent = parent ?? "",
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="parent">
        /// Required. The resource name that owns the logs:
        /// "projects/[PROJECT_ID]"
        /// "organizations/[ORGANIZATION_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]"
        /// "folders/[FOLDER_ID]"
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ListLogsResponse, string> ListLogs(ProjectName parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ListLogs(new ListLogsRequest
            {
                ParentAsProjectName = parent,
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="parent">
        /// Required. The resource name that owns the logs:
        /// "projects/[PROJECT_ID]"
        /// "organizations/[ORGANIZATION_ID]"
        /// "billingAccounts/[BILLING_ACCOUNT_ID]"
        /// "folders/[FOLDER_ID]"
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ListLogsResponse, string> ListLogsAsync(ProjectName parent, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ListLogsAsync(new ListLogsRequest
            {
                ParentAsProjectName = parent,
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);
    }

    /// <summary>LoggingServiceV2 client wrapper implementation, for convenient use.</summary>
    public sealed partial class LoggingServiceV2ClientImpl : LoggingServiceV2Client
    {
        private readonly gaxgrpc::ApiCall<DeleteLogRequest, Empty> _callDeleteLog;

        private readonly gaxgrpc::ApiCall<ListLogsRequest, ListLogsResponse> _callListLogs;

        /// <summary>
        /// Constructs a client wrapper for the LoggingServiceV2 service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="LoggingServiceV2Settings"/> used within this client.</param>
        public LoggingServiceV2ClientImpl(LoggingServiceV2.LoggingServiceV2Client grpcClient, LoggingServiceV2Settings settings)
        {
            GrpcClient = grpcClient;
            LoggingServiceV2Settings effectiveSettings = settings ?? LoggingServiceV2Settings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDeleteLog = clientHelper.BuildApiCall<DeleteLogRequest, Empty>(grpcClient.DeleteLogAsync, grpcClient.DeleteLog, effectiveSettings.DeleteLogSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"log_name={(sysnet::WebUtility.UrlEncode(request.LogName))}"));
            Modify_ApiCall(ref _callDeleteLog);
            Modify_DeleteLogApiCall(ref _callDeleteLog);
            _callListLogs = clientHelper.BuildApiCall<ListLogsRequest, ListLogsResponse>(grpcClient.ListLogsAsync, grpcClient.ListLogs, effectiveSettings.ListLogsSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"parent={(sysnet::WebUtility.UrlEncode(request.Parent))}"));
            Modify_ApiCall(ref _callListLogs);
            Modify_ListLogsApiCall(ref _callListLogs);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteLogApiCall(ref gaxgrpc::ApiCall<DeleteLogRequest, Empty> call);

        partial void Modify_ListLogsApiCall(ref gaxgrpc::ApiCall<ListLogsRequest, ListLogsResponse> call);

        partial void OnConstruction(LoggingServiceV2.LoggingServiceV2Client grpcClient, LoggingServiceV2Settings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC LoggingServiceV2 client</summary>
        public override LoggingServiceV2.LoggingServiceV2Client GrpcClient { get; }

        partial void Modify_DeleteLogRequest(ref DeleteLogRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListLogsRequest(ref ListLogsRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Empty DeleteLog(DeleteLogRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteLogRequest(ref request, ref callSettings);
            return _callDeleteLog.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Empty> DeleteLogAsync(DeleteLogRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteLogRequest(ref request, ref callSettings);
            return _callDeleteLog.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public override gax::PagedEnumerable<ListLogsResponse, string> ListLogs(ListLogsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListLogsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<ListLogsRequest, ListLogsResponse, string>(_callListLogs, request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<ListLogsResponse, string> ListLogsAsync(ListLogsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListLogsRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<ListLogsRequest, ListLogsResponse, string>(_callListLogs, request, callSettings);
        }
    }

    public partial class ListLogsRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class ListLogsResponse : gaxgrpc::IPageResponse<string>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<string> GetEnumerator() => LogNames.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
