using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="ServicesAttribute"/>.
    /// </summary>
    public class ServicesDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(ServicesDiscoverer);

        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the service information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var serviceNames = traitAttribute.GetNamedArgument<string[]>("ServiceNames");

            yield return new KeyValuePair<string, string>("Category", "Service");

            if (serviceNames != null && serviceNames.Any())
            {
                foreach (var service in serviceNames)
                {
                    if (!string.IsNullOrWhiteSpace(service))
                    {
                        yield return new KeyValuePair<string, string>("Service", service);
                    }
                }
            }
        }
    }
}
