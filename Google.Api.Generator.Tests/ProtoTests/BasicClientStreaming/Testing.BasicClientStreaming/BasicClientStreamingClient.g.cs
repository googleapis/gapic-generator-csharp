// Copyright 2021 Google LLC
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
using gaxgrpc = Google.Api.Gax.Grpc;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using sys = System;
using scg = System.Collections.Generic;
using stt = System.Threading.Tasks;

namespace Testing.BasicClientStreaming
{
    public sealed partial class BasicClientStreamingSettings : gaxgrpc::ServiceSettingsBase
    {
        private BasicClientStreamingSettings(BasicClientStreamingSettings existing) : base(existing)
        {
            // TEST_START
            MethodClientStreamingSettings = existing.MethodClientStreamingSettings;
            // TEST_END
        }

        
        // TEST_START
        public gaxgrpc::ClientStreamingSettings MethodClientStreamingSettings { get; set; } = new gaxgrpc::ClientStreamingSettings(100);
        // TEST_END
    }

    public abstract partial class BasicClientStreamingClient
    {
        // TEST_START
        /// <summary>
        /// Client streaming methods for
        /// <see cref="MethodClient(gaxgrpc::CallSettings,gaxgrpc::ClientStreamingSettings)"/>.
        /// </summary>
        public abstract partial class MethodClientStream : gaxgrpc::ClientStreamingBase<Request, Response>
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public virtual MethodClientStream MethodClient(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null) =>
            throw new sys::NotImplementedException();
        // TEST_END
    }

    /// <summary>BasicClientStreaming client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class BasicClientStreamingClientImpl : BasicClientStreamingClient
    {
        public BasicClientStreamingClientImpl() => _callMethodClient = null;

        // TEST_START
        private readonly gaxgrpc::ApiClientStreamingCall<Request, Response> _callMethodClient;
        // TEST_END

        // TEST_START
        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;
        // TEST_END

        // TEST_START
        partial void Modify_RequestCallSettings(ref gaxgrpc::CallSettings settings);

        partial void Modify_RequestRequest(ref Request request);
        // TEST_END

        // TEST_START
        internal sealed partial class MethodClientStreamImpl : MethodClientStream
        {
            /// <summary>Construct the client streaming method for <c>MethodClient</c>.</summary>
            /// <param name="service">The service containing this streaming method.</param>
            /// <param name="call">The underlying gRPC client streaming call.</param>
            /// <param name="writeBuffer">
            /// The <see cref="gaxgrpc::BufferedClientStreamWriter{Request}"/> instance associated with this streaming
            /// call.
            /// </param>
            public MethodClientStreamImpl(BasicClientStreamingClientImpl service, grpccore::AsyncClientStreamingCall<Request, Response> call, gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer)
            {
                _service = service;
                GrpcCall = call;
                _writeBuffer = writeBuffer;
            }

            private BasicClientStreamingClientImpl _service;

            private gaxgrpc::BufferedClientStreamWriter<Request> _writeBuffer;

            public override grpccore::AsyncClientStreamingCall<Request, Response> GrpcCall { get; }

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
        }
        // TEST_END

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <param name="streamingSettings">If not null, applies streaming overrides to this RPC call.</param>
        /// <returns>The client stream.</returns>
        public override BasicClientStreamingClient.MethodClientStream MethodClient(gaxgrpc::CallSettings callSettings = null, gaxgrpc::ClientStreamingSettings streamingSettings = null)
        {
            Modify_RequestCallSettings(ref callSettings);
            gaxgrpc::ClientStreamingSettings effectiveStreamingSettings = streamingSettings ?? _callMethodClient.StreamingSettings;
            grpccore::AsyncClientStreamingCall<Request, Response> call = _callMethodClient.Call(callSettings);
            gaxgrpc::BufferedClientStreamWriter<Request> writeBuffer = new gaxgrpc::BufferedClientStreamWriter<Request>(call.RequestStream, effectiveStreamingSettings.BufferedClientWriterCapacity);
            return new MethodClientStreamImpl(this, call, writeBuffer);
        }
        // TEST_END
    }
}
