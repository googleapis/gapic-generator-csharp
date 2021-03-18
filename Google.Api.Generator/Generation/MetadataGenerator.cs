using Google.Gapic.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Google.Api.Generator.Generation
{
    internal static class MetadataGenerator
    {
        private const string GapicMetadataSchemaVersion = "1.0";
        private const string GapicMetadataFileDescription = "This file maps proto services/RPCs to the corresponding library clients/methods";
        private const string GapicMetadataLanguage = "csharp";

        private const string TransportKeyGrpc = "grpc";

        internal static string GenerateGapicMetadataJson(List<ServiceDetails> allServiceDetails)
        {
            
            var gapicMetadata = new GapicMetadata
            {
                Schema = GapicMetadataSchemaVersion,
                Comment = GapicMetadataFileDescription,
                Language = GapicMetadataLanguage,
                ProtoPackage = allServiceDetails.First().Package,
                LibraryPackage = allServiceDetails.First().Namespace
            };

            foreach (var serviceDetails in allServiceDetails)
            {
                gapicMetadata.Services[serviceDetails.ServiceName] = ServiceForTransportMetadata(serviceDetails);
            }
   
            return JsonSerializer.Serialize(gapicMetadata, new JsonSerializerOptions {WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase, DictionaryKeyPolicy = JsonNamingPolicy.CamelCase});
        }

        private static GapicMetadata.Types.ServiceForTransport ServiceForTransportMetadata(ServiceDetails serviceDetails)
        {
            var serviceForTransportMetadata = new GapicMetadata.Types.ServiceForTransport();
            
            serviceForTransportMetadata.Clients[TransportKeyGrpc] = ServiceAsClientMetadata(serviceDetails);
            return serviceForTransportMetadata;
        }

        private static GapicMetadata.Types.ServiceAsClient ServiceAsClientMetadata(ServiceDetails serviceDetails)
        {
            var serviceAsClient = new GapicMetadata.Types.ServiceAsClient
            {
                LibraryClient = serviceDetails.ClientImplTyp.FullName
            };

            foreach (var methodDetails in serviceDetails.Methods)
            {
                var methodsList = new GapicMetadata.Types.MethodList();
                methodsList.Methods.AddRange(new[] { methodDetails.SyncMethodName, methodDetails.AsyncMethodName });
                serviceAsClient.Rpcs[methodDetails.MethodName] = methodsList;
            }

            return serviceAsClient;
        }
    }
}
