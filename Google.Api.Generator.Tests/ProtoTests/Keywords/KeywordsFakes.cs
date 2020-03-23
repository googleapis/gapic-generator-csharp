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

namespace Testing.Keywords
{
    // gRPC fakes
    public class Keywords
    {
        public class KeywordsClient
        {
            public KeywordsClient() { }
            public KeywordsClient(CallInvoker callInvoker) { }
            public virtual AsyncUnaryCall<Response> Method1Async(Request request, CallOptions options) => throw new NotImplementedException();
            public virtual Response Method1(Request request, CallOptions options) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> Method2Async(Resource request, CallOptions options) => throw new NotImplementedException();
            public virtual Response Method2(Resource request, CallOptions options) => throw new NotImplementedException();
        }
    }

    // proto msg fakes
    public enum Enum
    {
        Void = 0,
        For = 1,
        Foreach = 2,
    }

    public partial class Resource : ProtoMsgFake<Resource>
    {
        public string While { get; set; }
        public Enum Enum { get; set; }
    }

    public partial class Request : ProtoMsgFake<Request>
    {
        public string Event { get; set; }
        public int Switch { get; set; }
        public Enum Void { get; set; }
        public string Request_ { get; set; }
    }

    public partial class Response : ProtoMsgFake<Response> { }
}
