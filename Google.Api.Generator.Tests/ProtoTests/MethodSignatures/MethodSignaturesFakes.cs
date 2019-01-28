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

using Google.Protobuf;
using Google.Protobuf.Collections;

namespace Testing.Methodsignatures
{
    public class SimpleRequest : ProtoMsgFake<SimpleRequest>
    {
        public int ANumber { get; set; }
        public string AString { get; set; }
    }

    public class PrimitiveRequest : ProtoMsgFake<PrimitiveRequest>
    {
        public int Optional { get; set; }
        public int Required { get; set; }
        public RepeatedField<int> RepeatedOptional { get; }
        public RepeatedField<int> RepeatedRequired { get; }
    }

    public class StringRequest : ProtoMsgFake<StringRequest>
    {
        public string Optional { get; set; }
        public string Required { get; set; }
        public RepeatedField<string> RepeatedOptional { get; }
        public RepeatedField<string> RepeatedRequired { get; }
    }

    public class BytesRequest : ProtoMsgFake<BytesRequest>
    {
        public ByteString Optional { get; set; }
        public ByteString Required { get; set; }
        public RepeatedField<ByteString> RepeatedOptional { get; }
        public RepeatedField<ByteString> RepeatedRequired { get; }
    }

    public class MessageRequest : ProtoMsgFake<MessageRequest>
    {
        public class Types
        {
            public class Msg { }
        }
        public Types.Msg Optional { get; set; }
        public Types.Msg Required { get; set; }
        public RepeatedField<Types.Msg> RepeatedOptional { get; }
        public RepeatedField<Types.Msg> RepeatedRequired { get; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
