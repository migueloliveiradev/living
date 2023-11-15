namespace Living.Application.UseCases.Posts.Create;
public class CreatePostHandler : IRequestHandler<CreatePostCommand, BaseResponse<Guid>>
{
    public async Task<BaseResponse<Guid>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        return new(Guid.NewGuid());
    }
}
