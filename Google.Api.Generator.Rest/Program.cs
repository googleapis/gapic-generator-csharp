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
using Newtonsoft.Json;
using System;
using System.IO;

namespace Google.Api.Generator.Rest
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Expected arguments: <JSON file> <output directory> <features file> <enum storage file>");
                return 1;
            }
            string json = File.ReadAllText(args[0]);
            string outputDirectory = args[1];
            string featuresJson = File.ReadAllText(args[2]);
            
            string enumStorageFile = args[3];
            string enumStorageJson = File.Exists(enumStorageFile) ? File.ReadAllText(enumStorageFile) : "{}";
            var enumStorage = PackageEnumStorage.FromJson(enumStorageJson);

            var features = JsonConvert.DeserializeObject<Features>(featuresJson);
            var files = CodeGenerator.Generate(json, features, enumStorage);
            foreach (var file in files)
            {
                var path = Path.Combine(outputDirectory, file.RelativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, file.Content);
            }

            File.WriteAllText(enumStorageFile, enumStorage.ToJson());
            return 0;
        }
    }
}
