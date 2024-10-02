using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Professors.Entities;
using Professors.Repositories;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ProfessorsController : ControllerBase
{
    private readonly IProfessorRepository _professorRepository;

    public ProfessorsController(IProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }

    // GET: api/v1.0/Professors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
    {
        IEnumerable<Professor> professors = await _professorRepository.GetAllAsync();
        return Ok(professors);
    }

    // GET: api/v1.0/Professors/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Professor>> GetProfessor(Guid id)
    {
        Professor? professor = await _professorRepository.GetByIdAsync(id);
        if (professor == null) return NotFound();

        return Ok(professor);
    }

    // POST: api/v1.0/Professors
    [HttpPost]
    public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
    {
        await _professorRepository.AddAsync(professor);
        await _professorRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
    }

    // PUT: api/v1.0/Professors/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutProfessor(Guid id, Professor professor)
    {
        if (id != professor.Id) return BadRequest("Professor ID mismatch.");

        _professorRepository.Update(professor);

        try
        {
            await _professorRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _professorRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/v1.0/Professors/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProfessor(Guid id)
    {
        Professor? professor = await _professorRepository.GetByIdAsync(id);
        if (professor == null) return NotFound();

        await _professorRepository.DeleteAsync(id);
        await _professorRepository.SaveChangesAsync();

        return NoContent();
    }
}