namespace StudentAffairsSystem.Shared.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}