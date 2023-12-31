using System.Linq.Expressions;

namespace backend;

public interface IRepository<T>
{
    Task<List<T>> Filter(Expression<Func<T, bool>> exp);
    Task<T> FirstOrDefault(Expression<Func<T, bool>> exp);
    Task add(T obj);
    void Delete(T obj);
    void Update(T obj);
    Task<T> Last(T obj);
    Task<bool> exists(T obj);
    int Count(Expression<Func<T, bool>> exp);
}