using Semesters.Entities;
using Shared.Data;
using Shared.Repositories;

namespace Semesters.Repositories;

public class SemesterRepository : Repository<Semester>, ISemesterRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}