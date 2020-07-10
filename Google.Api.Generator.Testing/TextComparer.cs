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

using Google.Api.Generator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace Google.Api.Generator.Testing
{
    /// <summary>
    /// Utility code to compare the content of a "golden" file with actual generated code.
    /// </summary>
    public static class TextComparer
    {
        public static void CompareText(string expectedFilePath, ResultFile actualFile)
        {
            Assert.True(File.Exists(expectedFilePath), $"Expected file does not exist: '{expectedFilePath}'");

            var expectedLines = File.ReadAllLines(expectedFilePath).Select(x => x.Trim('\r')).ToList();
            if (expectedLines.Any(line => line.Trim() == "// TEST_DISABLE"))
            {
                return;
            }
            var actualLines = actualFile.Content.Split('\n').Select(x => x.Trim('\r')).ToList();
            var fullFile = !expectedLines.Any(x => x.Trim() == "// TEST_START");
            var expectedBlocks = fullFile ? new[] { expectedLines.Select((s, i) => (i, s)).ToList() } : TestBlocks();
            // Check that all expected code blocks in the expected code exist in the generated (actual) code.
            // The order of the test blocks is not enforced, only the content.
            foreach (var block in expectedBlocks)
            {
                int blockIndex = 0;
                (int lineNumber, string line) missing = default;
                string missingActualLine = null;
                int missingBestLength = -1;
                foreach (var (actualLine, actualLineNumber) in actualLines.Select((line, i) => (line, i)))
                {
                    if (block[blockIndex].line == actualLine && (!fullFile || block[blockIndex].lineNumber == actualLineNumber))
                    {
                        blockIndex += 1;
                        if (blockIndex == block.Count)
                        {
                            missing = default;
                            break;
                        }
                    }
                    else
                    {
                        if (blockIndex > missingBestLength)
                        {
                            missing = block[blockIndex];
                            missingActualLine = actualLine;
                            missingBestLength = blockIndex;
                        }
                        blockIndex = 0;
                    }
                }
                if (missing.line != null)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, actualLines));
                    throw new XunitException($"Failed to find expected line {missing.lineNumber + 1} in '{Path.GetFileName(actualFile.RelativePath)}'\n" +
                        $"  Expected line:  '{missing.line}'\n" +
                        $"  Generated line: '{missingActualLine}'");
                }
            }

            IEnumerable<IList<(int lineNumber, string line)>> TestBlocks()
            {
                bool active = false;
                var block = new List<(int, string)>();
                foreach (var (line, lineNumber) in expectedLines.Select((s, i) => (s, i)))
                {
                    if (active)
                    {
                        if (line.Trim() == "// TEST_END")
                        {
                            active = false;
                            yield return block.ToArray();
                            block.Clear();
                        }
                        else
                        {
                            block.Add((lineNumber, line));
                        }
                    }
                    else if (line.Trim() == "// TEST_START")
                    {
                        active = true;
                    }
                }
            }
        }
    }
}
