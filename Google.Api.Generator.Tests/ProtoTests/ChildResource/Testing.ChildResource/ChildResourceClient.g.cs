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
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.ChildResource
{
    public abstract class ChildResourceClient
    {
        public virtual stt::Task<Response> SingleAsync(ProjectRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();
        public virtual Response Single(ProjectRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="projectUserParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Single(string projectUserParent, gaxgrpc::CallSettings callSettings = null) =>
            Single(new ProjectRef
            {
                ProjectUserParent = projectUserParent ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="projectUserParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleAsync(string projectUserParent, gaxgrpc::CallSettings callSettings = null) =>
            SingleAsync(new ProjectRef
            {
                ProjectUserParent = projectUserParent ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="projectUserParent">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleAsync(string projectUserParent, st::CancellationToken cancellationToken) =>
            SingleAsync(projectUserParent, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="projectUserParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Single(ProjectName projectUserParent, gaxgrpc::CallSettings callSettings = null) =>
            Single(new ProjectRef
            {
                ProjectUserParentAsProjectName = projectUserParent,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="projectUserParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleAsync(ProjectName projectUserParent, gaxgrpc::CallSettings callSettings = null) =>
            SingleAsync(new ProjectRef
            {
                ProjectUserParentAsProjectName = projectUserParent,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="projectUserParent">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleAsync(ProjectName projectUserParent, st::CancellationToken cancellationToken) =>
            SingleAsync(projectUserParent, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public virtual Response Multi(MultiRootRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();
        public virtual stt::Task<Response> MultiAsync(MultiRootRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="multiRootParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Multi(string multiRootParent, gaxgrpc::CallSettings callSettings = null) =>
            Multi(new MultiRootRef
            {
                MultiRootParent = multiRootParent ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="multiRootParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiAsync(string multiRootParent, gaxgrpc::CallSettings callSettings = null) =>
            MultiAsync(new MultiRootRef
            {
                MultiRootParent = multiRootParent ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="multiRootParent">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiAsync(string multiRootParent, st::CancellationToken cancellationToken) =>
            MultiAsync(multiRootParent, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="multiRootParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Multi(RootsName multiRootParent, gaxgrpc::CallSettings callSettings = null) =>
            Multi(new MultiRootRef
            {
                MultiRootParentAsRootsName = multiRootParent,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="multiRootParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiAsync(RootsName multiRootParent, gaxgrpc::CallSettings callSettings = null) =>
            MultiAsync(new MultiRootRef
            {
                MultiRootParentAsRootsName = multiRootParent,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="multiRootParent">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiAsync(RootsName multiRootParent, st::CancellationToken cancellationToken) =>
            MultiAsync(multiRootParent, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public virtual Response Wild(WildcardRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();
        public virtual stt::Task<Response> WildAsync(WildcardRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="wildcardParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Wild(string wildcardParent, gaxgrpc::CallSettings callSettings = null) =>
            Wild(new WildcardRef
            {
                WildcardParent = wildcardParent ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="wildcardParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildAsync(string wildcardParent, gaxgrpc::CallSettings callSettings = null) =>
            WildAsync(new WildcardRef
            {
                WildcardParent = wildcardParent ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="wildcardParent">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildAsync(string wildcardParent, st::CancellationToken cancellationToken) =>
            WildAsync(wildcardParent, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="wildcardParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response Wild(gax::IResourceName wildcardParent, gaxgrpc::CallSettings callSettings = null) =>
            Wild(new WildcardRef
            {
                WildcardParentAsResourceName = wildcardParent,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="wildcardParent">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildAsync(gax::IResourceName wildcardParent, gaxgrpc::CallSettings callSettings = null) =>
            WildAsync(new WildcardRef
            {
                WildcardParentAsResourceName = wildcardParent,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="wildcardParent">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildAsync(gax::IResourceName wildcardParent, st::CancellationToken cancellationToken) =>
            WildAsync(wildcardParent, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

    }
}
