// Copyright 2020 Google LLC
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

using Google.Api.Gax;
using Google.Api.Generator.Rest.Models;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Formatting;
using Google.Apis.Discovery.v1.Data;
using Google.Apis.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.Rest
{
    internal class CodeGenerator
    {
        public static IEnumerable<ResultFile> Generate(string discoveryJson, Features features, PackageEnumStorage enumStorage, IClock clock)
        {
            discoveryJson = NormalizeDescriptions(discoveryJson);

            var discoveryDescription = NewtonsoftJsonSerializer.Instance.Deserialize<RestDescription>(discoveryJson);

            var package = new PackageModel(discoveryDescription, features, enumStorage);
            yield return GenerateCSharpCode(package, clock);
            yield return GenerateProjectFile(package, clock);
        }

        private static string NormalizeDescriptions(string discoveryJson)
        {
            JObject raw = JObject.Parse(discoveryJson);
            var descriptions = raw.Descendants()
                .OfType<JProperty>()
                .Where(prop => prop.Name == "description" && prop.Value.Type == JTokenType.String);
            foreach (var description in descriptions)
            {
                string text = (string) (description.Value);
                description.Value = text.Replace("\n", " ");
            }
            return raw.ToString();
        }

        private static ResultFile GenerateCSharpCode(PackageModel package, IClock clock)
        {
            var syntax = package.GenerateCompilationUnit(clock);
            string content = CodeFormatter.Format(syntax).ToFullString();
            return new ResultFile($"{package.PackageName}/{package.PackageName}.cs", content);
        }

        private static ResultFile GenerateProjectFile(PackageModel package, IClock clock)
        {
            var doc = package.GenerateProjectFile(clock);
            // Take care of fine-grained line-break placement, and add a final line break for compatibility
            // with existing generator (which really doesn't need to be changed for this).
            // Note that the built-in XDocument formatting puts the comment on a line on its own, so
            // all we need to do is replace the line with an empty line, and we have a line break.
            string text = doc.ToString().Replace("  <!--linebreak-->", "") + Environment.NewLine;
            return new ResultFile($"{package.PackageName}/{package.PackageName}.csproj", text);
        }
    }
}
