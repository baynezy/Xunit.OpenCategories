using System;
using System.Linq;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify multiple service names for a test class or method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer(ServicesDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ServicesAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesAttribute"/> class with one or more service names.
        /// </summary>
        /// <param name="serviceNames">The service names.</param>
        public ServicesAttribute(params string[] serviceNames)
        {
            ServiceNames = serviceNames ?? Array.Empty<string>();
        }

        /// <summary>
        /// Gets the service names.
        /// </summary>
        public string[] ServiceNames { get; private set; }
    }
}
