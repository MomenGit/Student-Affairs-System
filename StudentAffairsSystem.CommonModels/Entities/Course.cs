using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Course
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int Credits { get; set; }

    [ForeignKey("Professor")] public string? Professor { get; set; }

    [ForeignKey("Department")]
    public Guid DepartmentId { get; set; }
    
    
    public List<Guid>? PrerequisitesIds { get; set; }
    public string? Semester { get; set; }

    public List<Course>? Prerequisites { get; set; }
}