// Copyright 2018 Google Inc. All Rights Reserved.
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

using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Cloud;
using Google.Cloud.Location;
using Google.Cloud.Iam.V1;
using Google.Protobuf.Reflection;
using Grpc.ServiceConfig;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using Google.Api.Gax;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Details of a proto-defined service.
    /// </summary>
    internal class ServiceDetails
    {
        private static readonly Regex ApiVersionPattern = new Regex("^[vV][0-9]+.*");

        private static readonly Dictionary<string, MixinDetails> AvailableMixins = new[]
        {
            new MixinDetails(IAMPolicy.Descriptor.FullName, typeof(IAMPolicyClient), typeof(IAMPolicyClientImpl), typeof(IAMPolicy.IAMPolicyClient), typeof(IAMPolicySettings)),
            new MixinDetails(Locations.Descriptor.FullName, typeof(LocationsClient), typeof(LocationsClientImpl), typeof(Locations.LocationsClient), typeof(LocationsSettings)),
        }.ToDictionary(details => details.GrpcServiceName);

        public ServiceDetails(ProtoCatalog catalog, string ns, ServiceDescriptor desc, ServiceConfig grpcServiceConfig, Service serviceConfig, ApiTransports transports)
        {
            Catalog = catalog;
            Namespace = ns;
            ProtoPackage = desc.File.Package;
            PackageVersion = ProtoPackage.Split('.').FirstOrDefault(part => ApiVersionPattern.IsMatch(part));
            DocLines = desc.Declaration.DocLines().ToList();
            SnippetsNamespace = $"{ns}.Snippets";
            UnitTestsNamespace = $"{ns}.Tests";
            // Must come early; used by `MethodDetails.Create()`
            MethodGrpcConfigsByName = grpcServiceConfig?.MethodConfig
                .SelectMany(conf => conf.Name.Select(name => (name, conf)))
                .Where(x => x.name.Service == desc.FullName)
                .ToImmutableDictionary(x => $"{x.name.Service}/{x.name.Method}", x => x.conf) ??
                ImmutableDictionary<string, MethodConfig>.Empty;
            ServiceFullName = desc.FullName;
            ServiceName = desc.Name;
            DocumentationName = desc.Name; // TODO: There may be a more suitable name than this.
            ProtoTyp = Typ.Manual(ns, desc.Name);
            GrpcClientTyp = Typ.Nested(ProtoTyp, $"{desc.Name}Client");
            SettingsTyp = Typ.Manual(ns, $"{desc.Name}Settings");
            BuilderTyp = Typ.Manual(ns, $"{desc.Name}ClientBuilder");
            ClientAbstractTyp = Typ.Manual(ns, $"{desc.Name}Client");
            ClientImplTyp = Typ.Manual(ns, $"{desc.Name}ClientImpl");
            DefaultHost = desc.GetExtension(ClientExtensions.DefaultHost) ?? "";
            // We need to account for regional default endpoints like "us-east1-pubsub.googleapis.com"
            DefaultHostServiceName = DefaultHost
                .Split('.', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()
                ?.Split('-', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            DefaultPort = 443; // Hardcoded; this is not specifiable by proto annotation.
            var oauthScopes = desc.GetExtension(ClientExtensions.OauthScopes);
            DefaultScopes = string.IsNullOrEmpty(oauthScopes) ? Enumerable.Empty<string>() : oauthScopes.Split(',', ' ');
            Methods = desc.Methods.Select(x => MethodDetails.Create(this, x)).ToList();
            ServiceSnippetsTyp = Typ.Manual(SnippetsNamespace, $"AllGenerated{desc.Name}ClientSnippets");
            SnippetsTyp = Typ.Manual(SnippetsNamespace, $"Generated{desc.Name}ClientSnippets");
            SnippetsClientName = $"{desc.Name.ToLowerCamelCase()}Client";
            UnitTestsTyp = Typ.Manual(UnitTestsNamespace, $"Generated{desc.Name}ClientTest");
            NonStandardLro = NonStandardLroDetails.ForService(desc);
            Mixins = serviceConfig?.Apis
                .Select(api => AvailableMixins.GetValueOrDefault(api.Name))
                .Where(mixin => mixin is object)
                // Don't use mixins within the package that contains that mixin.
                .Where(mixin => mixin.GapicClientType.Namespace != ns)
                .ToList() ?? Enumerable.Empty<MixinDetails>();
            Transports = transports;
        }

        /// <summary>The lines of service documentation from the proto.</summary>
        public IEnumerable<string> DocLines { get; }

        public ProtoCatalog Catalog { get; }
        public string Namespace { get; }
        public string SnippetsNamespace { get; }
        public string UnitTestsNamespace { get; }

        /// <summary>The service full name (package name plus service name).</summary>
        public string ServiceFullName { get; }

        /// <summary>The service name</summary>
        public string ServiceName { get; }

        /// <summary>
        /// The version part of the proto package where this service is declared.
        /// May be null.
        /// </summary>
        public string PackageVersion { get; }

        /// <summary>The name of this service to be used in documentation.</summary>
        public string DocumentationName { get; }

        /// <summary>The outer typ of the protoc-generated C# code.</summary>
        public Typ ProtoTyp { get; }

        /// <summary>The typ of the grpc-protoc-generated C# gRPC client code.</summary>
        public Typ GrpcClientTyp { get; }

        /// <summary>The typ of the GAPIC settings class for this service.</summary>
        public Typ SettingsTyp { get; }

        /// <summary>The typ of the builder class for this service.</summary>
        public Typ BuilderTyp { get; }

        /// <summary>The typ of the GAPIC abstract client for this service.</summary>
        public Typ ClientAbstractTyp { get; }

        /// <summary>The typ of the GAPIC client implementation for this service.</summary>
        public Typ ClientImplTyp { get; }

        /// <summary>The default hostname for this service.</summary>
        public string DefaultHost { get; }

        /// <summary>
        /// The service name included on the default host.
        /// For instance, this will be pubsub in both
        /// "us-east1-pubsub.googleapis.com:443" and "pubsub.googleapis.com:443".
        /// May be null if there's no default host specified.
        /// </summary>
        public string DefaultHostServiceName { get; }

        /// <summary>The default port for this service.</summary>
        public int DefaultPort { get; }

        /// <summary>The default scopes for this services.</summary>
        public IEnumerable<string> DefaultScopes { get; }

        /// <summary>All RPC methods within this service.</summary>
        public IEnumerable<MethodDetails> Methods { get; }

        /// <summary>The typ of the snippets class for this service.</summary>
        public Typ ServiceSnippetsTyp { get; }

        /// <summary>
        /// The typ of the partial snippets class for this service,
        /// as each snippet is defined on its own file.
        /// </summary>
        public Typ SnippetsTyp { get; }

        /// <summary>The name of the variable to hold the client instance.</summary>
        public string SnippetsClientName { get; }

        /// <summary>The typ of the unit test class for this service.</summary>
        public Typ UnitTestsTyp { get; }

        /// <summary>Grpc Service-Config Method configs, includes both service-level and method-level.</summary>
        public IReadOnlyDictionary<string, MethodConfig> MethodGrpcConfigsByName { get; }

        /// <summary>Name of the proto package for this service</summary>
        public string ProtoPackage { get; }

        /// <summary>
        /// LRO details of this service, if it represents an LRO polling service in a
        /// non-standard LRO implementation, or null otherwise.
        /// </summary>
        public NonStandardLroDetails NonStandardLro { get; }

        /// The services to be mixed in via additional client properties.
        /// </summary>
        public IEnumerable<MixinDetails> Mixins { get; }

        /// <summary>
        /// The transports that can be used with this service.
        /// </summary>
        public ApiTransports Transports { get; }

        /// <summary>
        /// The details of a service responsible for LRO polling for a non-standard LRO implementation.
        /// (Multiple other services may have methods that return operations polled by the service.)
        /// </summary>
        public class NonStandardLroDetails
        {
            public ServiceDescriptor Service { get; }
            public MethodDescriptor PollingMethod { get; }
            public Typ PollingRequestTyp { get; }
            public MessageDescriptor PollingRequestDescriptor { get; }
            public Typ OperationTyp { get; }
            public MessageDescriptor OperationDescriptor { get; }

            private NonStandardLroDetails(ServiceDescriptor desc, MethodDescriptor pollingMethod)
            {
                Service = desc;
                PollingMethod = pollingMethod;
                PollingRequestDescriptor = pollingMethod.InputType;
                PollingRequestTyp = ProtoUtils.ProtoTyp.Of(PollingRequestDescriptor);
                OperationDescriptor = pollingMethod.OutputType;
                OperationTyp = ProtoUtils.ProtoTyp.Of(OperationDescriptor);
            }

            /// <summary>
            /// Returns the details of the service responsible for polling a non-standard LRO implementation, or
            /// null if the given service has no such responsibility.
            /// </summary>
            public static NonStandardLroDetails ForService(ServiceDescriptor desc)
            {
                var pollingMethods = desc.Methods
                    .Where(method => method.GetExtension(ExtendedOperationsExtensions.OperationPollingMethod))
                    .ToList();
                if (pollingMethods.Count == 0)
                {
                    return null;
                }
                if (pollingMethods.Count > 1)
                {
                    throw new InvalidOperationException($"{desc.FullName} contains more than one method configured for operation polling");
                }
                // Now we know we won't return null, do everything else in the constructor.
                return new NonStandardLroDetails(desc, pollingMethods.Single());
            }
        }

        /// <summary>
        /// The details of a mix-in which a service might have available.
        /// </summary>
        public class MixinDetails
        {
            /// <summary>
            /// The fully-qualified gRPC service name, as specified in service config files.
            /// </summary>
            public string GrpcServiceName { get; }

            /// <summary>
            /// The type of the generated GAPIC client.
            /// </summary>
            public Typ GapicClientType { get; }

            /// <summary>
            /// The type of the generated GAPIC client implementation.
            /// </summary>
            public Typ GapicClientImplType { get; }

            /// <summary>
            /// The type of the "raw" gRPC client.
            /// </summary>
            public Typ GrpcClientType { get; }

            /// <summary>
            /// The type of the generated GAPIC settings.
            /// </summary>
            public Typ GapicSettingsType { get; }

            public MixinDetails(string grpcServiceName, System.Type gapicClientType, System.Type gapicClientImplType, System.Type grpcClientType, System.Type gapicSettingsType)
            {
                GrpcServiceName = grpcServiceName;
                GapicClientType = Typ.Of(gapicClientType);
                GapicClientImplType = Typ.Of(gapicClientImplType);
                GrpcClientType = Typ.Of(grpcClientType);
                GapicSettingsType = Typ.Of(gapicSettingsType);
            }
        }
    }
}
