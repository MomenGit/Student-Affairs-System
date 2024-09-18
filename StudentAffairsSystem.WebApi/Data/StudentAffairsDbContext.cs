using Microsoft.EntityFrameworkCore;
using StudentAffairsSystem.CommonModels.Entities;

namespace StudentAffairsSystem.WebApi.Data;

public class StudentAffairsDbContext : DbContext
{
    public StudentAffairsDbContext(DbContextOptions<StudentAffairsDbContext> options) : base(options)
    {
    }

    // User Related
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Admin> Admins { get; set; }
    
    // Organizational
    public DbSet<Course> Courses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { set; get; }
    public DbSet<StudyProgram> StudyPrograms { get; set; }
    public DbSet<Semester> Semesters { get; set; }

    // Course Realted
    public DbSet<SemesterCourse> SemesterCourses { get; set; }
    public DbSet<CourseEnrollment> CourseEnrollments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseEntity>().Property(entity => entity.CreationDate)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<Semester>()
            .Property(sem => sem.Season)
            .HasConversion<string>();
        
        // Ignore BaseEntity as a table
        modelBuilder.Ignore<BaseEntity>();

        modelBuilder.Entity<CourseEnrollment>()
            .Property(enrollment => enrollment.Status)
            .HasConversion<string>();
        
        modelBuilder.Entity<Student>()
            .Property(stud => stud.Status)
            .HasConversion<string>();
        
        modelBuilder.Entity<Admin>()
            .Property(ad => ad.Privileges)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}