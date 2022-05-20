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
using gaxgrpc = Google.Api.Gax.Grpc;

namespace Testing.ServerStreaming
{
    public abstract class ServerStreamingClient
    {
        // Class generation is tested in `BasicServerStreaming`.
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
            SignatureMethod(new Request { Name = name ?? "", }, callSettings);
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
            ResourcedMethod(new ResourceRequest { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test a server-streaming RPC with a method signature and resource-name.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The server stream.</returns>
        public virtual ResourcedMethodStream ResourcedMethod(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest { ResourceName = name, }, callSettings);
        // TEST_END
    }
}
