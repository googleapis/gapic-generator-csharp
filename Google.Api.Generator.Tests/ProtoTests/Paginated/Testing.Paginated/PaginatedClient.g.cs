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

#pragma warning disable CS8981
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
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(string aString, int aNumber, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            Request request = new Request
            {
                AString = aString ?? "",
                ANumber = aNumber,
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return SignatureMethod(request, callSettings);
        }

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
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(string aString, int aNumber, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            Request request = new Request
            {
                AString = aString ?? "",
                ANumber = aNumber,
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return SignatureMethodAsync(request, callSettings);
        }

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
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(string aString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            Request request = new Request
            {
                AString = aString ?? "",
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return SignatureMethod(request, callSettings);
        }

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
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(string aString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            Request request = new Request
            {
                AString = aString ?? "",
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return SignatureMethodAsync(request, callSettings);
        }

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
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod(string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            Request request = new Request { };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return SignatureMethod(request, callSettings);
        }

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
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethodAsync(string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            Request request = new Request { };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return SignatureMethodAsync(request, callSettings);
        }

        /// <summary>
        /// Test rpc with duplicate response message, to make sure partial LRO response class is only generated once.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedEnumerable<Response, Response.Types.NestedResult> SignatureMethod2(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test rpc with duplicate response message, to make sure partial LRO response class is only generated once.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="Response.Types.NestedResult"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<Response, Response.Types.NestedResult> SignatureMethod2Async(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, string> ResourcedMethod(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, string> ResourcedMethodAsync(ResourceRequest request, gaxgrpc::CallSettings callSettings = null) =>
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
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, string> ResourcedMethod(string name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest { Name = name ?? "", };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethod(request, callSettings);
        }

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
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, string> ResourcedMethodAsync(string name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest { Name = name ?? "", };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethodAsync(request, callSettings);
        }

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
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, string> ResourcedMethod(ResourceName name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest { ResourceName = name, };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethod(request, callSettings);
        }

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
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, string> ResourcedMethodAsync(ResourceName name, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest { ResourceName = name, };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethodAsync(request, callSettings);
        }

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="extraString">
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
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, string> ResourcedMethod(string name, string extraString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest
            {
                Name = name ?? "",
                ExtraString = extraString ?? "",
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethod(request, callSettings);
        }

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="extraString">
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
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, string> ResourcedMethodAsync(string name, string extraString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest
            {
                Name = name ?? "",
                ExtraString = extraString ?? "",
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethodAsync(request, callSettings);
        }

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="extraString">
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
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<ResourceResponse, string> ResourcedMethod(ResourceName name, string extraString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest
            {
                ResourceName = name,
                ExtraString = extraString ?? "",
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethod(request, callSettings);
        }

        /// <summary>
        /// Test a paginated RPC with a method signature that contains resource-names
        /// in both the request and the response.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="extraString">
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
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<ResourceResponse, string> ResourcedMethodAsync(ResourceName name, string extraString, string pageToken = null, int? pageSize = null, gaxgrpc::CallSettings callSettings = null)
        {
            ResourceRequest request = new ResourceRequest
            {
                ResourceName = name,
                ExtraString = extraString ?? "",
            };
            if (pageToken != null)
            {
                request.PageToken = pageToken;
            }
            if (pageSize != null)
            {
                request.PageSize = pageSize.Value;
            }
            return ResourcedMethodAsync(request, callSettings);
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

    public partial class ResourceResponse : gaxgrpc::IPageResponse<string>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<string> GetEnumerator() => Results.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }
    // TEST_END
}
