using Google.Api.Gax;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceUpgradeTest
{
    // Implementations not shown.

    public class LogNameOneof : IResourceName
    {
        public ResourceNameKind Kind => ResourceNameKind.Oneof;
    }

    public partial class DeleteLogRequest
    {
        // The non-oneof property `LogNameAsLogName` will throw an exception when read if the stored type is not a `LogName` resource.
        public LogNameOneof LogNameAsLogNameOneof
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }

    public class ParentNameOneof : IResourceName
    {
        public ResourceNameKind Kind => ResourceNameKind.Oneof;
    }

    public partial class ListLogsRequest
    {
        // The non-oneof property `ParentAsProjectName` will throw an exception when read if the stored type is not a `ProjectName` resource.
        public ParentNameOneof ParentAsParentNameOneof
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
