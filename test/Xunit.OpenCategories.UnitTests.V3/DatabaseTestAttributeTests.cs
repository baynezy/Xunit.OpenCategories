using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class DatabaseTestAttributeTests : CategoryOnlyTests<DatabaseTestAttribute>
{
    [Fact]
    [DatabaseTest]
    public void DatabaseTest()
    {
        var testMethod = typeof(DatabaseTestAttributeTests).GetMethod(nameof(DatabaseTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<DatabaseTestAttribute>();
    }

    protected override string AttributeCategory => "DatabaseTest";
}