using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions;

namespace Shared.Data;

public class StudentAffairsDbContext : DbContext
{
    public StudentAffairsDbContext(DbContextOptions<StudentAffairsDbContext> options) : base(options)
    {
    }

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
        modelBuilder.ApplyConfigurationsFromAssemblies();

        base.OnModelCreating(modelBuilder);
    }
}