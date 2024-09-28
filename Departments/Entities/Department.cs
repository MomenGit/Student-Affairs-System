using System.ComponentModel.DataAnnotations;
using Faculties.Entities;
using Shared.Entities;

namespace Departments.Entities;

public class Department : BaseEntity
{
    [Required] [MaxLength(32)] public string? Name { get; set; }

    public Guid FacultyId { get; set; }

    public Faculty? Faculty { get; set; }
}