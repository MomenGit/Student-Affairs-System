using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface IAdminRepository : IRepository<Admin>
{
}

public class AdminRepository : Repository<Admin>, IAdminRepository
{
    private readonly StudentAffairsDbContext _context;

    public AdminRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}