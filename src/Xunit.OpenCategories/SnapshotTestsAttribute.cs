using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to mark a test as a snapshot test.
    /// </summary>
    /// <remarks>
    /// Snapshot tests are used to verify that the output of a function matches the expected output.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SnapshotTestsAttribute : Attribute, ITraitAttribute
    {
        /// <inheritdoc/>
        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Category", "SnapshotTest")
            };
        }
    }
}