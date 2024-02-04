using AutoFixture;
using Living.Application.UseCases.Users.Register;

namespace Living.Tests.Attributes;
public class ApplicationAutoDataAttribute : AutoDataAttribute
{
    public ApplicationAutoDataAttribute() : base(() => GetFixture())
    {
    }

    private static readonly Func<IFixture> GetFixture = () =>
    {
        var fixture = new Fixture();

        fixture.Customize<RegisterUserCommand>(ob => ob.Do(x => x.Email = "miguel@gmail.com").With(p => p.Email));

        return fixture;
    };
}
