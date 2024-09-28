using Shared.Data;
using Shared.Repositories;
using Users.Entities;

namespace Users.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(StudentAffairsDbContext context) : base(context)
    {
    }
}