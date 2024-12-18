using System.Collections.Generic;
using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class SystemTestAttributeTests : OptionalIdTests<SystemTestAttribute>
{
    [Fact]
    [SystemTest]
    public void SystemTest()
    {
        var testMethod = typeof(SystemTestAttributeTests).GetMethod(nameof(SystemTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SystemTestAttribute>();
    }

    [Fact]
    [SystemTest(666)]
    public void SystemTest_Integer()
    {
        var testMethod = typeof(SystemTestAttributeTests).GetMethod(nameof(SystemTest_Integer));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SystemTestAttribute>()
            .Which.Id.Should().Be("666");
    }

    [Fact]
    [SystemTest("666 a")]
    public void SystemTest_String()
    {
        var testMethod = typeof(SystemTestAttributeTests).GetMethod(nameof(SystemTest_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SystemTestAttribute>()
            .Which.Id.Should().Be("666 a");
    }

    protected override string AttributeCategory => "SystemTest";
    protected override string PropertyName => "SystemTest";
    protected override SystemTestAttribute CreateAttributeWithStringProperty(string value) => new(value);
    protected override SystemTestAttribute CreateAttributeWithStringProperty(long value) => new(value);
}