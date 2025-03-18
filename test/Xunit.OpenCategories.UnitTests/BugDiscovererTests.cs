using Xunit.Abstractions;

namespace Xunit.OpenCategories.UnitTests;

public class BugDiscovererTests : BaseDiscovererTests<BugDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsBugId_WhenBugIdIsProvided()
    {
        // arrange
        Substitute.For<IAttributeInfo>();
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("BUG-123");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Bug", "BUG-123"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenBugIdIsNull()
    {
        // arrange
        Substitute.For<IAttributeInfo>();
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns((string)null!);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().NotContain(kv => kv.Key == "Bug");
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenBugIdIsWhitespace()
    {
        // arrange
        Substitute.For<IAttributeInfo>();
        MockTraitAttribute.GetNamedArgument<string>("Id").Returns("   ");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().NotContain(kv => kv.Key == "Bug");
    }

    [Fact]
    public void GetTraits_AlwaysReturnsCategoryBug()
    {
        // arrange
        Substitute.For<IAttributeInfo>();

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Bug"));
    }
}