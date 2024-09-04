using Living.Application.UseCases.Users.Register;
using Living.Domain.Features.Users.Constants;
using Living.Tests.Extensions;

namespace Living.Tests.UseCases.User;

public class RegisterUserTests(WebAPIFactory webAPI) : SetupWebAPI(webAPI)
{
    [Theory, LivingAutoData]
    public async Task RegisterUser_ShouldRegister(RegisterUserCommand command)
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

    [Theory, LivingAutoData]
    public async Task RegisterUser_ShouldNotRegisterUserWithSameEmailOrUsername(RegisterUserCommand command)
    {
        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);

        response.Notifications.Should().BeEmpty();
        response.Data.Should().NotBeEmpty();

        var response2 = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);

        response2.Notifications.Should().HaveCount(2);
        response2.Notifications.Should().ContainNotification(UserErrors.EMAIL_ALREADY_IN_USE);
        response2.Notifications.Should().ContainNotification(UserErrors.USERNAME_ALREADY_IN_USE);

        var userCount = await UserRepository
            .Query()
            .CountAsync(x => x.Email == command.Email);

        userCount.Should().Be(1);
    }

    [Fact]
    public async Task RegiterUser_ShouldValidateNameIsRequired()
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .Without(x => x.Name)
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.NAME_IS_REQUIRED);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }

    [Theory]
    [InlineData("na")] // 2 characters
    [InlineData("PFa8Ax2oxa2sKZX40PGgC5BWOEFG05iT127pE074EtkUnYG3GYPFa8Ax2oxa2sKZX40PGgC5BWOEFG05iT127pE074EtkUnYG3GYA")] // 101 characters
    public async Task RegisterUser_ShouldValidateNameLength(string name)
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .With(x => x.Name, name)
            .With(p => p.Username, Fixture.Create<string>()[..20])
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.NAME_LENGTH_INVALID);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }

    [Fact]
    public async Task RegisterUser_ShouldValidateUsernameIsRequired()
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .Without(x => x.Username)
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.USERNAME_IS_REQUIRED);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }

    [Theory]
    [InlineData("use")] // 3 characters
    [InlineData("21")] // 21 characters
    public async Task RegisterUser_ShouldValidateUsernameLength(string username)
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .With(x => x.Username, username)
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.USERNAME_LENGTH_INVALID);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }

    [Fact]
    public async Task RegisterUser_ShouldValidateEmailIsRequired()
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .Without(x => x.Email)
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.EMAIL_IS_REQUIRED);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }

    [Fact]
    public async Task RegisterUser_ShouldValidateEmailLength()
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .With(x => x.Email, "ab")
            .With(p => p.Username, Fixture.Create<string>()[..20])
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.EMAIL_LENGTH_INVALID);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }

    [Fact]
    public async Task RegisterUser_ShouldValidateEmailLength2()
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .With(x => x.Email, new string(Fixture.CreateMany<char>(321).ToArray()))
            .With(p => p.Username, Fixture.Create<string>()[..20])
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.EMAIL_LENGTH_INVALID);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }

    [Fact]
    public async Task RegisterUser_ShouldValidateEmailIsEmail()
    {
        var command = Fixture.Build<RegisterUserCommand>()
            .With(x => x.Email, "invalid-email")
            .With(p => p.Username, Fixture.Create<string>()[..20])
            .Create();

        var response = await PostAsync<BaseResponse<Guid>>("api/auth/register", command);
        response.Notifications.Should().HaveCount(1);
        response.Notifications.Should().ContainNotification(UserErrors.INVALID_EMAIL);

        var user = await UserRepository
            .Query()
            .FirstOrDefaultAsync(x => x.Email == command.Email);
        user.Should().BeNull();
    }
}
