using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class CourseEnrollment : BaseEntity
{
    [ForeignKey("Student")] public Guid StudentId { get; set; }
    
    [ForeignKey("SemesterCourse")] public Guid SemesterCourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }
    
    public EnrollmentStatus? Status { get; set; }
    
    public float Score { get; set; }
    
    public float GradeValue { get; set; }

    public string? Comment { get; set; }

    // Navigation properties
    public Student Student { get; set; }
    
    public SemesterCourse SemesterCourse { get; set; }
}

public enum EnrollmentStatus
{
    Enrolled,
    Dropped,
    WaitListed,
}
