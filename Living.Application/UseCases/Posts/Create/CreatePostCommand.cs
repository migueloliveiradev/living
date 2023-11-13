using Living.Domain.Base;
using Living.Domain.Entity.Posts;
using MediatR;

namespace Living.Application.UseCases.Posts.Create;
public class CreatePostCommand : IRequest<BaseResponse<Guid>>
{
    public string Content { get; set; }
    public PostAccess Access { get; set; }

#warning add upload attachments
}
