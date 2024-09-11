namespace StudentAffairsSystem.CommonModels.Entities;

public class Student : BaseEntity
{
    public string? ProgramOfStudy { get; set; }
    public int CurrentLevel { get; set; }
    public decimal Gpa { get; set; }
    public DateOnly EnrollmentDate { get; set; }
}