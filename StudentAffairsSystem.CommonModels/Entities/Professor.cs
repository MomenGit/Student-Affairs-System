using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Professor : BaseEntity
{
    [ForeignKey("User")] public Guid UserId { get; set; }

    [InverseProperty("Professor")] public List<Course>? Courses { get; set; }
}