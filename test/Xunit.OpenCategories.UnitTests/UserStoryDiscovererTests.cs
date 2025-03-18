namespace Xunit.OpenCategories.UnitTests;

public class UserStoryDiscovererTests : BaseDiscovererTests<UserStoryDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryUserStory()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "UserStory"));
    }

    [Fact]
    public void GetTraits_ReturnsUserStory_WhenIdentifierIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("US-123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("UserStory", "US-123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnUserStory_WhenIdentifierIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "UserStory");
    }

    [Fact]
    public void GetTraits_DoesNotReturnUserStory_WhenIdentifierIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("Identifier").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "UserStory");
    }
}