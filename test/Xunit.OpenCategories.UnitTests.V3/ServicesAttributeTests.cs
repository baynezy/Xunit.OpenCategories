using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class ServicesAttributeTests
{
    [Fact]
    public void ServicesWithNoName()
    {
        var act = () => new ServicesAttribute();

        act.Should()
            .Throw<ArgumentException>()
            .WithMessage(
                "Services attribute is used without specifying a service. At least one service name must be provided. (Parameter 'names')");
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