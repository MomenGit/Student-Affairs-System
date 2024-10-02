using Asp.Versioning;
using Departments.Entities;
using Departments.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentsController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
    {
        IEnumerable<Department> departments = await _departmentRepository.GetAllAsync();
        return Ok(departments);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Department>> GetDepartment(Guid id)
    {
        Department? department = await _departmentRepository.GetByIdAsync(id);
        if (department == null) return NotFound();

        return Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult<Department>> PostDepartment(Department department)
    {
        await _departmentRepository.AddAsync(department);
        await _departmentRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutDepartment(Guid id, Department department)
    {
        if (id != department.Id) return BadRequest("Department ID mismatch.");

        _departmentRepository.Update(department);

        try
        {
            await _departmentRepository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _departmentRepository.GetByIdAsync(id) == null) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDepartment(Guid id)
    {
        Department? department = await _departmentRepository.GetByIdAsync(id);
        if (department == null) return NotFound();

        await _departmentRepository.DeleteAsync(id);
        await _departmentRepository.SaveChangesAsync();

        return NoContent();
    }
}