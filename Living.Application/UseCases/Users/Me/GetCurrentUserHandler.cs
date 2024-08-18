using Living.Domain.Features.Users.Constants;
using Living.Domain.Features.Users.Extensions;
using Living.Domain.Features.Users.Models;

namespace Living.Application.UseCases.Users.Me;
public class GetCurrentUserHandler(IUserContext context, IUserRepository userRepository)
    : IRequestHandler<GetCurrentUserQuery, BaseResponse<UserItemDetails>>
{
    public async Task<BaseResponse<UserItemDetails>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .Query()
            .ProjectToItemDetails()
            .FirstOrDefaultAsync(x => x.Id == context.UserId, cancellationToken);

        if (user is null)
            return new(UserErrors.NOT_FOUND);

        return new(user);
    }
}
