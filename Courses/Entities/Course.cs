using System.ComponentModel.DataAnnotations.Schema;
using Shared.Entities;
using StudyPrograms.Entities;

namespace Courses.Entities;

public class Course : BaseEntity
{
    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public int Credits { get; set; }

    public int RecommendedSemester { get; set; }

    public ICollection<Guid>? PrerequisitesIds { get; set; }

    public ICollection<Course>? Prerequisites { get; set; }

    [ForeignKey("StudyProgram")] public Guid StudyProgramId { get; set; }

    public StudyProgram? StudyProgram { get; set; }
}