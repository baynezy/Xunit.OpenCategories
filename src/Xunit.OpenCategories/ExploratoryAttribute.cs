using System;
using System.Collections.Generic;

namespace Xunit.OpenCategories;

/// <summary>
/// For tests that have an exploratory purpose like trying out an unknown API. Not necessarily relating to your own code.
/// </summary>
/// <example>Trying out LINQ for the first time, writing a piece of code to understand IEnumerable.Take and Skip.</example>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ExploratoryAttribute : BaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExploratoryAttribute"/> class with a specified work item ID.
    /// </summary>
    /// <param name="workItemId">The work item ID associated with the exploratory test.</param>
    public ExploratoryAttribute(string workItemId)
    {
        WorkItemId = workItemId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExploratoryAttribute"/> class with a specified work item ID.
    /// </summary>
    /// <param name="workItemId">The work item ID associated with the exploratory test.</param>
    public ExploratoryAttribute(long workItemId)
    {
        WorkItemId = workItemId.ToString();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExploratoryAttribute"/> class.
    /// </summary>
    public ExploratoryAttribute()
    {
    }

    /// <summary>
    /// Gets the work item ID associated with the exploratory test.
    /// </summary>
    public string WorkItemId { get; }

    /// <inheritdoc />
    protected override void OptionalTraits(List<KeyValuePair<string, string>> traits)
    {
        AddOptionalTrait(traits, "Exploratory", WorkItemId);
    }

    /// <inheritdoc />
    protected override void MandatoryTraits(List<KeyValuePair<string, string>> traits)
    {
        AddCategory(traits, "Exploratory");
    }
}