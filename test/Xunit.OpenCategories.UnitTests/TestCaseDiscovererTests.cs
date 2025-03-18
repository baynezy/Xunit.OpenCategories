namespace Xunit.OpenCategories.UnitTests;

public class TestCaseDiscovererTests : BaseDiscovererTests<TestCaseDiscoverer>
{
    [Fact]
    public void GetTraits_ReturnsCategoryTestCase()
    {
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("Category", "TestCase"));
    }

    [Fact]
    public void GetTraits_ReturnsTestCase_WhenTestCaseIdIsProvided()
    {
        MockTraitAttribute.GetNamedArgument<string>("TestCaseId").Returns("TC-123");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().Contain(new KeyValuePair<string, string>("TestCase", "TC-123"));
    }

    [Fact]
    public void GetTraits_DoesNotReturnTestCase_WhenTestCaseIdIsNull()
    {
        MockTraitAttribute.GetNamedArgument<string>("TestCaseId").Returns((string)null!);

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "TestCase");
    }

    [Fact]
    public void GetTraits_DoesNotReturnTestCase_WhenTestCaseIdIsWhitespace()
    {
        MockTraitAttribute.GetNamedArgument<string>("TestCaseId").Returns("   ");

        var traits = Discoverer.GetTraits(MockTraitAttribute);

        traits.Should().NotContain(kv => kv.Key == "TestCase");
    }
}