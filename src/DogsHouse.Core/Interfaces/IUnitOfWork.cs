namespace DogsHouse.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}