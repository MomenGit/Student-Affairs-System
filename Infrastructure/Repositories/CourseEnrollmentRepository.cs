using CourseEnrollments.Entities;
using CourseEnrollments.Repositories;
using Infrastructure.Data;
using Shared.Repositories;

namespace Infrastructure.Repositories;

public class CourseEnrollmentRepository : Repository<CourseEnrollment>, ICourseEnrollmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseEnrollmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}