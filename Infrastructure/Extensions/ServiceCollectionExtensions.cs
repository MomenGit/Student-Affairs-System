using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;

namespace Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        /*ICollection<Assembly> assemblies = Utils.LoadAssemblies();

        // Get the assembly where repositories are located
        foreach (Assembly assembly in assemblies)
            try
            {
                // Find all the types that implement IRepository<> and
                // their corresponding Repository<> implementations
                IEnumerable<Type>? repositoryTypes = assembly.GetTypes()
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
                    Type? genericInterfaceType = repositoryType.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType
                                             && i.GetGenericTypeDefinition()
                                             == typeof(IRepository<>));

                    if (genericInterfaceType != null)
                        services.AddScoped(genericInterfaceType, repositoryType);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }*/

        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        // services.AddScoped<IUnitOfWork, UnitOfWork>();
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