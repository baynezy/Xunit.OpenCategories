using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify the author of a test class or method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer(AuthorDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
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
    }
}