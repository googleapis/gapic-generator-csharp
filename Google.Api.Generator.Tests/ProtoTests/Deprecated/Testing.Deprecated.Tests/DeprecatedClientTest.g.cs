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

namespace Testing.Deprecated.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedDeprecatedClientTest
    {
        [xunit::FactAttribute]
        public void DeprecatedFieldMethodRequestObject()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            DeprecatedFieldRequest request = new DeprecatedFieldRequest
            {
#pragma warning disable CS0612
                DeprecatedField1 = "deprecated_field_1fddba2e1",
                DeprecatedField2 = "deprecated_field_2e15dd069",
#pragma warning restore CS0612
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedFieldMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
            Response response = client.DeprecatedFieldMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeprecatedFieldMethodRequestObjectAsync()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            DeprecatedFieldRequest request = new DeprecatedFieldRequest
            {
#pragma warning disable CS0612
                DeprecatedField1 = "deprecated_field_1fddba2e1",
                DeprecatedField2 = "deprecated_field_2e15dd069",
#pragma warning restore CS0612
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedFieldMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.DeprecatedFieldMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.DeprecatedFieldMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeprecatedFieldMethod()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            DeprecatedFieldRequest request = new DeprecatedFieldRequest
            {
#pragma warning disable CS0612
                DeprecatedField1 = "deprecated_field_1fddba2e1",
                DeprecatedField2 = "deprecated_field_2e15dd069",
#pragma warning restore CS0612
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedFieldMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
#pragma warning disable CS0612
            Response response = client.DeprecatedFieldMethod(request.DeprecatedField1, request.DeprecatedField2);
#pragma warning restore CS0612
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeprecatedFieldMethodAsync()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            DeprecatedFieldRequest request = new DeprecatedFieldRequest
            {
#pragma warning disable CS0612
                DeprecatedField1 = "deprecated_field_1fddba2e1",
                DeprecatedField2 = "deprecated_field_2e15dd069",
#pragma warning restore CS0612
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedFieldMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
#pragma warning disable CS0612
            Response responseCallSettings = await client.DeprecatedFieldMethodAsync(request.DeprecatedField1, request.DeprecatedField2, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
#pragma warning restore CS0612
            xunit::Assert.Same(expectedResponse, responseCallSettings);
#pragma warning disable CS0612
            Response responseCancellationToken = await client.DeprecatedFieldMethodAsync(request.DeprecatedField1, request.DeprecatedField2, st::CancellationToken.None);
#pragma warning restore CS0612
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeprecatedMessageMethodRequestObject()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
#pragma warning disable CS0612
            DeprecatedMessageRequest request = new DeprecatedMessageRequest { };
#pragma warning restore CS0612
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedMessageMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
            Response response = client.DeprecatedMessageMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeprecatedMessageMethodRequestObjectAsync()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
#pragma warning disable CS0612
            DeprecatedMessageRequest request = new DeprecatedMessageRequest { };
#pragma warning restore CS0612
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedMessageMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.DeprecatedMessageMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.DeprecatedMessageMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeprecatedMethodRequestObject()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
            Response response = client.DeprecatedMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeprecatedMethodRequestObjectAsync()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.DeprecatedMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.DeprecatedMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.DeprecatedMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeprecatedResponseMethodRequestObject()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
#pragma warning disable CS0612
            DeprecatedMessageResponse expectedResponse = new DeprecatedMessageResponse { };
#pragma warning restore CS0612
            mockGrpcClient.Setup(x => x.DeprecatedResponseMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
#pragma warning disable CS0612
            DeprecatedMessageResponse response = client.DeprecatedResponseMethod(request);
#pragma warning restore CS0612
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeprecatedResponseMethodRequestObjectAsync()
        {
            moq::Mock<Deprecated.DeprecatedClient> mockGrpcClient = new moq::Mock<Deprecated.DeprecatedClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
#pragma warning disable CS0612
            DeprecatedMessageResponse expectedResponse = new DeprecatedMessageResponse { };
            mockGrpcClient.Setup(x => x.DeprecatedResponseMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DeprecatedMessageResponse>(stt::Task.FromResult(expectedResponse), null, null, null, null));
#pragma warning restore CS0612
            DeprecatedClient client = new DeprecatedClientImpl(mockGrpcClient.Object, null);
#pragma warning disable CS0612
            DeprecatedMessageResponse responseCallSettings = await client.DeprecatedResponseMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
#pragma warning restore CS0612
            xunit::Assert.Same(expectedResponse, responseCallSettings);
#pragma warning disable CS0612
            DeprecatedMessageResponse responseCancellationToken = await client.DeprecatedResponseMethodAsync(request, st::CancellationToken.None);
#pragma warning restore CS0612
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
