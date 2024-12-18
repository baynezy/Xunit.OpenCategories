using System;
using System.Collections.Generic;
using Bogus;
using FluentAssertions;
using Xunit.v3;

namespace Xunit.OpenCategories.UnitTests;

public abstract class OptionalIdTests<TAttribute> : CategoryOnlyTests<TAttribute>
    where TAttribute : Attribute, ITraitAttribute, new()
{
    private const string CategoryKey = "Category";

    [Fact]
    public void AttributeWithStringIdSetShouldReturnIdProperty()
    {
        // arrange
        var id = new Faker().Random.String();
        var attribute = CreateAttributeWithStringProperty(id);

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>(PropertyName, id));
    }

    [Fact]
    public void AttributeWithLongIdSetShouldReturnIdProperty()
    {
        // arrange
        var id = new Faker().Random.Long();
        var attribute = CreateAttributeWithStringProperty(id);

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>(PropertyName, id.ToString()));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void WhenIdIsWhitespace_ThenReturnEmptyTraits(string id)
    {
        // arrange
        var attribute = CreateAttributeWithStringProperty(id);

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should().NotContain(kv => kv.Key == PropertyName);
    }

    [Fact]
    public void WhenIdIsNotSet_ThenReturnCategory()
    {
        // arrange
        var attribute = new TAttribute();

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>(CategoryKey, AttributeCategory));
    }
    
    [Theory]
    [InlineData(777)]
    [InlineData("123")]
    [InlineData(null)]
    [InlineData("    ")]
    public void WhenIdIsProvided_ThenReturnCategory(object id)
    {
        // arrange
        var idString = id?.ToString();
        var attribute = CreateAttributeWithStringProperty(idString);

        // act
        var traits = attribute.GetTraits();

        // assert
        traits.Should().Contain(new KeyValuePair<string, string>(CategoryKey, AttributeCategory));
    }

    protected abstract string PropertyName { get; }
    protected abstract TAttribute CreateAttributeWithStringProperty(string value);
    protected abstract TAttribute CreateAttributeWithStringProperty(long value);
}