using System.Collections.Generic;

namespace Xunit.OpenCategories.Core
{
    /// <summary>
    /// Contains constants and utility methods for working with traits.
    /// </summary>
    public static class TraitConstants
    {
        /// <summary>
        /// Key for category traits.
        /// </summary>
        public const string CategoryKey = "Category";

        /// <summary>
        /// Value for unit test category.
        /// </summary>
        public const string UnitTestCategory = "UnitTest";
        
        /// <summary>
        /// Value for integration test category.
        /// </summary>
        public const string IntegrationTestCategory = "IntegrationTest";
        
        /// <summary>
        /// Value for system test category.
        /// </summary>
        public const string SystemTestCategory = "SystemTest";
        
        /// <summary>
        /// Value for database test category.
        /// </summary>
        public const string DatabaseTestCategory = "DatabaseTest";
        
        /// <summary>
        /// Value for snapshot test category.
        /// </summary>
        public const string SnapshotTestCategory = "SnapshotTest";
        
        /// <summary>
        /// Value for expensive category.
        /// </summary>
        public const string ExpensiveCategory = "Expensive";
        
        /// <summary>
        /// Value for local test category.
        /// </summary>
        public const string LocalTestCategory = "LocalTest";
        
        /// <summary>
        /// Value for author category.
        /// </summary>
        public const string AuthorCategory = "Author";
        
        /// <summary>
        /// Value for bug category.
        /// </summary>
        public const string BugCategory = "Bug";
        
        /// <summary>
        /// Value for known bug category.
        /// </summary>
        public const string KnownBugCategory = "KnownBug";
        
        /// <summary>
        /// Value for category category.
        /// </summary>
        public const string CategoryCategory = "Category";
        
        /// <summary>
        /// Value for component category.
        /// </summary>
        public const string ComponentCategory = "Component";
        
        /// <summary>
        /// Value for components category.
        /// </summary>
        public const string ComponentsCategory = "Components";
        
        /// <summary>
        /// Value for services category.
        /// </summary>
        public const string ServicesCategory = "Services";
        
        /// <summary>
        /// Value for description category.
        /// </summary>
        public const string DescriptionCategory = "Description";
        
        /// <summary>
        /// Value for documentation category.
        /// </summary>
        public const string DocumentationCategory = "Documentation";
        
        /// <summary>
        /// Value for exploratory category.
        /// </summary>
        public const string ExploratoryCategory = "Exploratory";
        
        /// <summary>
        /// Value for feature category.
        /// </summary>
        public const string FeatureCategory = "Feature";
        
        /// <summary>
        /// Value for specification category.
        /// </summary>
        public const string SpecificationCategory = "Specification";
        
        /// <summary>
        /// Value for test case category.
        /// </summary>
        public const string TestCaseCategory = "TestCase";
        
        /// <summary>
        /// Value for user story category.
        /// </summary>
        public const string UserStoryCategory = "UserStory";
        
        /// <summary>
        /// Value for work item category.
        /// </summary>
        public const string WorkItemCategory = "WorkItem";
    }
    
    /// <summary>
    /// Contains utility methods for working with traits.
    /// </summary>
    public static class TraitUtility
    {
        /// <summary>
        /// Adds a category trait to the provided list.
        /// </summary>
        /// <param name="traits">The list to which the trait will be added.</param>
        /// <param name="value">The value of the trait.</param>
        public static void AddCategory(ICollection<KeyValuePair<string, string>> traits, string value)
        {
            traits.Add(new KeyValuePair<string, string>(TraitConstants.CategoryKey, value));
        }
        
        /// <summary>
        /// Adds an optional trait to the provided list if the value is not null or whitespace.
        /// </summary>
        /// <param name="traits">The list to which the trait will be added.</param>
        /// <param name="name">The name of the trait.</param>
        /// <param name="value">The value of the trait.</param>
        public static void AddOptionalTrait(ICollection<KeyValuePair<string, string>> traits, string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                traits.Add(new KeyValuePair<string, string>(name, value));
            }
        }
    }
}