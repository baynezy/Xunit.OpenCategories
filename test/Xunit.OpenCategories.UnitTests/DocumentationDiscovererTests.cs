namespace Xunit.OpenCategories.UnitTests;

public class DocumentationDiscovererTests : BaseDiscovererTests<DocumentationDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryDocumentation()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Documentation"));
    }

    [Fact]
    public void GetTraits_ReturnsDocumentation_WhenWorkItemIdIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns("12345");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Documentation", "12345"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenWorkItemIdIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns((string) null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Documentation");
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenWorkItemIdIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "Documentation");
    }
}