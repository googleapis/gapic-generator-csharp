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
            var hasMlkem = clientSupportedGroupsEntry.Value.IndexOf("MLKEM", StringComparison.OrdinalIgnoreCase) >= 0;

            bool.TryParse(Environment.GetEnvironmentVariable("SHOWCASE_STRICT_PQC"), out var strictPqc);
            // Guard against CI environment regressions when strict mode is enabled; otherwise skip when the host lacks ML-KEM.
            Assert.True(!strictPqc || hasMlkem, $"SHOWCASE_STRICT_PQC is enabled, but host did not advertise ML-KEM. Advertised: {clientSupportedGroupsEntry.Value}");
            Skip.If(!hasMlkem, $"Skipping: We rely on the host OS for protocol support. Advertised: {clientSupportedGroupsEntry.Value}");

            var negotiatedGroupEntry = Assert.Single(allHeaders, e => e.Key.Equals("x-showcase-tls-group", StringComparison.OrdinalIgnoreCase));

            // 'MLKEM' substring confirms post-quantum encryption despite naming variations.
            // Note: If new post-quantum algorithms are standardized in the future, these assertions may require updating.
            // See https://en.wikipedia.org/wiki/Post-Quantum_Cryptography_Standardization
            Assert.Contains("MLKEM", negotiatedGroupEntry.Value, StringComparison.OrdinalIgnoreCase);
        }

        public class PqcRestTest : PqcTestBase { }

        public class PqcGrpcTest : PqcTestBase { }
    }
}
