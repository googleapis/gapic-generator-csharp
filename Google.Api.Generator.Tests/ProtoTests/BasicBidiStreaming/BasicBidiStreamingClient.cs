using gaxgrpc = Google.Api.Gax.Grpc;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using sys = System;
using scg = System.Collections.Generic;
using stt = System.Threading.Tasks;

namespace Testing.Basicbidistreaming
{
    public sealed partial class BasicBidiStreamingSettings : gaxgrpc::ServiceSettingsBase
    {

        private BasicBidiStreamingSettings(BasicBidiStreamingSettings existing) : base(existing)
        {
            // TEST_START
            MethodBidiStreamingSettings = existing.MethodBidiStreamingSettings;
            // TEST_END
        }

        // TEST_START
        /// <summary>
        /// <see cref="gaxgrpc::BidirectionalStreamingSettings"/> for calls to <c>BasicBidiStreamingClient.MethodBidi</c>
        ///  and <c>BasicBidiStreamingClient.MethodBidiAsync</c>.
        /// </summary>
        /// <remarks>The default local send queue size is 100.</remarks>
        public gaxgrpc::BidirectionalStreamingSettings MethodBidiStreamingSettings { get; set; } = new gaxgrpc::BidirectionalStreamingSettings(100);
        // TEST_END
    }

    public abstract partial class BasicBidiStreamingClient
    {
        // TEST_START
        /// <summary>
        /// Bidirectional streaming methods for
        /// <see cref="MethodBidi(gaxgrpc::CallSettings,gaxgrpc::BidirectionalStreamingSettings)"/>.
        /// </summary>
        public abstract partial class MethodBidiStream : gaxgrpc::BidirectionalStreamingBase<Request, Response>
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public virtual MethodBidiStream MethodBidi(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();
        // TEST_END
    }

    public sealed partial class BasicBidiStreamingClientImpl : BasicBidiStreamingClient
    {
        // TEST_START
        private readonly gaxgrpc::ApiBidirectionalStreamingCall<Request, Response> _callMethodBidi;
        // TEST_END

        // TEST_START
        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiBidirectionalStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;
        // TEST_END

        // TEST_START
        partial void Modify_RequestCallSettings(ref gaxgrpc::CallSettings settings);

        partial void Modify_RequestRequest(ref Request request);
        // TEST_END

        // TEST_START
        internal sealed partial class MethodBidiStreamImpl : MethodBidiStream
        {
            /// <summary>Construct the bidirectional streaming method for <c>MethodBidi</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC duplex streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{Request}"/> instance associated with this streaming
            /// call.
            /// </param>
            public MethodBidiStreamImpl(BasicBidiStreamingClientImpl service, grpccore::AsyncDuplexStreamingCall<Request, Response> call, gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private BasicBidiStreamingClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<Request> _writeBuffer;

            public override grpccore::AsyncDuplexStreamingCall<Request, Response> GrpcCall { get; }

            private Request ModifyRequest(Request request)
            {
                _service.Modify_RequestRequest(ref request);
                return request;
            }

            public override stt::Task TryWriteAsync(Request message) => _writeBuffer.TryWriteAsync(ModifyRequest(message));

            public override stt::Task WriteAsync(Request message) => _writeBuffer.WriteAsync(ModifyRequest(message));

            public override stt::Task TryWriteAsync(Request message, grpccore::WriteOptions options) =>
                _writeBuffer.TryWriteAsync(ModifyRequest(message), options);

            public override stt::Task WriteAsync(Request message, grpccore::WriteOptions options) =>
                _writeBuffer.WriteAsync(ModifyRequest(message), options);

            public override stt::Task TryWriteCompleteAsync() => _writeBuffer.TryWriteCompleteAsync();

            public override stt::Task WriteCompleteAsync() => _writeBuffer.WriteCompleteAsync();

            public override scg::IAsyncEnumerator<Response> ResponseStream => GrpcCall.ResponseStream;
        }

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client-server stream.</returns>
        public override BasicBidiStreamingClient.MethodBidiStream MethodBidi(gaxgrpc::CallSettings callSettings = null, gaxgrpc::BidirectionalStreamingSettings streamingSettings = null)
        {
            Modify_RequestCallSettings(ref callSettings);
            gaxgrpc::BidirectionalStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callMethodBidi.StreamingSettings;
            grpccore::AsyncDuplexStreamingCall<Request, Response> call = _callMethodBidi.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<Request>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new MethodBidiStreamImpl(this, call, writeBuffer);
        }
        // TEST_END
    }
}
