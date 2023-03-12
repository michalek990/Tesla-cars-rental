namespace backend.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
}