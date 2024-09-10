﻿using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Discovers the traits for the <see cref="KnownBugAttribute"/>.
    /// </summary>
    public class KnownBugDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// The fully qualified type name of the discoverer.
        /// </summary>
        internal const string DiscovererTypeName = DiscovererUtil.AssemblyName + "." + nameof(KnownBugDiscoverer);

        /// <summary>
        /// Gets the traits for the specified trait attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the known bug information.</param>
        /// <returns>An enumerable of key-value pairs representing the traits.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            // Retrieve the "Id" named argument from the trait attribute
            var bugId = traitAttribute.GetNamedArgument<string>("Id");

            // Yield a key-value pair representing the category as "KnownBug"
            yield return new KeyValuePair<string, string>("Category", "KnownBug");

            // If the bug ID is not null or whitespace, yield a key-value pair for the known bug information
            if (!string.IsNullOrWhiteSpace(bugId))
                yield return new KeyValuePair<string, string>("KnownBug", bugId);
        }
    }
}