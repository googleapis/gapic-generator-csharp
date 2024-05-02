// Copyright 2021 Google Inc. All Rights Reserved.
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
using Google.Gapic.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Gapic.Metadata.GapicMetadata.Types;

namespace Google.Api.Generator.Generation
{
    internal static class MetadataGenerator
    {
        private const string GapicMetadataSchemaVersion = "1.0";
        private const string GapicMetadataFileDescription = "This file maps proto services/RPCs to the corresponding library clients/methods";
        private const string GapicMetadataLanguage = "csharp";

        private const string TransportKeyGrpc = "grpc";

        internal static string GenerateGapicMetadataJson(List<ServiceDetails> primaryLibraryServices)
        {
            var protoPackage = primaryLibraryServices.First().ProtoPackage;
            var libraryNamespace = primaryLibraryServices.First().Namespace;
            var servicesByName = new SortedDictionary<string, ServiceForTransport>(
                primaryLibraryServices.ToDictionary(serviceDetails => serviceDetails.OriginalServiceName, ServiceForTransportMetadata),
                StringComparer.Ordinal);

            return new GapicMetadata
            {
                Schema = GapicMetadataSchemaVersion,
                Comment = GapicMetadataFileDescription,
                Language = GapicMetadataLanguage,
                ProtoPackage = protoPackage,
                LibraryPackage = libraryNamespace,
                Services = { servicesByName }
            }.ToFormattedJson();
        }

        private static ServiceForTransport ServiceForTransportMetadata(ServiceDetails serviceDetails) =>
            new ServiceForTransport
            {
                Clients =
                {

                    [TransportKeyGrpc] = new ServiceAsClient
                        {
                            LibraryClient = serviceDetails.ClientAbstractTyp.Name,
                            Rpcs =
                            {
                                new SortedDictionary<string, MethodList>(
                                    serviceDetails.Methods.ToDictionary(
                                        methodDetails => methodDetails.ProtoRpcName,
                                        methodDetails => new MethodList
                                        {
                                            Methods = { methodDetails.SyncMethodName, methodDetails.AsyncMethodName }
                                        }), StringComparer.Ordinal)
                            }
                        }
                }
            };
    }
}
