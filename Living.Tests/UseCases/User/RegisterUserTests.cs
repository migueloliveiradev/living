using Living.Application.UseCases.Users.Register;

namespace Living.Tests.UseCases.User;

public class RegisterUserTests(WebAPIFactory webAPI) : SetupWebAPI(webAPI)
{
    [Theory, LivingAutoData]
    public async Task RegisterUserCommand_ShouldRegister(RegisterUserCommand command)
    {
        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);

        response.Notifications.Should().BeEmpty();
        response.Data.Should().NotBeEmpty();

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Id == response.Data);

        user.Should().NotBeNull();

        user.Email.Should().Be(command.Email);
        user.Name.Should().Be(command.Name);
        user.UserName.Should().Be(command.Username);
        user.Bio.Should().Be(command.Bio);
        user.Birthday.Should().Be(command.Birthday);
    }
}
