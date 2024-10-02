using Asp.Versioning;
using Courses.Entities;
using Courses.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CoursesController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        IEnumerable<Course> courses = await _courseRepository.GetAllAsync();
        return Ok(courses);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Course>> GetCourse(Guid id)
    {
        Course? course = await _courseRepository.GetByIdAsync(id);
        if (course == null) return NotFound();

        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(Course course)
    {
        await _courseRepository.AddAsync(course);
        await _courseRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutCourse(Guid id, Course course)
    {
        if (id != course.Id) return BadRequest("Course ID mismatch.");

        _courseRepository.Update(course);

        try
        {
            await _courseRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _courseRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        Course? course = await _courseRepository.GetByIdAsync(id);
        if (course == null) return NotFound();

        await _courseRepository.DeleteAsync(id);
        await _courseRepository.SaveChangesAsync();

        return NoContent();
    }
}