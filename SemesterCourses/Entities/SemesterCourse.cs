using System.ComponentModel.DataAnnotations.Schema;
using Courses.Entities;
using Professors.Entities;
using Semesters.Entities;
using Shared.Entities;

namespace SemesterCourses.Entities;

public class SemesterCourse : BaseEntity
{
    [ForeignKey("Course")] public Guid CourseId { get; set; }

    [ForeignKey("Semester")] public Guid SemesterId { get; set; }

    [ForeignKey("Professor")] public Guid? ProfessorId { get; set; }

    public int? AvailableSeats { get; set; }

    public Professor? Professor { get; set; }

    public Semester? Semester { get; set; }

    public Course? Course { get; set; }
}