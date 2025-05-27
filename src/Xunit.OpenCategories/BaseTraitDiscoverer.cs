using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.OpenCategories.Core;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Base trait discoverer that provides common functionality for trait discovery.
    /// </summary>
    public abstract class BaseTraitDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            yield return TraitDiscoveryUtil.CreateCategoryTrait(GetCategoryValue());
            
            foreach (var trait in GetAdditionalTraits(traitAttribute))
            {
                yield return trait;
            }
        }
        
        /// <summary>
        /// Gets the category value for this trait discoverer.
        /// </summary>
        /// <returns>The category value.</returns>
        protected abstract string GetCategoryValue();
        
        /// <summary>
        /// Gets additional traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing information.</param>
        /// <returns>An enumerable of key-value pairs representing additional traits.</returns>
        protected virtual IEnumerable<KeyValuePair<string, string>> GetAdditionalTraits(IAttributeInfo traitAttribute)
        {
            yield break;
        }
    }
}