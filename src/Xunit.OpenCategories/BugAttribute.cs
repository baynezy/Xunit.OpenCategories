using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// Attribute to specify a bug ID for a test class or method.
/// </summary>
/// <remarks>
/// This attribute can be applied to both classes and methods, and it supports multiple usages.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class BugAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BugAttribute"/> class with a string ID.
    /// </summary>
    /// <param name="id">The bug ID as a string.</param>
    public BugAttribute(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BugAttribute"/> class with a long ID.
    /// </summary>
    /// <param name="id">The bug ID as a long.</param>
    public BugAttribute(long id)
    {
        Id = id.ToString();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BugAttribute"/> class.
    /// </summary>
    public BugAttribute()
    {
    }

    /// <summary>
    /// Gets the bug ID.
    /// </summary>
    public string Id { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "Bug", Id);
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "Bug");
    }
}