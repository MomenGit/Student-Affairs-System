using Shared.Data;

namespace Shared.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentAffairsDbContext _context;

    public UnitOfWork(StudentAffairsDbContext context)
    {
        _context = context;
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