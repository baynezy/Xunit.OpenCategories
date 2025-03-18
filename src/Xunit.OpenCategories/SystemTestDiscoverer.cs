using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="SystemTestAttribute"/>.
    /// </summary>
    public class SystemTestDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(SystemTestDiscoverer);

        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the system test information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var bugId = traitAttribute.GetNamedArgument<string>("Id");

            yield return new KeyValuePair<string, string>("Category", "SystemTest");

            if (!string.IsNullOrWhiteSpace(bugId))
                yield return new KeyValuePair<string, string>("SystemTest", bugId);
        }
    }
}