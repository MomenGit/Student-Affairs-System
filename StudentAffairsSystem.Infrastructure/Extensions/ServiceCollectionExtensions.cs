using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentAffairsSystem.Domain.AcademicStructure.Repositories;
using StudentAffairsSystem.Domain.Courses.Repositories;
using StudentAffairsSystem.Domain.Users.Repositories;
using StudentAffairsSystem.Infrastructure.Data;
using StudentAffairsSystem.Infrastructure.Repositories;
using StudentAffairsSystem.Infrastructure.UnitsOfWork;
using StudentAffairsSystem.Shared.Repositories;

namespace StudentAffairsSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IProfessorRepository, ProfessorRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IStudyProgramRepository, StudyProgramRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseEnrollmentRepository, CourseEnrollmentRepository>();
        services.AddScoped<ISemesterRepository, SemesterRepository>();
        services.AddScoped<ISemesterCourseRepository, SemesterCourseRepository>();
        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        Env.Load();
        services.AddDbContextPool<StudentAffairsDbContext>(options =>
            options.UseNpgsql(
                Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));
        // Register repositories and UnitOfWork.
        services.AddRepositories();
        services.AddUnitOfWork();
        return services;
    }
}