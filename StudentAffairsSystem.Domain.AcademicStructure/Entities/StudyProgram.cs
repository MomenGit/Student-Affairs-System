using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.AcademicStructure.Entities;

public class StudyProgram : BaseEntity
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    public Degree Degree { get; set; }

    public int ProgramDuration { get; set; } // Number of semesters

    public SemesterSeason DefaultSemesterStartSeason { get; set; }

    public List<DateOnly>? ApplicationStartDates { get; set; }

    public List<DateOnly>? ApplicationEndDates { get; set; }

    [ForeignKey("Department")] public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }
}

public enum Degree
{
    Bachelor,
    Master,
    Doctorate,
    Associate,
    Diploma
}