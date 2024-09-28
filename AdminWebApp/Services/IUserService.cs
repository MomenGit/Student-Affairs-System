using Users.Entities;

namespace AdminWebApp.Services;

public interface IUserService
{
    Task<User?> GetUserAsync(string id);
    Task<List<User>?> GetAllUsersAsync();
}