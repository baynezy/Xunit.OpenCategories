using System;
using Xunit.Sdk;

namespace Xunit.OpenCategories
{
    /// <summary>
    /// Attribute to specify that a test is an integration test.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to both classes and methods, and it supports multiple usages.
    /// </remarks>
    [TraitDiscoverer(IntegrationTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class IntegrationTestAttribute : Attribute, ITraitAttribute
    {
    }
}