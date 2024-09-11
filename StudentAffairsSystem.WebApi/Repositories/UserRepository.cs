using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface IUserRepository : IRepository<User>
{
}

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly StudentAffairsDbContext _context;

    public UserRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}