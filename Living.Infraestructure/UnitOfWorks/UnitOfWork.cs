using Living.Domain.Base.Interfaces;

namespace Living.Infraestructure.UnitOfWorks;
public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    public async Task BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();

        if (_context.Database.CurrentTransaction is not null)
            await _context.Database.CommitTransactionAsync();
    }

    public async Task Rollback()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}
