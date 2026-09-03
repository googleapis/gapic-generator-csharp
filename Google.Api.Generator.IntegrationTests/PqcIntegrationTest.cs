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

using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Generator.IntegrationTests
{
    /// <summary>
    /// Verifies Post-Quantum Cryptography (PQC) TLS negotiation (MLKEM) across gRPC and REST transports against the GAPIC Showcase server.
    /// Note: These tests will fail or skip unless the GAPIC Showcase server is actively running with TLS enabled.
    /// </summary>
    public class PqcIntegrationTest
    {
        private static readonly string s_showcaseEndpoint = Environment.GetEnvironmentVariable("SHOWCASE_ENDPOINT");

        /// <summary>
        /// Ensures raw gRPC metadata negotiated a post-quantum MLKEM curve.
        /// </summary>
        [SkippableFact(Skip = "b/524321047")]
        public async Task TestPqcGrpcNegotiation()
        {
            Skip.If(string.IsNullOrEmpty(s_showcaseEndpoint), "PQC negotiation test requires the SHOWCASE_ENDPOINT environment variable to be set.");
            Skip.If(!s_showcaseEndpoint.StartsWith("https://", StringComparison.OrdinalIgnoreCase), "PQC negotiation test requires an https/TLS Showcase endpoint.");

            // Bypass certificate validation since we only care about verifying the negotiated key exchange algorithm.
            // .NET 8 requires HttpClientHandler callbacks, while .NET Framework uses instance-level WinHttpHandler callbacks to avoid global state modification.
#if NETFRAMEWORK
            var handler = new System.Net.Http.WinHttpHandler
            {
                ServerCertificateValidationCallback = (sender, cert, chain, errors) => true
            };
#else
            var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
#endif
            using var channel = GrpcChannel.ForAddress(s_showcaseEndpoint, new GrpcChannelOptions { HttpHandler = handler });
            var method = new Method<byte[], byte[]>(MethodType.Unary, "google.showcase.v1beta1.Echo", "Echo", Marshallers.Create(b => b, b => b), Marshallers.Create(b => b, b => b));
            
            // The Showcase server intercepts the TLS connection and attaches 
            // the supported and negotiated cipher groups directly to the gRPC response trailing metadata.
            var invoker = channel.CreateCallInvoker();
            using var call = invoker.AsyncUnaryCall(method, null, new CallOptions(), Array.Empty<byte>());
            await call.ResponseAsync;
            var allHeaders = (await call.ResponseHeadersAsync).Concat(call.GetTrailers());

            // Retrieve the client's advertised cipher list (supported) and the server's chosen cipher (negotiated).
            // We expect exactly one entry for each header, throwing otherwise.
            var clientSupportedGroupsEntry = Assert.Single(allHeaders, e => e.Key.Equals("x-showcase-tls-client-supported-groups", StringComparison.OrdinalIgnoreCase));
            var negotiatedGroupEntry = Assert.Single(allHeaders, e => e.Key.Equals("x-showcase-tls-group", StringComparison.OrdinalIgnoreCase));
            
            // 'MLKEM' substring confirms post-quantum encryption despite naming variations.
            // Note: If new post-quantum algorithms are standardized in the future, these assertions may require updating.
            // See https://en.wikipedia.org/wiki/Post-Quantum_Cryptography_Standardization
            Assert.Contains("MLKEM", clientSupportedGroupsEntry.Value, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("MLKEM", negotiatedGroupEntry.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Ensures native HTTP headers negotiated a post-quantum MLKEM curve.
        /// </summary>
        [SkippableFact(Skip = "b/524321418")]
        public async Task TestPqcRestNegotiation()
        {
            Skip.If(string.IsNullOrEmpty(s_showcaseEndpoint), "PQC negotiation test requires the SHOWCASE_ENDPOINT environment variable to be set.");
            Skip.If(!s_showcaseEndpoint.StartsWith("https://", StringComparison.OrdinalIgnoreCase), "PQC negotiation test requires an https/TLS Showcase endpoint.");

            // Bypass certificate validation since we only care about verifying the negotiated key exchange algorithm.
            // .NET 8 requires HttpClientHandler callbacks, while .NET Framework uses instance-level WinHttpHandler callbacks to avoid global state modification.
#if NETFRAMEWORK
            var handler = new System.Net.Http.WinHttpHandler
            {
                ServerCertificateValidationCallback = (sender, cert, chain, errors) => true
            };
#else
            var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
#endif
            using var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Post, $"{s_showcaseEndpoint}/v1beta1/echo:echo") { Content = new StringContent("{}") };
            
            // The Showcase server intercepts the TLS connection and attaches 
            // the supported and negotiated cipher groups directly to the HTTP response headers.
            var response = await client.SendAsync(request);
            
            // Retrieve the client's advertised cipher list (supported) and the server's chosen cipher (negotiated).
            // We expect exactly one entry for each header, throwing otherwise.
            var clientSupportedGroupsEntry = Assert.Single(response.Headers, h => h.Key.Equals("x-showcase-tls-client-supported-groups", StringComparison.OrdinalIgnoreCase));
            var negotiatedGroupEntry = Assert.Single(response.Headers, h => h.Key.Equals("x-showcase-tls-group", StringComparison.OrdinalIgnoreCase));

            var clientSupportedGroupsSingle = Assert.Single(clientSupportedGroupsEntry.Value);
            var negotiatedGroupsSingle = Assert.Single(negotiatedGroupEntry.Value);

            // 'MLKEM' substring confirms post-quantum encryption despite naming variations.
            // Note: If new post-quantum algorithms are standardized in the future, these assertions may require updating.
            // See https://en.wikipedia.org/wiki/Post-Quantum_Cryptography_Standardization
            Assert.Contains("MLKEM", clientSupportedGroupsSingle, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("MLKEM", negotiatedGroupsSingle, StringComparison.OrdinalIgnoreCase);
        }
    }
}
