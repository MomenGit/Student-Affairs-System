using Infrastructure.Data;
using SemesterCourses.Entities;
using SemesterCourses.Repositories;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class SemesterCourseRepository : Repository<SemesterCourse>, ISemesterCourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public SemesterCourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}