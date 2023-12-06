using Living.Domain.Base.Interfaces;
using Living.Domain.Entity.Posts.Interface;
using Living.Infraestructure.UnitOfWorks;

namespace Living.Application.UseCases.Posts.Comment;
public class CommentPostHandler(IUnitOfWork unitOfWork, IPostsRepository postsRepository) 
    : Handler(unitOfWork), IRequestHandler<CommentPostCommand, BaseResponse<Guid>>
{
    public async Task<BaseResponse<Guid>> Handle(CommentPostCommand request, CancellationToken cancellationToken)
    {
        var post = postsRepository
            .DBSet()
            .FirstOrDefault(p => p.Id == request.PostId);

        if (post is null)
            return new();

        post.AddComment(Guid.NewGuid(), request.Content);

        await CommitAsync();

        return new();
    }
}
