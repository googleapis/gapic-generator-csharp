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

// Generated code. DO NOT EDIT!

#pragma warning disable CS8981
using gaxgrpc = Google.Api.Gax.Grpc;
using gciv = Google.Cloud.Iam.V1;
using gcl = Google.Cloud.Location;
using gpr = Google.Protobuf.Reflection;
using lro = Google.LongRunning;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Static class to provide common access to package-wide API metadata.</summary>
    internal static class PackageApiMetadata
    {
        /// <summary>The <see cref="gaxgrpc::ApiMetadata"/> for services in this package.</summary>
        internal static gaxgrpc::ApiMetadata ApiMetadata { get; } = new gaxgrpc::ApiMetadata("Google.Showcase.V1Beta1", GetFileDescriptors)
            .WithRequestNumericEnumJsonEncoding(true)
            .WithHttpRuleOverrides(new scg::Dictionary<string, proto::ByteString>
            {
                {
                    "google.cloud.location.Locations.GetLocation",
                    // { "get": "/v1beta1/{name=projects/*/locations/*}" }
                    proto::ByteString.FromBase64("EiYvdjFiZXRhMS97bmFtZT1wcm9qZWN0cy8qL2xvY2F0aW9ucy8qfQ==")
                },
                {
                    "google.cloud.location.Locations.ListLocations",
                    // { "get": "/v1beta1/{name=projects/*}/locations" }
                    proto::ByteString.FromBase64("EiQvdjFiZXRhMS97bmFtZT1wcm9qZWN0cy8qfS9sb2NhdGlvbnM=")
                },
                {
                    "google.iam.v1.IAMPolicy.GetIamPolicy",
                    // { "get": "/v1beta1/{resource=users/*}:getIamPolicy", "additionalBindings": [ { "get": "/v1beta1/{resource=rooms/*}:getIamPolicy" }, { "get": "/v1beta1/{resource=rooms/*/blurbs/*}:getIamPolicy" }, { "get": "/v1beta1/{resource=sequences/*}:getIamPolicy" } ] }
                    proto::ByteString.FromBase64("EigvdjFiZXRhMS97cmVzb3VyY2U9dXNlcnMvKn06Z2V0SWFtUG9saWN5WioSKC92MWJldGExL3tyZXNvdXJjZT1yb29tcy8qfTpnZXRJYW1Qb2xpY3laMxIxL3YxYmV0YTEve3Jlc291cmNlPXJvb21zLyovYmx1cmJzLyp9OmdldElhbVBvbGljeVouEiwvdjFiZXRhMS97cmVzb3VyY2U9c2VxdWVuY2VzLyp9OmdldElhbVBvbGljeQ==")
                },
                {
                    "google.iam.v1.IAMPolicy.SetIamPolicy",
                    // { "post": "/v1beta1/{resource=users/*}:setIamPolicy", "body": "*", "additionalBindings": [ { "post": "/v1beta1/{resource=rooms/*}:setIamPolicy", "body": "*" }, { "post": "/v1beta1/{resource=rooms/*/blurbs/*}:setIamPolicy", "body": "*" }, { "post": "/v1beta1/{resource=sequences/*}:setIamPolicy", "body": "*" } ] }
                    proto::ByteString.FromBase64("IigvdjFiZXRhMS97cmVzb3VyY2U9dXNlcnMvKn06c2V0SWFtUG9saWN5OgEqWi0iKC92MWJldGExL3tyZXNvdXJjZT1yb29tcy8qfTpzZXRJYW1Qb2xpY3k6ASpaNiIxL3YxYmV0YTEve3Jlc291cmNlPXJvb21zLyovYmx1cmJzLyp9OnNldElhbVBvbGljeToBKloxIiwvdjFiZXRhMS97cmVzb3VyY2U9c2VxdWVuY2VzLyp9OnNldElhbVBvbGljeToBKg==")
                },
                {
                    "google.iam.v1.IAMPolicy.TestIamPermissions",
                    // { "post": "/v1beta1/{resource=users/*}:testIamPermissions", "body": "*", "additionalBindings": [ { "post": "/v1beta1/{resource=rooms/*}:testIamPermissions", "body": "*" }, { "post": "/v1beta1/{resource=rooms/*/blurbs/*}:testIamPermissions", "body": "*" }, { "post": "/v1beta1/{resource=sequences/*}:testIamPermissions", "body": "*" } ] }
                    proto::ByteString.FromBase64("Ii4vdjFiZXRhMS97cmVzb3VyY2U9dXNlcnMvKn06dGVzdElhbVBlcm1pc3Npb25zOgEqWjMiLi92MWJldGExL3tyZXNvdXJjZT1yb29tcy8qfTp0ZXN0SWFtUGVybWlzc2lvbnM6ASpaPCI3L3YxYmV0YTEve3Jlc291cmNlPXJvb21zLyovYmx1cmJzLyp9OnRlc3RJYW1QZXJtaXNzaW9uczoBKlo3IjIvdjFiZXRhMS97cmVzb3VyY2U9c2VxdWVuY2VzLyp9OnRlc3RJYW1QZXJtaXNzaW9uczoBKg==")
                },
                {
                    "google.longrunning.Operations.CancelOperation",
                    // { "post": "/v1beta1/{name=operations/**}:cancel" }
                    proto::ByteString.FromBase64("IiQvdjFiZXRhMS97bmFtZT1vcGVyYXRpb25zLyoqfTpjYW5jZWw=")
                },
                {
                    "google.longrunning.Operations.DeleteOperation",
                    // { "delete": "/v1beta1/{name=operations/**}" }
                    proto::ByteString.FromBase64("Kh0vdjFiZXRhMS97bmFtZT1vcGVyYXRpb25zLyoqfQ==")
                },
                {
                    "google.longrunning.Operations.GetOperation",
                    // { "get": "/v1beta1/{name=operations/**}" }
                    proto::ByteString.FromBase64("Eh0vdjFiZXRhMS97bmFtZT1vcGVyYXRpb25zLyoqfQ==")
                },
                {
                    "google.longrunning.Operations.ListOperations",
                    // { "get": "/v1beta1/operations" }
                    proto::ByteString.FromBase64("EhMvdjFiZXRhMS9vcGVyYXRpb25z")
                },
            });

        private static scg::IEnumerable<gpr::FileDescriptor> GetFileDescriptors()
        {
            yield return gciv::IamPolicyReflection.Descriptor;
            yield return gciv::OptionsReflection.Descriptor;
            yield return gciv::PolicyReflection.Descriptor;
            yield return gcl::LocationsReflection.Descriptor;
            yield return lro::OperationsReflection.Descriptor;
            yield return ComplianceReflection.Descriptor;
            yield return EchoReflection.Descriptor;
            yield return IdentityReflection.Descriptor;
            yield return MessagingReflection.Descriptor;
            yield return SequenceReflection.Descriptor;
            yield return TestingReflection.Descriptor;
        }
    }
}
