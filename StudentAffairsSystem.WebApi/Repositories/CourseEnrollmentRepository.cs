using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface ICourseEnrollmentRepository : IRepository<CourseEnrollment>
{
}

public class CourseEnrollmentRepository : Repository<CourseEnrollment>, ICourseEnrollmentRepository
{
    private readonly StudentAffairsDbContext _context;

    public CourseEnrollmentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}