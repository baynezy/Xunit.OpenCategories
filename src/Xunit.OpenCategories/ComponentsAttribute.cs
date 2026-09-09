using System;
using System.Linq;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify multiple component names for a test class or method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer(ComponentsDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ComponentsAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentsAttribute"/> class with one or more component names.
        /// </summary>
        /// <param name="componentNames">The component names.</param>
        public ComponentsAttribute(params string[] componentNames)
        {
            ComponentNames = componentNames ?? Array.Empty<string>();
        }

        /// <summary>
        /// Gets the component names.
        /// </summary>
        public string[] ComponentNames { get; private set; }
    }
}
