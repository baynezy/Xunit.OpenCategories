using System.Collections.Generic;

namespace Xunit.OpenCategories.Core
{
    /// <summary>
    /// Provides common trait discovery functionality.
    /// </summary>
    public static class TraitDiscoveryUtil
    {
        /// <summary>
        /// Creates a trait key-value pair with "Category" as the key.
        /// </summary>
        /// <param name="category">The category value.</param>
        /// <returns>A key-value pair representing the category trait.</returns>
        public static KeyValuePair<string, string> CreateCategoryTrait(string category)
        {
            return new KeyValuePair<string, string>(TraitConstants.CategoryKey, category);
        }
        
        /// <summary>
        /// Creates a trait key-value pair with the specified key and value.
        /// </summary>
        /// <param name="key">The trait key.</param>
        /// <param name="value">The trait value.</param>
        /// <returns>A key-value pair representing the trait.</returns>
        public static KeyValuePair<string, string> CreateTrait(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }
        
        /// <summary>
        /// Checks if a string is null or whitespace.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is null or whitespace, false otherwise.</returns>
        public static bool IsNullOrWhitespace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}