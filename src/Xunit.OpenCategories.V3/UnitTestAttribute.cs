using System.Collections.Generic;
using Xunit.OpenCategories.Core;

namespace Xunit.OpenCategories.V3;

/// <summary>
/// Attribute to mark a test as a unit test.
/// </summary>
/// <remarks>
/// Unit tests are used to verify the functionality of a specific section of code.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class UnitTestAttribute : BaseIdentifierAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class.
    /// </summary>
    public UnitTestAttribute() : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class with a specified identifier.
    /// </summary>
    /// <param name="name">The identifier associated with the unit test.</param>
    public UnitTestAttribute(string? name) : base(name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class with a specified identifier.
    /// </summary>
    /// <param name="id">The identifier associated with the unit test.</param>
    public UnitTestAttribute(long id) : base(id)
    {
    }

    /// <inheritdoc />
    protected override string GetPropertyName() => TraitConstants.UnitTestCategory;

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, TraitConstants.UnitTestCategory);
    }
}