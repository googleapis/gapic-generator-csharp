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

namespace Testing.Keywords.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedKeywordsClientTest
    {
        [xunit::FactAttribute]
        public void Method1RequestObject()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = -1514770765,
                Void = Enum.Foreach,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response response = client.Method1(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method1RequestObjectAsync()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = -1514770765,
                Void = Enum.Foreach,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.Method1Async(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method1Async(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Method1()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = -1514770765,
                Void = Enum.Foreach,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response response = client.Method1(request.Event, request.Switch, request.Void);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method1Async()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = -1514770765,
                Void = Enum.Foreach,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.Method1Async(request.Event, request.Switch, request.Void, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method1Async(request.Event, request.Switch, request.Void, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Method1_ResourceNames()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = -1514770765,
                Void = Enum.Foreach,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response response = client.Method1(request.EventAsResourceName, request.Switch, request.Void);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method1Async_ResourceNames()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Request request = new Request
            {
                EventAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Switch = -1514770765,
                Void = Enum.Foreach,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method1Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.Method1Async(request.EventAsResourceName, request.Switch, request.Void, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method1Async(request.EventAsResourceName, request.Switch, request.Void, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Method2RequestObject()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.For,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method2(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response response = client.Method2(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method2RequestObjectAsync()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.For,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method2Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.Method2Async(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method2Async(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Method2()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.For,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method2(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response response = client.Method2(request.While, request.Enum);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method2Async()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.For,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method2Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.Method2Async(request.While, request.Enum, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method2Async(request.While, request.Enum, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Method2_ResourceNames()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.For,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method2(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response response = client.Method2(request.WhileAsResourceName, request.Enum);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task Method2Async_ResourceNames()
        {
            moq::Mock<Keywords.KeywordsClient> mockGrpcClient = new moq::Mock<Keywords.KeywordsClient>(moq::MockBehavior.Strict);
            Resource request = new Resource
            {
                WhileAsResourceName = ResourceName.FromItem("[ITEM_ID]"),
                Enum = Enum.For,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.Method2Async(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            KeywordsClient client = new KeywordsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.Method2Async(request.WhileAsResourceName, request.Enum, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.Method2Async(request.WhileAsResourceName, request.Enum, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
