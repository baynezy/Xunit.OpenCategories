namespace Xunit.OpenCategories.UnitTests;

public class UserStoryAttributeTests
{
    [Fact]
    [UserStory]
    public void UserStory()
    {
        var testMethod = typeof(UserStoryAttributeTests).GetMethod(nameof(UserStory));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<UserStoryAttribute>();
    }
        
    [Fact]
    [UserStory("UserStoryName")]
    public void UserStory_String()
    {
        var testMethod = typeof(UserStoryAttributeTests).GetMethod(nameof(UserStory_String));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<UserStoryAttribute>()
            .Which.Identifier.Should().Be("UserStoryName");
    }
        
    [Fact]
    [UserStory(999)]
    public void UserStory_Long()
    {
        var testMethod = typeof(UserStoryAttributeTests).GetMethod(nameof(UserStory_Long));
        testMethod.Should()
            .BeDecoratedWith<FactAttribute>()
            .And.BeDecoratedWith<UserStoryAttribute>()
            .Which.Identifier.Should().Be("999");
    }
}