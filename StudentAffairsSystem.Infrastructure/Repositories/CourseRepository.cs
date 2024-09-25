using StudentAffairsSystem.Domain.Courses.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface ICourseRepository : IRepository<Course>
{
}

public class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}