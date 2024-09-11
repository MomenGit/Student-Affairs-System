using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Faculty : BaseEntity
{
    [Required] public string? Name { get; set; }

    [InverseProperty("Faculty")] public List<Department>? Departments { get; set; }
}