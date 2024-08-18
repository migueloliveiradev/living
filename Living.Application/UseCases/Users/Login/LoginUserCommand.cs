namespace Living.Application.UseCases.Users.Login;
public class LoginUserCommand : IRequest<BaseResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}