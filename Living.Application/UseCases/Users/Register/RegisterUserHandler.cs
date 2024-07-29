using Living.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace Living.Application.UseCases.Users.Register;
public class RegisterUserHandler(UserManager<User> userManager) : IRequestHandler<RegisterUserCommand, BaseResponse<Guid>>
{
    public async Task<BaseResponse<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToUser();

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return new(result.Errors);

        return new(user.Id);
    }
}
