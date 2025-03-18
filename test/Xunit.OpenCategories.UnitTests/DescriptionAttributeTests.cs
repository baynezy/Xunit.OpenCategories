namespace Xunit.OpenCategories.UnitTests;

public class DescriptionAttributeTests
{
    [Fact]
    [Description("All your base are belong to us")]
    public void Description()
    {
        var testMethod = typeof(DescriptionAttributeTests).GetMethod(nameof(Description));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<DescriptionAttribute>()
            .Which.Description.Should().Be("All your base are belong to us");
    }
}