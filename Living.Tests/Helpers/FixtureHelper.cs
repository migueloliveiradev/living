using Living.Tests.Base.Customizations;

namespace Living.Tests.Helpers;
public static class FixtureHelper
{
    public static IFixture CreateFixture()
    {
        return new Fixture()
            .CustomizeUser();
    }
}
