using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// For annotating tests that relate to a specific Test Case.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TestCaseAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Gets the identifier associated with the test case.
        /// </summary>
        public string TestCaseId { get; }

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

        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();
            var category = new KeyValuePair<string,string>("Category", "TestCase");
            traits.Add(category);
            
            if (!string.IsNullOrWhiteSpace(TestCaseId))
            {
                traits.Add(new KeyValuePair<string, string>("TestCase", TestCaseId));
            }
            
            return traits;
        }
    }
}