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
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;

namespace Testing
{
    public class Basic
    {
        // Fake gRPC client, to allow `BasicClient.cs` to compile.
        public class BasicClient
        {
            public BasicClient(CallInvoker callInvoker) { }
            public AsyncUnaryCall<Response> IdempotentMethodAsync(Request request, CallOptions options) =>
                throw new NotImplementedException();
            public Response IdempotentMethod(Request request, CallOptions options) =>
                throw new NotImplementedException();
            public AsyncUnaryCall<Response> NonIdempotentMethodAsync(Request request, CallOptions options) =>
                throw new NotImplementedException();
            public Response NonIdempotentMethod(Request request, CallOptions options) =>
                throw new NotImplementedException();
        }
    }

    public class Request : IMessage<Request>
    {
        public MessageDescriptor Descriptor => throw new NotImplementedException();
        public int CalculateSize() => throw new NotImplementedException();
        public Request Clone() => throw new NotImplementedException();
        public bool Equals(Request other) => throw new NotImplementedException();
        public void MergeFrom(Request message) => throw new NotImplementedException();
        public void MergeFrom(CodedInputStream input) => throw new NotImplementedException();
        public void WriteTo(CodedOutputStream output) => throw new NotImplementedException();
    }

    public class Response : IMessage<Response>
    {
        public MessageDescriptor Descriptor => throw new NotImplementedException();
        public int CalculateSize() => throw new NotImplementedException();
        public Response Clone() => throw new NotImplementedException();
        public bool Equals(Response other) => throw new NotImplementedException();
        public void MergeFrom(Response message) => throw new NotImplementedException();
        public void MergeFrom(CodedInputStream input) => throw new NotImplementedException();
        public void WriteTo(CodedOutputStream output) => throw new NotImplementedException();
    }
}
