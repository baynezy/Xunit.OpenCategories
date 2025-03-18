namespace Xunit.OpenCategories.UnitTests;

public class ExpensiveAttributeTests
{
    [Fact]
    [Expensive]
    public void Expensive()
    {
        var testMethod = typeof(ExpensiveAttributeTests).GetMethod(nameof(Expensive));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ExpensiveAttribute>();
    }
}