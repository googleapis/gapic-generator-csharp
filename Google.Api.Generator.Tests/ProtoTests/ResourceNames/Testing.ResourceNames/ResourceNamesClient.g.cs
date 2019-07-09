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
using linq = System.Linq;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.ResourceNames
{
    public abstract class ResourceNamesClient
    {
        public Response SimpleMethod(SimpleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> SimpleMethodAsync(SimpleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test simple resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test simple resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleResource { Name = name ?? "", }, callSettings);

        /// <summary>
        /// Test simple resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string name, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test simple resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(SimpleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleResource
            {
                SimpleResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test simple resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(SimpleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleResource
            {
                SimpleResourceName = name,
            }, callSettings);

        /// <summary>
        /// Test simple resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(SimpleResourceName name, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response SimpleMethodRef(SimpleResourceRef request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> SimpleMethodRefAsync(SimpleResourceRef request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test simple resource reference.
        /// </summary>
        /// <param name="simpleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethodRef(string simpleResource, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodRef(new SimpleResourceRef
            {
                SimpleResource = simpleResource ?? "",
            }, callSettings);

        /// <summary>
        /// Test simple resource reference.
        /// </summary>
        /// <param name="simpleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodRefAsync(string simpleResource, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodRefAsync(new SimpleResourceRef
            {
                SimpleResource = simpleResource ?? "",
            }, callSettings);

        /// <summary>
        /// Test simple resource reference.
        /// </summary>
        /// <param name="simpleResource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodRefAsync(string simpleResource, st::CancellationToken cancellationToken) =>
            SimpleMethodRefAsync(simpleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Test simple resource reference.
        /// </summary>
        /// <param name="simpleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethodRef(SimpleResourceName simpleResource, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodRef(new SimpleResourceRef
            {
                SimpleResourceAsSimpleResourceName = simpleResource,
            }, callSettings);

        /// <summary>
        /// Test simple resource reference.
        /// </summary>
        /// <param name="simpleResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodRefAsync(SimpleResourceName simpleResource, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodRefAsync(new SimpleResourceRef
            {
                SimpleResourceAsSimpleResourceName = simpleResource,
            }, callSettings);

        /// <summary>
        /// Test simple resource reference.
        /// </summary>
        /// <param name="simpleResource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodRefAsync(SimpleResourceName simpleResource, st::CancellationToken cancellationToken) =>
            SimpleMethodRefAsync(simpleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
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
        public virtual Response MultiMethod(MultiResourceNameOneOf name, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethod(new MultiResource
            {
                MultiResourceNameOneOf = name,
            }, callSettings);

        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodAsync(MultiResourceNameOneOf name, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodAsync(new MultiResource
            {
                MultiResourceNameOneOf = name,
            }, callSettings);

        /// <summary>
        /// Test multi resource definition.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodAsync(MultiResourceNameOneOf name, st::CancellationToken cancellationToken) =>
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
        public virtual Response MultiMethodRef(MultiResourceNameOneOf multiResource, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodRef(new MultiResourceRef
            {
                MultiResourceAsMultiResourceNameOneOf = multiResource,
            }, callSettings);

        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodRefAsync(MultiResourceNameOneOf multiResource, gaxgrpc::CallSettings callSettings = null) =>
            MultiMethodRefAsync(new MultiResourceRef
            {
                MultiResourceAsMultiResourceNameOneOf = multiResource,
            }, callSettings);

        /// <summary>
        /// Test multi resource reference.
        /// </summary>
        /// <param name="multiResource">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> MultiMethodRefAsync(MultiResourceNameOneOf multiResource, st::CancellationToken cancellationToken) =>
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

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response OriginallySingleMethod(OriginallySingleResourceNameOneOf name, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethod(new OriginallySingleResource
            {
                OriginallySingleResourceNameOneOf = name,
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodAsync(OriginallySingleResourceNameOneOf name, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodAsync(new OriginallySingleResource
            {
                OriginallySingleResourceNameOneOf = name,
            }, callSettings);

        /// <summary>
        /// Test original single resource (ORIGINALLY_SINGLE_PATTERN).
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> OriginallySingleMethodAsync(OriginallySingleResourceNameOneOf name, st::CancellationToken cancellationToken) =>
            OriginallySingleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
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
        public virtual Response OriginallySingleMethodRef(OriginallySingleResourceNameOneOf resource1, OriginallySingleResourceName resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRef(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceNameOneOf = resource1,
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
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceNameOneOf resource1, OriginallySingleResourceName resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRefAsync(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceNameOneOf = resource1,
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
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceNameOneOf resource1, OriginallySingleResourceName resource2, st::CancellationToken cancellationToken) =>
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
        public virtual Response OriginallySingleMethodRef(OriginallySingleResourceName resource1, OriginallySingleResourceNameOneOf resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRef(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceName = resource1,
                Resource2AsOriginallySingleResourceNameOneOf = resource2,
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
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceName resource1, OriginallySingleResourceNameOneOf resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRefAsync(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceName = resource1,
                Resource2AsOriginallySingleResourceNameOneOf = resource2,
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
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceName resource1, OriginallySingleResourceNameOneOf resource2, st::CancellationToken cancellationToken) =>
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
        public virtual Response OriginallySingleMethodRef(OriginallySingleResourceNameOneOf resource1, OriginallySingleResourceNameOneOf resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRef(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceNameOneOf = resource1,
                Resource2AsOriginallySingleResourceNameOneOf = resource2,
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
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceNameOneOf resource1, OriginallySingleResourceNameOneOf resource2, gaxgrpc::CallSettings callSettings = null) =>
            OriginallySingleMethodRefAsync(new OriginallySingleResourceRef
            {
                Resource1AsOriginallySingleResourceNameOneOf = resource1,
                Resource2AsOriginallySingleResourceNameOneOf = resource2,
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
        public virtual stt::Task<Response> OriginallySingleMethodRefAsync(OriginallySingleResourceNameOneOf resource1, OriginallySingleResourceNameOneOf resource2, st::CancellationToken cancellationToken) =>
            OriginallySingleMethodRefAsync(resource1, resource2, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
