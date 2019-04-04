using Google.Api.Gax;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceUpgradeTest
{
    // Implementations not shown.

    public class RequestNameOneof : IResourceName, IEquatable<RequestNameOneof>
    {
        public ResourceNameKind Kind => throw new NotImplementedException();
        public bool Equals(RequestNameOneof other) => throw new NotImplementedException();
    }

    public partial class Request
    {
        // The non-oneof property `RequestName` will throw an exception when read if the stored type is not a `RequestName` resource.
        public RequestNameOneof RequestNameOneof
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        // The non-oneof property `AnotherName` will throw an exception when read if the stored type is not a `RequestName` resource.
        public RequestNameOneof AnotherNameAsRequestNameOneof
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
