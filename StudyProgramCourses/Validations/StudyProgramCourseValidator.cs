using FluentValidation;
using StudyProgramCourses.Entities;

namespace StudyProgramCourses.Validations;

public class StudyProgramCourseValidator : AbstractValidator<StudyProgramCourse>
{
    public StudyProgramCourseValidator()
    {
        // StudyProgramId: Required
        RuleFor(spc => spc.StudyProgramId)
            .NotEmpty().WithMessage("Study Program ID is required.");

        // CourseId: Required
        RuleFor(spc => spc.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}