namespace Living.Application.Validation;
/*public class ValidationBehavior<TRequest> : IPipelineBehavior<TRequest, BaseResponse<Guid>>
    where TRequest : IRequest<BaseResponse>
{
    private IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<BaseResponse<Guid>> Handle(TRequest request, RequestHandlerDelegate<BaseResponse<Guid>> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators.Select(v => v.Validate(context))
                                    .SelectMany(e => e.Errors)
                                    .Where(x => x != null)
                                    .ToDictionary(f => f.PropertyName, f => f.ErrorMessage);

        if (failures.Any())
        {
            return new BaseResponse<Guid>(failures);
        }

        return await next();
    }

}*/