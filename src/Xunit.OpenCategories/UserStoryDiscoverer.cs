using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="UserStoryAttribute"/>.
    /// </summary>
    public class UserStoryDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(UserStoryDiscoverer);

        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the user story information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var name = traitAttribute.GetNamedArgument<string>("Identifier");

            yield return new KeyValuePair<string, string>("Category", "UserStory");

            if (!string.IsNullOrWhiteSpace(name))
                yield return new KeyValuePair<string, string>("UserStory", name);
        }
    }
}