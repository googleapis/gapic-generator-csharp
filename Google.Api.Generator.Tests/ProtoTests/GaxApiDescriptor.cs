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

using gaxgrpc = Google.Api.Gax.Grpc;
using gpr = Google.Protobuf.Reflection;
using scg = System.Collections.Generic;

// This is a "fallback" API descriptor class, effectively: all the proto tests (other than Showcase)
// use a namespace under "Testing." so this is always valid; if a "real" GaxApiDescriptor is present
// for testing, that will take priority as its namespace will match exactly.

namespace Testing
{
    /// <summary>Static class to provide common access to an API descriptor.</summary>
    internal static class GaxApiDescriptor
    {
        /// <summary>The <see cref="gaxgrpc::ApiDescriptor"/> for services in this package.</summary>
        internal static gaxgrpc::ApiDescriptor ApiDescriptor { get; } = new gaxgrpc::ApiDescriptor("Testing (fallback)", gaxgrpc::GrpcTransports.Grpc, GetFileDescriptors);

        private static scg::IEnumerable<gpr::FileDescriptor> GetFileDescriptors()
        {
            yield break;
        }
    }
}
