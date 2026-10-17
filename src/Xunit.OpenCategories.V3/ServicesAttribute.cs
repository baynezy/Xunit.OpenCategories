namespace Xunit.OpenCategories.V3;

/// <summary>
/// Attribute to specify multiple service names for a test class or method.
/// </summary>
/// <remarks>
/// This attribute can be applied to both classes and methods, and it supports multiple usages.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ServicesAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServicesAttribute"/> class with one or more service names.
    /// </summary>
    /// <param name="serviceNames">The service names.</param>
    public ServicesAttribute(params string[] serviceNames)
    {
        ServiceNames = serviceNames ?? Array.Empty<string>();
    }

    /// <summary>
    /// Gets the service names.
    /// </summary>
    public string[] ServiceNames { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        if (ServiceNames != null)
        {
            foreach (var service in ServiceNames)
            {
                AddOptionalTrait(traits, "Service", service);
            }
        }
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "Service");
    }
}
