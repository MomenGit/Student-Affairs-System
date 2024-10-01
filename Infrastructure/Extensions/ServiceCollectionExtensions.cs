using System.Reflection;
using DotNetEnv;
using FluentValidation;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repositories;
using Shared.UnitOfWork;
using Shared.Utilities;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoriesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        // Find all the types that implement IRepository<> and
        // their corresponding Repository<> implementations
        IEnumerable<Type> repositoryTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i =>
                    i.IsGenericType
                    && i.GetGenericTypeDefinition() == typeof(IRepository<>)
                ) && t is { IsClass: true, IsAbstract: false });

        foreach (Type repositoryType in repositoryTypes)
        {
            // Get the interface that the repository implements
            // (e.g., IUserRepository)
            Type? interfaceType = repositoryType.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType == false
                                     && i != typeof(IRepository<>));

            // Register the repository type and its interface
            // (e.g., IUserRepository -> UserRepository)
            if (interfaceType != null)
                services.AddScoped(interfaceType, repositoryType);

            // Also register the generic IRepository<T> interface
            // (e.g., IRepository<User> -> UserRepository)
            // Type? genericInterfaceType = repositoryType.GetInterfaces()
            //     .FirstOrDefault(i => i.IsGenericType
            //                          && i.GetGenericTypeDefinition()
            //                          == typeof(IRepository<>));
            //
            // if (genericInterfaceType != null)
            //     services.AddScoped(genericInterfaceType, repositoryType);
        }

        return services;
    }

    public static IServiceCollection AddRepositoriesFromProjects(this IServiceCollection services)
    {
        ICollection<Assembly> assemblies = Utils.ProjectAssemblies;

        // Get the assembly where repositories are located
        foreach (Assembly assembly in assemblies)
            services.AddRepositoriesFromAssembly(assembly);

        return services;
    }

    public static IServiceCollection AddUnitsOfWorkFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        // Find all the types that implement IUnitOfWork and
        // their corresponding UnitOfWork implementations
        IEnumerable<Type> unitOfWorkTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i == typeof(IUnitOfWork)
                ) && t is { IsClass: true, IsAbstract: false });

        foreach (Type unitOfWorkType in unitOfWorkTypes)
        {
            // Get the interface that the UnitOfWork implements
            // (e.g., IStudentUnitOfWork)
            Type? interfaceType = unitOfWorkType.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType == false
                                     && i != typeof(IRepository<>));

            // Register the UnitOfWork type and its interface
            // (e.g., IStudentUnitOfWork -> StudentUnitOfWork)
            if (interfaceType != null)
                services.AddScoped(interfaceType, unitOfWorkType);
        }

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Get the assembly where repositories are located
        Assembly assembly = Assembly.GetExecutingAssembly();

        Env.Load();
        services.AddDbContextPool<StudentAffairsDbContext>(options =>
            options.UseNpgsql(
                Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));

        services.AddValidatorsFromAssembly(assembly);
        services.AddRepositoriesFromAssembly(assembly);
        services.AddUnitsOfWorkFromAssembly(assembly);
        return services;
    }
}