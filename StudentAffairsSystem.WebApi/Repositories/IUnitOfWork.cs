namespace StudentAffairsSystem.WebApi.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }

    Task<int> CompleteAsync();
}