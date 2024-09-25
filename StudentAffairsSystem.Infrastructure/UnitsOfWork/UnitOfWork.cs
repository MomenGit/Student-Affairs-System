using StudentAffairsSystem.Domain.AcademicStructure.Repositories;
using StudentAffairsSystem.Domain.Courses.Repositories;
using StudentAffairsSystem.Domain.Users.Repositories;
using StudentAffairsSystem.Infrastructure.Data;
using StudentAffairsSystem.Shared.Repositories;

namespace StudentAffairsSystem.Infrastructure.UnitsOfWork;

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
        Faculties = faculties;
        Departments = departments;
        StudyPrograms = studyPrograms;
        Courses = courses;
        CourseEnrollments = courseEnrollments;
        Semesters = semesters;
        SemesterCourses = semesterCourses;
    }

    public IStudentRepository Students { get; set; }
    public IProfessorRepository Professors { get; set; }
    public IAdminRepository Admins { get; set; }
    public IFacultyRepository Faculties { get; set; }
    public IDepartmentRepository Departments { get; set; }
    public IStudyProgramRepository StudyPrograms { get; set; }
    public ICourseRepository Courses { get; set; }
    public ICourseEnrollmentRepository CourseEnrollments { get; set; }
    public ISemesterRepository Semesters { get; set; }
    public ISemesterCourseRepository SemesterCourses { get; set; }
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