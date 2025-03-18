using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// For annotating tests that relate to a specific Test Case.
    /// </summary>
    [TraitDiscoverer(TestCaseDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TestCaseAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Gets the identifier associated with the test case.
        /// </summary>
        public string TestCaseId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseAttribute"/> class with a specified test case identifier.
        /// </summary>
        /// <param name="testCaseId">The identifier associated with the test case.</param>
        public TestCaseAttribute(string testCaseId)
        {
            TestCaseId = testCaseId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseAttribute"/> class with a specified test case identifier.
        /// </summary>
        /// <param name="testCaseId">The identifier associated with the test case.</param>
        public TestCaseAttribute(long testCaseId)
        {
            TestCaseId = testCaseId.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseAttribute"/> class.
        /// </summary>
        public TestCaseAttribute()
        {
        }
    }
}