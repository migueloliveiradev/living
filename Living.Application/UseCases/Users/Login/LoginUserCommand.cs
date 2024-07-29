using FluentValidation;
using Living.Domain.Entities.Users.Models;

namespace Living.Application.UseCases.Users.Login;
public class LoginUserCommand : IRequest<BaseResponse<UserLoginResponse>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public bool UseCookies { get; set; } = true;
}

public class LoginCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithErrorCode("IS_REQUIRED")
            .EmailAddress().WithErrorCode("IS_EMAIL");
        RuleFor(x => x.Password)
            .NotEmpty().WithErrorCode("IS_REQUIRED");
    }
}