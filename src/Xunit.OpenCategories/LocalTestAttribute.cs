using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// For tests that should only be executed locally and excluded from automated pipeline runs.
    /// </summary>
    /// <example>
    /// Trying out LINQ for the first time, writing a piece of code to understand IEnumerable.Take and Skip.
    /// </example>
    [TraitDiscoverer(LocalTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class LocalTestAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTestAttribute"/> class with a specified ID.
        /// </summary>
        /// <param name="id">The ID associated with the local test.</param>
        public LocalTestAttribute(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTestAttribute"/> class with a specified ID.
        /// </summary>
        /// <param name="id">The ID associated with the local test.</param>
        public LocalTestAttribute(long id)
        {
            Id = id.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTestAttribute"/> class.
        /// </summary>
        public LocalTestAttribute()
        {
        }

        /// <summary>
        /// Gets the ID associated with the local test.
        /// </summary>
        public string Id { get; }
    }
}