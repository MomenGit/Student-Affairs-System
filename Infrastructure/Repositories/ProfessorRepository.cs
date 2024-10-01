using Infrastructure.Data;
using Professors.Entities;
using Professors.Repositories;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    private readonly StudentAffairsDbContext _context;

    public ProfessorRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}