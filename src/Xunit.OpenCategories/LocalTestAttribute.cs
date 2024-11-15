using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// For tests that should only be executed locally and excluded from automated pipeline runs.
/// </summary>
/// <example>
/// Trying out LINQ for the first time, writing a piece of code to understand IEnumerable.Take and Skip.
/// </example>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class LocalTestAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocalTestAttribute"/> class with a specified ID.
    /// </summary>
    /// <param name="id">The ID associated with the local test.</param>
    public LocalTestAttribute(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalTestAttribute"/> class with a specified ID.
    /// </summary>
    /// <param name="id">The ID associated with the local test.</param>
    public LocalTestAttribute(long id)
    {
        Id = id.ToString();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalTestAttribute"/> class.
    /// </summary>
    public LocalTestAttribute()
    {
    }

    /// <summary>
    /// Gets the ID associated with the local test.
    /// </summary>
    public string Id { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        if (!string.IsNullOrWhiteSpace(Id))
        {
            traits.Add(new KeyValuePair<string, string>("LocalTest", Id));
        }
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        var category = new KeyValuePair<string, string>("Category", "LocalTest");
        traits.Add(category);
    }
}