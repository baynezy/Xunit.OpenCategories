namespace Xunit.OpenCategories.UnitTests;

public class AuthorDiscovererTests : BaseDiscovererTests<AuthorDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsAuthorName_WhenAuthorNameIsProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("AuthorName").Returns("John Doe");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Author", "John Doe"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenAuthorNameIsNull()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("AuthorName").Returns((string) null!);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().BeEmpty();
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenAuthorNameIsWhitespace()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("AuthorName").Returns("   ");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().BeEmpty();
    }
}