using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Domain.AcademicStructure.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class FacultyRepository : Repository<Faculty>, IFacultyRepository
{
    private readonly StudentAffairsDbContext _context;

    public FacultyRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}