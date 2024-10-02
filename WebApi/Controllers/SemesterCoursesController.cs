using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemesterCourses.Entities;
using SemesterCourses.Repositories;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class SemesterCoursesController : ControllerBase
{
    private readonly ISemesterCourseRepository _semesterCourseRepository;

    public SemesterCoursesController(ISemesterCourseRepository semesterCourseRepository)
    {
        _semesterCourseRepository = semesterCourseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SemesterCourse>>> GetSemesterCourses()
    {
        IEnumerable<SemesterCourse> semesterCourses = await _semesterCourseRepository.GetAllAsync();
        return Ok(semesterCourses);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SemesterCourse>> GetSemesterCourse(Guid id)
    {
        SemesterCourse? semesterCourse = await _semesterCourseRepository.GetByIdAsync(id);
        if (semesterCourse == null) return NotFound();

        return Ok(semesterCourse);
    }

    [HttpPost]
    public async Task<ActionResult<SemesterCourse>> PostSemesterCourse(SemesterCourse semesterCourse)
    {
        await _semesterCourseRepository.AddAsync(semesterCourse);
        await _semesterCourseRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSemesterCourse), new { id = semesterCourse.Id }, semesterCourse);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutSemesterCourse(Guid id, SemesterCourse semesterCourse)
    {
        if (id != semesterCourse.Id) return BadRequest("Semester Course ID mismatch.");

        _semesterCourseRepository.Update(semesterCourse);

        try
        {
            await _semesterCourseRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _semesterCourseRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSemesterCourse(Guid id)
    {
        SemesterCourse? semesterCourse = await _semesterCourseRepository.GetByIdAsync(id);
        if (semesterCourse == null) return NotFound();

        await _semesterCourseRepository.DeleteAsync(id);
        await _semesterCourseRepository.SaveChangesAsync();

        return NoContent();
    }
}