using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Domain.Users.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class AdminRepository : Repository<Admin>, IAdminRepository
{
    private readonly StudentAffairsDbContext _context;

    public AdminRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}