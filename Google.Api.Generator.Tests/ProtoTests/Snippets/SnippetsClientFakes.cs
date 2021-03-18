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

using Google.Api.Gax;
using Google.Api.Gax.Grpc;
using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Testing.Snippets
{
    public class SnippetsClient
    {
        public static SnippetsClient Create() => throw new NotImplementedException();
        public static Task<SnippetsClient> CreateAsync() => throw new NotImplementedException();

        public Response MethodDefaultValues(DefaultValuesRequest request) => throw new NotImplementedException();
        public Task<Response> MethodDefaultValuesAsync(DefaultValuesRequest request) => throw new NotImplementedException();
        public Response MethodDefaultValues(IEnumerable<double> repeatedDouble,
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage,
            IEnumerable<string> repeatedResourceName) => throw new NotImplementedException();
        public Task<Response> MethodDefaultValuesAsync(IEnumerable<double> repeatedDouble,
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage,
            IEnumerable<string> repeatedResourceName) => throw new NotImplementedException();
        public Response MethodDefaultValues(IEnumerable<double> repeatedDouble,
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage,
            IEnumerable<AResourceName> repeatedResourceName) => throw new NotImplementedException();
        public Task<Response> MethodDefaultValuesAsync(IEnumerable<double> repeatedDouble,
            IEnumerable<DefaultValuesRequest.Types.NestedMessage> repeatedNestedMessage,
            IEnumerable<AResourceName> repeatedResourceName) => throw new NotImplementedException();

        public Response MethodOneSignature(SignatureRequest request) => throw new NotImplementedException();
        public Task<Response> MethodOneSignatureAsync(SignatureRequest request) => throw new NotImplementedException();
        public Response MethodOneSignature(string aString, int anInt, bool aBool) => throw new NotImplementedException();
        public Task<Response> MethodOneSignatureAsync(string aString, int anInt, bool aBool) => throw new NotImplementedException();

        public Response MethodThreeSignatures(SignatureRequest request) => throw new NotImplementedException();
        public Task<Response> MethodThreeSignaturesAsync(SignatureRequest request) => throw new NotImplementedException();
        public Response MethodThreeSignatures(string aString, int anInt, bool aBool) => throw new NotImplementedException();
        public Task<Response> MethodThreeSignaturesAsync(string aString, int anInt, bool aBool) => throw new NotImplementedException();
        public Response MethodThreeSignatures(string aString, bool aBool) => throw new NotImplementedException();
        public Task<Response> MethodThreeSignaturesAsync(string aString, bool aBool) => throw new NotImplementedException();
        public Response MethodThreeSignatures() => throw new NotImplementedException();
        public Task<Response> MethodThreeSignaturesAsync() => throw new NotImplementedException();

        public Response MethodMapSignature(SignatureRequest request) => throw new NotImplementedException();
        public Task<Response> MethodMapSignatureAsync(SignatureRequest request) => throw new NotImplementedException();
        public Response MethodMapSignature(IDictionary<int, string> mapIntString) => throw new NotImplementedException();
        public Task<Response> MethodMapSignatureAsync(IDictionary<int, string> mapIntString) => throw new NotImplementedException();

        public Response MethodResourceSignature(ResourceSignatureRequest request) => throw new NotImplementedException();
        public Task<Response> MethodResourceSignatureAsync(ResourceSignatureRequest request) => throw new NotImplementedException();
        public Response MethodResourceSignature(string firstName, string secondName, string thirdName) => throw new NotImplementedException();
        public Task<Response> MethodResourceSignatureAsync(string firstName, string secondName, string thirdName) => throw new NotImplementedException();
        public Response MethodResourceSignature(SimpleResourceName firstName, SimpleResourceName secondName, SimpleResourceName thirdName) => throw new NotImplementedException();
        public Task<Response> MethodResourceSignatureAsync(SimpleResourceName firstName, SimpleResourceName secondName, SimpleResourceName thirdName) => throw new NotImplementedException();
        public Response MethodResourceSignature(string firstName) => throw new NotImplementedException();
        public Task<Response> MethodResourceSignatureAsync(string firstName) => throw new NotImplementedException();
        public Response MethodResourceSignature(SimpleResourceName firstName) => throw new NotImplementedException();
        public Task<Response> MethodResourceSignatureAsync(SimpleResourceName firstName) => throw new NotImplementedException();

        public Response MethodRepeatedResourceSignature(RepeatedResourceSignatureRequest request) => throw new NotImplementedException();
        public Task<Response> MethodRepeatedResourceSignatureAsync(RepeatedResourceSignatureRequest request) => throw new NotImplementedException();
        public Response MethodRepeatedResourceSignature(IEnumerable<string> names) => throw new NotImplementedException();
        public Response MethodRepeatedResourceSignature(IEnumerable<SimpleResourceName> names) => throw new NotImplementedException();
        public Task<Response> MethodRepeatedResourceSignatureAsync(IEnumerable<string> names) => throw new NotImplementedException();
        public Task<Response> MethodRepeatedResourceSignatureAsync(IEnumerable<SimpleResourceName> names) => throw new NotImplementedException();

        public Operation<LroResponse, LroMetadata> MethodLroSignatures(SignatureRequest request) => throw new NotImplementedException();
        public Task<Operation<LroResponse, LroMetadata>> MethodLroSignaturesAsync(SignatureRequest request) => throw new NotImplementedException();
        public Operation<LroResponse, LroMetadata> MethodLroSignatures(string aString, int anInt, bool aBool) => throw new NotImplementedException();
        public Task<Operation<LroResponse, LroMetadata>> MethodLroSignaturesAsync(string aString, int anInt, bool aBool) => throw new NotImplementedException();
        public Operation<LroResponse, LroMetadata> PollOnceMethodLroSignatures(string operationName) => throw new NotImplementedException();
        public Task<Operation<LroResponse, LroMetadata>> PollOnceMethodLroSignaturesAsync(string operationName) => throw new NotImplementedException();

        public Operation<LroResponse, LroMetadata> MethodLroResourceSignature(ResourceSignatureRequest request) => throw new NotImplementedException();
        public Task<Operation<LroResponse, LroMetadata>> MethodLroResourceSignatureAsync(ResourceSignatureRequest request) => throw new NotImplementedException();
        public Operation<LroResponse, LroMetadata> MethodLroResourceSignature(string firstName, string secondName, string thirdName) => throw new NotImplementedException();
        public Task<Operation<LroResponse, LroMetadata>> MethodLroResourceSignatureAsync(string firstName, string secondName, string thirdName) => throw new NotImplementedException();
        public Operation<LroResponse, LroMetadata> MethodLroResourceSignature(SimpleResourceName firstName, SimpleResourceName secondName, SimpleResourceName thirdName) => throw new NotImplementedException();
        public Task<Operation<LroResponse, LroMetadata>> MethodLroResourceSignatureAsync(SimpleResourceName firstName, SimpleResourceName secondName, SimpleResourceName thirdName) => throw new NotImplementedException();
        public Operation<LroResponse, LroMetadata> PollOnceMethodLroResourceSignature(string operationName) => throw new NotImplementedException();
        public Task<Operation<LroResponse, LroMetadata>> PollOnceMethodLroResourceSignatureAsync(string operationName) => throw new NotImplementedException();

        public class MethodServerStreamingStream : ServerStreamingBase<Response> { }
        public MethodServerStreamingStream MethodServerStreaming(SignatureRequest request) => throw new NotImplementedException();
        public MethodServerStreamingStream MethodServerStreaming(string aString, bool aBool) => throw new NotImplementedException();
        public MethodServerStreamingStream MethodServerStreaming() => throw new NotImplementedException();

        public class MethodServerStreamingResourcesStream : ServerStreamingBase<Response> { }
        public MethodServerStreamingResourcesStream MethodServerStreamingResources(ResourceSignatureRequest request) => throw new NotImplementedException();
        public MethodServerStreamingResourcesStream MethodServerStreamingResources(string firstName, string secondName, string thirdName) => throw new NotImplementedException();
        public MethodServerStreamingResourcesStream MethodServerStreamingResources(SimpleResourceName firstName, SimpleResourceName secondName, SimpleResourceName thirdName) => throw new NotImplementedException();

        public class MethodBidiStreamingStream : BidirectionalStreamingBase<SignatureRequest, Response> { }
        public MethodBidiStreamingStream MethodBidiStreaming() => throw new NotImplementedException();

        public Task TaskMethod(Task request) => throw new NotImplementedException();
        public Task<Task> TaskMethodAsync(Task request) => throw new NotImplementedException();

        public Response OneOfMethod(OneOfRequest request) => throw new NotImplementedException();
        public Task<Response> OneOfMethodAsync(OneOfRequest request) => throw new NotImplementedException();
    }

    public partial class AResource : ProtoMsgFake<AResource>
    {
        public string Name { get; set; }
    }

    public partial class WildcardResource : ProtoMsgFake<WildcardResource>
    {
        public string Name { get; set; }
    }

    public partial class MultiPatternResource : ProtoMsgFake<MultiPatternResource>
    {
        public string Name { get; set; }
    }

    public class AnotherMessage : ProtoMsgFake<AnotherMessage> { }

    public enum Enum
    {
        Default = 0,
    }

    public partial class DefaultValuesRequest : ProtoMsgFake<DefaultValuesRequest>
    {
        public static class Types
        {
            public class NestedMessage : ProtoMsgFake<NestedMessage> { }
            public enum NestedEnum
            {
                DefaultValue = 0,
            }
        }

        public double SingleDouble { get; set; }
        public float SingleFloat { get; set; }
        public int SingleInt32 { get; set; }
        public long SingleInt64 { get; set; }
        public uint SingleUint32 { get; set; }
        public ulong SingleUint64 { get; set; }
        public int SingleSint32 { get; set; }
        public long SingleSint64 { get; set; }
        public uint SingleFixed32 { get; set; }
        public ulong SingleFixed64 { get; set; }
        public int SingleSfixed32 { get; set; }
        public long SingleSfixed64 { get; set; }
        public bool SingleBool { get; set; }
        public string SingleString { get; set; }
        public ByteString SingleBytes { get; set; }
        public AnotherMessage SingleMessage { get; set; }
        public Types.NestedMessage SingleNestedMessage { get; set; }
        public Enum SingleEnum { get; set; }
        public Types.NestedEnum SingleNestedEnum { get; set; }
        public RepeatedField<double> RepeatedDouble { get; }
        public RepeatedField<float> RepeatedFloat { get; }
        public RepeatedField<int> RepeatedInt32 { get; }
        public RepeatedField<long> RepeatedInt64 { get; }
        public RepeatedField<uint> RepeatedUint32 { get; }
        public RepeatedField<ulong> RepeatedUint64 { get; }
        public RepeatedField<int> RepeatedSint32 { get; }
        public RepeatedField<long> RepeatedSint64 { get; }
        public RepeatedField<uint> RepeatedFixed32 { get; }
        public RepeatedField<ulong> RepeatedFixed64 { get; }
        public RepeatedField<int> RepeatedSfixed32 { get; }
        public RepeatedField<long> RepeatedSfixed64 { get; }
        public RepeatedField<bool> RepeatedBool { get; }
        public RepeatedField<string> RepeatedString { get; }
        public RepeatedField<ByteString> RepeatedBytes { get; }
        public RepeatedField<AnotherMessage> RepeatedMessage { get; }
        public RepeatedField<Types.NestedMessage> RepeatedNestedMessage { get; }
        public RepeatedField<Enum> RepeatedEnum { get; }
        public RepeatedField<Types.NestedEnum> RepeatedNestedEnum { get; }
        public string SingleResourceName { get; set; }
        public RepeatedField<string> RepeatedResourceName { get; }
        public string SingleWildcardResource { get; set; }
        public RepeatedField<string> RepeatedWildcardResource { get; }
        public string MultiPatternResourceName { get; set; }
        public RepeatedField<string> RepeatedMultiPatternResourceName { get; }
        public MapField<int, string> MapIntString { get; }
        public double? SingleWrappedDouble { get; set; }
        public float? SingleWrappedFloat { get; set; }
        public long? SingleWrappedInt64 { get; set; }
        public ulong? SingleWrappedUint64 { get; set; }
        public int? SingleWrappedInt32 { get; set; }
        public uint? SingleWrappedUint32 { get; set; }
        public bool? SingleWrappedBool { get; set; }
        public string SingleWrappedString { get; set; }
        public ByteString SingleWrappedBytes { get; set; }
        public RepeatedField<double?> RepeatedWrappedDouble { get; } = new RepeatedField<double?>();
        public RepeatedField<float?> RepeatedWrappedFloat { get; } = new RepeatedField<float?>();
        public RepeatedField<long?> RepeatedWrappedInt64 { get; } = new RepeatedField<long?>();
        public RepeatedField<ulong?> RepeatedWrappedUint64 { get; } = new RepeatedField<ulong?>();
        public RepeatedField<int?> RepeatedWrappedInt32 { get; } = new RepeatedField<int?>();
        public RepeatedField<uint?> RepeatedWrappedUint32 { get; } = new RepeatedField<uint?>();
        public RepeatedField<bool?> RepeatedWrappedBool { get; } = new RepeatedField<bool?>();
        public RepeatedField<string> RepeatedWrappedString { get; } = new RepeatedField<string>();
        public RepeatedField<ByteString> RepeatedWrappedBytes { get; } = new RepeatedField<ByteString>();
    }

    public class SignatureRequest : ProtoMsgFake<SignatureRequest>
    {
        public string AString { get; set; }
        public int AnInt { get; set; }
        public bool ABool { get; set; }
        public MapField<int, string> MapIntString { get; } = new MapField<int, string>();
    }

    public partial class SimpleResource : ProtoMsgFake<SimpleResource>
    {
        public string Name { get; set; }
    }


    public partial class ResourceSignatureRequest : ProtoMsgFake<ResourceSignatureRequest>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
    }

    public partial class RepeatedResourceSignatureRequest : ProtoMsgFake<ResourceSignatureRequest>
    {
        public RepeatedField<string> Names { get; set; }
    }

    public class Task : ProtoMsgFake<Task> { }

    public class OneOfRequest : ProtoMsgFake<OneOfRequest>
    {
        public string NonOneOfString { get; set; }
        public string AString { get; set; }
        public int ANumber { get; set; }
    }

    public class Response : ProtoMsgFake<Response> { }
    public class LroResponse : ProtoMsgFake<LroResponse> { }
    public class LroMetadata : ProtoMsgFake<LroMetadata> { }
}
