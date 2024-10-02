using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semesters.Entities;
using Semesters.Repositories;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class SemestersController : ControllerBase
{
    private readonly ISemesterRepository _semesterRepository;

    public SemestersController(ISemesterRepository semesterRepository)
    {
        _semesterRepository = semesterRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Semester>>> GetSemesters()
    {
        IEnumerable<Semester> semesters = await _semesterRepository.GetAllAsync();
        return Ok(semesters);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Semester>> GetSemester(Guid id)
    {
        Semester? semester = await _semesterRepository.GetByIdAsync(id);
        if (semester == null) return NotFound();

        return Ok(semester);
    }

    [HttpPost]
    public async Task<ActionResult<Semester>> PostSemester(Semester semester)
    {
        await _semesterRepository.AddAsync(semester);
        await _semesterRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSemester), new { id = semester.Id }, semester);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutSemester(Guid id, Semester semester)
    {
        if (id != semester.Id) return BadRequest("Semester ID mismatch.");

        _semesterRepository.Update(semester);

        try
        {
            await _semesterRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _semesterRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSemester(Guid id)
    {
        Semester? semester = await _semesterRepository.GetByIdAsync(id);
        if (semester == null) return NotFound();

        await _semesterRepository.DeleteAsync(id);
        await _semesterRepository.SaveChangesAsync();

        return NoContent();
    }
}