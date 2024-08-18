using Living.Domain.Features.Users;
using Living.Domain.Features.Users.Constants;
using Living.Shared.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Living.Application.UseCases.Users.Register;
public class RegisterUserHandler(
    IUserRepository userRepository,
    UserManager<User> userManager,
    IUnitOfWork unitOfWork)
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

        if (await EmailInUseAsync(user.Email))
            return new(UserErrors.EMAIL_ALREADY_IN_USE);

        userRepository.Insert(user);

        user.PasswordHash = userManager.PasswordHasher.HashPassword(user, request.Password);
        user.SecurityStamp = Guid.NewGuid().ToString();

        await CommitAsync(cancellationToken);

        return new(user.Id);
    }

    private async Task<bool> EmailInUseAsync(string email)
    {
        return await userRepository.ExistsAsync(x => EF.Functions.ILike(x.Email, email));
    }
}
