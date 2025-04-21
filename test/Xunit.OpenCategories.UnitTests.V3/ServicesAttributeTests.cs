using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class ServicesAttributeTests
{
    [Fact]
    public void ServicesWithNoName_ShouldThrowArgumentException()
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
            .Which.ServiceNames.Should()
            .Contain("Service A")
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
            .Which.ServiceNames.Should()
            .Contain("Service A")
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
            .Which.ServiceNames.Should()
            .Contain("Service A")
            .And.Contain("Service B")
            .And.Contain("Service C")
            .And.HaveCount(3);
    }

    [Fact]
    public void WhenServicesAreProvided_ThenReturnsServices()
    {
        // arrange
        var attribute = new ServicesAttribute("Service A", "Service B");

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Where(kv => kv.Key.Equals("Service") && kv.Value.Equals("Service A"))
            .Should()
            .ContainSingle();
        traits.Where(kv => kv.Key.Equals("Service") && kv.Value.Equals("Service B"))
            .Should()
            .ContainSingle();
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("")]
    public void WhenServiceNameIsEmptyOrWhitespace_ThenReturnNoServices(string name)
    {
        // arrange
        var attribute = new ServicesAttribute(name);

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should()
            .NotContain(kv => kv.Key == "Service");
    }

    [Theory]
    [InlineData("Service A", "Service B")]
    [InlineData("Service A", "Service B, Service C")]
    public void RegardlessOfServices_ThenShouldHaveCategoryOfService(params string[] names)
    {
        // arrange
        var attribute = new ServicesAttribute(names);

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should()
            .Contain(new KeyValuePair<string, string>("Category", "Service"));
    }
}