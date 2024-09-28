using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Data;
using Shared.Utilities;

namespace Shared.Extensions;

public static class DataExtensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            IServiceProvider services = scope.ServiceProvider;
            StudentAffairsDbContext dbContext = services.GetRequiredService<StudentAffairsDbContext>();
            dbContext.Database.EnsureCreated();
            DbInitializer.Initialize(dbContext);
        }
    }

    public static ModelBuilder ApplyConfigurationsFromAssemblies(this ModelBuilder modelBuilder)
    {
        ICollection<Assembly> assemblies = Utils.ProjectAssemblies;

        foreach (Assembly assembly in assemblies)
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        return modelBuilder;
    }
}