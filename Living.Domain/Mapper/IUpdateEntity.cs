namespace Living.Domain.Mapper;
public interface IUpdateEntity<in T> where T : class
{
    void UpdateEntity(T entity);
}
