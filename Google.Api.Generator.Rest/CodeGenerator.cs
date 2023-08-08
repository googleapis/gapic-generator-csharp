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
                // Remove line breaks, at least for now.
                // Currently (2023-08-08) Discovery docs are inconsistent in their use of multi-line
                // descriptions. If Discovery docs were created with descriptions on multiple lines
                // as per the original protos, we could use XmlDoc.SummaryPreFormatted everywhere,
                // and assume reasonable line lengths and formatting. For now, we remove line breaks
                // and wrap - which is far from ideal.
                // We could potentially have a helper method which assumes preformatting when there
                // are multiple lines, and non-preformatting otherwise.
                description.Value = text.Replace("\n", " ");
            }
            return raw.ToString();
        }

        private static ResultFile GenerateCSharpCode(PackageModel package, IClock clock)
        {
            var syntax = package.GenerateCompilationUnit(clock);
            string content = CodeFormatter.Format(syntax).ToFullString();
            content = ReformatBackticksInComments(content);
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

        /// <summary>
        /// Split comment lines on triple-backticks, maintaining the backticks on lines on their own.
        /// Until we get *real* multi-line support, the result will still be a mess, but it won't
        /// cause docfx to fail.
        /// </summary>
        private static string ReformatBackticksInComments(string text)
        {
            // It doesn't matter whether the separator is \r\n or \n; we'll preserve the \r
            // and add \r to the end of any *new* lines, based on the existing ones.
            List<string> lines = text.Split('\n').SelectMany(MaybeSplitLine).ToList();
            return string.Join('\n', lines);

            IEnumerable<string> MaybeSplitLine(string line)
            {
                int commentStartIndex = line.IndexOf("/// ");
                if (commentStartIndex == -1 || !line.Contains("```"))
                {
                    yield return line;
                    yield break;
                }

                string comment = line.Substring(commentStartIndex + 4);
                string prefix = line.Substring(0, commentStartIndex + 4);
                string suffix = line.EndsWith('\r') ? "\r" : "";
                string[] pieces = comment.Split("```", StringSplitOptions.TrimEntries);

                bool first = true;
                foreach (var piece in pieces)
                {
                    if (!first)
                    {
                        yield return prefix + "```" + suffix;
                    }
                    // We don't trim empty entries when splitting, as we still want to emit
                    // the right number of ``` lines, but we can omit empty lines here.
                    if (piece != "")
                    {
                        yield return prefix + piece + suffix;
                    }
                    first = false;
                }
            }
        }
    }
}
