namespace Xunit.OpenCategories.UnitTests;

public class DatabaseTestAttributeTests
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
}