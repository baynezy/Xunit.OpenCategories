using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class FeatureAttributeTests : OptionalIdTests<FeatureAttribute>
{
    [Fact]
    [Feature]
    public void Feature()
    {
        var testMethod = typeof(FeatureAttributeTests).GetMethod(nameof(Feature));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<FeatureAttribute>();
    }

    [Fact, IntegrationTests]
    [Feature(888)]
    public void FeatureWithId_Integer()
    {
        var testMethod = typeof(FeatureAttributeTests).GetMethod(nameof(FeatureWithId_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<IntegrationTestsAttribute>()
            .And.BeDecoratedWith<FeatureAttribute>()
            .Which.Identifier.Should().Be("888");
    }

    [Fact, IntegrationTests]
    [Feature("888")]
    public void FeatureWithId_String()
    {
        var testMethod = typeof(FeatureAttributeTests).GetMethod(nameof(FeatureWithId_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<IntegrationTestsAttribute>()
            .And.BeDecoratedWith<FeatureAttribute>()
            .Which.Identifier.Should().Be("888");
    }

    protected override string AttributeCategory => "Feature";
    protected override string PropertyName => "Feature";
    protected override FeatureAttribute CreateAttributeWithStringProperty(string value) => new(value);
    protected override FeatureAttribute CreateAttributeWithStringProperty(long value) => new(value);
}