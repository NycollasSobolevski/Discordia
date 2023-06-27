using System.Linq.Expressions;

namespace backend;

public interface IRepository<T>
{
    Task<List<T>> Filter(Expression<Func<T, bool>> exp);
    void add(T obj);
    void Delete(T obj);
    void Update(T obj);

}