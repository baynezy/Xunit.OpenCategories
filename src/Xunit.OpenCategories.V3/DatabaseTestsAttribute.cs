namespace Xunit.OpenCategories.V3;

/// <summary>
/// Attribute to categorize a test as a database test.
/// </summary>
/// <remarks>
/// This is a category-only attribute that applies the "DatabaseTest" category.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class DatabaseTestsAttribute : BaseAttribute
{
    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "DatabaseTest");
    }
}
