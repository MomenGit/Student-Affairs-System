using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentAffairsDbContext _context;

    public IUserRepository Users { get; private set; }

    public UnitOfWork(StudentAffairsDbContext context, IUserRepository users)
    {
        _context = context;
        Users = users;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}