using StudentAffairsSystem.Domain.University.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface IFacultyRepository : IRepository<Faculty>
{
}

public class FacultyRepository : Repository<Faculty>, IFacultyRepository
{
    private readonly StudentAffairsDbContext _context;

    public FacultyRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}