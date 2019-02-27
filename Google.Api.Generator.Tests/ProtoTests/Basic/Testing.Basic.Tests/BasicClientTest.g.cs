using grpccore = Grpc.Core;
using moq = Moq;
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
    }
}
