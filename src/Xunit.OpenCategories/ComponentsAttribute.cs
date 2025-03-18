using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify multiple components for a test class or method.
    /// </summary>
    [TraitDiscoverer(ComponentsDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ComponentsAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentsAttribute"/> class.
        /// </summary>
        public ComponentsAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentsAttribute"/> class with component names.
        /// </summary>
        /// <param name="names"></param>
        public ComponentsAttribute(params string[] names)
        {
            ComponentNames = names;
        }

        /// <summary>
        /// Gets the names of the components.
        /// </summary>
        public string[] ComponentNames { get; private set; }
    }
}