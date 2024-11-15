using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// Attribute to specify a description for a test class or method.
/// </summary>
/// <remarks>
/// This attribute can be applied to both classes and methods, and it supports multiple usages.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class DescriptionAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DescriptionAttribute"/> class.
    /// </summary>
    /// <param name="description">The description of the test.</param>
    public DescriptionAttribute(string description)
    {
        Description = description;
    }

    /// <summary>
    /// Gets the description of the test.
    /// </summary>
    public string Description { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        if (!string.IsNullOrWhiteSpace(Description))
        {
            traits.Add(new KeyValuePair<string, string>("Description", Description));
        }
    }
}