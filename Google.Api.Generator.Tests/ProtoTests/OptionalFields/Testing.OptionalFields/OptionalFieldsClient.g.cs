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
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.OptionalFields
{
    public abstract partial class OptionalFieldsClient
    {
        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method1(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(Request request, st::CancellationToken cancellationToken) =>
            Method1Async(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="number">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method1(string name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1(new Request
            {
                Name = name ?? "",
                Number = number,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="number">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(string name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1Async(new Request
            {
                Name = name ?? "",
                Number = number,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="number">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(string name, int number, st::CancellationToken cancellationToken) =>
            Method1Async(name, number, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="number">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Method1(ResourceName name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1(new Request
            {
                ResourceName = name,
                Number = number,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="number">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(ResourceName name, int number, gaxgrpc::CallSettings callSettings = null) =>
            Method1Async(new Request
            {
                ResourceName = name,
                Number = number,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="number">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> Method1Async(ResourceName name, int number, st::CancellationToken cancellationToken) =>
            Method1Async(name, number, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
