namespace Living.Shared.Handlers;
public class Handler(IUnitOfWork unitOfWork)
{
    public Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return unitOfWork.BeginTransactionAsync(cancellationToken);
    }

    public Task EndTransactionAsync(CancellationToken cancellationToken)
    {
        return unitOfWork.EndTransactionAsync(cancellationToken);
    }

    protected Task CommitAsync(CancellationToken cancellationToken)
    {
        return unitOfWork.CommitAsync(cancellationToken);
    }

    protected Task Rollback(CancellationToken cancellationToken)
    {
        return unitOfWork.RollbackAsync(cancellationToken);
    }
}
