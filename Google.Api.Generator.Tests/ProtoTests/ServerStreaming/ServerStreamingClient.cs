using gaxgrpc = Google.Api.Gax.Grpc;

namespace Testing.Serverstreaming
{
    public abstract class ServerStreamingClient
    {
        public abstract class SignatureMethodStream : gaxgrpc::ServerStreamingBase<Response> { }
        public SignatureMethodStream SignatureMethod(Request request, gaxgrpc::CallSettings callSettings = null) => null;

        // TEST_START
        /// <summary>
        /// Test a server-streaming RPC with a method signature.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual SignatureMethodStream SignatureMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethod(new Request
            {
                Name = name ?? "",
            }, callSettings);
        // TEST_END

        public abstract class ResourcedMethodStream : gaxgrpc::ServerStreamingBase<Response> { }
        public ResourcedMethodStream ResourcedMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) => null;

        // TEST_START
        /// <summary>
        /// Test a server-streaming RPC with a method signature and resource-name.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual ResourcedMethodStream ResourcedMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// Test a server-streaming RPC with a method signature and resource-name.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual ResourcedMethodStream ResourcedMethod(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest
            {
                ResourceName = name,
            }, callSettings);
        // TEST_END
    }
}
