using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Entities;
using Users.Repositories;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // GET: api/v1.0/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        IEnumerable<User> users = await _userRepository.GetAllAsync();
        return Ok(users);
    }

    // GET: api/v1.0/Users/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        User? user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound();

        return Ok(user);
    }

    // POST: api/v1.0/Users
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/v1.0/Users/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutUser(Guid id, User user)
    {
        if (id != user.Id) return BadRequest("User ID mismatch.");

        _userRepository.Update(user);

        try
        {
            await _userRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _userRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/v1.0/Users/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        User? user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound();

        await _userRepository.DeleteAsync(id);
        await _userRepository.SaveChangesAsync();

        return NoContent();
    }
}