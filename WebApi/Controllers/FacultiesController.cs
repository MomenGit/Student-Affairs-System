using Asp.Versioning;
using Faculties.Entities;
using Faculties.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class FacultiesController : ControllerBase
{
    private readonly IFacultyRepository _facultyRepository;

    public FacultiesController(IFacultyRepository facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculties()
    {
        IEnumerable<Faculty> faculties = await _facultyRepository.GetAllAsync();
        return Ok(faculties);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Faculty>> GetFaculty(Guid id)
    {
        Faculty? faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty == null) return NotFound();

        return Ok(faculty);
    }

    [HttpPost]
    public async Task<ActionResult<Faculty>> PostFaculty(Faculty faculty)
    {
        await _facultyRepository.AddAsync(faculty);
        await _facultyRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFaculty), new { id = faculty.Id }, faculty);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutFaculty(Guid id, Faculty faculty)
    {
        if (id != faculty.Id) return BadRequest("Faculty ID mismatch.");

        _facultyRepository.Update(faculty);

        try
        {
            await _facultyRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _facultyRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFaculty(Guid id)
    {
        Faculty? faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty == null) return NotFound();

        await _facultyRepository.DeleteAsync(id);
        await _facultyRepository.SaveChangesAsync();

        return NoContent();
    }
}