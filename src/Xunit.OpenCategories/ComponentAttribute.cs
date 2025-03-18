using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify a component for a test class or method.
    /// </summary>
    [TraitDiscoverer(ComponentDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
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
        public string ComponentName { get; private set; }
    }
}