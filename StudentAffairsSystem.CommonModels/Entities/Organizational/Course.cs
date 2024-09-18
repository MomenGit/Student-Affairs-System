using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Course : BaseEntity
{
    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public int Credits { get; set; }

    public int RecommendedSemester { get; set; }
    
    public ICollection<Guid>? PrerequisitesIds { get; set; }

    public ICollection<Course>? Prerequisites { get; set; }

    [ForeignKey("Department")] public Guid DepartmentId { get; set; }

    [InverseProperty("Course")] 
    public List<SemesterCourse>? SemesterCourses { get; set; }
}