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
using grpccore = Grpc.Core;
using moq = Moq;
using st = System.Threading;
using stt = System.Threading.Tasks;
using xunit = Xunit;

namespace Testing.ResourceNameSeparator.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedResourceNameSeparatorClientTest
    {
        [xunit::FactAttribute]
        public void Method1RequestObject()
        {
            moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient> mockGrpcClient = new moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNameSeparatorClient client = new ResourceNameSeparatorClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.Method1(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method1RequestObjectAsync()
        {
            moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient> mockGrpcClient = new moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNameSeparatorClient client = new ResourceNameSeparatorClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.Method1Async(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method1Async(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Method1()
        {
            moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient> mockGrpcClient = new moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNameSeparatorClient client = new ResourceNameSeparatorClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.Method1(request.Name, request.Ref);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method1Async()
        {
            moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient> mockGrpcClient = new moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNameSeparatorClient client = new ResourceNameSeparatorClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.Method1Async(request.Name, request.Ref, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method1Async(request.Name, request.Ref, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Method1ResourceNames()
        {
            moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient> mockGrpcClient = new moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNameSeparatorClient client = new ResourceNameSeparatorClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.Method1(request.RequestName, request.RefAsRequestName);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method1ResourceNamesAsync()
        {
            moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient> mockGrpcClient = new moq::Mock<ResourceNameSeparator.ResourceNameSeparatorClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                RequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
                RefAsRequestName = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("[ITEM_A_ID]", "[ITEM_B_ID]", "[DETAILS_A_ID]", "[DETAILS_B_ID]", "[DETAILS_C_ID]", "[EXTRA_ID]"),
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNameSeparatorClient client = new ResourceNameSeparatorClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.Method1Async(request.RequestName, request.RefAsRequestName, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method1Async(request.RequestName, request.RefAsRequestName, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
