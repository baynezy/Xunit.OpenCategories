namespace Xunit.OpenCategories.UnitTests;

public class SpecificationDiscovererTests : BaseDiscovererTests<SpecificationDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategorySpecification()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Specification"));
    }

    [Fact]
    public void GetTraits_ReturnsSpecification_WhenIdentifierIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("Spec123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Specification", "Spec123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnSpecification_WhenIdentifierIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Specification");
    }

    [Fact]
    public void GetTraits_DoesNotReturnSpecification_WhenIdentifierIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Specification");
    }
}