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
using grpccore = Grpc.Core;
using moq = Moq;
using st = System.Threading;
using stt = System.Threading.Tasks;
using xunit = Xunit;

namespace Testing.ResourceNames.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedResourceNamesClientTest
    {
        [xunit::FactAttribute]
        public void SinglePatternMethodRequestObject()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SinglePatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.SinglePatternMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SinglePatternMethodRequestObjectAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SinglePatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.SinglePatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SinglePatternMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SinglePatternMethod()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SinglePatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.SinglePatternMethod(request.RealName, request.Ref, request.RepeatedRef, request.ValueRef, request.RepeatedValueRef);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SinglePatternMethodAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SinglePatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.SinglePatternMethodAsync(request.RealName, request.Ref, request.RepeatedRef, request.ValueRef, request.RepeatedValueRef, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SinglePatternMethodAsync(request.RealName, request.Ref, request.RepeatedRef, request.ValueRef, request.RepeatedValueRef, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SinglePatternMethodResourceNames()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SinglePatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.SinglePatternMethod(request.RealNameAsSinglePatternName, request.RefAsSinglePatternName, request.RepeatedRefAsSinglePatternNames, request.ValueRefAsSinglePatternName, request.RepeatedValueRefAsSinglePatternNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SinglePatternMethodResourceNamesAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            SinglePattern request = new SinglePattern
            {
                RealNameAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
                ValueRefAsSinglePatternName = SinglePatternName.FromItem("[ITEM_ID]"),
                RepeatedValueRefAsSinglePatternNames =
                {
                    SinglePatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.SinglePatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.SinglePatternMethodAsync(request.RealNameAsSinglePatternName, request.RefAsSinglePatternName, request.RepeatedRefAsSinglePatternNames, request.ValueRefAsSinglePatternName, request.RepeatedValueRefAsSinglePatternNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.SinglePatternMethodAsync(request.RealNameAsSinglePatternName, request.RefAsSinglePatternName, request.RepeatedRefAsSinglePatternNames, request.ValueRefAsSinglePatternName, request.RepeatedValueRefAsSinglePatternNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardOnlyPatternMethodRequestObject()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardOnlyPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardOnlyPatternMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardOnlyPatternMethodRequestObjectAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardOnlyPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardOnlyPatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardOnlyPatternMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardOnlyPatternMethod()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardOnlyPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardOnlyPatternMethod(request.Name, request.Ref, request.RepeatedRef, request.RefSugar, request.RepeatedRefSugar);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardOnlyPatternMethodAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardOnlyPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardOnlyPatternMethodAsync(request.Name, request.Ref, request.RepeatedRef, request.RefSugar, request.RepeatedRefSugar, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardOnlyPatternMethodAsync(request.Name, request.Ref, request.RepeatedRef, request.RefSugar, request.RepeatedRefSugar, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardOnlyPatternMethodResourceNames()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardOnlyPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardOnlyPatternMethod(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsResourceNames, request.RefSugarAsResourceName, request.RepeatedRefSugarAsResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardOnlyPatternMethodResourceNamesAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardOnlyPattern request = new WildcardOnlyPattern
            {
                ResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RefAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
                RefSugarAsResourceName = new gax::UnparsedResourceName("a/wildcard/resource"),
                RepeatedRefSugarAsResourceNames =
                {
                    new gax::UnparsedResourceName("a/wildcard/resource"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardOnlyPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardOnlyPatternMethodAsync(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsResourceNames, request.RefSugarAsResourceName, request.RepeatedRefSugarAsResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardOnlyPatternMethodAsync(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsResourceNames, request.RefSugarAsResourceName, request.RepeatedRefSugarAsResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodRequestObject()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodRequestObjectAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethod()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.Name, request.Ref, request.RepeatedRef);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.Name, request.Ref, request.RepeatedRef, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.Name, request.Ref, request.RepeatedRef, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames1()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.WildcardMultiPatternName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsWildcardMultiPatternNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames1Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsWildcardMultiPatternNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsWildcardMultiPatternNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames2()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.WildcardMultiPatternName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames2Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames3()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.WildcardMultiPatternName, request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames3Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames4()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.WildcardMultiPatternName, request.RefAsResourceName, request.RepeatedRefAsResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames4Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsResourceName, request.RepeatedRefAsResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.WildcardMultiPatternName, request.RefAsResourceName, request.RepeatedRefAsResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames5()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.ResourceName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsWildcardMultiPatternNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames5Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsWildcardMultiPatternNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsWildcardMultiPatternNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames6()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.ResourceName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames6Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsWildcardMultiPatternName, request.RepeatedRefAsResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames7()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames7Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMethodResourceNames8()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMethod(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMethodResourceNames8Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPattern request = new WildcardMultiPattern
            {
                WildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RefAsWildcardMultiPatternName = WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    WildcardMultiPatternName.FromItem("[ITEM_ID]"),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMethodAsync(request.ResourceName, request.RefAsResourceName, request.RepeatedRefAsResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMultipleMethodRequestObject()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                WildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMultipleMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMultipleMethodRequestObjectAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                WildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMultipleMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMultipleMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMultipleMethod()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMultipleMethod(request.Ref, request.RepeatedRef);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMultipleMethodAsync()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMultipleMethodAsync(request.Ref, request.RepeatedRef, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMultipleMethodAsync(request.Ref, request.RepeatedRef, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMultipleMethodResourceNames1()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMultipleMethod(request.RefAsWildcardMultiPatternMultipleName, request.RepeatedRefAsWildcardMultiPatternMultipleNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMultipleMethodResourceNames1Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsWildcardMultiPatternMultipleName, request.RepeatedRefAsWildcardMultiPatternMultipleNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsWildcardMultiPatternMultipleName, request.RepeatedRefAsWildcardMultiPatternMultipleNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMultipleMethodResourceNames2()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMultipleMethod(request.RefAsWildcardMultiPatternMultipleName, request.RepeatedRefAsResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMultipleMethodResourceNames2Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsWildcardMultiPatternMultipleName, request.RepeatedRefAsResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsWildcardMultiPatternMultipleName, request.RepeatedRefAsResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMultipleMethodResourceNames3()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMultipleMethod(request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternMultipleNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMultipleMethodResourceNames3Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternMultipleNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsResourceName, request.RepeatedRefAsWildcardMultiPatternMultipleNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WildcardMultiPatternMultipleMethodResourceNames4()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response response = client.WildcardMultiPatternMultipleMethod(request.RefAsResourceName, request.RepeatedRefAsResourceNames);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WildcardMultiPatternMultipleMethodResourceNames4Async()
        {
            moq::Mock<ResourceNames.ResourceNamesClient> mockGrpcClient = new moq::Mock<ResourceNames.ResourceNamesClient>(moq::MockBehavior.Strict);
            WildcardMultiPatternMultiple request = new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = WildcardMultiPatternMultipleName.FromConstPattern(),
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    WildcardMultiPatternMultipleName.FromConstPattern(),
                },
            };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.WildcardMultiPatternMultipleMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourceNamesClient client = new ResourceNamesClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsResourceName, request.RepeatedRefAsResourceNames, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.WildcardMultiPatternMultipleMethodAsync(request.RefAsResourceName, request.RepeatedRefAsResourceNames, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
