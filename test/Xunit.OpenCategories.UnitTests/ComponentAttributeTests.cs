using System.Collections.Generic;
using FluentAssertions;

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
    
    [Fact]
    public void WhenComponentNameIsProvided_ThenReturnsComponentName()
    {
        // arrange
        var componentAttribute = new ComponentAttribute("Service X");
        
        // act
        var traits = componentAttribute.GetTraits();
        
        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Component", "Service X"));
    }
    
    [Theory]
    [InlineData("   ")]
    [InlineData("")]
    [InlineData(null)]
    public void WhenComponentNameIsNullOrWhitespace_ThenReturnNoComponent(string componentName)
    {
        // arrange
        var componentAttribute = new ComponentAttribute(componentName);
        
        // act
        var traits = componentAttribute.GetTraits();
        
        // assert
        traits.Should().NotContain(kv => kv.Key == "Component");
    }
    
    [Fact]
    public void WhenNoComponentName_ThenReturnCategoryComponent()
    {
        // arrange
        var componentAttribute = new ComponentAttribute();
        
        // act
        var traits = componentAttribute.GetTraits();
        
        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Component"));
    }

    [Theory]
    [InlineData("123")]
    [InlineData(null)]
    [InlineData("    ")]
    public void WhenComponentNameIsProvided_ThenReturnsCategoryComponent(string componentName)
    {
        // arrange
        var componentAttribute = new ComponentAttribute(componentName);
        
        // act
        var traits = componentAttribute.GetTraits();
        
        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", "Component"));
    }
}