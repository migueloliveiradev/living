using Living.Domain.Entity.Posts;
using Living.Domain.Entity.Posts.Models;

namespace Living.Application.UseCases.Posts.Get;
public record GetPostCommand(Guid PostId) : IRequest<BaseResponse<PostItemGet>>;
