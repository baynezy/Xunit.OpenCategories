using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

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