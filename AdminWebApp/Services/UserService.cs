using Users.Entities;

namespace AdminWebApp.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<User?> GetUserAsync(string id)
    {
        return await _httpClient.GetFromJsonAsync<User>($"api/users/{id}");
    }

    public async Task<List<User>?> GetAllUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>("api/users");
    }
}