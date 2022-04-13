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

using Google.Api.Gax.Grpc;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Testing.ResourceNameSeparator
{
    // gRPC client
    public static class ResourceNameSeparator
    {
        public class ResourceNameSeparatorClient
        {
            public virtual Response Method1(Request request, CallOptions options) => throw new NotImplementedException();
            public virtual AsyncUnaryCall<Response> Method1Async(Request request, CallOptions options) => throw new NotImplementedException();
        }
    }

    // GAPIC client
    public class ResourceNameSeparatorClient
    {
        public static ResourceNameSeparatorClient Create() => throw new NotImplementedException();
        public static Task<ResourceNameSeparatorClient> CreateAsync() => throw new NotImplementedException();

        public virtual Response Method1(Request request) => throw new NotImplementedException();
        public virtual Task<Response> Method1Async(Request request, CallSettings settings = null) => throw new NotImplementedException();
        public virtual Task<Response> Method1Async(Request request, CancellationToken cancellationToken) => throw new NotImplementedException();
        public virtual Response Method1(string name, string @ref) => throw new NotImplementedException();
        public virtual Task<Response> Method1Async(string name, string @ref, CallSettings settings = null) => throw new NotImplementedException();
        public virtual Task<Response> Method1Async(string name, string @ref, CancellationToken cancellationToken) => throw new NotImplementedException();
        public virtual Response Method1(RequestName name, RequestName @ref) => throw new NotImplementedException();
        public virtual Task<Response> Method1Async(RequestName name, RequestName @ref, CallSettings settings = null) => throw new NotImplementedException();
        public virtual Task<Response> Method1Async(RequestName name, RequestName @ref, CancellationToken cancellationToken) => throw new NotImplementedException();
    }

    public class ResourceNameSeparatorClientImpl : ResourceNameSeparatorClient
    {
        public ResourceNameSeparatorClientImpl(ResourceNameSeparator.ResourceNameSeparatorClient client, object settings, ILogger logger) => _client = client;
        private ResourceNameSeparator.ResourceNameSeparatorClient _client;
        public override Response Method1(Request request) => _client.Method1(request, default);
        public override Task<Response> Method1Async(Request request, CallSettings settings = null) => _client.Method1Async(request, default).ResponseAsync;
        public override Task<Response> Method1Async(Request request, CancellationToken cancellationToken) => _client.Method1Async(request, default).ResponseAsync;
        public override Response Method1(string name, string @ref) => _client.Method1(new Request { Name = name, Ref = @ref }, default);
        public override Task<Response> Method1Async(string name, string @ref, CallSettings settings = null) =>
            _client.Method1Async(new Request { Name = name, Ref = @ref }, default).ResponseAsync;
        public override Task<Response> Method1Async(string name, string @ref, CancellationToken cancellationToken) =>
            _client.Method1Async(new Request { Name = name, Ref = @ref }, default).ResponseAsync;
        public override Response Method1(RequestName name, RequestName @ref) => _client.Method1(new Request { RequestName = name, RefAsRequestName = @ref }, default);
        public override Task<Response> Method1Async(RequestName name, RequestName @ref, CallSettings settings = null) =>
            _client.Method1Async(new Request { RequestName = name, RefAsRequestName = @ref }, default).ResponseAsync;
        public override Task<Response> Method1Async(RequestName name, RequestName @ref, CancellationToken cancellationToken) =>
            _client.Method1Async(new Request { RequestName = name, RefAsRequestName = @ref }, default).ResponseAsync;
    }

    public partial class Request : ProtoMsgFake<Request>
    {
        public string Name { get; set; }
        public string Ref { get; set; }
    }

    public partial class Response : ProtoMsgFake<Response> { }
}
