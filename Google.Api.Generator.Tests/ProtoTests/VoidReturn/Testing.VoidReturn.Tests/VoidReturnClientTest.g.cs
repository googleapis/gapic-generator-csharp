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
using wkt = Google.Protobuf.WellKnownTypes;
using grpccore = Grpc.Core;
using moq = Moq;
using st = System.Threading;
using stt = System.Threading.Tasks;
using xunit = Xunit;

// Public methods are not tests. These methods cannot be tested as various implementations are missing.
#pragma warning disable xUnit1013

namespace Testing.VoidReturn.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedVoidReturnClientTest
    {
        // TEST_START
        public void VoidMethodRequestObject()
        {
            moq::Mock<VoidReturn.VoidReturnClient> mockGrpcClient = new moq::Mock<VoidReturn.VoidReturnClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                ResourceName = ResourceName.FromItem("[ITEM_ID]"),
            };
            wkt::Empty expectedResponse = new wkt::Empty { };
            mockGrpcClient.Setup(x => x.VoidMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            VoidReturnClient client = new VoidReturnClientImpl(mockGrpcClient.Object, null);
            client.VoidMethod(request);
            mockGrpcClient.VerifyAll();
        }
        // TEST_END

        // TEST_START
        public async stt::Task VoidMethodRequestObjectAsync()
        {
            moq::Mock<VoidReturn.VoidReturnClient> mockGrpcClient = new moq::Mock<VoidReturn.VoidReturnClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                ResourceName = ResourceName.FromItem("[ITEM_ID]"),
            };
            wkt::Empty expectedResponse = new wkt::Empty { };
            mockGrpcClient.Setup(x => x.VoidMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<wkt::Empty>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            VoidReturnClient client = new VoidReturnClientImpl(mockGrpcClient.Object, null);
            await client.VoidMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            await client.VoidMethodAsync(request, st::CancellationToken.None);
            mockGrpcClient.VerifyAll();
        }
        // TEST_END

        // TEST_START
        public void VoidMethod()
        {
            moq::Mock<VoidReturn.VoidReturnClient> mockGrpcClient = new moq::Mock<VoidReturn.VoidReturnClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                ResourceName = ResourceName.FromItem("[ITEM_ID]"),
            };
            wkt::Empty expectedResponse = new wkt::Empty { };
            mockGrpcClient.Setup(x => x.VoidMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            VoidReturnClient client = new VoidReturnClientImpl(mockGrpcClient.Object, null);
            client.VoidMethod(request.Name);
            mockGrpcClient.VerifyAll();
        }
        // TEST_END

        // TEST_START
        public async stt::Task VoidMethodAsync()
        {
            moq::Mock<VoidReturn.VoidReturnClient> mockGrpcClient = new moq::Mock<VoidReturn.VoidReturnClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                ResourceName = ResourceName.FromItem("[ITEM_ID]"),
            };
            wkt::Empty expectedResponse = new wkt::Empty { };
            mockGrpcClient.Setup(x => x.VoidMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<wkt::Empty>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            VoidReturnClient client = new VoidReturnClientImpl(mockGrpcClient.Object, null);
            await client.VoidMethodAsync(request.Name, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            await client.VoidMethodAsync(request.Name, st::CancellationToken.None);
            mockGrpcClient.VerifyAll();
        }
        // TEST_END

        // TEST_START
        public void VoidMethod_ResourceNames()
        {
            moq::Mock<VoidReturn.VoidReturnClient> mockGrpcClient = new moq::Mock<VoidReturn.VoidReturnClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                ResourceName = ResourceName.FromItem("[ITEM_ID]"),
            };
            wkt::Empty expectedResponse = new wkt::Empty { };
            mockGrpcClient.Setup(x => x.VoidMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            VoidReturnClient client = new VoidReturnClientImpl(mockGrpcClient.Object, null);
            client.VoidMethod(request.ResourceName);
            mockGrpcClient.VerifyAll();
        }
        // TEST_END

        // TEST_START
        public async stt::Task VoidMethodAsync_ResourceNames()
        {
            moq::Mock<VoidReturn.VoidReturnClient> mockGrpcClient = new moq::Mock<VoidReturn.VoidReturnClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                ResourceName = ResourceName.FromItem("[ITEM_ID]"),
            };
            wkt::Empty expectedResponse = new wkt::Empty { };
            mockGrpcClient.Setup(x => x.VoidMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<wkt::Empty>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            VoidReturnClient client = new VoidReturnClientImpl(mockGrpcClient.Object, null);
            await client.VoidMethodAsync(request.ResourceName, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            await client.VoidMethodAsync(request.ResourceName, st::CancellationToken.None);
            mockGrpcClient.VerifyAll();
        }
        // TEST_END
    }
}
