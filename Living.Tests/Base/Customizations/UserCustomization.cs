using AutoFixture;
using Living.Application.UseCases.Users.Register;
using System.Net.Mail;

namespace Living.Tests.Base.Customizations;
public static class UserCustomization
{
    public static IFixture CustomizeUser(this IFixture fixture)
    {
        fixture.Customize<RegisterUserCommand>(composer =>
            composer
                .With(p => p.Username, fixture.Create<string>()[..20])
                .With(p => p.Email, fixture.Create<MailAddress>().Address)
        );

        return fixture;
    }
}
