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

#pragma warning disable CS8981
using gaxgrpc = Google.Api.Gax.Grpc;
using gciv = Google.Cloud.Iam.V1;
using gcl = Google.Cloud.Location;
using lro = Google.LongRunning;
using proto = Google.Protobuf;
using gpr = Google.Protobuf.Reflection;
using gsv = Google.Showcase.V1Beta1;
using sys = System;
using scg = System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>Static class to provide extension methods to configure API clients.</summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>Adds a singleton <see cref="gsv::ComplianceClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddComplianceClient(this IServiceCollection services, sys::Action<gsv::ComplianceClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gsv::ComplianceClientBuilder builder = new gsv::ComplianceClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });

        /// <summary>Adds a singleton <see cref="gsv::EchoClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddEchoClient(this IServiceCollection services, sys::Action<gsv::EchoClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gsv::EchoClientBuilder builder = new gsv::EchoClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });

        /// <summary>Adds a singleton <see cref="gsv::IdentityClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddIdentityClient(this IServiceCollection services, sys::Action<gsv::IdentityClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gsv::IdentityClientBuilder builder = new gsv::IdentityClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });

        /// <summary>Adds a singleton <see cref="gsv::MessagingClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddMessagingClient(this IServiceCollection services, sys::Action<gsv::MessagingClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gsv::MessagingClientBuilder builder = new gsv::MessagingClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });

        /// <summary>Adds a singleton <see cref="gsv::SequenceServiceClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddSequenceServiceClient(this IServiceCollection services, sys::Action<gsv::SequenceServiceClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gsv::SequenceServiceClientBuilder builder = new gsv::SequenceServiceClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });

        /// <summary>Adds a singleton <see cref="gsv::TestingClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddTestingClient(this IServiceCollection services, sys::Action<gsv::TestingClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gsv::TestingClientBuilder builder = new gsv::TestingClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });
    }
}
