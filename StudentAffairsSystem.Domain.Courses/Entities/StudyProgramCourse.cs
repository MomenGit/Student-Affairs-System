using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.Courses.Entities;

public class StudyProgramCourse : BaseDateTrace
{
    public Guid StudyProgramId { get; set; }

    public StudyProgram? StudyProgram { get; set; }

    public Guid CourseId { get; set; }

    public Course? Course { get; set; }
}