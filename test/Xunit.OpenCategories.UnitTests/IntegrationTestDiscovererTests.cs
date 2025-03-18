namespace Xunit.OpenCategories.UnitTests;

public class IntegrationTestDiscovererTests : BaseDiscovererTests<IntegrationTestDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryIntegrationTest()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "IntegrationTest"));
    }
}