using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to mark a test as a unit test.
    /// </summary>
    /// <remarks>
    /// Unit tests are used to verify the functionality of a specific section of code.
    /// </remarks>
    [TraitDiscoverer(UnitTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UnitTestAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class.
        /// </summary>
        public UnitTestAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="name">The identifier associated with the unit test.</param>
        public UnitTestAttribute(string name)
        {
            Identifier = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier associated with the unit test.</param>
        public UnitTestAttribute(long id)
        {
            Identifier = id.ToString();
        }

        /// <summary>
        /// Gets the identifier associated with the unit test.
        /// </summary>
        public string Identifier { get; private set; }
    }
}