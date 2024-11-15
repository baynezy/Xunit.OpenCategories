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
}