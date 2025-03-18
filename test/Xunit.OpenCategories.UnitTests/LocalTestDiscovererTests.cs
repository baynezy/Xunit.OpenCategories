namespace Xunit.OpenCategories.UnitTests;

public class LocalTestDiscovererTests : BaseDiscovererTests<LocalTestDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryLocalTest()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "LocalTest"));
    }

    [Fact]
    public void GetTraits_ReturnsLocalTest_WhenIdIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("Local123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("LocalTest", "Local123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnLocalTest_WhenIdIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "LocalTest");
    }

    [Fact]
    public void GetTraits_DoesNotReturnLocalTest_WhenIdIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "LocalTest");
    }
}