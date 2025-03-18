using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class CategoryAttributeTests : StringPropertyOnlyTests<CategoryAttribute>
{
    [Fact]
    [Category("CategoryName")]
    public void Category_String()
    {
        var testMethod = typeof(CategoryAttributeTests).GetMethod(nameof(Category_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<CategoryAttribute>()
            .Which.Name.Should().Be("CategoryName");
    }
    
    protected override string PropertyName => "Category";
    protected override CategoryAttribute CreateAttributeWithStringProperty(string? value) => new(value);
}