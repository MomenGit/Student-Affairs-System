using StudentAffairsSystem.Domain.Courses.Entities;
using StudentAffairsSystem.Domain.Courses.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class SemesterCourseRepository : Repository<SemesterCourse>, ISemesterCourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterCourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}