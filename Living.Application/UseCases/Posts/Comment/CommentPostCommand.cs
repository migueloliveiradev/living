namespace Living.Application.UseCases.Posts.Comment;
public class CommentPostCommand : IRequest<BaseResponse<Guid>>
{
    public Guid PostId { get; set; }
    public string Content { get; set; }
}
