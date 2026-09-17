// Copyright 2026 Google LLC
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

using Google.Showcase.V1Beta1;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Generator.IntegrationTests
{
    public abstract class PqcTestBase : ShowcaseTestBase<EchoClient, EchoClientBuilder>
    {
        [SkippableFact]
        public async Task TestPqcNegotiation()
        {
            var client = CreateClient();
            const string content = "pqc-test";

            using var call = client.GrpcClient.EchoAsync(new EchoRequest { Content = content });
            var response = await call.ResponseAsync;
            Assert.Equal(content, response.Content);

            var allHeaders = (await call.ResponseHeadersAsync).Concat(call.GetTrailers());

            var clientSupportedGroupsEntry = Assert.Single(allHeaders, e => e.Key.Equals("x-showcase-tls-client-supported-groups", StringComparison.OrdinalIgnoreCase));
            Skip.If(clientSupportedGroupsEntry.Value.IndexOf("MLKEM", StringComparison.OrdinalIgnoreCase) < 0,
                $"Skipping: We rely on the host OS for protocol support. Unable to verify that an allowed PQC protocol (ML-KEM) is used when present because the host does not advertise it. Advertised: {clientSupportedGroupsEntry.Value}");

            var negotiatedGroupEntry = Assert.Single(allHeaders, e => e.Key.Equals("x-showcase-tls-group", StringComparison.OrdinalIgnoreCase));

            // 'MLKEM' substring confirms post-quantum encryption despite naming variations.
            // Note: If new post-quantum algorithms are standardized in the future, these assertions may require updating.
            // See https://en.wikipedia.org/wiki/Post-Quantum_Cryptography_Standardization
            Assert.Contains("MLKEM", clientSupportedGroupsEntry.Value, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("MLKEM", negotiatedGroupEntry.Value, StringComparison.OrdinalIgnoreCase);
        }

        public class PqcRestTest : PqcTestBase { }

        public class PqcGrpcTest : PqcTestBase { }
    }
}
