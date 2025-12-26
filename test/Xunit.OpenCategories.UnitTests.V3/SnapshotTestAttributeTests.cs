using Xunit.OpenCategories.V3;

namespace Xunit.OpenCategories.UnitTests.V3;

public class SnapshotTestAttributeTests : CategoryOnlyTests<SnapshotTestAttribute>
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

    protected override string AttributeCategory => "SnapshotTest";
}