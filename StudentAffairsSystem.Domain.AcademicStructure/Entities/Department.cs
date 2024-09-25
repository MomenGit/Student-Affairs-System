using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.AcademicStructure.Entities;

public class Department : BaseEntity
{
    [Required] [MaxLength(32)] public string? Name { get; set; }

    [ForeignKey("Faculty")] public Guid FacultyId { get; set; }

    public Faculty? Faculty { get; set; }

    public ICollection<StudyProgram>? StudyPrograms { get; set; }
}