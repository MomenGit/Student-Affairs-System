using CourseEnrollments.Entities;
using Shared.Repositories;

namespace CourseEnrollments.Repositories;

public interface ICourseEnrollmentRepository : IRepository<CourseEnrollment>
{
}