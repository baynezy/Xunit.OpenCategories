using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify a component for a test class or method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ComponentAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentAttribute"/> class.
        /// </summary>
        public ComponentAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentAttribute"/> class with a specified component name.
        /// </summary>
        /// <param name="name">The name of the component.</param>
        public ComponentAttribute(string name)
        {
            ComponentName = name;
        }

        /// <summary>
        /// Gets the name of the component.
        /// </summary>
        public string ComponentName { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();
            var category = new KeyValuePair<string, string>("Category", "Component");
            traits.Add(category);
            
            if (!string.IsNullOrWhiteSpace(ComponentName))
            {
                traits.Add(new KeyValuePair<string, string>("Component", ComponentName));
            }
            
            return traits;
        }
    }
}