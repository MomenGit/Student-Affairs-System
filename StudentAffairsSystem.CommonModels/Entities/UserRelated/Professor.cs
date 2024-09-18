using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Professor : BaseEntity
{
    [ForeignKey("User")] public Guid UserId { get; set; }
    
    [ForeignKey("Department")] public Guid DepartmentId { get; set; }

    [InverseProperty("Professor")]
    public ICollection<SemesterCourse>? SemesterCourses { get; set; }
}