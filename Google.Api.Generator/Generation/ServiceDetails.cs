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
using Google.Protobuf.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Details of a proto-defined service.
    /// </summary>
    internal class ServiceDetails
    {
        public ServiceDetails(ProtoCatalog catalog, string ns, ServiceDescriptor desc)
        {
            Catalog = catalog;
            Namespace = ns;
            DocumentationName = desc.Name; // TODO: There may be a more suitable name than this.
            ProtoTyp = Typ.Manual(ns, desc.Name);
            GrpcClientTyp = Typ.Nested(ProtoTyp, $"{desc.Name}Client");
            SettingsTyp = Typ.Manual(ns, $"{desc.Name}Settings");
            ClientAbstractTyp = Typ.Manual(ns, $"{desc.Name}Client");
            ClientImplTyp = Typ.Manual(ns, $"{desc.Name}ClientImpl");
            desc.CustomOptions.TryGetString(ProtoConsts.ServiceOption.DefaultHost, out var defaultHost);
            DefaultHost = defaultHost ?? "";
            DefaultPort = 443; // Hardcoded; this is not specifiable by proto annotation.
            desc.CustomOptions.TryGetString(ProtoConsts.ServiceOption.OAuthScopes, out var oauthScopes);
            DefaultScopes = oauthScopes?.Split(',', ' ') ?? Enumerable.Empty<string>();
            Methods = desc.Methods.Select(x => MethodDetails.Create(this, x)).ToList();
            SnippetsTyp = Typ.Manual(ns, $"Generated{desc.Name}Snippets");
            SnippetsClientName = $"{desc.Name.ToLowerCamelCase()}Client";
            UnitTestsTyp = Typ.Manual(ns, $"Generated{desc.Name}Test");
        }

        public ProtoCatalog Catalog { get; }
        public string Namespace { get; }

        /// <summary>The name of this service to be used in documentation.</summary>
        public string DocumentationName { get; }

        /// <summary>The outer typ of the protoc-generated C# code.</summary>
        public Typ ProtoTyp { get; }

        /// <summary>The typ of the grpc-protoc-generated C# gRPC client code.</summary>
        public Typ GrpcClientTyp { get; }

        /// <summary>The typ of the GAPIC settings class for this service.</summary>
        public Typ SettingsTyp { get; }

        /// <summary>The typ of the GAPIC abstract client for this service.</summary>
        public Typ ClientAbstractTyp { get; }

        /// <summary>The typ of the GAPIC client implementation for this service.</summary>
        public Typ ClientImplTyp { get; }

        /// <summary>The default hostname for this service.</summary>
        public string DefaultHost { get; }

        /// <summary>The default port for this service.</summary>
        public int DefaultPort { get; }

        /// <summary>The default scopes for this services.</summary>
        public IEnumerable<string> DefaultScopes { get; }

        /// <summary>All RPC methods within this service.</summary>
        public IEnumerable<MethodDetails> Methods { get; }

        /// <summary>The typ of the snippets class for this service.</summary>
        public Typ SnippetsTyp { get; }

        /// <summary>The name of the variable to hold the client instance.</summary>
        public string SnippetsClientName { get; }

        /// <summary>The typ of the unit test class for this service.</summary>
        public Typ UnitTestsTyp { get; }
    }
}
