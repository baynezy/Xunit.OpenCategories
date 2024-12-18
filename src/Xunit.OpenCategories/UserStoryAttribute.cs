using System;
using System.Collections.Generic;
using Xunit.v3;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to mark a test as related to a user story.
    /// </summary>
    /// <remarks>
    /// User story attributes are used to categorize tests based on user stories.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UserStoryAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserStoryAttribute"/> class.
        /// </summary>
        public UserStoryAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStoryAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="name">The identifier associated with the user story.</param>
        public UserStoryAttribute(string name)
        {
            Identifier = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStoryAttribute"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier associated with the user story.</param>
        public UserStoryAttribute(long id)
        {
            Identifier = id.ToString();
        }

        /// <summary>
        /// Gets the identifier associated with the user story.
        /// </summary>
        public string Identifier { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
        {
            var traits = new List<KeyValuePair<string, string>>();
            var category = new KeyValuePair<string,string>("Category", "UserStory");
            traits.Add(category);
            
            if (!string.IsNullOrWhiteSpace(Identifier))
            {
                traits.Add(new KeyValuePair<string, string>("UserStory", Identifier));
            }
            
            return traits;
        }
    }
}