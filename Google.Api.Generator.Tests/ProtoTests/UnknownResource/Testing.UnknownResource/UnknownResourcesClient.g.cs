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
using sys = System;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.UnknownResource
{
    public abstract partial class UnknownResourcesClient
    {
        public Response AMethod(Request request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> AMethodAsync(Request request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="resource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response AMethod(gax::IResourceName resource, gaxgrpc::CallSettings callSettings = null) =>
            AMethod(new Request
            {
                ResourceAsResourceName = resource,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="resource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> AMethodAsync(gax::IResourceName resource, gaxgrpc::CallSettings callSettings = null) =>
            AMethodAsync(new Request
            {
                ResourceAsResourceName = resource,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="resource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> AMethodAsync(gax::IResourceName resource, st::CancellationToken cancellationToken) =>
            AMethodAsync(resource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
