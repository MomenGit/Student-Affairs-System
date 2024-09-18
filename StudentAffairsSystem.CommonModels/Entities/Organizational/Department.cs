using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Department : BaseEntity
{
    [Required] public string? Name { get; set; }

    [ForeignKey("Faculty")] public Guid FacultyId { get; set; }

    [InverseProperty("Departments")] public Faculty? Faculty { get; set; }
    
    [InverseProperty("Department")] public ICollection<StudyProgram>? StudyPrograms { get; set; }
}