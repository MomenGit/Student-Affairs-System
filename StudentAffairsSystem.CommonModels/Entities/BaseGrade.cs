using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class BaseGrade : BaseEntity
{
    [ForeignKey("Student")] public Guid StudentId { get; set; }

    public float Value { get; set; }

    public char Letter { get; set; }

    public string? Comment { get; set; }
}