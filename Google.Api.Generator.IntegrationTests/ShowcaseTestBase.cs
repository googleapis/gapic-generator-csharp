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

using Google.Api.Gax.Grpc;
using Google.Api.Gax.Grpc.Rest;
using Grpc.Core;
using System;
using System.Net.Http;
using System.Reflection;
using Xunit;

namespace Google.Api.Generator.IntegrationTests
{
    /// <summary>
    /// Base class for all Showcase tests.
    /// </summary>
    public abstract class ShowcaseTestBase<TClient, TBuilder>
        where TBuilder : ClientBuilderBase<TClient>, new()
    {
        static ShowcaseTestBase()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }

        private readonly GrpcAdapter _adapter;

        protected ShowcaseTestBase()
        {
            // Normally we'd pass the adapter in as a parameter... but this leads to a load of constructors
            // that are effectively pointless, when we can determine the adapter based on the name of the class.
            // (We could add an attribute instead, but just going by convention is simpler.)
            _adapter = GetType().Name switch
            {
                string name when name.EndsWith("RestTest") => RestGrpcAdapter.Default,
                string name when name.EndsWith("GrpcTest") => GrpcNetClientAdapter.Default,
                _ => throw new InvalidOperationException("Unable to determine gRPC adapter")
            };
        }

        /// <summary>
        /// Creates a suitable client, throwing an exception resulting in a "skipped" test
        /// result if the Showcase endpoint hasn't been specified.
        /// </summary>
        protected TClient CreateClient()
        {
            string endpoint = Environment.GetEnvironmentVariable("SHOWCASE_ENDPOINT");
            Skip.If(string.IsNullOrEmpty(endpoint));

            var builder = new TBuilder
            {
                GrpcAdapter = _adapter,
                Endpoint = endpoint,
                // Use TLS credentials for Showcase's HTTPS endpoint.
                ChannelCredentials = ChannelCredentials.SecureSsl
            };
            var client = builder.Build();
            AcceptAnyCertificate(builder.LastCreatedChannel);
            return client;
        }

        private static void AcceptAnyCertificate(ChannelBase channel)
        {
            if (channel is null)
            {
                return;
            }
            // No functionality is exposed to modify the internal HTTP handler to bypass certificate validation.
            // Using reflection allows us to avoid installing the Showcase certificate into the OS root store;
            // TLS encryption still occurs, we just skip verifying the certificate's Certificate Authority.
            var invoker = (channel.GetType().GetField("_httpClient", BindingFlags.Instance | BindingFlags.NonPublic)
                ?? channel.GetType().GetField("<HttpInvoker>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic))
                ?.GetValue(channel) as HttpMessageInvoker;

            var handler = invoker is null
                ? null
                : typeof(HttpMessageInvoker).GetField("_handler", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(invoker);

            // Unwrap any DelegatingHandler layers
            while (handler is DelegatingHandler delegating)
            {
                handler = delegating.InnerHandler;
            }

            if (handler is null)
            {
                throw new InvalidOperationException($"Failed to retrieve the internal HTTP handler via reflection for channel type: {channel.GetType().FullName}");
            }

            switch (handler)
            {
                case SocketsHttpHandler socketsHandler: // Used by GrpcChannel
                    socketsHandler.SslOptions.RemoteCertificateValidationCallback = (_, _, _, _) => true;
                    break;
                case HttpClientHandler httpClientHandler: // Used by RestChannel
                    httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported HTTP handler type: {handler.GetType().FullName}");
            }
        }
    }
}
