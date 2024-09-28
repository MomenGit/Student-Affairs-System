namespace Shared.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}