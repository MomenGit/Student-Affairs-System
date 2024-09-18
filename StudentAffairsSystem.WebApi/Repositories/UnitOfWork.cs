using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentAffairsDbContext _context;

    public IUserRepository Users { get; private set; }
    public IStudentRepository Students { get; private set; }
    public IProfessorRepository Professors { get; private set; }
    public IAdminRepository Admins { get; private set; }
    public IFacultyRepository Faculities { get; private set; }
    public IDepartmentRepository Departments { get; private set; }
    public IStudyProgramRepository StudyPrograms { get; private set; }
    public ICourseRepository Courses { get; private set; }
    public ICourseEnrollmentRepository CourseEnrollments { get; private set; }
    public ISemesterRepository Semesters { get; private set; }
    public ISemesterCourseRepository SemesterCourses { get; private set; }
    

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

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}