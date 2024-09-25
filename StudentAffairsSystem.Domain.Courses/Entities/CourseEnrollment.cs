using System.ComponentModel.DataAnnotations.Schema;
using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.Courses.Entities;

public class CourseEnrollment : BaseDateTrace
{
    [ForeignKey("Student")] public Guid StudentId { get; set; }

    [ForeignKey("SemesterCourse")] public Guid SemesterCourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public EnrollmentStatus? Status { get; set; }

    public float Score { get; set; }

    public float GradeValue { get; set; }

    public string? Comment { get; set; }

    public Student? Student { get; set; }

    public SemesterCourse? SemesterCourse { get; set; }
}

public enum EnrollmentStatus
{
    Enrolled,
    Dropped,
    WaitListed
}