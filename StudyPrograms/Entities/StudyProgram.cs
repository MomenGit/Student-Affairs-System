using Departments.Entities;
using Semesters.Entities;
using Shared.Entities;

namespace StudyPrograms.Entities;

public class StudyProgram : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Degree Degree { get; set; }

    public int ProgramDuration { get; set; } // Number of semesters

    public SemesterSeason DefaultSemesterStartSeason { get; set; }

    public ICollection<DateOnly>? ApplicationStartDates { get; set; }

    public ICollection<DateOnly>? ApplicationEndDates { get; set; }

    public Guid DepartmentId { get; set; }

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