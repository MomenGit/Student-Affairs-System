using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Extensions;

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
}