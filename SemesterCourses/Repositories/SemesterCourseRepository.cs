using SemesterCourses.Entities;
using Shared.Data;
using Shared.Repositories;

namespace SemesterCourses.Repositories;

public class SemesterCourseRepository : Repository<SemesterCourse>, ISemesterCourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterCourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}