﻿// Copyright 2019 Google LLC
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
using sys = System;
using sc = System.Collections;
using scg = System.Collections.Generic;

namespace Testing.BasicPaginated
{
    public abstract partial class BasicPaginatedClient
    {
        // TEST_START
        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<Response, string> MethodPaginated(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedAsyncEnumerable<Response, string> MethodPaginatedAsync(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();
        // TEST_END
    }

    public sealed partial class BasicPaginatedClientImpl : BasicPaginatedClient
    {
        private readonly gaxgrpc::ApiCall<Request, Response> _callMethodPaginated = null;

        partial void Modify_Request(ref Request request, ref gaxgrpc::CallSettings callSettings);

        // TEST_START
        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public override gax::PagedEnumerable<Response, string> MethodPaginated(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedEnumerable<Request, Response, string>(_callMethodPaginated, request, callSettings);
        }

        /// <summary>
        /// Test method
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable asynchronous sequence of <see cref="string"/> resources.</returns>
        public override gax::PagedAsyncEnumerable<Response, string> MethodPaginatedAsync(Request request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_Request(ref request, ref callSettings);
            return new gaxgrpc::GrpcPagedAsyncEnumerable<Request, Response, string>(_callMethodPaginated, request, callSettings);
        }
        // TEST_END
    }

    // TEST_START
    public partial class Request : gaxgrpc::IPageRequest
    {
    }

    public partial class Response : gaxgrpc::IPageResponse<string>
    {
        /// <summary>Returns an enumerator that iterates through the resources in this response.</summary>
        public scg::IEnumerator<string> GetEnumerator() => Results.GetEnumerator();

        sc::IEnumerator sc::IEnumerable.GetEnumerator() => GetEnumerator();
    }
    // TEST_END
}
