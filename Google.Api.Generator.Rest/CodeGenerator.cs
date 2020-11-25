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
using System.IO;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest
{
    internal class CodeGenerator
    {
        public static IEnumerable<ResultFile> Generate(string discoveryJson)
        {
            discoveryJson = NormalizeDescriptions(discoveryJson);

            var discoveryDescription = NewtonsoftJsonSerializer.Instance.Deserialize<RestDescription>(discoveryJson);

            var package = new PackageModel(discoveryDescription);
            yield return GenerateCSharpCode(package);
            yield return GenerateProjectFile(package);
            yield return GenerateNet40Config(package);
            yield return GenerateNetStandard10Config(package);
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

        private static ResultFile GenerateCSharpCode(PackageModel package)
        {
            var syntax = package.GenerateCompilationUnit();
            string content = ApplyIfDirectives(CodeFormatter.Format(syntax).ToFullString());
            return new ResultFile($"{package.PackageName}/{package.PackageName}.cs", content);
        }

        /// <summary>
        /// The #if directives in the service are relatively tricky to generate. We hack them in here...
        /// </summary>
        private static string ApplyIfDirectives(string code)
        {
            bool usesCarriageReturn = code.Contains('\r');
            var lines = code.Replace("\r", "").Split('\n').ToList();

            int baseUriIndex = lines.FindIndex(line => line.Contains("public override string BaseUri => BaseUriOverride ??"));
            string withBaseUriOverrideExpression = lines[baseUriIndex].Split(" => ").Last();
            string withoutBaseUriOverrideExpression = withBaseUriOverrideExpression.Split('?').Last().Trim();
            lines[baseUriIndex] = lines[baseUriIndex].Split(" => ").First() + " =>";
            lines.InsertRange(baseUriIndex + 1, new[]
            {
                "        #if NETSTANDARD1_3 || NETSTANDARD2_0 || NET45",
                "            " + withBaseUriOverrideExpression,
                "        #else",
                "            " + withoutBaseUriOverrideExpression,
                "        #endif"
            });

            InsertLine("/// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>", 0, "#if !NET40");
            InsertLine("public override string BatchPath =>", 1, "#endif");

            InsertLine("/// <summary>Synchronously download a range of the media into the given stream.</summary>", 0, "#if !NET40");
            // We need to insert the line two lines lower, after the closing } of the method
            // Note that the additional spaces here are to ensure that the #endif lines up with the brace instead of the return statement.
            InsertLine("    return mediaDownloader.DownloadAsync(this.GenerateRequestUri(), stream, cancellationToken);", 2, "#endif");

            string separator = usesCarriageReturn ? "\r\n" : "\n";
            return string.Join(separator, lines);

            void InsertLine(string contentToFind, int offset, string extraLine)
            {
                int startIndex = 0;
                while (true)
                {
                    int index = lines.FindIndex(startIndex, line => line.Contains(contentToFind, StringComparison.Ordinal));
                    if (index == -1)
                    {
                        return;
                    }
                    // Use the leading whitespace of the existing line to work out how far to indent the new content.
                    string extraWhitespace = lines[index].Substring(0, lines[index].IndexOf(contentToFind, StringComparison.Ordinal));
                    lines.Insert(index + offset, extraWhitespace + extraLine);
                    // Start after the existing line - which may now be one later than it was before.
                    startIndex = index + 2;
                }
            }
        }

        private static ResultFile GenerateProjectFile(PackageModel package)
        {
            var doc = package.GenerateProjectFile();
            // Take care of fine-grained line-break placement, and add a final line break for compatibility
            // with existing generator (which really doesn't need to be changed for this).
            // Note that the built-in XDocument formatting puts the comment on a line on its own, so
            // all we need to do is replace the line with an empty line, and we have a line break.
            string text = doc.ToString().Replace("  <!--linebreak-->", "") + Environment.NewLine;
            return new ResultFile($"{package.PackageName}/{package.PackageName}.csproj", text);
        }

        private static ResultFile GenerateNet40Config(PackageModel package) =>
            new ResultFile($"{package.PackageName}/app.net40.config", LoadResource("Net40Config.xml"));

        private static ResultFile GenerateNetStandard10Config(PackageModel package) =>
            new ResultFile($"{package.PackageName}/app.netstandard10.config", LoadResource("NetStandard10Config.xml"));

        private static string LoadResource(string name)
        {
            string resource = "Google.Api.Generator.Rest.StaticResources." + name;
            using var stream = typeof(CodeGenerator).Assembly.GetManifestResourceStream(resource);
            if (stream is null)
            {
                var allResourceNames = typeof(CodeGenerator).Assembly.GetManifestResourceNames();
                throw new ArgumentException($"Unable to find resource '{resource}'. Available resources: {string.Join(",", allResourceNames)}");
            }
            return new StreamReader(stream).ReadToEnd();
        }
    }
}
