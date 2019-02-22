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
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A pageable sequence of <see cref="string"/> resources.</returns>
        public virtual gax::PagedEnumerable<Response, string> MethodPaginated(Request request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
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
