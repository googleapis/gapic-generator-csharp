using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpYaml;
using SharpYaml.Serialization;

namespace Google.Api.Generator.Generation
{
    public class ServiceYaml
    {
        public static Service ParseYaml(string yamlContentRaw)
        {
            var yamlContentTrim = yamlContentRaw.Trim();

            // If the yaml starts with the `type` attribute, it should be discarded.
            if (yamlContentTrim.StartsWith("type:"))
            {
                // this work for the `\r\n` separator as well because it'll just get discarded
                var yamlContentSplit = yamlContentTrim.Split(new[] {'\n'}, 2);
                if (yamlContentSplit.Length < 2)
                {
                    throw new InvalidOperationException(
                        "Provided service.yaml file does not contain a valid google.api.Service description.");
                }

                yamlContentTrim = yamlContentSplit[1];
            }
                
            var deSerializer = new Serializer();
            var yamlParseResult = deSerializer.Deserialize(yamlContentTrim);

            var serializer = new Serializer(new SerializerSettings { EmitJsonComptible = true });
            var yaml2JsonRaw = JsonConvert.SerializeObject(yamlParseResult, Formatting.Indented);// serializer.Serialize(yamlParseResult);

            // This Yaml serializer will emit some type information before JSON, cutting that off
            var resWithoutTypeInfo = yaml2JsonRaw.Substring(yaml2JsonRaw.IndexOf('{'));
            var serv = Service.Parser.ParseJson(resWithoutTypeInfo);
            
            return serv;
        }

    }
}
