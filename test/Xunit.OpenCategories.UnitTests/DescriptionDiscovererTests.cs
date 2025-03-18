namespace Xunit.OpenCategories.UnitTests;

public class DescriptionDiscovererTests : BaseDiscovererTests<DescriptionDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsDescription_WhenDescriptionIsProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("Description").Returns("This is a test description");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);
        
        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Description", "This is a test description"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenDescriptionIsNull()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("Description").Returns((string)null!);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().BeEmpty();
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenDescriptionIsWhitespace()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("Description").Returns("   ");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().BeEmpty();
    }
}