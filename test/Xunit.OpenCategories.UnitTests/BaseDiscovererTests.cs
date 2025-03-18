using Xunit.Abstractions;

namespace Xunit.OpenCategories.UnitTests;

public abstract class BaseDiscovererTests<TDiscoverer> where TDiscoverer : new()
{
    protected readonly IAttributeInfo MockTraitAttribute = Substitute.For<IAttributeInfo>();
    protected readonly TDiscoverer Discoverer = new();
}