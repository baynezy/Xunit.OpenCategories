using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify multiple services for a test class or method.
    /// </summary>
    [TraitDiscoverer(ServicesDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ServicesAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ServicesAttribute"/> class.
        /// </summary>
        /// <param name="names"></param>
        public ServicesAttribute(params string[] names)
        {
            ServiceNames = names;
        }

        /// <summary>
        /// Gets the names of the services.
        /// </summary>
        public string[] ServiceNames { get; private set; }
    }
}