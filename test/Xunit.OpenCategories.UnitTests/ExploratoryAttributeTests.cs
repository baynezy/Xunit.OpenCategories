using System.Collections.Generic;
using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class ExploratoryAttributeTests : OptionalIdTests<ExploratoryAttribute>
{
    [Fact]
    [Exploratory]
    public void Exploratory()
    {
        var testMethod = typeof(ExploratoryAttributeTests).GetMethod(nameof(Exploratory));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ExploratoryAttribute>();
    }

    [Fact]
    [Exploratory(666)]
    public void Exploratory_Integer()
    {
        var testMethod = typeof(ExploratoryAttributeTests).GetMethod(nameof(Exploratory_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ExploratoryAttribute>()
            .Which.WorkItemId.Should().Be("666");
    }

    [Fact]
    [Exploratory("666 a")]
    public void Exploratory_String()
    {
        var testMethod = typeof(ExploratoryAttributeTests).GetMethod(nameof(Exploratory_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<ExploratoryAttribute>()
            .Which.WorkItemId.Should().Be("666 a");
    }

    protected override string AttributeCategory => "Exploratory";
    protected override string PropertyName => "Exploratory";
    protected override ExploratoryAttribute CreateAttributeWithStringProperty(string value) => new(value);
    protected override ExploratoryAttribute CreateAttributeWithStringProperty(long value) => new(value);
}