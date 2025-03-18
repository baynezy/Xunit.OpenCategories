namespace Xunit.OpenCategories.UnitTests;

public class SystemTestAttributeTests
{
    [Fact]
    [SystemTest]
    public void SystemTest()
    {
        var testMethod = typeof(SystemTestAttributeTests).GetMethod(nameof(SystemTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SystemTestAttribute>();
    }

    [Fact]
    [SystemTest(666)]
    public void SystemTest_Integer()
    {
        var testMethod = typeof(SystemTestAttributeTests).GetMethod(nameof(SystemTest_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SystemTestAttribute>()
            .Which.Id.Should().Be("666");
    }

    [Fact]
    [SystemTest("666 a")]
    public void SystemTest_String()
    {
        var testMethod = typeof(SystemTestAttributeTests).GetMethod(nameof(SystemTest_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SystemTestAttribute>()
            .Which.Id.Should().Be("666 a");
    }
}