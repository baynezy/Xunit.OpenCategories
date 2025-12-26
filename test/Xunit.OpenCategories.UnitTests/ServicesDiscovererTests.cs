namespace Xunit.OpenCategories.UnitTests;

public class ServicesDiscovererTests : BaseDiscovererTests<ServicesDiscoverer>
{
    [Fact]
    public void GetTraits_AlwaysReturnsCategoryServices()
    {
        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should()
            .Contain(new KeyValuePair<string, string>("Category", "Services"));
    }

    [Fact]
    public void GetTraits_ReturnsServiceName_WhenOneServiceNameIsProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ServiceNames")
            .Returns(["Authentication"]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        traits.Should()
            .Contain(new KeyValuePair<string, string>("Service", "Authentication"));
    }

    [Fact]
    public void GetTraits_ReturnsServiceNames_WhenMultipleServiceNamesAreProvided()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ServiceNames")
            .Returns(["Authentication", "DataProcessing"]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        var keyValuePairs = traits as KeyValuePair<string, string>[] ?? traits.ToArray();
        keyValuePairs.ToList()[1]
            .Should()
            .Be(new KeyValuePair<string, string>("Service", "Authentication"));
        keyValuePairs.ToList()[2]
            .Should()
            .Be(new KeyValuePair<string, string>("Service", "DataProcessing"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenServiceNamesIsNull()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ServiceNames")
            .Returns([null!]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        var keyValuePairs = traits as KeyValuePair<string, string>[] ?? traits.ToArray();
        keyValuePairs.Should().HaveCount(1);
        keyValuePairs[0]
            .Should()
            .Be(new KeyValuePair<string, string>("Category", "Services"));
    }

    [Fact]
    public void GetTraits_ReturnsEmpty_WhenServiceNamesContainOnlyWhitespaceOrEmptyStrings()
    {
        // arrange
        MockTraitAttribute.GetNamedArgument<string[]>("ServiceNames")
            .Returns(["   ", ""]);

        // act
        var traits = Discoverer.GetTraits(MockTraitAttribute);

        // assert
        var keyValuePairs = traits as KeyValuePair<string, string>[] ?? traits.ToArray();
        keyValuePairs.Should().HaveCount(1);
        keyValuePairs[0]
            .Should()
            .Be(new KeyValuePair<string, string>("Category", "Services"));
    }
}