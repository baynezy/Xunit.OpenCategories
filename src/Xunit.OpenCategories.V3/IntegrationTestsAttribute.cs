namespace Xunit.OpenCategories.V3;

/// <summary>
/// Attribute to specify that a test is an integration test.
/// </summary>
/// <remarks>
/// This attribute can be applied to both classes and methods, and it supports multiple usages.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
[Obsolete("Use IntegrationTestAttribute from Xunit.OpenCategories instead.")]
public class IntegrationTestsAttribute : BaseAttribute
{
    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "IntegrationTest");
    }
}