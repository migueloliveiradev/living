using System.Linq.Expressions;

namespace Living.Domain.Base.Interfaces;
public interface IBaseRepository<T> where T : IEntity
{
    void Insert(T entity);
    void InsertRange(T[] entities);
    void Update(T entity);
    void Delete(T entity);
    public IQueryable<T> Query();
    public IQueryable<T> DBSet();
    Task CommitAsync();
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
}
