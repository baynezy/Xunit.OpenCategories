namespace Xunit.OpenCategories;

/// <summary>
/// Attribute to specify multiple services tested within a test class or method.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
public class ServicesAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServicesAttribute"/> class with Service names.
    /// At least one service name must be provided.
    /// </summary>
    /// <param name="names"></param>
    /// <exception cref="ArgumentException">Thrown if no service names are provided.</exception>
    public ServicesAttribute(params string[] names)
    {
        if (names == null || names.Length == 0)
        {
            throw new ArgumentException(
                "Services attribute is used without specifying a service. At least one service name must be provided.", nameof(names));
        }

        ServiceNames = names;
    }

    /// <summary>
    /// Gets the names of the Services.
    /// </summary>
    public string[] ServiceNames { get; private set; }
}
