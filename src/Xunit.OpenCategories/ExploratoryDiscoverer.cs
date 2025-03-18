using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="ExploratoryAttribute"/>.
    /// </summary>
    public class ExploratoryDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(ExploratoryDiscoverer);

        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the exploratory information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var workItemId = traitAttribute.GetNamedArgument<string>("WorkItemId");

            yield return new KeyValuePair<string, string>("Category", "Exploratory");

            if (!string.IsNullOrWhiteSpace(workItemId))
                yield return new KeyValuePair<string, string>("Exploratory", workItemId);
        }
    }
}