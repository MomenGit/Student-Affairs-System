using StudyPrograms.Entities;
using Users.Entities;

namespace Students.Entities;

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