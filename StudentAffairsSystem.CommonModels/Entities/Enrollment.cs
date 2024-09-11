namespace StudentAffairsSystem.CommonModels.Entities;

public class Enrollment : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string? Status { get; set; } // Active, Dropped, Waitlisted

    // Navigation properties
    public Student Student { get; set; }
    public Course Course { get; set; }
}