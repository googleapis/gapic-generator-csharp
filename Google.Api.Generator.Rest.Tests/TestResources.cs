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

using Google.Api.Generator.Rest.Models;
using Google.Api.Generator.Testing;
using System;
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

        static TestResources()
        {
            var rootPath = Environment.CurrentDirectory;
            while (!rootPath.EndsWith("Google.Api.Generator.Rest.Tests"))
            {
                rootPath = Path.GetFullPath(Path.Combine(rootPath, ".."));
            }
            TestDirectory = rootPath;
        }

        internal static void TestOutput(string directory, bool ignoreCsProj = false, bool ignoreConfig = false)
        {
            var resourceDirectory = Path.Combine(TestDirectory, "GoldenTestData", directory);
            var json = File.ReadAllText(Path.Combine(resourceDirectory, "discovery.json"));
            var features = new Features
            {
                ReleaseVersion = "1.49.0",
                CurrentSupportVersion = "1.49.0",
                Net40SupportVersion = "1.25.0",
                PclSupportVersion = "1.10.0"
            };
            var files = CodeGenerator.Generate(json, features).ToList();
            // Check output is present.
            Assert.NotEmpty(files);

            foreach (var file in files)
            {
                if ((ignoreCsProj && file.RelativePath.EndsWith(".csproj")) ||
                    (ignoreConfig && file.RelativePath.EndsWith(".config")))
                {
                    continue;
                }
                var expectedFilePath = Path.Combine(TestDirectory, "GoldenTestData", directory, file.RelativePath);

                TextComparer.CompareText(expectedFilePath, file);
            }
        }
    }
}
