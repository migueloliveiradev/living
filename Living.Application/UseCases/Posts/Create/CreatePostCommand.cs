using Living.Domain.Entity.Posts;

namespace Living.Application.UseCases.Posts.Create;
public class CreatePostCommand : IRequest<BaseResponse<Guid>>
{
    public string Content { get; set; }
    public PostAccess Access { get; set; }

#warning add upload attachments
}
