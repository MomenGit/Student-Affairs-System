using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyProgramCourses.Entities;
using StudyProgramCourses.Repositories;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class StudyProgramCoursesController : ControllerBase
{
    private readonly IStudyProgramCourseRepository _studyProgramCourseRepository;

    public StudyProgramCoursesController(IStudyProgramCourseRepository studyProgramCourseRepository)
    {
        _studyProgramCourseRepository = studyProgramCourseRepository;
    }

    // GET: api/StudyProgramCourses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudyProgramCourse>>> GetStudyProgramCourses()
    {
        IEnumerable<StudyProgramCourse> studyProgramCourses = await _studyProgramCourseRepository.GetAllAsync();
        return Ok(studyProgramCourses);
    }

    // GET: api/StudyProgramCourses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<StudyProgramCourse>> GetStudyProgramCourse(Guid id)
    {
        StudyProgramCourse? studyProgramCourse = await _studyProgramCourseRepository.GetByIdAsync(id);
        if (studyProgramCourse == null) return NotFound();

        return Ok(studyProgramCourse);
    }

    // POST: api/StudyProgramCourses
    [HttpPost]
    public async Task<ActionResult<StudyProgramCourse>> PostStudyProgramCourse(StudyProgramCourse studyProgramCourse)
    {
        await _studyProgramCourseRepository.AddAsync(studyProgramCourse);
        await _studyProgramCourseRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudyProgramCourse), new { id = studyProgramCourse.Id }, studyProgramCourse);
    }

    // PUT: api/StudyProgramCourses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudyProgramCourse(Guid id, StudyProgramCourse studyProgramCourse)
    {
        if (id != studyProgramCourse.Id) return BadRequest();

        _studyProgramCourseRepository.Update(studyProgramCourse);

        try
        {
            await _studyProgramCourseRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _studyProgramCourseRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/StudyProgramCourses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudyProgramCourse(Guid id)
    {
        StudyProgramCourse? studyProgramCourse = await _studyProgramCourseRepository.GetByIdAsync(id);
        if (studyProgramCourse == null) return NotFound();

        await _studyProgramCourseRepository.DeleteAsync(id);
        await _studyProgramCourseRepository.SaveChangesAsync();

        return NoContent();
    }
}