using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Google.Api.Generator.Generation
{
    internal static class MetadataGenerator
    {
        private const string GapicMetadataSchemaVersion = "1.0";
        private const string GapicMetadataFileDescription = "This file maps proto services/RPCs to the corresponding library clients/methods";


        internal static string GenerateGapicMedatataJson(List<ServiceDetails> allServiceDetails)
        {
            var gapicMetadata = new Dictionary<string, string>();
            gapicMetadata["schema"] = GapicMetadataSchemaVersion;
            gapicMetadata["comment"] = GapicMetadataFileDescription;
            gapicMetadata["language"] = "csharp";
            gapicMetadata["protoPackage"] = allServiceDetails.First().Package;
            gapicMetadata["libraryPackage"] = allServiceDetails.First().Namespace;

            return JsonSerializer.Serialize(gapicMetadata, new JsonSerializerOptions {WriteIndented = true});
        }
    }
}
