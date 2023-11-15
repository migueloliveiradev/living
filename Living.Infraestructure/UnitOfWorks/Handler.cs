using Living.Domain.Base.Interfaces;

namespace Living.Infraestructure.UnitOfWorks;
public abstract class Handler
{
    private readonly IUnitOfWork _unitOfWork;

    protected Handler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task BeginTransaction()
    {
        await _unitOfWork.BeginTransaction();
    }

    protected async Task CommitAsync()
    {
        await _unitOfWork.Commit();
    }

    public async Task Rollback()
    {
        await _unitOfWork.Rollback();
    }
}
