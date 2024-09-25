using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface ISemesterRepository : IRepository<Semester>
{
}

public class SemesterRepository : Repository<Semester>, ISemesterRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}