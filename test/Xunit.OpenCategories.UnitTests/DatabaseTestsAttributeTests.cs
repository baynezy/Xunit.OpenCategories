using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class DatabaseTestsAttributeTests : CategoryOnlyTests<DatabaseTestsAttribute>
{
    [Fact]
    [DatabaseTests]
    public void DatabaseTest()
    {
        var testMethod = typeof(DatabaseTestsAttributeTests).GetMethod(nameof(DatabaseTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<DatabaseTestsAttribute>();
    }

    protected override string AttributeCategory => "DatabaseTest";
}