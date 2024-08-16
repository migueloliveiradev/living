namespace Living.Application.UseCases.Posts.Create;
public class CreatePostHandler(IUnitOfWork unitOfWork) : Handler(unitOfWork), IRequestHandler<CreatePostCommand, BaseResponse<Guid>>
{
    public Task<BaseResponse<Guid>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new BaseResponse<Guid>(Guid.NewGuid()));
    }
}
