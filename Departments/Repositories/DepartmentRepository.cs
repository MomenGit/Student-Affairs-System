using Departments.Entities;
using Shared.Data;
using Shared.Repositories;

namespace Departments.Repositories;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public DepartmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}