using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.OpenCategories.Core;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="UnitTestAttribute"/>.
    /// </summary>
    public class UnitTestDiscoverer : BaseTraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(UnitTestDiscoverer);

        /// <inheritdoc />
        protected override string GetCategoryValue() => TraitConstants.UnitTestCategory;

        /// <inheritdoc />
        protected override IEnumerable<KeyValuePair<string, string>> GetAdditionalTraits(IAttributeInfo traitAttribute)
        {
            var name = traitAttribute.GetNamedArgument<string>("Identifier");

            if (!TraitDiscoveryUtil.IsNullOrWhitespace(name))
                yield return TraitDiscoveryUtil.CreateTrait(TraitConstants.UnitTestCategory, name);
        }
    }
}