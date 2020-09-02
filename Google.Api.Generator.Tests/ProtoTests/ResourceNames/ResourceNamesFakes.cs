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

using Google.Protobuf.Collections;
using Grpc.Core;
using System;

namespace Testing.ResourceNames
{
    public class ResourceNames
    {
        // Fake gRPC client, to allow generated tests to compile.
        public class ResourceNamesClient
        {
            public ResourceNamesClient() { }
            public ResourceNamesClient(CallInvoker callInvoker) { }
            public virtual Response SinglePatternMethod(SinglePattern request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> SinglePatternMethodAsync(SinglePattern request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response WildcardOnlyPatternMethod(WildcardOnlyPattern request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> WildcardOnlyPatternMethodAsync(WildcardOnlyPattern request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response WildcardMultiPatternMethod(WildcardMultiPattern request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> WildcardMultiPatternMethodAsync(WildcardMultiPattern request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultiple request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultiple request, CallOptions callOptions) => throw new NotImplementedException();
        }
    }

    public partial class SinglePattern : ProtoMsgFake<SinglePattern>
    {
        public string RealName { get; set; }
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; } = new RepeatedField<string>();
        public string ValueRef { get; set; }
        public RepeatedField<string> RepeatedValueRef { get; } = new RepeatedField<string>();
    }

    public partial class WildcardOnlyPattern : ProtoMsgFake<WildcardOnlyPattern>
    {
        public string Name { get; set; }
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; } = new RepeatedField<string>();
        public string RefSugar { get; set; }
        public RepeatedField<string> RepeatedRefSugar { get; } = new RepeatedField<string>();
    }

    public partial class WildcardMultiPattern : ProtoMsgFake<WildcardMultiPattern>
    {
        public string Name { get; set; }
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; } = new RepeatedField<string>();
    }

    public partial class WildcardMultiPatternMultiple : ProtoMsgFake<WildcardMultiPatternMultiple>
    {
        public string Name { get; set; }
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; } = new RepeatedField<string>();
    }

    public partial class Response : ProtoMsgFake<Response> { }
}
