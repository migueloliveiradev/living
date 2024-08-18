using Living.Tests.Helpers;

namespace Living.Tests.Setup;

public class TestBase
{
    protected IFixture Fixture { get; } = FixtureHelper.CreateFixture();
}
