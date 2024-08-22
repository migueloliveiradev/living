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
                .With(p => p.Birthday, DateOnly.FromDateTime(DateTime.UtcNow).AddYears(-20))
        );

        return fixture;
    }
}
