// Copyright 2022 Google Inc. All Rights Reserved.
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

using Grpc.Core;
using System;


namespace Testing.RoutingHeadersExplicit
{
    public class RoutingHeadersExplicit
    {
        public class RoutingHeadersExplicitClient
        {
            public Response NoUrlMethod(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> NoUrlMethodAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response PlainNoTemplate(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> PlainNoTemplateAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response PlainNoExtraction(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> PlainNoExtractionAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response PlainFullField(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> PlainFullFieldAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response PlainExtract(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> PlainExtractAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response Nested(NestedRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> NestedAsync(NestedRequest request, CallOptions options) => throw new NotImplementedException();
            public Response Complex(NestedRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> ComplexAsync(NestedRequest request, CallOptions options) => throw new NotImplementedException();

        }
    }

    public class SimpleRequest : ProtoMsgFake<SimpleRequest>
    {
        public string Name { get; set; }
    }

    public class NestedRequest : ProtoMsgFake<NestedRequest>
    {
        public static class Types
        {
            public class Inner1
            {
                public static class Types
                {
                    public class Inner2
                    {
                        public string Name { get; set; }
                    }
                }
                public string Name { get; set; }
                public Types.Inner2 Nest2 { get; set; }
            }
        }

        public Types.Inner1 Nest1 { get; set; }
        public string TableName { get; set; }
        public string AppProfileId { get; set; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
