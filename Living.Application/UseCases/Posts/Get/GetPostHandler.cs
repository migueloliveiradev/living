using Living.Domain.Entity.Posts.Interface;
using Living.Domain.Entity.Posts.Models;

namespace Living.Application.UseCases.Posts.Get;
public class GetPostHandler(IPostsRepository postsRepository): IRequestHandler<GetPostCommand, BaseResponse<PostItemGet>>
{
    public async Task<BaseResponse<PostItemGet>> Handle(GetPostCommand request, CancellationToken cancellationToken)
    {
        var post = postsRepository.Get(request.PostId);

        if (post is null)
            return new();

        return new(post);
    }
}
