using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Domain.AcademicStructure.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class SemesterRepository : Repository<Semester>, ISemesterRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}