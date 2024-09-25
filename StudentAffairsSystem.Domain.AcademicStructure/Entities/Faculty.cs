using System.ComponentModel.DataAnnotations;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.AcademicStructure.Entities;

public class Faculty : BaseEntity
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Department>? Departments { get; set; }
}