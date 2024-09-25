using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Domain.Users.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    private readonly StudentAffairsDbContext _context;

    public ProfessorRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}