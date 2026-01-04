using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace Xunit.OpenCategories.SourceGenerators.Shared
{
    /// <summary>
    /// Options for file-based source generation.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal sealed class FileOptions
    {
        /// <summary>
        /// Gets or sets the category files to process.
        /// </summary>
        public ImmutableArray<AdditionalText> CategoryFiles { get; set; }
    }
}
