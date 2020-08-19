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
using Google.Apis.Discovery.v1.Data;
using Google.Apis.Json;
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
            var discoveryDescription = NewtonsoftJsonSerializer.Instance.Deserialize<RestDescription>(discoveryJson);
            var package = new PackageModel(discoveryDescription);
            yield return GenerateCSharpCode(package);
            yield return GenerateProjectFile(package);
            yield return GenerateNet40Config();
            yield return GenerateNetStandard10Config();
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
            return new ResultFile($"{package.PackageName}.cs", syntax);
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
