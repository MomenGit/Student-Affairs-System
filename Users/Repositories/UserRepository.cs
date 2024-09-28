using Infrastructure.Data;
using Shared.Repositories;
using Users.Entities;
using Users.Repositories;

namespace Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(StudentAffairsDbContext context) : base(context)
    {
    }
}