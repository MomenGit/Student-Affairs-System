using StudentAffairsSystem.Domain.AcademicStructure.Entities;

namespace StudentAffairsSystem.Domain.Users.Entities;

public class Student : UserSubType
{
    public Guid StudyProgramId { get; set; }

    public StudentStatus Status { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public ICollection<string>? DocumentsUrls { get; set; }

    public StudyProgram? StudyProgram { get; set; }
}

public enum StudentStatus
{
    Applicant,
    Enrolled,
    Dropped
}