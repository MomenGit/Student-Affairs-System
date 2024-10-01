using Faculties.Entities;
using Faculties.Repositories;
using Infrastructure.Data;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class FacultyRepository : Repository<Faculty>, IFacultyRepository
{
    private readonly StudentAffairsDbContext _context;

    public FacultyRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}