using System.Collections.Generic;
using Xunit.OpenCategories.Core;

namespace Xunit.OpenCategories.V3
{
    /// <summary>
    /// Base attribute class for attributes that only have a category.
    /// </summary>
    public abstract class BaseCategoryAttribute : BaseAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCategoryAttribute"/> class.
        /// </summary>
        protected BaseCategoryAttribute()
        {
        }

        /// <inheritdoc />
        protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
        {
            AddCategory(traits, GetCategoryValue());
        }

        /// <summary>
        /// Gets the category value to use for the category trait.
        /// </summary>
        /// <returns>The category value.</returns>
        protected abstract string GetCategoryValue();
    }
}