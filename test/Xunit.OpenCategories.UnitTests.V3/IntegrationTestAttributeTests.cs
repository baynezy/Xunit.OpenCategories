using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class IntegrationTestAttributeTests : CategoryOnlyTests<IntegrationTestAttribute>
{
    [Fact]
    [IntegrationTest]
    public void IntegrationTest()
    {
        var testMethod = typeof(IntegrationTestAttributeTests).GetMethod(nameof(IntegrationTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<IntegrationTestAttribute>();
    }

    protected override string AttributeCategory => "IntegrationTest";
}