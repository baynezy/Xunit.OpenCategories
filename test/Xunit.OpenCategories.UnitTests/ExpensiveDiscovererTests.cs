namespace Xunit.OpenCategories.UnitTests;

public class ExpensiveDiscovererTests : BaseDiscovererTests<ExpensiveDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryExpensive()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Expensive"));
    }
}