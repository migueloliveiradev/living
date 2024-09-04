using Living.Domain.Features.Posts.Enums;

namespace Living.Application.UseCases.Posts.Create;
public class CreatePostCommand : IRequest<BaseResponse<Guid>>
{
    public string Content { get; set; }
    public PostAccess Access { get; set; }
}
