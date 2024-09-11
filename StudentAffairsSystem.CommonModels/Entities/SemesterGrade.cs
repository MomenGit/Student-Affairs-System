using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class SemesterGrade : BaseGrade
{
    [ForeignKey("Semester")] public Guid SemesterId { get; set; }
}