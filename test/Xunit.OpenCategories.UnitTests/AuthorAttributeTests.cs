using FluentAssertions;

namespace Xunit.OpenCategories.UnitTests;

public class AuthorAttributeTests : StringPropertyOnlyTests<AuthorAttribute>
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

    protected override string PropertyName => "Author";
    protected override AuthorAttribute CreateAttributeWithStringProperty(string value) => new(value);
}