using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyPrograms.Entities;
using StudyPrograms.Repositories;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class StudyProgramsController : ControllerBase
{
    private readonly IStudyProgramRepository _studyProgramRepository;

    public StudyProgramsController(IStudyProgramRepository studyProgramRepository)
    {
        _studyProgramRepository = studyProgramRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudyProgram>>> GetStudyPrograms()
    {
        IEnumerable<StudyProgram> studyPrograms = await _studyProgramRepository.GetAllAsync();
        return Ok(studyPrograms);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudyProgram>> GetStudyProgram(Guid id)
    {
        StudyProgram? studyProgram = await _studyProgramRepository.GetByIdAsync(id);
        if (studyProgram == null) return NotFound();

        return Ok(studyProgram);
    }

    [HttpPost]
    public async Task<ActionResult<StudyProgram>> PostStudyProgram(StudyProgram studyProgram)
    {
        await _studyProgramRepository.AddAsync(studyProgram);
        await _studyProgramRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudyProgram), new { id = studyProgram.Id }, studyProgram);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutStudyProgram(Guid id, StudyProgram studyProgram)
    {
        if (id != studyProgram.Id) return BadRequest("Study Program ID mismatch.");

        _studyProgramRepository.Update(studyProgram);

        try
        {
            await _studyProgramRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _studyProgramRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudyProgram(Guid id)
    {
        StudyProgram? studyProgram = await _studyProgramRepository.GetByIdAsync(id);
        if (studyProgram == null) return NotFound();

        await _studyProgramRepository.DeleteAsync(id);
        await _studyProgramRepository.SaveChangesAsync();

        return NoContent();
    }
}