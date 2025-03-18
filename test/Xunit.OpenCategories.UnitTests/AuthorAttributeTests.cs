namespace Xunit.OpenCategories.UnitTests;

public class AuthorAttributeTests
{
    [Fact]
    [Author("Henry David Thoreau")]
    public void Author()
    {
        var testMethod = typeof(AuthorAttributeTests).GetMethod(nameof(Author));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<AuthorAttribute>()
            .Which.AuthorName.Should().Be("Henry David Thoreau");
    }
}