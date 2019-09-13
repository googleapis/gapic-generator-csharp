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

using cn = Common.Namespace;
using gaxgrpc = Google.Api.Gax.Grpc;
using stt = System.Threading.Tasks;
using st = System.Threading;
using sys = System;

namespace Testing.CommonResource
{
    public abstract partial class CommonResourceClient
    {
        public Response MethodWithCommonResource(Request request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> MethodWithCommonResourceAsync(Request request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="projectName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MethodWithCommonResource(cn::CommonProjectName projectName, gaxgrpc::CallSettings callSettings = null) =>
            MethodWithCommonResource(new Request
            {
                ProjectNameAsCommonProjectName = projectName,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="projectName">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodWithCommonResourceAsync(cn::CommonProjectName projectName, gaxgrpc::CallSettings callSettings = null) =>
            MethodWithCommonResourceAsync(new Request
            {
                ProjectNameAsCommonProjectName = projectName,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="projectName">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MethodWithCommonResourceAsync(cn::CommonProjectName projectName, st::CancellationToken cancellationToken) =>
            MethodWithCommonResourceAsync(projectName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
