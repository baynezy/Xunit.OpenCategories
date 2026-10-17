namespace Xunit.OpenCategories.V3;

/// <summary>
/// Attribute to specify multiple component names for a test class or method.
/// </summary>
/// <remarks>
/// This attribute can be applied to both classes and methods, and it supports multiple usages.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ComponentsAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentsAttribute"/> class with one or more component names.
    /// </summary>
    /// <param name="componentNames">The component names.</param>
    public ComponentsAttribute(params string[] componentNames)
    {
        ComponentNames = componentNames ?? Array.Empty<string>();
    }

    /// <summary>
    /// Gets the component names.
    /// </summary>
    public string[] ComponentNames { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        if (ComponentNames != null)
        {
            foreach (var component in ComponentNames)
            {
                AddOptionalTrait(traits, "Component", component);
            }
        }
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "Component");
    }
}
