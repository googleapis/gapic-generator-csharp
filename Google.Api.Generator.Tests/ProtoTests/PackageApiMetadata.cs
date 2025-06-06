// Copyright 2019 Google LLC
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

using GAXGPRC = Google.Api.Gax.Grpc;
using GPR = Google.Protobuf.Reflection;
using SCG = System.Collections.Generic;

// This is a "fallback" API descriptor class, effectively: all the proto tests (other than Showcase)
// use a namespace under "Testing." so this is always valid; if a "real" PackageApiMetadata is present
// for testing, that will take priority as its namespace will match exactly.

namespace Testing
{
    /// <summary>Static class to provide common access to package-wide API metadata.</summary>
    internal static class PackageApiMetadata
    {
        /// <summary>The <see cref="GAXGPRC::ApiMetadata"/> for services in this package.</summary>
        internal static GAXGPRC::ApiMetadata ApiMetadata { get; } = new GAXGPRC::ApiMetadata("Testing (fallback)", GetFileDescriptors);

        private static SCG::IEnumerable<GPR::FileDescriptor> GetFileDescriptors()
        {
            yield break;
        }
    }
}
