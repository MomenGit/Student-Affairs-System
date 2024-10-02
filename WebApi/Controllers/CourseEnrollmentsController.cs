using Asp.Versioning;
using CourseEnrollments.Entities;
using CourseEnrollments.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CourseEnrollmentsController : ControllerBase
{
    private readonly ICourseEnrollmentRepository _courseEnrollmentRepository;

    public CourseEnrollmentsController(ICourseEnrollmentRepository courseEnrollmentRepository)
    {
        _courseEnrollmentRepository = courseEnrollmentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseEnrollment>>> GetCourseEnrollments()
    {
        IEnumerable<CourseEnrollment> courseEnrollments = await _courseEnrollmentRepository.GetAllAsync();
        return Ok(courseEnrollments);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CourseEnrollment>> GetCourseEnrollment(Guid id)
    {
        CourseEnrollment? courseEnrollment = await _courseEnrollmentRepository.GetByIdAsync(id);
        if (courseEnrollment == null) return NotFound();

        return Ok(courseEnrollment);
    }

    [HttpPost]
    public async Task<ActionResult<CourseEnrollment>> PostCourseEnrollment(CourseEnrollment courseEnrollment)
    {
        await _courseEnrollmentRepository.AddAsync(courseEnrollment);
        await _courseEnrollmentRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCourseEnrollment), new { id = courseEnrollment.Id },
            courseEnrollment);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutCourseEnrollment(Guid id, CourseEnrollment courseEnrollment)
    {
        if (id != courseEnrollment.Id) return BadRequest("Course Enrollment ID mismatch.");

        _courseEnrollmentRepository.Update(courseEnrollment);

        try
        {
            await _courseEnrollmentRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _courseEnrollmentRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCourseEnrollment(Guid id)
    {
        CourseEnrollment? courseEnrollment = await _courseEnrollmentRepository.GetByIdAsync(id);
        if (courseEnrollment == null) return NotFound();

        await _courseEnrollmentRepository.DeleteAsync(id);
        await _courseEnrollmentRepository.SaveChangesAsync();

        return NoContent();
    }
}