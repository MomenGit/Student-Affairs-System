using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Domain.Users.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly StudentAffairsDbContext _context;

    public UserRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}