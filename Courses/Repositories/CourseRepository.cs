using Courses.Entities;
using Shared.Data;
using Shared.Repositories;

namespace Courses.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}