namespace Living.Domain.Base.Interfaces;
public interface IUnitOfWork
{
    Task BeginTransaction();
    Task Commit();
    Task Rollback();
}
