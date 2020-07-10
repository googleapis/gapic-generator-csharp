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

using Google.Api.Generator.Utils.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Google.Api.Generator.Utils
{
    /// <summary>
    /// Code generation result for a single file.
    /// </summary>
    public class ResultFile
    {
        /// <summary>
        /// The path to write the content to, relative to the output directory.
        /// </summary>
        public string RelativePath { get; }

        /// <summary>
        /// The content of the file.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Creates a new result file from text content.
        /// </summary>
        public ResultFile(string relativePath, string content) =>
            (RelativePath, Content) = (relativePath, content);

        /// <summary>
        /// Creates a new result file from a Roslyn compilation unit syntax. The code
        /// is automatically formatted using <see cref="CodeFormatter"/>.
        /// </summary>
        public ResultFile(string relativePath, CompilationUnitSyntax compilationUnit)
            : this(relativePath, CodeFormatter.Format(compilationUnit).ToFullString())
        {
        }
    }
}
