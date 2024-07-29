using Living.Shared.Extensions;

namespace Living.Tests.Unit.Shared.Extensions;
public class StringExtensionsTests
{
    [Theory]
    [InlineData("WARD_VS_VITAL_SIGNS", "WardVsVitalSigns")]
    [InlineData("Who am I?", "WhoAmI")]
    [InlineData("I ate before you got here", "IAteBeforeYouGotHere")]
    [InlineData("Hello|Who|Am|I?", "HelloWhoAmI")]
    [InlineData("Live long and prosper", "LiveLongAndProsper")]
    [InlineData("Lorem ipsum dolor...", "LoremIpsumDolor")]
    [InlineData("CoolSP", "CoolSp")]
    [InlineData("AB9CD", "Ab9Cd")]
    [InlineData("CCCTrigger", "CccTrigger")]
    [InlineData("CIRC", "Circ")]
    [InlineData("ID_SOME", "IdSome")]
    [InlineData("ID_SomeOther", "IdSomeOther")]
    [InlineData("ID_SOMEOther", "IdSomeOther")]
    [InlineData("CCC_SOME_2Phases", "CccSome2Phases")]
    [InlineData("AlreadyGoodPascalCase", "AlreadyGoodPascalCase")]
    [InlineData("999 999 99 9 ", "999999999")]
    [InlineData("1 2 3 ", "123")]
    [InlineData("1 AB cd EFDDD 8", "1AbCdEfddd8")]
    [InlineData("INVALID VALUE AND _2THINGS", "InvalidValueAnd2Things")]
    public void ToPascalCase_ShouldReturnPascalCase(string value, string expectedValue)
    {
        var result = value.ToPascalCase();

        result.Should().Be(expectedValue);
    }
}
