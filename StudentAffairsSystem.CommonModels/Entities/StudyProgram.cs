using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class StudyProgram : BaseEntity
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    [ForeignKey("Department")] public Guid DepartmentId { get; set; }
}