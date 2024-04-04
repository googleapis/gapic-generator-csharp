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
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;

// Disable warning: Missing XML comment on public members.
// Required to successfully build this generated test project.
#pragma warning disable 1591

namespace Testing.Lro;

// gRPC fakes
public static partial class Lro
{
    public static ServiceDescriptor Descriptor => null;
    public partial class LroClient
    {
        private CallInvoker CallInvoker => throw new NotImplementedException();

        public LroClient(CallInvoker callInvoker) { }
        public virtual AsyncUnaryCall<Operation> SignatureMethodAsync(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual Operation SignatureMethod(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual AsyncUnaryCall<Operation> ResourcedMethodAsync(ResourceRequest request, CallOptions options) => throw new NotImplementedException();
        public virtual Operation ResourcedMethod(ResourceRequest request, CallOptions options) => throw new NotImplementedException();
    }
}

// Protobuf fakes
public class Request : ProtoMsgFake<Request>
{
    public string Name { get; set; }
}

public partial class ResourceRequest : ProtoMsgFake<ResourceRequest>
{
    public string Name { get; set; }
}

public class LroResponse : ProtoMsgFake<LroResponse> {
    public class Types
    {
        public class Nested : ProtoMsgFake<Nested> { }
    }
}

public class LroMetadata : ProtoMsgFake<LroMetadata>
{
    public class Types
    {
        public class Nested : ProtoMsgFake<Nested> { }
    }
}
