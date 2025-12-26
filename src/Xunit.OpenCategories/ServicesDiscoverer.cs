using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discoverer for the <see cref="ServicesAttribute"/> attribute.
    /// </summary>
    public class ServicesDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(ServicesDiscoverer);
        
        /// <inheritdoc/>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var names = traitAttribute.GetNamedArgument<string[]>("ServiceNames");
            
            yield return new KeyValuePair<string, string>("Category", "Services");

            if (names is null) yield break;
            
            foreach (var name in names)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    yield return new KeyValuePair<string, string>("Service", name);
                }
            }
        }
    }
}