using Living.Domain.Features.Users.Models;

namespace Living.Application.UseCases.Users.Me;
public record GetCurrentUserQuery : IRequest<BaseResponse<UserItemDetails>>;
