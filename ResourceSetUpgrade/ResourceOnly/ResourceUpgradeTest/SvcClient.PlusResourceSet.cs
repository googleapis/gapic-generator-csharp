using ResourceUpgradeTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceOnly.ResourceUpgradeTest
{
    partial class SvcClient
    {
        // Simple/usual case - one parameter with a resource upgraded to a resource-set.

        // These methods already exist (showing sync methods only; ignoring `callSettings` final parameter for simplicity):
        // public virtual Response M(string name)
        // public virtual Response M(RequestName name)

        // This methods will be added:
        public virtual Response M(RequestNameOneof name) => throw new NotImplementedException();

        // These methods already exist (showing sync methods only; ignoring `callSettings` final parameter for simplicity):
        // public virtual Response M(string name, string anotherName)
        // public virtual Response M(RequestName name, RequestName anotherName)

        // These methods will be added.
        // Note the combinatorial addition of methods when there are multiple parameters with upgrades.
        // This is required so backwards compatibility is maintained regardless of the order in which the resouces are upgraded to resource-sets.
        // In a real-life scenario it's possible that the method signature arguments won't be of the same resource, so they can be upgraded
        // to resource-sets independently of each other.
        public virtual Response M(RequestNameOneof name, RequestName anotherName) => throw new NotImplementedException();
        public virtual Response M(RequestName name, RequestNameOneof anotherName) => throw new NotImplementedException();
        public virtual Response M(RequestNameOneof name, RequestNameOneof anotherName) => throw new NotImplementedException();
    }
}
