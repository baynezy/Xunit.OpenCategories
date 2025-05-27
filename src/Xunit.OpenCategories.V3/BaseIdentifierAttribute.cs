using System.Collections.Generic;
using Xunit.OpenCategories.Core;

namespace Xunit.OpenCategories.V3
{
    /// <summary>
    /// Base attribute class for attributes that have an identifier.
    /// </summary>
    public abstract class BaseIdentifierAttribute : BaseAttribute
    {
        /// <summary>
        /// Gets the identifier associated with the attribute.
        /// </summary>
        public string? Identifier { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdentifierAttribute"/> class.
        /// </summary>
        protected BaseIdentifierAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdentifierAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier associated with the attribute.</param>
        protected BaseIdentifierAttribute(string? identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdentifierAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier associated with the attribute.</param>
        protected BaseIdentifierAttribute(long id)
        {
            Identifier = id.ToString();
        }

        /// <inheritdoc />
        protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
        {
            AddOptionalTrait(traits, GetPropertyName(), Identifier);
        }

        /// <summary>
        /// Gets the property name to use for the identifier trait.
        /// </summary>
        /// <returns>The property name.</returns>
        protected abstract string GetPropertyName();
    }
}