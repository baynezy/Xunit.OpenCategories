namespace Xunit.OpenCategories.UnitTests;

public class WorkItemDiscovererTests : BaseDiscovererTests<WorkItemDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryWorkItem()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "WorkItem"));
    }

    [Fact]
    public void GetTraits_ReturnsWorkItem_WhenWorkItemIdIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns("WI-123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("WorkItem", "WI-123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnWorkItem_WhenWorkItemIdIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "WorkItem");
    }

    [Fact]
    public void GetTraits_DoesNotReturnWorkItem_WhenWorkItemIdIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("WorkItemId").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "WorkItem");
    }
}