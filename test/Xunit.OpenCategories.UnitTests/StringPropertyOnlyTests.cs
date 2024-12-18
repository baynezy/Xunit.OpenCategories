using System;
using System.Collections.Generic;
using Bogus;
using FluentAssertions;
using Xunit.v3;

namespace Xunit.OpenCategories.UnitTests;

public abstract class StringPropertyOnlyTests<TAttribute>
    where TAttribute : Attribute, ITraitAttribute
{
    private readonly Faker _faker = new();

    protected abstract string PropertyName { get; }

    [Fact]
    public void Attribute_ShouldReturnProperty()
    {
        // arrange
        var value = _faker.Lorem.Word();
        var attribute = CreateAttributeWithStringProperty(value);

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>(PropertyName, value));
    }
    
    [Fact]
    public void WhenPropertyIsNull_ThenReturnEmptyTraits()
    {
        // arrange
        var attribute = CreateAttributeWithStringProperty(null);
        
        // act
        var traits = attribute.GetTraits();
        
        // assert
        traits.Count.Should().Be(0);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void WhenPropertyIsWhitespace_ThenReturnEmptyTraits(string value)
    {
        // arrange
        var attribute = CreateAttributeWithStringProperty(value);
        
        // act
        var traits = attribute.GetTraits();
        
        // assert
        traits.Count.Should().Be(0);
    }

    protected abstract TAttribute CreateAttributeWithStringProperty(string value);
}