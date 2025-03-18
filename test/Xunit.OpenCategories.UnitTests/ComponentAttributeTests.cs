namespace Xunit.OpenCategories.UnitTests;

public class ComponentAttributeTests
{
    [Fact]
    [Component]
    public void Component()
    {
        var testMethod = typeof(ComponentAttributeTests).GetMethod(nameof(Component));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ComponentAttribute>();
    }
    [Fact]
    [Component("Service X")]
    public void ComponentWithName()
    {
        var testMethod = typeof(ComponentAttributeTests).GetMethod(nameof(ComponentWithName));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ComponentAttribute>()
            .Which.ComponentName.Should().Be("Service X");
    }
}