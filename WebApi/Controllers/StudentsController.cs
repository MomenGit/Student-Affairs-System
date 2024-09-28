/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Entities;
using Shared.Repositories;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/Students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        IEnumerable<Student> students = await _unitOfWork.Students.GetAllAsync();
        return Ok(students);
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(Guid id)
    {
        Student? student = await _unitOfWork.Students.GetByIdAsync(id);

        if (student == null) return NotFound();

        return Ok(student);
    }

    // POST: api/Students
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        await _unitOfWork.Students.AddAsync(student);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT: api/Students/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(Guid id, Student student)
    {
        if (id != student.Id) return BadRequest();

        _unitOfWork.Students.Update(student);

        try
        {
            await _unitOfWork.CompleteAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _unitOfWork.Students.GetByIdAsync(id) == null) return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        Student? student = await _unitOfWork.Students.GetByIdAsync(id);
        if (student == null) return NotFound();

        await _unitOfWork.Students.DeleteAsync(id);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}*/

