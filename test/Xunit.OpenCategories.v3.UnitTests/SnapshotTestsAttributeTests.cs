namespace Xunit.OpenCategories.v3.UnitTests;

public class SnapshotTestsAttributeTests : CategoryOnlyTests<SnapshotTestsAttribute>
{
    [Fact]
    [SnapshotTests]
    public void SnapshotTest()
    {
        var testMethod = typeof(SnapshotTestsAttributeTests).GetMethod(nameof(SnapshotTest));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<SnapshotTestsAttribute>();
    }

    protected override string AttributeCategory => "SnapshotTest";
}