using Departments.Entities;
using Departments.Repositories;
using Infrastructure.Data;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public DepartmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}