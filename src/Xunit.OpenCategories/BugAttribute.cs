using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify a bug ID for a test class or method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BugAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BugAttribute"/> class with a string ID.
        /// </summary>
        /// <param name="id">The bug ID as a string.</param>
        public BugAttribute(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BugAttribute"/> class with a long ID.
        /// </summary>
        /// <param name="id">The bug ID as a long.</param>
        public BugAttribute(long id)
        {
            Id = id.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BugAttribute"/> class.
        /// </summary>
        public BugAttribute()
        {
        }

        /// <summary>
        /// Gets the bug ID.
        /// </summary>
        public string Id { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();
            var category = new KeyValuePair<string,string>("Category", "Bug");
            traits.Add(category);
            
            if (!string.IsNullOrWhiteSpace(Id))
            {
                traits.Add(new KeyValuePair<string, string>("Bug", Id));
            }
            
            return traits;
        }
    }
}