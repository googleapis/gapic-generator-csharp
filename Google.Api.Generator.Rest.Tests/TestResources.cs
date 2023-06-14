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

using Google.Api.Gax.Testing;
using Google.Api.Generator.Rest.Models;
using Google.Api.Generator.Testing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Google.Api.Generator.Rest.Tests
{
    public class TestResources
    {
        /// <summary>
        /// The root directory of the test project.
        /// </summary>
        public static string TestDirectory { get; }

        private static string ActualGeneratedFilesDir { get; } = Path.Combine(Path.GetTempPath(), $"GeneratorTests-{DateTime.UtcNow:yyyyMMddHHmmssZ}");

        static TestResources()
        {
            var rootPath = Environment.CurrentDirectory;
            while (!rootPath.EndsWith("Google.Api.Generator.Rest.Tests"))
            {
                rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            }
            TestDirectory = rootPath;
        }

        internal static void TestOutput(string directory, bool ignoreCsProj = false)
        {
            var clock = new FakeClock(new DateTime(2022, 1, 1));
            var resourceDirectory = Path.Combine(TestDirectory, "GoldenTestData", directory);
            var json = File.ReadAllText(Path.Combine(resourceDirectory, "discovery.json"));
            var features = new Features
            {
                ReleaseVersion = "1.54.0",
                CurrentSupportVersion = "1.54.0",
                Net40SupportVersion = "1.10.0",
                PclSupportVersion = "1.25.0",
                CloudPackageMap = new Dictionary<string, string>
                {
                    { "Google.Apis.Storage.v1", "Google.Cloud.Storage.V1" },
                    { "Google.Apis.Translate.v2", "Google.Cloud.Translation.V2" }
                }
            };
            PackageEnumStorage enumStorage = PackageEnumStorage.FromJson("{}");
            var files = CodeGenerator.Generate(json, features, enumStorage, clock).ToList();

            // Write all output files to the temporary directory before validating any.
            // This makes it easier to see the complete set of outputs.
            foreach (var file in files)
            {
                var pathToWriteTo = Path.Combine(ActualGeneratedFilesDir, file.RelativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(pathToWriteTo));
                File.WriteAllText(pathToWriteTo, file.Content);
            }

            // Check output is present.
            Assert.NotEmpty(files);

            foreach (var file in files)
            {
                if (ignoreCsProj && file.RelativePath.EndsWith(".csproj"))
                {
                    continue;
                }
                var expectedFilePath = Path.Combine(TestDirectory, "GoldenTestData", file.RelativePath);

                TextComparer.CompareText(expectedFilePath, file);
            }

            // TODO: Validate enum storage
        }
    }
}
