using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// For failing tests relating to known bugs that should not fail a build.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class KnownBugAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KnownBugAttribute"/> class with a specified bug ID.
        /// </summary>
        /// <param name="id">The ID of the known bug associated with the test.</param>
        public KnownBugAttribute(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownBugAttribute"/> class with a specified bug ID.
        /// </summary>
        /// <param name="id">The ID of the known bug associated with the test.</param>
        public KnownBugAttribute(long id)
        {
            Id = id.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownBugAttribute"/> class.
        /// </summary>
        public KnownBugAttribute()
        {
        }

        /// <summary>
        /// Gets the ID of the known bug associated with the test.
        /// </summary>
        public string Id { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();
            var category = new KeyValuePair<string,string>("Category", "KnownBug");
            traits.Add(category);
            
            if (!string.IsNullOrWhiteSpace(Id))
            {
                traits.Add(new KeyValuePair<string, string>("KnownBug", Id));
            }
            
            return traits;
        }
    }
}