using Living.Domain.Base.Interfaces;

namespace Living.Infraestructure.UnitOfWorks;
public class Handler(IUnitOfWork unitOfWork)
{
    public async Task BeginTransaction()
    {
        await unitOfWork.BeginTransaction();
    }

    protected async Task CommitAsync()
    {
        await unitOfWork.Commit();
    }

    protected async Task Rollback()
    {
        await unitOfWork.Rollback();
    }
}
