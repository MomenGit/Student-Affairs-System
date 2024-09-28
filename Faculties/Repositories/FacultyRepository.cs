using Shared.Repositories;

namespace Faculties.Repositories;

public class FacultyRepository : Repository<Faculties>, IFacultyRepository
{
    private readonly StudentAffairsDbContext _context;

    public FacultyRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}