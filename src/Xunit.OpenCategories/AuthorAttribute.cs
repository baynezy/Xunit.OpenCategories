using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify the author of a test class or method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorAttribute"/> class.
        /// </summary>
        /// <param name="authorName">The name of the author.</param>
        public AuthorAttribute(string authorName)
        {
            AuthorName = authorName;
        }

        /// <summary>
        /// Gets the name of the author.
        /// </summary>
        public string AuthorName { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(AuthorName))
            {
                traits.Add(new KeyValuePair<string, string>("Author", AuthorName));
            }

            return traits;
        }
    }
}