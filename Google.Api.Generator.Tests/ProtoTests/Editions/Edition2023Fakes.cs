// Copyright 2024 Google Inc. All Rights Reserved.
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

namespace Testing.Editions;

public partial class Edition2023Request : ProtoMsgFake<Edition2023Request>
{
    public string Name { get; set; }
    public int Number { get; set; }
    public int I { get; set; }
}

public partial class Edition2023Response : ProtoMsgFake<Edition2023Response> { }

public class Edition2023
{
    public static ServiceDescriptor Descriptor => null;

    // Fake gRPC client
    public class Edition2023Client
    {
        public Edition2023Client() { }
        public Edition2023Client(CallInvoker callInvoker) { }
        public virtual AsyncUnaryCall<Edition2023Response> Method1Async(Edition2023Request request, CallOptions options) => throw new NotImplementedException();
        public virtual Edition2023Response Method1(Edition2023Request request, CallOptions options) => throw new NotImplementedException();
    }
}