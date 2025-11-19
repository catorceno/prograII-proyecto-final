
using System.Linq.Expressions;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly TeatroTickets7Context context;
    protected readonly DbSet<T> dbSet;
    
    public GenericRepository(TeatroTickets7Context context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public async Task<T?> GetById(int id)
        => await dbSet.FindAsync(id);
    
    public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate) 
        => await dbSet.FirstOrDefaultAsync(predicate);
    
    public async Task<IEnumerable<T>> GetAll() 
        => await dbSet.AsNoTracking().ToListAsync();
    
    public async Task Add(T entity) 
        => await dbSet.AddAsync(entity);
    
}
    /*
    public async Task Update(T entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        await Task.CompletedTask;
    }
    
    public async Task SoftDelete(int id)
    {
        var entity = await GetById(id);
        if(entity != null)
        {
            dbSet.Remove(entity);
        }
    }
    */