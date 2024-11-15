using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// Attribute to specify a category for a test class or method.
/// </summary>
/// <remarks>
/// This attribute can be applied to both classes and methods, and it supports multiple usages.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class CategoryAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryAttribute"/> class.
    /// </summary>
    /// <param name="categoryName">The name of the category.</param>
    public CategoryAttribute(string categoryName)
    {
        Name = categoryName;
    }

    /// <summary>
    /// Gets the name of the category.
    /// </summary>
    public string Name { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            traits.Add(new KeyValuePair<string, string>("Category", Name));
        }
    }
}