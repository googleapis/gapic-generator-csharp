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
using System;

namespace Google.Api.Generator.ProtoUtils
{
    internal class ProtoMsg : IMessage<ProtoMsg>
    {
        public MessageDescriptor Descriptor => throw new NotImplementedException();
        public int CalculateSize() => throw new NotImplementedException();
        public ProtoMsg Clone() => throw new NotImplementedException();
        public bool Equals(ProtoMsg other) => throw new NotImplementedException();
        public void MergeFrom(CodedInputStream input) => throw new NotImplementedException();
        public void MergeFrom(ProtoMsg message) => throw new NotImplementedException();
        public void WriteTo(CodedOutputStream output) => throw new NotImplementedException();
    }
}
