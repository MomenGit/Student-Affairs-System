using Admins.Entities;
using Admins.Repositories;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IAdminRepository _adminRepository;

    public AdminsController(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
    {
        IEnumerable<Admin> admins = await _adminRepository.GetAllAsync();
        return Ok(admins);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Admin>> GetAdmin(Guid id)
    {
        Admin? admin = await _adminRepository.GetByIdAsync(id);
        if (admin == null) return NotFound();

        return Ok(admin);
    }

    [HttpPost]
    public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
    {
        await _adminRepository.AddAsync(admin);
        await _adminRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id }, admin);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutAdmin(Guid id, Admin admin)
    {
        if (id != admin.Id) return BadRequest("Admin ID mismatch.");

        _adminRepository.Update(admin);

        try
        {
            await _adminRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _adminRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAdmin(Guid id)
    {
        Admin? admin = await _adminRepository.GetByIdAsync(id);
        if (admin == null) return NotFound();

        await _adminRepository.DeleteAsync(id);
        await _adminRepository.SaveChangesAsync();

        return NoContent();
    }
}