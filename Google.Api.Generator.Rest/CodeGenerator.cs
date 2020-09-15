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
using Microsoft.CodeAnalysis;
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
            yield return GenerateNet40Config();
            yield return GenerateNetStandard10Config();
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
            var ctx = SourceFileContext.CreateFullyQualified(SystemClock.Instance);
            var ns = Namespace(package.PackageName);
            using (ctx.InNamespace(ns))
            {
                var serviceClass = package.GenerateServiceClass(ctx);
                var baseRequestClass = package.GenerateBaseRequestClass(ctx);
                ns = ns.AddMembers(serviceClass, baseRequestClass);

                foreach (var resource in package.Resources)
                {
                    var resourceClass = resource.GenerateClass(ctx);
                    ns = ns.AddMembers(resourceClass);
                }
            }
            var dataNs = Namespace(package.PackageName + ".Data");
            using (ctx.InNamespace(dataNs))
            {
                foreach (var dataModel in package.DataModels.Where(dm => dm.Parent is null))
                {
                    dataNs = dataNs.AddMembers(dataModel.GenerateClass(ctx));
                }
            }
            var syntax = ctx.CreateCompilationUnit(ns).AddMembers(dataNs);
            
            string content = ApplyIfDirectives(CodeFormatter.Format(syntax).ToFullString());
            return new ResultFile($"{package.PackageName}.cs", content);
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

            int batchBaseUriIndex = lines.FindIndex(line => line.Contains("/// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>"));
            lines.Insert(batchBaseUriIndex, "        #if !NET40");

            int batchPathIndex = lines.FindIndex(line => line.Contains("public override string BatchPath =>"));
            lines.Insert(batchPathIndex + 1, "        #endif");

            // TODO: Media downloads have #if as well, for the DownloadRange and DownloadRangeAsync methods.

            string separator = usesCarriageReturn ? "\r\n" : "\n";
            return string.Join(separator, lines);
        }

        private static ResultFile GenerateProjectFile(PackageModel package)
        {
            var doc = package.GenerateProjectFile();
            return new ResultFile($"{package.PackageName}.csproj", doc.ToString());
        }

        private static ResultFile GenerateNet40Config() =>
            new ResultFile("app.net40.config", LoadResource("Net40Config.xml"));

        private static ResultFile GenerateNetStandard10Config() =>
            new ResultFile("app.netstandard10.config", LoadResource("NetStandard10Config.xml"));

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
