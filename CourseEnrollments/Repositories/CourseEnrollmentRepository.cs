using CourseEnrollments.Entities;
using Shared.Data;
using Shared.Repositories;

namespace CourseEnrollments.Repositories;

public class CourseEnrollmentRepository : Repository<CourseEnrollment>, ICourseEnrollmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseEnrollmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}