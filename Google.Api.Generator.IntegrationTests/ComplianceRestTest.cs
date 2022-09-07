// Copyright 2022 Google LLC
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

using Google.Api.Gax.Grpc;
using Google.Protobuf;
using Google.Showcase.V1Beta1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Google.Api.Generator.IntegrationTests
{
    /// <summary>
    /// Compliance test for the REST transport.
    /// </summary>
    public class ComplianceRestTest : ShowcaseTestBase<ComplianceClient, ComplianceClientBuilder>
    {
        private static ComplianceSuite s_testFile = TestResources.ParseJson<ComplianceSuite>("compliance_suite.json");
        public static IEnumerable<object[]> Tests =>
            from grp in s_testFile.Group
            from rpc in grp.Rpcs
            from req in grp.Requests
            select new object[] { new SerializableTest(grp.Name, rpc, req) };

        [SkippableTheory]
        [InlineData(false)]
        [InlineData(true)]
        public void GetEnum(bool unknownEnum)
        {
            var client = CreateClient();
            var response = client.GetEnum(new EnumRequest { UnknownEnum = unknownEnum });
            Assert.Equal(!unknownEnum, Enum.IsDefined(typeof(Continent), response.Continent));
        }

        [SkippableTheory]
        [MemberData(nameof(Tests))]
        public void Transcoding(SerializableTest test)
        {
            // See https://github.com/googleapis/gapic-showcase/issues/1203
            Skip.If(test.Request.Name == "Extreme values");

            var rpc = test.Rpc;
            var request = test.Request;
            var client = CreateClient();
            var parts = rpc.Split('.');

            // Check that we're asked for a Compliance RPC...
            Assert.Equal("Compliance", parts[0]);

            var method = client.GetType().GetMethod(parts[1], new[] { typeof(RepeatRequest), typeof(CallSettings) });
            var response = (RepeatResponse) method.Invoke(client, new object[] { request, null });
            Assert.NotEmpty(response.BindingUri);
            Assert.Equal(request.Info, response.Request.Info);
        }

        /// <summary>
        /// XUnit-serializable representation of a transcoding test, so we can easily execute just one at a time from VS.
        /// </summary>
        public class SerializableTest : IXunitSerializable
        {
            public string GroupName { get; private set; }
            public RepeatRequest Request { get; private set; }
            public string Rpc { get; private set; }

            // Used in deserialization
            public SerializableTest() { }

            public SerializableTest(string groupName, string rpc, RepeatRequest request) =>
                (GroupName, Rpc, Request) = (groupName, rpc, request);

            public void Deserialize(IXunitSerializationInfo info)
            {
                GroupName = info.GetValue<string>(nameof(GroupName));
                Request = RepeatRequest.Parser.ParseFrom(info.GetValue<byte[]>(nameof(Request)));
                Rpc = info.GetValue<string>(nameof(Rpc));
            }

            public void Serialize(IXunitSerializationInfo info)
            {
                info.AddValue(nameof(GroupName), GroupName);
                info.AddValue(nameof(Request), Request.ToByteArray());
                info.AddValue(nameof(Rpc), Rpc);
            }

            public override string ToString() => $"{GroupName} / {Rpc} / {Request?.Name}";
        }
    }
}