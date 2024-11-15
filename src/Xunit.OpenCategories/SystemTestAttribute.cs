using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// Attribute to mark a test as a system test.
/// </summary>
/// <remarks>
/// System tests are used to verify the complete and integrated software system.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SystemTestAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SystemTestAttribute"/> class with a specified identifier.
    /// </summary>
    /// <param name="id">The identifier associated with the system test.</param>
    public SystemTestAttribute(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemTestAttribute"/> class with a specified identifier.
    /// </summary>
    /// <param name="id">The identifier associated with the system test.</param>
    public SystemTestAttribute(long id)
    {
        Id = id.ToString();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemTestAttribute"/> class.
    /// </summary>
    public SystemTestAttribute()
    {
    }

    /// <summary>
    /// Gets the identifier associated with the system test.
    /// </summary>
    public string Id { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "SystemTest", Id);
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "SystemTest");
    }
}