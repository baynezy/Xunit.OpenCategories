namespace Xunit.OpenCategories.UnitTests;

public class ExploratoryAttributeTests
{
    [Fact]
    [Exploratory]
    public void Exploratory()
    {
        var testMethod = typeof(ExploratoryAttributeTests).GetMethod(nameof(Exploratory));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ExploratoryAttribute>();
    }

    [Fact]
    [Exploratory(666)]
    public void Exploratory_Integer()
    {
        var testMethod = typeof(ExploratoryAttributeTests).GetMethod(nameof(Exploratory_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ExploratoryAttribute>()
            .Which.WorkItemId.Should().Be("666");
    }

    [Fact]
    [Exploratory("666 a")]
    public void Exploratory_String()
    {
        var testMethod = typeof(ExploratoryAttributeTests).GetMethod(nameof(Exploratory_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ExploratoryAttribute>()
            .Which.WorkItemId.Should().Be("666 a");
    }
}