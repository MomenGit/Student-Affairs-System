using Infrastructure.Data;
using Semesters.Entities;
using Semesters.Repositories;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class SemesterRepository : Repository<Semester>, ISemesterRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}