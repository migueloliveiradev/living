using Living.Domain.Features.Users;
using Living.Domain.Features.Users.Constants;
using Living.Shared.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Living.Application.UseCases.Users.Register;
public class RegisterUserHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
    : Handler(unitOfWork), IRequestHandler<RegisterUserCommand, BaseResponse<Guid>>
{
    public async Task<BaseResponse<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToUser();

        var errors = user.IsValid();
        if (errors.Any())
            return new(errors);

        if (!user.Email.IsEmail())
            return new(UserErrors.INVALID_EMAIL);

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return new(result.Errors);

        return new(user.Id);
    }
}
