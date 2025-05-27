using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify that a test class or method is related to database testing.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer("Xunit.OpenCategories.DatabaseTestDiscoverer", "Xunit.OpenCategories")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DatabaseTestAttribute : Attribute, ITraitAttribute
    {
    }
}