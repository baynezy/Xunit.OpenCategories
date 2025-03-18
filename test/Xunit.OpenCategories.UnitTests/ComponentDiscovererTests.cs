namespace Xunit.OpenCategories.UnitTests;

public class ComponentDiscovererTests : BaseDiscovererTests<ComponentDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsComponentName_WhenComponentNameIsProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("ComponentName").Returns("UI");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Component", "UI"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenComponentNameIsNull()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("ComponentName").Returns((string)null!);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().NotContain(kv => kv.Key == "Component");
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenComponentNameIsWhitespace()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("ComponentName").Returns("   ");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().NotContain(kv => kv.Key == "Component");
    }

    [Fact]
    public void GetTraits_AlwaysReturnsCategoryComponent()
    {
        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Component"));
    }
}