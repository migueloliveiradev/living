using FluentValidation;

namespace Living.Application.UseCases.Users.Login;
public class LoginUserCommand : IRequest<BaseResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
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