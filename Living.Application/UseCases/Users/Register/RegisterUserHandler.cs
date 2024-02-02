using AutoMapper;
using Living.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Living.Application.UseCases.Users.Register;
public class RegisterUserHandler(IMapper mapper, UserManager<User> userManager) : IRequestHandler<RegisterUserCommand, IResult>
{
    public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);

        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
            return Results.Ok(new BaseResponse());

        return Results.BadRequest(new BaseResponse(result.Errors));
    }
}
