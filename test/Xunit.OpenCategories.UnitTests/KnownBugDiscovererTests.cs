namespace Xunit.OpenCategories.UnitTests;

public class KnownBugDiscovererTests : BaseDiscovererTests<KnownBugDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryKnownBug()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "KnownBug"));
    }

    [Fact]
    public void GetTraits_ReturnsKnownBug_WhenIdIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("BUG-123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("KnownBug", "BUG-123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnKnownBug_WhenIdIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "KnownBug");
    }

    [Fact]
    public void GetTraits_DoesNotReturnKnownBug_WhenIdIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "KnownBug");
    }
}