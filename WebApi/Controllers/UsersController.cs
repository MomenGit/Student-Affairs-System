using Asp.Versioning;
using Infrastructure.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = (UnitOfWork)unitOfWork;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        IEnumerable<User> users = await _unitOfWork.Users.GetAllAsync();
        return Ok(users);
    }


    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        User? user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return NotFound();

        return Ok(user);
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(Guid id, User user)
    {
        if (id != user.Id) return BadRequest();

        _unitOfWork.Users.Update(user);

        try
        {
            await _unitOfWork.CompleteAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _unitOfWork.Users.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        User? user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) return NotFound();

        await _unitOfWork.Users.DeleteAsync(id);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}