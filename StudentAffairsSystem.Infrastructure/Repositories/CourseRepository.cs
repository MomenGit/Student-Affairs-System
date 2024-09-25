using StudentAffairsSystem.Domain.Courses.Entities;
using StudentAffairsSystem.Domain.Courses.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}