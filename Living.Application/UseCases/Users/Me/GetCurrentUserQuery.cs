using Living.Domain.Entities.Users.Models;

namespace Living.Application.UseCases.Users.Me;
public record GetCurrentUserQuery : IRequest<BaseResponse<UserItemDetails>>;
