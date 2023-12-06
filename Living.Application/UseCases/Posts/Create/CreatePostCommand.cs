using Living.Domain.Entity.Posts;
using Living.Domain.Entity.Posts.Enums;

namespace Living.Application.UseCases.Posts.Create;
public class CreatePostCommand : IRequest<BaseResponse<Guid>>
{
    public string Content { get; set; }
    public PostAccess Access { get; set; }

#warning add upload attachments
}
