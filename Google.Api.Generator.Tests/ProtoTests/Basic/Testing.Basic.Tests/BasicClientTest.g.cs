using gaxgrpc = Google.Api.Gax.Grpc;
using grpccore = Grpc.Core;
using moq = Moq;
using st = System.Threading;
using stt = System.Threading.Tasks;
using xunit = Xunit;

namespace Testing.Basic
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedBasicTest
    {
        [xunit::FactAttribute]
        public void IdempotentMethodRequestObject()
        {
            moq::Mock<Basic.BasicClient> mockGrpcClient = new moq::Mock<Basic.BasicClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.IdempotentMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            BasicClient client = new BasicClientImpl(mockGrpcClient.Object, null);
            Response response = client.IdempotentMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task IdempotentMethodRequestObjectAsync()
        {
            moq::Mock<Basic.BasicClient> mockGrpcClient = new moq::Mock<Basic.BasicClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.IdempotentMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            BasicClient client = new BasicClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.IdempotentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.IdempotentMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void NonIdempotentMethodRequestObject()
        {
            moq::Mock<Basic.BasicClient> mockGrpcClient = new moq::Mock<Basic.BasicClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.NonIdempotentMethod(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            BasicClient client = new BasicClientImpl(mockGrpcClient.Object, null);
            Response response = client.NonIdempotentMethod(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task NonIdempotentMethodRequestObjectAsync()
        {
            moq::Mock<Basic.BasicClient> mockGrpcClient = new moq::Mock<Basic.BasicClient>(moq::MockBehavior.Strict);
            Request request = new Request { };
            Response expectedResponse = new Response { };
            mockGrpcClient.Setup(x => x.NonIdempotentMethodAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Response>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            BasicClient client = new BasicClientImpl(mockGrpcClient.Object, null);
            Response responseCallSettings = await client.NonIdempotentMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Response responseCancellationToken = await client.NonIdempotentMethodAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
