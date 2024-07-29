using Bogus;
using Living.Application.UseCases.Users.Register;
using Living.Domain.Entities.Users.Constants;

namespace Living.Tests;
internal class RegisterUserFaker : Faker<RegisterUserCommand>
{
    internal static RegisterUserFaker Instance => new();
    internal RegisterUserFaker()
    {
        RuleFor(x => x.Email, f => f.Person.Email);
        RuleFor(x => x.Password, f => Password());
        RuleFor(x => x.Name, f => f.Person.FullName);
        RuleFor(x => x.Username, f => f.Random.String2(10, UserIdentity.AllowedUserNameCharacters));
    }

    internal RegisterUserCommand GenerateUsernameInvalid()
    {
        RuleFor(x => x.Username, f => f.Random.String(3));

        return Generate();
    }

    internal RegisterUserCommand GenerateEmailInvalid()
    {
        RuleFor(x => x.Email, f => f.Random.String(3));

        return Generate();
    }

    internal RegisterUserCommand GeneratePasswordInvalid()
    {
        RuleFor(x => x.Password, f => f.Random.String(3));

        return Generate();
    }

    private static string Password()
    {
        return "ABCDefghi@012.";
    }
}
