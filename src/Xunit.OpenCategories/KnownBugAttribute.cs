using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

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
    public KnownBugAttribute(string id)
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
    public string Id { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        if (!string.IsNullOrWhiteSpace(Id))
        {
            traits.Add(new KeyValuePair<string, string>("KnownBug", Id));
        }
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        var category = new KeyValuePair<string, string>("Category", "KnownBug");
        traits.Add(category);
    }
}