using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class DescriptionAttributeTests : StringPropertyOnlyTests<DescriptionAttribute>
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
    
    protected override string PropertyName => "Description";
    protected override DescriptionAttribute CreateAttributeWithStringProperty(string value) => new(value);
}