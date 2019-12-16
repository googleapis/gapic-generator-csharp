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
using sc = System.Collections;
using scg = System.Collections.Generic;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.Paginated
{
    public abstract class PaginatedClient
    {
        public static PaginatedClient Create() => throw new sys::NotImplementedException();
        public static stt::Task<PaginatedClient> CreateAsync() => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="aString">
        /// </param>
        /// <param name="aNumber">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(string aString, int aNumber, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethod(new Request
            {
                AString = aString ?? "",
                ANumber = aNumber,
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="aString">
        /// </param>
        /// <param name="aNumber">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(string aString, int aNumber, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethodAsync(new Request
            {
                AString = aString ?? "",
                ANumber = aNumber,
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="aString">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(string aString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethod(new Request
            {
                AString = aString ?? "",
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="aString">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(string aString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethodAsync(new Request
            {
                AString = aString ?? "",
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethod(new Request
            {
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            SignatureMethodAsync(new Request
            {
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="ResourceName"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, ResourceName> ResourcedMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="ResourceName"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, ResourceName> ResourcedMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="ResourceName"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, ResourceName> ResourcedMethod(string name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest
            {
                Name = name ?? "",
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="ResourceName"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, ResourceName> ResourcedMethodAsync(string name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethodAsync(new ResourceRequest
            {
                Name = name ?? "",
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="ResourceName"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, ResourceName> ResourcedMethod(ResourceName name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethod(new ResourceRequest
            {
                ResourceName = name,
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="pageToken">
        /// The token returned from the previous request. A value of <c>null</c> or an empty string retrieves the first
        /// page.
        /// </param>
        /// <param name="pageSize">
        /// The size of page to request. The response will not be larger than this, but may be smaller. A value of
        /// <c>null</c> or <c>0</c> uses a server-defined page size.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="ResourceName"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, ResourceName> ResourcedMethodAsync(ResourceName name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null) =>
            ResourcedMethodAsync(new ResourceRequest
            {
                ResourceName = name,
                PageToken = pageToken ?? "",
                PageSize = pageSize ?? 0,
            }, callSettings);
        // TEST_END
    }

    public sealed partial class PaginatedClientImpl : PaginatedClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callSignatureMethod = null;
        private readonly gaxgrpc::ApiCall<ResourceRequest, ResourceResponse> _callResourcedMethod = null;

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings callSettings);
        partial void Modify_ResourceRequest(ref ResourceRequest request, ref gaxgrpc::CallSettings callSettings);

        // TEST_START
        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public override gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<Request, Response, Response.Types.NestedResult>(_callSignatureMethod, request, callSettings);
        }

        /// <summary>
        /// Test a paginated RPC with a method signature.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<Request, Response, Response.Types.NestedResult>(_callSignatureMethod, request, callSettings);
        }

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="ResourceName"/> resources.</returns>
        public override gax::PagedEnumerable<ResourceResponse, ResourceName> ResourcedMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResourceRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<ResourceRequest, ResourceResponse, ResourceName>(_callResourcedMethod, request, callSettings);
        }

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="ResourceName"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<ResourceResponse, ResourceName> ResourcedMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResourceRequest(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<ResourceRequest, ResourceResponse, ResourceName>(_callResourcedMethod, request, callSettings);
        }
        // TEST_END
    }

    // TEST_START
    public partial class Request : gaxgrpc::IPageRequest
    {
    }

    public partial class ResourceRequest : gaxgrpc::IPageRequest
    {
    }

    public partial class Response : gaxgrpc::IPageResponse<Response.Types.NestedResult>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<Types.NestedResult> GetEnumerator() => Results.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public partial class ResourceResponse : gaxgrpc::IPageResponse<ResourceName>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<ResourceName> GetEnumerator() => ResultsAsResourceNames.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }
    // TEST_END
}
