namespace Xunit.OpenCategories.V3
{
    /// <summary>
    /// Attribute to specify multiple components for a test class or method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ComponentsAttribute : BaseAttribute
    {
        private const string TraitCategoryName = "Components";
        private const string TraitName = "Component";
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentsAttribute"/> class.
        /// </summary>
        public ComponentsAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentsAttribute"/> class with component names.
        /// </summary>
        /// <param name="names"></param>
        public ComponentsAttribute(params string[] names)
        {
            ComponentNames = names;
        }

        /// <summary>
        /// Gets the names of the components.
        /// </summary>
        public string[] ComponentNames { get; } = Array.Empty<string>();

        /// <inheritdoc/>
        protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
        {
            AddCategory(traits, TraitCategoryName);
        }

        /// <inheritdoc/>
        protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
        {
            foreach (var name in ComponentNames)
            {
                AddOptionalTrait(traits, TraitName, name);
            }
        }
    }
}