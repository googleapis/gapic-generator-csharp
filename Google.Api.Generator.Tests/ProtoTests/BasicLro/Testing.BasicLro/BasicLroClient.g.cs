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
using lro = Google.LongRunning;
using mel = Microsoft.Extensions.Logging;
using sys = System;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.BasicLro
{
    /// <summary>Settings for a <see cref="BasicLroClient"/>.</summary>
    public sealed partial class BasicLroSettings : gaxgrpc::ServiceSettingsBase
    {
        public BasicLroSettings() { }

        // TEST_START
        private BasicLroSettings(BasicLroSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            Method1Settings = existing.Method1Settings;
            Method1OperationsSettings = existing.Method1OperationsSettings.Clone();
            OnCopy(existing);
        }
        // TEST_END

        partial void OnCopy(BasicLroSettings existing);

        public gaxgrpc::CallSettings Method1Settings { get; set; }

        // TEST_START
        /// <summary>
        /// Long Running Operation settings for calls to <c>BasicLroClient.Method1</c> and
        /// <c>BasicLroClient.Method1Async</c>.
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
        public lro::OperationsSettings Method1OperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };
        // TEST_END
    }

    public abstract class BasicLroClient
    {
        public static BasicLroClient Create() => throw new sys::NotImplementedException();
        public static stt::Task<BasicLroClient> CreateAsync() => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> Method1(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> Method1Async(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> Method1Async(Request request, st::CancellationToken cancellationToken) =>
            Method1Async(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>Method1</c>.</summary>
        public virtual lro::OperationsClient Method1OperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of <c>Method1</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> PollOnceMethod1(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), Method1OperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>Method1</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> PollOnceMethod1Async(string operationName, gaxgrpc::CallSettings callSettings = null) =>
            lro::Operation<LroResponse, LroMetadata>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), Method1OperationsClient, callSettings);
        // TEST_END
    }

    public sealed partial class BasicLroClientImpl : BasicLroClient
    {
        private readonly gaxgrpc::ApiCall<Request, lro::Operation> _callMethod1 = null;

        public BasicLroClientImpl(BasicLro.BasicLroClient grpcClient, mel::ILogger logger)
        {
            var effectiveSettings = new BasicLroSettings();
            // TEST_START
            Method1OperationsClient = new lro::OperationsClientImpl(grpcClient.CreateOperationsClient(), effectiveSettings.Method1OperationsSettings, logger);
            // TEST_END
        }

        // TEST_START
        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings settings);

        /// <summary>The long-running operations client for <c>Method1</c>.</summary>
        public override lro::OperationsClient Method1OperationsClient { get; }

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override lro::Operation<LroResponse, LroMetadata> Method1(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(_callMethod1.Sync(request, callSettings), Method1OperationsClient);
        }

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override async stt::Task<lro::Operation<LroResponse, LroMetadata>> Method1Async(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new lro::Operation<LroResponse, LroMetadata>(await _callMethod1.Async(request, callSettings).ConfigureAwait(false), Method1OperationsClient);
        }
    }

    public static partial class BasicLro
    {
        public partial class BasicLroClient
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
    // TEST_END
}
