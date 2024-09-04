using Living.Application.UseCases.Users.Register;
using System.Net.Mail;

namespace Living.Tests.Helpers;
public static class FixtureHelper
{
    public static IFixture CreateFixture()
    {
        return new Fixture()
            .CustomizeUser()
            .CustomizeDateOnly();
    }

    public static IFixture CustomizeUser(this IFixture fixture)
    {
        fixture.Customize<RegisterUserCommand>(composer =>
            composer
                .With(p => p.Username, fixture.Create<string>()[..20])
                .With(p => p.Email, fixture.Create<MailAddress>().Address)
        );

        return fixture;
    }

    public static IFixture CustomizeDateOnly(this IFixture fixture)
    {
        fixture.Customize<DateOnly>(o => o.FromFactory((DateTime dt) => DateOnly.FromDateTime(dt)));

        return fixture;
    }
}
