using DogsHouse.Core.Interfaces;

namespace DogsHouse.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void Dispose()
    {
        _applicationDbContext.Dispose();
    }

    public Task SaveChangesAsync()
    {
        return _applicationDbContext.SaveChangesAsync();
    }
}
