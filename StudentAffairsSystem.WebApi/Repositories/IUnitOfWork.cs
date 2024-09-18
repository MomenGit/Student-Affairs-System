namespace StudentAffairsSystem.WebApi.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    public IStudentRepository Students { get; }
    public IProfessorRepository Professors { get; }
    public IAdminRepository Admins { get; }
    public IFacultyRepository Faculities { get; }
    public IDepartmentRepository Departments { get; }
    public IStudyProgramRepository StudyPrograms { get; }
    public ICourseRepository Courses { get; }
    public ICourseEnrollmentRepository CourseEnrollments { get; }
    public ISemesterRepository Semesters { get; }
    public ISemesterCourseRepository SemesterCourses { get; }

    Task<int> CompleteAsync();
}