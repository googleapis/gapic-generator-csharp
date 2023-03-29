// Copyright 2023 Google Inc. All Rights Reserved.
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

using Google.Api.Gax.Grpc;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

// Disable warning: Missing XML comment on public members.
// Required to successfully build this generated test project.
#pragma warning disable 1591

namespace Testing.PublishingSettings;

public static class PublishingSettingsReflection
{
    public static FileDescriptor Descriptor => null;
}

public class OriginalServiceName
{
    public static ServiceDescriptor Descriptor => null;

    // Fake gRPC client
    public class OriginalServiceNameClient
    {
        public OriginalServiceNameClient() { }
        public OriginalServiceNameClient(CallInvoker callInvoker) { }
        public virtual AsyncUnaryCall<Response> AMethodAsync(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual Response AMethod(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual AsyncUnaryCall<Empty> VoidMethodAsync(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual Empty VoidMethod(Request request, CallOptions options) => throw new NotImplementedException();
    }
}

public class ServiceWithHandwrittenSignatures
{
    public static ServiceDescriptor Descriptor => null;

    // Fake gRPC client
    public class ServiceWithHandwrittenSignaturesClient
    {
        public ServiceWithHandwrittenSignaturesClient() { }
        public ServiceWithHandwrittenSignaturesClient(CallInvoker callInvoker) { }
        public virtual AsyncUnaryCall<Response> AMethodAsync(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual Response AMethod(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual AsyncUnaryCall<Empty> VoidMethodAsync(Request request, CallOptions options) => throw new NotImplementedException();
        public virtual Empty VoidMethod(Request request, CallOptions options) => throw new NotImplementedException();
    }
}

public class ServiceWithResources
{
    public static ServiceDescriptor Descriptor => null;

    // Fake gRPC client
    public class ServiceWithResourcesClient
    {
        public ServiceWithResourcesClient() { }
        public ServiceWithResourcesClient(CallInvoker callInvoker) { }
        public virtual AsyncUnaryCall<Resource> AMethodAsync(ResourceRequest request, CallOptions options) => throw new NotImplementedException();
        public virtual Resource AMethod(ResourceRequest request, CallOptions options) => throw new NotImplementedException();
    }
}

public partial class ServiceWithHandwrittenSignaturesClient
{
    // This is the hand-written method we're deliberately not generating
    public Response AMethod(string string1) => throw new NotImplementedException();
    public Task<Response> AMethodAsync(string string1, CallSettings callSettings = null) => throw new NotImplementedException();
    public Task<Response> AMethodAsync(string string1, CancellationToken cancellationToken) => throw new NotImplementedException();
}

public class Request : ProtoMsgFake<Request>
{
    public string String1 { get; set; }
    public string String2 { get; set; }
}

public class Response : ProtoMsgFake<Response> { }

public partial class ResourceRequest : ProtoMsgFake<ResourceRequest>
{
    public string Parent { get; set; }
    public string Database { get; set; }
}

public partial class Resource : ProtoMsgFake<Resource>
{
    public string Name { get; set; }
}
