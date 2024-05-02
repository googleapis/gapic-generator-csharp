// Copyright 2022 Google LLC
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

using Google.Rpc;
using Google.Showcase.V1Beta1;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Generator.IntegrationTests
{
    public abstract class EchoTestBase : ShowcaseTestBase<EchoClient, EchoClientBuilder>
    {
        [SkippableFact]
        public void SimpleEcho()
        {
            var client = CreateClient();
            string content = "hello world!";
            var response = client.Echo(new EchoRequest { Content = content });
            Assert.Equal(content, response.Content);
        }

        [SkippableFact]
        public void EchoError()
        {
            var client = CreateClient();
            var request = new EchoRequest { Error = new Rpc.Status { Code = (int) Code.Cancelled } };
            var exception = Assert.Throws<RpcException>(() => client.Echo(request));
            Assert.Equal(request.Error.Code, (int) exception.Status.StatusCode);
        }

        // Note: header testing is currently at least tricky. (It may be feasible for a gRPC interceptor.)
        // We'll defer that for now; perhaps in a future version of the server it could check the expected
        // header values.

        public class EchoRestTest : EchoTestBase { }

        public class EchoGrpcTest : EchoTestBase
        {
            // Note: currently only for gRPC as we don't support streaming methods in REST yet.
            [SkippableFact]
            public async Task Expand()
            {
                string content = "The rain in Spain stays mainly on the plain!";
                var client = CreateClient();
                var stream = client.Expand(new ExpandRequest { Content = content });
                var items = await stream.GetResponseStream().Select(resp => resp.Content).ToListAsync();
                Assert.Equal(content, string.Join(" ", items));
            }
        }
    }
}
