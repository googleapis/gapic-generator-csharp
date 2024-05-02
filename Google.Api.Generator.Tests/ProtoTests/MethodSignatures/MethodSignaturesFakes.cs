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
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;

namespace Testing.MethodSignatures
{
    // Fake gRPC client.
    public static partial class MethodSignatures
    {
        public static ServiceDescriptor Descriptor => null;

        public partial class MethodSignaturesClient
        {
            public MethodSignaturesClient() { }
            public MethodSignaturesClient(CallInvoker callInvoker) => throw new NotImplementedException();

            public virtual AsyncUnaryCall<Response> SimpleMethodAsync(SimpleRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response SimpleMethod(SimpleRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> PrimitiveArgsAsync(PrimitiveRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response PrimitiveArgs(PrimitiveRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> StringArgsAsync(StringRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response StringArgs(StringRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> BytesArgsAsync(BytesRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response BytesArgs(BytesRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> MessageArgsAsync(MessageRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response MessageArgs(MessageRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> MapArgsAsync(MapRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response MapArgs(MapRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> EnumArgsAsync(EnumRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response EnumArgs(EnumRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> NestedArgsAsync(NestedRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response NestedArgs(NestedRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> WktArgsAsync(WktRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response WktArgs(WktRequest request, CallOptions callOptions) => throw new NotImplementedException();
        }
    }

    public class SimpleRequest : ProtoMsgFake<SimpleRequest>
    {
        public int ANumber { get; set; }
        public string AString { get; set; }
        public MapField<string, string> AMap { get; } = new MapField<string, string>();
    }

    public class PrimitiveRequest : ProtoMsgFake<PrimitiveRequest>
    {
        public int Optional { get; set; }
        public int Required { get; set; }
        public RepeatedField<int> RepeatedOptional { get; } = new RepeatedField<int>();
        public RepeatedField<int> RepeatedRequired { get; } = new RepeatedField<int>();
    }

    public class StringRequest : ProtoMsgFake<StringRequest>
    {
        public string Optional { get; set; }
        public string Required { get; set; }
        public RepeatedField<string> RepeatedOptional { get; } = new RepeatedField<string>();
        public RepeatedField<string> RepeatedRequired { get; } = new RepeatedField<string>();
    }

    public class BytesRequest : ProtoMsgFake<BytesRequest>
    {
        public ByteString Optional { get; set; }
        public ByteString Required { get; set; }
        public RepeatedField<ByteString> RepeatedOptional { get; } = new RepeatedField<ByteString>();
        public RepeatedField<ByteString> RepeatedRequired { get; } = new RepeatedField<ByteString>();
    }

    public class MessageRequest : ProtoMsgFake<MessageRequest>
    {
        public static class Types
        {
            public class Msg { }
        }
        public Types.Msg Optional { get; set; }
        public Types.Msg Required { get; set; }
        public RepeatedField<Types.Msg> RepeatedOptional { get; } = new RepeatedField<Types.Msg>();
        public RepeatedField<Types.Msg> RepeatedRequired { get; } = new RepeatedField<Types.Msg>();
    }

    public class MapRequest : ProtoMsgFake<MapRequest>
    {
        public static class Types
        {
            public class Msg : ProtoMsgFake<Msg> { }
        }
        public MapField<string, string> Optional { get; } = new MapField<string, string>();
        public MapField<int, Types.Msg> Required { get; } = new MapField<int, Types.Msg>();
    }

    public enum TopLevelEnum
    {
        Default = 0,
        NotDefault = 1,
    }

    public class EnumRequest : ProtoMsgFake<EnumRequest>
    {
        public static class Types
        {
            public enum Enum
            {
                Default = 0,
            }
        }
        public Types.Enum Optional { get; set; }
        public Types.Enum Required { get; set; }
        public RepeatedField<Types.Enum> RepeatedOptional { get; } = new RepeatedField<Types.Enum>();
        public RepeatedField<Types.Enum> RepeatedRequired { get; } = new RepeatedField<Types.Enum>();
        public TopLevelEnum TopLevelOptional { get; set; }
        public TopLevelEnum TopLevelRequired { get; set; }
        public RepeatedField<TopLevelEnum> RepeatedTopLevelOptional { get; } = new RepeatedField<TopLevelEnum>();
        public RepeatedField<TopLevelEnum> RepeatedTopLevelRequired { get; } = new RepeatedField<TopLevelEnum>();
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
        public RepeatedField<int?> RepeatedOptionalInt32 { get; } = new RepeatedField<int?>();
        public RepeatedField<int?> RepeatedRequiredInt32 { get; } = new RepeatedField<int?>();
        public string OptionalString { get; set; }
        public string RequiredString { get; set; }
        public RepeatedField<string> RepeatedOptionalString { get; } = new RepeatedField<string>();
        public RepeatedField<string> RepeatedRequiredString { get; } = new RepeatedField<string>();
    }

    public class Response : ProtoMsgFake<Response> { }
}
