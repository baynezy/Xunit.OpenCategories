using Xunit.OpenCategories.Core;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="DatabaseTestAttribute"/>.
    /// </summary>
    public class DatabaseTestDiscoverer : BaseTraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(DatabaseTestDiscoverer);

        /// <inheritdoc />
        protected override string GetCategoryValue() => TraitConstants.DatabaseTestCategory;
    }
}