namespace Xunit.OpenCategories.UnitTests;

public class SystemTestDiscovererTests : BaseDiscovererTests<SystemTestDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategorySystemTest()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "SystemTest"));
    }

    [Fact]
    public void GetTraits_ReturnsSystemTest_WhenIdIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("SYS-123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("SystemTest", "SYS-123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnSystemTest_WhenIdIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "SystemTest");
    }

    [Fact]
    public void GetTraits_DoesNotReturnSystemTest_WhenIdIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "SystemTest");
    }
}