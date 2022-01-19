﻿// Copyright 2019 Google Inc. All Rights Reserved.
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

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;

// Disable warning: Missing XML comment on public members.
// Required to successfully build this generated test project.
#pragma warning disable 1591

namespace Testing.Mixins
{
    // (Re-)define this here; required to successfully build this generated test project.
    public abstract class ProtoMsgFake<T> : Google.Protobuf.IMessage<T> where T : ProtoMsgFake<T>
    {
        public Google.Protobuf.Reflection.MessageDescriptor Descriptor => throw new NotImplementedException();
        public int CalculateSize() => throw new NotImplementedException();
        public T Clone() => throw new NotImplementedException();
        public bool Equals(T other) => throw new NotImplementedException();
        public void MergeFrom(T message) => throw new NotImplementedException();
        public void MergeFrom(Google.Protobuf.CodedInputStream input) => throw new NotImplementedException();
        public void WriteTo(Google.Protobuf.CodedOutputStream output) => throw new NotImplementedException();
    }

    public partial class MixinService
    {
        public partial class MixinServiceClient
        {
            public MixinServiceClient() { }
            public MixinServiceClient(CallInvoker callInvoker) { }
            private CallInvoker CallInvoker => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> MethodAsync(Request request, CallOptions options) => throw new NotImplementedException();
            public virtual Response Method(Request request, CallOptions options) => throw new NotImplementedException();            
        }
    }

    public class Request : ProtoMsgFake<Request> { }
    public class Response : ProtoMsgFake<Response> { }
}
