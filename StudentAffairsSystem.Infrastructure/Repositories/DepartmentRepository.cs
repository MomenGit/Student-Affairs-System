using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Domain.AcademicStructure.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public DepartmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}