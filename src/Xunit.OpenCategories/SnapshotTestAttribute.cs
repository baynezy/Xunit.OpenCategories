using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to mark a test as a snapshot test.
    /// </summary>
    /// <remarks>
    /// Snapshot tests are used to verify that the output of a function matches the expected output.
    /// </remarks>
    [TraitDiscoverer(SnapshotTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SnapshotTestAttribute : Attribute, ITraitAttribute
    {
    }
}