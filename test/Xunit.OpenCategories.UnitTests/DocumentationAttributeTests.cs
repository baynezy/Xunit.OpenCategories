namespace Xunit.OpenCategories.UnitTests;

public class DocumentationAttributeTests
{
    [Fact]
    [Documentation]
    public void Documentation()
    {
        var testMethod = typeof(DocumentationAttributeTests).GetMethod(nameof(Documentation));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<DocumentationAttribute>();
    }

    [Fact]
    [Documentation(666)]
    public void Documentation_Integer()
    {
        var testMethod = typeof(DocumentationAttributeTests).GetMethod(nameof(Documentation_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<DocumentationAttribute>()
            .Which.WorkItemId.Should().Be("666");
    }

    [Fact]
    [Documentation("666 a")]
    public void Documentation_String()
    {
        var testMethod = typeof(DocumentationAttributeTests).GetMethod(nameof(Documentation_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<DocumentationAttribute>()
            .Which.WorkItemId.Should().Be("666 a");
    }
}