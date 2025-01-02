using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit.v3;

namespace Xunit.OpenCategories.UnitTests;

public abstract class CategoryOnlyTests<TAttribute> where TAttribute : Attribute, ITraitAttribute, new()
{
    protected abstract string AttributeCategory { get; }

    [Fact]
    public void Attribute_ShouldReturnCategory()
    {
        // arrange
        var attribute = new TAttribute();
        
        // act
        var traits = attribute.GetTraits();
        
        // assert
        traits.Should().Contain(new KeyValuePair<string, string>("Category", AttributeCategory));
    }
}