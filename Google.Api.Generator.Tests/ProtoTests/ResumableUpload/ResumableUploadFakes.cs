// Copyright 2026 Google LLC
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

using Google.Api.Generator.Testing;
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;

namespace Google.Ads.GoogleAds.V23.Services
{
    public abstract class ProtoMsgFake<T> : Google.Protobuf.IMessage<T> where T : ProtoMsgFake<T>
    {
        public MessageDescriptor Descriptor => throw new NotImplementedException();
        public int CalculateSize() => throw new NotImplementedException();
        public T Clone() => throw new NotImplementedException();
        public bool Equals(T other) => throw new NotImplementedException();
        public void MergeFrom(T message) => throw new NotImplementedException();
        public void MergeFrom(Google.Protobuf.CodedInputStream input) => throw new NotImplementedException();
        public void WriteTo(Google.Protobuf.CodedOutputStream output) => throw new NotImplementedException();
    }

    // Fake gRPC client, to allow `YouTubeVideoUploadServiceClient.g.cs` to compile.
    public static partial class YouTubeVideoUploadService
    {
        public static ServiceDescriptor Descriptor => throw new NotImplementedException();

        public partial class YouTubeVideoUploadServiceClient
        {
            public YouTubeVideoUploadServiceClient(CallInvoker callInvoker) { }
            private CallInvoker CallInvoker => throw new NotImplementedException();
        }
    }

    public static class ResumableUploadReflection
    {
        public static FileDescriptor Descriptor => throw new NotImplementedException();
    }

    public class CreateYouTubeVideoUploadRequest : ProtoMsgFake<CreateYouTubeVideoUploadRequest> { }
    public class CreateYouTubeVideoUploadResponse : ProtoMsgFake<CreateYouTubeVideoUploadResponse> { }
}
