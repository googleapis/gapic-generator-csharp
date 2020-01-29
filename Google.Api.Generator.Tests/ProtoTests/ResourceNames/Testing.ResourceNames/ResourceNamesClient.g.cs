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
using gax = Google.Api.Gax;
using linq = System.Linq;
using scg = System.Collections.Generic;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.ResourceNames
{
    public abstract class ResourceNamesClient
    {
        public Response SinglePatternMethod(SinglePattern request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> SinglePatternMethodAsync(SinglePattern request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SinglePatternMethod(string realName, string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethod(new SinglePattern
            {
                RealName = realName ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(string realName, string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethodAsync(new SinglePattern
            {
                RealName = realName ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(string realName, string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            SinglePatternMethodAsync(realName, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SinglePatternMethod(SinglePatternName realName, SinglePatternName @ref, scg::IEnumerable<SinglePatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethod(new SinglePattern
            {
                RealNameAsSinglePatternName = realName,
                RefAsSinglePatternName = @ref,
                RepeatedRefAsSinglePatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<SinglePatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(SinglePatternName realName, SinglePatternName @ref, scg::IEnumerable<SinglePatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethodAsync(new SinglePattern
            {
                RealNameAsSinglePatternName = realName,
                RefAsSinglePatternName = @ref,
                RepeatedRefAsSinglePatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<SinglePatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(SinglePatternName realName, SinglePatternName @ref, scg::IEnumerable<SinglePatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            SinglePatternMethodAsync(realName, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response WildcardOnlyPatternMethod(WildcardOnlyPattern request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();
        public stt::Task<Response> WildcardOnlyPatternMethodAsync(WildcardOnlyPattern request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardOnlyPatternMethod(string name, string @ref, scg::IEnumerable<string> repeatedRef, string refSugar, scg::IEnumerable<string> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethod(new WildcardOnlyPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
                RefSugar = refSugar ?? "",
                RepeatedRefSugar =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, string refSugar, scg::IEnumerable<string> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethodAsync(new WildcardOnlyPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
                RefSugar = refSugar ?? "",
                RepeatedRefSugar =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, string refSugar, scg::IEnumerable<string> repeatedRefSugar, st::CancellationToken cancellationToken) =>
            WildcardOnlyPatternMethodAsync(name, @ref, repeatedRef, refSugar, repeatedRefSugar, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardOnlyPatternMethod(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gax::IResourceName refSugar, scg::IEnumerable<gax::IResourceName> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethod(new WildcardOnlyPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
                RefSugarAsResourceName = refSugar,
                RepeatedRefSugarAsResourceNames =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gax::IResourceName refSugar, scg::IEnumerable<gax::IResourceName> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethodAsync(new WildcardOnlyPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
                RefSugarAsResourceName = refSugar,
                RepeatedRefSugarAsResourceNames =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gax::IResourceName refSugar, scg::IEnumerable<gax::IResourceName> repeatedRefSugar, st::CancellationToken cancellationToken) =>
            WildcardOnlyPatternMethodAsync(name, @ref, repeatedRef, refSugar, repeatedRefSugar, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response WildcardMultiPatternMethod(WildcardMultiPattern request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();
        public stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPattern request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(string name, string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultiple request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();
        public stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultiple request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
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
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
