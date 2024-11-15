using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// Attribute to specify a component for a test class or method.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ComponentAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentAttribute"/> class.
    /// </summary>
    public ComponentAttribute()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentAttribute"/> class with a specified component name.
    /// </summary>
    /// <param name="name">The name of the component.</param>
    public ComponentAttribute(string name)
    {
        ComponentName = name;
    }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    public string ComponentName { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "Component");
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "Component", ComponentName);
    }
}