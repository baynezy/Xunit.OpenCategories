namespace Xunit.OpenCategories.UnitTests;

public class CategoryAttributeTests
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
}