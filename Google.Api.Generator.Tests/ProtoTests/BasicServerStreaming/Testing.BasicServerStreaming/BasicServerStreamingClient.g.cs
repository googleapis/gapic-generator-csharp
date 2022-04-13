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

using gaxgrpc = Google.Api.Gax.Grpc;
using grpccore = Grpc.Core;
using mel = Microsoft.Extensions.Logging;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;
using sys = System;

namespace Testing.BasicServerStreaming
{
    public sealed class BasicServerStreamingSettings : gaxgrpc::ServiceSettingsBase
    {
        public gaxgrpc::CallSettings MethodServerSettings { get; set; }
    }

    public abstract partial class BasicServerStreamingClient
    {
        // TEST_START
        /// <summary>Server streaming methods for <see cref="MethodServer(Request,gaxgrpc::CallSettings)"/>.</summary>
        public abstract partial class MethodServerStream : gaxgrpc::ServerStreamingBase<Response>
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual MethodServerStream MethodServer(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();
        // TEST_END
    }

    public sealed partial class BasicServerStreamingClientImpl : BasicServerStreamingClient
    {
        // TEST_START
        private readonly gaxgrpc::ApiServerStreamingCall<Request, Response> _callMethodServer;
        // TEST_END

        public BasicServerStreamingClientImpl(BasicServerStreaming.BasicServerStreamingClient grpcClient, mel::ILogger logger)
        {
            BasicServerStreamingSettings effectiveSettings = null;
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            // TEST_START
            _callMethodServer = clientHelper.BuildApiCall<Request, Response>("MethodServer", grpcClient.MethodServer, effectiveSettings.MethodServerSettings);
            // TEST_END
        }

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings callSettings);

        // TEST_START
        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiServerStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;
        // TEST_END

        // TEST_START
        internal sealed partial class MethodServerStreamImpl : MethodServerStream
        {
            /// <summary>Construct the server streaming method for <c>MethodServer</c>.</summary>
            /// <param name="call">The underlying gRPC server streaming call.</param>
            public MethodServerStreamImpl(grpccore::AsyncServerStreamingCall<Response> call) => GrpcCall = call;

            public override grpccore::AsyncServerStreamingCall<Response> GrpcCall { get; }
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public override BasicServerStreamingClient.MethodServerStream MethodServer(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new MethodServerStreamImpl(_callMethodServer.Call(request, callSettings));
        }
        // TEST_END
    }
}
