namespace Xunit.OpenCategories.UnitTests;

public class FeatureDiscovererTests : BaseDiscovererTests<FeatureDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryFeature()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Feature"));
    }

    [Fact]
    public void GetTraits_ReturnsFeature_WhenIdentifierIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("Feature123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Feature", "Feature123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnFeature_WhenIdentifierIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Feature");
    }

    [Fact]
    public void GetTraits_DoesNotReturnFeature_WhenIdentifierIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Feature");
    }
}