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

namespace 
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedSvcTest
    {
        [xunit::FactAttribute]
        public void MRequestObject()
        {
            moq::Mock<Svc.SvcClient> mockGrpcClient = new moq::Mock<Svc.SvcClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.M(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            SvcClient client = new SvcClientImpl(mockGrpcClient.Object, null);
            Response response = client.M(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MRequestObjectAsync()
        {
            moq::Mock<Svc.SvcClient> mockGrpcClient = new moq::Mock<Svc.SvcClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.MAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            SvcClient client = new SvcClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.MAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.MAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
