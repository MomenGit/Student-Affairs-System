namespace StudentAffairsSystem.WebApi.Data;

public static class DbInitializer
{
    public static void Initialize(StudentAffairsDbContext dbContext)
    {
        dbContext.SaveChanges();
    }
}