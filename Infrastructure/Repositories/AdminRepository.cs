using Admins.Entities;
using Admins.Repositories;
using Infrastructure.Data;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class AdminRepository : Repository<Admin>, IAdminRepository
{
    private readonly StudentAffairsDbContext _context;

    public AdminRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}