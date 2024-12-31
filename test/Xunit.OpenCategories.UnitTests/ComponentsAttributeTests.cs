using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class ComponentsAttributeTests
{
    [Fact]
    [Components]
    public void Components()
    {
        var testMethod = typeof(ComponentsAttributeTests).GetMethod(nameof(Components));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ComponentsAttribute>();
    }

    [Fact]
    [Components("Component A")]
    public void ComponentsWithSingleName()
    {
        var testMethod = typeof(ComponentsAttributeTests).GetMethod(nameof(ComponentsWithSingleName));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ComponentsAttribute>()
            .Which.ComponentNames.Should().Contain("Component A")
            .And.HaveCount(1);
    }

    [Fact]
    [Components("Component A", "Component B")]
    public void ComponentsWithTwoNames()
    {
        var testMethod = typeof(ComponentsAttributeTests).GetMethod(nameof(ComponentsWithTwoNames));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ComponentsAttribute>()
            .Which.ComponentNames.Should().Contain("Component A")
            .And.Contain("Component B")
            .And.HaveCount(2);
    }

    [Fact]
    [Components("Component A", "Component B", "Component C")]
    public void ComponentsWithMultipleNames()
    {
        var testMethod = typeof(ComponentsAttributeTests).GetMethod(nameof(ComponentsWithMultipleNames));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ComponentsAttribute>()
            .Which.ComponentNames.Should().Contain("Component A")
            .And.Contain("Component B")
            .And.Contain("Component C")
            .And.HaveCount(3);
    }
}