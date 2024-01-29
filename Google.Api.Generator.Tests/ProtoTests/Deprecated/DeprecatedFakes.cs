// Copyright 2020 Google Inc. All Rights Reserved.
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

using Google.Protobuf.Reflection;
using Grpc.Core;
using System;

// Disable Obsolete warnings; this is testing that obsolete elements have suitable `#pragma warning`s generated.
#pragma warning disable CS0612

namespace Testing.Deprecated
{
    public class Deprecated
    {
        public static ServiceDescriptor Descriptor => null;

        public class DeprecatedClient
        {
            public DeprecatedClient() { } // Required for unit-tests.
            public DeprecatedClient(CallInvoker callInvoker) { }
            public virtual Response DeprecatedFieldMethod(DeprecatedFieldRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> DeprecatedFieldMethodAsync(DeprecatedFieldRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response DeprecatedMessageMethod(DeprecatedMessageRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> DeprecatedMessageMethodAsync(DeprecatedMessageRequest request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response DeprecatedMethod(Request request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> DeprecatedMethodAsync(Request request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual DeprecatedMessageResponse DeprecatedResponseMethod(Request request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<DeprecatedMessageResponse> DeprecatedResponseMethodAsync(Request request, CallOptions callOptions) => throw new NotImplementedException();
        }
    }

    public class DeprecatedService
    {
        public static ServiceDescriptor Descriptor => null;

        public class DeprecatedServiceClient
        {
            public DeprecatedServiceClient() { } // Required for unit-tests.
            public DeprecatedServiceClient(CallInvoker callInvoker) { }
            public virtual Response DeprecatedMethod(Request request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> DeprecatedMethodAsync(Request request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual Response NonDeprecatedMethod(Request request, CallOptions callOptions) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> NonDeprecatedMethodAsync(Request request, CallOptions callOptions) => throw new NotImplementedException();
        }
    }

    public class DeprecatedFieldRequest : ProtoMsgFake<DeprecatedFieldRequest>
    {
        [Obsolete]
        public string DeprecatedField1 { get; set; }
        [Obsolete]
        public string DeprecatedField2 { get; set; }
    }

    [Obsolete]
    public class DeprecatedMessageRequest : ProtoMsgFake<DeprecatedMessageRequest> { }

    public class Request : ProtoMsgFake<Request> { }

    [Obsolete]
    public class DeprecatedMessageResponse : ProtoMsgFake<DeprecatedMessageResponse> { }

    public class Response : ProtoMsgFake<Response> { }
}
