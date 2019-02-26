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

using Grpc.Core;
using System;

namespace Testing.RoutingHeaders
{
    public class RoutingHeaders
    {
        public class RoutingHeadersClient
        {
            public Response NoUrlMethod(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> NoUrlMethodAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response GetMethod(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> GetMethodAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response PostMethod(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> PostMethodAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response PutMethod(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> PutMethodAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response PatchMethod(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> PatchMethodAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response DeleteMethod(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> DeleteMethodAsync(SimpleRequest request, CallOptions options) => throw new NotImplementedException();
            public Response NestedMultiMethod(NestedRequest request, CallOptions options) => throw new NotImplementedException();
            public AsyncUnaryCall<Response> NestedMultiMethodAsync(NestedRequest request, CallOptions options) => throw new NotImplementedException();
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
                public Types.Inner2 Nest2 { get; set; }
            }
        }

        public Types.Inner1 Nest1 { get; set; }
        public string Name { get; set; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
