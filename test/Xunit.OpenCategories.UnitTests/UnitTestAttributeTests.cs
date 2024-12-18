using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class UnitTestAttributeTests : OptionalIdTests<UnitTestAttribute>
{
    [Fact]
    [UnitTest]
    public void UnitTest()
    {
        var testMethod = typeof(UnitTestAttributeTests).GetMethod(nameof(UnitTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<UnitTestAttribute>();
    }
        
    [Fact]
    [UnitTest("UnitTestName")]
    public void UnitTest_String()
    {
        var testMethod = typeof(UnitTestAttributeTests).GetMethod(nameof(UnitTest_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<UnitTestAttribute>()
            .Which.Identifier.Should().Be("UnitTestName");
    }
        
    [Fact]
    [UnitTest(999)]
    public void UnitTest_Long()
    {
        var testMethod = typeof(UnitTestAttributeTests).GetMethod(nameof(UnitTest_Long));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<UnitTestAttribute>()
            .Which.Identifier.Should().Be("999");
    }

    protected override string AttributeCategory => "UnitTest";
    protected override string PropertyName => "UnitTest";
    protected override UnitTestAttribute CreateAttributeWithStringProperty(string value) => new(value);
    protected override UnitTestAttribute CreateAttributeWithStringProperty(long value) => new(value);
}