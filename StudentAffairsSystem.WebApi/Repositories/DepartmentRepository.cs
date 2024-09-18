using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface IDepartmentRepository : IRepository<Department>
{
}

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public DepartmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}