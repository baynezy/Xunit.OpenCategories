namespace Xunit.OpenCategories.UnitTests;

public class ExploratoryDiscovererTests : BaseDiscovererTests<ExploratoryDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryExploratory()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Exploratory"));
    }

    [Fact]
    public void GetTraits_ReturnsExploratory_WhenWorkItemIdIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns("12345");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Exploratory", "12345"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnExploratory_WhenWorkItemIdIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Exploratory");
    }

    [Fact]
    public void GetTraits_DoesNotReturnExploratory_WhenWorkItemIdIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Exploratory");
    }
}