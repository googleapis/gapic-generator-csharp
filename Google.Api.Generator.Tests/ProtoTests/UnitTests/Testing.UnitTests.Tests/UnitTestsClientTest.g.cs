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

using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using lro = Google.LongRunning;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using moq = Moq;
using st = System.Threading;
using stt = System.Threading.Tasks;
using xunit = Xunit;

namespace Testing.UnitTests.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedUnitTestsClientTest
    {
        [xunit::FactAttribute]
        public void MethodValuesRequestObject()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
                SingleFloat = 9.844708E+17F,
                SingleInt32 = 1006714422,
                SingleInt64 = 7588944567505710014L,
                SingleUint32 = 1126406589U,
                SingleUint64 = 17485030504044489760UL,
                SingleSint32 = -1352705621,
                SingleSint64 = 2082867308710527737L,
                SingleFixed32 = 4173946396U,
                SingleFixed64 = 11184033605403130352UL,
                SingleSfixed32 = 1276562217,
                SingleSfixed64 = -6081914353897584723L,
                SingleBool = false,
                SingleString = "single_string96cd7d30",
                SingleBytes = proto::ByteString.CopyFromUtf8("single_bytes7f9384e7"),
                SingleMessage = new AnotherMessage(),
                SingleNestedMessage = new ValuesRequest.Types.NestedMessage(),
                SingleEnum = Enum.Default,
                SingleNestedEnum = ValuesRequest.Types.NestedEnum.Default,
                RepeatedDouble =
                {
                    -4.5208902549925389E+17,
                },
                RepeatedFloat = { -1.0048845E+18F, },
                RepeatedInt32 = { -2077149597, },
                RepeatedInt64 =
                {
                    7687316919822141708L,
                },
                RepeatedUint32 = { 603035763U, },
                RepeatedUint64 =
                {
                    17209126530695563676UL,
                },
                RepeatedSint32 = { 2039757871, },
                RepeatedSint64 =
                {
                    -620817012101130427L,
                },
                RepeatedFixed32 = { 2635338237U, },
                RepeatedFixed64 =
                {
                    3059281051678551290UL,
                },
                RepeatedSfixed32 = { -1293299539, },
                RepeatedSfixed64 =
                {
                    4598468037304457802L,
                },
                RepeatedBool = { true, },
                RepeatedString =
                {
                    "repeated_string60f8764e",
                },
                RepeatedBytes =
                {
                    proto::ByteString.CopyFromUtf8("repeated_bytes6e9b8178"),
                },
                RepeatedMessage =
                {
                    new AnotherMessage(),
                },
                RepeatedNestedMessage =
                {
                    new ValuesRequest.Types.NestedMessage(),
                },
                RepeatedEnum = { Enum.Default, },
                RepeatedNestedEnum =
                {
                    ValuesRequest.Types.NestedEnum.Default,
                },
                SingleResourceNameAsAResourceName = AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                RepeatedResourceNameAsAResourceNames =
                {
                    AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                },
                SingleWildcardResourceAsResourceName = new gax::UnknownResourceName("a/wildcard/resource"),
                RepeatedWildcardResourceAsResourceNames =
                {
                    new gax::UnknownResourceName("a/wildcard/resource"),
                },
                MultiPatternResourceNameAsMultiPatternResourceName = MultiPatternResourceName.FromRootAItem("[ROOT_A_ID]", "[ITEM_ID]"),
                RepeatedMultiPatternResourceNameAsMultiPatternResourceNames =
                {
                    MultiPatternResourceName.FromRootAItem("[ROOT_A_ID]", "[ITEM_ID]"),
                },
                MapIntString =
                {
                    {
                        -1978962372,
                        "value60c16320"
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValues(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response response = client.MethodValues(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MethodValuesRequestObjectAsync()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
                SingleFloat = 9.844708E+17F,
                SingleInt32 = 1006714422,
                SingleInt64 = 7588944567505710014L,
                SingleUint32 = 1126406589U,
                SingleUint64 = 17485030504044489760UL,
                SingleSint32 = -1352705621,
                SingleSint64 = 2082867308710527737L,
                SingleFixed32 = 4173946396U,
                SingleFixed64 = 11184033605403130352UL,
                SingleSfixed32 = 1276562217,
                SingleSfixed64 = -6081914353897584723L,
                SingleBool = false,
                SingleString = "single_string96cd7d30",
                SingleBytes = proto::ByteString.CopyFromUtf8("single_bytes7f9384e7"),
                SingleMessage = new AnotherMessage(),
                SingleNestedMessage = new ValuesRequest.Types.NestedMessage(),
                SingleEnum = Enum.Default,
                SingleNestedEnum = ValuesRequest.Types.NestedEnum.Default,
                RepeatedDouble =
                {
                    -4.5208902549925389E+17,
                },
                RepeatedFloat = { -1.0048845E+18F, },
                RepeatedInt32 = { -2077149597, },
                RepeatedInt64 =
                {
                    7687316919822141708L,
                },
                RepeatedUint32 = { 603035763U, },
                RepeatedUint64 =
                {
                    17209126530695563676UL,
                },
                RepeatedSint32 = { 2039757871, },
                RepeatedSint64 =
                {
                    -620817012101130427L,
                },
                RepeatedFixed32 = { 2635338237U, },
                RepeatedFixed64 =
                {
                    3059281051678551290UL,
                },
                RepeatedSfixed32 = { -1293299539, },
                RepeatedSfixed64 =
                {
                    4598468037304457802L,
                },
                RepeatedBool = { true, },
                RepeatedString =
                {
                    "repeated_string60f8764e",
                },
                RepeatedBytes =
                {
                    proto::ByteString.CopyFromUtf8("repeated_bytes6e9b8178"),
                },
                RepeatedMessage =
                {
                    new AnotherMessage(),
                },
                RepeatedNestedMessage =
                {
                    new ValuesRequest.Types.NestedMessage(),
                },
                RepeatedEnum = { Enum.Default, },
                RepeatedNestedEnum =
                {
                    ValuesRequest.Types.NestedEnum.Default,
                },
                SingleResourceNameAsAResourceName = AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                RepeatedResourceNameAsAResourceNames =
                {
                    AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                },
                SingleWildcardResourceAsResourceName = new gax::UnknownResourceName("a/wildcard/resource"),
                RepeatedWildcardResourceAsResourceNames =
                {
                    new gax::UnknownResourceName("a/wildcard/resource"),
                },
                MultiPatternResourceNameAsMultiPatternResourceName = MultiPatternResourceName.FromRootAItem("[ROOT_A_ID]", "[ITEM_ID]"),
                RepeatedMultiPatternResourceNameAsMultiPatternResourceNames =
                {
                    MultiPatternResourceName.FromRootAItem("[ROOT_A_ID]", "[ITEM_ID]"),
                },
                MapIntString =
                {
                    {
                        -1978962372,
                        "value60c16320"
                    },
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValuesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.MethodValuesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MethodValuesAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MethodValues1()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValues(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response response = client.MethodValues(request.SingleDouble);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MethodValues1Async()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValuesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.MethodValuesAsync(request.SingleDouble, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MethodValuesAsync(request.SingleDouble, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MethodValues2()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
                SingleFloat = 9.844708E+17F,
                SingleInt32 = 1006714422,
                SingleInt64 = 7588944567505710014L,
                RepeatedBool = { true, },
                RepeatedBytes =
                {
                    proto::ByteString.CopyFromUtf8("repeated_bytes6e9b8178"),
                },
                RepeatedResourceNameAsAResourceNames =
                {
                    AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValues(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response response = client.MethodValues(request.SingleDouble, request.SingleFloat, request.SingleInt32, request.SingleInt64, request.RepeatedBool, request.RepeatedBytes, request.RepeatedResourceName);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MethodValues2Async()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
                SingleFloat = 9.844708E+17F,
                SingleInt32 = 1006714422,
                SingleInt64 = 7588944567505710014L,
                RepeatedBool = { true, },
                RepeatedBytes =
                {
                    proto::ByteString.CopyFromUtf8("repeated_bytes6e9b8178"),
                },
                RepeatedResourceNameAsAResourceNames =
                {
                    AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValuesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.MethodValuesAsync(request.SingleDouble, request.SingleFloat, request.SingleInt32, request.SingleInt64, request.RepeatedBool, request.RepeatedBytes, request.RepeatedResourceName, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MethodValuesAsync(request.SingleDouble, request.SingleFloat, request.SingleInt32, request.SingleInt64, request.RepeatedBool, request.RepeatedBytes, request.RepeatedResourceName, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MethodValues2_ResourceNames()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
                SingleFloat = 9.844708E+17F,
                SingleInt32 = 1006714422,
                SingleInt64 = 7588944567505710014L,
                RepeatedBool = { true, },
                RepeatedBytes =
                {
                    proto::ByteString.CopyFromUtf8("repeated_bytes6e9b8178"),
                },
                RepeatedResourceNameAsAResourceNames =
                {
                    AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValues(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response response = client.MethodValues(request.SingleDouble, request.SingleFloat, request.SingleInt32, request.SingleInt64, request.RepeatedBool, request.RepeatedBytes, request.RepeatedResourceNameAsAResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MethodValues2Async_ResourceNames()
        {
            moq::Mock<UnitTests.UnitTestsClient> mockGrpcClient = new moq::Mock<UnitTests.UnitTestsClient>(moq::MockBehavior.Strict);
            mockGrpcClient.Setup(x => x.CreateOperationsClient()).Returns(new moq::Mock<lro::Operations.OperationsClient>().Object);
            ValuesRequest request = new ValuesRequest
            {
                SingleDouble = -1.076317236333089E+18,
                SingleFloat = 9.844708E+17F,
                SingleInt32 = 1006714422,
                SingleInt64 = 7588944567505710014L,
                RepeatedBool = { true, },
                RepeatedBytes =
                {
                    proto::ByteString.CopyFromUtf8("repeated_bytes6e9b8178"),
                },
                RepeatedResourceNameAsAResourceNames =
                {
                    AResourceName.FromItemPart("[ITEM_ID]", "[PART_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MethodValuesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            UnitTestsClient client = new UnitTestsClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.MethodValuesAsync(request.SingleDouble, request.SingleFloat, request.SingleInt32, request.SingleInt64, request.RepeatedBool, request.RepeatedBytes, request.RepeatedResourceNameAsAResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MethodValuesAsync(request.SingleDouble, request.SingleFloat, request.SingleInt32, request.SingleInt64, request.RepeatedBool, request.RepeatedBytes, request.RepeatedResourceNameAsAResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
