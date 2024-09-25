using System.ComponentModel.DataAnnotations.Schema;
using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.Courses.Entities;

public class SemesterCourse : BaseDateTrace
{
    [ForeignKey("Course")] public Guid CourseId { get; set; }

    [ForeignKey("Semester")] public Guid SemesterId { get; set; }

    [ForeignKey("Professor")] public Guid? ProfessorId { get; set; }

    public int? AvailableSeats { get; set; }

    public Professor? Professor { get; set; }

    public Semester? Semester { get; set; }

    public Course? Course { get; set; }

    public ICollection<CourseEnrollment>? CourseEnrollments { get; set; }
}