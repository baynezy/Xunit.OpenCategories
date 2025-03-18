namespace Xunit.OpenCategories.V3;

/// <summary>
/// For failing tests relating to known bugs that should not fail a build.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class KnownBugAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KnownBugAttribute"/> class with a specified bug ID.
    /// </summary>
    /// <param name="id">The ID of the known bug associated with the test.</param>
    public KnownBugAttribute(string? id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KnownBugAttribute"/> class with a specified bug ID.
    /// </summary>
    /// <param name="id">The ID of the known bug associated with the test.</param>
    public KnownBugAttribute(long id)
    {
        Id = id.ToString();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KnownBugAttribute"/> class.
    /// </summary>
    public KnownBugAttribute()
    {
    }

    /// <summary>
    /// Gets the ID of the known bug associated with the test.
    /// </summary>
    public string? Id { get; } = string.Empty;

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "KnownBug", Id);
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "KnownBug");
    }
}