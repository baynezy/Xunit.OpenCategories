using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// For annotating tests that have a mainly documentative purpose, as sometimes a piece of code says more
    /// than a 1000 words API Documentation.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer(DocumentationDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DocumentationAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationAttribute"/> class with a specified work item ID.
        /// </summary>
        /// <param name="workItemId">The work item ID associated with the documentation.</param>
        public DocumentationAttribute(string workItemId)
        {
            WorkItemId = workItemId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationAttribute"/> class with a specified work item ID.
        /// </summary>
        /// <param name="workItemId">The work item ID associated with the documentation.</param>
        public DocumentationAttribute(long workItemId)
        {
            WorkItemId = workItemId.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationAttribute"/> class.
        /// </summary>
        public DocumentationAttribute()
        {
        }

        /// <summary>
        /// Gets the work item ID associated with the documentation.
        /// </summary>
        public string WorkItemId { get; private set; }
    }
}