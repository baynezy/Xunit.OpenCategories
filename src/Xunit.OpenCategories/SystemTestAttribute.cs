using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to mark a test as a system test.
    /// </summary>
    /// <remarks>
    /// System tests are used to verify the complete and integrated software system.
    /// </remarks>
    [TraitDiscoverer(SystemTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SystemTestAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTestAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier associated with the system test.</param>
        public SystemTestAttribute(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTestAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier associated with the system test.</param>
        public SystemTestAttribute(long id)
        {
            Id = id.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTestAttribute"/> class.
        /// </summary>
        public SystemTestAttribute()
        {

        }

        /// <summary>
        /// Gets the identifier associated with the system test.
        /// </summary>
        public string Id { get; private set; }
    }
}