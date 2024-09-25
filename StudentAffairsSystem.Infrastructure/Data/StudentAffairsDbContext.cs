using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Domain.Courses.Entities;
using StudentAffairsSystem.Domain.Users.Entities;

namespace StudentAffairsSystem.Infrastructure.Data;

public class StudentAffairsDbContext : DbContext
{
    public StudentAffairsDbContext(DbContextOptions<StudentAffairsDbContext> options) : base(options)
    {
    }

    // Users Domain
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Admin> Admins { get; set; }

    // Academic Structure Domain
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { set; get; }
    public DbSet<StudyProgram> StudyPrograms { get; set; }
    public DbSet<Semester> Semesters { get; set; }

    // Courses Domain
    public DbSet<Course> Courses { get; set; }
    public DbSet<SemesterCourse> SemesterCourses { get; set; }
    public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
    public DbSet<StudyProgramCourse> StudyProgramCourses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();
        string? connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply all configurations in the domain assemblies
        // Users, Academic Structure & Courses
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(User).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Faculty).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Course).Assembly);


        base.OnModelCreating(modelBuilder);
    }
}