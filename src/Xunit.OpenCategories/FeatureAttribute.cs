using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify that a test is related to a specific feature.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer(FeatureDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class FeatureAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
        /// </summary>
        public FeatureAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureAttribute"/> class with a specified feature name.
        /// </summary>
        /// <param name="name">The name of the feature associated with the test.</param>
        public FeatureAttribute(string name)
        {
            Identifier = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureAttribute"/> class with a specified feature ID.
        /// </summary>
        /// <param name="id">The ID of the feature associated with the test.</param>
        public FeatureAttribute(long id)
        {
            Identifier = id.ToString();
        }

        /// <summary>
        /// Gets the identifier (name or ID) of the feature associated with the test.
        /// </summary>
        public string Identifier { get; private set; }
    }
}