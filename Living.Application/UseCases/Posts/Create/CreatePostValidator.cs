using FluentValidation;

namespace Living.Application.UseCases.Posts.Create;
public class CreatePostValidator : AbstractValidator<CreatePostCommand> 
{
    public CreatePostValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.Access)
            .IsInEnum();
    }
}
