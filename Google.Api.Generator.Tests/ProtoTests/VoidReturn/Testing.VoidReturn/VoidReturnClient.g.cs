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
using wkt = Google.Protobuf.WellKnownTypes;
using sys = System;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.VoidReturn
{
    public abstract class VoidReturnClient
    {
        public static VoidReturnClient Create() => throw new sys::NotImplementedException();
        public static stt::Task<VoidReturnClient> CreateAsync() => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void VoidMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task VoidMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task VoidMethodAsync(Request request, st::CancellationToken cancellationToken) =>
            VoidMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void VoidMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            VoidMethod(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task VoidMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            VoidMethodAsync(new Request { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task VoidMethodAsync(string name, st::CancellationToken cancellationToken) =>
            VoidMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual void VoidMethod(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            VoidMethod(new Request { ResourceName = name, }, callSettings);

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task VoidMethodAsync(ResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            VoidMethodAsync(new Request { ResourceName = name, }, callSettings);

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task VoidMethodAsync(ResourceName name, st::CancellationToken cancellationToken) =>
            VoidMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }

    public sealed partial class VoidReturnClientImpl : VoidReturnClient
    {
        public VoidReturnClientImpl(VoidReturn.VoidReturnClient grpcClient, object callSettings) => throw new sys::NotImplementedException();

        private readonly gaxgrpc::ApiCall<Request, wkt::Empty> _callVoidMethod = null;

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings callSettings);

        // TEST_START
        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override void VoidMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            _callVoidMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// Test returning `void`, with request methods and a method signature (flattening).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task VoidMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return _callVoidMethod.Async(request, callSettings);
        }
        // TEST_END
    }
}