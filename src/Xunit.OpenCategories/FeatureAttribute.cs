using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// Attribute to specify that a test is related to a specific feature.
/// </summary>
/// <remarks>
/// This attribute can be applied to both classes and methods, and it supports multiple usages.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class FeatureAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
    /// </summary>
    public FeatureAttribute()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureAttribute"/> class with a specified feature name.
    /// </summary>
    /// <param name="name">The name of the feature associated with the test.</param>
    public FeatureAttribute(string name)
    {
        Identifier = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureAttribute"/> class with a specified feature ID.
    /// </summary>
    /// <param name="id">The ID of the feature associated with the test.</param>
    public FeatureAttribute(long id)
    {
        Identifier = id.ToString();
    }

    /// <summary>
    /// Gets the identifier (name or ID) of the feature associated with the test.
    /// </summary>
    public string Identifier { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "Feature", Identifier);
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "Feature");
    }
}