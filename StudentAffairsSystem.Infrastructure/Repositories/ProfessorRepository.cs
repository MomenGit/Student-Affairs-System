using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface IProfessorRepository : IRepository<Professor>
{
}

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    private readonly StudentAffairsDbContext _context;

    public ProfessorRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}