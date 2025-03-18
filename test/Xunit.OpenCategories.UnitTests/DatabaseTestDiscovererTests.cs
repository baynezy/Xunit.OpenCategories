namespace Xunit.OpenCategories.UnitTests;

public class DatabaseTestDiscovererTests : BaseDiscovererTests<DatabaseTestDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryDatabaseTest()
    {
        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", "DatabaseTest"));
    }
}