using Professors.Entities;
using Shared.Data;
using Shared.Repositories;

namespace Professors.Repositories;

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    private readonly StudentAffairsDbContext _context;

    public ProfessorRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}