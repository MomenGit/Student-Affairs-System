using Faculties.Entities;
using Shared.Data;
using Shared.Repositories;

namespace Faculties.Repositories;

public class FacultyRepository : Repository<Faculty>, IFacultyRepository
{
    private readonly StudentAffairsDbContext _context;

    public FacultyRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}