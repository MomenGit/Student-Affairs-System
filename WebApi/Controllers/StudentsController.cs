using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Entities;
using Students.Repositories;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        IEnumerable<Student> students = await _studentRepository.GetAllAsync();
        return Ok(students);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Student>> GetStudent(Guid id)
    {
        Student? student = await _studentRepository.GetByIdAsync(id);
        if (student == null) return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        await _studentRepository.AddAsync(student);
        await _studentRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutStudent(Guid id, Student student)
    {
        if (id != student.Id) return BadRequest("Student ID mismatch.");

        _studentRepository.Update(student);

        try
        {
            await _studentRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _studentRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        Student? student = await _studentRepository.GetByIdAsync(id);
        if (student == null) return NotFound();

        await _studentRepository.DeleteAsync(id);
        await _studentRepository.SaveChangesAsync();

        return NoContent();
    }
}