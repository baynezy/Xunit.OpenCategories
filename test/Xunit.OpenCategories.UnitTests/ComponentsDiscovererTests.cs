using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;

namespace Xunit.OpenCategories.UnitTests;

public class ComponentsDiscovererTests : BaseDiscovererTests<ComponentsDiscoverer>
{
    [Fact]
    public void GetTraits_AlwaysReturnsCategoryComponents()
    {
        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Components"));
    }

    [Fact]
    public void GetTraits_ReturnsComponentsName_WhenOneComponentNameIsProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ComponentNames").Returns(["UI"]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Component", "UI"));
    }

    [Fact]
    public void GetTraits_ReturnsComponentsNames_WhenMultipleComponentNamesAreProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ComponentNames").Returns(["UI", "Database"]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.ToList()[1].Should().Be(new KeyValuePair<string, string>("Component", "UI"));
        traits.ToList()[2].Should().Be(new KeyValuePair<string, string>("Component", "Database"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenComponentNamesIsNull()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ComponentNames").Returns([null]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().NotContain(kv => kv.Key == "Component");
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenComponentNamesIsWhitespace()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ComponentNames").Returns(["   "]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().NotContain(kv => kv.Key == "Component");
    }
}