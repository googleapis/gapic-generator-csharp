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
using scg = System.Collections.Generic;
using linq = System.Linq;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.ChildResource
{
    public abstract class ChildResourceClient
    {
        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SingleParentMethod(SingleParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleParentMethodAsync(SingleParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleParentMethodAsync(SingleParent request, st::CancellationToken cancellationToken) =>
            SingleParentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SingleParentMethod(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SingleParentMethod(new SingleParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SingleParentMethodAsync(new SingleParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            SingleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SingleParentMethod(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SingleParentMethod(new SingleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleParentMethodAsync(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SingleParentMethodAsync(new SingleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleParentMethodAsync(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            SingleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardParentMethod(WildcardParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardParentMethodAsync(WildcardParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardParentMethodAsync(WildcardParent request, st::CancellationToken cancellationToken) =>
            WildcardParentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardParentMethod(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardParentMethod(new WildcardParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardParentMethodAsync(new WildcardParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardParentMethod(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardParentMethod(new WildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardParentMethodAsync(new WildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(TripleParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(TripleParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(TripleParent request, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(ProjectName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(ProjectName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(ProjectName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(ProjectName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(OrgName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(OrgName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(OrgName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(OrgName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(OrgName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(DeptName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(DeptName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(DeptName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(DeptName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(DeptName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(gax::IResourceName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(gax::IResourceName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(gax::IResourceName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleParentMethod(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethod(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleParentMethodAsync(new TripleParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(TripleWildcardParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(TripleWildcardParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(TripleWildcardParent request, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(ProjectName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(ProjectName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(ProjectName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsProjectName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(ProjectName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(OrgName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(OrgName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(OrgName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(OrgName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsOrgName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(OrgName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(DeptName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(DeptName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(DeptName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(DeptName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsDeptName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(DeptName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(gax::IResourceName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(gax::IResourceName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(gax::IResourceName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response TripleWildcardParentMethod(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethod(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            TripleWildcardParentMethodAsync(new TripleWildcardParent
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> TripleWildcardParentMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            TripleWildcardParentMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(OverlapParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(OverlapParent request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(OverlapParent request, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(string @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent { Ref = @ref ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(string @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent { Ref = @ref ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(string @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(ProjectName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RefAsProjectName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(ProjectName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RefAsProjectName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(ProjectName @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(OrgName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent { RefAsOrgName = @ref, }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(OrgName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent { RefAsOrgName = @ref, }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(OrgName @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(DeptName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RefAsDeptName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(DeptName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RefAsDeptName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(DeptName @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(ProjectOverlapName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RefAsProjectOverlapName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(ProjectOverlapName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RefAsProjectOverlapName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(ProjectOverlapName @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(OrgOverlapName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RefAsOrgOverlapName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(OrgOverlapName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RefAsOrgOverlapName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(OrgOverlapName @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(AllOverlapName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RefAsAllOverlapName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(AllOverlapName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RefAsAllOverlapName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(AllOverlapName @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(gax::IResourceName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RefAsResourceName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(gax::IResourceName @ref, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RefAsResourceName = @ref,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(gax::IResourceName @ref, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(@ref, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<ProjectName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRefAsProjectNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<ProjectName> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<OrgName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRefAsOrgNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<OrgName> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<DeptName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRefAsDeptNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<DeptName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<DeptName> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<ProjectOverlapName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRefAsProjectOverlapNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectOverlapName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<ProjectOverlapName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRefAsProjectOverlapNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<ProjectOverlapName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<ProjectOverlapName> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<OrgOverlapName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRefAsOrgOverlapNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgOverlapName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<OrgOverlapName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRefAsOrgOverlapNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<OrgOverlapName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<OrgOverlapName> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<AllOverlapName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRefAsAllOverlapNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<AllOverlapName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<AllOverlapName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRefAsAllOverlapNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<AllOverlapName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<AllOverlapName> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OverlapParentMethod(scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethod(new OverlapParent
            {
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            OverlapParentMethodAsync(new OverlapParent
            {
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OverlapParentMethodAsync(scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            OverlapParentMethodAsync(repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
