using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify a category for a test class or method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CategoryAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryAttribute"/> class.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        public CategoryAttribute(string categoryName)
        {
            Name = categoryName;
        }

        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        public string Name { get; }

        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();
            
            if (!string.IsNullOrWhiteSpace(Name))
            {
                traits.Add(new KeyValuePair<string, string>("Category", Name));
            }
            
            return traits;
        }
    }
}