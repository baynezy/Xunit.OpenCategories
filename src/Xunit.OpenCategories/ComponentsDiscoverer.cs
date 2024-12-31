using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="ComponentsAttribute"/>.
    /// </summary>
    public class ComponentsDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(ComponentsDiscoverer);

        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the component information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var names = traitAttribute.GetNamedArgument<string[]>("ComponentNames");

            yield return new KeyValuePair<string, string>("Category", "Components");

            if (names != null)
            {
                foreach (var name in names)
                {
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        yield return new KeyValuePair<string, string>("Component", name);
                    }
                }
            }
        }
    }
}