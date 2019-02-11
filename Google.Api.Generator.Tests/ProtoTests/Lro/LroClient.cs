using gaxgrpc = Google.Api.Gax.Grpc;
using lro = Google.LongRunning;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.Lro
{
    public abstract class LroClient
    {
        public lro::Operation<LroResponse, LroMetadata> SignatureMethod(Request request, gaxgrpc::CallSettings callSettings) => null;
        public stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(Request request, gaxgrpc::CallSettings callSettings) => null;

        // TEST_START
        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> SignatureMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethod(new Request
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethodAsync(new Request
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> SignatureMethodAsync(string name, st::CancellationToken cancellationToken) =>
            SignatureMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public lro::Operation<LroResponse, LroMetadata> ResourcedMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings) => null;
        public stt::Task<lro::Operation<LroResponse, LroMetadata>> ResourcedMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings) => null;

        // TEST_START
        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> ResourcedMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> ResourcedMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethodAsync(new ResourceRequest
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> ResourcedMethodAsync(string name, st::CancellationToken cancellationToken) =>
            ResourcedMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual lro::Operation<LroResponse, LroMetadata> ResourcedMethod(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest
            {
                ResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> ResourcedMethodAsync(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethodAsync(new ResourceRequest
            {
                ResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test an LRO RPC with a method signature that contains resource-names.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<lro::Operation<LroResponse, LroMetadata>> ResourcedMethodAsync(ResourceName name, st::CancellationToken cancellationToken) =>
            ResourcedMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
