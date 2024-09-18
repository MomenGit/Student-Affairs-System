using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class SemesterCourse : BaseEntity
{
    [ForeignKey("Course")] public Guid CourseId { get; set; }
    
    [ForeignKey("Semester")] public Guid SemesterId { get; set; }
    
    [ForeignKey("Professor")] public Guid? ProfessorId { get; set; }
    
    public int? AvailableSeats { get; set; }
    
    [InverseProperty("SemesterCourses")] public Semester? Semester { get; set; }
    
    [InverseProperty("SemesterCourses")] public Professor? Professor { get; set; }

    [InverseProperty("SemesterCourses")] public Course? Course { get; set; }
    
    [InverseProperty("SemesterCourse")] public ICollection<CourseEnrollment>? CourseEnrollments { get; set; }
}
