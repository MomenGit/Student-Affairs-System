namespace Shared.UnitsOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}