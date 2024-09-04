using Living.Infraestructure.Context;
using Living.Shared.Handlers;

namespace Living.Infraestructure.UnitOfWorks;
public class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task EndTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (context.Database.CurrentTransaction is not null)
            await context.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await context.Database.RollbackTransactionAsync(cancellationToken);
    }
}
