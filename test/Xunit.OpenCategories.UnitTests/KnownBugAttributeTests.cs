using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class KnownBugAttributeTests : OptionalIdTests<KnownBugAttribute>
{
    [Fact]
    [KnownBug]
    public void KnownBug()
    {
        var testMethod = typeof(KnownBugAttributeTests).GetMethod(nameof(KnownBug));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<KnownBugAttribute>();
    }

    [Fact]
    [KnownBug(666)]
    public void KnownBugWithId_Integer()
    {
        var testMethod = typeof(KnownBugAttributeTests).GetMethod(nameof(KnownBugWithId_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<KnownBugAttribute>()
            .Which.Id.Should().Be("666");
    }

    [Fact]
    [KnownBug("666 a")]
    public void KnownBugWithId_String()
    {
        var testMethod = typeof(KnownBugAttributeTests).GetMethod(nameof(KnownBugWithId_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<KnownBugAttribute>()
            .Which.Id.Should().Be("666 a");
    }

    protected override string AttributeCategory => "KnownBug";
    protected override string PropertyName => "KnownBug";
    protected override KnownBugAttribute CreateAttributeWithStringProperty(string value) => new(value);
    protected override KnownBugAttribute CreateAttributeWithStringProperty(long value) => new(value);
}