namespace Xunit.OpenCategories.V3;

/// <summary>
/// Attribute to categorize a test as a snapshot test.
/// </summary>
/// <remarks>
/// This is a category-only attribute that applies the "SnapshotTest" category.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SnapshotTestsAttribute : BaseAttribute
{
    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "SnapshotTest");
    }
}
