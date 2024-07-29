namespace Living.Domain.Mapper;
public interface IUpdateEntity<T> where T : class
{
    void UpdateEntity(T entity);
}
