using Living.Domain.Base.Interfaces;
using Living.Infraestructure.Context;
using System.Linq.Expressions;

namespace Living.Infraestructure.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{
    protected readonly DatabaseContext _context;
    protected readonly DbSet<T> _entity;
    protected BaseRepository(DatabaseContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }
    public void Insert(T entity) => _entity.Add(entity);
    public void InsertRange(T[] entities) => _entity.AddRange(entities);
    public void Update(T entity) => _entity.Update(entity);
    public void Delete(T entity) => _entity.Remove(entity);
    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression) => await _entity.AsNoTracking().AnyAsync(expression);
    public IQueryable<T> Query() => _entity.AsNoTracking();
    public IQueryable<T> DBSet() => _entity;
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}