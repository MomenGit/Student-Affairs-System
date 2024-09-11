using Microsoft.EntityFrameworkCore;
using StudentAffairsSystem.CommonModels.Entities;

namespace StudentAffairsSystem.WebApi.Data;

public class StudentAffairsDbContext : DbContext
{
    public StudentAffairsDbContext(DbContextOptions<StudentAffairsDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Semester>()
            .Property(sem => sem.Season)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}