namespace Xunit.OpenCategories.UnitTests;

public class SnapshotTestDiscovererTests : BaseDiscovererTests<SnapshotTestDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategorySnapshotTest()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "SnapshotTest"));
    }
}