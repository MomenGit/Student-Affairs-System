using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class CourseGrade : BaseGrade
{
    [ForeignKey("Course")] public Guid CourseId { get; set; }
}