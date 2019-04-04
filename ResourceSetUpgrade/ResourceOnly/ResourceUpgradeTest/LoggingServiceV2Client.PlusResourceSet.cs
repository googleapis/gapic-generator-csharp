using Google.Api.Gax;
using ResourceUpgradeTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceOnly.ResourceUpgradeTest
{
    partial class SvcClient
    {
        // DeleteLog method

        // These methods already exist (showing sync methods only; ignoring `callSettings` final parameter for simplicity):
        // public virtual Empty DeleteLog(string logName)
        // public virtual Empty DeleteLog(LogName logName) // Still required for backward compatibility.

        // This overload will be added:
        public virtual Empty DeleteLog(LogNameOneof name) => throw new NotImplementedException();

        // ListLogs method

        // These methods already exist (showing sync methods only; ignoring `callSettings` final parameter for simplicity):
        // public virtual gax::PagedEnumerable<ListLogsResponse, string> ListLogs(string parent, string pageToken = null, int? pageSize = null)
        // public virtual gax::PagedEnumerable<ListLogsResponse, string> ListLogs(ProjectName parent, string pageToken = null, int? pageSize = null) // Still required for backward compatibility.

        // This overload will be added:
        public virtual PagedEnumerable<ListLogsResponse, string> ListLogs(ParentNameOneof parent, string pageToken = null, int? pageSize = null) =>
            throw new NotImplementedException();
    }
}
