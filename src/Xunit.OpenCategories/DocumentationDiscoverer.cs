using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="DocumentationAttribute"/>.
    /// </summary>
    public class DocumentationDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(DocumentationDiscoverer);

        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the documentation information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var workItemId = traitAttribute.GetNamedArgument<string>("WorkItemId");

            yield return new KeyValuePair<string, string>("Category", "Documentation");

            if (!string.IsNullOrWhiteSpace(workItemId))
                yield return new KeyValuePair<string, string>("Documentation", workItemId);
        }
    }
}