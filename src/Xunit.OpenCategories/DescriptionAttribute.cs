using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify a description for a test class or method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer(DescriptionDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DescriptionAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">The description of the test.</param>
        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Gets the description of the test.
        /// </summary>
        public string Description { get; }
    }
}