namespace Xunit.OpenCategories.UnitTests;

public class SnapshotTestAttributeTests
{
    [Fact]
    [SnapshotTest]
    public void SnapshotTest()
    {
        var testMethod = typeof(SnapshotTestAttributeTests).GetMethod(nameof(SnapshotTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SnapshotTestAttribute>();
    }
}