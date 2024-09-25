using StudentAffairsSystem.Domain.Courses.Entities;
using StudentAffairsSystem.Shared.Repositories;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public interface ICourseEnrollmentRepository : IRepository<CourseEnrollment>
{
}