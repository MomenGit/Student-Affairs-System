using StudentAffairsSystem.Domain.Courses.Entities;
using StudentAffairsSystem.Domain.Courses.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class CourseEnrollmentRepository : Repository<CourseEnrollment>, ICourseEnrollmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseEnrollmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}