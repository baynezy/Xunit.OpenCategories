using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class BugAttributeTests : OptionalIdTests<BugAttribute>
{
    [Fact]
    [Bug]
    public void Bug()
    {
        var testMethod = typeof(BugAttributeTests).GetMethod(nameof(Bug));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<BugAttribute>();
    }

    [Fact]
    [Bug(777)]
    public void BugWithId_Integer()
    {
        var testMethod = typeof(BugAttributeTests).GetMethod(nameof(BugWithId_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<BugAttribute>()
            .Which.Id.Should().Be("777");
    }

    [Fact]
    [Bug("777")]
    public void BugWithId_String()
    {
        var testMethod = typeof(BugAttributeTests).GetMethod(nameof(BugWithId_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<BugAttribute>()
            .Which.Id.Should().Be("777");
    }

    protected override string AttributeCategory => "Bug";
    protected override string PropertyName => "Bug";
    protected override BugAttribute CreateAttributeWithStringProperty(string value) => new(value);
    protected override BugAttribute CreateAttributeWithStringProperty(long value) => new(value);
}