namespace Xunit.OpenCategories.V3;

/// <summary>
/// Attribute to categorize a test as an integration test.
/// </summary>
/// <remarks>
/// This is a category-only attribute that applies the "IntegrationTest" category.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class IntegrationTestsAttribute : BaseAttribute
{
    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "IntegrationTest");
    }
}
