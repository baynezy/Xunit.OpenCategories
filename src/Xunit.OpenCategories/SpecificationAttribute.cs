using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to mark a test as a specification test.
    /// </summary>
    /// <remarks>
    /// Specification tests are used to verify that the implementation meets the specified requirements.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SpecificationAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationAttribute"/> class.
        /// </summary>
        public SpecificationAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier associated with the specification test.</param>
        public SpecificationAttribute(string id)
        {
            Identifier = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier associated with the specification test.</param>
        public SpecificationAttribute(long id)
        {
            Identifier = id.ToString();
        }

        /// <summary>
        /// Gets the identifier associated with the specification test.
        /// </summary>
        public string Identifier { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();
            var category = new KeyValuePair<string,string>("Category", "Specification");
            traits.Add(category);
            
            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                traits.Add(new KeyValuePair<string, string>("Specification", Identifier));
            }
            
            return traits;
        }
    }
}