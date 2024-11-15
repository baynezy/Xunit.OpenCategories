using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// For annotating tests that relate to a specific Test Case.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class TestCaseAttribute : BaseAttribute
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

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "TestCase", TestCaseId);
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "TestCase");

    }
}