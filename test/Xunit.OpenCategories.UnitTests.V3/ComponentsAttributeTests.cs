using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

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
            .Which.ComponentNames.Should()
            .Contain("Component A")
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
            .Which.ComponentNames.Should()
            .Contain("Component A")
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
            .Which.ComponentNames.Should()
            .Contain("Component A")
            .And.Contain("Component B")
            .And.Contain("Component C")
            .And.HaveCount(3);
    }

    [Fact]
    public void WhenComponentNamesAreProvided_ThenReturnsComponentNames()
    {
        // arrange
        var componentAttribute = new ComponentsAttribute("Component A", "Component B");

        // act
        var traits = componentAttribute.GetTraits();

        // assert
        traits.Where(kv => kv.Key.Equals("Component") && kv.Value.Equals("Component A"))
            .Should()
            .ContainSingle();
        traits.Where(kv => kv.Key.Equals("Component") && kv.Value.Equals("Component B"))
            .Should()
            .ContainSingle();
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("")]
    public void WhenComponentNamesAreWhitespace_ThenReturnNoComponent(string componentName)
    {
        // arrange
        var componentAttribute = new ComponentsAttribute(componentName);

        // act
        var traits = componentAttribute.GetTraits();

        // assert
        traits.Should()
            .NotContain(kv => kv.Key == "Component");
    }

    [Theory]
    [InlineData("Component A", "Component B")]
    [InlineData("Component A", "Component B, Component C")]
    [InlineData("")]
    public void RegardlessOrComponents_ThenShouldHaveACategoryOfComponents(params string[] componentNames)
    {
        // arrange
        var componentAttribute = new ComponentsAttribute(componentNames);

        // act
        var traits = componentAttribute.GetTraits();

        // assert
        traits.Should()
            .Contain(new KeyValuePair<string, string>("Category", "Components"));
    }
}