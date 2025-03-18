using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class ExpensiveAttributeTests : CategoryOnlyTests<ExpensiveAttribute>
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

    protected override string AttributeCategory => "Expensive";
}