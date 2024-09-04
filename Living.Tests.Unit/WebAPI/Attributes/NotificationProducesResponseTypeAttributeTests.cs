using Living.Tests.Unit.Base;
using Living.WebAPI.Attributes;

namespace Living.Tests.Unit.WebAPI.Attributes;
public class NotificationProducesResponseTypeAttributeTests : TestBase
{
    [Fact]
    public void NotificationProducesResponseTypeAttribute_Constructor_ShouldCreateDynamicDictionaryType()
    {
        var dicionary = new Dictionary<string, IEnumerable<string>>(StringComparer.Ordinal)
        {
            { "USER", new List<string> { "NOT_FOUND" } },
            { "NAME", new List<string> { "NAME_IS_REQUIRED", "NOT_BE_EMPTY" } }
        };

        var type = NotificationProducesResponseTypeAttribute.CreateDynamicDictionaryType(dicionary);

        type.Should().NotBeNull();
        type.GetProperties().Should().HaveCount(2);
        type.GetProperties().Select(p => p.Name).Should().BeEquivalentTo("USER", "NAME");
    }
}
