using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories;

/// <summary>
/// Base attribute class that implements the ITraitAttribute interface.
/// Provides methods to get traits and add mandatory and optional traits.
/// </summary>
public abstract class BaseAttribute : Attribute, ITraitAttribute
{
    /// <summary>
    /// Gets the traits associated with the attribute.
    /// </summary>
    /// <returns>A read-only collection of key-value pairs representing the traits.</returns>
    public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
    {
        var traits = new List<KeyValuePair<string, string>>();

        MandatoryTraits(traits);
        OptionalTraits(traits);

        return traits;
    }

    /// <summary>
    /// Adds optional traits to the provided list.
    /// </summary>
    /// <param name="traits">The list to which optional traits will be added.</param>
    protected virtual void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
    }

    /// <summary>
    /// Adds mandatory traits to the provided list.
    /// </summary>
    /// <param name="traits">The list to which mandatory traits will be added.</param>
    protected virtual void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
    }

    /// <summary>
    /// Adds an optional trait to the provided list.
    /// </summary>
    /// <param name="traits">The list to which the trait will be added.</param>
    /// <param name="name">The name of the trait.</param>
    /// <param name="value">The value of the trait.</param>
    protected static void AddOptionalTrait(List<KeyValuePair<string, string>> traits, string name, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            traits.Add(new KeyValuePair<string, string>(name, value));
        }
    }

    private static void AddMandatoryTrait(List<KeyValuePair<string, string>> traits, string name, string value)
    {
        var category = new KeyValuePair<string, string>(name, value);
        traits.Add(category);
    }

    /// <summary>
    /// Adds a category trait to the provided list.
    /// </summary>
    /// <param name="traits">The list to which the trait will be added.</param>
    /// <param name="value">The value of the trait.</param>
    protected static void AddCategory(List<KeyValuePair<string, string>> traits, string value)
    {
        AddMandatoryTrait(traits,"Category", value);
    }
}