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

using System;
using System.IO;
using System.Linq;

namespace Google.Api.Generator.DiffSimplifier
{
    /// <summary>
    /// Simple tool to recurse through the given directories finding appropriate files (e.g. *.cs, *.csproj)
    /// and normalizing them to make diffs simpler. This could involve removing copyright statements, trimming
    /// trailing whitespace, reformatting comments etc.
    /// </summary>
    public class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify at least one directory");
                return 1;
            }
            foreach (var directory in args)
            {
                NormalizeContents(directory);
            }
            return 0;
        }

        private static void NormalizeContents(string directory)
        {
            foreach (var subdirectory in Directory.GetDirectories(directory))
            {
                NormalizeContents(subdirectory);
            }
            foreach (var csharpFile in Directory.GetFiles(directory, "*.cs"))
            {
                NormalizeSourceFile(csharpFile);
            }
            // TODO: csproj
        }

        private static void NormalizeSourceFile(string file)
        {
            Console.WriteLine($"Normalizing {file}");
            // Remove trailing whitespace for all lines, and remove blank lines.
            var lines = File.ReadAllLines(file)
                .Select(line => line.TrimEnd())
                .Where(line => line != "")
                .ToList();

            // Remove copyright
            lines = lines.SkipWhile(line => line.StartsWith("//")).ToList();

            // Remove all comments. This way we're not broken by the Python generator stripping (instead of escaping) things like "<name>".
            // It would be really nice to be able to retain comments when diffing, but we've got more important differences to handle first.
            lines = lines.Where(line => !line.TrimStart().StartsWith("///")).ToList();

            File.WriteAllLines(file, lines);
        }
    }
}
