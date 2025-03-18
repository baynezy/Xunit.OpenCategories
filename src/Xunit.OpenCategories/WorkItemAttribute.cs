using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// For annotating tests that relate to a specific work item, not necessarily a bug.
    /// </summary>
    [TraitDiscoverer(WorkItemDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class WorkItemAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemAttribute"/> class with a specified work item identifier.
        /// </summary>
        /// <param name="workItemId">The identifier associated with the work item.</param>
        public WorkItemAttribute(string workItemId)
        {
            WorkItemId = workItemId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemAttribute"/> class with a specified work item identifier.
        /// </summary>
        /// <param name="workItemId">The identifier associated with the work item.</param>
        public WorkItemAttribute(long workItemId)
        {
            WorkItemId = workItemId.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemAttribute"/> class.
        /// </summary>
        public WorkItemAttribute()
        {
        }

        /// <summary>
        /// Gets the identifier associated with the work item.
        /// </summary>
        public string WorkItemId { get; private set; }
    }
}