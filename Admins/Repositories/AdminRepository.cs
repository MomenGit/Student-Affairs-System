using Admins.Entities;
using Shared.Data;
using Shared.Repositories;

namespace Admins.Repositories;

public class AdminRepository : Repository<Admin>, IAdminRepository
{
    private readonly StudentAffairsDbContext _context;

    public AdminRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}