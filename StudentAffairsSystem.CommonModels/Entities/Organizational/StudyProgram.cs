using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class StudyProgram : BaseEntity
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }
    
    public int ProgramDuration { get; set; } // Number of semesters

    public SemesterSeason DefaultSemesterStartSeason { get; set; }
    
    public List<DateOnly>? ApplicationStartDates { get; set; }

    public List<DateOnly>? ApplicationEndDates { get; set; }

    [ForeignKey("Department")] public Guid DepartmentId { get; set; }
    
    [InverseProperty("StudyPrograms")] public Department Department { get; set; }
}