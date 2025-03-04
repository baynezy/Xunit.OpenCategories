namespace Xunit.OpenCategories.UnitTests;

public class ServicesAttributeTests
{

    [Fact]
    [Services]
    public void ServicesWithNoName_ShouldFailByDesign()
    {
        var testMethod = typeof(ServicesAttributeTests).GetMethod(nameof(ServicesWithNoName_ShouldFailByDesign));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ServicesAttribute>();
    }

    [Fact]
    [Services("Service A")]
    public void ServicesWithSingleName()
    {
        var testMethod = typeof(ServicesAttributeTests).GetMethod(nameof(ServicesWithSingleName));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ServicesAttribute>()
            .Which.ServiceNames.Should().Contain("Service A")
            .And.HaveCount(1);
    }

    [Fact]
    [Services("Service A", "Service B")]
    public void ServicesWithTwoNames()
    {
        var testMethod = typeof(ServicesAttributeTests).GetMethod(nameof(ServicesWithTwoNames));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ServicesAttribute>()
            .Which.ServiceNames.Should().Contain("Service A")
            .And.Contain("Service B")
            .And.HaveCount(2);
    }

    [Fact]
    [Services("Service A", "Service B", "Service C")]
    public void ServicesWithMultipleNames()
    {
        var testMethod = typeof(ServicesAttributeTests).GetMethod(nameof(ServicesWithMultipleNames));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ServicesAttribute>()
            .Which.ServiceNames.Should().Contain("Service A")
            .And.Contain("Service B")
            .And.Contain("Service C")
            .And.HaveCount(3);
    }
}