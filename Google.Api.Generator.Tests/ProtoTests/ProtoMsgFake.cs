using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    public abstract class ProtoMsgFake<T> : IMessage<T> where T : ProtoMsgFake<T>
    {
        public MessageDescriptor Descriptor => throw new NotImplementedException();
        public int CalculateSize() => throw new NotImplementedException();
        public T Clone() => throw new NotImplementedException();
        public bool Equals(T other) => throw new NotImplementedException();
        public void MergeFrom(T message) => throw new NotImplementedException();
        public void MergeFrom(CodedInputStream input) => throw new NotImplementedException();
        public void WriteTo(CodedOutputStream output) => throw new NotImplementedException();
    }
}
