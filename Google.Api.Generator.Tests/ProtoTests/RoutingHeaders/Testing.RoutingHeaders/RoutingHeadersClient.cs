using gaxgrpc = Google.Api.Gax.Grpc;
using proto = Google.Protobuf;
using sysnet = System.Net;
using sys = System;

namespace Testing.RoutingHeaders
{
    public sealed class RoutingHeadersSettings : gaxgrpc::ServiceSettingsBase
    {
        public static RoutingHeadersSettings GetDefault() => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings NoUrlMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings GetMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings PostMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings PutMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings PatchMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings DeleteMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings NestedMultiMethodSettings => throw new sys::NotImplementedException();
    }

    public abstract class RoutingHeadersClient
    {

    }

    public sealed partial class RoutingHeadersClientImpl : RoutingHeadersClient
    {
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callNoUrlMethod;
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callGetMethod;
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callPostMethod;
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callPutMethod;
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callPatchMethod;
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callDeleteMethod;
        private readonly gaxgrpc::ApiCall<NestedRequest, Response> _callNestedMultiMethod;


        // TEST_START
        public RoutingHeadersClientImpl(RoutingHeaders.RoutingHeadersClient grpcClient, RoutingHeadersSettings settings)
        {
            GrpcClient = grpcClient;
            RoutingHeadersSettings effectiveSettings = settings ?? RoutingHeadersSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callNoUrlMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.NoUrlMethodAsync, grpcClient.NoUrlMethod, effectiveSettings.NoUrlMethodSettings);
            Modify_ApiCall(ref _callNoUrlMethod);
            Modify_NoUrlMethodApiCall(ref _callNoUrlMethod);
            _callGetMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.GetMethodAsync, grpcClient.GetMethod, effectiveSettings.GetMethodSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"name={(sysnet::WebUtility.UrlEncode(request.Name))}"));
            Modify_ApiCall(ref _callGetMethod);
            Modify_GetMethodApiCall(ref _callGetMethod);
            _callPostMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.PostMethodAsync, grpcClient.PostMethod, effectiveSettings.PostMethodSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"name={(sysnet::WebUtility.UrlEncode(request.Name))}"));
            Modify_ApiCall(ref _callPostMethod);
            Modify_PostMethodApiCall(ref _callPostMethod);
            _callPutMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.PutMethodAsync, grpcClient.PutMethod, effectiveSettings.PutMethodSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"name={(sysnet::WebUtility.UrlEncode(request.Name))}"));
            Modify_ApiCall(ref _callPutMethod);
            Modify_PutMethodApiCall(ref _callPutMethod);
            _callPatchMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.PatchMethodAsync, grpcClient.PatchMethod, effectiveSettings.PatchMethodSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"name={(sysnet::WebUtility.UrlEncode(request.Name))}"));
            Modify_ApiCall(ref _callPatchMethod);
            Modify_PatchMethodApiCall(ref _callPatchMethod);
            _callDeleteMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.DeleteMethodAsync, grpcClient.DeleteMethod, effectiveSettings.DeleteMethodSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"name={(sysnet::WebUtility.UrlEncode(request.Name))}"));
            Modify_ApiCall(ref _callDeleteMethod);
            Modify_DeleteMethodApiCall(ref _callDeleteMethod);
            _callNestedMultiMethod = clientHelper.BuildApiCall<NestedRequest, Response>(grpcClient.NestedMultiMethodAsync, grpcClient.NestedMultiMethod, effectiveSettings.NestedMultiMethodSettings).WithCallSettingsOverlay(request => gaxgrpc::CallSettings.FromHeader("x-goog-request-params", $"nest1.nest2.name={(sysnet::WebUtility.UrlEncode(request.Nest1.Nest2.Name))}&name={(sysnet::WebUtility.UrlEncode(request.Name))}"));
            Modify_ApiCall(ref _callNestedMultiMethod);
            Modify_NestedMultiMethodApiCall(ref _callNestedMultiMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }
        // TEST_END

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;
        partial void Modify_NoUrlMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_GetMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_PostMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_PutMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_PatchMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_DeleteMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_NestedMultiMethodApiCall(ref gaxgrpc::ApiCall<NestedRequest, Response> call);
        partial void OnConstruction(RoutingHeaders.RoutingHeadersClient grpcClient, RoutingHeadersSettings settings, gaxgrpc::ClientHelper clientHelper);

        RoutingHeaders.RoutingHeadersClient GrpcClient { get; }
    }
}
