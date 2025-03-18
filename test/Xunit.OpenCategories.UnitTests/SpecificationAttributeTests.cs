namespace Xunit.OpenCategories.UnitTests;

public class SpecificationAttributeTests
{
    [Fact]
    [Specification]
    public void Specification()
    {
        var testMethod = typeof(SpecificationAttributeTests).GetMethod(nameof(Specification));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SpecificationAttribute>();
    }
        
    [Fact]
    [Specification("SpecificationName")]
    public void Specification_String()
    {
        var testMethod = typeof(SpecificationAttributeTests).GetMethod(nameof(Specification_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SpecificationAttribute>()
            .Which.Identifier.Should().Be("SpecificationName");
    }
        
    [Fact]
    [Specification(999)]
    public void Specification_Long()
    {
        var testMethod = typeof(SpecificationAttributeTests).GetMethod(nameof(Specification_Long));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SpecificationAttribute>()
            .Which.Identifier.Should().Be("999");
    }
}