using Courses.Entities;
using Courses.Repositories;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}