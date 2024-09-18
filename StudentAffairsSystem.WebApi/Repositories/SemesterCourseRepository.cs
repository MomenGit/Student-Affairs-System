using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface ISemesterCourseRepository : IRepository<SemesterCourse>
{
}

public class SemesterCourseRepository : Repository<SemesterCourse>, ISemesterCourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterCourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}