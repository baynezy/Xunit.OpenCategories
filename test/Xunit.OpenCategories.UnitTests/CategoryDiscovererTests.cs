namespace Xunit.OpenCategories.UnitTests;

public class CategoryDiscovererTests : BaseDiscovererTests<CategoryDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryName_WhenCategoryNameIsProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("Name").Returns("UnitTest");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", "UnitTest"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenCategoryNameIsNull()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("Name").Returns((string)null!);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().BeEmpty();
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenCategoryNameIsWhitespace()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string>("Name").Returns("   ");

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should().BeEmpty();
    }
}