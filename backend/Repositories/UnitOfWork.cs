
using backend.Entities;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWork : IUnitOfWork
{
    private readonly TeatroTickets7Context context;
    private readonly Dictionary<Type, object> repositories = new();
    private IDbContextTransaction transaction;

    public UnitOfWork(TeatroTickets7Context context)
    {
        this.context = context;
    }

    public IGenericRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        if (!repositories.ContainsKey(type))
        {
            var repository = new GenericRepository<T>(context);
            repositories[type] = repository;
        }
        return (IGenericRepository<T>)repositories[type]!;
    }

    public async Task<int> Save() 
        => await context.SaveChangesAsync();

    public async Task BeginTransaction()
    {
        transaction = await context.Database.BeginTransactionAsync();
    }
    public async Task Commit()
    {
        await transaction.CommitAsync();
        await transaction.DisposeAsync();
    }
    public async Task Rollback()
    {
        await transaction.RollbackAsync();
        await transaction.DisposeAsync();
    }

    public void Dispose()
    {
        transaction?.Dispose();
        context.Dispose();
    }
}
/*
    public async Task BeginTransaction()
    {
        transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        try
        {
            await context.SaveChangesAsync();
            await transaction?.CommitAsync();
        }
        catch
        {
            await RollbackTransaction();
            throw;
        }
        finally
        {
            transaction?.Dispose();
            transaction = null;
        }
    }

    public async Task RollbackTransaction()
    {
        await transaction?.RollbackAsync();
        transaction?.Dispose();
        transaction = null;
    }
*/