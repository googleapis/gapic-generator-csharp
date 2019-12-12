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

namespace Testing.ResourceNames
{
    public abstract class ResourceNamesClient
    {
        public Response SingleMethod(SingleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> SingleMethodAsync(SingleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test single resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SingleMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethod(new SingleResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test single resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethodAsync(new SingleResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test single resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodAsync(string name, st::CancellationToken cancellationToken) =>
            SingleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test single resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SingleMethod(SingleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethod(new SingleResource
            {
                SingleResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test single resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodAsync(SingleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethodAsync(new SingleResource
            {
                SingleResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test single resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodAsync(SingleResourceName name, st::CancellationToken cancellationToken) =>
            SingleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response SingleMethodRef(SingleResourceRef request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> SingleMethodRefAsync(SingleResourceRef request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test single resource reference.
        /// </summary>
        /// <param name="singleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SingleMethodRef(string singleResource, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethodRef(new SingleResourceRef
            {
                SingleResource = singleResource ?? "",
            }, callSettings);

        /// <summary>
        /// Test single resource reference.
        /// </summary>
        /// <param name="singleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodRefAsync(string singleResource, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethodRefAsync(new SingleResourceRef
            {
                SingleResource = singleResource ?? "",
            }, callSettings);

        /// <summary>
        /// Test single resource reference.
        /// </summary>
        /// <param name="singleResource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodRefAsync(string singleResource, st::CancellationToken cancellationToken) =>
            SingleMethodRefAsync(singleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test single resource reference.
        /// </summary>
        /// <param name="singleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SingleMethodRef(SingleResourceName singleResource, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethodRef(new SingleResourceRef
            {
                SingleResourceAsSingleResourceName = singleResource,
            }, callSettings);

        /// <summary>
        /// Test single resource reference.
        /// </summary>
        /// <param name="singleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodRefAsync(SingleResourceName singleResource, gaxgrpc::CallSettings callSettings = null) =>
            SingleMethodRefAsync(new SingleResourceRef
            {
                SingleResourceAsSingleResourceName = singleResource,
            }, callSettings);

        /// <summary>
        /// Test single resource reference.
        /// </summary>
        /// <param name="singleResource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SingleMethodRefAsync(SingleResourceName singleResource, st::CancellationToken cancellationToken) =>
            SingleMethodRefAsync(singleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response MultiMethod(MultiResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> MultiMethodAsync(MultiResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MultiMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethod(new MultiResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodAsync(new MultiResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodAsync(string name, st::CancellationToken cancellationToken) =>
            MultiMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MultiMethod(MultiResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethod(new MultiResource
            {
                MultiResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodAsync(MultiResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodAsync(new MultiResource
            {
                MultiResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodAsync(MultiResourceName name, st::CancellationToken cancellationToken) =>
            MultiMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response MultiMethodRef(MultiResourceRef request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> MultiMethodRefAsync(MultiResourceRef request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MultiMethodRef(string multiResource, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodRef(new MultiResourceRef
            {
                MultiResource = multiResource ?? "",
            }, callSettings);

        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodRefAsync(string multiResource, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodRefAsync(new MultiResourceRef
            {
                MultiResource = multiResource ?? "",
            }, callSettings);

        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodRefAsync(string multiResource, st::CancellationToken cancellationToken) =>
            MultiMethodRefAsync(multiResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response MultiMethodRef(MultiResourceName multiResource, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodRef(new MultiResourceRef
            {
                MultiResourceAsMultiResourceName = multiResource,
            }, callSettings);

        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodRefAsync(MultiResourceName multiResource, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodRefAsync(new MultiResourceRef
            {
                MultiResourceAsMultiResourceName = multiResource,
            }, callSettings);

        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodRefAsync(MultiResourceName multiResource, st::CancellationToken cancellationToken) =>
            MultiMethodRefAsync(multiResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response OriginallySingleMethod(OriginallySingleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> OriginallySingleMethodAsync(OriginallySingleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OriginallySingleMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethod(new OriginallySingleResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodAsync(new OriginallySingleResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodAsync(string name, st::CancellationToken cancellationToken) =>
            OriginallySingleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OriginallySingleMethod(OriginallySingleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethod(new OriginallySingleResource
            {
                OriginallySingleResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodAsync(OriginallySingleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodAsync(new OriginallySingleResource
            {
                OriginallySingleResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodAsync(OriginallySingleResourceName name, st::CancellationToken cancellationToken) =>
            OriginallySingleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response FutureMultiMethod(FutureMultiResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> FutureMultiMethodAsync(FutureMultiResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test future multi resource (FUTURE_MULTI_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response FutureMultiMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            FutureMultiMethod(new FutureMultiResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test future multi resource (FUTURE_MULTI_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> FutureMultiMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            FutureMultiMethodAsync(new FutureMultiResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test future multi resource (FUTURE_MULTI_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> FutureMultiMethodAsync(string name, st::CancellationToken cancellationToken) =>
            FutureMultiMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test future multi resource (FUTURE_MULTI_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response FutureMultiMethod(FutureMultiResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            FutureMultiMethod(new FutureMultiResource
            {
                FutureMultiResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test future multi resource (FUTURE_MULTI_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> FutureMultiMethodAsync(FutureMultiResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            FutureMultiMethodAsync(new FutureMultiResource
            {
                FutureMultiResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test future multi resource (FUTURE_MULTI_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> FutureMultiMethodAsync(FutureMultiResourceName name, st::CancellationToken cancellationToken) =>
            FutureMultiMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response OriginallySingleMethodRef(OriginallySingleResourceRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();
        public stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceRef request, gaxgrpc::CallSettings callSettings = null) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN),
        /// with combinatorial method generation.
        /// </summary>
        /// <param name="resource1">
        /// Two resource fields, to test combinatorial generation.
        /// </param>
        /// <param name="resource2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OriginallySingleMethodRef(string resource1, string resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRef(new OriginallySingleResourceRef
            {
                Resource1 = resource1 ?? "",
                Resource2 = resource2 ?? "",
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN),
        /// with combinatorial method generation.
        /// </summary>
        /// <param name="resource1">
        /// Two resource fields, to test combinatorial generation.
        /// </param>
        /// <param name="resource2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(string resource1, string resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRefAsync(new OriginallySingleResourceRef
            {
                Resource1 = resource1 ?? "",
                Resource2 = resource2 ?? "",
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN),
        /// with combinatorial method generation.
        /// </summary>
        /// <param name="resource1">
        /// Two resource fields, to test combinatorial generation.
        /// </param>
        /// <param name="resource2">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(string resource1, string resource2, st::CancellationToken cancellationToken) =>
            OriginallySingleMethodRefAsync(resource1, resource2, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN),
        /// with combinatorial method generation.
        /// </summary>
        /// <param name="resource1">
        /// Two resource fields, to test combinatorial generation.
        /// </param>
        /// <param name="resource2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OriginallySingleMethodRef(OriginallySingleResourceName resource1, OriginallySingleResourceName resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRef(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceName = resource1,
                Resource2AsOriginallySingleResourceName = resource2,
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN),
        /// with combinatorial method generation.
        /// </summary>
        /// <param name="resource1">
        /// Two resource fields, to test combinatorial generation.
        /// </param>
        /// <param name="resource2">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceName resource1, OriginallySingleResourceName resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRefAsync(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceName = resource1,
                Resource2AsOriginallySingleResourceName = resource2,
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN),
        /// with combinatorial method generation.
        /// </summary>
        /// <param name="resource1">
        /// Two resource fields, to test combinatorial generation.
        /// </param>
        /// <param name="resource2">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceName resource1, OriginallySingleResourceName resource2, st::CancellationToken cancellationToken) =>
            OriginallySingleMethodRefAsync(resource1, resource2, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
