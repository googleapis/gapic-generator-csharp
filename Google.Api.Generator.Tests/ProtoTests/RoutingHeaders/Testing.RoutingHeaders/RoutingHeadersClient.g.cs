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
        public gaxgrpc::CallSettings GetNoTemplateMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings NestedMultiMethodSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings ServerStreamingMethodSettings => throw new sys::NotImplementedException();
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
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callGetNoTemplateMethod;
        private readonly gaxgrpc::ApiCall<NestedRequest, Response> _callNestedMultiMethod;
        private readonly gaxgrpc::ApiServerStreamingCall<SimpleRequest, Response> _callServerStreamingMethod;

        // TEST_START
        public RoutingHeadersClientImpl(RoutingHeaders.RoutingHeadersClient grpcClient, RoutingHeadersSettings settings)
        {
            GrpcClient = grpcClient;
            RoutingHeadersSettings effectiveSettings = settings ?? RoutingHeadersSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callNoUrlMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.NoUrlMethodAsync, grpcClient.NoUrlMethod, effectiveSettings.NoUrlMethodSettings);
            Modify_ApiCall(ref _callNoUrlMethod);
            Modify_NoUrlMethodApiCall(ref _callNoUrlMethod);
            _callGetMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.GetMethodAsync, grpcClient.GetMethod, effectiveSettings.GetMethodSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callGetMethod);
            Modify_GetMethodApiCall(ref _callGetMethod);
            _callPostMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.PostMethodAsync, grpcClient.PostMethod, effectiveSettings.PostMethodSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callPostMethod);
            Modify_PostMethodApiCall(ref _callPostMethod);
            _callPutMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.PutMethodAsync, grpcClient.PutMethod, effectiveSettings.PutMethodSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callPutMethod);
            Modify_PutMethodApiCall(ref _callPutMethod);
            _callPatchMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.PatchMethodAsync, grpcClient.PatchMethod, effectiveSettings.PatchMethodSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callPatchMethod);
            Modify_PatchMethodApiCall(ref _callPatchMethod);
            _callDeleteMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.DeleteMethodAsync, grpcClient.DeleteMethod, effectiveSettings.DeleteMethodSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callDeleteMethod);
            Modify_DeleteMethodApiCall(ref _callDeleteMethod);
            _callGetNoTemplateMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.GetNoTemplateMethodAsync, grpcClient.GetNoTemplateMethod, effectiveSettings.GetNoTemplateMethodSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callGetNoTemplateMethod);
            Modify_GetNoTemplateMethodApiCall(ref _callGetNoTemplateMethod);
            _callNestedMultiMethod = clientHelper.BuildApiCall<NestedRequest, Response>(grpcClient.NestedMultiMethodAsync, grpcClient.NestedMultiMethod, effectiveSettings.NestedMultiMethodSettings).WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<NestedRequest>().WithExtractedParameter("nest1.nest2.name", "^(.+)$", request => request.Nest1?.Nest2?.Name).WithExtractedParameter("name", "^(.+)$", request => request.Name));
            Modify_ApiCall(ref _callNestedMultiMethod);
            Modify_NestedMultiMethodApiCall(ref _callNestedMultiMethod);
            _callServerStreamingMethod = clientHelper.BuildApiCall<SimpleRequest, Response>(grpcClient.ServerStreamingMethod, effectiveSettings.ServerStreamingMethodSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callServerStreamingMethod);
            Modify_ServerStreamingMethodApiCall(ref _callServerStreamingMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }
        // TEST_END

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;
        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiServerStreamingCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>; 
        partial void Modify_NoUrlMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_GetMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_PostMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_PutMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_PatchMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_DeleteMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_GetNoTemplateMethodApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);
        partial void Modify_NestedMultiMethodApiCall(ref gaxgrpc::ApiCall<NestedRequest, Response> call);
        partial void Modify_ServerStreamingMethodApiCall(ref gaxgrpc::ApiServerStreamingCall<SimpleRequest, Response> call);
        partial void OnConstruction(RoutingHeaders.RoutingHeadersClient grpcClient, RoutingHeadersSettings settings, gaxgrpc::ClientHelper clientHelper);

        RoutingHeaders.RoutingHeadersClient GrpcClient { get; }
    }
}
