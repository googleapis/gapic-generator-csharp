// Copyright 2019 Google Inc. All Rights Reserved.
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

using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Grpc.Core;
using System;

namespace Testing.UnitTests
{
    // gRPC fake.
    public partial class UnitTests
    {
        public partial class UnitTestsClient
        {
            public UnitTestsClient() { }
            public UnitTestsClient(CallInvoker invoker) { }
            public CallInvoker CallInvoker => throw new NotImplementedException();
            public virtual Response MethodValues(ValuesRequest request, CallOptions options) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> MethodValuesAsync(ValuesRequest request, CallOptions options) => throw new NotImplementedException();
            public virtual Operation MethodLro(LroRequest request, CallOptions options) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Operation> MethodLroAsync(LroRequest request, CallOptions options) => throw new NotImplementedException();
        }
    }

    public class AnotherMessage : ProtoMsgFake<AnotherMessage> { }

    public enum Enum
    {
        Default = 0,
    }

    public partial class ValuesRequest : ProtoMsgFake<ValuesRequest>
    {
        public static class Types
        {
            public class NestedMessage : ProtoMsgFake<NestedMessage> { }
            public enum NestedEnum
            {
                Default = 0,
            }
        }

        public double SingleDouble { get; set; }
        public float SingleFloat { get; set; }
        public int SingleInt32 { get; set; }
        public long SingleInt64 { get; set; }
        public uint SingleUint32 { get; set; }
        public ulong SingleUint64 { get; set; }
        public int SingleSint32 { get; set; }
        public long SingleSint64 { get; set; }
        public uint SingleFixed32 { get; set; }
        public ulong SingleFixed64 { get; set; }
        public int SingleSfixed32 { get; set; }
        public long SingleSfixed64 { get; set; }
        public bool SingleBool { get; set; }
        public string SingleString { get; set; }
        public ByteString SingleBytes { get; set; }
        public AnotherMessage SingleMessage { get; set; }
        public Types.NestedMessage SingleNestedMessage { get; set; }
        public Enum SingleEnum { get; set; }
        public Types.NestedEnum SingleNestedEnum { get; set; }
        public RepeatedField<double> RepeatedDouble { get; } = new RepeatedField<double>();
        public RepeatedField<float> RepeatedFloat { get; } = new RepeatedField<float>();
        public RepeatedField<int> RepeatedInt32 { get; } = new RepeatedField<int>();
        public RepeatedField<long> RepeatedInt64 { get; } = new RepeatedField<long>();
        public RepeatedField<uint> RepeatedUint32 { get; } = new RepeatedField<uint>();
        public RepeatedField<ulong> RepeatedUint64 { get; } = new RepeatedField<ulong>();
        public RepeatedField<int> RepeatedSint32 { get; } = new RepeatedField<int>();
        public RepeatedField<long> RepeatedSint64 { get; } = new RepeatedField<long>();
        public RepeatedField<uint> RepeatedFixed32 { get; } = new RepeatedField<uint>();
        public RepeatedField<ulong> RepeatedFixed64 { get; } = new RepeatedField<ulong>();
        public RepeatedField<int> RepeatedSfixed32 { get; } = new RepeatedField<int>();
        public RepeatedField<long> RepeatedSfixed64 { get; } = new RepeatedField<long>();
        public RepeatedField<bool> RepeatedBool { get; } = new RepeatedField<bool>();
        public RepeatedField<string> RepeatedString { get; } = new RepeatedField<string>();
        public RepeatedField<ByteString> RepeatedBytes { get; } = new RepeatedField<ByteString>();
        public RepeatedField<AnotherMessage> RepeatedMessage { get; } = new RepeatedField<AnotherMessage>();
        public RepeatedField<Types.NestedMessage> RepeatedNestedMessage { get; } = new RepeatedField<Types.NestedMessage>();
        public RepeatedField<Enum> RepeatedEnum { get; } = new RepeatedField<Enum>();
        public RepeatedField<Types.NestedEnum> RepeatedNestedEnum { get; } = new RepeatedField<Types.NestedEnum>();
        public string SingleResourceName { get; set; }
        public RepeatedField<string> RepeatedResourceName { get; } = new RepeatedField<string>();
        public string SingleWildcardResource { get; set; }
        public RepeatedField<string> RepeatedWildcardResource { get; } = new RepeatedField<string>();
    }

    public class Response : ProtoMsgFake<Response> { }

    public class LroRequest : ProtoMsgFake<LroRequest> { }
    public class LroResponse : ProtoMsgFake<LroResponse> { }
    public class LroMetadata : ProtoMsgFake<LroMetadata> { }
}
