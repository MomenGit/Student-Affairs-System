using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Student : BaseEntity
{
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    
    [ForeignKey("StudyProgram")]
    public Guid StudyProgramId { get; set; }
    
    public StudentStatus Status { get; set; }
    
    public DateOnly EnrollmentDate { get; set; }
    
    public IEnumerable<string>? Documents { get; set; }
    
    public User User { get; set; }
}

public enum StudentStatus
{
    Applicant,
    Enrolled,
    Dropped
}