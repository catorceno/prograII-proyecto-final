
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    Task<int> Save();
    
    Task BeginTransaction();
    Task Commit();
    Task Rollback();
}