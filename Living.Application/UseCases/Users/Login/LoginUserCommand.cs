namespace Living.Application.UseCases.Users.Login;
public class LoginUserCommand : IRequest<BaseResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}