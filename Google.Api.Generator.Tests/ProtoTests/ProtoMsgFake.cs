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
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Testing
{
    public abstract class ProtoMsgFake<T> : IMessage<T> where T : ProtoMsgFake<T>
    {
        public MessageDescriptor Descriptor => throw new NotImplementedException();
        public int CalculateSize() => throw new NotImplementedException();
        public T Clone() => throw new NotImplementedException();
        public void MergeFrom(T message) => throw new NotImplementedException();
        public void MergeFrom(CodedInputStream input) => throw new NotImplementedException();
        public void WriteTo(CodedOutputStream output) => throw new NotImplementedException();

        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }
            foreach (var property in GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                var thisValue = property.GetValue(this);
                var otherValue = property.GetValue(other);
                if (thisValue is IEnumerable thisEnum && otherValue is IEnumerable otherEnum)
                {
                    if (!thisEnum.Cast<object>().SequenceEqual(otherEnum.Cast<object>()))
                    {
                        return false;
                    }
                }
                else if (!Equals(thisValue, otherValue))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj) => obj is T other ? Equals(other) : false;
        public override int GetHashCode() => GetType().GetProperties().Sum(x => x.GetValue(this)?.GetHashCode() ?? 0);
    }
}
