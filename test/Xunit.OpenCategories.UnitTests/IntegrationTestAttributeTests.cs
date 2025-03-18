namespace Xunit.OpenCategories.UnitTests;

public class IntegrationTestAttributeTests
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
}