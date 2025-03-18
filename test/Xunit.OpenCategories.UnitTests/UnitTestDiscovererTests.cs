namespace Xunit.OpenCategories.UnitTests;

public class UnitTestDiscovererTests : BaseDiscovererTests<UnitTestDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryUnitTest()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "UnitTest"));
    }

    [Fact]
    public void GetTraits_ReturnsUnitTest_WhenIdentifierIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("Unit123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("UnitTest", "Unit123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnUnitTest_WhenIdentifierIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "UnitTest");
    }

    [Fact]
    public void GetTraits_DoesNotReturnUnitTest_WhenIdentifierIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "UnitTest");
    }
}