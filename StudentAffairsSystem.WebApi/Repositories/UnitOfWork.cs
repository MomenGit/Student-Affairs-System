using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentAffairsDbContext _context;


    public UnitOfWork(
        StudentAffairsDbContext context,
        IUserRepository users,
        IStudentRepository students,
        IProfessorRepository professors,
        IAdminRepository admins,
        IFacultyRepository faculties,
        IDepartmentRepository departments,
        IStudyProgramRepository studyPrograms, ICourseRepository courses,
        ICourseEnrollmentRepository courseEnrollments,
        ISemesterRepository semesters,
        ISemesterCourseRepository semesterCourses)
    {
        _context = context;
        Users = users;
        Students = students;
        Professors = professors;
        Admins = admins;
        Faculities = faculties;
        Departments = departments;
        StudyPrograms = studyPrograms;
        Courses = courses;
        CourseEnrollments = courseEnrollments;
        Semesters = semesters;
        SemesterCourses = semesterCourses;
    }

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

    public IUserRepository Users { get; set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}