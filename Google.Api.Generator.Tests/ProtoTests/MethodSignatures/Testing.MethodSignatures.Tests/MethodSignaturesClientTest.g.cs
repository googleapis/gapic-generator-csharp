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
using grpccore = Grpc.Core;
using moq = Moq;
using st = System.Threading;
using stt = System.Threading.Tasks;
using xunit = Xunit;

namespace Testing.MethodSignatures.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedMethodSignaturesClientTest
    {
        [xunit::FactAttribute]
        public void SimpleMethodRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
                AString = "a_string5c3f0d7a",
                AMap =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.SimpleMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SimpleMethodRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
                AString = "a_string5c3f0d7a",
                AMap =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.SimpleMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SimpleMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SimpleMethod1()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.SimpleMethod();
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SimpleMethod1Async()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.SimpleMethodAsync(gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SimpleMethodAsync(st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SimpleMethod2()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.SimpleMethod(request.ANumber);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SimpleMethod2Async()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.SimpleMethodAsync(request.ANumber, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SimpleMethodAsync(request.ANumber, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SimpleMethod3()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                AString = "a_string5c3f0d7a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.SimpleMethod(request.AString);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SimpleMethod3Async()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                AString = "a_string5c3f0d7a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.SimpleMethodAsync(request.AString, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SimpleMethodAsync(request.AString, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SimpleMethod4()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
                AString = "a_string5c3f0d7a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.SimpleMethod(request.ANumber, request.AString);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SimpleMethod4Async()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
                AString = "a_string5c3f0d7a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.SimpleMethodAsync(request.ANumber, request.AString, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SimpleMethodAsync(request.ANumber, request.AString, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SimpleMethod5()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
                AString = "a_string5c3f0d7a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.SimpleMethod(request.AString, request.ANumber);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SimpleMethod5Async()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            SimpleRequest request = new SimpleRequest
            {
                ANumber = -208788734,
                AString = "a_string5c3f0d7a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SimpleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.SimpleMethodAsync(request.AString, request.ANumber, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SimpleMethodAsync(request.AString, request.ANumber, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void PrimitiveArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            PrimitiveRequest request = new PrimitiveRequest
            {
                Optional = -215712555,
                Required = -437426260,
                RepeatedOptional = { -103373237, },
                RepeatedRequired = { 101804334, },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.PrimitiveArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.PrimitiveArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PrimitiveArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            PrimitiveRequest request = new PrimitiveRequest
            {
                Optional = -215712555,
                Required = -437426260,
                RepeatedOptional = { -103373237, },
                RepeatedRequired = { 101804334, },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.PrimitiveArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.PrimitiveArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.PrimitiveArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void PrimitiveArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            PrimitiveRequest request = new PrimitiveRequest
            {
                Optional = -215712555,
                Required = -437426260,
                RepeatedOptional = { -103373237, },
                RepeatedRequired = { 101804334, },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.PrimitiveArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.PrimitiveArgs(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PrimitiveArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            PrimitiveRequest request = new PrimitiveRequest
            {
                Optional = -215712555,
                Required = -437426260,
                RepeatedOptional = { -103373237, },
                RepeatedRequired = { 101804334, },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.PrimitiveArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.PrimitiveArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.PrimitiveArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void StringArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            StringRequest request = new StringRequest
            {
                Optional = "optionalf3247cd5",
                Required = "requirede5ed67ac",
                RepeatedOptional =
                {
                    "repeated_optionalf9d6a64b",
                },
                RepeatedRequired =
                {
                    "repeated_required0611692e",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.StringArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.StringArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task StringArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            StringRequest request = new StringRequest
            {
                Optional = "optionalf3247cd5",
                Required = "requirede5ed67ac",
                RepeatedOptional =
                {
                    "repeated_optionalf9d6a64b",
                },
                RepeatedRequired =
                {
                    "repeated_required0611692e",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.StringArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.StringArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.StringArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void StringArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            StringRequest request = new StringRequest
            {
                Optional = "optionalf3247cd5",
                Required = "requirede5ed67ac",
                RepeatedOptional =
                {
                    "repeated_optionalf9d6a64b",
                },
                RepeatedRequired =
                {
                    "repeated_required0611692e",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.StringArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.StringArgs(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task StringArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            StringRequest request = new StringRequest
            {
                Optional = "optionalf3247cd5",
                Required = "requirede5ed67ac",
                RepeatedOptional =
                {
                    "repeated_optionalf9d6a64b",
                },
                RepeatedRequired =
                {
                    "repeated_required0611692e",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.StringArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.StringArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.StringArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void BytesArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            BytesRequest request = new BytesRequest
            {
                Optional = proto::ByteString.CopyFromUtf8("optionalf3247cd5"),
                Required = proto::ByteString.CopyFromUtf8("requirede5ed67ac"),
                RepeatedOptional =
                {
                    proto::ByteString.CopyFromUtf8("repeated_optionalf9d6a64b"),
                },
                RepeatedRequired =
                {
                    proto::ByteString.CopyFromUtf8("repeated_required0611692e"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.BytesArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.BytesArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task BytesArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            BytesRequest request = new BytesRequest
            {
                Optional = proto::ByteString.CopyFromUtf8("optionalf3247cd5"),
                Required = proto::ByteString.CopyFromUtf8("requirede5ed67ac"),
                RepeatedOptional =
                {
                    proto::ByteString.CopyFromUtf8("repeated_optionalf9d6a64b"),
                },
                RepeatedRequired =
                {
                    proto::ByteString.CopyFromUtf8("repeated_required0611692e"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.BytesArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.BytesArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.BytesArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void BytesArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            BytesRequest request = new BytesRequest
            {
                Optional = proto::ByteString.CopyFromUtf8("optionalf3247cd5"),
                Required = proto::ByteString.CopyFromUtf8("requirede5ed67ac"),
                RepeatedOptional =
                {
                    proto::ByteString.CopyFromUtf8("repeated_optionalf9d6a64b"),
                },
                RepeatedRequired =
                {
                    proto::ByteString.CopyFromUtf8("repeated_required0611692e"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.BytesArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.BytesArgs(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task BytesArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            BytesRequest request = new BytesRequest
            {
                Optional = proto::ByteString.CopyFromUtf8("optionalf3247cd5"),
                Required = proto::ByteString.CopyFromUtf8("requirede5ed67ac"),
                RepeatedOptional =
                {
                    proto::ByteString.CopyFromUtf8("repeated_optionalf9d6a64b"),
                },
                RepeatedRequired =
                {
                    proto::ByteString.CopyFromUtf8("repeated_required0611692e"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.BytesArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.BytesArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.BytesArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MessageArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MessageRequest request = new MessageRequest
            {
                Optional = new MessageRequest.Types.Msg(),
                Required = new MessageRequest.Types.Msg(),
                RepeatedOptional =
                {
                    new MessageRequest.Types.Msg(),
                },
                RepeatedRequired =
                {
                    new MessageRequest.Types.Msg(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MessageArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.MessageArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MessageArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MessageRequest request = new MessageRequest
            {
                Optional = new MessageRequest.Types.Msg(),
                Required = new MessageRequest.Types.Msg(),
                RepeatedOptional =
                {
                    new MessageRequest.Types.Msg(),
                },
                RepeatedRequired =
                {
                    new MessageRequest.Types.Msg(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MessageArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.MessageArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MessageArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MessageArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MessageRequest request = new MessageRequest
            {
                Optional = new MessageRequest.Types.Msg(),
                Required = new MessageRequest.Types.Msg(),
                RepeatedOptional =
                {
                    new MessageRequest.Types.Msg(),
                },
                RepeatedRequired =
                {
                    new MessageRequest.Types.Msg(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MessageArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.MessageArgs(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MessageArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MessageRequest request = new MessageRequest
            {
                Optional = new MessageRequest.Types.Msg(),
                Required = new MessageRequest.Types.Msg(),
                RepeatedOptional =
                {
                    new MessageRequest.Types.Msg(),
                },
                RepeatedRequired =
                {
                    new MessageRequest.Types.Msg(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MessageArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.MessageArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MessageArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MapArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MapRequest request = new MapRequest
            {
                Optional =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Required =
                {
                    {
                        -1978962372,
                        new MapRequest.Types.Msg()
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MapArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.MapArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MapArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MapRequest request = new MapRequest
            {
                Optional =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Required =
                {
                    {
                        -1978962372,
                        new MapRequest.Types.Msg()
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MapArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.MapArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MapArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MapArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MapRequest request = new MapRequest
            {
                Optional =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Required =
                {
                    {
                        -1978962372,
                        new MapRequest.Types.Msg()
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MapArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.MapArgs(request.Optional, request.Required);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MapArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            MapRequest request = new MapRequest
            {
                Optional =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Required =
                {
                    {
                        -1978962372,
                        new MapRequest.Types.Msg()
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MapArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.MapArgsAsync(request.Optional, request.Required, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MapArgsAsync(request.Optional, request.Required, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void EnumArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            EnumRequest request = new EnumRequest
            {
                Optional = EnumRequest.Types.Enum.Default,
                Required = EnumRequest.Types.Enum.Default,
                RepeatedOptional =
                {
                    EnumRequest.Types.Enum.Default,
                },
                RepeatedRequired =
                {
                    EnumRequest.Types.Enum.Default,
                },
                TopLevelOptional = TopLevelEnum.NotDefault,
                TopLevelRequired = TopLevelEnum.Default,
                RepeatedTopLevelOptional =
                {
                    TopLevelEnum.Default,
                },
                RepeatedTopLevelRequired =
                {
                    TopLevelEnum.NotDefault,
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.EnumArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.EnumArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task EnumArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            EnumRequest request = new EnumRequest
            {
                Optional = EnumRequest.Types.Enum.Default,
                Required = EnumRequest.Types.Enum.Default,
                RepeatedOptional =
                {
                    EnumRequest.Types.Enum.Default,
                },
                RepeatedRequired =
                {
                    EnumRequest.Types.Enum.Default,
                },
                TopLevelOptional = TopLevelEnum.NotDefault,
                TopLevelRequired = TopLevelEnum.Default,
                RepeatedTopLevelOptional =
                {
                    TopLevelEnum.Default,
                },
                RepeatedTopLevelRequired =
                {
                    TopLevelEnum.NotDefault,
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.EnumArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.EnumArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.EnumArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void EnumArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            EnumRequest request = new EnumRequest
            {
                Optional = EnumRequest.Types.Enum.Default,
                Required = EnumRequest.Types.Enum.Default,
                RepeatedOptional =
                {
                    EnumRequest.Types.Enum.Default,
                },
                RepeatedRequired =
                {
                    EnumRequest.Types.Enum.Default,
                },
                TopLevelOptional = TopLevelEnum.NotDefault,
                TopLevelRequired = TopLevelEnum.Default,
                RepeatedTopLevelOptional =
                {
                    TopLevelEnum.Default,
                },
                RepeatedTopLevelRequired =
                {
                    TopLevelEnum.NotDefault,
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.EnumArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.EnumArgs(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, request.TopLevelOptional, request.TopLevelRequired, request.RepeatedTopLevelOptional, request.RepeatedTopLevelRequired);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task EnumArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            EnumRequest request = new EnumRequest
            {
                Optional = EnumRequest.Types.Enum.Default,
                Required = EnumRequest.Types.Enum.Default,
                RepeatedOptional =
                {
                    EnumRequest.Types.Enum.Default,
                },
                RepeatedRequired =
                {
                    EnumRequest.Types.Enum.Default,
                },
                TopLevelOptional = TopLevelEnum.NotDefault,
                TopLevelRequired = TopLevelEnum.Default,
                RepeatedTopLevelOptional =
                {
                    TopLevelEnum.Default,
                },
                RepeatedTopLevelRequired =
                {
                    TopLevelEnum.NotDefault,
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.EnumArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.EnumArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, request.TopLevelOptional, request.TopLevelRequired, request.RepeatedTopLevelOptional, request.RepeatedTopLevelRequired, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.EnumArgsAsync(request.Optional, request.Required, request.RepeatedOptional, request.RepeatedRequired, request.TopLevelOptional, request.TopLevelRequired, request.RepeatedTopLevelOptional, request.RepeatedTopLevelRequired, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void NestedArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            NestedRequest request = new NestedRequest
            {
                Nest1 = new NestedRequest.Types.Nest1(),
                TopLevelString = "top_level_string96fd379a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.NestedArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.NestedArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task NestedArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            NestedRequest request = new NestedRequest
            {
                Nest1 = new NestedRequest.Types.Nest1(),
                TopLevelString = "top_level_string96fd379a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.NestedArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.NestedArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.NestedArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void NestedArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            NestedRequest request = new NestedRequest
            {
                Nest1 = new NestedRequest.Types.Nest1
                {
                    AString = "a_string5c3f0d7a",
                    Nest2 = new NestedRequest.Types.Nest1.Types.Nest2
                    {
                        ANumber = -208788734,
                        AnotherNumber = -1687928571,
                    },
                    NestOuter = new NestedOuter { ABool = false, },
                },
                TopLevelString = "top_level_string96fd379a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.NestedArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.NestedArgs(request.Nest1.AString, request.Nest1.Nest2.ANumber, request.Nest1.Nest2.AnotherNumber, request.Nest1.NestOuter.ABool, request.TopLevelString);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task NestedArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            NestedRequest request = new NestedRequest
            {
                Nest1 = new NestedRequest.Types.Nest1
                {
                    AString = "a_string5c3f0d7a",
                    Nest2 = new NestedRequest.Types.Nest1.Types.Nest2
                    {
                        ANumber = -208788734,
                        AnotherNumber = -1687928571,
                    },
                    NestOuter = new NestedOuter { ABool = false, },
                },
                TopLevelString = "top_level_string96fd379a",
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.NestedArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.NestedArgsAsync(request.Nest1.AString, request.Nest1.Nest2.ANumber, request.Nest1.Nest2.AnotherNumber, request.Nest1.NestOuter.ABool, request.TopLevelString, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.NestedArgsAsync(request.Nest1.AString, request.Nest1.Nest2.ANumber, request.Nest1.Nest2.AnotherNumber, request.Nest1.NestOuter.ABool, request.TopLevelString, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WktArgsRequestObject()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            WktRequest request = new WktRequest
            {
                OptionalInt32 = 342716643,
                RequiredInt32 = -796492414,
                RepeatedOptionalInt32 = { 416900572, },
                RepeatedRequiredInt32 = { 1487201384, },
                OptionalString = "optional_string4b5fd8be",
                RequiredString = "required_string9663e282",
                RepeatedOptionalString =
                {
                    "repeated_optional_stringb1c05735",
                },
                RepeatedRequiredString =
                {
                    "repeated_required_string5021f513",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WktArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.WktArgs(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WktArgsRequestObjectAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            WktRequest request = new WktRequest
            {
                OptionalInt32 = 342716643,
                RequiredInt32 = -796492414,
                RepeatedOptionalInt32 = { 416900572, },
                RepeatedRequiredInt32 = { 1487201384, },
                OptionalString = "optional_string4b5fd8be",
                RequiredString = "required_string9663e282",
                RepeatedOptionalString =
                {
                    "repeated_optional_stringb1c05735",
                },
                RepeatedRequiredString =
                {
                    "repeated_required_string5021f513",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WktArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.WktArgsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WktArgsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WktArgs()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            WktRequest request = new WktRequest
            {
                OptionalInt32 = 342716643,
                RequiredInt32 = -796492414,
                RepeatedOptionalInt32 = { 416900572, },
                RepeatedRequiredInt32 = { 1487201384, },
                OptionalString = "optional_string4b5fd8be",
                RequiredString = "required_string9663e282",
                RepeatedOptionalString =
                {
                    "repeated_optional_stringb1c05735",
                },
                RepeatedRequiredString =
                {
                    "repeated_required_string5021f513",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WktArgs(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response response = client.WktArgs(request.OptionalInt32, request.RequiredInt32, request.RepeatedOptionalInt32, request.RepeatedRequiredInt32, request.OptionalString, request.RequiredString, request.RepeatedOptionalString, request.RepeatedRequiredString);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WktArgsAsync()
        {
            moq::Mock<MethodSignatures.MethodSignaturesClient> mockGrpcClient = new moq::Mock<MethodSignatures.MethodSignaturesClient>(moq::MockBehavior.Strict);
            WktRequest request = new WktRequest
            {
                OptionalInt32 = 342716643,
                RequiredInt32 = -796492414,
                RepeatedOptionalInt32 = { 416900572, },
                RepeatedRequiredInt32 = { 1487201384, },
                OptionalString = "optional_string4b5fd8be",
                RequiredString = "required_string9663e282",
                RepeatedOptionalString =
                {
                    "repeated_optional_stringb1c05735",
                },
                RepeatedRequiredString =
                {
                    "repeated_required_string5021f513",
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WktArgsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MethodSignaturesClient client = new MethodSignaturesClientImpl(mockGrpcClient.Object, null, null);
            Response responseCallSettings = await client.WktArgsAsync(request.OptionalInt32, request.RequiredInt32, request.RepeatedOptionalInt32, request.RepeatedRequiredInt32, request.OptionalString, request.RequiredString, request.RepeatedOptionalString, request.RepeatedRequiredString, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WktArgsAsync(request.OptionalInt32, request.RequiredInt32, request.RepeatedOptionalInt32, request.RepeatedRequiredInt32, request.OptionalString, request.RequiredString, request.RepeatedOptionalString, request.RepeatedRequiredString, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
