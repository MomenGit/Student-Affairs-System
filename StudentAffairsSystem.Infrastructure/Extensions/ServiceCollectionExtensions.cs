using StudentAffairsSystem.WebApi.Repositories;

namespace StudentAffairsSystem.WebApi.Extensions;

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
}