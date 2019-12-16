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

namespace Testing.MethodSignatures
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
        public static class Types
        {
            public class Msg { }
        }
        public Types.Msg Optional { get; set; }
        public Types.Msg Required { get; set; }
        public RepeatedField<Types.Msg> RepeatedOptional { get; }
        public RepeatedField<Types.Msg> RepeatedRequired { get; }
    }

    public class MapRequest : ProtoMsgFake<MessageRequest>
    {
        public static class Types
        {
            public class Msg : ProtoMsgFake<Msg> { }
        }
        public MapField<string, string> Optional { get; }
        public MapField<int, Types.Msg> Required { get; }
    }

    public enum TopLevelEnum
    {
        DEFAULT = 0,
        NOT_DEFAULT = 1,
    }

    public class EnumRequest : ProtoMsgFake<EnumRequest>
    {
        public static class Types
        {
            public enum Enum
            {
                DEFAULT = 0,
            }
        }
        public Types.Enum Optional { get; set; }
        public Types.Enum Required { get; set; }
        public RepeatedField<Types.Enum> RepeatedOptional { get; }
        public RepeatedField<Types.Enum> RepeatedRequired { get; }
        public TopLevelEnum TopLevelOptional { get; set; }
        public TopLevelEnum TopLevelRequired { get; set; }
        public RepeatedField<TopLevelEnum> RepeatedTopLevelOptional { get; }
        public RepeatedField<TopLevelEnum> RepeatedTopLevelRequired { get; }
    }

    public class NestedOuter : ProtoMsgFake<NestedOuter>
    {
        public bool ABool { get; set; }
    }
    public class NestedRequest : ProtoMsgFake<NestedRequest>
    {
        public static class Types
        {
            public class Nest1 : ProtoMsgFake<Nest1>
            {
                public static class Types
                {
                    public class Nest2 : ProtoMsgFake<Nest2>
                    {
                        public int ANumber { get; set; }
                        public int AnotherNumber { get; set; }
                    }
                }
                public string AString { get; set; }
                public Types.Nest2 Nest2 { get; set; }
                public NestedOuter NestOuter { get; set; }
            }
        }
        public Types.Nest1 Nest1 { get; set; }
        public string TopLevelString { get; set; }
    }

    public class WktRequest : ProtoMsgFake<WktRequest>
    {
        public int? OptionalInt32 { get; set; }
        public int? RequiredInt32 { get; set; }
        public RepeatedField<int?> RepeatedOptionalInt32 { get; }
        public RepeatedField<int?> RepeatedRequiredInt32 { get; }
        public string OptionalString { get; set; }
        public string RequiredString { get; set; }
        public RepeatedField<string> RepeatedOptionalString { get; }
        public RepeatedField<string> RepeatedRequiredString { get; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
