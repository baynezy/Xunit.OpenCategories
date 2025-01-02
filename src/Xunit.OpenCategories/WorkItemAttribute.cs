using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// For annotating tests that relate to a specific work item, not necessarily a bug.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class WorkItemAttribute : BaseAttribute
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
    public string WorkItemId { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "WorkItem", WorkItemId);
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "WorkItem");
    }
}