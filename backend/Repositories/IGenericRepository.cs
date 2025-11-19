
using System.Linq.Expressions;

public interface IGenericRepository<T> where T : class
{
    Task Add(T entity);
    // Task Update(T entity);
    // Task SoftDelete(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);
}