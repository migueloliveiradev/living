using Living.Domain.Features.Users;
using Living.Domain.Features.Users.Interfaces;
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

        userRepository.Insert(user);

        user.PasswordHash = userManager.PasswordHasher.HashPassword(user, request.Password);
        user.SecurityStamp = Guid.NewGuid().ToString();

        await CommitAsync(cancellationToken);


        return new(user.Id);
    }
}
