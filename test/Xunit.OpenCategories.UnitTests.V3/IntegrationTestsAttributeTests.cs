using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class IntegrationTestsAttributeTests : CategoryOnlyTests<IntegrationTestsAttribute>
{
    [Fact]
    [IntegrationTests]
    public void IntegrationTest()
    {
        var testMethod = typeof(IntegrationTestsAttributeTests).GetMethod(nameof(IntegrationTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<IntegrationTestsAttribute>();
    }

    protected override string AttributeCategory => "IntegrationTest";
}