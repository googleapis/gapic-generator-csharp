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
using Google.Protobuf;
using Google.Protobuf.Collections;
using System;
using System.Threading.Tasks;

namespace Testing.Snippets
{
    public class SnippetsClient
    {
        public static SnippetsClient Create() => throw new NotImplementedException();
        public static Task<SnippetsClient> CreateAsync() => throw new NotImplementedException();

        public Response MethodDefaultValues(DefaultValuesRequest request) => throw new NotImplementedException();
        public Task<Response> MethodDefaultValuesAsync(DefaultValuesRequest request) => throw new NotImplementedException();

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
    }

    public class AResourceName : IResourceName
    {
        public AResourceName(string itemId, string partId) => throw new NotImplementedException();
        public ResourceNameKind Kind => throw new NotImplementedException();
    }

    public class AnotherMessage : ProtoMsgFake<AnotherMessage> { }

    public enum Enum
    {
        Default = 0,
    }

    public class DefaultValuesRequest : ProtoMsgFake<DefaultValuesRequest>
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

        public AResourceName SingleResourceNameAsAResourceName { get; set; }
        public ResourceNameList<AResourceName> RepeatedResourceNameAsAResourceNames { get; }
        public IResourceName SingleWildcardResourceAsResourceName { get; set; }
        public ResourceNameList<IResourceName> RepeatedWildcardResourceAsResourceNames { get; }
    }

    public class SignatureRequest : ProtoMsgFake<SignatureRequest>
    {
        public string AString { get; set; }
        public int AnInt { get; set; }
        public bool ABool { get; set; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
