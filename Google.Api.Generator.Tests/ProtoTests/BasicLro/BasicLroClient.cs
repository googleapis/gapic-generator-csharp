using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using lro = Google.LongRunning;
using sys = System;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.Basiclro
{
    /// <summary>Settings for a <see cref="BasicLroClient"/>.</summary>
    public sealed partial class BasicLroSettings : gaxgrpc::ServiceSettingsBase
    {
        // TEST_START
        private BasicLroSettings(BasicLroSettings existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            Method1Settings = existing.Method1Settings;
            Method1OperationsSettings = existing.Method1OperationsSettings;
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
        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="request">
        /// The request object containing all of the parameters for the API call.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> Method1(Request request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">
        /// The request object containing all of the parameters for the API call.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> Method1Async(Request request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">
        /// The request object containing all of the parameters for the API call.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="st::CancellationToken"/> to use for this RPC.
        /// </param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> Method1Async(Request request, st::CancellationToken cancellationToken) => Method1Async(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>The long-running operations client for <c>Method1</c>.</summary>
        public virtual lro::OperationsClient Method1OperationsClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Poll an operation once, using an <c>operationName</c> from a previous invocation of
        /// <c>Method1</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The result of polling the operation.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> PollOnceMethod1(string operationName, gaxgrpc::CallSettings callSettings = null) => lro::Operation<LroResponse, LroMetadata>.PollOnceFromName(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), Method1OperationsClient, callSettings);

        /// <summary>
        /// Asynchronously poll an operation once, using an <c>operationName</c> from a previous
        /// invocation of <c>Method1</c>.
        /// </summary>
        /// <param name="operationName">
        /// The name of a previously invoked operation. Must not be <c>null</c> or empty.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A task representing the result of polling the operation.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> PollOnceMethod1Async(string operationName, gaxgrpc::CallSettings callSettings = null) => lro::Operation<LroResponse, LroMetadata>.PollOnceFromNameAsync(gax::GaxPreconditions.CheckNotNullOrEmpty(operationName, nameof(operationName)), Method1OperationsClient, callSettings);
        // TEST_END
    }
}
