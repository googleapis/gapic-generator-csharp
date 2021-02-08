// Copyright 2021 Google LLC
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

using System.Collections.Generic;

namespace Google.Api.Generator.Rest.Models
{
    public class Features
    {
        /// <summary>
        /// Major/minor/patch of the generated packages.
        /// (Build part is provided by the Discovery doc.)
        /// </summary>
        public string ReleaseVersion { get; set; }

        /// <summary>
        /// Version of support library upon which to depend.
        /// </summary>
        public string CurrentSupportVersion { get; set; }

        /// <summary>
        /// Version of PCL support library.
        /// </summary>
        public string PclSupportVersion { get; set; }

        /// <summary>
        /// Version of net40 support library.
        /// </summary>
        public string Net40SupportVersion { get; set; }

        /// <summary>
        /// Map from REST library to GAPIC library to inform uses of the preferred package.
        /// </summary>
        public IReadOnlyDictionary<string, string> CloudPackageMap { get; set; } =
            new Dictionary<string, string>();

        /// <summary>
        /// Allows individual APIs to have a different major version number to the one in ReleaseVersion.
        /// </summary>
        public IReadOnlyDictionary<string, int> MajorVersionOverrideMap { get; set; } =
            new Dictionary<string, int>();
    }
}
