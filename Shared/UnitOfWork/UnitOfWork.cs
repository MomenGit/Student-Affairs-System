using Microsoft.EntityFrameworkCore;

namespace Shared.UnitOfWork;

public abstract class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    protected UnitOfWork(DbContext context)
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