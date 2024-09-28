using Courses.Entities;
using Shared.Entities;
using StudyPrograms.Entities;

namespace StudyProgramCourses.Entities;

public class StudyProgramCourse : BaseDateTrace
{
    public Guid StudyProgramId { get; set; }

    public StudyProgram? StudyProgram { get; set; }

    public Guid CourseId { get; set; }

    public Course? Course { get; set; }
}